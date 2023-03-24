using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AestheticsDesignReport.Input
{
    /// <summary>
    /// 查询美学设计报告
    /// </summary>
    public class QueryAestheticsDesignReportVo:BaseQueryVo
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int? Status { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
        
    }
}
