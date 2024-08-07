using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalPartakeItem
{
   public class HospitalPartakeItemDto
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public int ItemId { get; set; }
        public string ThumbPicUrl { get; set; }
        public bool IsAgreeLivingPrice { get; set; }
        public decimal HospitalPrice { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Standard { get; set; }
        public string Parts { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal LivePrice { get; set; }
        public bool IsLimitBuy { get; set; }
        public int? LimitBuyQuantity { get; set; }
        public int ForenoonCanAppointmentQuantity { get; set; }
        public int AfternoonCanAppointmentQuantity { get; set; }
    }
}
