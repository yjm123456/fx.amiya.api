using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 微博数据改为快手数据
    /// </summary>
    public class BeforeLivingSinaWeiBoDailyTarget : BaseDbModel
    {
        public string LiveAnchorMonthlyTargetId { get; set; }

        public int OperationEmpId { get; set; }

        public decimal FlowInvestmentNum { get; set; }

        public int SendNum { get; set; }
        public string Remark { get; set; }

        public DateTime RecordDate { get; set; }

        public LiveAnchorMonthlyTargetBeforeLiving LiveAnchorMonthlyTargetBeforeLiving { get; set; }

        public AmiyaEmployee AmiyaEmployee { get; set; }
    }
}
