using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.FinancialBoard
{
    public class LiveAnchorBoardDataDto
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
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
        /// <summary>
        /// 主播名称
        /// </summary>
        public string LiveAnchorName { get; set; }
    }
}
