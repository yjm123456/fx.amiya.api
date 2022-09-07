using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Balance
{
    public class AddBalanceUseRecordDto
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 消费时间 
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 消费订单id
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 消费前余额
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// 使用类型(预留默认0)
        /// </summary>
        public int UseType { get; set; }
    }
}
