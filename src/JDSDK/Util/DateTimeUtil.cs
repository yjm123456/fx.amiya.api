using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jos_sdk_net.Util
{
    public class DateTimeUtil
    {
        /// <summary>
        /// 获取下个月的第一天
        /// </summary>
        public static DateTime GetNextMonthFirstDay() {
            var date = DateTime.Now.AddMonths(1);
            return new DateTime(date.Year,date.Month,1);
        }
    }
}
