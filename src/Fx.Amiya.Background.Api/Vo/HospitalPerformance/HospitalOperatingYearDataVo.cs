using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalPerformance
{
    /// <summary>
    /// 全国机构运营数据
    /// </summary>
    public class HospitalOperatingYearDataVo
    {
        /// <summary>
        /// 前十机构运营数据（11条数据10条+1条总计）
        /// </summary>
        public List<HospitalOperatingDataVo> TopTenHospitalOperatingDataVo { get; set; }
        /// <summary>
        /// 其他机构运营数据
        /// </summary>
        public List<HospitalOperatingDataVo> OtherHospitalOperatingDataVo { get; set; }

        /// <summary>
        /// 统计数据(一条数据)
        /// </summary>
        public HospitalOperatingDataVo TotalSum { get; set; }
    }
}
