using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 用户抵用券
    /// </summary>
    public class CustomerConsumptionVoucher
    {
        public string Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 消费券类型id
        /// </summary>
        public string ConsumptionVoucherId { get; set; }
        /// <summary>
        /// 是否已经使用
        /// </summary>
        public bool IsUsed { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? ExpireDate { get; set; }
        /// <summary>
        /// 是否过期
        /// </summary>
        public bool IsExpire { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 使用时间
        /// </summary>
        public DateTime? UseDate { get; set; }
        
    }
}
