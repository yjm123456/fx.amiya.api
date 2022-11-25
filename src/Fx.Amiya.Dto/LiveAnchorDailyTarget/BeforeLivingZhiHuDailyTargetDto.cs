using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorDailyTarget
{
    public class BeforeLivingZhiHuDailyTargetDto : BaseDto
    {
        public string LiveAnchorMonthlyTargetId { get; set; }

        public string LiveAnchor { get; set; }

        public int OperationEmpId { get; set; }

        public string OperationEmpName { get; set; }

        public decimal FlowInvestmentNum { get; set; }

        public int SendNum { get; set; }

        public DateTime RecordDate { get; set; }
    }
}
