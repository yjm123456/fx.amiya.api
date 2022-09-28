using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Remark
{
    /// <summary>
    /// 优秀机构批注
    /// </summary>
    public class AmiyaRemarkDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 运营指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 优秀机构啊美雅批注
        /// </summary>
        public string AmiyaRemark { get; set; }
    }
}
