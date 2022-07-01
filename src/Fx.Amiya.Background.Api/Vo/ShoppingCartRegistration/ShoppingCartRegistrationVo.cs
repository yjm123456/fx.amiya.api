using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ShoppingCartRegistration
{
    /// <summary>
    /// 小黄车登记列表
    /// </summary>
    public class ShoppingCartRegistrationVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime RecordDate { get; set; }
        public string ContentPlatFormId { get; set; }
        /// <summary>
        /// 来源渠道
        /// </summary>
        public string ContentPlatFormName { get; set; }
        public int LiveAnchorId { get; set; }
        /// <summary>
        /// 主播IP
        /// </summary>
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 主播微信号
        /// </summary>
        public string LiveAnchorWechatNo { get; set; }
        /// <summary>
        /// 抖音昵称
        /// </summary>
        public string CustomerNickName { get; set; }
        /// <summary>
        /// 联系方式
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
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
