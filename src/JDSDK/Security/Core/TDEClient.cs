using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using log4net;
using Jd.ACES.Common;
using Jd.ACES.Common.Exceptions;
using Jd.ACES.Utils;
using Jd.ACES.Task;
using static Jd.ACES.Common.Constants;
using static Jd.ACES.Common.TDEStatus;
using System.Security.Cryptography;
using Jd.Api;


namespace Jd.ACES
{
    public class TDEClient
    {
        private static ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // Key - base64 token string; Value - TDEClient instance
        public static Dictionary<string, TDEClient> clientPool;
        // used in JMQ reporting
        private static string version = "1.0.0";
        // MKeys in-memory cache
        private CacheKeyStore cache_ks;
        // token holder
        private Token t;
        // Monitor Client based on Https
        private MonitorClient reporter = null;
        // Pushing epoch, default is 1 hours, unit is second
        private static long mqEpoch = 3600L;
        // KM Client
        private KMClient kmc = null;
        // refresh epoch, default is 8 hours, unit is second
        private static long kmEpoch = 28800L;
        //网关系统参数
        public JosSystemParam josSystemParam;

        // v2.0.x CipherResult
        private static readonly CipherResult malformedCipher = new CipherResult(CipherStatus.Malformed, null, false);

        // prepare Scheduler for KM client
        private static ScheduledExecutor kmScheduler;
        // prepare Scheduler for MQ client
        private static ScheduledExecutor mqScheduler;
        // mutex to prevent race condition in getInstance()
        private static Object mutex = new Object();

        // statistic record present in long array
        // index: enccnt(0) deccnt(1) encerrcnt(2) decerrcnt(3)
        //        signcnt(4) verifycnt(5) signerrcnt(6) verifyerrcnt(7)
        public enum StatisticType
        {
            ENCCNT = 0,
            DECCNT,
            ENCERRCNT,
            DECERRCNT,
            SIGNCNT,
            VERIFYCNT,
            SIGNERRCNT,
            VERIFYERRCNT
        }
        private long[] statistic = null;

        private static readonly byte[] SALT = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        private static readonly byte[] KEYWORDSALT = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
        0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F};
        static TDEClient()
        {
            if (clientPool == null)
                clientPool = new Dictionary<string, TDEClient>();
            if (kmScheduler == null)
                kmScheduler = new ScheduledExecutor(kmEpoch, FlushKeyCacheTask.Task);
            if (mqScheduler == null)
                mqScheduler = new ScheduledExecutor(mqEpoch, SendReportCacheTask.Task);
            version = version + "-dotnet";
        }

        /// <summary>
        /// Initializes a new instance of TDEClient with specified token, KMS endpoint and platform mode.
        /// </summary>
        /// <param name="serverURL">网关域名地址.</param>
        /// <param name="appKey">控制台应用appkey</param>
        /// <param name="appSecret">控制台应用appSecret</param>
        /// <param name="accessToken">网关授权token</param>
        /// <returns>The corresponding instance of TDEClient.</returns>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="MalformedException"/>
        /// <exception cref="ServiceErrorException"/>
        /// <exception cref="CorruptKeyException"/>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="ArgumentException"/>
        private TDEClient(string serverURL, string appKey, string appSecret, string accessToken)
        {
            LOGGER.Debug("Create client with a given new token string.");
            josSystemParam = new JosSystemParam();
            josSystemParam.accessToken = accessToken;
            josSystemParam.appKey = appKey;
            josSystemParam.appSecret = appSecret;
            josSystemParam.serverURL = serverURL;
            InitClient(josSystemParam);
        }

        /// <summary>
        /// Initializes the instance of TDEClient with specified token, KMS endpoint and platform mode.
        /// </summary>
        /// <param name="josSystemParam">API网关系统参数.</param>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="MalformedException"/>
        /// <exception cref="ServiceErrorException"/>
        /// <exception cref="CorruptKeyException"/>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="ArgumentException"/>
        private void InitClient(JosSystemParam josSystemParam)
        {
            try
            {

                // step 1: Build the HTTPS listener to the client
                reporter = new MonitorClient(this);

                // step 2: request voucher info 
                string tokenStr = RequestVoucher(josSystemParam);

                // step 3: load single token
                // one token can access only one app
                // throws NoSuchAlgorithmException, InvalidKeyException, SignatureException,
                // InvalidTokenException, MalformedException
                t = Token.ParseFromString(tokenStr); 
                LOGGER.InfoFormat("Token ID: {0}, origins from {1}", t.GetId(), t.GetTokenOrigin());

                // step 4: prepare MKey cache and corrupt key list
                cache_ks = new CacheKeyStore();

                // step 5: prepare KM client (separate thread) with a given epoch
                // setup necessary parameters like epoch, key cache file and backup file locations,
                // token and version number
                kmc = new KMClient(reporter, cache_ks, t, version,josSystemParam);

                // step 6: adjust settings
                reporter.SetProductionEnv();

                // step 7: allocate some statistic structure
                statistic = new long[Enum.GetNames(typeof(StatisticType)).Length];
                
                // step 8: connect KMS for flash keys
                kmc.FetchMKeys();
                // FetchMKeys are blocking call, check key chain is ready for bootup
                // if not keys here, throw new Exception(ex.Message.ToString())ception here..
                if (!kmc.IsKeyChainReady())
                {
                    throw new SystemException(SDK_HAS_NO_AVAILABLE_KEYS.GetMessage());
                }
            }
            catch (InvalidTokenException e)
            {
                LOGGER.Fatal(e.Message);
                // MQ client reports this severe exception
                reporter.InsertErrReport(
                        SDK_USE_INVALID_TOKEN.GetValue(),
                        e.Message,
                        e.StackTrace,
                        MsgLevel.SEVERE);
                throw new InvalidTokenException(e.Message);
            }
            catch (MalformedException e)
            {
                LOGGER.Fatal(e.Message); ;
                // MQ client reports this severe exception
                reporter.InsertErrReport(
                        SDK_THROW_JDK_EXCEPTION.GetValue(),
                        e.Message,
                        e.StackTrace,
                        MsgLevel.ERROR);
                throw new MalformedException(e.Message);
            }
            catch (ServiceErrorException e)
            {
                throw new ServiceErrorException(e.Message);
            }
            catch (NoValidKeyException e)
            {
                throw new NoValidKeyException(e.Message);
            }
            catch (Exception e)
            {
                LOGGER.Fatal(e.Message); ;
                // catch all exceptions and throw wrapped exception as SystemException
                reporter.InsertErrReport(
                        SDK_INTERNAL_ERROR.GetValue(),
                        e.Message,
                        e.StackTrace,
                        MsgLevel.ERROR);
                throw new SystemException(e.Message);
            }
        }

