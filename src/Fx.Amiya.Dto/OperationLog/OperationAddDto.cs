using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OperationLog
{
    public class OperationAddDto
    {
        /// <summary>
        /// 请求路由
        /// </summary>
        public string RouteAddress { get; set; }
        /// <summary>
        /// 接口访问类型
        /// </summary>
        public int RequestType { get; set; }
        /// <summary>
        /// 请求参数
        /// </summary>
        public string Parameters { get; set; }
        /// <summary>
        /// 返回code()
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 返回说明
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public int OperationBy { get; set; }
        /// <summary>
        /// 操作来源
        /// </summary>
        public int Source { get; set; }
    }
}
