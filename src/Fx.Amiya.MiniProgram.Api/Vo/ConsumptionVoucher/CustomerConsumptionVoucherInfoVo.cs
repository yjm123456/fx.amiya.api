using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.ConsumptionVoucher
{
    public class CustomerConsumptionVoucherInfoVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 抵用券名称
        /// </summary>
        public string ConsumptionVoucherName { get; set; }
        /// <summary>
        /// 抵用券抵扣金额
        /// </summary>
        public decimal DeductMoney { get; set; }
        /// <summary>
        /// 是否可分享
        /// </summary>
        public bool IsShare { get; set; }
        /// <summary>
        /// 是否只能用于指定商品
        /// </summary>
        public bool IsSpecifyProduct { get; set; }

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
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 使用时间
        /// </summary>
        public DateTime? UseDate { get; set; }
        /// <summary>
        /// 优惠券来源
        /// </summary>
        public int Source { get; set; }
        /// <summary>
        /// 抵用券类型 0:商品抵用券,1:面诊卡抵用券
        /// </summary>
        public int Type { get; set; }
        public string WirteOfCode { get; set; }
    }
}
