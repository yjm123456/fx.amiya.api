using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.SyncOrder.Core
{
    public class AmiyaOrder
    {
        public string Id { get; set; }
        public string GoodsName { get; set; }
        public string GoodsId { get; set; }
        public string Phone { get; set; }
        public string AppointmentHospital { get; set; }
        public string StatusCode { get; set; }
        /// <summary>
        /// 价格（商品正常价格）
        /// </summary>
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 应收款（优惠后实际价格，财务用）
        /// </summary>
        public decimal? AccountReceivable { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? WriteOffDate { get; set; }
        public string ThumbPicUrl { get; set; }
        public string BuyerNick { get; set; }
        public byte AppType { get; set; }
        public bool IsAppointment { get; set; }
        //  public string Type { get; set; }

        /// <summary>
        /// 订单类型：0=虚拟订单（电子凭证），1=实物订单（快递发货）
        /// </summary>
        public byte OrderType { get; set; }
        public int Quantity { get; set; }

    }
}
