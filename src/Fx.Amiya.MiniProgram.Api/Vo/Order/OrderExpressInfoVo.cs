using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Order
{
    /// <summary>
    /// 订单物流信息
    /// </summary>
    public class OrderExpressInfoVo
    {
        /// <summary>
        /// 快递单号
        /// </summary>
        public string ExpressNo { get; set; }
        /// <summary>
        /// 物流公司
        /// </summary>
        public string ExpressName { get; set; }

        /// <summary>
        /// 快递当前状态
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// 物流详情
        /// </summary>
        public List<ExpressDetailsVo> ExpressDetailList { get; set; }
    }

}
