using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class SendOrderInfo
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int HospitalId { get; set; }
        public decimal PurchaseSinglePrice { get; set; }
        public int PurchaseNum { get; set; }
        public int SendBy { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public byte? TimeType { get; set; }
       
        public bool IsUncertainDate { get; set; }

        public OrderInfo OrderInfo { get; set; }
        public HospitalInfo HospitalInfo { get; set; }
        public AmiyaEmployee AmiyaEmployee { get; set; }
        public List<SendOrderMessageBoard> SendOrderMessageBoardList { get; set; }
    }
}
