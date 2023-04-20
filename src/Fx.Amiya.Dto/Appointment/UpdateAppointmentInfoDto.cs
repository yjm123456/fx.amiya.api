using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Appointment
{
    public class UpdateAppointmentInfoDto
    {
        /// <summary>
        /// 预约编号
        /// </summary>
       
        public int Id { get; set; }

        /// <summary>
        /// 预约日期
        /// </summary>
       
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        /// 星期
        /// </summary>
       
        public string Week { get; set; }

        /// <summary>
        /// 时间（上午/下午）
        /// </summary>
       
        public string Time { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
       
        public string ItemName { get; set; }


        /// <summary>
        /// 预约电话
        /// </summary>
       
        public string Phone { get; set; }
        /// <summary>
        /// 预约地区
        /// </summary>
        public string AppointArea { get; set; }
        /// <summary>
        /// 预约叫车地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 预约医院id
        /// </summary>
        public int HospitalId { get; set; }
    }
}
