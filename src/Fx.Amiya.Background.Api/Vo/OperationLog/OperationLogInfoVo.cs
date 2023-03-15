using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OperationLog
{
    public class OperationLogInfoVo
    {
        /// <summary>
        /// 请求路由
        /// </summary>
        public string RouteAddress { get; set; }
        /// <summary>
        /// 接口访问类型
        /// </summary>
        public string RequestTypeText { get; set; }
        /// <summary>
        /// 返回code
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 请求参数
        /// </summary>
        public string Parameters { get; set; }
        /// <summary>
        /// 返回说明
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string OperaterName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
