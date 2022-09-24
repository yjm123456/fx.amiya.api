using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.SendOrderInfo
{
    public class SendOrderInfoPerformanceDto
    {
        /// <summary>
        /// 业绩
        /// </summary>
        public decimal? Performance { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
    }
}
