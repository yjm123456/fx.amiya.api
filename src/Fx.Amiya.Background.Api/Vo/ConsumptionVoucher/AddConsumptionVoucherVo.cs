using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ConsumptionVoucher
{
    public class AddConsumptionVoucherVo
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
        /// 抵用券类型0:实体商品抵扣,1:虚拟商品抵扣(如面诊卡)
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 当前抵用券是否有效
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// 抵用券编码
        /// </summary>
        public string ConsumptionVoucherCode { get; set; }
    }
}
