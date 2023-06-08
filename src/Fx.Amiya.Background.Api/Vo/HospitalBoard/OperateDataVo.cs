using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalBoard
{
    public class OperateDataVo
    {
        /// <summary>
        /// 新客上门量
        /// </summary>
        public decimal NewCustomerToHospitalCount { get; set; }
        /// <summary>
        /// 新客上门量环比
        /// </summary>
        public decimal? NewCustomerToHospitalChainRatio { get; set; }
        /// <summary>
        /// 新客上门量同比
        /// </summary>
        public decimal? NewCustomerToHospitalYearOnYear { get; set; }
        /// <summary>
        /// 新客成交量
        /// </summary>
        public decimal NewCustomerDealCount { get; set; }
        /// <summary>
        /// 新客成交量环比
        /// </summary>
        public decimal? NewCustomerDealChainRatio { get; set; }
        /// <summary>
        /// 新客成交量同比
        /// </summary>
        public decimal? NewCustomerDealYearOnYear { get; set; }

        /// <summary>
        /// 老客上门量
        /// </summary>
        public decimal OldCustomerToHospitalCount { get; set; }
        /// <summary>
        /// 老客上门量环比
        /// </summary>
        public decimal? OldCustomerToHospitalChainRatio { get; set; }
        /// <summary>
        /// 老客上门量同比
        /// </summary>
        public decimal? OldCustomerToHospitalYearOnYear { get; set; }
        /// <summary>
        /// 老客成交量
        /// </summary>
        public decimal OldCustomerDealCount { get; set; }
        /// <summary>
        /// 老客成交量环比
        /// </summary>
        public decimal? OldCustomerDealChainRatio { get; set; }
        /// <summary>
        /// 老客成交量同比
        /// </summary>
        public decimal? OldCustomerDealYearOnYear { get; set; }


        /// <summary>
        /// 新客上门率
        /// </summary>
        public decimal? NewCustomerToHospitalRatio { get; set; }
        /// <summary>
        /// 新客上门率环比
        /// </summary>
        public decimal? NewCustomerToHospitalRatioChainRatio { get; set; }
        /// <summary>
        /// 新客上门率同比
        /// </summary>
        public decimal? NewCustomerToHospitalRatioYearOnYear { get; set; }
        /// <summary>
        /// 新客上门率健康值
        /// </summary>
        public decimal? NewCustomerToHospitalRatioHealthValue { get; set; }


        /// <summary>
        /// 新客成交率
        /// </summary>
        public decimal? NewCustomerDealRation { get; set; }
        /// <summary>
        /// 新客成交率环比
        /// </summary>
        public decimal? NewCustomerDealRationChainRatio { get; set; }
        /// <summary>
        /// 新客成交率同比
        /// </summary>
        public decimal? NewCustomerDealRationYearOnYear { get; set; }

        /// <summary>
        /// 新客成交率健康值
        /// </summary>
        public decimal? NewCustomerDealRationHealthValue { get; set; }


        /// <summary>
        /// 老客复购率
        /// </summary>
        public decimal? OldCustomerRepurchaseRatio { get; set; }
        /// <summary>
        /// 老客复购率环比
        /// </summary>
        public decimal? OldCustomerRepurchaseRatioChainRatio { get; set; }
        /// <summary>
        /// 老客复购率同比
        /// </summary>
        public decimal? OldCustomerRepurchaseRatioYearOnYear { get; set; }
        /// <summary>
        /// 老客复购率健康值
        /// </summary>
        public decimal? OldCustomerRepurchaseRatioHealthValue { get; set; }



        /// <summary>
        /// 老客成交率
        /// </summary>
        public decimal? OldCustomerDealRation { get; set; }
        /// <summary>
        /// 老客成交率环比
        /// </summary>
        public decimal? OldCustomerDealRationChainRatio { get; set; }
        /// <summary>
        /// 老客成交率同比
        /// </summary>
        public decimal? OldCustomerDealRationYearOnYear { get; set; }
        /// <summary>
        /// 老客成交率健康值
        /// </summary>
        public decimal? OldCustomerDealRationHealthValue { get; set; }

        /*/// <summary>
        /// 累计新客上门量
        /// </summary>
        public decimal AccumulateNewCustomerToHospitalCount { get; set; }
        /// <summary>
        /// 新客累计上门量环比
        /// </summary>

        public decimal? AccumulateNewCustomerToHospitalCountChainRatio { get; set; }
        /// <summary>
        /// 新客累计上门量同比
        /// </summary>

        public decimal? AccumulateNewCustomerToHospitalCountYearOnYear { get; set; }
        /// <summary>
        /// 累计新客成交量
        /// </summary>
        public decimal AccumulateNewCustomerDealCount { get; set; }
        /// <summary>
        /// 累计新客成交量环比
        /// </summary>
        public decimal? AccumulateNewCustomerDealCountChainRatio { get; set; }
        /// <summary>
        /// 累计新客成交量同比
        /// </summary>
        public decimal? AccumulateNewCustomerDealCountYearOnYear { get; set; }
        /// <summary>
        /// 累计老客成交量
        /// </summary>

        public decimal AccumulateOldCustomerDealCount { get; set; }
        /// <summary>
        /// 累计老客成交量环比
        /// </summary>

        public decimal? AccumulateOldCustomerDealCountChainRatio { get; set; }
        /// <summary>
        /// 累计老客成交量同比
        /// </summary>

        public decimal? AccumulateOldCustomerDealCountYearOnYear { get; set; }
        /// <summary>
        /// 累计新客上门率
        /// </summary>

        public decimal AccumulateNewCustomerToHospitalRatio { get; set; }
        /// <summary>
        /// 累计新客上门率环比
        /// </summary>

        public decimal? AccumulateNewCustomerToHospitalRatioChainRatio { get; set; }
        /// <summary>
        /// 累计新客上门率同比
        /// </summary>

        public decimal? AccumulateNewCustomerToHospitalRatioYearOnYear { get; set; }
        /// <summary>
        /// 累计新客成交率
        /// </summary>
        public decimal AccumulateNewCustomerDealRation { get; set; }
        /// <summary>
        /// 累计新客成交率环比
        /// </summary>
        public decimal? AccumulateNewCustomerDealRationChainRatio { get; set; }
        /// <summary>
        /// 累计新客成交率同比
        /// </summary>
        public decimal? AccumulateNewCustomerDealRationYearOnYear { get; set; }*/
    }
}
