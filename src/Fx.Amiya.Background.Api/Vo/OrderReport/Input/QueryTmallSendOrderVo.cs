using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.Input
{
    /// <summary>
    /// 下单平台订单派单报表查询类
    /// </summary>
    public class QueryTmallSendOrderVo:BaseQueryVo
    {
        /// <summary>
        /// 订单状态
        /// </summary>
        public string Status { get; set; }
    }
}
