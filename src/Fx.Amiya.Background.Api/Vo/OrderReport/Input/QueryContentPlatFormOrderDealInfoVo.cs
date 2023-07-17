using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.Input
{
    /// <summary>
    /// 导出成交情况列表查询类
    /// </summary>
    public class QueryContentPlatFormOrderDealInfoVo : BaseQueryVo
    {
        /// <summary>
        /// 派单开始日期
        /// </summary>
        public DateTime? SendStartDate { get; set; }
        /// <summary>
        /// 派单结束日期
        /// </summary>
        public DateTime? SendEndDate { get; set; }
        /// <summary>
        /// 最小下单金额（空查询所有）
        /// </summary>
        public decimal? MinAddOrderPrice { get; set; }
        /// <summary>
        /// 最大下单金额（空查询所有）
        /// </summary>
        public decimal? MaxAddOrderPrice { get; set; }
        /// <summary>
        /// 面诊类型（空查询所有）
        /// </summary>
        public int? ConsultationType { get; set; }
        /// <summary>
        /// 是否到院（空查询所有）
        /// </summary>
        public bool? IsToHospital { get; set; }
        /// <summary>
        /// 到院开始时间
        /// </summary>
        public DateTime? TohospitalStartDate { get; set; }
        /// <summary>
        /// 到院结束时间
        /// </summary>
        public DateTime? ToHospitalEndDate { get; set; }
        /// <summary>
        /// 到院类型（空查询所有）
        /// </summary>
        public int? ToHospitalType { get; set; }
        /// <summary>
        /// 是否成交（空查询所有）
        /// </summary>
        public bool? IsDeal { get; set; }
        /// <summary>
        /// 最终成交医院id（空查询所有）
        /// </summary>
        public int? LastDealHospitalId { get; set; }
        /// <summary>
        /// 是否陪诊（空查询所有）
        /// </summary>
        public bool? IsAccompanying { get; set; }
        /// <summary>
        /// 新老客业绩（空查询所有）
        /// </summary>
        public bool? IsOldCustomer { get; set; }
        /// <summary>
        /// 审核状态（空查询所有）
        /// </summary>
        public int? CheckState { get; set; }
        /// <summary>
        /// 审核开始时间
        /// </summary>
        public DateTime? CheckStartDate { get; set; }
        /// <summary>
        /// 审核结束时间
        /// </summary>
        public DateTime? CheckEndDate { get; set; }
        /// <summary>
        /// 是否开票
        /// </summary>
        public bool? IsCreateBill { get; set; }
        /// <summary>
        /// 是否回款（空查询所有）
        /// </summary>
        public bool? IsReturnBakcPrice { get; set; }
        /// <summary>
        /// 回款开始时间
        /// </summary>
        public DateTime? ReturnBackPriceStartDate { get; set; }
        /// <summary>
        /// 回款结束时间
        /// </summary>
        public DateTime? ReturnBackPriceEndDate { get; set; }
        /// <summary>
        /// 跟进人员（空查询所有，0查医院）
        /// </summary>
        public int? CustomerServiceId { get; set; }
        /// <summary>
        /// 开票公司
        /// </summary>
        public string BelongCompanyId { get; set; }
        /// <summary>
        /// 消费类型
        /// </summary>
        public int? ConsumptionType { get; set; }
        /// <summary>
        /// 基础主播id
        /// </summary>
        public string BaseLiveAnchorId { get; set; }
    }
}
