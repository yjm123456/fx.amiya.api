using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
   public class ContentPlatformOrderSend
    {
        public int Id { get; set; }
        public string ContentPlatformOrderId { get; set; }
        public int HospitalId { get; set; }
        public int Sender { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsUncertainDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string Remark { get; set; }
        public string HospitalRemark { get; set; }
        /// <summary>
        /// 是否是主派医院
        /// </summary>
        public bool IsMainHospital { get; set; }
        /// <summary>
        /// 是否是重单可深度订单
        /// </summary>
        public bool IsRepeatProfundityOrder { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus { get; set; }
        public ContentPlatformOrder ContentPlatformOrder { get; set; }
        public AmiyaEmployee AmiyaEmployee { get; set; }
        public HospitalInfo HospitalInfo { get; set; }
    }
}
