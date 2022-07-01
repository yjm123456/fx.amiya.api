using Fx.Amiya.Dto.HospitalEnvironmentPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalInfo
{
    public class HospitalUpdateHospitalInfoDto
    {

        /// <summary>
        /// 医院编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 医院图标
        /// </summary>
        public string ThumbPicUrl { get; set; }


        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public decimal Area { get; set; }

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
        /// 当地知名度
        /// </summary>
        public string ProfileRank { get; set; }
        public string Phone { get; set; }

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
        public List<HospitalEnvironmentPictureEditDto> HospitalEnvironmentPicture { get; set; }
    }
}
