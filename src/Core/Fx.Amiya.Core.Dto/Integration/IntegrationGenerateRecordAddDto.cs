using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Integration
{
    public record IntegrationGenerateRecordAddDto
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerId { get; set; } 
        /// <summary>
        /// 充值类型
        /// </summary>
        public IntegrationGenerateType Type { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal  Quantity { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单总额
        /// </summary>
        public decimal AmountOfConsumption { get; set; }
        /// <summary>
        /// 产生的比例
        /// </summary>
        public decimal Percents { get; set; }
        /// <summary>
        /// 客户介绍的人消费了产生的（预留）
        /// </summary>
        public string ProviderId { get; set; }
        /// <summary>
        /// 有效期（预留）
        /// </summary>
        public DateTime? ExpiredDate { get; set; }

        public int? HandleBy { get; set; }

    }
}
