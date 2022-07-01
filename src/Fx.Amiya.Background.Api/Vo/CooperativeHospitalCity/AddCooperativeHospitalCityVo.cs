using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CooperativeHospitalCity
{
    public class AddCooperativeHospitalCityVo
    {
        /// <summary>
        /// 城市名称
        /// </summary>
        [Required(ErrorMessage ="城市名称不能为空")]
        [StringLength(20,ErrorMessage ="城市名称最多{1}个字符")]
        public string Name { get; set; }
        /// <summary>
        /// 省份id
        /// </summary>
        [Required(ErrorMessage = "省份不能为空")]
        public string ProvinceId { get; set; }

        /// <summary>
        /// 是否热门
        /// </summary>
        public bool IsHot { get; set; }
    }
}
