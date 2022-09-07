using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Balance
{
    public class UpdateBalanceAccountDto
    {
        /// <summary>
        /// 客户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
    }
}
