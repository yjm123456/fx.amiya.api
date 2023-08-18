using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveReplay.Input
{
    public class QueryReplayDto:BaseQueryDto
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
