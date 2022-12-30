using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class GoodsShopCar
    {

        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string GoodsId { get; set; }
        public int Num { get; set; }
        public int Status { get; set; }

        public int? CityId { get; set; }

        public int? HospitalId { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string SelectStandards { get; set; }
        public GoodsInfo GoodsInfo { get; set; }

        public CustomerInfo CustomerInfo { get; set; }

        public CooperativeHospitalCity City { get; set; }

        public HospitalInfo HospitalInfo { get; set; }
    }
}
