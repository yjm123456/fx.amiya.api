using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ShoppingCartRegistration
{
    public class UpdateShoppingCartRegistrationVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 来源渠道id
        /// </summary>
        public string ContentPlatFormId { get; set; }
        /// <summary>
        /// 主播ID
        /// </summary>
        public int LiveAnchorId { get; set; }
        /// <summary>
        /// 主播微信号
        /// </summary>
        public string LiveAnchorWechatNo { get; set; }
        /// <summary>
        /// 客户抖音昵称
        /// </summary>
        public string CustomerNickName { get; set; }
        /// <summary>
        /// 客户手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 下单金额
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 是否加V
        /// </summary>
        public bool IsAddWeChat { get; set; }
        /// <summary>
        /// 面诊方式
        /// </summary>
        public int ConsultationType { get; set; }

        /// <summary>
        /// 是否核销
        /// </summary>
        public bool IsWriteOff { get; set; }
        /// <summary>
        /// 是否面诊
        /// </summary>
        public bool IsConsultation { get; set; }
        /// <summary>
        /// 是否退款
        /// </summary>
        public bool IsReturnBackPrice { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 退款时间
        /// </summary>
        public DateTime? RefundDate { get; set; }
        /// <summary>
        /// 退款原因
        /// </summary>
        public string RefundReason { get; set; }
        /// <summary>
        /// 差评时间
        /// </summary>
        public DateTime? BadReviewDate { get; set; }
        /// <summary>
        /// 差评原因
        /// </summary>
        public string BadReviewReason { get; set; }
        /// <summary>
        /// 差评内容
        /// </summary>
        public string BadReviewContent { get; set; }
        /// <summary>
        /// 是否追评
        /// </summary>
        public bool IsReContent { get; set; }
        /// <summary>
        /// 追评内容
        /// </summary>
        public string ReContent { get; set; }
        /// <summary>
        /// 接诊人员id
        /// </summary>
        public int AdmissionId { get; set; }
        /// <summary>
        /// 是否差评
        /// </summary>
        public bool IsBadReview { get; set; }
    }
}
