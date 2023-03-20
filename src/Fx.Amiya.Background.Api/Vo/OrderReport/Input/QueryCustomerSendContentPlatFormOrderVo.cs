using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.Input
{
    /// <summary>
    /// 内容平台客服已派单报表查询类
    /// </summary>
    public class QueryCustomerSendContentPlatFormOrderVo:BaseQueryVo
    {
        /// <summary>
        /// 归属月份
        /// </summary>
        public int? BelongMonth { get; set; }
        /// <summary>
        /// 最小下单金额
        /// </summary>
        public decimal? MinAddOrderPrice { get; set; }
        /// <summary>
        /// 最大下单金额
        /// </summary>
        public decimal? MaxAddOrderPrice { get; set; }
        /// <summary>
        /// 医院id（为空查询所有）
        /// </summary>
        public int? HospitalId { get; set; }
        /// <summary>
        /// 主播id
        /// </summary>
        public int? LiveAnchorId { get; set; }
        /// <summary>
        /// 是否陪诊
        /// </summary>
        public bool? IsAcompanying { get; set; }
        /// <summary>
        /// 新/老客业绩
        /// </summary>
        public bool? IsOldCustomer { get; set; }
        /// <summary>
        /// 佣金比例
        /// </summary>
        public decimal? CommissionRatio { get; set; }
        /// <summary>
        /// 是否到院，为空查询全部
        /// </summary>
        public bool? IsToHospital { get; set; }
        /// <summary>
        /// 到院时间起
        /// </summary>
        public DateTime? ToHospitalStartDate { get; set; }
        /// <summary>
        /// 到院时间止
        /// </summary>
        public DateTime? ToHospitalEndDate { get; set; }
        /// <summary>
        /// 到院类型，为空查询所有
        /// </summary>
        public int? ToHospitalType { get; set; }
        /// <summary>
        /// 平台id
        /// </summary>
        public string ContentPlatFormId { get; set; }
        /// <summary>
        /// 派单客服id
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 归属客服id
        /// </summary>
        public int BelongEmpId { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int? OrderStatus { get; set; }
    }
}
