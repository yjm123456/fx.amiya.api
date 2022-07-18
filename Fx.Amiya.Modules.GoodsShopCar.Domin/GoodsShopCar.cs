using Fx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.GoodsShopCar.Domin
{
    public class GoodsShopCar:IEntity
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string GoodsId { get; set; }
        public int Num { get; set; }
        public byte Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CityId { get; set; }
        public int HospitalId { get; set; }
    }
}
