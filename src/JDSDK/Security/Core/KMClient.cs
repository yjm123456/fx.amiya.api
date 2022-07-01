using System;
using System.Collections.Generic;
using log4net;
using Jd.ACES.Common;
using Jd.ACES.Common.Exceptions;
using Jd.ACES.Utils;
using static Jd.ACES.Common.TDEStatus;
using static Jd.ACES.Common.Constants;

namespace Jd.ACES
{
    public class KMClient
    {
        private static ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // MQ reference
        private MonitorClient reporter;
        // Token reference
        private Token userToken;
        // MKeys in-memory cache
        private CacheKeyStore cacheKs;
        // fail list for return keys which fail in verification procedure
        private HashSet<string> corruptKeylist;
        // available key list for all enc/dec keys, pair = (service, # of keys)
        private Dictionary<string, int> availableKeylist;
        // flag to indicate encryption/decryption keys are ready in memory
        private bool keyChainIsReady = false;
        // newest version holder for major service
        private uint majorKeyVer;
        // mutex to prevent race condition in getInstance()
        private static Object mutex = new Object();
        // major sdk version number (for major upgrade)
        private int majorSdkVer = 0;
        //网关系统参数
        JosSystemParam josSystemParam;

        private static readonly string[] sensitiveFields = { "sig", "key_string", "key_digest", "mkey", "mkey_digest" };

        public KMClient(MonitorClient mq, CacheKeyStore ks, Token t, string version, JosSystemParam jyp)
        {
            // assign references
            reporter = mq;
            cacheKs = ks;
            userToken = t;
            this.josSystemParam = jyp;
            corruptKeylist = new HashSet<string>();
            availableKeylist = new Dictionary<string, int>();
            majorSdkVer = Convert.ToInt32(version.Substring(0, 1));
            LOGGER.DebugFormat("major_sdk_version = {0}", majorSdkVer);
        }

        /// <summary>
        /// Defines a task to fetch master keys from KMS server.
        /// </summary>
        public void Flush()
        {
            LOGGER.Debug("Key Management Thread Performs Key Updating...");

            // catch all exceptions
            try
            {
                FetchMKeys();
                // only send MQ for particular exceptions
            }
            catch (MalformedException ex)
            {
                LOGGER.Fatal(ex.Message);
                // MQ client reports throwable exception
                DeliverExceptionMQ(ex);
            }
            catch (NoValidKeyException ex)
            {
                LOGGER.Fatal(ex.Message);
                // MQ client reports throwable exception
                DeliverExceptionMQ(ex);
            }
            catch (InvalidTokenException ex)
            {
                LOGGER.Fatal(ex.Message);
                // MQ client reports throwable exception
                DeliverExceptionMQ(ex);
            }
            catch (Exception ex)
            {
                LOGGER.Fatal(ex.Message);
            }
        }

        private void DeliverExceptionMQ(Exception e)
        {
            reporter.InsertErrReport(
                    SDK_THROW_JDK_EXCEPTION.GetValue(),
                    e.Message,
                    e.StackTrace,
                    MsgLevel.ERROR);
        }

