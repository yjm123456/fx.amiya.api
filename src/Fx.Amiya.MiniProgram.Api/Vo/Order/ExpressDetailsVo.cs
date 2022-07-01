using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Order
{
    /// <summary>
    /// 物流信息
    /// </summary>
    public class ExpressDetailsVo
    {
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime time { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }
    }
}
