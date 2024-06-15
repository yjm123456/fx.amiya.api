using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Input
{
    /// <summary>
    /// 运营看板查询情况
    /// </summary>
    public class QueryOperationDataVo
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? startDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        public string keyWord { get; set; }
    }
}
