using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Appointment
{
    /// <summary>
    /// 修改预约信息
    /// </summary>
    public class UpdateAppointmentInfoVo
    {
        /// <summary>
        /// 预约编号
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// 预约日期
        /// </summary>
        [Required]
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        /// 星期
        /// </summary>
        [Required]
        public string Week { get; set; }

        /// <summary>
        /// 时间（上午/下午）
        /// </summary>
        [Required]
        public string Time { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]
        public string ItemName { get; set; }


        /// <summary>
        /// 预约电话
        /// </summary>
        [Required]
        public string Phone { get; set; }

    }
}
