using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TakeGoods
{
    public class GroupTakeGoodsDataDto
    {
        public int Date { get; set; }
        public decimal OrderGMV { get; set; }
        /// <summary>
        /// 千川投放折线图
        /// </summary>
        public decimal QianChuanPutIn { get; set; }
        /// <summary>
        /// 退款GMV折线图
        /// </summary>
        public decimal RefundGMV { get; set; }
        /// <summary>
        /// 下单件数折线图
        /// </summary>
        public decimal OrderPackages { get; set; }
        /// <summary>
        /// 退款件数折线图
        /// </summary>
        public decimal RefundPackages { get; set; }
        /// <summary>
        /// 下单件单价折线图
        /// </summary>
        public decimal SinglePrice { get; set; }
        /// <summary>
        /// 退款件单价折线图
        /// </summary>
        public decimal RefundSinglePrice { get; set; }
    }
}
