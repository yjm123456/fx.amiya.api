using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.OutPut
{
    /// <summary>
    /// 付款订单报表导出查询类
    /// </summary>
    public class GetOrderBuyExportVo : BaseQueryVo
    {
        /// <summary>
        /// 归属客服id
        /// </summary>
        public int BelongEmpId { get; set; }
    }
}
