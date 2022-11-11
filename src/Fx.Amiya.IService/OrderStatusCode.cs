using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.IService
{
   public class OrderStatusCode
    {
        /// <summary>
        /// 等待买家付款
        /// </summary>
        public static string WAIT_BUYER_PAY = "WAIT_BUYER_PAY";

        /// <summary>
        /// 等待卖家发货,即:买家已付款
        /// </summary>
        public static string WAIT_SELLER_SEND_GOODS = "WAIT_SELLER_SEND_GOODS";

        /// <summary>
        /// 等待买家确认收货,即:卖家已发货
        /// </summary>
        public static string WAIT_BUYER_CONFIRM_GOODS = "WAIT_BUYER_CONFIRM_GOODS";

        /// <summary>
        /// 买家已签收,货到付款专用
        /// </summary>
        public static string TRADE_BUYER_SIGNED = "TRADE_BUYER_SIGNED";

        /// <summary>
        /// 买家已付款（小程序美肤卡使用）
        /// </summary>
        public static string TRADE_BUYER_PAID = "TRADE_BUYER_PAID";

        /// <summary>
        /// 交易成功
        /// </summary>
        public static string TRADE_FINISHED = "TRADE_FINISHED";

        /// <summary>
        /// 退款审核中
        /// </summary>
        public static string REFUNDING = "REFUNDING";

        /// <summary>
        /// 付款以后用户退款成功，交易自动关闭
        /// </summary>
        public static string TRADE_CLOSED = "TRADE_CLOSED";

        /// <summary>
        /// 付款以前，卖家或买家主动关闭交易
        /// </summary>
        public static string TRADE_CLOSED_BY_TAOBAO = "TRADE_CLOSED_BY_TAOBAO";

        /// <summary>
        /// 定金订单
        /// </summary>
        public static string BARGAIN_MONEY = "BARGAIN_MONEY";

        /// <summary>
        /// 咨询订单
        /// </summary>
        public static string SEEK_ADVICE = "SEEK_ADVICE";
        /// <summary>
        /// 部分退款(购物车使用)
        /// </summary>
        public static string PARTIAL_REFUND = "PARTIAL_REFUND";
        /// <summary>
        /// 退款审核未通过
        /// </summary>
        public static string CHECK_FAIL = "CHECK_FAIL";
    }
}
