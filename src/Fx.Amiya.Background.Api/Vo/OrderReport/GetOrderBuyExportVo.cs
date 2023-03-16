using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    /// <summary>
    /// 付款订单报表导出查询类
    /// </summary>
    public class GetOrderBuyExportVo
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 归属客服id
        /// </summary>
        public int BelongEmpId { get; set; }
    }
}