        /// <summary>
        /// Attempts to get a singleton instance of TDEClient class.
        /// </summary>
        /// <param name="serverURL">网关域名地址.</param>
        /// <param name="appKey">控制台应用appkey</param>
        /// <param name="appSecret">控制台应用appSecret</param>
        /// <param name="accessToken">网关授权token</param>
        ///     The default is production mode.</param>
        /// <returns>TDEClient instance if the token was available and the keys 
        ///     for encryption were fetched successfully.</returns>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="MalformedException"/>
        /// <exception cref="ServiceErrorException"/>
        /// <exception cref="CorruptKeyException"/>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="ArgumentException"/>
        public static TDEClient GetInstance(string serverURL, string appKey, string appSecret, string accessToken)
        {
            if (!clientPool.ContainsKey(accessToken))
            {
                lock (mutex)
                {
                    if (!clientPool.ContainsKey(accessToken))
                    {
                        // cannot find it in the pool, create one for sure
                        clientPool.Add(accessToken, new TDEClient( serverURL,appKey,appSecret,accessToken));
                    }
                }
            }
            return clientPool[accessToken];
        }

        public static TDEClient GetInstance(DefaultJdClient jdClient){
            return GetInstance(jdClient.serverUrl, jdClient.appKey, jdClient.appSecret, jdClient.accessToken);
        }

    /// <summary>
    /// Attempts to calculate index with given plaintext and salt value.
    /// </summary>
    /// <param name="pt">The given plaintext to calculate.</param>
    /// <param name="salt">The given salt value.</param>
    /// <returns>byte array of calculated index</returns>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InsufficientSaltLengthException"/>
    public static byte[] CalculateIndex(byte[] pt, byte[] salt)
        {
            return IndexCalculator.Sha256Index(pt, salt);
        }

        /// <summary>
        /// Attempts to calculate index with given plaintext and salt value.
        /// </summary>
        /// <param name="pt">The given plaintext to calculate.</param>
        /// <param name="salt">The given salt value.</param>
        /// <returns>base64 encoding string of calculated index</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InsufficientSaltLengthException"/>
        public static string CalculateStringIndex(byte[] pt, byte[] salt)
        {
            return Convert.ToBase64String(CalculateIndex(pt, salt));
        }

        /// <summary>
        /// Attempts to calculate index with given plaintext and special salt value derived from master key.
        /// </summary>
        /// <param name="pt">The given plaintext to calculate.</param>
        /// <returns>byte array of calculated index</returns>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="IndexCalculateException"/>
        public byte[] CalculateIndex(byte[] pt)
        {
            MKey k0 = this.GetEncKey(0, true);
            byte[] index = null;
            try
            {
                byte[] compute_salt = KeyEncryption.Wrap(k0, SALT);
                index = IndexCalculator.Sha256Index(pt, compute_salt);
            }
            catch (Exception e)
            {
                // rewrap the exception
                throw new IndexCalculateException(e.GetType().Name + ":" + e.Message);
            }

            return index;
        }

        /// <summary>
        /// Attempts to calculate index with given plaintext and specified salt value derived from master key.
        /// </summary>
        /// <param name="pt">The given plaintext to calculate.</param>
        /// <returns>base64 encoding string of calculated index</returns>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="IndexCalculateException"/>
        public string CalculateStringIndex(byte[] pt)
        {
            return Convert.ToBase64String(CalculateIndex(pt));
        }

        /// <summary>
        /// Checks if the ciphertext can be decrypted.
        /// </summary>
        /// <param name="ct">The byte array of ciphertext to check.</param>
        /// <returns></returns>
        public static bool isEncryptData(byte[] ct)
        {
            try
            {
                byte ctype = ct[0];
                // for weak
                bool flag = false;
                if (ctype == (byte)CipherType.LARGE || ctype == (byte)CipherType.REGULAR)
                {
                    flag = true;
                }
                else if (ctype != (byte)CipherType.WEAK)
                {
                    return false;
                }

                byte[] mkIdx = ExtractKeyId(ct, flag);
                if (mkIdx == null && mkIdx.Length<=0)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                // format error or other error
                return false;
            }
        }

