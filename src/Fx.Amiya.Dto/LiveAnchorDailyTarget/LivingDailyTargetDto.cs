using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorDailyTarget
{
    public class LivingDailyTargetDto : BaseDto
    {
        public string LiveAnchorMonthlyTargetId { get; set; }

        public string LiveAnchor { get; set; }

        public int OperationEmpId { get; set; }

        public string OperationEmpName { get; set; }

        public decimal LivingRoomFlowInvestmentNum { get; set; }

        public int Consultation { get; set; }
        public int Consultation2 { get; set; }
        public decimal CargoSettlementCommission { get; set; }

        public DateTime RecordDate { get; set; }
    }
}
