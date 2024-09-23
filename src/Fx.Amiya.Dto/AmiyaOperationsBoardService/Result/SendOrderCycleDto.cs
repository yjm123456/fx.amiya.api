using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class SendOrderCycleDto
    {
        public string Phone { get; set; }

        public DateTime SendDate { get; set; }

        public DateTime? ToHospitalDate { get; set; }
        public DateTime ShoppingCartRegistrationRecordDate { get; set; }
        public int DateDiff { get; set; }
    }
}
