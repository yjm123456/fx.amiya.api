using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.FinancialBorad
{
    public class CustomerServiceBoardVo
    {
        /// <summary>
        /// 客服姓名
        /// </summary>
        public string CustomerServiceName { get; set; }
        /// <summary>
        /// 对账业绩
        /// </summary>
        public decimal DealPrice { get; set; }
        /// <summary>
        /// 服务费合计
        /// </summary>
        public decimal TotalServicePrice { get; set; }
        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPrice { get; set; }
        /// <summary>
        /// 新客服务费
        /// </summary>
        public decimal NewCustomerServicePrice { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPrice { get; set; }
        /// <summary>
        /// 老客服务费
        /// </summary>
        public decimal OldCustomerServicePrice { get; set; }
    }
}
