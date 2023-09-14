using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AssistantHomePage.Result
{
    public class MonthPerformanceCompleteSituationDataVo
    {
        /// <summary>
        /// 已完成业绩
        /// </summary>
        public decimal CompletedPerformance { get; set; }
        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
        /// <summary>
        /// 分诊量
        /// </summary>
        public int TriageCount { get; set; }
        /// <summary>
        /// 加v量
        /// </summary>
        public int AddWechat { get; set; }
        /// <summary>
        /// 加v率
        /// </summary>
        public decimal AddWechatRatio { get; set; }
        /// <summary>
        /// 派单量
        /// </summary>
        public int SenOrderCount { get; set; }
        /// <summary>
        /// 派单率
        /// </summary>
        public decimal SendOrderRatio { get; set; }
        /// <summary>
        /// 到院量
        /// </summary>
        public int ToHospitalCount { get; set; }
        public decimal ToHospitalCountRatio { get; set; }
        /// <summary>
        /// 成交量
        /// </summary>
        public int DealCount { get; set; }
        /// <summary>
        /// 成交率
        /// </summary>
        public decimal DealRatio { get; set; }
    }
}
