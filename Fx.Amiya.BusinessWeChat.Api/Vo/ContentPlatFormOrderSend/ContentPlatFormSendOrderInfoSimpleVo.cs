using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlatFormOrderSend
{
    /// <summary>
    /// 派单基础信息
    /// </summary>
    public class ContentPlatFormSendOrderInfoSimpleVo
    {
        /// <summary>
        /// 派单编号
        /// </summary>
        public int Id { get; set; }

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
        /// 是否主派
        /// </summary>
        public bool IsMainHospital { get; set; }
    }
}
