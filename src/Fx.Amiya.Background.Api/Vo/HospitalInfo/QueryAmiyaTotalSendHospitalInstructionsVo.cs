using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalInfo
{
    /// <summary>
    /// 啊美雅全国供应链派单指南查询类
    /// </summary>
    public class QueryAmiyaTotalSendHospitalInstructionsVo
    {
        /// <summary>
        /// 城市id
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
    }
}
