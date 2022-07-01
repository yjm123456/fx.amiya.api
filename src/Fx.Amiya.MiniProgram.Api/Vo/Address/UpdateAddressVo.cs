using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Address
{
    public class UpdateAddressVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        [Required(ErrorMessage = "省份不能为空")]
        public string Province { get; set; }

        /// <summary>
        /// 省份编码
        /// </summary>
        [Required(ErrorMessage = "省份编码不能为空")]
        public string ProvinceCode { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [Required(ErrorMessage = "城市不能为空")]
        public string City { get; set; }

        /// <summary>
        /// 城市编码
        /// </summary>
        [Required(ErrorMessage = "城市编码不能为空")]
        public string CityCode { get; set; }

        /// <summary>
        /// 区/县
        /// </summary>
        [Required(ErrorMessage = "区/县不能为空")]
        public string District { get; set; }

        /// <summary>
        /// 区/县编码
        /// </summary>
        [Required(ErrorMessage = "区/县编码不能为空")]
        public string DistrictCode { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [Required(ErrorMessage = "详细地址不能为空")]
        public string Other { get; set; }

        /// <summary>
        /// 收货人姓名
        /// </summary>
        [Required(ErrorMessage = "收货人姓名不能为空")]
        public string Contact { get; set; }

        /// <summary>
        /// 收货人电话
        /// </summary>
        [Required(ErrorMessage = "收货人电话不能为空")]
        public string Phone { get; set; }

        /// <summary>
        /// 是否设置为默认地址
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
