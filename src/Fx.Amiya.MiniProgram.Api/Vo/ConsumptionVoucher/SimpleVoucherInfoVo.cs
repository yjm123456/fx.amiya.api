using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.ConsumptionVoucher
{
    public class SimpleVoucherInfoVo
    {
        /// <summary>
        /// 用户抵用券id
        /// </summary>
        public string CustomerVoucherId { get; set; }
        /// <summary>
        /// 抵用券名称
        /// </summary>
        public string VoucherName { get; set; }
        /// <summary>
        /// 是否是指定商品抵用券
        /// </summary>
        public bool IsSpecifyProduct { get; set; }
        /// <summary>
        /// 抵用券类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 是否有最小消费金额限制
        /// </summary>
        public bool IsNeedMinFee { get; set; }
        /// <summary>
        /// 最小消费金额
        /// </summary>
        public decimal MinPrice { get; set; }
        /// <summary>
        /// 抵用券id
        /// </summary>
        public string VioucherId { get; set; }
        /// <summary>
        /// 抵用券使用说明
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 抵扣金额
        /// </summary>
        public decimal DeductMoney { get; set; }
    }
}
