using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderReport
{
    public class HospitalOrderNumAndPriceDto
    {
        public string HospitalName { get; set; }

        public int OrderNum { get; set; }

        public decimal Price { get; set; }
    }
}
