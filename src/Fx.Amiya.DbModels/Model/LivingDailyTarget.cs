using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class LivingDailyTarget : BaseDbModel
    {
        public string LiveAnchorMonthlyTargetId { get; set; }

        public int OperationEmpId { get; set; }

        public decimal LivingRoomFlowInvestmentNum { get; set; }

        public int Consultation { get; set; }
        public int Consultation2 { get; set; }
        public decimal CargoSettlementCommission { get; set; }

        /// <summary>
        /// 退卡量
        /// </summary>
        public int RefundCard { get; set; }
        /// <summary>
        /// GMV
        /// </summary>
        public decimal GMV { get; set; }
        
        /// <summary>
        /// 去卡GMV
        /// </summary>
        public decimal EliminateCardGMV { get; set; }
        /// <summary>
        /// 退款gmv
        /// </summary>
        public decimal RefundGMV { get; set; }


        public DateTime RecordDate { get; set; }

        public LiveAnchorMonthlyTargetLiving LiveAnchorMonthlyTargetLiving { get; set; }

        public AmiyaEmployee AmiyaEmployee { get; set; }
    }
}
