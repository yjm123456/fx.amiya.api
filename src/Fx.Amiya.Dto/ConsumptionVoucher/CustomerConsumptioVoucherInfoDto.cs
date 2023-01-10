using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ConsumptionVoucher
{
    public class CustomerConsumptioVoucherInfoDto:BaseDto
    {
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
        /// 使用时间
        /// </summary>
        public DateTime? UseDate { get; set; }
        /// <summary>
        /// 抵用券来源0:会员赠送,1:其他人分享
        /// </summary>
        public int Source { get; set; }
        /// <summary>
        /// 抵用券类型 0:商品抵用券,1:面诊卡抵用券,2积分抵用券,3打车抵用券
        /// </summary>
        public int Type { get; set; }
        public string WriteOfCode { get; set; }
        public bool IsNeedMinPrice { get; set; }
        public decimal? MinPrice { get; set; }
        /// <summary>
        /// 抵用券编码
        /// </summary>
        public string VoucherCode { get; set; }
        /// <summary>
        /// 抵用券备注
        /// </summary>
        public string Remark { get; set; }
    }
}
