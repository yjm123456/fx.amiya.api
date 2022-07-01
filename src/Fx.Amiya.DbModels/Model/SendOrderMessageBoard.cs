using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class SendOrderMessageBoard
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public byte Type { get; set; }
        public int SendOrderInfoId { get; set; }
        public int HospitalId { get; set; }
        public int? AmiyaEmployeeId{get;set;}
        public int? HospitalEmployeeId{get;set;}
        public string Content { get; set; }

        public SendOrderInfo SendOrderInfo { get; set; }
        public HospitalInfo HospitalInfo { get; set; }
        public AmiyaEmployee AmiyaEmployee { get; set; }
        public HospitalEmployee HospitalEmployee { get; set; }
        
    }
}
