using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.SendOrderInfo
{
  public  class AddSendOrderMessageBoardDto
    {
        /// <summary>
        /// 0=阿美雅，1=医院
        /// </summary>
        public byte Type { get; set; }
        public int SendOrderInfoId { get; set; }
        public int HospitalId { get; set; }
        public int? AmiyaEmployeeId { get; set; }
        public int? HospitalEmployeeId { get; set; }
        public string Content { get; set; }
    }
}
