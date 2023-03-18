using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.Input
{
    /// <summary>
    /// 客服下单平台未派单报表查询类
    /// </summary>
    public class QueryCustomerTmallUnSendOrderVo:BaseQueryVo
    {
        /// <summary>
        /// 归属客服id
        /// </summary>
        public int EmployeeId { get; set; }
    }
}
