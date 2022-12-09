using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Doctor
{
    public class UpdateDoctorSatusDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 是否离职（0：在职，1：在职）
        /// </summary>
        public int IsLeaveOffice { get; set; }
    }
}
