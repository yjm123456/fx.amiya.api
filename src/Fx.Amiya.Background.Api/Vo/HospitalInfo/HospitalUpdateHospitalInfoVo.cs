using Fx.Amiya.Background.Api.Vo.HospitalEnvironmentPicture;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalInfo
{
    public class HospitalUpdateHospitalInfoVo
    {
        /// <summary>
        /// 医院名称
        /// </summary>
        [Required(ErrorMessage = "医院名称不能为空")]
        [StringLength(100, ErrorMessage = "医院名称最多{1}个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 医院图标
        /// </summary>
        [Required(ErrorMessage = "医院图标不能为空")]
        [StringLength(500, ErrorMessage = "医院名称最多{1}个字符")]
        public string ThumbPicUrl { get; set; }


        /// <summary>
        /// 地址
        /// </summary>
        [Required(ErrorMessage = "地址不能为空")]
        [StringLength(200, ErrorMessage = "地址最多{1}个字符")]
        public string Address { get; set; }

        /// <summary>
        /// 医院成立时间
        /// </summary>
        public DateTime? HospitalCreateDate { get; set; }
        /// <summary>
        /// 医院规模等标签编号数组
        /// </summary>
        public int[] TagIds { get; set; }

        /// <summary>
        /// 行业荣誉
        /// </summary>
        public string IndustryHonors { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public decimal Area { get; set; }
        /// <summary>
        /// 咨询热线
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 当地知名度
        /// </summary>
        public string ProfileRank { get; set; }

        /// <summary>
        /// 医院简介
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 简介详情
        /// </summary>

        public string DescriptionPicture { get; set; }
        /// <summary>
        /// 医院环境图片
        /// </summary>
        public List<HospitalEnvironmentPictureVo> HospitalEnvironmentPicture { get; set; }
    }
}
