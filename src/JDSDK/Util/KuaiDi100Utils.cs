using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace jos_sdk_net.Util
{
    public class KuaiDi100Utils
    {
        /// <summary>
        /// 访问提交
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string doPostForm(string url, Dictionary<string, string> param)
        {
            try
            {
                string json = JsonConvert.SerializeObject(param);
                using (var client = new System.Net.Http.HttpClient())
                {
                    using (var multipartFormDataContent = new FormUrlEncodedContent(param))
                    {
                        Console.WriteLine();
                        var result = client.PostAsync(url, multipartFormDataContent).Result.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(result);
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        /// <summary>
        /// 数据转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ObjectToMap(object obj)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();

            Type t = obj.GetType(); // 获取对象对应的类， 对应的类型

            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance); // 获取当前type公共属性

            foreach (PropertyInfo p in pi)
            {
                MethodInfo m = p.GetGetMethod();

                if (m != null && m.IsPublic)
                {
                    // 进行判NULL处理
                    if (m.Invoke(obj, new object[] { }) != null)
                    {
                        map.Add(p.Name, m.Invoke(obj, new object[] { })
                                         .ToString()); // 向字典添加元素
                    }
                }
            }
            return map;
        }

        /// <summary>
        /// 转换快递状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string GetExpressState(int state)
        {
            try
            {
                string text = "";
                switch (state)
                {
                    case 0:
                        text = "快递正在途中";
                        break;
                    case 1:
                        text = "快递已揽件";
                        break;
                    case 2:
                        text = "快件存在疑难";
                        break;
                    case 3:
                        text = "快递已签收";
                        break;
                    case 4:
                        text = "此快件单已退签";
                        break;
                    case 5:
                        text = "快件正在派件";
                        break;
                    case 6:
                        text = "快件正处于返回发货人的途中";
                        break;
                    case 7:
                        text = "快件转给其他快递公司邮寄";
                        break;
                    case 8:
                        text = "快件清关";
                        break;
                    case 14:
                        text = "收件人拒签快件";
                        break;
                }
                return text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
