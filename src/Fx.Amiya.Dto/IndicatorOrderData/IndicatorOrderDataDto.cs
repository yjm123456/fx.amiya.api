using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.IndicatorOrderData
{
    public class IndicatorOrderDataDto
    {
        public string IndicatorId { get; set; }
        public int HospitalId { get; set; }
        /// <summary>
        /// 总派单数
        /// </summary>
        public int AllSendorderCount { get; set; }
        /// <summary>
        /// 本地派单数
        /// </summary>
        public int LocalSendorderCount { get; set; }
        /// <summary>
        /// 外地派单数
        /// </summary>
        public int OtherPlaceSendorderCount { get; set; }
        /// <summary>
        /// 无效派单数
        /// </summary>
        public int InvalidSendorderCount { get; set; }
        /// <summary>
        /// 疫情影响
        /// </summary>
        public int EpidemicCount { get; set; }
        //其他问题
        public string OtherQuestion { get; set; }
    }
}
