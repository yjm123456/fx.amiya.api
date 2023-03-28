using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ReconciliationDocuments.Input
{
    public class QueryExportReconciliationDocumentsDetailsVo : BaseQueryVo
    {
        /// <summary>
        /// 回款状态
        /// </summary>
        public bool? IsSettle { get; set; }
        /// <summary>
        /// 账单类型
        /// </summary>
        public bool? AccountType { get; set; }
        /// <summary>
        /// 关键词（对账单编号，订单号，成交编号；支持模糊查询）
        /// </summary>
        public string Keyword { get; set; }
    }
}
