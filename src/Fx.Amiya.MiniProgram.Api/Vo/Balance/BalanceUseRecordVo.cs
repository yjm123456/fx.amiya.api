using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Balance
{
    public class BalanceUseRecordVo
    {
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>
        public DateTime UseDate { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
    }
}
