using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ConsumptionVoucher
{
    /// <summary>
    /// 抵用券类型列表
    /// </summary>
    public class ConsumptionVoucherTypeListVo
    {
        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeText { get; set; }
    }
}
