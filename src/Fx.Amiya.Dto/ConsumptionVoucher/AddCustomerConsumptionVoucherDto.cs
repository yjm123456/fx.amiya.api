using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ConsumptionVoucher
{
    public class AddCustomerConsumptionVoucherDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 抵用券编码
        /// </summary>
        public string  ConsumptionVoucherCode { get; set; }
        /// <summary>
        /// 核销码
        /// </summary>
        public string WriteOfCode { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpireDate { get; set; }
        /// <summary>
        /// 分享人
        /// </summary>
        public string ShareBy { get; set; }
        /// <summary>
        /// 来源 0会员赠送,1分享,2每月领取
        /// </summary>
        public int Source { get; set; }

    }
}
