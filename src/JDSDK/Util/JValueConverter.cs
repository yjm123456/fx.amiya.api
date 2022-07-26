using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Common.Utils
{
    public class JValueConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var val = value as JValue;
            if (val.Type == JTokenType.Float)
            {
                var d = Convert.ToDouble(val.Value);
                var i = (long)d;
                if (Math.Abs(i - d) == 0) // 针对float，如果小数点后的零是多余的，那么按整数方式输出
                {
                    writer.WriteValue(i);
                    return;
                }
            }
            writer.WriteValue(value); // 否则按原逻辑
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(JValue);
        }
    }
}
