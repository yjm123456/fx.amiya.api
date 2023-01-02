using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TmallOrder
{
    public class ReturnBackOrderDto
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 成交编号id
        /// </summary>
        public string OrderDealId { get; set; }
        /// <summary>
        /// 回款金额
        /// </summary>
        public decimal ReturnBackPrice { get; set; }

        /// <summary>
        /// 回款时间
        /// </summary>
        public DateTime ReturnBackDate { get; set; }

        /// <summary>
        /// 对账单id集合
        /// </summary>
        public List<string> ReconciliationDocumentsIdList { get; set; }
    }
}
