using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jos_sdk_net.Util
{
    public class CreateOrderIdHelper
    {
        /// <summary>
        /// 生成订单号
        /// </summary>
        /// <returns></returns>
        public static string GetNextNumber()
        {
            Random random = new Random();
            long orderNumbers = random.Next(1, 10000);
            var nextNumber = $"{DateTime.Now.ToString("yyMMddhhmmss")}{orderNumbers.ToString().PadLeft(4, '0')}";
            return nextNumber;
        }
    }
}
