using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    /// <summary>
    /// 小黄车登记列表
    /// </summary>
    public class ShoppingCartRegistrationReportVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Description("编号")]
        public string Id { get; set; }
        /// <summary>
        /// 登记日期
        /// </summary>
        [Description("登记日期")]
        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 来源渠道
        /// </summary>
        [Description("来源渠道")]
        public string ContentPlatFormName { get; set; }
        /// <summary>
        /// 主播IP
        /// </summary>
        [Description("主播IP")]
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 主播微信号
        /// </summary>
        [Description("主播微信号")]
        public string LiveAnchorWechatNo { get; set; }
        /// <summary>
        /// 抖音昵称
        /// </summary>
        [Description("抖音昵称")]
        public string CustomerNickName { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        [Description("联系方式")]
        public string Phone { get; set; }
        /// <summary>
        /// 下单金额
        /// </summary>
        [Description("下单金额")]
        public decimal Price { get; set; }
        /// <summary>
        /// 面诊方式
        /// </summary>
        [Description("面诊方式")]
        public string ConsultationTypeText { get; set; }

        /// <summary>
        /// 是否加V
        /// </summary>
        [Description("是否加V")]
        public string IsAddWechat { get; set; }
        /// <summary>
        /// 是否核销
        /// </summary>
        [Description("是否核销")]
        public string IsWriteOff { get; set; }
        /// <summary>
        /// 是否面诊
        /// </summary>
        [Description("是否面诊")]
        public string IsConsultation { get; set; }
        /// <summary>
        /// 是否退款
        /// </summary>
        [Description("是否退款")]
        public string IsReturnBackPrice { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Description("创建人")]
        public string CreateBy { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Description("创建日期")]
        public DateTime CreateDate { get; set; }
    }
}
