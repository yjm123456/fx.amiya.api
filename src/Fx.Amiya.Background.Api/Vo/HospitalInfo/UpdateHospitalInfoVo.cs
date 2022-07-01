using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalInfo
{
    public class UpdateHospitalInfoVo
    {
        /// <summary>
        /// 医院编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        [Required(ErrorMessage = "医院名称不能为空")]
        [StringLength(100, ErrorMessage = "医院名称最多{1}个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        [Required(ErrorMessage = "图片不能为空")]
        [StringLength(500, ErrorMessage = "医院名称最多{1}个字符")]
        public string ThumbPicUrl { get; set; }


        /// <summary>
        /// 地址
        /// </summary>
        [Required(ErrorMessage = "地址不能为空")]
        [StringLength(200, ErrorMessage = "地址最多{1}个字符")]
        public string Address { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// 医院电话
        /// </summary>
        [StringLength(20, ErrorMessage = "电话最多{1}个字符")]
        public string Phone { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }

        public int? CityId { get; set; }

        /// <summary>
        /// 营业时间
        /// </summary>
        public string BusinessHours { get; set; }
        /// <summary>
        /// 标签编号数组
        /// </summary>
        public int[] TagIds { get; set; }
        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime? DueTime { get; set; }
        /// <summary>
        /// 合同地址
        /// </summary>
        public string ContractUrl { get; set; }
    }
}
