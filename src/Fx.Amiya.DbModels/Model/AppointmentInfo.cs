using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class AppointmentInfo
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Week { get; set; }
        public string Time { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime SubmitDate { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Remark { get; set; }
        public byte Status { get; set; }
        public int HospitalId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemInfoName { get; set; }

        public CustomerInfo CustomerInfo { get; set; }
        public HospitalInfo HospitalInfo { get; set; }
    }
}
