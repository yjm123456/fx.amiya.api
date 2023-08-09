using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LivingDailyTakeGoods.Input
{
    public class LivingDailyTakeGoodsUpdateVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 带货时间
        /// </summary>

        public DateTime? TakeGoodsDate { get; set; }

        /// <summary>
        /// 品牌id
        /// </summary>
        public string BrandId { get; set; }
        /// <summary>
        /// 品类id
        /// </summary>
        public string CategoryId { get; set; }
        /// <summary>
        /// 品项id
        /// </summary>
        public string ItemDetailsId { get; set; }
        /// <summary>
        /// 主播平台
        /// </summary>
        public string ContentPlatFormId { get; set; }
        /// <summary>
        /// 主播IP账号id
        /// </summary>
        public int LiveAnchorId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal SinglePrice { get; set; }
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
        /// 带货商品类型（0-下单；1-退款）
        /// </summary>
        public int TakeGoodsType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
