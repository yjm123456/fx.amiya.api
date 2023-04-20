using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Appointment
{
    /// <summary>
    /// 预约信息
    /// </summary>
    public class WxAppointmentInfoVo
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
        /// 上午/下午
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 状态 1=待完成，2=已完成，3=已取消
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime SubmitDate { get; set; }

        /// <summary>
        /// 预约手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>

        public string ItemInfoName { get; set; }
        /// <summary>
        /// 项目图片地址
        /// </summary>
        public string ItemInfopicUrl { get; set; }

        public AppointmentHospitalVo HospitalInfo { get; set; }
        /// <summary>
        /// 预约地址
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
