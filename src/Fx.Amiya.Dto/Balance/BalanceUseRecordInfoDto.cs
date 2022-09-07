using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Balance
{
    public class BalanceUseRecordInfoDto
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
        /// 商品名
        /// </summary>
        public string GoodsName { get; set; }
    }
}
