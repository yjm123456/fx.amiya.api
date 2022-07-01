using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.SendOrderInfo
{
    public class AddSendOrderInfoVo
    {
       /// <summary>
       /// 订单编号
       /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 采购单价
        /// </summary>
        public decimal PurchaseSinglePrice { get; set; }

        /// <summary>
        /// 采购数量
        /// </summary>
        public int PurchaseNum { get; set; }

        /// <summary>
        /// 是否未明确时间
        /// </summary>
        public bool IsUncertainDate { get; set; }

        /// <summary>
        /// 预约到院日期
        /// </summary>
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
