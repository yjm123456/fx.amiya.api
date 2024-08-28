using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ReconciliationDocuments
{
    public class NewCustomerToHospiatlAndTargetCompleteVo
    {
        /// <summary>
        /// 新客上门人数
        /// </summary>
        public int NewCustomerToHospitalCount { get; set; }
        /// <summary>
        /// 目标完成率
        /// </summary>
        public decimal TargetComplete { get; set; }
        /// <summary>
        /// 老带新人数
        /// </summary>
        public int OldTakeNewCustomerNum { get; set; }
    }
}
