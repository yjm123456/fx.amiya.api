using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Appointment
{

    /// <summary>
    /// 派单到医院输入类
    /// </summary>
    public class SendToHospitalVo
    {
        /// <summary>
        /// 预约编号
        /// </summary>
        [Required]
        public int id { get; set; }
        /// <summary>
        /// 医院编号
        /// </summary>
        [Required]
        public int hospitalId { get; set; }
    }
}
