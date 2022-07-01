using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.TmallOrder
{
    /// <summary>
    /// 小程序订单明细展示模型
    /// </summary>
    public class OrderInfoMiniProgramDetailVo
    {

        public string OrderId { get; set; }
        public string ThumbPicUrl { get; set; }
        public string GoodsName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateDate { get; set; }
        /// <summary>
        /// 合作医院（支付订单展示）
        /// </summary>
        public string AppointmentHospital { get; set; }
        /// <summary>
        /// 配送门店地址
        /// </summary>
        public string HospitalAddress { get; set; }
        /// <summary>
        /// 商品分类（实物商品订单展示）
        /// </summary>
        public string GoodsCategory { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public decimal? SinglePrice { get; set; }
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
        /// 订单类型(可根据订单类型定位配送方式：0为自提，1为快递)
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 购买人昵称
        /// </summary>
        public string BuyerNick { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public int appType { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// 订单状态（说明）
        /// </summary>
        public string StatusText { get; set; }
        /// <summary>
        /// 核销码
        /// </summary>
        public string WriteOffCode { get; set; }

        /// <summary>
        /// 退款信息
        /// </summary>
        public RefundOrderInfo RefundOrderInfo { get; set; }

    }

    /// <summary>
    /// 退款申请情况
    /// </summary>
    public class RefundOrderInfo { 
    
        /// <summary>
        /// 审核类型
        /// </summary>
        public string CheckTypeText { get; set; }

        /// <summary>
        /// 审核原因
        /// </summary>
        public string CheckReason { get; set; }

        /// <summary>
        /// 退款原因
        /// </summary>
        public string RefundReason { get; set; }
    }

    /// <summary>
    /// 已购买订单展示模型
    /// </summary>
    public class TmallOrderSimpleVo
    {

        public string OrderId { get; set; }
        public string ThumbPicUrl { get; set; }
        public string GoodsName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateDate { get; set; }
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
        public decimal? SinglePrice { get; set; }
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
        /// <summary>
        /// 订单来源
        /// </summary>
        public int appType { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// 订单状态原版参数
        /// </summary>
        public string StatusCodeInfo { get; set; }
        /// <summary>
        /// 交易编号
        /// </summary>
        public string TradeId { get; set; }


    }

    /// <summary>
    /// 核销好礼展示模型
    /// </summary>
    public class WriteOffOrderVo {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public string ThumbPicUrl { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public int AppType { get; set; }

        /// <summary>
        /// 医院
        /// </summary>
        public string AppointmentHospital { get; set; }
    }
}
