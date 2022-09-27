using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GreatHospitalOperationHealth
{
    /// <summary>
    /// 新增优秀机构运营健康指标
    /// </summary>
    public class AddGreatHospitalOperationHealthVo 
    {
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 归属指标id
        /// </summary>
        public string IndicatorsId { get; set; }
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
