using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TakeGoods
{
    public class TakeGoodsDataDto
    {
        /// <summary>
        /// gmv
        /// </summary>
        public decimal GMV { get; set; }
        /// <summary>
        /// 件数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 件单价
        /// </summary>
        public decimal SinglePrice { get; set; }
        /// <summary>
        /// 主播id
        /// </summary>
        public int LiveAnchorId { get; set; }
        /// <summary>
        /// 带货类型
        /// </summary>
        public int TakeGoodsType { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 带货时间
        /// </summary>
        public DateTime TakeGoodsDate { get; set; }
    }
}
