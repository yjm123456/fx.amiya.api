using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 优秀机构运营健康指标
    /// </summary>
    public class ExcellentHospitalOperationsbe:BaseDbModel
    {
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 上月新客上门率
        /// </summary>
        public  decimal LastMonthNewCustomerToHospitalRate { get; set; }
        /// <summary>
        /// 本月新客上门率
        /// </summary>
        public decimal  CurrentMonthNewCustomerToHospitalRate { get; set; }
        /// <summary>
        /// 新客上门率环比
        /// </summary>
        public decimal NewCustomerToHospitalChainRatio { get; set; }
        /// <summary>
        /// 上月新客成交率
        /// </summary>
        public decimal LastMonthNewCustomerDealRate { get; set; }
        /// <summary>
        /// 本月新客成交率
        /// </summary>
        public decimal CurrentMonthNewCustomerDealRate { get; set; }
        /// <summary>
        /// 新客成交率环比
        /// </summary>
        public decimal NewCustomerDealChainRation { get; set; }
        /// <summary>
        /// 上月新客客单价
        /// </summary>
        public decimal LastMonthNewCustomerOrderPrice { get; set; }
        /// <summary>
        /// 本月新客客单价
        /// </summary>
        public decimal CurrentMonthNewCustomerOrderPrice { get; set; }
        /// <summary>
        /// 新客客单价环比
        /// </summary>
        public decimal NewCustomerOrderPriceChainRation { get; set; }
        /// <summary>
        /// 运营指标id
        /// </summary>
        public string HospitalOperationsbeIndicatorId { get; set; }
        public HospitalOperationsbeIndicator HospitalOperationsbeIndicator { get; set; }

    }
}
