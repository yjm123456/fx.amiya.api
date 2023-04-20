using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Appointment
{
    public class AddAppointmentVo
    {
        /// <summary>
        /// 预约日期
        /// </summary>
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        /// 星期
        /// </summary>
       [StringLength(10,ErrorMessage ="星期最大长度10个字符")]
        public string Week { get; set; }

        /// <summary>
        /// 上午/下午
        /// </summary>
        [Required(ErrorMessage ="时间（上午/下午）不能为空")]
        public string Time { get; set; }


        /// <summary>
        /// 预约手机号
        /// </summary>
        [Required(ErrorMessage = "手机号不能为空")]
        public string Phone { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        [Required(ErrorMessage ="客户姓名不能为空")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(20,ErrorMessage ="备注最多20个字符")]
        public string Remark { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 预约地区
        /// </summary>
        public string AppointArea { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemInfoName{ get; set; }
        /// <summary>
        /// 预约叫车地址
        /// </summary>
        public string Address { get; set; }
    }
}
