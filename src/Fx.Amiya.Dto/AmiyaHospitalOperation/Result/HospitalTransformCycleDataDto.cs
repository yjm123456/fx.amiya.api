using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaHospitalOperation.Result
{
    public class HospitalTransformCycleDataDto
    {
        /// <summary>
        /// 派单上门转化周期柱状图数据
        /// </summary>
        public List<KeyValuePair<string, int>> ToHospitalCycleData { get; set; }
        /// <summary>
        /// 老客复购率数据
        /// </summary>
        public List<KeyValuePair<string, decimal>> OldCustomerRePurcheData { get; set; }
    }
}
