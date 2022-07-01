using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalCheckPhoneRecord
{
    public class HospitalCheckPhoneRecordDto
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public int HospitalEmployeeId { get; set; }
        public string HospitalEmployeeName { get; set; }
        public string OrderId { get; set; }
        public DateTime Date { get; set; }
    }
}
