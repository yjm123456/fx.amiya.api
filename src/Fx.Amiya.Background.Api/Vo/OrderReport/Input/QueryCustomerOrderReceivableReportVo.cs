using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.Input
{
    /// <summary>
    /// 客户订单应收款统计（交易完成订单）查询类
    /// </summary>
    public class QueryCustomerOrderReceivableReportVo : BaseQueryVo
    {
        /// <summary>
        /// 下单平台
        /// </summary>
        public int? AppType { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int? CheckState { get; set; }
        /// <summary>
        /// 是否回款
        /// </summary>
        public bool? ReturnBackPriceState { get; set; }
        /// <summary>
        /// 是否开票
        /// </summary>
        public bool? IsCreateBill { get; set; }
        /// <summary>
        /// 开票公司id
        /// </summary>
        public string BelongCompanyId { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }
    }
}
