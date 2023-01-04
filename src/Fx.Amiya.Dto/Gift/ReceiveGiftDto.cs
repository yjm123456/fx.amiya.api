using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Gift
{
   public class ReceiveGiftDto
    {
        public int Id { get; set; }
        public int GiftId { get; set; }
        public string GiftName { get; set; }
        public string ThumbPicUrl { get; set; }
        public string CustomerId { get; set; }
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }
        public string Address { get; set; }
        public string ReceiveName { get; set; }
        public string ReceivePhone { get; set; }
        public DateTime Date { get; set; }
        public string CourierNumber { get; set; }
        public string ExpressId { get; set; }
        public int Quantity { get; set; }
        public bool IsSendGoods { get; set; }
        public int? SendGoodsBy { get; set; }
        public string SendGoodsName { get; set; }
        public DateTime? SendGoodsDate { get; set; }

        public string OrderId { get; set; }
        public string GoodsThumbPicUrl { get; set; }
        public string GoodsName { get; set; }
        public decimal? ActualPayment { get; set; }
        public string TbBuyerNick { get; set; }
        public string CategoryName { get; set; }
    }
}
