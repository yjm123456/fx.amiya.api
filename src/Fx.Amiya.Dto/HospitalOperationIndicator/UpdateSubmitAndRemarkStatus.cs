using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalOperationIndicator
{
    public class UpdateSubmitAndRemarkStatus
    {
        public string Id { get; set; }
        /// <summary>
        /// 提报状态
        /// </summary>
        public bool SubmitStatus { get; set; }
        /// <summary>
        /// 批注状态
        /// </summary>
        public bool RemarkStatus { get; set; }
    }
}
