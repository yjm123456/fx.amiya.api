using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Gift
{
    /// <summary>
    /// 导出已领取礼品列表数据
    /// </summary>
    public class ExportReveiveGiftVo
    {
        /// <summary>
        /// 礼品名称
        /// </summary>
        [Description("礼品名称")]
        public string GiftName { get; set; }
        /// <summary>
        /// 礼品类别
        /// </summary>
        [Description("礼品类别")]
        public string CategoryName { get; set; }
        /// <summary>
        /// 领取人电话
        /// </summary>
        [Description("领取人电话")]
        public string Phone { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        [Description("收货人")]
        public string ReceiveName { get; set; }
        /// <summary>
        /// 收货人电话
        /// </summary>
        [Description("收货人电话")]
        public string ReceivePhone { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        [Description("收货地址")]
        public string Address { get; set; }

        /// <summary>
        /// 领取时间
        /// </summary>
        [Description("领取时间")]
        public DateTime Date { get; set; }
        /// <summary>
        /// 绑定订单号
        /// </summary>
        [Description("绑定订单号")]
        public string OrderId { get; set; }
        /// <summary>
        /// 订单实付款
        /// </summary>
        [Description("订单实付款")]
        public decimal? ActualPayment { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        [Description("快递单号")]
        public string CourierNumber { get; set; }
        /// <summary>
        /// 物流公司
        /// </summary>
        [Description("物流公司")]
        public string ExpressName { get; set; }
        /// <summary>
        /// 发货人
        /// </summary>
        [Description("发货人")]
        public string SendGoodsName { get; set; }
        /// <summary>
        /// 发货时间
        /// </summary>
        [Description("发货时间")]
        public DateTime? SendGoodsDate { get; set; }
    }
}
