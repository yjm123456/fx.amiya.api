using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderReport
{
    public class TodayOrderAddDto
    {

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType { get; set; }
    }
}
