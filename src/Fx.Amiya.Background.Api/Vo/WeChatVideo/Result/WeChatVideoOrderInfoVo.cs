﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WeChatVideo
{
    public class WeChatVideoOrderInfoVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// 订单状态文本
        /// </summary>
        public string StatusCodeText { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 应收款（优惠后实际价格，财务用）
        /// </summary>
        public decimal? AccountReceivable { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public string CreateDate { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string? UpdateDate { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public string ThumbPicUrl { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string BuyerNick { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>

        public long? OrderType { get; set; }
        /// <summary>
        /// 订单类型文本
        /// </summary>
        public string OrderTypeText { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int? Quantity { get; set; }
        /// <summary>
        /// 归属主播Id
        /// </summary>
        public int? BelongLiveAnchorId { get; set; }
        /// <summary>
        /// 归属主播名称
        /// </summary>
        public string BelongLiveAnchorName { get; set; }
    }
}
