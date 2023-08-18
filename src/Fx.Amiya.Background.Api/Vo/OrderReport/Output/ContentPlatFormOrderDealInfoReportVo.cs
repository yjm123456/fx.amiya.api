using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.OutPut
{
    public class ContentPlatFormOrderDealInfoReportVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Description("编号")]
        public string Id { get; set; }

        /// <summary>
        /// 登记时间
        /// </summary>
        [Description("登记时间")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [Description("订单编号")]
        public string ContentPlatFormOrderId { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        [Description("下单时间")]
        public DateTime OrderCreateDate { get; set; }

        /// <summary>
        /// 下单金额
        /// </summary>
        [Description("下单金额")]
        public decimal? AddOrderPrice { get; set; }

        /// <summary>
        /// 派单时间
        /// </summary>
        [Description("派单时间")]
        public DateTime? SendOrderDate { get; set; }
        /// <summary>
        /// 面诊类型
        /// </summary>
        [Description("面诊类型")]
        public string ConsultationType { get; set; }


        /// <summary>
        /// 平台
        /// </summary>
        [Description("平台")]
        public string ContentPlatFormName { get; set; }
        /// <summary>
        /// 主播
        /// </summary>
        [Description("主播")]
        public string LiveAnchorName { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        [Description("项目")]
        public string GoodsName { get; set; }

        /// <summary>
        /// 客户昵称
        /// </summary>
        [Description("客户昵称")]
        public string CustomerNickName { get; set; }
        /// <summary>
        /// 客户手机号
        /// </summary>
        [Description("客户手机号")]
        public string Phone { get; set; }

        /// <summary>
        /// 是否到院
        /// </summary>
        [Description("是否到院")]
        public string IsToHospital { get; set; }


        /// <summary>
        /// 到院类型
        /// </summary>
        [Description("到院类型")]
        public string ToHospitalTypeText { get; set; }

        /// <summary>
        /// 到院时间
        /// </summary>
        [Description("到院时间")]
        public DateTime? TohospitalDate { get; set; }

        /// <summary>
        /// 到院医院
        /// </summary>
        [Description("到院医院")]
        public string LastDealHospital { get; set; }
        /// <summary>
        /// 是否是重单可深度订单
        /// </summary>
        [Description("是否重单深度")]
        public string IsRepeatProfundityOrder { get; set; }

        /// <summary>
        /// 是否成交
        /// </summary>
        [Description("是否成交")]
        public string IsDeal { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 成交金额
        /// </summary>
        [Description("成交金额")]
        public decimal Price { get; set; }

        /// <summary>
        /// 业绩类型
        /// </summary>
        [Description("业绩类型")]
        public string DealPerformanceTypeText { get; set; }

        /// <summary>
        /// 成交时间
        /// </summary>
        [Description("成交时间")]
        public DateTime? DealDate { get; set; }
        
        /// <summary>
        /// 三方订单号
        /// </summary>
        [Description("三方订单号")]
        public string OtherOrderId { get; set; }
        /// <summary>
        /// 消费类型
        /// </summary>
        [Description("消费类型")]
        public string ConsumptionTypeText { get; set; }
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

        ///// <summary>
        ///// 佣金比例
        ///// </summary>
        /*[Description("佣金比例")]
        public decimal CommissionRatio { get; set; }*/
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
        /// 审核日期
        /// </summary>
        [Description("审核日期")]
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 信息服务费
        /// </summary>
        [Description("信息服务费")]
        public decimal? InformationPrice { get; set; }
        /// <summary>
        /// 系统使用费
        /// </summary>
        [Description("系统使用费")]
        public decimal? SystemUpdatePrice { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        [Description("服务费合计")]
        public decimal? SettlePrice { get; set; }
        /// <summary>
        /// 审核客服业绩金额
        /// </summary>
        [Description("助理服务费合计")]
        public decimal? CustomerServiceSettlePrice { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        [Description("审核人")]
        public string CheckBy { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        [Description("审核备注")]
        public string CheckRemark { get; set; }
        /// <summary>
        /// 是否开票
        /// </summary>
        [Description("是否开票")]
        public string IsCreateBill { get; set; }
        /// <summary>
        /// 开票公司
        /// </summary>
        [Description("开票公司")]
        public string BelongCompanyName { get; set; }
        /// <summary>
        /// 是否回款
        /// </summary>
        [Description("是否回款")]

        public string IsReturnBackPrice { get; set; }
        /// <summary>
        /// 回款金额
        /// </summary>
        [Description("回款金额")]

        public decimal? ReturnBackPrice { get; set; }
        /// <summary>
        /// 回款日期
        /// </summary>
        [Description("回款日期")]
        public DateTime? ReturnBackDate { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Description("跟进人员")]
        public string CreateByEmpName { get; set; }
       
    }
}
