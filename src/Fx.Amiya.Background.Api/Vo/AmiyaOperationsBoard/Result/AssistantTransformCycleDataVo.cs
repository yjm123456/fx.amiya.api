using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class AssistantTransformCycleDataVo
    {
        /// <summary>
        /// 当前助理有效分诊派单转化周期
        /// </summary>
        public int EffectiveSendCycle { get; set; }
        /// <summary>
        /// 当前助理有效分诊上门转化周期
        /// </summary>
        public int EffectiveToHospitalCycle { get; set; }
        /// <summary>
        /// 当前助潜在分诊派单转化周期
        /// </summary>
        public int PotionelSendCycle { get; set; }
        /// <summary>
        /// 当前助理潜在分诊上门转化周期
        /// </summary>
        public int PotionelToHospitalCycle { get; set; }
        /// <summary>
        /// 当前助理总分诊派单转化周期
        /// </summary>
        public int TotalSendCycle { get; set; }
        /// <summary>
        /// 当前助理总分诊上门转化周期
        /// </summary>
        public int TotalToHospitalCycle { get; set; }
        /// <summary>
        /// 分诊派单转化周期柱状图数据
        /// </summary>
        public List<KeyValuePair<string, int>> SendCycleData { get; set; }
        /// <summary>
        /// 分诊上门转化周期柱状图数据
        /// </summary>
        public List<KeyValuePair<string, int>> ToHospitalCycleData { get; set; }
        /// <summary>
        /// 老客复购率数据
        /// </summary>
        public List<KeyValuePair<string, decimal>> OldCustomerRePurcheData { get; set; }
    }
}
