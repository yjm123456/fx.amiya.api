using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Address
{
   public class UpdateAddressDto
    {
        public int Id { get; set; }
        public string Province { get; set; }
        public string ProvinceCode { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string District { get; set; }
        public string DistrictCode { get; set; }
        public string Other { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public bool IsDefault { get; set; }
    }
}
