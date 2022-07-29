using System;
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
        public string LiveAnchorWechatNo { get; set; }
        public string CustomerNickName { get; set; }
        public string Phone { get; set; }
        public decimal Price { get; set; }
        public int ConsultationType { get; set; }
        public string ConsultationTypeText { get; set; }
        public bool IsAddWeChat { get; set; }
        public bool IsWriteOff { get; set; }
        public bool IsConsultation { get; set; }
        public bool IsReturnBackPrice { get; set; }
        public string Remark { get; set; }
        public int CreateBy { get; set; }
        public string CreateByName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? RefundDate { get; set; }
        public string RefundReason { get; set; }
        public DateTime? BadReviewDate { get; set; }
        public string BadReviewReason { get; set; }
        public string BadReviewContent { get; set; }
        public bool IsReContent { get; set; }
        public string ReContent { get; set; }
        public bool IsBadReview { get; set; }
    }
}
