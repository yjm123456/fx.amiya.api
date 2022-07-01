using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ShoppingCartRegistration
{
    public class AddShoppingCartRegistrationVo
    {
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
        /// 面诊方式
        /// </summary>
        public int ConsultationType { get; set; }
        /// <summary>
        /// 是否加V
        /// </summary>
        public bool IsAddWeChat { get; set; }

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
    }
}
