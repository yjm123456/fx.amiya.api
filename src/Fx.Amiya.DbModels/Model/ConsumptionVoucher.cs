﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 抵用券
    /// </summary>
    public class ConsumptionVoucher:BaseDbModel
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
        /// 有效期时长(天)
        /// </summary>
        public int EffectiveTime { get; set; }
        /// <summary>
        /// 抵用券类型0:实体商品折扣,1:面诊卡抵用券
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
        /// 抵用券编码
        /// </summary>
        public string ConsumptionVoucherCode { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 是否限制最小使用金额
        /// </summary>
        public bool IsNeedMinFee { get; set; }
        /// <summary>
        /// 最小金额限制
        /// </summary>
        public decimal? MinPrice { get; set; }
        /// <summary>
        /// 是否是会员领取抵用券
        /// </summary>
        public bool IsMemberVoucher { get; set; }
        /// <summary>
        /// 会员领取抵用券对应的会员编码
        /// </summary>
        public string MemberRankCode { get; set; }
    }
}
