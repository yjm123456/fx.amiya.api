using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LivingDailyTakeGoods.Input
{
    public class LivingDailyTakeGoodsImportDto
    {
        public int CreateBy { get; set; }
        /// <summary>
        /// 带货时间
        /// </summary>

        public DateTime? TakeGoodsDate { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 品类名称
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 品项名称
        /// </summary>
        public string ItemDetails { get; set; }
        /// <summary>
        /// 主播平台名称
        /// </summary>
        public string ContentPlatForm { get; set; }
        /// <summary>
        /// 主播IP账号名称
        /// </summary>
        public string LiveAnchor { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Item { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        public int TakeGoodsQuantity { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 订单量
        /// </summary>
        public int OrderNum { get; set; }
        /// <summary>
        /// 带货商品类型（下单,退款）
        /// </summary>
        public string TakeGoodsType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
