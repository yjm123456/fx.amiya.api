using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Gift
{
   public class ReceiveGiftSimpleDto
    {
        public int Id { get; set; }
        public int GiftId { get; set; }
        public string GiftName { get; set; }
        public string ThumbPicUrl { get; set; }
        public string ReceivePhone { get; set; }
        public DateTime Date { get; set; }
        public bool IsSendGoods { get; set; }
        public string CourierNumber { get; set; }
        public DateTime? SendGoodsDate { get; set; }

        public string OrderId { get; set; }
        public string CategoryName { get; set; }
    }
}
