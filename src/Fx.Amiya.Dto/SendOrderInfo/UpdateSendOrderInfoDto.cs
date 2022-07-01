using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.SendOrderInfo
{
   public class UpdateSendOrderInfoDto
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        /// <summary>
        /// 是否未明确时间
        /// </summary>
        public bool IsUncertainDate { get; set; }

        /// <summary>
        /// 采购单价
        /// </summary>
        public decimal PurchaseSinglePrice { get; set; }

        /// <summary>
        /// 采购数量
        /// </summary>
        public int PurchaseNum { get; set; }
        public DateTime? AppointmentDate { get; set; }

        /// <summary>
        /// 1=上午，2=下午
        /// </summary>
        public byte? TimeType { get; set; }

        /// <summary>
        /// 留言内容
        /// </summary>
        public string Content { get; set; }

    }
}
