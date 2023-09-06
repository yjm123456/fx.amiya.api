using Fx.Amiya.BusinessWeChat.Api.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWechat.Api.Vo.TakeGoods.Result
{
    public class GMVDataBrokenLineVo
    {
        /// <summary>
        /// 下单GMV折线图
        /// </summary>
        public List<BaseBrokenLineVo> OrderGMVBrokenLineList { get; set; }
        /// <summary>
        /// 千川投放折线图
        /// </summary>
        public List<BaseBrokenLineVo> QianChuanPutInBrokenLineList { get; set; }
        /// <summary>
        /// 退款GMV折线图
        /// </summary>
        public List<BaseBrokenLineVo> RefundGMVBrokenLineList { get; set; }
        /// <summary>
        /// 下单件数折线图
        /// </summary>
        public List<BaseBrokenLineVo> OrderPackagesBrokenLineList { get; set; }
        /// <summary>
        /// 退款件数折线图
        /// </summary>
        public List<BaseBrokenLineVo> RefundPackagesBrokenLineList { get; set; }
        /// <summary>
        /// 下单件单价折线图
        /// </summary>
        public List<BaseBrokenLineVo> SinglePriceBrokenLineList { get; set; }
        /// <summary>
        /// 退款件单价折线图
        /// </summary>
        public List<BaseBrokenLineVo> RefundSinglePriceBrokenLineList { get; set; }
    }
}
