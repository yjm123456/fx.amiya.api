using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    /// <summary>
    /// 小程序实物订单展示
    /// </summary>
    public class MiniProgramOrderTradeVo
    {
        /// <summary>
        /// 交易编号
        /// </summary>
        [Description("交易编号")]
        public string TradeId { get; set; }
        /// <summary>
        /// 下单人电话
        /// </summary>
        [Description("下单人电话")]
        public string Phone { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 状态编码
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        public string StatusText { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Description("地址")]
        public string Address { get; set; }
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
        /// 绑定订单号
        /// </summary>
        [Description("绑定订单号")]
        public string BindOrderIds { get; set; }
        /// <summary>
        /// 商品
        /// </summary>
        [Description("商品")]
        public string Goods { get; set; }


        /// <summary>
        /// 购买总量
        /// </summary>
        [Description("购买总量")]
        public int Quantities { get; set; }

        /// <summary>
        /// 实付总积分
        /// </summary>
        [Description("实付总积分")]
        public decimal IntergrationAccounts { get; set; }
        /// <summary>
        /// 实付款
        /// </summary>
        [Description("实付款")]
        public decimal TotalAmount { get; set; }
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
