using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Doctor
{
   public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }
        public int ObtainEmploymentYear { get; set; }
        public string Description { get; set; }
        public int HospitalId { get; set; }
        public string HosptalName { get; set; }
        public int IsMain { get; set; }
        public string ProjectPicture { get; set; }
    }
}

