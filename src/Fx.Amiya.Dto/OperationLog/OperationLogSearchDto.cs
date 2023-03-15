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
