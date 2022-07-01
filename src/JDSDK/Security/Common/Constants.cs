namespace Jd.ACES.Common
{
    public class Constants
    {
        public const string DEFAULT_TOKEN_VERIFY_ALGO = "SHA256";
        public const string EMPTYSTR = "";
        public const int DEFAULT_DKEY_LEN = 16;
        public const int DEFAULT_MEKEY_LEN = 16;
        public const int DEFAULT_MSKEY_LEN = 32;
        public const int DEFAULT_IV_LEN = 16;
        public const int DEFAULT_KEYID_LEN = 16;
        public const int DEFAULT_CIPHERBLK_LEN = 16;
        public const int DEFAULT_SEED_LEN = 16;
        public const int MIN_SALT_LEN = 16;
        // 5000 ms for default time out
        public const int HTTP_TIMEOUT = 5000;
        // 2 times for default reties
        public const int HTTP_RETRY_MAX = 2;
        // 2 times for index reties
        public const int INDEX_RETRY_MAX = 2;
        // default delta value for token expiration
        public const long TOKEN_EXP_DELTA = 2592000000L;
        public const int WEAK_HDR_LEN = 1 + 1 + 16;
        public const int STRONG_HDR_LEN = 1 + 2 + 16 + 1 + 2 + 16 + 1 + 4;
        // api gateway  param
        public const string APP_KEY = "app_key";
        public const string FORMAT = "format";
        public const string METHOD = "method";
        public const string TIMESTAMP = "timestamp";
        public const string VERSION = "v";
        public const string SIGN = "sign";
        public const string ACCESS_TOKEN = "access_token";
        public const string PARAM_JSON = "360buy_param_json";
        public const string DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        public const string UNDERLINE = "_";

        // KMS api configuration
        public const string KMS_API_SERVER = "jingdong.jos.master.key.get";
        public const string TMS_API_SERVER = "jingdong.jos.voucher.info.get";
        public const string SECRET_API_SERVER = "jingdong.jos.secret.api.report.get";


        public const string TMS_PROD_TOKEN_CERT = "-----BEGIN CERTIFICATE-----\n" +
            "MIIEcDCCA1igAwIBAgIJAKCBMSvIHNiEMA0GCSqGSIb3DQEBBQUAMIGAMQswCQYD\n" +
            "VQQGEwJDTjEQMA4GA1UECBMHQmVpamluZzEQMA4GA1UEBxMHQmVpamluZzEPMA0G\n" +
            "A1UEChMGSkQuQ09NMQwwCgYDVQQLEwNKT1MxEzARBgNVBAMTCmpvcy5qZC5jb20x\n" +
            "GTAXBgkqhkiG9w0BCQEWCmpvc0BqZC5jb20wIBcNMTkwMzE1MDQ1NTM2WhgPMjA1\n" +
            "OTAzMDUwNDU1MzZaMIGAMQswCQYDVQQGEwJDTjEQMA4GA1UECBMHQmVpamluZzEQ\n" +
            "MA4GA1UEBxMHQmVpamluZzEPMA0GA1UEChMGSkQuQ09NMQwwCgYDVQQLEwNKT1Mx\n" +
            "EzARBgNVBAMTCmpvcy5qZC5jb20xGTAXBgkqhkiG9w0BCQEWCmpvc0BqZC5jb20w\n" +
            "ggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDf9jdFbaYJLb6H/B1EEtuO\n" +
            "okkjrU1taQSudZhuBlnzCiKeUjK6vYDoqGgJSzRI86slU/rkK/7o4mc8LOvmAJRv\n" +
            "ULWLUdM9EzI+6+M6eVLwuWnm3QMIJJl1y7dQqwnAMLl3T/P6UGP1g19R7D8LcaEw\n" +
            "289Y8i/qJaVdobaM822xcW4Wv+QIldlWo6YlDoE7dfY9pXTlAkTP/GzO+LOnCzp1\n" +
            "/VA3Q6Xl1Cl4Kvk0wFWnGiMEbVEZx9yEknwPV1Viq3QGjMPoEGEau6x9srCcEitC\n" +
            "lllqXHOWkIVNt//qN2ubx90wjyHKZTe3HrQ/LFSIWLTeNo738iR8tFzxSfa5hitZ\n" +
            "AgMBAAGjgegwgeUwHQYDVR0OBBYEFHYHDa2moq7nEccftSm3x72QBWWJMIG1BgNV\n" +
            "HSMEga0wgaqAFHYHDa2moq7nEccftSm3x72QBWWJoYGGpIGDMIGAMQswCQYDVQQG\n" +
            "EwJDTjEQMA4GA1UECBMHQmVpamluZzEQMA4GA1UEBxMHQmVpamluZzEPMA0GA1UE\n" +
            "ChMGSkQuQ09NMQwwCgYDVQQLEwNKT1MxEzARBgNVBAMTCmpvcy5qZC5jb20xGTAX\n" +
            "BgkqhkiG9w0BCQEWCmpvc0BqZC5jb22CCQCggTEryBzYhDAMBgNVHRMEBTADAQH/\n" +
            "MA0GCSqGSIb3DQEBBQUAA4IBAQAr9qLL6qkNJjtcOzYM5afdyt+KBF9iwIcKG8ca\n" +
            "NUPNXwOFnOFw/JBKR4svjafvV3rSGs7ZtVMmASLUhrtStwfJJvXV7tdyqC0p44u/\n" +
            "sWK6SHoTNIHX+kXbzKrkwggqeTiUlHDTw60BP/mmbrYhIwOiTNvI247iWZ4IxxyD\n" +
            "bpFULv0gBfTVuc/ATWrHTI2pT78lIectDgUCpTOAhQIvE0PLK9nZjrsSCvW7tRED\n" +
            "PC+6KCPYQAzxmKvRRMCHXkAVeqb/0M6GEXBIT0aYEBHKdQ7s4g1VSGrbMUL5mQsA\n" +
            "+3fYhR+QEhE8PboH5kVct1V9tiMpx7kymJQKVfNufC3FIlyr\n" +
            "-----END CERTIFICATE-----";

        public enum ProtoType : short
        {
            KEY_REQUEST = 0
        }

        public enum CipherType : byte
        {
            WEAK = 0,
            REGULAR = 1,
            LARGE = 2
        }

        public enum AlgoType : byte
        {
            AES_CBC_128 = 4
        }

        public enum KeyType
        {
            AES = 0
        }

        public enum KeyUsage
        {
            N = -1,
            E = 0,
            D = 1,
            ED = 2
        }

        public enum KeyStatus
        {
            ACTIVE = 0,
            SUSPENDED = 1,
            REVOKED = 2
        }

        public enum MsgType
        {
            INIT = 1,
            EXCEPTION = 2,
            STATISTIC = 3,
            EVENT = 4
        }

        // level type to indicate notification type
        public enum MsgLevel
        {
            INFO = 1,
            WARN = 2,
            ERROR = 3,
            SEVERE = 4
        }
    }
}