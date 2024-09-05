﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlateFormOrder
{
    public class ContentPlatformOrderSendOrderInfoDto
    {
        public int Id { get; set; }
        public string ContentPlatFormOrderId { get; set; }
        public int HospitalId { get; set; }
        public int Sender { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsUnCertainDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string Remark { get; set; }
        /// <summary>
        /// 是否指定医院账户
        /// </summary>
        public bool IsSpecifyHospitalEmployee { get; set; }

        /// <summary>
        /// 医院账户id
        /// </summary>
        public int HospitalEmployeeId { get; set; }
    }
}
