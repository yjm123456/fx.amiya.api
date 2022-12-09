using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public string ProjectPicture { get; set; }
        public string Position { get; set; }
        public int ObtainEmploymentYear { get; set; }
        public string Description { get; set; }
        public int HospitalId { get; set; }

        public int IsMain { get; set; }

        public string DepartmentId { get; set; }
        /// <summary>
        /// 是否离职
        /// </summary>
        public int IsLeaveOffice { get; set; }

        public HospitalInfo HospitalInfo { get; set; }
    }
}
