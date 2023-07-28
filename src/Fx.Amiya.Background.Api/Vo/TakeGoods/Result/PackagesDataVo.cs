using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TakeGoods.Result
{
    public class PackagesDataVo
    {
        /// <summary>
        /// 下单件数
        /// </summary>
        public int OrderCount { get; set; }
        /// <summary>
        /// 下单件数环比
        /// </summary>
        public decimal OrderCountChainRatio { get; set; }
        /// <summary>
        /// 下单件数同比
        /// </summary>
        public decimal OrderCountYearOnYear { get; set; }
        /// <summary>
        /// 实际下单件数
        /// </summary>
        public int ActualOrderCount { get; set; }
        /// <summary>
        /// 实际下单件数环比
        /// </summary>
        public decimal ActualOrderCountChainRatio { get; set; }
        /// <summary>
        /// 实际下单件数同比
        /// </summary>
        public decimal ActualOrderCountYearOnYear { get; set; }
        /// <summary>
        /// 刀刀组下单件数
        /// </summary>
        public int DaoDaoOrderCount { get; set; }
        /// <summary>
        /// 刀刀组下单件数环比
        /// </summary>
        public decimal DaoDaoOrderCountChainRatio { get; set; }
        /// <summary>
        /// 刀刀组下单件数同比
        /// </summary>
        public decimal DaoDaoOrderCountYearOnYear { get; set; }
        /// <summary>
        /// 刀刀组件数占比
        /// </summary>
        public decimal DaoDaoOrderCountProportion { get; set; }
        /// <summary>
        /// 吉娜组下单件数
        /// </summary>
        public int JinaOrderCount { get; set; }
        /// <summary>
        /// 吉娜组下单件数环比
        /// </summary>
        public decimal JinaOrderCountChainRatio { get; set; }
        /// <summary>
        /// 吉娜组下单件数同比
        /// </summary>
        public decimal JinaOrderCountYearOnYear { get; set; }
        /// <summary>
        /// 刀刀组件数占比
        /// </summary>
        public decimal JinaOrderCountProportion { get; set; }
        /// <summary>
        /// 退款件数
        /// </summary>
        public int RefundCount { get; set; }
        /// <summary>
        /// 退款件数环比
        /// </summary>
        public decimal RefundCountChainRatio { get; set; }
        /// <summary>
        /// 退款件数同比
        /// </summary>
        public decimal RefundCountYearOnYear { get; set; }

    }
}
