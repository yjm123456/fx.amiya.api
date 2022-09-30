using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.IndicatorSendHospital
{
    public class HospitalReamrkAndSumbitStatusDto
    {
        /// <summary>
        /// 提报状态
        /// </summary>
        public bool SumbitStatus { get; set; }
        /// <summary>
        /// 批注状态
        /// </summary>
        public bool RemarkStatus { get; set; }
    }
}
