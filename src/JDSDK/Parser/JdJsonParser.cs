using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Jd.Api.Util;

namespace Jd.Api.Parser
{

    /// <summary>
    /// Jd JSON响应通用解释器。
    /// </summary>
    public class JdJsonParser<T> : IJdParser<T> where T : JdResponse
    {
        public T Parse(string body)
        {
            IJdLogger jdLogger = new DefaultJdLogger();
            T rsp = null;
            try
            {
                JObject json = JObject.Parse(body);
                if (json != null && json.First != null)
                {
                    JObject data = (JObject)json.First.First;
                    if (data != null)
                    {
                        rsp = data.ToObject<T>(GetJsonSerializer());
                        rsp.Json = json;
                    }
                }
            }
            catch (Exception e)
            {
                jdLogger.Error("json parse"+e.StackTrace);
            }

            if (rsp == null)
            {
                rsp = Activator.CreateInstance<T>();
            }

            if (rsp != null)
            {
                rsp.Body = body;
            }

            return rsp;
        }

        private static JsonSerializer _jsonSerializer = null;
        public static JsonSerializer GetJsonSerializer()
        {
            if (_jsonSerializer == null)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.Converters = new List<JsonConverter>(JdUtils.GetJsonConverters());
                _jsonSerializer = JsonSerializer.Create(settings);
            }

            return _jsonSerializer;
        }

    }
}
