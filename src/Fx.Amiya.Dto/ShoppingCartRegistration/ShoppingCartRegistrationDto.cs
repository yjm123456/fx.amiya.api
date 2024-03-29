﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ShoppingCartRegistration
{
    public class ShoppingCartRegistrationDto
    {
        public string Id { get; set; }

        public DateTime RecordDate { get; set; }
        public string ContentPlatFormId { get; set; }
        public string ContentPlatFormName { get; set; }
        public int LiveAnchorId { get; set; }
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 主播微信号id
        /// </summary>
        public string LiveAnchorWeChatId { get; set; }
        public string LiveAnchorWechatNo { get; set; }
        public string CustomerNickName { get; set; }
        public string Phone { get; set; }
        public string SubPhone { get; set; }
        public decimal Price { get; set; }
        public int ConsultationType { get; set; }
        public string ConsultationTypeText { get; set; }
        public bool IsAddWeChat { get; set; }
        public bool IsWriteOff { get; set; }
        public bool IsConsultation { get; set; }
        public DateTime? ConsultationDate { get; set; }
        public bool IsReturnBackPrice { get; set; }
        public string Remark { get; set; }
        public int CreateBy { get; set; }
        public string CreateByName { get; set; }
        public int? AssignEmpId { get; set; }
        public string AssignEmpName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? RefundDate { get; set; }
        public string RefundReason { get; set; }
        public DateTime? BadReviewDate { get; set; }
        public string BadReviewReason { get; set; }
        public string BadReviewContent { get; set; }
        public bool IsReContent { get; set; }
        public string ReContent { get; set; }
        public bool IsBadReview { get; set; }

        public bool IsCreateOrder { get; set; }
        /// <summary>
        /// 派单触达
        /// </summary>
        public bool IsSendOrder { get; set; }
        /// <summary>
        /// 紧急程度
        /// </summary>
        public int EmergencyLevel { get; set; }
        public string EmergencyLevelText { get; set; }
        /// <summary>
        /// 抖音客户来源
        /// </summary>
        public int? Source { get; set; }
        /// <summary>
        /// 抖音客户来源文本
        /// </summary>
        public string SourceText { get; set; }
        /// <summary>
        /// 基础主播信息id
        /// </summary>
        public string BaseLiveAnchorId { get; set; }
        /// <summary>
        /// 基础主播名称
        /// </summary>
        public string BaseLiveAnchorName { get; set; }
       
    }
}
