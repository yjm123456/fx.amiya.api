using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CooperativeHospitalCity
{
    public class CooperativeHospitalCityVo
    {
        public int Id { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }
        /// <summary>
        /// 省份id
        /// </summary>
        public string ProvinceId { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 是否热门
        /// </summary>
        public bool IsHot { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
