using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Address
{
    public class AddressVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 省份编码
        /// </summary>
        public string ProvinceCode { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 城市编码
        /// </summary>
        public string CityCode { get; set; }
        /// <summary>
        /// 区/县
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// 区/县编码
        /// </summary>
        public string DistrictCode { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Other { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 收货人电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 是否默认地址
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
