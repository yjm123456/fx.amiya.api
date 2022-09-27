using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalPerformance
{
    public class HospitalNewCustomerAchievementDto
    {
        /// <summary>
        /// 前月新客上门率
        /// </summary>
        public decimal LastNewCustomerVisitRate { get; set; }
        /// <summary>
        /// 上月新客上门率
        /// </summary>
        public decimal ThisNewCustomerVisitRate { get; set; }
        /// <summary>
        /// 新客上门率环比
        /// </summary>
        public decimal NewCustomerVisitChainRatio { get; set; }


        /// <summary>
        /// 前月新客成交率
        /// </summary>
        public decimal LastNewCustomerDealRate { get; set; }
        /// <summary>
        /// 上月新客成交率
        /// </summary>
        public decimal ThisNewCustomerDealRate { get; set; }
        /// <summary>
        /// 新客成交率环比
        /// </summary>
        public decimal NewCustomerDealChainRatio { get; set; }


        /// <summary>
        /// 前月新客客单价
        /// </summary>
        public decimal LastNewCustomerUnitPrice { get; set; }
        /// <summary>
        /// 上月新客客单价
        /// </summary>
        public decimal ThisNewCustomerUnitPrice { get; set; }
        /// <summary>
        /// 新客客单价环比
        /// </summary>
        public decimal NewCustomerUnitPriceChainRatio { get; set; }
    }
}
