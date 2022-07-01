using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Doctor
{
   public class AddDoctorDto
    {
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public string Position { get; set; }
        public int ObtainEmploymentYear { get; set; }
        public string Description { get; set; }
        public int HospitalId { get; set; }
        /// <summary>
        /// 归属科室
        /// </summary>
        public string DepartmentId { get; set; }
        /// <summary>
        /// 是否主推
        /// </summary>
        public int IsMain { get; set; }
        public string ProjectPicture { get; set; }
    }
}
