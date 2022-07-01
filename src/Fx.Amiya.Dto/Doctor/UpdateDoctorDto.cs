using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Doctor
{
  public  class UpdateDoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public string Position { get; set; }
        public int ObtainEmploymentYear { get; set; }
        public string Description { get; set; }
        public int HospitalId { get; set; }
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
    }
}
