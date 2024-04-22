using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService
{
    public class QueryAmiyaAssistantOperationsDataDto
    {
        /// <summary>
        /// 单位(0:万,1:元)
        /// </summary>
        public int Unit { get; set; }
        /// <summary>
        /// 开始时间(开始时间结束时间都为null时查询当日数据)
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }
        public bool? IsOldCustomer { get; set; }
        /// <summary>
        /// 主播账号集合
        /// </summary>
        public List<string> LiveAnchorIds { get; set; }
        /// <summary>
        /// 有效/潜在 true:有效,false:潜在 null:全部
        /// </summary>
        public bool? IsEffective { get; set; }
    }
}
