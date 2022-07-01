using System;
using Newtonsoft.Json;

namespace Jd.Api.Request
{
    [Serializable]
    public class Field : JdObject
    {
        [JsonProperty("key")]
        public String Key
        {
            get;
            set;
        }

        [JsonProperty("value")]
        public String Value
        {
            get;
            set;
        }

    }
}