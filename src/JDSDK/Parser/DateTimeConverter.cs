using System;
using Newtonsoft.Json;
using Jd.Api.Util;

namespace Jd.Api.Parser
{
    public class DateTimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                DateTime dateTime = (DateTime)value;
                String dateTimeStr = JdUtils.FormatDateTime(dateTime);
                writer.WriteValue(dateTimeStr);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.ValueType == typeof(Int64))
            {
                //DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                DateTime dtStart = new DateTime(1970, 1, 1);
                Int64 lTime = (Int64)reader.Value;
                return dtStart.AddMilliseconds(lTime);
            }

            DateTime dt = new DateTime();
            if (DateTime.TryParse(reader.Value.ToString(), out dt))
            {
                return dt;
            }
            else
            {
                throw new Exception(String.Format("{0}:{1}转换成DateTime失败！", reader.Path, reader.Value));
            }
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(DateTime) || objectType == typeof(DateTime?))
                return true;

            return false;
        }
    }
}