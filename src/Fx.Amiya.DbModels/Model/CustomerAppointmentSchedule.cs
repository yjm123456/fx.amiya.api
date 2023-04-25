﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class CustomerAppointmentSchedule : BaseDbModel
    {
        /// <summary>
        /// 创建人id
        /// </summary>
        public int CreateBy { get; set; }
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
        /// 预约时间
        /// </summary>
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsFinish { get; set; }

        /// <summary>
        /// 重要程度
        /// </summary>
        public int ImportantType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 预约医院
        /// </summary>
        public int? AppointmentHospitalId { get; set; }
        /// <summary>
        /// 接诊咨询
        /// </summary>
        public string Consultation { get; set; }

        public AmiyaEmployee AmiyaEmployeeInfo { get; set; }
    }
}