        /// <summary>
        /// Attemps to fetch master keys from KMS server.
        /// </summary>
        /// <exception cref="ServiceErrorException"/>
        /// <exception cref="CorruptKeyException"/>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="MalformedException"/>
        /// <exception cref="ArgumentException"/>
        public void FetchMKeys()
        {
            try
            {
                KeyRequest keyRequest;
                lock (mutex)
                {
                    keyRequest = KeyRequest.CreateNewKeyRequest(userToken, majorSdkVer);
                    LOGGER.DebugFormat("Key Request: {0}", JsonHelper.ToDesensitiveJson(keyRequest, sensitiveFields));
                }
                //根据凭证获取密钥信息
                KeyResponse kr = RequestMK(keyRequest);

                LOGGER.DebugFormat("Key Response: {0}", JsonHelper.ToDesensitiveJson(kr, sensitiveFields));

                // prepare corrupt key list
                corruptKeylist.Clear();

                if (kr.StatusCode == 0)
                {
                    // import keys to memory
                    ImportMKeys(kr);
                }
                else
                {
                    LOGGER.DebugFormat("ERR CODE: {0}; ERR MESSAGE: {1}", kr.StatusCode, kr.StatusMessage);
                    // handle error response from KMS/TMS
                    // serious TMS errors, remove all keys in cache
                    if ((kr.StatusCode == TMS_REQUEST_VERIFY_FAILED.GetValue())
                            || (kr.StatusCode == TMS_TOKEN_EXPIRE.GetValue())
                            || (kr.StatusCode == TMS_NO_AVAILABLE_GRANTS_FOR_SERVICE.GetValue())
                            || (kr.StatusCode == TMS_TOKEN_IS_FROZEN.GetValue())
                            || (kr.StatusCode == TMS_TOKEN_IS_REVOKE.GetValue())
                            || (kr.StatusCode == TMS_DB_DATA_NOTFOUND_ERROR.GetValue())
                            )
                    {
                        // errors from TMS
                        reporter.InsertErrReport(
                                kr.StatusCode,
                                kr.StatusMessage,
                                EMPTYSTR,
                                MsgLevel.SEVERE);
                        // handle cases: frozen, expired, verify failed, revoke
                        // for security reason, better to remove all keys
                        cacheKs.RemoveAllMKeys();
                        // set flag to false
                        keyChainIsReady = false;
                    }
                    else
                    {
                        // other errors
                        reporter.InsertErrReport(
                                kr.StatusCode,
                                kr.StatusMessage,
                                EMPTYSTR,
                                MsgLevel.ERROR);
                    }

                    throw new ServiceErrorException(kr.StatusMessage);
                }
            }
            catch (ArgumentNullException e)
            {
                LOGGER.Fatal(e.Message);
                throw new MalformedException(e.Message);
            }
            catch (SystemException e)
            {
                // report KMS error no matter what
                LOGGER.Fatal(e.Message);
                // adjust the KMS unreachable to warning level
                reporter.InsertErrReport(
                        SDK_CANNOT_REACH_KMS.GetValue(),
                        SDK_CANNOT_REACH_KMS.GetMessage() + e.Message,
                        e.StackTrace,
                        MsgLevel.WARN);

                throw new SystemException(SDK_CANNOT_REACH_KMS.GetMessage() + e.Message);
            }
        }

        /// <summary>
        /// Attemps to import master keys fetched from KMS server to memory.
        /// </summary>
        /// <exception cref="ServiceErrorException"/>
        /// <exception cref="CorruptKeyException"/>
        /// <exception cref="NoValidKeyException"/>
        /// <exception cref="MalformedException"/>
        /// <exception cref="ArgumentException"/>
        /// <param name="kr"></param>
        private void ImportMKeys(KeyResponse kr)
        {            
            // check major service name and token ID
            if (!kr.EncService.Equals(userToken.GetServiceName()))
            {
                LOGGER.Fatal(SDK_RECEIVED_WRONG_KEYRESPONSE1.GetMessage());
                reporter.InsertErrReport(
                        SDK_RECEIVED_WRONG_KEYRESPONSE1.GetValue(),
                        SDK_RECEIVED_WRONG_KEYRESPONSE1.GetMessage(),
                        EMPTYSTR,
                        MsgLevel.ERROR);
                throw new ServiceErrorException(SDK_RECEIVED_WRONG_KEYRESPONSE1.GetMessage());
            }
            if (!kr.Tid.Equals(userToken.GetId()))
            {
                LOGGER.Fatal(SDK_RECEIVED_WRONG_KEYRESPONSE2.GetMessage());
                reporter.InsertErrReport(
                        SDK_RECEIVED_WRONG_KEYRESPONSE2.GetValue(),
                        SDK_RECEIVED_WRONG_KEYRESPONSE2.GetMessage(),
                        EMPTYSTR,
                        MsgLevel.ERROR);
                throw new ServiceErrorException(SDK_RECEIVED_WRONG_KEYRESPONSE2.GetMessage());
            }

            // get two lists of key IDs to make sure old keys could be removed from cache_ks
            List<string> enc_rmv_list = cacheKs.GetKeyIDList(KStoreType.ENC_STORE);
            List<string> dec_rmv_list = cacheKs.GetKeyIDList(KStoreType.DEC_STORE);

            List<ServiceKeyInfo> list = kr.ServiceKeyList;
            cacheKs.ResetFutureKeyIDs();

            foreach (ServiceKeyInfo service in list)
            {
                // granted services
                List<MKData> mkeys = service.Keys;
                // add available key list entry
                // entry: service -> max key version
                if (availableKeylist.ContainsKey(service.Service))
                    availableKeylist[service.Service] = mkeys.Count - 1;
                else
                    availableKeylist.Add(service.Service, mkeys.Count - 1);

                foreach (MKData key in mkeys)
                {
                    MKey k = new MKey(
                            service.Service,
                            Convert.FromBase64String(key.Id),
                            Convert.FromBase64String(key.KeyString),
                            key.KeyDigest,
                            key.Version,
                            key.KeyEffective,
                            key.KeyExp,
                            key.KeyType,
                            service.GrantUsage,
                            key.KeyStatus);

                    if (k.IsValid())
                    {
                        if (service.Service.Equals(userToken.GetServiceName()))
                        {
                            // major service, require to update key version
                            // v2.0.x will use any version assigned by KMS
                            majorKeyVer = service.CurrentKeyVersion;
                            // update to enc/dec key cache if necessary
                            cacheKs.UpdateKey(key.Id, k, KStoreType.ENC_STORE);
                            cacheKs.UpdateKey(key.Id, k, KStoreType.DEC_STORE);
                            enc_rmv_list.Remove(key.Id);
                            dec_rmv_list.Remove(key.Id);
                        }
                        else
                        {
                            // update to decryption key cache only
                            cacheKs.UpdateKey(key.Id, k, KStoreType.DEC_STORE);
                            dec_rmv_list.Remove(key.Id);
                        }

                    }
                    else
                    {
                        // if key is corrupted
                        corruptKeylist.Add(Convert.ToBase64String(k.GetID()));
                    }
                }

                // v2.0.x, pre-compute key id
                // create service key-id list
                cacheKs.UpdateFutureKeyIDs(service.Service, service.CurrentKeyVersion);
            }

            // generate key update report with assigned key list information
            reporter.InsertKeyUpdateEventReport(SDK_REPORT_CUR_KEYVER.GetValue(),
                    SDK_REPORT_CUR_KEYVER.GetMessage() + majorKeyVer, majorKeyVer, availableKeylist);
            availableKeylist.Clear();

            // adjust key store cache
            if (enc_rmv_list.Count > 0)
                cacheKs.RemoveKeysViaList(enc_rmv_list, KStoreType.ENC_STORE);
            if (dec_rmv_list.Count > 0)
                cacheKs.RemoveKeysViaList(dec_rmv_list, KStoreType.DEC_STORE);

            // verify key store by compare their digest
            SendCorruptReport();
            // check valid key chain
            CheckValidKeyChain();
        }

