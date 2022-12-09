using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Doctor
{
    public class UpdateDoctorVo
    {
        /// <summary>
        /// 医生编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 医生姓名
        /// </summary>
        [Required(ErrorMessage = "医生名称不能为空")]
        public string Name { get; set; }

      /// <summary>
      /// 图片url
      /// </summary>
        public string PicUrl { get; set; }


        /// <summary>
        /// 职位
        /// </summary>
        [Required(ErrorMessage = "医生职位不能为空")]
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
        /// 归属科室id
        /// </summary>
        public string DepartmentId { get; set; }
        /// <summary>
        /// 是否主推，1为主推
        /// </summary>
        public int IsMain { get; set; }
        /// <summary>
        /// 主推项目案例图
        /// </summary>
        public string ProjectPicture { get; set; }
        /// <summary>
        /// 是否离职（0：离职，1：在职）
        /// </summary>
        public int IsLeaveOffice { get; set; }

    }
}
