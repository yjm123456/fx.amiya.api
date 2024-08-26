using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class QueryAssistantPerformanceFilterDataDto
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
        /// 有效/潜在(null全部)
        /// </summary>
        public bool? IsEffectiveCustomerData { get; set; }

    }
}