        /// <summary>
        /// Sends a report if there exists corrupt keys.
        /// </summary>
        /// <exception cref="CorruptKeyException"/>
        private void SendCorruptReport()
        {
            if (corruptKeylist.Count != 0)
            {
                LOGGER.Fatal(SDK_HAS_CORRUPTED_KEYS.GetMessage());
                // prepare String
                string keyids = "keyids:";
                foreach (string x in corruptKeylist)
                {
                    keyids += x + ",";
                }
                keyids = keyids.Substring(0, keyids.Length - 1);
                reporter.InsertErrReport(
                        SDK_HAS_CORRUPTED_KEYS.GetValue(),
                        SDK_HAS_CORRUPTED_KEYS.GetMessage(),
                        keyids,
                        MsgLevel.ERROR);
                // throw new exception here
                throw new CorruptKeyException(SDK_HAS_CORRUPTED_KEYS.GetMessage());
            }
        }

        /// <summary>
        /// Checks if key chain is ready with fail-fast behavior.
        /// </summary>
        /// <exception cref="NoValidKeyException"/>
        private void CheckValidKeyChain()
        {
            keyChainIsReady = false;
            int total_keys = cacheKs.NumOfKeys(KStoreType.DEC_STORE) + cacheKs.NumOfKeys(KStoreType.ENC_STORE);
            // fail-fast
            if (total_keys == 0)
            {
                LOGGER.Fatal(SDK_HAS_NO_AVAILABLE_KEYS.GetMessage());
                // should not happen, probably due to some internal error or other issues
                reporter.InsertErrReport(
                        SDK_HAS_NO_AVAILABLE_KEYS.GetValue(),
                        SDK_HAS_NO_AVAILABLE_KEYS.GetMessage(),
                        EMPTYSTR,
                        MsgLevel.SEVERE);
                throw new NoValidKeyException(SDK_HAS_NO_AVAILABLE_KEYS.GetMessage());
            }

            LOGGER.DebugFormat("# of enc keys: {0} and # of dec keys: {1}", cacheKs.NumOfKeys(KStoreType.ENC_STORE), cacheKs.NumOfKeys(KStoreType.DEC_STORE));
            LOGGER.DebugFormat("Max key version for major service: {0}", majorKeyVer);

            // at least the memory has functional keychain already
            keyChainIsReady = true;
        }
        /// <summary>
        /// 获取主密钥请求
        /// </summary>
        /// <param name="keyRequest"></param>
        /// <returns></returns>
        private KeyResponse RequestMK(KeyRequest keyRequest)
        {
            JosMasterKeyGetRequest josMasterKeyGetRequest = new JosMasterKeyGetRequest();
            josMasterKeyGetRequest.sdk_ver = keyRequest.Data.SdkVer;
            josMasterKeyGetRequest.ts = keyRequest.Data.Ts;
            josMasterKeyGetRequest.tid = keyRequest.Data.Tid;
            josMasterKeyGetRequest.sig = keyRequest.Sig;
            josMasterKeyGetRequest.appKey = josSystemParam.appKey;
            josMasterKeyGetRequest.appSecret = josSystemParam.appSecret;
            //request KMS MKey
            string result = HttpsClientWrapper.PostJson(josSystemParam.serverURL, josMasterKeyGetRequest.getParameters());
            JosMasterKeyGetResponse josMasterKeyGetResponse = JsonHelper.FromJson<JosMasterKeyGetResponse>(result);

            if (!"0".Equals(josMasterKeyGetResponse.getResponse.code))
            {
                throw new ServiceErrorException("gw platform error ->" + josMasterKeyGetResponse.getResponse.code);
            }
            if (josMasterKeyGetResponse.getResponse.keyResponse.StatusCode != 0)
            {
                LOGGER.Warn("mkey api error ->: " + josMasterKeyGetResponse.getResponse.keyResponse.StatusMessage);
            }
            return josMasterKeyGetResponse.getResponse.keyResponse;
        }
        
