using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderReport
{
    public class TodaySendOrderInfoDto
    {  
        /// <summary>
       /// 订单号
       /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 商品
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 实付款
        /// </summary>
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 派单医院
        /// </summary>
        public string SendHospital { get; set; }

        /// <summary>
        /// 派单医院id
        /// </summary>
        public int SendHospitalId { get; set; }
    }
}
