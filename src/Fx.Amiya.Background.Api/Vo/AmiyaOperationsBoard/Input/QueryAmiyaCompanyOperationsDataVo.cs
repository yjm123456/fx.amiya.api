using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Input
{
    public class QueryAmiyaCompanyOperationsDataVo
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
        /// <summary>
        /// 主播账号集合
        /// </summary>
        public List<string> LiveAnchorIds { get; set; }
        /// <summary>
        /// 是否是新/老客(true:老客,false:新客,传null不筛选)
        /// </summary>
        public bool? IsOldCustomer { get; set; }
    }
}
