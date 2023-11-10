using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.SendOrderInfo
{
    public class SendOrderInfoSimpleDto
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }

        public decimal PurchaseSiglePrice { get; set; }
        public int PurchaseNum { get; set; }
        /// <summary>
        /// 是否未明确时间
        /// </summary>
        public bool IsUncertainDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string Time { get; set; }

        /// <summary>
        /// 1=上午，2=下午
        /// </summary>
        public byte? TimeType { get; set; }
        public string GoodsId { get; set; }
        public string GoodsName { get; set; }

        /// <summary>
        /// 平台类型
        /// </summary>
        public byte AppType { get; set; }

        /// <summary>
        /// 平台类型名称
        /// </summary>
        public string AppTypeText { get; set; }
        public bool IsMainHospital { get; set; }

    }
}
