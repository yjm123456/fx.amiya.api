using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalDoctorOperation
{
    public class UpdateHospitalDoctorOperationVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 医生名称
        /// </summary>
        public string DoctorName { get; set; }
        /// <summary>
        /// 新客接诊人数
        /// </summary>
        public int NewCustomerTreatCount { get; set; }
        /// <summary>
        /// 新客成交人数
        /// </summary>
        public int NewCustomerDealCount { get; set; }
        /// <summary>
        /// 新客成交率
        /// </summary>
        public decimal NewCustomerDealRate { get; set; }
        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 新客客单价
        /// </summary>
        public decimal NewCustomerOrderPrice { get; set; }
        /// <summary>
        /// 新客业绩占比
        /// </summary>
        public decimal NewCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 老客接诊人数
        /// </summary>
        public int OldCustomerTreatCount { get; set; }
        /// <summary>
        /// 老客成交人数
        /// </summary>
        public int OldCustomerDealCount { get; set; }
        /// <summary>
        /// 老客成交率
        /// </summary>
        public decimal OldCustomerDealRate { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
        /// <summary>
        /// 老客客单价
        /// </summary>
        public decimal OldCustomerOrderPrice { get; set; }
        /// <summary>
        /// 老客业绩占比
        /// </summary>
        public decimal OldCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }
    }
}
