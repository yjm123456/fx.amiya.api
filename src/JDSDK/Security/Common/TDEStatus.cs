using System;

namespace Jd.ACES.Common
{
    class TDEStatusAttribute : Attribute
    {
        public TDEStatusAttribute(string Message)
        {
            this.Message = Message;
        }
        public string Message { get; set; }
    }

    public enum TDEStatus
    {
        [TDEStatusAttribute("Success.")]
        SUCCESS = 0,

        // Generic error codes across the whole TDE system. Range 1 to 99
        [TDEStatusAttribute("Internal system error.")]
        INTERNAL_ERROR = 1,  // default error code
        [TDEStatusAttribute("Internal database error.")]
        DB_ERROR = 2,
        [TDEStatusAttribute("Invalid json input.")]
        INVALID_JSON = 3,
        // Request json is well-formed but some data field is not valid
        [TDEStatusAttribute("Invalid data in the request json.")]
        INVALID_REQUEST_DATA = 4,
        [TDEStatusAttribute("Validation of the request signature failed.")]
        REQUEST_SIG_VERFIFY_ERROR = 5,

        // KMS specific errors. Range 100 to 199
        [TDEStatusAttribute("KMS internal system error.")]
        KMS_INTERNAL_ERROR = 100,
        [TDEStatusAttribute("No key found on KMS.")]
        KMS_NO_KEY_FOUND = 101,
        [TDEStatusAttribute("MK already created for this service.")]
        KMS_KEY_CREATED_ALREADY = 102,
        [TDEStatusAttribute("Failed to register key by RKS.")]
        KMS_KEY_REGISTRATION_FAILED = 103,
        [TDEStatusAttribute("The service is already registered")]
        KMS_SERVICE_ALREADY_REGISTERED = 104,
        [TDEStatusAttribute("Failed to connect to TMS server")]
        KMS_TMS_CONNECTION_ERROR = 105,
        [TDEStatusAttribute("Failed to connect to RKS server")]
        KMS_RKS_CONNECTION_ERROR = 106,
        [TDEStatusAttribute("Latest key already activated")]
        KMS_KEY_ALREADY_ACTIVATED = 107,
        [TDEStatusAttribute("KMS fail to remove redis cache.")]
        KMS_FAIL_TO_REMOVE_REDIS_CACHE = 108,

        // SDK specific errors. Range 200 to 299
        [TDEStatusAttribute("SDK generic exception error.")]
        SDK_INTERNAL_ERROR = 200,
        // token related
        [TDEStatusAttribute("SDK uses an ineffective token.")]
        SDK_USE_INEFFECTIVE_TOKEN = 201,
        [TDEStatusAttribute("SDK uses an expired token with hard deadline.")]
        SDK_USE_HARD_EXPIRED_TOKEN = 202,
        [TDEStatusAttribute("SDK uses an expired token with soft deadline.")]
        SDK_USE_SOFT_EXPIRED_TOKEN = 203,
        // recovery procedure related
        [TDEStatusAttribute("SDK cannot fetch any function keys from backup file.")]
        SDK_FAIL_TO_READ_BACKUP = 204,
        // key request/response related
        [TDEStatusAttribute("SDK received key response with unmatched service name.")]
        SDK_RECEIVED_WRONG_KEYRESPONSE1 = 205,
        [TDEStatusAttribute("SDK received key response with unmatched token id.")]
        SDK_RECEIVED_WRONG_KEYRESPONSE2 = 206,
        [TDEStatusAttribute("KMS is unreachable due to:")]
        SDK_CANNOT_REACH_KMS = 207,
        // Encrypt/Decrypt related
        [TDEStatusAttribute("SDK holds a decrypt-only token or has no key to encrypt data.")]
        SDK_HAS_NO_AVAILABLE_ENC_KEYS = 208,
        [TDEStatusAttribute("SDK has no corresponding key to decrypt cipher data, header:")]
        SDK_HAS_NO_CORRESPONDING_DEC_KEYS = 209,
        [TDEStatusAttribute("SDK uses old keys to encrypt/decrypt data.")]
        SDK_OPERATE_WITH_EXPIRED_KEYS = 210,
        [TDEStatusAttribute("SDK uses suspended/revoked keys to encrypt/decrypt data.")]
        SDK_OPERATE_WITH_INACTIVE_KEYS = 211,
        [TDEStatusAttribute("SDK threw generic exception.")]
        SDK_THROW_JDK_EXCEPTION = 212,
        [TDEStatusAttribute("SDK uses an invalid token.")]
        SDK_USE_INVALID_TOKEN = 213,
        [TDEStatusAttribute("SDK has no keys in internal cache.")]
        SDK_HAS_NO_AVAILABLE_KEYS = 214,
        [TDEStatusAttribute("SDK has corrupted keys in internal cache.")]
        SDK_HAS_CORRUPTED_KEYS = 215,
        [TDEStatusAttribute("SDK tries to decrypt corrupted cipher, header: ")]
        SDK_HAS_CORRUPTED_CIPHER = 216,
        [TDEStatusAttribute("SDK did not set resource path correctly.")]
        SDK_DIDNOT_SETUP_RPATH = 217,
        [TDEStatusAttribute("SDK cannot write key cache file to the given resource path.")]
        SDK_FAIL_TO_WRITE_KEYCACHE = 218,
        [TDEStatusAttribute("SDK fails to delete all key cache files.")]
        SDK_FAIL_TO_DELETE_KEYCACHE = 219,
        [TDEStatusAttribute("SDK cannot fetch any function keys from cache file.")]
        SDK_FAIL_TO_READ_KEYCACHE = 220,
        [TDEStatusAttribute("SDK fails to delete backup file.")]
        SDK_FAIL_TO_DELETE_KEYBACKUP = 221,
        // Event related
        [TDEStatusAttribute("SDK deletes backup file successfully.")]
        SDK_SUCCEEDS_TO_DELETE_KEYBACKUP = 222,
        [TDEStatusAttribute("SDK deletes cache file successfully.")]
        SDK_SUCCEEDS_TO_DELETE_KEYCACHE = 223,
        [TDEStatusAttribute("SDK recoveries keys from backup file successfully.")]
        SDK_RECOVERIES_KEYS_FROM_KEYBACKUP = 224,
        [TDEStatusAttribute("SDK recoveries keys from cache file successfully.")]
        SDK_RECOVERIES_KEYS_FROM_KEYCACHE = 225,
        [TDEStatusAttribute("SDK successfully rewrite new keys to cache file.")]
        SDK_SUCCEEDS_TO_OVERWRITE_KEYBACKUP = 226,
        [TDEStatusAttribute("SDK failed to fetch rotated keys, header:")]
        SDK_FAILS_TO_FETCH_UPDATED_KEYS = 227,
        [TDEStatusAttribute("SDK trigger key fetching because ciphertext is encrypted with newer keys.")]
        SDK_TRIGGER_ROTATED_KEY_FETCH = 228,
        [TDEStatusAttribute("CurKeyVer=")]
        SDK_REPORT_CUR_KEYVER = 229,

