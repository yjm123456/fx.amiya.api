using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class ReceiveGift
    {
        public int Id { get; set; }
        public int GiftId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public bool IsSendGoods { get; set; }
        public int? SendGoodsBy { get; set; }
        public DateTime? SendGoodsDate { get; set; }
        public string ReceiveName { get; set; }
        public string ReceivePhone { get; set; }
        public string CourierNumber { get; set; }
        public string ExpressId { get; set; }
        public string OrderId { get; set; }
        public int? AddressId { get; set; }
        public int? CreateBy { get; set; }
        /// <summary>
        /// 领取类型
        /// </summary>
        public int SendType { get; set; }
        public OrderInfo OrderInfo { get; set; }

        public GiftInfo GiftInfo { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public AmiyaEmployee AmiyaEmployee { get; set; }
        public Address AddressInfo { get; set; }
    }
}
