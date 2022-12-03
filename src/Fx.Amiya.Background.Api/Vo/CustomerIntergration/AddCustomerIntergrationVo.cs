
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerIntergration
{

    /// <summary>
    /// 客户消费赠送积分
    /// </summary>
    public class AddCustomerIntergrationVo
    {
        /// <summary>
        /// 客户手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal? ActualPayment { get; set; }
    }
}