        /**
         * 判断字符串是否为密文
         */
        public static bool isEncryptData(String base64ct)
        {
            try
            {
                return isEncryptData(Convert.FromBase64String(base64ct));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CipherResult GetCipherResult(byte[] ct)
        {
            try
            {
                byte ctype = ct[0];
                // for weak
                bool flag = false;
                if (ctype == (byte)CipherType.LARGE || ctype == (byte)CipherType.REGULAR)
                {
                    flag = true;
                }
                else if (ctype != (byte)CipherType.WEAK)
                {
                    return malformedCipher;
                }

                byte[] mkIdx = ExtractKeyId(ct, flag);

                if (mkIdx == null)
                    return malformedCipher;
                if (cache_ks.SearchDecKey(mkIdx) != null)
                    return new CipherResult(CipherStatus.Decryptable, mkIdx, flag);
                else if (cache_ks.HasFutureKeyID(mkIdx))
                    return new CipherResult(CipherStatus.Feasible, mkIdx, flag);
                else
                    return new CipherResult(CipherStatus.UnDecryptable, mkIdx, flag);
            }
            catch (Exception)
            {
                // format error or other error
                return malformedCipher;
            }
        }

        public CipherResult GetCipherResult(string base64ct)
        {
            CipherResult ret;
            try
            {
                ret = GetCipherResult(Convert.FromBase64String(base64ct));
            }
            catch (Exception)
            {
                return malformedCipher;
            }
            // return Malformed by default
            return ret;
        }

        /// <summary>
        /// Attemps to encrypt the specified plaintext with regular version.
        /// </summary>
        /// <param name="pt">The byte array of plaintext to encrypt.</param>
        /// <returns>The byte array of encrypted data.</returns>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="InvalidKeyException"/>
        /// <exception cref="InvalidKeyPermission"/>
        /// <exception cref="ArgumentNullException"/>
        public byte[] Encrypt(byte[] pt)
        {
            ValidateToken();
            // fetch corresponding master key and check its status
            MKey k = this.GetEncKey(this.kmc.GetMajorKeyVersion());
            LOGGER.DebugFormat("Weak encrypt with key version: {0}", k.GetVersion());

            byte[] ct;
            try
            {
                ct = k.Encrypt(pt);
                // not catch all exceptions, we only increase error count for
                // possible cases
                statistic[StatisticType.ENCCNT.GetValue()]++;
            }
            catch (ArgumentNullException e)
            {
                // null input
                statistic[StatisticType.ENCERRCNT.GetValue()]++;
                throw new Exception(e.Message.ToString());
            }
            catch (Exception e)
            {
                // master key has some issue
                statistic[StatisticType.ENCERRCNT.GetValue()]++;
                throw new SystemException(e.GetType().Name + ":" + e.Message);
            }

            return ct;
        }
        /// <summary>
        /// Attemps to decrypt the specified ciphertext and automatically recognition encryption version is regular or strong.
        /// </summary>
        /// <param name="ct">The byte array of ciphertext.</param>
        /// <returns>The byte array of decrypted data.</returns>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="InvalidKeyException"/>
        /// <exception cref="InvalidKeyPermission"/>
        /// <exception cref="MalformedException"/>
        /// <exception cref="CorruptKeyException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ServiceErrorException"/>
        public byte[] Decrypt(byte[] ct)
        {
            ValidateToken();

            MKey k = this.GetDecKey(ct);
            LOGGER.DebugFormat("Decrypt with key version: {0}", k.GetVersion());

            byte[] pt;
            // decrypt and then return plaintext
            try
            {
                pt = k.Decrypt(ct);
                // increase after decryption done
                statistic[StatisticType.DECCNT.GetValue()]++;
            }
            catch (ArgumentNullException e)
            {
                statistic[StatisticType.DECERRCNT.GetValue()]++;
                throw new Exception(e.Message.ToString());
            }
            catch (MalformedException e)
            {
                statistic[StatisticType.DECERRCNT.GetValue()]++;
                throw new Exception(e.Message.ToString());
            }
            catch (Exception e)
            {
                statistic[StatisticType.DECERRCNT.GetValue()]++;
                throw new SystemException(e.GetType().Name + ":" + e.Message);
            }
            return pt;
        }

        /// <summary>
        /// Attemps to encrypt a specified plaintext.
        /// </summary>
        /// <param name="pt">The UTF-8 encoding string of plaintext.</param>
        /// <returns>The base64 encoding string of encrypted data.</returns>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="InvalidKeyException"/>
        /// <exception cref="InvalidKeyPermission"/>
        /// <exception cref="ArgumentNullException"/>
        public string EncryptString(string pt)
        {
            return EncryptString(pt, Encoding.UTF8);
        }

        /// <summary>
        /// Attemps to encrypt a specified encoding string of plaintext.
        /// </summary>
        /// <param name="pt">The string of plaintext.</param>
        /// <param name="encoding">The encoding of plaintext.</param>
        /// <returns>The base64 encoding string of encrypted data.</returns>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="InvalidKeyException"/>
        /// <exception cref="InvalidKeyPermission"/>
        /// <exception cref="ArgumentNullException"/>
        public string EncryptString(string pt, Encoding encoding)
        {
            if (pt == null)
                throw new ArgumentNullException("Input string pt is null.");
            byte[] input = encoding.GetBytes(pt);
            byte[] ct = Encrypt(input);
            return Convert.ToBase64String(ct);
        }

        /// <summary>
        /// Attemps to decrypt the specified base64 encoding string.
        /// </summary>
        /// <param name="base64ct">The base64 encoding string to decrypt.</param>
        /// <returns>The UTF-8 encoding string of decrypted data.</returns>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="InvalidKeyException"/>
        /// <exception cref="InvalidKeyPermission"/>
        /// <exception cref="MalformedException"/>
        /// <exception cref="CorruptKeyException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ServiceErrorException"/>
        public string DecryptString(string base64ct)
        {
            return DecryptString(base64ct, Encoding.UTF8);
        }

        /// <summary>
        /// Attemps to decrypt the specified base64 encoding string and return decrypted data with speicified encoding.
        /// </summary>
        /// <param name="base64ct">The base64 encoding string to decrypt.</param>
        /// <param name="encoding">The encoding of decrypted data.</param>
        /// <returns>The specified encoding string of decrypted data.</returns>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="InvalidKeyException"/>
        /// <exception cref="InvalidKeyPermission"/>
        /// <exception cref="MalformedException"/>
        /// <exception cref="CorruptKeyException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ServiceErrorException"/>
        public string DecryptString(string base64ct, Encoding encoding)
        {
            if (base64ct == null)
                throw new ArgumentNullException("Input cipher string base64ct is NULL.");
            byte[] decoded = Convert.FromBase64String(base64ct);
            return encoding.GetString(Decrypt(decoded));
        }

        /// <summary>
        /// Attemps to encrypt specified source file and output encrypted data into another specified file.
        /// </summary>
        /// <param name="source">The file carrying plaintext.</param>
        /// <param name="dest">The file carrying encrypted data.</param>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="InvalidKeyException"/>
        /// <exception cref="InvalidKeyPermission"/>
        /// <exception cref="IOException"/>
        public void EncryptFile(string source, string dest)
        {
            // validate token
            ValidateToken();
            // fetch master key and check key status
            MKey k = this.GetEncKey(kmc.GetMajorKeyVersion());
            LOGGER.DebugFormat("Encrypt file with key version: {0}", k.GetVersion());

            try
            {
                using (FileStream fout = File.OpenWrite(dest), fin = File.OpenRead(source))
                {
                    k.Encrypt(fin, fout, fin.Length);
                    // increase counting after everything completes
                    statistic[StatisticType.ENCCNT.GetValue()]++;
                }
            }
            catch (IOException e)
            {
                statistic[StatisticType.ENCERRCNT.GetValue()]++;
                throw new Exception(e.Message.ToString());
            }
            catch (Exception e)
            {
                statistic[StatisticType.ENCERRCNT.GetValue()]++;
                LOGGER.Fatal(e.Message);
                throw new SystemException(e.GetType().Name + ":" + e.Message);
            }
        }

        /// <summary>
        /// Attemps to decrypt specified source file and output decrypted data into another specified file.
        /// </summary>
        /// <param name="source">The file carrying ciphertext.</param>
        /// <param name="dest">The file carrying decrypted data.</param>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="IOException"/>
        public void DecryptFile(string source, string dest)
        {
            // validate token
            ValidateToken();

            try
            {
                // check cipher and handle exceptions
                byte[] minheader = new byte[STRONG_HDR_LEN];
                using (FileStream fout = File.OpenWrite(dest), fin = File.OpenRead(source))
                {
                    int rdlen = fin.Read(minheader, 0, minheader.Length);
                    // throw new Exception(ex.Message.ToString())arlier
                    if (rdlen < STRONG_HDR_LEN)
                    {
                        string message = SDK_HAS_CORRUPTED_CIPHER.GetMessage() + Convert.ToBase64String(minheader);
                        reporter.InsertErrReport(
                            SDK_HAS_CORRUPTED_CIPHER.GetValue(),
                            message,
                            EMPTYSTR,
                            MsgLevel.SEVERE);
                        throw new MalformedException(message);
                    }

                    // try to extractID and check key status
                    MKey k = this.GetDecKey(minheader);
                    LOGGER.DebugFormat("Decrypt with key version: {0}", k.GetVersion());
                    fin.Position = 0;
                    // decrypt it
                    k.Decrypt(fin, fout, fin.Length);
                    // increase counting after everything completes
                    statistic[StatisticType.DECCNT.GetValue()]++;
                }
            }
            catch (IOException e)
            {
                statistic[StatisticType.DECERRCNT.GetValue()]++;
                throw new Exception(e.Message.ToString());
            }
            catch (Exception e)
            {
                statistic[StatisticType.DECERRCNT.GetValue()]++;
                LOGGER.Fatal(e.Message);
                throw new SystemException(e.GetType().Name + ":" + e.Message);
            }
        }

        /**
         * 生成自定义Token，提供给自有账号使用
         * @param userId
         * @return
         */
        public static string generateCustomerToken(long userId, String appKey)
        {
            return Constants.UNDERLINE + userId + Constants.UNDERLINE + appKey;
        }

        /// <summary>
        /// 获取token对应的凭证信息
        /// </summary>
        /// <param name="josSystemParam"></param>
        /// <returns></returns>
        public static string RequestVoucher(JosSystemParam josSystemParam)
        {
            string voucher = null;
            try
            {
                string result = null;
                string accessToken = josSystemParam.accessToken;
                JosVoucherInfoGetRequest josVoucherInfoGetRequest = new JosVoucherInfoGetRequest();
                if (!string.IsNullOrEmpty(accessToken) && accessToken.StartsWith(Constants.UNDERLINE))
                {
                    //添加自有账号逻辑，CustomerUserId为自有账号token
                    string customerUserId = accessToken.Substring(1, accessToken.LastIndexOf(Constants.UNDERLINE) - 1);
                    try
                    {
                        josVoucherInfoGetRequest.customerUserId = Convert.ToInt64(customerUserId);
                    }catch (Exception e)
                    {
                        LOGGER.Error("token invalid", e);
                    }
                }
                else{
                    josVoucherInfoGetRequest.accessToken = accessToken;
                }
                josVoucherInfoGetRequest.appKey = josSystemParam.appKey;
                josVoucherInfoGetRequest.appSecret = josSystemParam.appSecret;
                result = HttpsClientWrapper.PostJson(josSystemParam.serverURL, josVoucherInfoGetRequest.getParameters());
                JosVoucherInfoGetResponse josVoucherInfoGetResponse = JsonHelper.FromJson<JosVoucherInfoGetResponse>(result);
                if (!"0".Equals(josVoucherInfoGetResponse.getResult.code))
                {
                    throw new ServiceErrorException("gw platform error ->" + josVoucherInfoGetResponse.getResult.code);
                }
                if (!"0".Equals(josVoucherInfoGetResponse.getResult.responseData.errorCode))
                {
                    LOGGER.Error("request voucher api error"+ josVoucherInfoGetResponse.getResult.responseData.errorCode);
                    throw new InvalidTokenException("voucher api error ->" + josVoucherInfoGetResponse.getResult.code);
                }
                voucher = josVoucherInfoGetResponse.getResult.responseData.voucherEntity.voucher;
            }
            catch (Exception e)
            {
                LOGGER.Error("request voucher failure ", e);
            }
            return voucher;
        }

        /// <summary>
        /// Attemps to sign specified input.
        /// </summary>
        /// <param name="input">The array byte of input to sign.</param>
        /// <returns>The base64 encoding string of signature.</returns>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="InvalidKeyException"/>
        /// <exception cref="InvalidKeyPermission"/>
        /// <exception cref="MalformedException"/>
        public string Sign(byte[] input)
        {
            // validate token first
            ValidateToken();

            // fetch sign key and check key status
            MKey k = this.GetEncKey(kmc.GetMajorKeyVersion(), false);

            LOGGER.DebugFormat("Signing with key version: {0}", k.GetVersion());

            string sig = null;
            try
            {
                sig = k.Sign(input);
            }
            catch (MalformedException e)
            {
                statistic[StatisticType.SIGNERRCNT.GetValue()]++;
                throw new Exception(e.Message.ToString());
            }
            catch (Exception e)
            {
                statistic[StatisticType.SIGNERRCNT.GetValue()]++;
                throw new SystemException(e.GetType().Name + ":" + e.Message);
            }
            statistic[StatisticType.SIGNCNT.GetValue()]++;
            return sig;
        }

        /// <summary>
        /// Attemps to verify the signature with specified input data.
        /// </summary>
        /// <param name="data">The byte array of input data.</param>
        /// <param name="sig">The base64 encoding string of signature to verify.</param>
        /// <returns>True if verify successfully; otherwise, false.</returns>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="MalformedException"/>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="InvalidKeyException"/>
        /// <exception cref="InvalidKeyPermission"/>
        /// <exception cref="CorruptKeyException"/>
        /// <exception cref="ServiceErrorException"/>
        /// <exception cref="ArgumentException"/>
        public bool Verify(byte[] input, string sig)
        {
            // validate token
            ValidateToken();

            byte[] sigBytes = Convert.FromBase64String(sig);
            if (sigBytes.Length <= DEFAULT_KEYID_LEN + DEFAULT_SEED_LEN)
            {
                statistic[StatisticType.VERIFYERRCNT.GetValue()]++;
                throw new MalformedException("Corrupted signature with illegal length.");
            }

            byte[] keyID = new byte[DEFAULT_KEYID_LEN];
            using (MemoryStream buf = new MemoryStream(sigBytes))
            {
                buf.Read(keyID, 0, DEFAULT_KEYID_LEN);
            }

            MKey k = this.GetDecKeyByID(keyID, false);

            LOGGER.DebugFormat("Verifying with key version: {0}", k.GetVersion());

            bool ret = false;
            try
            {
                ret = k.Verify(input, sig);
                statistic[StatisticType.VERIFYCNT.GetValue()]++;
            }
            catch (MalformedException e)
            {
                statistic[StatisticType.VERIFYERRCNT.GetValue()]++;
                throw new Exception(e.Message.ToString());
            }
            catch (Exception e)
            {
                statistic[StatisticType.VERIFYERRCNT.GetValue()]++;
                throw new Exception(e.Message.ToString());
            }

            return ret;
        }

        /// <summary>
        /// Attemps to get encryption key with specified key version.
        /// </summary>
        /// <param name="keyVersion">The key version.</param>
        /// <param name="isEncryption">True in encryption mode; otherwise, false.</param>
        /// <returns>The master key for encryption.</returns>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="InvalidKeyException"/>
        /// <exception cref="InvalidKeyPermission"/>
        private MKey GetEncKey(uint keyVersion, bool isEncryption = true)
        {
            // try to fetch corresponding master key from local key store
            MKey k = this.cache_ks.GetEncKeyByVersion(keyVersion);

            // check key status
            if (k == null)
            {
                if (isEncryption)
                {
                    LOGGER.Fatal(SDK_HAS_NO_AVAILABLE_ENC_KEYS.GetMessage());
                    // should not happen, probably due to some internal error or other issues
                    reporter.InsertErrReport(
                            SDK_HAS_NO_AVAILABLE_ENC_KEYS.GetValue(),
                            SDK_HAS_NO_AVAILABLE_ENC_KEYS.GetMessage(),
                            EMPTYSTR,
                            MsgLevel.SEVERE);
                    statistic[StatisticType.ENCERRCNT.GetValue()]++;
                    throw new NoValidKeyException(SDK_HAS_NO_AVAILABLE_ENC_KEYS.GetMessage());
                }
                else
                {
                    LOGGER.Fatal(SDK_HAS_NO_AVAILABLE_SIGN_KEYS.GetMessage());
                    // should not happen, probably due to some internal error or other issues
                    reporter.InsertErrReport(
                            SDK_HAS_NO_AVAILABLE_SIGN_KEYS.GetValue(),
                            SDK_HAS_NO_AVAILABLE_SIGN_KEYS.GetMessage(),
                            EMPTYSTR,
                            MsgLevel.SEVERE);
                    statistic[StatisticType.SIGNERRCNT.GetValue()]++;
                    throw new NoValidKeyException(SDK_HAS_NO_AVAILABLE_SIGN_KEYS.GetMessage());
                }
            }

            // encrypt only for ACTIVE key
            if (k.GetKeyStatus() != KeyStatus.ACTIVE)
            {
                // Key might be revoke/suspended
                LOGGER.Fatal(SDK_OPERATE_WITH_INACTIVE_KEYS.GetMessage());
                reporter.InsertErrReport(
                        SDK_OPERATE_WITH_INACTIVE_KEYS.GetValue(),
                        SDK_OPERATE_WITH_INACTIVE_KEYS.GetMessage(),
                        EMPTYSTR,
                        MsgLevel.ERROR);
                if (isEncryption)
                    statistic[StatisticType.ENCERRCNT.GetValue()]++;
                else
                    statistic[StatisticType.SIGNERRCNT.GetValue()]++;
                throw new InvalidKeyException(SDK_OPERATE_WITH_INACTIVE_KEYS.GetMessage());
            }
            // check key permission
            if (k.GetKeyUsage() != KeyUsage.E && k.GetKeyUsage() != KeyUsage.ED)
            {
                throw new InvalidKeyPermission("Key Permission Invalid.");
            }

            // check key timestamp
            CheckExpiredKey(k);

            return k;
        }

        /// <summary>
        /// Attemps to get decryption key for specified ciphertext.
        /// </summary>
        /// <param name="ct">The byte array of key identifier.</param>
        /// <param name="st">The output cipher status.</param>
        /// <returns>The master key for decryption.</returns>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="InvalidKeyException"/>
        /// <exception cref="InvalidKeyPermission"/>
        /// <exception cref="MalformedException"/>
        /// <exception cref="ServiceErrorException"/>
        /// <exception cref="CorruptKeyException"/>
        /// <exception cref="ArgumentException"/>
        private MKey GetDecKey(byte[] ct)
        {
            // check cipher and handle exceptions
            CipherResult st = GetCipherResult(ct);
            // MQ handler for different cases
            if (st.status.Equals(CipherStatus.UnDecryptable))
            {
                int minLen = st.isStrong ? Math.Min(ct.Length, STRONG_HDR_LEN) : Math.Min(ct.Length, WEAK_HDR_LEN);
                byte[] minHeader = new byte[minLen];
                Array.Copy(ct, minHeader, minLen);
                string header = Convert.ToBase64String(minHeader);
                reporter.InsertErrReport(
                    SDK_HAS_NO_CORRESPONDING_DEC_KEYS.GetValue(),
                    SDK_HAS_NO_CORRESPONDING_DEC_KEYS.GetMessage() + header,
                    EMPTYSTR,
                    MsgLevel.SEVERE);
                statistic[StatisticType.DECERRCNT.GetValue()]++;
                throw new NoValidKeyException(SDK_HAS_NO_CORRESPONDING_DEC_KEYS.GetMessage() + header);
            }
            else if (st.status.Equals(CipherStatus.Feasible))
            {
                LOGGER.Debug("Feasible case: KMS client needs to fetch keys from KMS.");
                reporter.InsertEventReport(SDK_TRIGGER_ROTATED_KEY_FETCH.GetValue(),
                    SDK_TRIGGER_ROTATED_KEY_FETCH.GetMessage());
                // fetch keys from KMS
                // blocking call!!
                kmc.FetchMKeys();
                if (cache_ks.HasFutureKeyID(st.keyID))
                {
                    int minLen = st.isStrong ? Math.Min(ct.Length, STRONG_HDR_LEN) : Math.Min(ct.Length, WEAK_HDR_LEN);
                    byte[] minHeader = new byte[minLen];
                    Array.Copy(ct, minHeader, minLen);
                    string header = Convert.ToBase64String(minHeader);
                    reporter.InsertErrReport(
                        SDK_FAILS_TO_FETCH_UPDATED_KEYS.GetValue(),
                        SDK_FAILS_TO_FETCH_UPDATED_KEYS.GetMessage() + header,
                        EMPTYSTR,
                        MsgLevel.SEVERE);
                    statistic[StatisticType.DECERRCNT.GetValue()]++;
                    throw new NoValidKeyException(SDK_FAILS_TO_FETCH_UPDATED_KEYS.GetMessage() + header);
                }
            }
            else if (st.status.Equals(CipherStatus.Malformed))
            {
                statistic[StatisticType.DECERRCNT.GetValue()]++;
                // fetch available ciphertext
                string corrpted_cipher = "(NULL)";
                if (ct != null)
                {
                    int minLen = Math.Min(ct.Length, WEAK_HDR_LEN);
                    byte[] minHeader = new byte[minLen];
                    Array.Copy(ct, minHeader, minLen);
                    corrpted_cipher = minLen == 0 ? "(EMPTY)" : Convert.ToBase64String(minHeader);
                }
                reporter.InsertErrReport(
                    SDK_HAS_CORRUPTED_CIPHER.GetValue(),
                    SDK_HAS_CORRUPTED_CIPHER.GetMessage() + corrpted_cipher,
                    EMPTYSTR,
                    MsgLevel.SEVERE);
                throw new MalformedException(SDK_HAS_CORRUPTED_CIPHER.GetMessage() + corrpted_cipher);
            }

            return this.GetDecKeyByID(st.keyID);
        }

        /// <summary>
        /// Attemps to get decryption key with specified key identifier.
        /// </summary>
        /// <param name="keyID">The byte array of key identifier.</param>
        /// <param name="isDecryption">True in decryption mode; otherwise, false.</param>
        /// <returns>The master key for decryption.</returns>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="InvalidKeyException"/>
        /// <exception cref="InvalidKeyPermission"/>
        /// <exception cref="ServiceErrorException"/>
        /// <exception cref="CorruptKeyException"/>
        /// <exception cref="MalformedException"/>
        /// <exception cref="ArgumentException"/>
        private MKey GetDecKeyByID(byte[] keyID, bool isDecryption = true)
        {
            // try to fetch corresponding master key from local key store
            MKey k = this.cache_ks.SearchDecKey(keyID);

            if (!isDecryption)
            {
                string header = MKey.GenerateMinHeaderByKeyID(keyID);

                if (cache_ks.HasFutureKeyID(keyID))
                {
                    LOGGER.Debug("Feasible case: KMS client needs to fetch verify keys from KMS.");
                    reporter.InsertEventReport(SDK_TRIGGER_ROTATED_VERIFY_KEY_FETCH.GetValue(),
                            SDK_TRIGGER_ROTATED_VERIFY_KEY_FETCH.GetMessage());
                    kmc.FetchMKeys();
                    if (cache_ks.HasFutureKeyID(keyID))
                    {
                        reporter.InsertErrReport(
                                SDK_FAILS_TO_FETCH_UPDATED_VERIFY_KEYS.GetValue(),
                                SDK_FAILS_TO_FETCH_UPDATED_VERIFY_KEYS.GetMessage() + header,
                                EMPTYSTR,
                                MsgLevel.SEVERE);
                        statistic[StatisticType.VERIFYERRCNT.GetValue()]++;
                        throw new NoValidKeyException(SDK_FAILS_TO_FETCH_UPDATED_VERIFY_KEYS.GetMessage() + header);
                    }

                    k = this.cache_ks.SearchDecKey(keyID);
                }

                if (k == null)
                {
                    string errorMessage = SDK_HAS_NO_CORRESPONDING_VERIFY_KEYS.GetMessage() + header;
                    LOGGER.Fatal(errorMessage);
                    reporter.InsertErrReport(
                            SDK_HAS_NO_CORRESPONDING_VERIFY_KEYS.GetValue(),
                            errorMessage,
                            EMPTYSTR,
                            MsgLevel.SEVERE);
                    statistic[StatisticType.VERIFYERRCNT.GetValue()]++;
                    throw new NoValidKeyException(errorMessage);
                }
            }

            // check if key status is revoked
            if (k.GetKeyStatus() == KeyStatus.REVOKED)
            {
                // due to key rotation, decryption can use both active/suspend key but not for revoked one
                LOGGER.Fatal(SDK_OPERATE_WITH_INACTIVE_KEYS.GetMessage());
                reporter.InsertErrReport(
                        SDK_OPERATE_WITH_INACTIVE_KEYS.GetValue(),
                        SDK_OPERATE_WITH_INACTIVE_KEYS.GetMessage(),
                        EMPTYSTR,
                        MsgLevel.SEVERE);
                if (isDecryption)
                {
                    statistic[StatisticType.DECERRCNT.GetValue()]++;
                }
                else
                {
                    statistic[StatisticType.VERIFYERRCNT.GetValue()]++;
                }
                throw new InvalidKeyException(SDK_OPERATE_WITH_INACTIVE_KEYS.GetMessage());
            }

            // check key permission
            if (k.GetKeyUsage() != KeyUsage.D && k.GetKeyUsage() != KeyUsage.ED)
            {
                throw new InvalidKeyPermission("Key Permission Invalid.");
            }

            // check key timestamp
            this.CheckExpiredKey(k);

            return k;
        }

        private void CheckExpiredKey(MKey key)
        {
            long now = EnvironmentHelper.GetCurrentMillis();
            if (key.GetExpiredTime() < now)
            {
                reporter.InsertErrReport(
                        SDK_OPERATE_WITH_EXPIRED_KEYS.GetValue(),
                        SDK_OPERATE_WITH_EXPIRED_KEYS.GetMessage(),
                        EMPTYSTR,
                        MsgLevel.WARN);
                LOGGER.Debug(SDK_OPERATE_WITH_EXPIRED_KEYS.GetMessage());
            }
        }

        /// <exception cref="InvalidTokenException"/>
        private void ValidateToken()
        {
            if (!t.CheckEffective())
            {
                LOGGER.FatalFormat("Please use this token after {0}", t.GetEffectiveDate());
                // report via JMQ
                reporter.InsertErrReport(
                    SDK_USE_INEFFECTIVE_TOKEN.GetValue(),
                    SDK_USE_INEFFECTIVE_TOKEN.GetMessage(),
                    EMPTYSTR,
                    MsgLevel.SEVERE);
                // throw new exception
                throw new InvalidTokenException(SDK_USE_INEFFECTIVE_TOKEN.GetMessage());
            }
            Token.State state = t.CheckExpired(TOKEN_EXP_DELTA);
            if (state == Token.State.EXPIRED)
            {
                LOGGER.Fatal("Please apply for a new token online. The current token is already expired for more than 30 days.");
                // MQ client reports this severe exception
                reporter.InsertErrReport(
                    SDK_USE_HARD_EXPIRED_TOKEN.GetValue(),
                    SDK_USE_HARD_EXPIRED_TOKEN.GetMessage(),
                    EMPTYSTR,
                    MsgLevel.SEVERE);

                throw new InvalidTokenException(SDK_USE_HARD_EXPIRED_TOKEN.GetMessage());
            }
            else if (state == Token.State.EXPIREWARNING)
            {
                reporter.InsertErrReport(
                    SDK_USE_SOFT_EXPIRED_TOKEN.GetValue(),
                    SDK_USE_SOFT_EXPIRED_TOKEN.GetMessage(),
                    EMPTYSTR,
                    MsgLevel.WARN);

                LOGGER.Warn("Token is already expired but less than 30 days. We still allow it to be operated.");
                LOGGER.WarnFormat("Token expired date: {0}", t.GetExpiredDate());
            }
        }

        /// <summary>
        /// Computes a position-sensitive index for the specified plaintext.
        /// <para>Suitable for fixed-length or fixed-format data, such as phone number and ID card number.</para>
        /// </summary>
        /// <param name="spt">The string of plaintext to compute index for.</param>
        /// <returns>the hex string of computed index.</returns>
        public string ObtainWildCardKeyWordIndex(string spt)
        {
            if (spt == null)
            {
                throw new ArgumentNullException("plaintext is null.");
            }
            // convert to unicode encoding if plaintext contains non-ASCII character
            spt = IndexCalculator.FormatPlaintext(spt);

            MKey k = this.GetEncKey(0, true);
            byte[] key = KeyEncryption.Wrap(k, KEYWORDSALT);
            byte[] iv = new byte[24];
            Array.Copy(key, 0, iv, 0, iv.Length);
            byte[] pt = Encoding.UTF8.GetBytes(spt);

            int clen = pt.Length;
            byte[] ct = new byte[clen];
            using (SymmetricAlgorithm salsa20 = new Salsa20())
            using (ICryptoTransform encrypt = salsa20.CreateEncryptor(key, iv))
            {
                ct = encrypt.TransformFinalBlock(pt, 0, pt.Length);
            }

            return BitConverterHelper.ToHexString(ct);
        }

        /// <summary>
        /// Computes a query index for the specified keyword with wildcard character.
        /// <para>Use the asterisk '*' as a wildcard to match any ASCII charachter.</para>
        /// <para>Use the crosshatch '#' as a wildcard to match any non-ASCII charachter.</para>
        /// </summary>
        /// <param name="queryW">The string of keyword with wildcard to query.</param>
        /// <returns>the hex string of computed query index.</returns>
        public string CalculateWildCardKeyWord(string queryW)
        {
            if (queryW == null)
            {
                throw new ArgumentNullException("query keyword is null.");
            }
            // format if keyword contains wildcard for non-ASCII character
            queryW = IndexCalculator.FormatQueryKeyword(queryW);

            MKey k = this.GetEncKey(0, true);
            Console.WriteLine(k.GetRawKey().Length);

            byte[] key = KeyEncryption.Wrap(k, KEYWORDSALT);
            byte[] nonce = new byte[24];
            Array.Copy(key, 0, nonce, 0, nonce.Length);
            byte[] pt = Encoding.UTF8.GetBytes(queryW);

            // preallocate
            byte[] ct = new byte[pt.Length];
            using (SymmetricAlgorithm salsa20 = new Salsa20())
            using (ICryptoTransform encrypt = salsa20.CreateEncryptor(key, nonce))
            {
                ct = encrypt.TransformFinalBlock(pt, 0, pt.Length);
            }

            int skip = 0;
            for (int i = 0; i < queryW.Length; i++)
            {
                if (queryW[i] == WildcardPattern.ASCII)
                    skip++;
                else break;
            }

            if (skip == queryW.Length)
            {
                // query string is all *
                throw new Exception("keyword format does not match!");
            }

            byte[] rct = new byte[ct.Length - skip];
            Array.Copy(ct, skip, rct, 0, rct.Length);
            return BitConverterHelper.ToHexString(rct);
        }

        /// <summary>
        /// Computes a query index for the specified keyword with wildcard.
        /// </summary>
        /// <param name="keyword">The string of keyword to query.</param>
        /// <param name="asciiCharPrefixNumber">The number of ASCII wildcard character.</param>
        /// <param name="nonAsciiCharPrefixNumber">The number of non-ASCII wildcard character.</param>
        /// <returns>the hex string of computed query index.</returns>
        public string CalculateWildCardKeyWord(string keyword, int asciiCharPrefixNumber, int nonAsciiCharPrefixNumber = 0)
        {
            string queryW = IndexCalculator.GenerateWildcardKeyword(keyword, asciiCharPrefixNumber, nonAsciiCharPrefixNumber);
            return CalculateWildCardKeyWord(queryW);
        }

        /// <summary>
        /// Computes a position-insensitive index for the specified plaintext.
        /// <para>Suitable for variable length data, such as name and address.</para>
        /// </summary>
        /// <param name="spt">The string of plaintext to compute index for.</param>
        /// <returns>base64 encoding string of computed index.</returns>
        public string ObtainKeyWordIndex(string spt)
        {
            if (spt == null)
            {
                throw new ArgumentNullException("plaintext is null.");
            }
            MKey k = this.GetEncKey(0, true);
            byte[] key = KeyEncryption.Wrap(k, KEYWORDSALT);
            byte[] iv = new byte[24];
            Array.Copy(key, 0, iv, 0, iv.Length);

            byte[] ct = new byte[spt.Length * 4];
            int offset = 0;
            StringBuilder buffer = new StringBuilder();

            using (SymmetricAlgorithm salsa20 = new Salsa20())
            using (ICryptoTransform encrypt = salsa20.CreateEncryptor(key, iv))
            {
                for (int i = 0, l = spt.Length; i < l; i++)
                {
                    byte[] wpt = Encoding.UTF8.GetBytes(spt.Substring(i, 1));
                    if (wpt.Length < 4)
                    {
                        // padding with key string
                        int padOffset = (wpt[0] > 127 ? 256 - wpt[0] : wpt[0]) % (key.Length - 8);
                        int padSize = 4 - wpt.Length;
                        byte[] wpt2 = new byte[4];
                        Array.Copy(wpt, wpt2, Math.Min(wpt.Length, 4));
                        wpt = wpt2;
                        Array.Copy(key, 4 + padOffset, wpt, wpt.Length - padSize, padSize);
                    }
                    encrypt.TransformBlock(wpt, 0, 4, ct, offset);
                    byte[] rct = new byte[4];
                    Array.Copy(ct, offset, rct, 0, rct.Length);
                    buffer.Append(Convert.ToBase64String(rct).Replace("==", string.Empty));
                    offset += 4;
                }
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Computes a query index for the specified keyword.
        /// </summary>
        /// <param name="queryW">The string of keyword to query.</param>
        /// <returns>base64 encoding string of computed query index.</returns>
        public string CalculateKeyWord(string queryW)
        {
            return ObtainKeyWordIndex(queryW);
        }

        private static byte[] ExtractKeyId(byte[] ct, bool isStrong)
        {
            byte[] eid;
            using (MemoryStream buf = new MemoryStream(ct))
            {
                // skip ciphertext type
                byte ctype = (byte)buf.ReadByte();
                if (isStrong)
                {
                    byte[] len = new byte[2];
                    buf.Read(len, 0, 2);
                    ushort eidLen = BitConverterHelper.ToUInt16(len, 0);
                    // add length checking, not enough space
                    if (ct.Length - 3 < eidLen)
                        return null;
                    eid = new byte[eidLen];
                    buf.Read(eid, 0, eidLen);
                }
                else
                {
                    // skip algorithm
                    byte atype = (byte)buf.ReadByte();
                    // add length checking, not enough space
                    if (ct.Length - 2 < DEFAULT_KEYID_LEN)
                        return null;
                    eid = new byte[DEFAULT_KEYID_LEN];
                    buf.Read(eid, 0, DEFAULT_KEYID_LEN);
                }
            }

            return eid;
        }

        /// <summary>
        /// Attempts to set the interval, in seconds, for repeated execution.
        /// </summary>
        /// <param name="epoch">The given time interval, unit is second.</param>
        public void SetRefreshEpoch(long epoch)
        {
            LOGGER.DebugFormat("Set epoch for MQ/KM threads. Value = {0} seconds.", epoch);
            kmEpoch = mqEpoch = epoch;
            kmScheduler.SetExecuteInterval(kmEpoch);
            mqScheduler.SetExecuteInterval(mqEpoch);
        }

        /// <summary>
        /// Delete all keys in memory and reset the key chain status flag
        /// </summary>
        public void ManuallyDeleteKeys()
        {
            cache_ks.RemoveAllMKeys();
            kmc.ResetKeyChainFlag();
        }

        public bool IsKeyChainReady()
        {
            return kmc.IsKeyChainReady();
        }

        public static string GetSDKVersion()
        {
            return version;
        }

        public long[] GetStatistic()
        {
            long[] tmp = new long[this.statistic.Length];
            Array.Copy(this.statistic, tmp, this.statistic.Length);
            return tmp;
        }

        public string GetServiceIdentifier()
        {
            // encapsulate all details in attributes
            return (t == null) ? "Unknown Service" : t.GetServiceName();
        }

        public string GetTokenIdentifier()
        {
            // encapsulate all details in attributes
            return (t == null) ? "Unknown TID" : t.GetId();
        }
        public KMClient GetKMClient()
        {
            return kmc;
        }
        public MonitorClient GetMonitorClient()
        {
            return reporter;
        }
    }
    public class CipherResult
    {
        public CipherStatus status;
        public byte[] keyID;
        public bool isStrong;
        public CipherResult(CipherStatus status, byte[] keyID, bool isStrong)
        {
            this.keyID = keyID;
            this.status = status;
            this.isStrong = isStrong;
        }
    }

    // CipherStatus (return from canDecrypt)
    public enum CipherStatus
    {
        Decryptable,          // valid cipher, can be decrypted
        Malformed,            // invalid cipher because the format is malformed (by checking cipher header)
        Feasible,             // valid cipher with future key id, could decrypt the cipher but required to pull keys
        UnDecryptable         // valid cipher but undecryptable (keyid is neither in key cache or future keyid list
    }
}