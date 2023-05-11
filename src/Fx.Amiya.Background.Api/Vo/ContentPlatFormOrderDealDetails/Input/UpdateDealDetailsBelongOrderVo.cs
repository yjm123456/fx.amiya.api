using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlatFormOrderDealDetails.Input
{
    public class UpdateDealDetailsBelongOrderVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string ContentPlatFormOrderId { get; set; }
        /// <summary>
        /// 成交情况编号
        /// </summary>
        public string ContentPlatFormOrderDealId { get; set; }
    }
}
