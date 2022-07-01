using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Jd.ACES.Utils
{
    public class JsonHelper
    {
        public static T FromJson<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public static T FromJson<T>(byte[] input)
        {
            return FromJson<T>(Encoding.Default.GetString(input));
        }

        public static string ToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string ToDesensitiveJson<T>(T obj, string[] fields, bool retain = false)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new DynamicContractResolver(fields, retain)
            };
            return JsonConvert.SerializeObject(obj, serializerSettings);
        }
    }

    public class DynamicContractResolver : DefaultContractResolver
    {
        string[] props = null;

        bool retain;

        public DynamicContractResolver(string[] props, bool retain = true)
        {
            this.props = props;
            this.retain = retain;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> list =
            base.CreateProperties(type, memberSerialization);
            return list.Where(p => {
                if (retain)
                {
                    return props.Contains(p.PropertyName);
                }
                else
                {
                    return !props.Contains(p.PropertyName);
                }
            }).ToList();
        }
    }
}