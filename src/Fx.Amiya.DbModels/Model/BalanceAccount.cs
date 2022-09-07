using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 用户余额账户
    /// </summary>
    public  class BalanceAccount
    {
        public string CustomerId { get; set; }
        public decimal Balance { get; set; }
    }
}
