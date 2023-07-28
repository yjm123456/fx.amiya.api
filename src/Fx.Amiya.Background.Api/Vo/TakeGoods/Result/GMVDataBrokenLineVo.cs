using Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TakeGoods.Result
{
    public class GMVDataBrokenLineVo
    {
        /// <summary>
        /// 下单GMV折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> OrderGMVBrokenLineList { get; set; }
        /// <summary>
        /// 千川投放折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> QianChuanPutInBrokenLineList { get; set; }
        /// <summary>
        /// 退款GMV折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> RefundGMVBrokenLineList { get; set; }
        /// <summary>
        /// 下单件数折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> OrderPackagesBrokenLineList { get; set; }
        /// <summary>
        /// 退款件数折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> RefundPackagesBrokenLineList { get; set; }
        /// <summary>
        /// 下单件单价折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> SinglePriceBrokenLineList { get; set; }
        /// <summary>
        /// 退款件单价折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> RefundSinglePriceBrokenLineList { get; set; }
    }
}
