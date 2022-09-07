using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.ConsumptionVoucher
{
    public class ShareConsumptionVoucherVo
    {
        /// <summary>
        /// 分享人
        /// </summary>
        [Required]
        public string ShareBy { get; set; }
        /// <summary>
        /// 被分享的用户优惠券id
        /// </summary>
        [Required]
        public string ConsumerConsumptionVoucherId { get; set; }
    }
}
