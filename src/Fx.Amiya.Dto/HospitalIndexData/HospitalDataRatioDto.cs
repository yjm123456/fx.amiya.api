using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalIndexData
{
    public class HospitalDataRatioDto
    {
        /// <summary>
        /// 上门率
        /// </summary>
        public decimal ToHospitalRatio { get; set; }
        /// <summary>
        /// 上门率环比
        /// </summary>
        public decimal ToHospitalRatioChainRatio { get; set; }
        /// <summary>
        /// 新客成交率
        /// </summary>
        public decimal NewCustomerDealRatio { get; set; }
        /// <summary>
        /// 新客成交率环比
        /// </summary>
        public decimal NewCustomerDealRatioChainRatio { get; set; }
        /// <summary>
        /// 老客成交率
        /// </summary>
        public decimal OldCustomerDealRatio { get; set; }
        /// <summary>
        /// 老客成交率环比
        /// </summary>
        public decimal OldCustomerDealRatioChainRatio { get; set; }
        /// <summary>
        /// 新客占比
        /// </summary>
        public decimal NewCustomerRatio { get; set; }
        /// <summary>
        /// 新客占比环比
        /// </summary>
        public decimal NewCustomerRatioChainRatio { get; set; }
        /// <summary>
        /// 老客占比
        /// </summary>
        public decimal OldCustomerRatio { get; set; }
        /// <summary>
        /// 老客占比环比
        /// </summary>
        public decimal OldCustomerRatioChainRatio { get; set; }
    }
}
