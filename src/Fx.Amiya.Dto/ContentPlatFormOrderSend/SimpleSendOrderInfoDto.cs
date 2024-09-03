using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlatFormOrderSend
{
     public class SimpleSendOrderInfoDto
    {
        public int Id { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

       

        /// <summary>
        /// 预约到院日期
        /// </summary>
        public DateTime? AppointmentDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        public string HospitalRemark { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatus { get; set; }

        /// <summary>
        /// 派单人
        /// </summary>
        public int SendBy { get; set; }
        /// <summary>
        /// 派单人姓名
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// 派单时间
        /// </summary>
        public DateTime? SendDate { get; set; }
        /// <summary>
        /// 是否主派
        /// </summary>
        public bool IsMainHospital { get; set; }
    }
}
