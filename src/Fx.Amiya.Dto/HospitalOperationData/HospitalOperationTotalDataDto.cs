using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalOperationData
{
    public class HospitalOperationTotalDataDto
    {
        public int LastMonthSendOrderCount { get; set; }
        public int LastMonthNewCustomerToHospitalCount { get; set; }
        public decimal LastMonthNewCustomerToHospitalRate { get; set; }
        public int LastMonthNewCustomerDealCount { get; set; }
        public decimal LastMonthNewCustomerDealRate { get; set; }
        public decimal LastMonthNewCustomerPerformance { get; set; }
        public decimal LastMonthNewCustomerUnitPrice { get; set; }
        public int LastMonthOldCustomerToHospitalCount { get; set; }
        public int LastMonthOldCustomerDealCount { get; set; }
        public decimal LastMonthOldCustomerDealRate { get; set; }
        public decimal LastMonthOldCustomerPerformance { get; set; }
        public decimal LastMonthOldCustomerUnitPrice { get; set; }
        public decimal LastMonthTotalPerformance { get; set; }
        public decimal LastMonthOldCustomerPerformanceRatio { get; set; }




        public int ThisMonthSendOrderCount { get; set; }
        public int ThisMonthNewCustomerToHospitalCount { get; set; }
        public decimal ThisMonthNewCustomerToHospitalRate { get; set; }
        public int ThisMonthNewCustomerDealCount { get; set; }
        public decimal ThisMonthNewCustomerDealRate { get; set; }
        public decimal ThisMonthNewCustomerPerformance { get; set; }
        public decimal ThisMonthNewCustomerUnitPrice { get; set; }
        public int ThisMonthOldCustomerToHospitalCount { get; set; }
        public int ThisMonthOldCustomerDealCount { get; set; }
        public decimal ThisMonthOldCustomerDealRate { get; set; }
        public decimal ThisMonthOldCustomerPerformance { get; set; }
        public decimal ThisMonthOldCustomerUnitPrice { get; set; }
        public decimal ThisMonthTotalPerformance { get; set; }
        public decimal ThisMonthOldCustomerPerformanceRatio { get; set; }

        /// <summary>
        /// 派单数环比
        /// </summary>
        public decimal SendOrderCountChainRatio { get; set; }
        /// <summary>
        /// 新客上门人数环比
        /// </summary>
        public decimal NewCustomerToHospitalCountChainRatio { get; set; }
        /// <summary>
        /// 新客上门率环比
        /// </summary>
        public decimal NewCustomerToHospitalRateChainRatio { get; set; }
        /// <summary>
        /// 新客成交人数环比
        /// </summary>
        public decimal NewCustomerDealCountChainRatio { get; set; }
        /// <summary>
        /// 新客成交率环比
        /// </summary>
        public decimal NewCustomerDealRateChainRatio { get; set; }
        /// <summary>
        /// 新客业绩环比
        /// </summary>
        public decimal NewCustomerPerformanceChainRatio { get; set; }
        /// <summary>
        /// 新客客单价环比
        /// </summary>
        public decimal NewCustomerUnitPriceChainRatio { get; set; }
        /// <summary>
        /// 老客上门人数环比
        /// </summary>
        public decimal OldCustomerToHospitalCountChainRatio { get; set; }
        /// <summary>
        /// 老客成交人数环比
        /// </summary>
        public decimal OldCustomerDealCountChainRatio { get; set; }
        /// <summary>
        /// 老客成交率环比
        /// </summary>
        public decimal OldCustomerDealRateChainRatio { get; set; }
        /// <summary>
        /// 老客业绩环比
        /// </summary>
        public decimal OldCustomerPerformanceChainRatio { get; set; }
        /// <summary>
        /// 老客客单价环比
        /// </summary>
        public decimal OldCustomerUnitPriceChainRatio { get; set; }
        /// <summary>
        /// 总业绩环比
        /// </summary>
        public decimal TotalPerformanceChainRatio { get; set; }
        /// <summary>
        /// 老客业绩环比
        /// </summary>
        public decimal OldCustomerPerformanceRatioChainRatio { get; set; }


    }
}
