using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Input
{
    public class QueryBeforeLiveDataVo
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
        public int? AssistantId { get; set; }
    }
    public class QueryBeforeLiveBrokenDataVo : QueryBeforeLiveDataVo
    {
        /// <summary>
        /// 部门
        /// </summary>
        public bool Department { get; set; }
        /// <summary>
        /// 个人
        /// </summary>
        public bool Employee { get; set; }
    }
    public class QueryBeforeLiveFilterDataVo : QueryBeforeLiveDataVo
    {
        /// <summary>
        /// 当月
        /// </summary>
        public bool Current { get; set; }
        /// <summary>
        /// 历史
        /// </summary>
        public bool History { get; set; }
    }
}
