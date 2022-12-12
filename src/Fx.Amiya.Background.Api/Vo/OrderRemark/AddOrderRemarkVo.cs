using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderRemark
{
    /// <summary>
    /// 订单备注
    /// </summary>
    public class AddOrderRemarkVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
    }
}
