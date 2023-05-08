using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder
{
    /// <summary>
    /// 订单成交情况
    /// </summary>
    public class ContentPlatFormOrderDealInfoVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string ContentPlatFormOrderId { get; set; }

        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 派单时间
        /// </summary>
        public DateTime? SendDate { get; set; }
        /// <summary>
        /// 面诊类型文本
        /// </summary>
        public string ConsultationTypeText { get; set; }

        /// <summary>
        /// 客户昵称
        /// </summary>
        public string CustomerNickName { get; set; }
        /// <summary>
        /// 客户手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 加密手机号
        /// </summary>
        public string EncryptPhone { get; set; }


        /// <summary>
        /// 下单金额
        /// </summary>
        public decimal? AddOrderPrice { get; set; }

        /// <summary>
        /// 是否到院
        /// </summary>
        public bool IsToHospital { get; set; }

        /// <summary>
        /// 到院类型
        /// </summary>
        public int ToHospitalType { get; set; }

        /// <summary>
        /// 到院类型文本
        /// </summary>
        public string ToHospitalTypeText { get; set; }

        /// <summary>
        /// 到院时间
        /// </summary>
        public DateTime? TohospitalDate { get; set; }

        /// <summary>
        /// 是否成交
        /// </summary>
        public bool IsDeal { get; set; }

        /// <summary>
        /// 最终成交医院id
        /// </summary>
        public int? LastDealHospitalId { get; set; }
        /// <summary>
        /// 成交医院
        /// </summary>
        public string DealHospital { get; set; }

        /// <summary>
        /// 截图
        /// </summary>
        public string DealPicture { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 业绩类型
        /// </summary>
        public int DealPerformanceType { get; set; }

        /// <summary>
        /// 业绩类型文本
        /// </summary>
        public string DealPerformanceTypeText { get; set; }

        /// <summary>
        /// 成交时间
        /// </summary>
        public DateTime? DealDate { get; set; }

        /// <summary>
        /// 三方订单号
        /// </summary>
        public string OtherOrderId { get; set; }

        /// <summary>
        /// 新客/老客
        /// </summary>
        public bool IsOldCustomer { get; set; }

        /// <summary>
        /// 是否陪诊
        /// </summary>
        public bool IsAcompanying { get; set; }

        /// <summary>
        /// 佣金比例
        /// </summary>
        public decimal CommissionRatio { get; set; }


        /// <summary>
        /// 审核状态
        /// </summary>
        public int? CheckState { get; set; }

        /// <summary>
        /// 审核状态文本
        /// </summary>
        public string CheckStateText { get; set; }
        /// <summary>
        /// 审核金额
        /// </summary>

        public decimal? CheckPrice { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 信息服务费
        /// </summary>
        public decimal? InformationPrice { get; set; }
        /// <summary>
        /// 系统使用费
        /// </summary>
        public decimal? SystemUpdatePrice { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>

        public decimal? SettlePrice { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public int? CheckBy { get; set; }

        /// <summary>
        /// 审核人名称
        /// </summary>
        public string CheckByEmpName { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        public string CheckRemark { get; set; }
        /// <summary>
        /// 是否回款
        /// </summary>

        public bool IsReturnBackPrice { get; set; }
        /// <summary>
        /// 回款金额
        /// </summary>

        public decimal? ReturnBackPrice { get; set; }
        /// <summary>
        /// 回款日期
        /// </summary>
        public DateTime? ReturnBackDate { get; set; }

        /// <summary>
        /// 创建人（0为医院）
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        public string CreateByEmpName { get; set; }
        /// <summary>
        /// 归属主播
        /// </summary>
        public string BelongLiveAnchor { get; set; }
        /// <summary>
        /// 邀约凭证图片
        /// </summary>
        public List<string> InvitationDocuments { get; set; }
        /// <summary>
        /// 对账单id
        /// </summary>
        public string ReconciliationDocumentsId { get; set; }
        /// <summary>
        /// 是否是重单可深度订单
        /// </summary>
        public bool IsRepeatProfundityOrder { get; set; }
        /// <summary>
        /// 是否开票
        /// </summary>
        public bool IsCreateBill { get; set; }
        /// <summary>
        /// 开票公司
        /// </summary>
        public string CreatBillCompany { get; set; }
        /// <summary>
        /// 消费类型
        /// </summary>
        public int? ConsumptionType { get; set; }
        /// <summary>
        /// 消费类型文本
        /// </summary>
        public string ConsumptionTypeText { get; set; }
    }
}
