using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jd.Api.Util
{
    // 自定义JObject的序列化方法，确保对象的Key按字典序输出
    public class JObjectConverter:JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var val = value as JObject;
            var props = val.Properties().OrderBy(i => i.Name).ToList();
            writer.WriteStartObject();
            foreach (var p in props)
            {
                writer.WritePropertyName(p.Name);
                serializer.Serialize(writer, p.Value);
            }

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(JObject);
        }
    }
}
