﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Order
{
    public class AddIntegralVirtualOrderDto
    {
        public string Id { get; set; }

        public string GoodsName { get; set; }
        public string GoodsId { get; set; }
        public string Phone { get; set; }
        public string StatusCode { get; set; }
        /// <summary>
        /// 价格（商品正常价格）
        /// </summary>
        public decimal? ActualPayment { get; set; }

        public DateTime? CreateDate { get; set; }
        
        public string ThumbPicUrl { get; set; }
        public string BuyerNick { get; set; }
        public byte AppType { get; set; }
        public byte OrderType { get; set; }
        public byte? OrderNature { get; set; }
        /// <summary>
        /// 预约门店
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// 抵扣积分
        /// </summary>
        public decimal? IntegrationQuantity { get; set; }
        /// <summary>
        /// 商品简介
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }


        /// <summary>
        /// 交易类型：0=积分,1三方支付,2余额支付
        /// </summary>
        public byte? ExchangeType { get; set; }

        /// <summary>
        /// 归属客服
        /// </summary>
        public int BelongEmpId { get; set; }
        /// <summary>
        /// 归属主播id
        /// </summary>
        public int BelongLiveAnchorId { get; set; }

        public string TradeId { get; set; }
        /// <summary>
        /// 是否使用抵用券
        /// </summary>
        public bool IsUseCoupon { get; set; }
        /// <summary>
        /// 使用的抵用券id
        /// </summary>
        public string CouponId { get; set; }
        /// <summary>
        /// 抵用券抵扣金额
        /// </summary>
        public decimal DeductMoney { get; set; }
    }
}
