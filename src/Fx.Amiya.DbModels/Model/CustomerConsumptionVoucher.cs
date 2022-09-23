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
    public class CustomerConsumptionVoucher:BaseDbModel
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 抵用券id
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
        /// 使用时间
        /// </summary>
        public DateTime? UseDate { get; set; }
        /// <summary>
        /// 来源 0:升级会员赠送,1:用户分享,2:每月领取
        /// </summary>
        public int Source { get; set; }
        /// <summary>
        /// 分享人
        /// </summary>
        public string ShareBy { get; set; }
        /// <summary>
        /// 核销码
        /// </summary>
        public string WriteOfCode { get; set; }

    }
}
