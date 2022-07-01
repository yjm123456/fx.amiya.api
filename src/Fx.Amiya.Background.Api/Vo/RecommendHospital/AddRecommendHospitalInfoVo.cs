using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.RecommendHospital
{
    public class AddRecommendHospitalInfoVo
    {
        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        ///排列序号
        /// </summary>
        public int RecommendIndex { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
