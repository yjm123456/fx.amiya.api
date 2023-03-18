using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OperationLog
{
    public class OperationLogSearchDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string RouteAddress { get; set; }
        /// <summary>
        /// 请求参数
        /// </summary>
        public string Parameters { get; set; }
        /// <summary>
        /// 访问类型
        /// </summary>
        public int? RequestType { get; set; }
        /// <summary>
        /// code:0:请求成功 -1:请求异常
        /// </summary>
        public int? Code { get; set; }
        /// <summary>
        /// 操作来源
        /// </summary>
        public int? Source { get; set; }
        public int PageNum { get; set; }
        public int PageSize { get; set; }
       
    }
}
