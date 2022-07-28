using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    public class ContentPlatFormOrderDealInfoVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public string Id { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        [Description("预约时间")]
        public string AppointmentDate { get; set; }
        /// <summary>
        /// 面诊状态
        /// </summary>
        [Description("面诊状态")]
        public string ConsultationTypeText { get; set; }
        /// <summary>
        /// 客户昵称
        /// </summary>
        [Description("客户昵称")]
        public string CustomerName { get; set; }
        /// <summary>
        /// 预约医院
        /// </summary>
        [Description("预约医院")]
        public string AppointmentHospitalName { get; set; }
        /// <summary>
        /// 最终成交医院
        /// </summary>
        [Description("最终成交医院")]
        public string LastDealHospital { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        [Description("项目")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 咨询内容
        /// </summary>
        [Description("咨询内容")]
        public string ConsultingContent { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        [Description("下单时间")]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 下单平台
        /// </summary>
        [Description("下单平台")]
        public string ContentPlatformName { get; set; }
        /// <summary>
        /// 主播ip账号
        /// </summary>
        [Description("主播ip账号")]
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 主播微信号
        /// </summary>
        [Description("主播微信号")]
        public string LiveAnchorWeChatNo { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        [Description("订单类型")]
        public string OrderTypeText { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        [Description("订单状态")]
        public string OrderStatusText { get; set; }
        /// <summary>
        /// 三方订单号
        /// </summary>
        [Description("抖店订单号")]
        public string OtherContentPlatFormOrderId { get; set; }
        /// <summary>
        /// 定金金额
        /// </summary>
        [Description("定金金额")]
        public decimal? DepositAmount { get; set; }
        /// <summary>
        /// 成交金额
        /// </summary>
        [Description("成交金额")]
        public decimal? DealAmount { get; set; }

        /// <summary>
        /// 成交时间
        /// </summary>
        [Description("成交时间")]
        public DateTime? DealDate { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [Description("电话")]
        public string Phone { get; set; }
        /// <summary>
        /// 未成交原因
        /// </summary>
        [Description("未成交原因")]
        public string UnDealReason { get; set; }
        /// <summary>
        /// 后期项目铺垫
        /// </summary>
        [Description("后期项目铺垫")]
        public string LateProjectStage { get; set; }

        /// <summary>
        /// 新老客业绩
        /// </summary>
        [Description("新老客业绩")]
        public string IsOldCustomer { get; set; }

        /// <summary>
        /// 是否陪诊
        /// </summary>
        [Description("是否陪诊")]
        public string IsAcompanying { get; set; }
        /// <summary>
        /// 佣金比例
        /// </summary>
        [Description("佣金比例")]
        public decimal CommissionRatio { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 归属客服
        /// </summary>
        [Description("归属客服")]
        public string BelongEmpName { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        [Description("审核时间")]
        public DateTime? CheckDate { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        [Description("审核状态")]
        public string CheckStateText { get; set; }
        /// <summary>
        /// 审核金额
        /// </summary>

        [Description("审核金额")]
        public decimal? CheckPrice { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        [Description("结算金额")]

        public decimal? SettlePrice { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        [Description("审核备注")]
        public string CheckRemark { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        [Description("审核人")]
        public string CheckByName { get; set; }

        /// <summary>
        /// 是否回款
        /// </summary>
        [Description("是否回款")]
        public bool IsReturnBackPrice { get; set; }

        /// <summary>
        /// 回款金额
        /// </summary>
        [Description("回款金额")]
        public decimal? ReturnBackPrice { get; set; }
        /// <summary>
        /// 回款时间
        /// </summary>
        [Description("回款时间")]
        public DateTime? ReturnBackDate { get; set; }
    }
}
