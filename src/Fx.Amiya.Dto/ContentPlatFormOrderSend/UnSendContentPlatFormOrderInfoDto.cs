using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlatFormOrderSend
{
    /// <summary>
    /// 未派单内容平台订单列表
    /// </summary>
    public class UnSendContentPlatFormOrderInfoDto
    {
        public string OrderId { get; set; }
        public string ContentPlatFormName { get; set; }
        public string LiveAnchorName { get; set; }
        public DateTime CreateDate { get; set; }
        public string GoodsName { get; set; }
        public string ThumbPictureUrl { get; set; }
        /// <summary>
        /// 主派咨询内容
        /// </summary>
        public string ConsultingContent { get; set; }
        /// <summary>
        /// /次派咨询内容
        /// </summary>
        public string ConsultingContent2 { get; set; }
        public string CustomerName { get; set; }
        public decimal? DepositAmount { get; set; }
        public decimal? DealAmount { get; set; }
        public string OrderTypeText{ get; set; }
        public string OrderStatusText { get; set; }
        public string AppointmentHospital { get; set; }
        public string AppointmentDate { get; set; }
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }
        public string Remark { get; set; }

        /// <summary>
        /// 面诊状态
        /// </summary>
        public int ConsultationType { get; set; }
        /// <summary>
        /// 面诊状态文本
        /// </summary>
        public string ConsultationTypeText { get; set; }
        /// <summary>
        /// 后期项目铺垫
        /// </summary>
        public string LateProjectStage { get; set; }
        public int BelongEmpId { get; set; }
        public string BelongEmpName { get; set; }

        /// <summary>
        /// 订单来源文本
        /// </summary>

        public string OrderSourceText { get; set; }

        /// <summary>
        /// 未派单原因
        /// </summary>
        public string UnSendReason { get; set; }
    }
}
