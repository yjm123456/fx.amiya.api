using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TakeGoods
{
    public class CategoryAnalizeDataDto
    {

        /// <summary>
        /// 下单GMV占比分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> CreateOrderGMVAnalizeData { get; set; }
        /// <summary>
        /// 下单件数占比分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> CreateOrderNumAnalizeData { get; set; }
        /// <summary>
        /// 下单件单价分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> CreateOrderSinglePriceAnalizeData { get; set; }
        /// <summary>
        /// 实际GMV占比分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> ActualGMVAnalizeData { get; set; }
        /// <summary>
        /// 实际件数占比分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> ActualNumAnalizeData { get; set; }
        /// <summary>
        /// 实际件单价分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> ActualSinglePriceAnalizeData { get; set; }
        /// <summary>
        /// 退款GMV占比分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> RefundGMVAnalizeData { get; set; }
        /// <summary>
        /// 退款件数占比分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> RefundNumAnalizeData { get; set; }
        /// <summary>
        /// 退款件单价分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> RefundSinglePriceAnalizeData { get; set; }
    }
}
