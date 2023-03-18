using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.OutPut
{
    public class HospitalOrderAndPriceInfoVo
    {
        public string HospitalName { get; set; }
        public decimal Price { get; set; }
        public int OrderNum { get; set; }
    }
}
