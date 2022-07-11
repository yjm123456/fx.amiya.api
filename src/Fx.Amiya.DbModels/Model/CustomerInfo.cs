using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class CustomerInfo
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }
        public string Phone { get; set; }

        public UserInfo UserInfo { get; set; }

        public List<AppointmentInfo> AppointmentInfoList { get; set; }
        public List<ReceiveGift> ReceiveGiftList { get; set; }
        public List<Address> AddressList { get; set; }
        public List<OrderTrade> OrderTradeList { get; set; }
        public List<GoodsShopCar> GoodsShopCar { get; set; }
    }
}
