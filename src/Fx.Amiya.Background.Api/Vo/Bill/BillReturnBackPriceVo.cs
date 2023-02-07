using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Bill
{
    public class BillReturnBackPriceVo
    {
        public string Id { get; set; }
        public decimal ReturnBackPrice { get; set; }

        public DateTime ReturnBackDate { get; set; }

    }
}
