using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Performance
{
    public class PeformanceBrokenLineListInfoDto
    {
        /// <summary>
        /// 日期（可以是年也可以是月）例：年输出1-12，月输出1-31
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 业绩金额
        /// </summary>
        public decimal? Performance { get; set; }
    }
}
