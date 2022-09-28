using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Remark
{
    /// <summary>
    /// 添加优秀机构啊
    /// </summary>
    public class UpdateAmiyaRemarkDto
    {
        /// <summary>
        /// 机构运营指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 批注
        /// </summary>
        public string Remark { get; set; }
    }
}
