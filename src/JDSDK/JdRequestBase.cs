using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Util;
using Jd.Api.Request;

namespace Jd.Api
{
    public abstract class JdRequestBase<T> : IJdRequest<T> where T : JdResponse
    {
        IDictionary<String, Object> _addedParamters = new Dictionary<String, Object>();

        /// <summary>
        /// 附加参数
        /// </summary>
        public IDictionary<String, Object> AddedParam
        {
            get
            {
                return _addedParamters;
            }
        }

        /// <summary>
        /// API方法名称
        /// </summary>
        public abstract String ApiName
        {
            get;
        }
        public String ApiVersion
        {
            get;
            set;
        }

        /// <summary>
        /// 增加附加参数
        /// </summary>
        /// <param name="key">参数名</param>
        /// <param name="value">参数值</param>
        public void AddParam(String key, Object value)
        {
            _addedParamters.Add(key, value);
        }

        /// <summary>
        /// 移除附加参数
        /// </summary>
        /// <param name="key">参数名</param>
        /// <returns></returns>
        public Boolean RemoveParam(String key)
        {
            return _addedParamters.Remove(key);
        }

        protected abstract void PrepareParam(IDictionary<String, Object> paramters);

        public virtual String GetParamJson()
        {
            var paramters = new Dictionary<String, Object>();
            var param = new Dictionary<String, Object>();
            PrepareParam(paramters);
            foreach (var added in paramters)
            {
                if (string.IsNullOrEmpty(added.Key) || added.Value == null || string.IsNullOrEmpty(added.Value.ToString())) continue;
                if (!param.ContainsKey(added.Key))
                {
                    param.Add(added.Key, added.Value);
                }
            }
            foreach (var added in _addedParamters)
            {
                if (!param.ContainsKey(added.Key))
                {
                    param.Add(added.Key, added.Value);
                }
            }
            return JsonConvert.SerializeObject(param, JdUtils.GetJsonConverters());
        }

        public virtual void Validate()
        {

        }
    }
}