using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Input
{
    public class QueryToHospiatlByAssistantAndHospitalIdListDto
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 助理id
        /// </summary>
        public int AssistantId { get; set; }
        /// <summary>
        /// 医院id集合
        /// </summary>
        public List<int>  HospitalIdList { get; set; }
    }
}
