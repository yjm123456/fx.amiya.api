using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Jd.ACES.Utils;
using Jd.ACES.Common.Exceptions;

namespace Jd.ACES.Common
{
    public class Token : ITokenCipher, ITokenSignature
    {
        private string label;           // label, could be create, update, and other types
        private long effectiveTs;      // token active timestamp, unix time format
        private long expiredTs;        // token expired timesatmp, unix time format
        private string id;              // token identifier, encoded in Base64
        private byte[] key;             // token credential, symmetric key for HMAC
        private string service = "Unknown";         // token major service
        private Origin stype;              // service type, 0 for IDC, 1 for Beta,
        private bool isVerify = false; // token is verified or not
        private string zone = "CN-0";   // zone field, default value is CN-0 if not assigned
        private static X509Certificate2 scert = null;
        private DataEncryption de;

        /// <summary>
        /// Token constructor to initialize itself by given certain fields,
        /// including label, identifier, key, service name, effective and
        /// expired time stamp, and issue type (stype, online or offline).
        /// </summary>
        private Token(string label, string id, byte[] key, long effectiveTs, long expiredTs,
            Origin stype, string service, string zone)
        {

            this.label = label;
            this.effectiveTs = effectiveTs;
            this.expiredTs = expiredTs;

            this.id = id;
            this.key = key;
            this.service = service;
            this.stype = stype;
            this.isVerify = true;
            if (zone != null) this.zone = zone;

            // init cipher and sign objects
            this.de = new DataEncryption(this.key);
        }

        /// <summary>
        /// Attemps to load certificate from hardcode SDK to validate token.
        /// </summary>
        /// <param name="isProd">True if it is production mode; otherwise, false.</param>
        private static void LoadCert()
        {
            try
            {
                scert = new X509Certificate2(Encoding.Default.GetBytes(Constants.TMS_PROD_TOKEN_CERT));
            }
            catch (Exception)
            {
                scert = null;
            }
        }

        /// <summary>
        /// Attemps to parse a new instance of Token from the specified token and platform mode.
        /// </summary>
        /// <param name="base64Token">The base64 encoding string of token to parse.</param>
        /// <param name="isProd">True if it is production mode; otherwise, false.</param>
        /// <returns>The corresponding instance of Token if no exception occur.</returns>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="MalformedException"/>
        public static Token ParseFromString(string base64Token)
        {
            TokenStruct token;
            string data;
            byte[] sigBytes;
            try
            {
                var input = Convert.FromBase64String(base64Token);
                token = JsonHelper.FromJson<TokenStruct>(input);
                data = JsonHelper.ToJson(token.Data);
                sigBytes = Convert.FromBase64String(token.Sig);
            }
            catch (Exception)
            {
                throw new InvalidTokenException(TDEStatus.SDK_USE_INVALID_TOKEN.GetMessage());
            }

            string label = token.Data.Act;
            long startTs = token.Data.Effective;
            long endTs = token.Data.Expired;
            string id = token.Data.Id;

            byte[] key = Convert.FromBase64String(token.Data.Key);
            string service = token.Data.Service;
            Origin sType = EnumHelper.FromValue<Origin>(token.Data.Stype);
            string zone = null;

            if (token.ExternalData != null)
            {
                zone = token.ExternalData.Zone;
            }

            LoadCert();

            if (scert == null) { throw new SystemException("No Trust Anchor Certificate Available"); }

            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
            RSAPKCS1SignatureDeformatter rsaDeformatter = new RSAPKCS1SignatureDeformatter(scert.PublicKey.Key);
            rsaDeformatter.SetHashAlgorithm(Constants.DEFAULT_TOKEN_VERIFY_ALGO);            
            if (!rsaDeformatter.VerifySignature(hash, sigBytes))
            {
                throw new InvalidTokenException("Token Signature Validation Failed.");
            }

            // assign parsing fields back to Token t and return it
            return new Token(label, id, key, startTs, endTs, sType, service, zone);
        }

        public string GetId() { return this.id; }

        public string GetServiceName() { return this.service; }

        public Origin GetOriginType() { return this.stype; }

        /// <summary>
        /// Checks token is effective (active) or not.
        /// </summary>
        /// <returns>true if token is active; otherwise, false.</returns>
        public bool CheckEffective()
        {
            long now = EnvironmentHelper.GetCurrentMillis();
            return now >= this.effectiveTs;
        }

