using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OperationLog
{
    public class SearchVo
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 访问类型
        /// </summary>
        public int? RequestType { get; set; }
        /// <summary>
        /// code:0:请求成功 1:请求异常
        /// </summary>
        public int? Code { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }
}
