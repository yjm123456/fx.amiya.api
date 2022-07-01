using System;
using Newtonsoft.Json;

namespace Jd.ACES.Common
{

    public class JosMasterKeyGetResponse
    {
        [JsonProperty("jingdong_jos_master_key_get_responce")]
        public MasterKeyResponseData getResponse { get; set; }
    }
    public class MasterKeyResponseData
    {
        [JsonProperty("response")]
        public KeyResponse keyResponse { get; set; }

        [JsonProperty("code")]
        public String code { get; set; }

    }
}