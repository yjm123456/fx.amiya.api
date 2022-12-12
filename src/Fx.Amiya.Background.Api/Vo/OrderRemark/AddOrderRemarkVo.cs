using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderRemark
{
    /// <summary>
    /// 订单备注
    /// </summary>
    public class AddOrderRemarkVo:BaseVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 创建人（根据归属端口判断员工）
        /// </summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
    }
}
