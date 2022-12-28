using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ReconciliationDocuments
{
    public class ReconciliationDocumentsReturnBackPriceVo
    {
        /// <summary>
        /// 对账单id集合
        /// </summary>
        public List<string> ReconciliationDocumentsIdList { get; set; }
        /// <summary>
        /// 回款时间
        /// </summary>
        public DateTime ReturnBackDate { get; set; }
    }
}
