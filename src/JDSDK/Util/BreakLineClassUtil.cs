using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jos_sdk_net.Util
{
    /// <summary>
    /// 折线图工具类
    /// </summary>
    public class BreakLineClassUtil<T>
    {
        /// <summary>
        /// 按月填充数据
        /// </summary>
        /// <param name="month">月份</param>
        /// <param name="data">要转化的数据</param>
        /// <returns></returns>
        public static List<T> Convert(int month,List<T> data) {
            try
            {
                List<T> list = new List<T>();
                Type type = typeof(T);
                var date = type.GetProperty("Date");
                var performance = type.GetProperty("PerfomancePrice");
                for (int i = 1; i <= month; i++)
                {
                    T t = (T)Activator.CreateInstance(type);
                    date.SetValue(t, i.ToString());
                    performance.SetValue(t, 0m);
                    list.Add(t);
                }
                foreach (var item in data)
                {
                    T res=list.Find(l => l.GetType().GetProperty("Date").GetValue(l).ToString() == item.GetType().GetProperty("Date").GetValue(item).ToString());
                    if(res!=null) res.GetType().GetProperty("PerfomancePrice").SetValue(res, item.GetType().GetProperty("PerfomancePrice").GetValue(item));
                }
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception("转化失败,检查格式");
            }
        }
    }
}
