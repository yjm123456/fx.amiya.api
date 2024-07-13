using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlatFormOrderSend
{
    public class UpdateContentPlatFormSendOrderInfoDto
    {
        public int Id { get; set; }

        public string OrderId { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 是否未明确时间
        /// </summary>
        public bool IsUncertainDate { get; set; }

        /// <summary>
        /// 预约到院日期
        /// </summary>
        public DateTime? AppointmentDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 次派医院
        /// </summary>
        public List<int> OtherHospitalId { get; set; }
        /// <summary>
        /// 派单人
        /// </summary>
        public int SendBy { get; set; }
    }
}
