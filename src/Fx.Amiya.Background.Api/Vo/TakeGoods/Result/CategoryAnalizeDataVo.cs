using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TakeGoods.Result
{
    public class CategoryAnalizeDataVo
    {
        /// <summary>
        /// 下单GMV占比分析
        /// </summary>
        public List<BaseIdNameAndRateVo> CreateOrderGMVAnalizeData { get; set; }
        /// <summary>
        /// 下单件数占比分析
        /// </summary>
        public List<BaseIdNameAndRateVo> CreateOrderNumAnalizeData { get; set; }
        /// <summary>
        /// 下单件单价分析
        /// </summary>
        public List<BaseIdNameAndRateVo> CreateOrderSinglePriceAnalizeData { get; set; }
        /// <summary>
        /// 实际GMV占比分析
        /// </summary>
        public List<BaseIdNameAndRateVo> ActualGMVAnalizeData { get; set; }
        /// <summary>
        /// 实际件数占比分析
        /// </summary>
        public List<BaseIdNameAndRateVo> ActualNumAnalizeData { get; set; }
        /// <summary>
        /// 实际件单价分析
        /// </summary>
        public List<BaseIdNameAndRateVo> ActualSinglePriceAnalizeData { get; set; }
        /// <summary>
        /// 退款GMV占比分析
        /// </summary>
        public List<BaseIdNameAndRateVo> RefundGMVAnalizeData { get; set; }
        /// <summary>
        /// 退款件数占比分析
        /// </summary>
        public List<BaseIdNameAndRateVo> RefundNumAnalizeData { get; set; }
        /// <summary>
        /// 退款件单价分析
        /// </summary>
        public List<BaseIdNameAndRateVo> RefundSinglePriceAnalizeData { get; set; }
    }
}
