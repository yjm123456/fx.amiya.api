using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlatFormOrderDealDetails.Input
{
    public class ConfirmContentPlatFormOrderDealDetailsDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string ContentPlatFormOrderId { get; set; }
        /// <summary>
        /// 成交编号
        /// </summary>
        public string ContentPlatFormOrderDealId { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }
    }
}
