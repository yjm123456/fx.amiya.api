using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Integration
{
    public record IntegrationGenerateRecordsDto
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 充值类型
        /// </summary>
        public byte Type { get; set; }
        /// <summary>
        /// 充值类型文本
        /// </summary>
        public string TypeText { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// 这条充值记录还剩下的余额
        /// </summary>
        public decimal StockQuantity { get; set; }
        /// <summary>
        /// 该客户的积分账户实时余额（产生这条记录的时候的余额）
        /// </summary>
        public decimal AccountBalance { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime? ExpiredDate { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 核销订单号
        /// </summary>
        public string OrderId { get; set; }
    }
}
