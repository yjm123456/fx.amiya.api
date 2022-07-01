using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.SendOrderInfo
{
   public class SendOrderMessageBoardDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public byte Type { get; set; }
        public string TypeName { get; set; }
        public int SendOrderInfoId { get; set; }
        public int? AmiyaEmployeeId { get; set; }
        public string AmiyaEmployeeName { get; set; }
        public int? HospitalEmployeeId { get; set; }
        public string HospitalEmployeeName { get; set; }
        public int HospitalId { get; set; }
        public string HospitalLogo { get; set; }
        public string Content { get; set; }
    }
}
