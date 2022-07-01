using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo
{
    /// <summary>
    /// 客户积分明细基础类
    /// </summary>
    public class WxCustomerInterGrationAccount
    {
        /// <summary>
        /// 当前积分
        /// </summary>
        public int CurrentIntergration { get; set; }
        /// <summary>
        /// 积分明细
        /// </summary>
        public List<CustomerInterGrationAccountDetails> CustomerIntergrationDetails { get; set; }
    }
    /// <summary>
    /// 客户积分明细
    /// </summary>
    public class CustomerInterGrationAccountDetails {
        /// <summary>
        /// 积分来源/用途
        /// </summary>
        public string GenerateOrUsed { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string  InterGrationAmount { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
