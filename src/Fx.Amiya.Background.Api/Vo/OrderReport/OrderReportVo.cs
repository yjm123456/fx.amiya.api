using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    /// <summary>
    /// 订单报表
    /// </summary>
    public class OrderReportVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public string Id { get; set; }
        /// <summary>
        /// 下单平台
        /// </summary>
        [Description("下单平台")]
        public string AppTypeText { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        [Description("下单时间")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 核销时间
        /// </summary>
        [Description("核销时间")]
        public DateTime? WriteOffDate { get; set; }

        /// <summary>
        /// 订单性质
        /// </summary>
        [Description("订单性质")]
        public string OrderNatureText { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        [Description("商品")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 支付积分
        /// </summary>
        [Description("支付积分")]
        public decimal? IntegrationQuantity { get; set; }
        /// <summary>
        /// 实付款
        /// </summary>
        [Description("实付款")]
        public decimal? ActualPayment { get; set; }

        /// <summary>
        /// 应收款
        /// </summary>
        [Description("应收款")]
        public decimal? AccountReceivable { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        [Description("购买数量")]
        public int? Quantity { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        [Description("订单状态")]
        public string StatusText { get; set; }
        /// <summary>
        /// 主播平台
        /// </summary>
        [Description("主播平台")]
        public string LiveAnchorPlatForm { get; set; }

        /// <summary>
        /// 归属主播
        /// </summary>
        [Description("归属主播")]
        public string LiveAnchor { get; set; }
        /// <summary>
        /// 归属客服
        /// </summary>
        [Description("归属客服")]
        public string BelongEmpName { get; set; }


        /// <summary>
        /// 客户昵称
        /// </summary>
        [Description("客户昵称")]
        public string NickName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Description("手机号")]
        public string Phone { get; set; }

        /// <summary>
        /// 预约门店
        /// </summary>
        [Description("预约门店")]
        public string AppointmentHospital { get; set; }
    }
}
