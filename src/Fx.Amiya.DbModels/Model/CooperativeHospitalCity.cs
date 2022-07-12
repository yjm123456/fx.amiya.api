using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class CooperativeHospitalCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Valid { get; set; }

        public string ProvinceId { get; set; }
        public bool IsHot { get; set; }

        public List<HospitalInfo> HospitalInfoList { get; set; }
        public List<GoodsShopCar> GoodsShopCar { get; set; }
    }
}
