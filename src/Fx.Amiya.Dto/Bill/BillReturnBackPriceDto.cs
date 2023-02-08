using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Bill
{
    public class BillReturnBackPriceDto
    {
        public string Id { get; set; }
        public decimal ReturnBackPrice { get; set; }

        public DateTime ReturnBackDate { get; set; }

        public int CreateBy { get; set; }
        public string Remark { get; set; }
    }
}
