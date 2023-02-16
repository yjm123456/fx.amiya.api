using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TmallOrder
{
   public class OrderInfoSimpleDto
    {
        public string Id { get; set; }
        public string ThumbPicUrl { get; set; }
        public string GoodsId { get; set; }
        public string GoodsName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 合作医院（支付订单展示）
        /// </summary>
        public string AppointmentHospital { get; set; }
        /// <summary>
        /// 商品分类（实物商品订单展示）
        /// </summary>
        public string GoodsCategory { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public decimal?  SinglePrice { get; set; }
        /// <summary>
        /// 积分单价
        /// </summary>
        public decimal? SingleIntegrationQuantity { get; set; }
        /// <summary>
        /// 实付款
        /// </summary>
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 实付积分
        /// </summary>
        public decimal? IntegrationQuantity { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int Quantity { get; set; }

        public string Phone { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public int appType { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// 订单状态原版
        /// </summary>
        public string StatusCodeInfo { get; set; }
        /// <summary>
        /// 交易编号
        /// </summary>
        public string TradeId { get; set; }
        /// <summary>
        /// 是否使用抵用券
        /// </summary>
        public bool IsUseCoupon { get; set; }
        /// <summary>
        /// 订单使用的抵用券id
        /// </summary>
        public string CouponId { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int ExchageType { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string CustomerId { get; set; }

    }
}
