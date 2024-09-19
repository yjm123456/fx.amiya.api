using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Input
{
    public class QueryAssistantHospitalCluesDataDto
    {
        /// <summary>
        /// 开始时间(开始时间结束时间都为null时查询当日数据)
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 助理id
        /// </summary>
        public int? AssistantId { get; set; }
        /// <summary>
        /// 当月
        /// </summary>
        public bool CurrentMonth { get; set; }
        /// <summary>
        /// 历史
        /// </summary>
        public bool History { get; set; }
    }
}
