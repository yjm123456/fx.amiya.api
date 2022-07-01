using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Doctor
{
    public class AddDoctorVo
    {
        /// <summary>
        /// 医生姓名
        /// </summary>
       [Required(ErrorMessage ="医生名称不能为空")]
       [StringLength(50,ErrorMessage="医生姓名做多{1}个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 图片url
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [Required(ErrorMessage = "医生职位不能为空")]
        [StringLength(100, ErrorMessage = "医生职位做多{1}个字符")]
        public string Position { get; set; }

        /// <summary>
        /// 从业年份
        /// </summary>
        public int ObtainEmploymentYear { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 归属科室
        /// </summary>
        public string DepartmentId { get; set; }
        /// <summary>
        /// 是否主推
        /// </summary>
        public int IsMain { get; set; }
        /// <summary>
        /// 主推项目案例图
        /// </summary>
        public string ProjectPicture { get; set; }
    }
}
