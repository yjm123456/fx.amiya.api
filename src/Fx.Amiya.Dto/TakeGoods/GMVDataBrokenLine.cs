using Fx.Amiya.Dto.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TakeGoods
{
    public class GMVDataBrokenLineDto
    {
        /// <summary>
        /// 下单GMV折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> OrderGMVBrokenLineList { get; set; }
        /// <summary>
        /// 千川投放折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> QianChuanPutInBrokenLineList { get; set; }
        /// <summary>
        /// 退款GMV折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> RefundGMVBrokenLineList { get; set; }
        /// <summary>
        /// 下单件数折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> OrderPackagesBrokenLineList { get; set; }
        /// <summary>
        /// 退款件数折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> RefundPackagesBrokenLineList { get; set; }
        /// <summary>
        /// 下单件单价折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> SinglePriceBrokenLineList { get; set; }
        /// <summary>
        /// 退款件单价折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> RefundSinglePriceBrokenLineList { get; set; }

    }
}
