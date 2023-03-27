using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.Input
{

    /// <summary>
    /// 客户订单应收款统计（买家已付款订单）查询类
    /// </summary>
    public class QueryCustomerPaidOrderReceivableReportVo:BaseQueryVo
    {
        /// <summary>
        /// 审核状态
        /// </summary>
        public int? CheckState{get;set;}
        /// <summary>
        /// 是否回款
        /// </summary>
        public bool? ReturnBackPriceState{get;set;}
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }
    }
}
