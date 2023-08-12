using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ItemInfo
{
    public class ImportTemplate
    {
        /// <summary>
        /// 主播平台名称
        /// </summary>
        [Description("主播平台")]
        public string ContentPlatForm { get; set; }
        /// <summary>
        /// 主播IP账号名称
        /// </summary>
        [Description("主播ip")]
        public string LiveAnchor { get; set; }
        /// <summary>
        /// 品类名称
        /// </summary>
        [Description("品类")]
        public string Category { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        [Description("品牌")]
        public string Brand { get; set; }
        /// <summary>
        /// 品项名称
        /// </summary>
        [Description("品项")]
        public string ItemDetails { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Description("商品名称")]
        public string Item { get; set; }
        /// <summary>
        /// 带货时间
        /// </summary>
        [Description("带货时间")]
        public DateTime? TakeGoodsDate { get; set; }
        /// <summary>
        /// 带货商品类型（下单,退款）
        /// </summary>
        [Description("带货类型")]
        public string TakeGoodsType { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Description("数量")]
        public int TakeGoodsQuantity { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        [Description("总价")]
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 订单量
        /// </summary>
        [Description("订单量")]
        public int OrderNum { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
    }
}
