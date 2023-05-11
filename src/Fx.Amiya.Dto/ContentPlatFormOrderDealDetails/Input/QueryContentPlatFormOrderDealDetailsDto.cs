using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlatFormOrderDealDetails.Input
{
    public class QueryContentPlatFormOrderDealDetailsDto : BaseQueryDto
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string ContentPlatFormOrderId { get; set; }
        /// <summary>
        /// 成交情况编号
        /// </summary>
        public string ContentPlatFormOrderDealId { get; set; }
    }
}
