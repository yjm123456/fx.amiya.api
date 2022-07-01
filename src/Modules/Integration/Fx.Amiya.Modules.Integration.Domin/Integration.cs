using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.Domin
{
   public class Integration
    {
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
        public string CustomerId { get; set; }
        public DateTime? ExpiredDate { get; set; }

        /// <summary>
        /// 产生的类型
        /// 是消费，还是单独赠送等
        /// </summary>
        public GenerateType GenerateType { get; protected set; }
    }
}
