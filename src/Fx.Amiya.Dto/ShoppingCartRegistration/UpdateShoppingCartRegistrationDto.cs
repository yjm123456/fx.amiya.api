﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ShoppingCartRegistration
{
    public class UpdateShoppingCartRegistrationDto
    {
        public string Id { get; set; }

        public DateTime RecordDate { get; set; }
        public string ContentPlatFormId { get; set; }
        public int LiveAnchorId { get; set; }
        public string LiveAnchorWechatNo { get; set; }
        public string CustomerNickName { get; set; }
        public string Phone { get; set; }
        public string SubPhone { get; set; }
        public decimal Price { get; set; }
        public int ConsultationType { get; set; }
        public bool IsAddWeChat { get; set; }
        public bool IsWriteOff { get; set; }
        public bool IsConsultation { get; set; }
        public DateTime? ConsultationDate { get; set; }
        public bool IsReturnBackPrice { get; set; }
        public string Remark { get; set; }
        public DateTime? RefundDate { get; set; }

        public bool IsCreateOrder { get; set; }
        /// <summary>
        /// 派单触达
        /// </summary>
        public bool IsSendOrder { get; set; }
        public string RefundReason { get; set; }
        public DateTime? BadReviewDate { get; set; }
        public string BadReviewReason { get; set; }
        public string BadReviewContent { get; set; }
        public bool IsReContent { get; set; }
        public string ReContent { get; set; }
        /// <summary>
        /// 指派人员id
        /// </summary>
        public int? AssignEmpId { get; set; }
        public bool IsBadReview { get; set; }
        /// <summary>
        /// 紧急程度
        /// </summary>
        public int EmergencyLevel { get; set; }
        /// <summary>
        /// 抖音客户来源
        /// </summary>
        public int? Source { get; set; }
        /// <summary>
        /// 带货产品类型
        /// </summary>
        public int ProductType { get; set; }
        /// <summary>
        /// 获客方式
        /// </summary>
        public int GetCustomerType { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 小黄车登记顾客类型
        /// </summary>
        public int ShoppingCartRegistrationCustomerType { get; set; }
    }
}
