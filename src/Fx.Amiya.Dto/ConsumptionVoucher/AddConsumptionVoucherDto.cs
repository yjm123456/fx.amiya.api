using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ConsumptionVoucher
{
    public class AddConsumptionVoucherDto
    {
        /// <summary>
        /// 抵用券名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 抵扣金额
        /// </summary>
        public decimal DeductMoney { get; set; }
        /// <summary>
        /// 是否只能用于指定商品
        /// </summary>
        public bool IsSpecifyProduct { get; set; }
        /// <summary>
        /// 是否可累加使用
        /// </summary>
        public bool IsAccumulate { get; set; }
        /// <summary>
        /// 是否可分享
        /// </summary>
        public bool IsShare { get; set; }
        /// <summary>
        /// 有效期时长(天数)
        /// </summary>
        public int EffectiveTime { get; set; }
        /// <summary>
        /// 抵用券类型 0:商品抵用券,1:面诊卡抵用券
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? ExpireDate { get; set; }
        /// <summary>
        /// 当前抵用券是否有效
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 抵用券编码
        /// </summary>
        public string ConsumptionVoucherCode { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 是否有最小支付金额限制
        /// </summary>
        public bool IsNeedMinPrice { get; set; }
        /// <summary>
        /// 最小限制金额
        /// </summary>
        public decimal? MinPrice { get; set; }
        /// <summary>
        /// 是否是会员领取抵用券
        /// </summary>
        public bool IsMemberVoucher { get; set; }
        /// <summary>
        /// 对应的会员等级(当抵用券是会员领取抵用券时必填,不是则不填)
        /// </summary>
        public string MemberRankCode { get; set; }

    }
}
