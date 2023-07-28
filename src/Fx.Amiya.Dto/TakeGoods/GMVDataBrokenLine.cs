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
        public List<PeformanceBrokenLineListInfoDto> OrderGMVBrokenLineList { get; set; }
        /// <summary>
        /// 千川投放折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> QianChuanPutInBrokenLineList { get; set; }
        /// <summary>
        /// 退款GMV折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> RefundGMVBrokenLineList { get; set; }
        /// <summary>
        /// 下单件数折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> OrderPackagesBrokenLineList { get; set; }
        /// <summary>
        /// 退款件数折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> RefundPackagesBrokenLineList { get; set; }
        /// <summary>
        /// 下单件单价折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> SinglePriceBrokenLineList { get; set; }
        /// <summary>
        /// 退款件单价折线图
        /// </summary>
        public List<PeformanceBrokenLineListInfoDto> RefundSinglePriceBrokenLineList { get; set; }

    }
}
