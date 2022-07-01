using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
  public  class HospitalCheckPhoneRecord
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public int HospitalEmployeeId { get; set; }

        /// <summary>
        /// 订单平台类型：0=购物平台订单，1=内容平台订单
        /// </summary>
        public byte OrderPlatformType { get; set; }
        public string OrderId { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }

        public HospitalInfo HospitalInfo { get; set; }
        public HospitalEmployee HospitalEmployee { get; set; }
    }
}
