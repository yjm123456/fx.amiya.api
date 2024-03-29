﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerAppointmentSchedule.Result
{
    public class CustomerAppointmentScheduleByCalendarVo
    {
        /// <summary>
        /// 日期
        /// </summary>
        public int Date { get; set; }
        public List<CustomerAppointmentScheduleVo> ccstomerAppointmentScheduleDetailsVos { get; set; }
    }
    public class CustomerAppointmentScheduleVo : BaseVo
    {

        /// <summary>
        /// 创建人id
        /// </summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        public string CreateByEmpName { get; set; }
        /// <summary>
        /// 客户昵称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 预约类型
        /// </summary>
        public int AppointmentType { get; set; }
        /// <summary>
        /// 预约类型文本
        /// </summary>
        public string AppointmentTypeText { get; set; }

        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        /// 当日日期
        /// </summary>
        public int Date { get; set; }

        /// <summary>
        /// 当日星期
        /// </summary>
        public DayOfWeek Week { get; set; }

        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsFinish { get; set; }

        /// <summary>
        /// 重要程度
        /// </summary>
        public int ImportantType { get; set; }

        /// <summary>
        /// 重要程度文本
        /// </summary>
        public string ImportantTypeText { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 预约医院id
        /// </summary>
        public int? AppointmentHospitalId { get; set; }
        /// <summary>
        /// 预约医院名称
        /// </summary>
        public string AppointmentHospitalName { get; set; }
        /// <summary>
        /// 接诊咨询
        /// </summary>
        public string Consultation { get; set; }
        /// <summary>
        /// 指派主播id
        /// </summary>
        public string AssignLiveanchorId { get; set; }
        /// <summary>
        /// 指派主播名称
        /// </summary>
        public string AssignLiveanchorName { get; set; }
        /// <summary>
        /// 顾客照片1
        /// </summary>

        public string CustomerPic1 { get; set; }
        /// <summary>
        /// 顾客照片2
        /// </summary>

        public string CustomerPic2 { get; set; }
        /// <summary>
        /// 顾客照片3
        /// </summary>

        public string CustomerPic3 { get; set; }
    }
}