        public uint GetMajorKeyVersion()
        {
            return majorKeyVer;
        }

        public bool IsKeyChainReady() { return keyChainIsReady; }

        public void ResetKeyChainFlag() { keyChainIsReady = false; }

    }

    public enum KStoreType : byte
    {
        ENC_STORE = (byte)0,
        DEC_STORE = (byte)1
    }

    public class CacheKeyStore
    {
        // keyid -> MKey (encryption)
        private TDEConcurrentDictionary<string, MKey> encKeystore;
        // keyid -> Mkey (decryption)
        private TDEConcurrentDictionary<string, MKey> decKeystore;
        private HashSet<string> futureKeyIds;
        private const int TVALUE = 3;

        public CacheKeyStore()
        {
            encKeystore = new TDEConcurrentDictionary<string, MKey>();
            decKeystore = new TDEConcurrentDictionary<string, MKey>();
            futureKeyIds = new HashSet<string>();
        }

        public int NumOfKeys(KStoreType t)
        {
            if (t == KStoreType.ENC_STORE)
                return encKeystore.Count;
            else
                return decKeystore.Count;
        }

        public MKey SearchDecKey(byte[] mkIndex)
        {
            MKey retKey = null;
            decKeystore.TryGetValue(Convert.ToBase64String(mkIndex), out retKey);
            return retKey;
        }

        public MKey GetEncKeyByVersion(uint keyVer)
        {
            foreach (MKey k in encKeystore.Values)
            {
                if (k.GetVersion() == keyVer)
                {
                    return k;
                }
            }
            return null;
        }

        public List<string> GetKeyIDList(KStoreType t)
        {
            if (t == KStoreType.ENC_STORE)
                return new List<string>(encKeystore.Keys);
            else
                return new List<string>(decKeystore.Keys);
        }

        public void RemoveKeysViaList(ICollection<string> target, KStoreType t)
        {
            if (t == KStoreType.ENC_STORE)
            {
                encKeystore.Remove(target);
            }
            else
            {
                decKeystore.Remove(target);
            }
        }

        public void ResetFutureKeyIDs()
        {
            futureKeyIds.Clear();
        }

        public bool HasFutureKeyID(byte[] keyid)
        {
            return futureKeyIds.Contains(Convert.ToBase64String(keyid));
        }

        public void UpdateFutureKeyIDs(string service, uint maxVer)
        {
            uint sindex = maxVer + 1;
            for (uint i = sindex; i < sindex + TVALUE; i++)
            {
                // compute future keyids
                futureKeyIds.Add(KeyDerivation.KeyIDString(service, i));
            }
        }

        public void UpdateKey(string b64Index, MKey k, KStoreType t)
        {
            var keyStore = t == KStoreType.ENC_STORE ? encKeystore : decKeystore;
            // update it when key is new to cache or status has been changed
            if (!keyStore.ContainsKey(b64Index))
                keyStore.Add(b64Index, k);
            else
            {
                keyStore.TryGetValue(b64Index, out MKey oldk);
                if (!oldk.GetKeyStatus().EqualValue(k.GetKeyStatus()))
                {
                    // status changes
                    keyStore.TryUpdate(b64Index, k, oldk);
                }
            }

        }

        public void RemoveAllMKeys()
        {
            encKeystore.Clear();
            decKeystore.Clear();
        }
    }

}