        // sign/verify
        [TDEStatusAttribute("SDK has no key to sign data.")]
        SDK_HAS_NO_AVAILABLE_SIGN_KEYS = 233,
        [TDEStatusAttribute("SDK has no corresponding key to verify signature, header:")]
        SDK_HAS_NO_CORRESPONDING_VERIFY_KEYS = 234,
        [TDEStatusAttribute("SDK failed to fetch rotated verify keys, header:")]
        SDK_FAILS_TO_FETCH_UPDATED_VERIFY_KEYS = 235,
        [TDEStatusAttribute("SDK trigger verify key fetching because signature is signed with newer keys.")]
        SDK_TRIGGER_ROTATED_VERIFY_KEY_FETCH = 236,

        /********************************** TMS about ********************************/
        // TMS specific errors. Range 300 to 399
        [TDEStatusAttribute("TMS internal system error.")]
        TMS_INTERNAL_ERROR = 300,
        [TDEStatusAttribute("TMS-db's data not found.")]
        TMS_DB_DATA_NOTFOUND_ERROR = 301,
        [TDEStatusAttribute("Request argument error.")]
        TMS_REQUEST_ARGS_ERROR = 302,
        [TDEStatusAttribute("Tms db data error.")]
        TMS_DB_DATA_ERROR = 303,
        [TDEStatusAttribute("KMS request timeout.")]
        TMS_KMS_REQUEST_EXPIRE = 304,
        [TDEStatusAttribute("Request signature validation failed.")]
        TMS_REQUEST_VERIFY_FAILED = 305,
        [TDEStatusAttribute("The request token is expired.")]
        TMS_TOKEN_EXPIRE = 306,
        [TDEStatusAttribute("The request token is frozen.")]
        TMS_TOKEN_IS_FROZEN = 307,
        [TDEStatusAttribute("The request token is revoked.")]
        TMS_TOKEN_IS_REVOKE = 308,
        [TDEStatusAttribute("The token is ineffective.")]
        TMS_TOKEN_IS_NOT_IN_THE_EFFECT_TIME_RANGE = 309,
        [TDEStatusAttribute("The token in the db is null.")]
        TMS_TOKEN_IN_DB_IS_NULL = 310,
        [TDEStatusAttribute("The token has no granted service.")]
        TMS_NO_AVAILABLE_GRANTS_FOR_SERVICE = 311,

        // RKS specific errors. Range 400 to 499
        [TDEStatusAttribute("RKS internal system error.")]
        RKS_INTERNAL_ERROR = 400,
        [TDEStatusAttribute("Registration request format error.")]
        RKS_REQUEST_FORMAT_ERROR = 401,
        [TDEStatusAttribute("Registration request signature validation failed.")]
        RKS_SIG_VERIFY_ERROR = 402,
        [TDEStatusAttribute("Backup service is not available.")]
        RKS_BACKUP_CLOSE = 403
    }

}