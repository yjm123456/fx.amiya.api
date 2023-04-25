using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class BeforeLivingZhiHuDailyTarget : BaseDbModel
    {
        public string LiveAnchorMonthlyTargetId { get; set; }

        public int OperationEmpId { get; set; }

        public decimal FlowInvestmentNum { get; set; }

        public int SendNum { get; set; }

        public DateTime RecordDate { get; set; }

        public LiveAnchorMonthlyTargetBeforeLiving LiveAnchorMonthlyTargetBeforeLiving { get; set; }

        public AmiyaEmployee AmiyaEmployee { get; set; }
    }
}
