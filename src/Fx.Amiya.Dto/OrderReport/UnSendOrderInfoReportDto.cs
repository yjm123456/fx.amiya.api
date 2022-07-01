using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.OrderReport
{
  public  class UnSendOrderInfoReportDto
    {

        public string OrderId { get; set; }
        public string GoodsName { get; set; }
        public string EncryptPhone { get; set; }
        public string AppointmentHospital { get; set; }
        public decimal? ActualPayment { get; set; }

        public string ThumbPicUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public string StatusText { get; set; }

        /// <summary>
        /// 平台类型名称
        /// </summary>
        public string AppTypeText { get; set; }

        public int? BelongEmpId { get; set; }

        /// <summary>
        /// 绑定客服
        /// </summary>
        public string BindCustomerServiceName { get; set; }
    }
}