        /// <summary>
        /// Checks token is expired (inactive) or not.
        /// </summary>
        /// <param name="delta">delta value for extended tolerance (in millisecond).</param>
        /// <returns>Enum type indicating token state. 
        ///         VALID indicates the token is still valid(not expired). 
        ///         EXPIREWARNING indicates the token is expired within delta millisecond.
        ///         EXPIRED means the token is expired more than delta millisecond.</returns>
        public State CheckExpired(long delta)
        {
            long now = EnvironmentHelper.GetCurrentMillis();
            if (expiredTs >= now)
                return State.VALID;
            else if (expiredTs + delta >= now)
                return State.EXPIREWARNING;
            else
                return State.EXPIRED;
        }

        public string GetExpiredDate()
        {
            return EnvironmentHelper.FormatMsDateToString(this.expiredTs);
        }

        public long GetExpiredDateInLong() { return expiredTs; }

        public string GetEffectiveDate()
        {
            return EnvironmentHelper.FormatMsDateToString(this.effectiveTs);
        }

        public string GetZone() { return this.zone; }

        public string GetTokenOrigin() { return stype.ToString(); }

        /// <summary>
        /// Attemps to encrypt the specified plaintext.
        /// </summary>
        /// <param name="plaintext">The byte array of plaintext to encrypt.</param>
        /// <returns>The byte array of encrypted data.</returns>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="ArgumentNullException"/>
        public byte[] DoEncrypt(byte[] plaintext)
        {
            if (!isVerify)
                throw new InvalidTokenException("Not a verified token.");
            return de.Encrypt(plaintext);
        }

        /// <summary>
        /// Attemps to decrypt the specified ciphertext.
        /// </summary>
        /// <param name="ciphertext">The byte array of ciphertext to decrypt.</param>
        /// <returns>The byte array of decrypted data.</returns>
        /// <exception cref="InvalidTokenException"/>
        /// <exception cref="ArgumentNullException"/>
        public byte[] DoDecrypt(byte[] ciphertext)
        {
            if (!isVerify)
                throw new InvalidTokenException("Not a verified token.");
            return de.Decrypt(ciphertext);
        }

        /// <summary>
        /// Computes the signature for the specified input data.
        /// </summary>
        /// <param name="input">The byte array of input to compute hash value for.</param>
        /// <returns>The computed byte array.</returns>
        /// <exception cref="InvalidTokenException"/>
        public byte[] DoSign(byte[] input)
        {
            if (!isVerify)
                throw new InvalidTokenException("Not a verified token.");
            byte[] sig = null;
            using (HMACSHA256 hmac = new HMACSHA256(this.key))
            {
                sig = hmac.ComputeHash(input);
            }
            return sig;
        }

        /// <summary>
        /// Attemps to verify the signature for the specified input data.
        /// </summary>
        /// <param name="input">The byte array of input data.</param>
        /// <param name="sig">The byte array of signature to verify.</param>
        /// <returns>True if verify successfully; otherwise, false.</returns>
        /// <exception cref="InvalidTokenException"/>
        public bool DoVerify(byte[] input, byte[] sig)
        {
            if (!isVerify)
                throw new InvalidTokenException("Not a verified token.");
            // call doSign on the input
            byte[] csig = DoSign(input);
            return csig.SequenceEqual(sig);
        }

        // Token status
        public enum State
        {
            VALID,
            EXPIREWARNING,
            EXPIRED
        }

        public enum Origin
        {

            UNDEFINED = 0,
            IDC = 1,
            BETA = 2,
            DEV = 3
        }
    }

    public class TokenStruct
    {
        [JsonProperty("sig")]
        public string Sig { get; set; }
        [JsonProperty("data")]
        public InnerStruct Data { get; set; }
        [JsonProperty("externalData")]
        public ExternalStruct ExternalData { get; set; }

        public class ExternalStruct
        {
            [JsonProperty("zone")]
            public string Zone { get; set; }
        }

        public class InnerStruct
        {
            [JsonProperty("act")]
            public string Act { get; set; }
            [JsonProperty("effective")]
            public long Effective { get; set; }
            [JsonProperty("expired")]
            public long Expired { get; set; }
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("key")]
            public string Key { get; set; }
            [JsonProperty("service")]
            public string Service { get; set; }
            [JsonProperty("stype")]
            public int Stype { get; set; }
        }
    }

    public interface ITokenCipher
    {
        byte[] DoEncrypt(byte[] plaintext);
        byte[] DoDecrypt(byte[] ciphertext);
    }

    public interface ITokenSignature
    {
        byte[] DoSign(byte[] input);
        bool DoVerify(byte[] input, byte[] sig);
    }
}
