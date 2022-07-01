using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.ACES.Utils;

namespace Jd.ACES.Common
{
    public class KeyResponse
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }
        [JsonProperty("tid")]
        public string Tid { get; set; }
        [JsonProperty("ts")]
        public long Ts { get; set; }
        [JsonProperty("enc_service")]
        public string EncService { get; set; }
        [JsonProperty("service_key_list")]
        public List<ServiceKeyInfo> ServiceKeyList { get; set; }
        [JsonProperty("key_cache_disabled")]
        public int KeyCacheDisabled { get; set; }
        [JsonProperty("key_backup_disabled")]
        public int KeyBackupDisabled { get; set; }

        public KeyResponse() { }
        public KeyResponse(int status_code, string status_message)
        {
            this.StatusCode = status_code;
            this.StatusMessage = status_message;
            this.Ts = EnvironmentHelper.GetCurrentMillis();
        }
    }

    public class ServiceKeyInfo
    {
        [JsonProperty("service")]
        public string Service { get; set; }
        [JsonProperty("current_key_version")]
        public uint CurrentKeyVersion { get; set; }
        [JsonProperty("grant_usage")]
        public string GrantUsage { get; set; }
        [JsonProperty("keys")]
        public List<MKData> Keys { get; set; }
    }
}
