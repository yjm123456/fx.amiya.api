using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalOperationData
{
    /// <summary>
    /// 机构运营数据
    /// </summary>
    public class HospitalOperationDataListVo
    {
        /// <summary>
        /// 前月派单数
        /// </summary>
        public int LastMonthSendOrderCount { get; set; }
        /// <summary>
        /// 前月新客上门数
        /// </summary>
        public int LastMonthNewCustomerToHospitalCount { get; set; }
        /// <summary>
        /// 前月新客上门率
        /// </summary>
        public decimal LastMonthNewCustomerToHospitalRate { get; set; }
        /// <summary>
        /// 前月新客成交人数
        /// </summary>
        public int LastMonthNewCustomerDealCount { get; set; }
        /// <summary>
        /// 前月新客成交率
        /// </summary>
        public decimal LastMonthNewCustomerDealRate { get; set; }
        /// <summary>
        /// 前月新客业绩
        /// </summary>
        public decimal LastMonthNewCustomerPerformance { get; set; }
        /// <summary>
        /// 前月新客客单价
        /// </summary>
        public decimal LastMonthNewCustomerUnitPrice { get; set; }
        /// <summary>
        /// 前月老客上门人数
        /// </summary>
        public int LastMonthOldCustomerToHospitalCount { get; set; }
        /// <summary>
        /// 前月老客成交人数
        /// </summary>
        public int LastMonthOldCustomerDealCount { get; set; }
        /// <summary>
        /// 前月老客成交率
        /// </summary>
        public decimal LastMonthOldCustomerDealRate { get; set; }
        /// <summary>
        /// 前月老客业绩
        /// </summary>
        public decimal LastMonthOldCustomerPerformance { get; set; }
        /// <summary>
        /// 前月老客客单价
        /// </summary>
        public decimal LastMonthOldCustomerUnitPrice { get; set; }
        /// <summary>
        /// 前月总业绩
        /// </summary>
        public decimal LastMonthTotalPerformance { get; set; }
        /// <summary>
        /// 前月老客业绩占比
        /// </summary>
        public decimal LastMonthOldCustomerPerformanceRatio { get; set; }



        /// <summary>
        /// 上月派单数
        /// </summary>
        public int ThisMonthSendOrderCount { get; set; }
        /// <summary>
        /// 上月新客上门人数
        /// </summary>
        public int ThisMonthNewCustomerToHospitalCount { get; set; }
        /// <summary>
        /// 上月新客上门率
        /// </summary>
        public decimal ThisMonthNewCustomerToHospitalRate { get; set; }
        /// <summary>
        /// 上月新客成交人数
        /// </summary>
        public int ThisMonthNewCustomerDealCount { get; set; }
        /// <summary>
        /// 上月新客成交率
        /// </summary>
        public decimal ThisMonthNewCustomerDealRate { get; set; }
        /// <summary>
        /// 上月新客业绩
        /// </summary>
        public decimal ThisMonthNewCustomerPerformance { get; set; }
        /// <summary>
        /// 上月新客客单价
        /// </summary>
        public decimal ThisMonthNewCustomerUnitPrice { get; set; }
        /// <summary>
        /// 上月老客上门人数
        /// </summary>
        public int ThisMonthOldCustomerToHospitalCount { get; set; }
        /// <summary>
        /// 上月老客成交人数
        /// </summary>
        public int ThisMonthOldCustomerDealCount { get; set; }
        /// <summary>
        /// 上月老客成交率
        /// </summary>
        public decimal ThisMonthOldCustomerDealRate { get; set; }
        /// <summary>
        /// 上月老客业绩
        /// </summary>
        public decimal ThisMonthOldCustomerPerformance { get; set; }
        /// <summary>
        /// 上月老客客单价
        /// </summary>
        public decimal ThisMonthOldCustomerUnitPrice { get; set; }
        /// <summary>
        /// 上月总业绩
        /// </summary>
        public decimal ThisMonthTotalPerformance { get; set; }
        /// <summary>
        /// 上月老客业绩占比
        /// </summary>
        public decimal ThisMonthOldCustomerPerformanceRatio { get; set; }
    }
}
