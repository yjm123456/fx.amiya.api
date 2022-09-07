using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 余额消费记录
    /// </summary>
    public class BalanceUseRecord
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 对应的订单id
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 消费前账户余额
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// 消费类型(预留)
        /// </summary>
        public int UseType { get; set; }

    }
}
