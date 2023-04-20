using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Appointment
{
    public class AppointmentInfoVo
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
        /// 预约状态
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// 预约状态文本
        /// </summary>
        public string StatusText { get; set; }



        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }


        /// <summary>
        /// 预约电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 电话加密文本
        /// </summary>
        public string EncryptPhone { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

       /// <summary>
       /// 提交时间
       /// </summary>
        public DateTime SubmitDate { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 预约地区
        /// </summary>
        public string AppointArea { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 客服名称
        /// </summary>
        public string EmpolyeeName { get; set; }
        /// <summary>
        /// 叫车地址
        /// </summary>
        public string Address { get; set; }
    }
}
