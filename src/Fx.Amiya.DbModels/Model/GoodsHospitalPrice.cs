using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class GoodsHospitalPrice
    {
        public string GoodsId { get; set; }
        public int HospitalId { get; set; }
        public decimal Price { get; set; }
    }
}
