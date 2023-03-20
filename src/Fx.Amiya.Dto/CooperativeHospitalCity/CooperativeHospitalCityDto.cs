using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.CooperativeHospitalCity
{
    public class CooperativeHospitalCityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
