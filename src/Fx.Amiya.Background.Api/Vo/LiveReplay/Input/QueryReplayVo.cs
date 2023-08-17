using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveReplay.Input
{
    public class QueryReplayVo:BaseQueryVo
    {
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool? Valid { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Date { get; set; }
    }
}
