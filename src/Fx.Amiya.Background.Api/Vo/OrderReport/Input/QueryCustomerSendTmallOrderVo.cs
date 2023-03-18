using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.Input
{
    /// <summary>
    /// 下单平台客服已派单报表查询类
    /// </summary>
    public class QueryCustomerSendTmallOrderVo:BaseQueryVo
    {
        /// <summary>
        /// 派单客服
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 归属客服
        /// </summary>
        public int BelongEmpId { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatus { get; set; }
    }
}
