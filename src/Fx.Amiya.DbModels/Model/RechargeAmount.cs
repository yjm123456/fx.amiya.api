using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 充值金额表
    /// </summary>
    public class RechargeAmount
    {
        
        public string Id { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>

        public decimal Amount { get; set; }
    }
}
