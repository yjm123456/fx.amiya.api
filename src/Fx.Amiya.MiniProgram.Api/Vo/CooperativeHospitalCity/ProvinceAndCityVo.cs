using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.CooperativeHospitalCity
{
    public class ProvinceAndCityVo
    {
        /// <summary>
        /// 省份id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 所属城市
        /// </summary>
        public List<CooperativeHospitalCityVo> City { get; set; }
    }
}
