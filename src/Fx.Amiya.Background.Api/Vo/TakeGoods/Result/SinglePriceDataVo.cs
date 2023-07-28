using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TakeGoods.Result
{
    public class SinglePriceDataVo
    {
        /// <summary>
        /// 下单件单价
        /// </summary>
        public decimal SinglePrice { get; set; }
        /// <summary>
        /// 下单件单价环比
        /// </summary>
        public decimal SinglePriceChainRatio { get; set; }
        /// <summary>
        /// 下单件单价同比
        /// </summary>
        public decimal SinglePriceYearOnYear { get; set; }
        /// <summary>
        /// 实际件单价
        /// </summary>
        public decimal ActualSinglePrice { get; set; }
        /// <summary>
        /// 实际件单价环比
        /// </summary>
        public decimal ActualSinglePriceChainRatio { get; set; }
        /// <summary>
        /// 实际件单价同比
        /// </summary>
        public decimal ActualSinglePriceYearOnYear { get; set; }
        /// <summary>
        /// 刀刀组件单价
        /// </summary>
        public decimal DaoDaoActualSinglePrice { get; set; }
        /// <summary>
        /// 刀刀组件数环比
        /// </summary>
        public decimal DaoDaoActualSinglePriceChainRatio { get; set; }
        /// <summary>
        /// 刀刀组件数同比
        /// </summary>
        public decimal DaoDaoActualSinglePriceYearOnYear { get; set; }
        /// <summary>
        /// 吉娜组件数
        /// </summary>
        public decimal JinaActualSinglePrice { get; set; }
        /// <summary>
        /// 吉娜组件数环比
        /// </summary>
        public decimal JinaActualSinglePriceChainRatio { get; set; }
        /// <summary>
        /// 吉娜组件数同比
        /// </summary>
        public decimal JinaActualSinglePriceYearOnYear { get; set; }
        /// <summary>
        /// 退款件单价
        /// </summary>
        public decimal RefundSinglePrice { get; set; }
        /// <summary>
        /// 退款件单价环比
        /// </summary>
        public decimal RefundSinglePriceChainRatio { get; set; }
        /// <summary>
        /// 退款件单价同比
        /// </summary>
        public decimal RefundSinglePriceYearOnYear { get; set; }
    }
}
