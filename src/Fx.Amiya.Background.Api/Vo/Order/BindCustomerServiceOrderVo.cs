using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    public class BindCustomerServiceOrderVo
    {
        public string Id { get; set; }
        public string GoodsName { get; set; }
        public string GoodsId { get; set; }
        public string ThumbPicUrl { get; set; }
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }
        public string AppointmentHospital { get; set; }
        /// <summary>
        /// 实付款
        /// </summary>
        public decimal? ActualPayment { get; set; }
        public bool IsAppointment { get; set; }
        public string Status { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string StatusText { get; set; }
        /// <summary>
        /// 客服编号
        /// </summary>
        public int CustomerServiceId { get; set; }

        /// <summary>
        /// 客服名称
        /// </summary>
        public string CustomerServiceName { get; set; }

        /// <summary>
        /// 平台类型
        /// </summary>
        public byte AppType { get; set; }

        /// <summary>
        /// 平台类型名称
        /// </summary>
        public string AppTypeText{get;set;}

        /// <summary>
        /// 购买数量
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// 支付积分
        /// </summary>
        public decimal? IntegrationQuantity { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public byte? ExchangeType { get; set; }
        public string ExchangeTypeText { get; set; }
        public string TradeId { get; set; }
    }
}
