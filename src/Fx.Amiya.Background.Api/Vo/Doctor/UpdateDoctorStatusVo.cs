using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Doctor
{
    public class UpdateDoctorStatusVo
    {
        public int Id { get; set; }
        /// <summary>
        /// 医生在职状态（0：离职，1:在职）
        /// </summary>
        public int IsLeaveOffice { get; set; }
    }
}
