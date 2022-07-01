using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string Province { get; set; }
        public string ProvinceCode { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string District { get; set; }
        public string DistrictCode { get; set; }
        public string Other { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }

        public CustomerInfo CustomerInfo { get; set; }

        public List<ReceiveGift> ReceiveGiftList { get; set; }
        public List<OrderTrade> OrderTradeList { get; set; }
    }
}
