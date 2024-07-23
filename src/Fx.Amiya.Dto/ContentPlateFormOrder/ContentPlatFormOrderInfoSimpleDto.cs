using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlateFormOrder
{
    public class ContentPlatFormOrderInfoSimpleDto
    {
        public string Id { get; set; }
        public string OrderTypeText { get; set; }
        public string ContentPlatformName { get; set; }
        public DateTime CreateDate { get; set; }
        public string LiveAnchorBaseId { get; set; }
        public string LiveAnchorName { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentHospitalName { get; set; }
        public string GoodsName { get; set; }
        /// <summary>
        /// 主派咨询内容
        /// </summary>
        public string ConsultingContent { get; set; }
        /// <summary>
        /// 次派咨询内容
        /// </summary>
        public string ConsultingContent2 { get; set; }
        public int OrderStatus { get; set; }
        public string OrderStatusText { get; set; }
        public decimal? DepositAmount { get; set; }
        public decimal? DealAmount { get; set; }
        /// <summary>
        /// 医院科室id
        /// </summary>
        public string HospitalDepartmentId { get; set; }
        public string UnDealReason { get; set; }
        public string LateProjectStage { get; set; }
        public string Remark { get; set; }
    }
}
