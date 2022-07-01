using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    /// <summary>
    /// 客户升单报表
    /// </summary>
    public class CustomerHospitalConsumeReportVo
    {
        /// <summary>
        /// 升单编号
        /// </summary>
        [Description("升单编号")]
        public string ConsumeId { get; set; }
        /// <summary>
        /// 登记日期
        /// </summary>
        [Description("登记日期")]
        public DateTime CreateDate { get; set; }
        ///<summary>
        /// 渠道
        /// </summary>
        [Description("渠道")]
        public string Channel { get; set; }
        ///<summary>
        /// 归属主播IP
        /// </summary>
        [Description("归属主播IP")]
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 三方订单号
        /// </summary>
        [Description("抖店订单号")]
        public string OtherContentPlatFormOrderId { get; set; }
        /// <summary>
        /// 客户昵称
        /// </summary>
        [Description("客户昵称")]
        public string NickName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Description("联系电话")]
        public string Phone { get; set; }
        /// <summary>
        /// 是否携带订单
        /// </summary>
        [Description("是否携带订单")]
        public string IsAddedOrder { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public string OrderId { get; set; }
        /// <summary>
        /// 核销日期
        /// </summary>
        [Description("核销日期")]
        public DateTime? WriteOffDate { get; set; }
        /// <summary>
        /// 消费类型
        /// </summary>
        [Description("消费类型")]
        public string ConsumeTypeText { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        [Description("项目")]
        public string ItemName { get; set; }
        /// <summary>
        /// 是否为面诊卡
        /// </summary>
        [Description("是否为面诊卡")]
        public string IsCconsultationCard { get; set; }
        /// <summary>
        /// 医院
        /// </summary>
        [Description("医院")]
        public string HospitalName { get; set; }
        /// <summary>
        /// 升单类型
        /// </summary>
        [Description("升单类型")]
        public string BuyAgainTypeText { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [Description("金额")]
        public decimal Price { get; set; }
        /// <summary>
        /// 是否为外播
        /// </summary>
        [Description("是否为外播")]
        public string IsSelfLiving { get; set; }

        /// <summary>
        /// 升单日期
        /// </summary>
        [Description("升单日期")]
        public DateTime? BuyAgainTime { get; set; }
        /// <summary>
        /// 是否有升单证明
        /// </summary>
        [Description("是否有升单证明")]
        public string HasBuyagainEvidence { get; set; }
        /// <summary>
        /// 是否与医院核实
        /// </summary>
        [Description("是否与医院核实")]
        public string IsCheckToHospital { get; set; }
        /// <summary>
        /// 跟进人员
        /// </summary>
        [Description("跟进人员")]
        public string EmployeeName { get; set; }
        /// <summary>
        /// 人次
        /// </summary>
        [Description("人次")]
        public int PersonTime { get; set; }
        /// <summary>
        /// 是否领取加购礼
        /// </summary>
        [Description("是否领取加购礼")]
        public string IsReceiveAdditionalPurchase { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        [Description("审核时间")]
        public DateTime? CheckDate { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        [Description("审核状态")]
        public string CheckState { get; set; }
        /// <summary>
        /// 审核升单金额
        /// </summary>
        [Description("审核升单金额")]
        public decimal? CheckBuyAgainPrice { get; set; }

        /// <summary>
        /// 审核结算金额
        /// </summary>
        [Description("审核结算金额")]
        public decimal? CheckSettlePrice { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        [Description("审核人员")]
        public string CheckByEmpName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 审核信息
        /// </summary>
        [Description("审核信息")]
        public string CheckRemark { get; set; }
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
