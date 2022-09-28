using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Remark
{
    /// <summary>
    /// 机构成交品项数据分析批注
    /// </summary>
    public class HospitalDealRemarkVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 成交品项批注
        /// </summary>
        public string HospitalDealRemark { get; set; }
        /// <summary>
        /// 啊美雅成交品项批注
        /// </summary>
        public string AmiyaDealRemark { get; set; }
    }
}
