using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalOperationData
{
    /// <summary>
    /// 机构运营数据分析新增
    /// </summary>
    public class AddHospitalOperationDataVo
    {
        /// <summary>
        /// 指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }

        #region 上月数据
        /// <summary>
        /// 上月派单数
        /// </summary>
        public int LastMonthSendOrderNum { get; set; }
        /// <summary>
        /// 上月新客上门数
        /// </summary>

        public int LastMonthNewCustomerVisitNum { get; set; }

        /// <summary>
        /// 上月新客上门率
        /// </summary>
        public decimal LastMonthNewCustomerVisitRate { get; set; }

        /// <summary>
        /// 上月新客成交数
        /// </summary>

        public int LastMonthNewCustomerDealNum { get; set; }

        /// <summary>
        /// 上月新客成交率
        /// </summary>
        public decimal LastMonthNewCustomerDealRate { get; set; }

        /// <summary>
        /// 上月新客业绩
        /// </summary>

        public int LastMonthNewCustomerDealPrice { get; set; }

        /// <summary>
        /// 上月新客客单价
        /// </summary>
        public decimal LastMonthNewCustomerUnitPrice { get; set; }


        /// <summary>
        /// 上月老客上门数
        /// </summary>

        public int LastMonthOldCustomerVisitNum { get; set; }

        /// <summary>
        /// 上月老客成交数
        /// </summary>

        public int LastMonthOldCustomerDealNum { get; set; }

        /// <summary>
        /// 上月老客成交率
        /// </summary>
        public decimal LastMonthOldCustomerDealRate { get; set; }

        /// <summary>
        /// 上月老客业绩
        /// </summary>

        public int LastMonthOldCustomerDealPrice { get; set; }

        /// <summary>
        /// 上月老客客单价
        /// </summary>
        public decimal LastMonthOldCustomerUnitPrice { get; set; }

        /// <summary>
        /// 上月老客业绩占比
        /// </summary>
        public decimal LastMonthOldCustomerAchievementRate { get; set; }

        /// <summary>
        /// 上月总业绩
        /// </summary>
        public decimal LasttMonthTotalAchievement { get; set; }

        #endregion

        #region 前月数据

        /// <summary>
        /// 前月派单数
        /// </summary>
        public int BeforeMonthSendOrderNum { get; set; }
        /// <summary>
        /// 前月新客前门数
        /// </summary>

        public int BeforeMonthNewCustomerVisitNum { get; set; }

        /// <summary>
        /// 前月新客前门率
        /// </summary>
        public decimal BeforeMonthNewCustomerVisitRate { get; set; }

        /// <summary>
        /// 前月新客成交数
        /// </summary>

        public int BeforeMonthNewCustomerDealNum { get; set; }

        /// <summary>
        /// 前月新客成交率
        /// </summary>
        public decimal BeforeMonthNewCustomerDealRate { get; set; }

        /// <summary>
        /// 前月新客业绩
        /// </summary>

        public int BeforeMonthNewCustomerDealPrice { get; set; }

        /// <summary>
        /// 前月新客客单价
        /// </summary>
        public decimal BeforeMonthNewCustomerUnitPrice { get; set; }


        /// <summary>
        /// 前月老客前门数
        /// </summary>

        public int BeforeMonthOldCustomerVisitNum { get; set; }

        /// <summary>
        /// 前月老客成交数
        /// </summary>

        public int BeforeMonthOldCustomerDealNum { get; set; }

        /// <summary>
        /// 前月老客成交率
        /// </summary>
        public decimal BeforeMonthOldCustomerDealRate { get; set; }

        /// <summary>
        /// 前月老客业绩
        /// </summary>

        public int BeforeMonthOldCustomerDealPrice { get; set; }

        /// <summary>
        /// 前月老客客单价
        /// </summary>
        public decimal BeforeMonthOldCustomerUnitPrice { get; set; }

        /// <summary>
        /// 前月老客业绩占比
        /// </summary>
        public decimal BeforeMonthOldCustomerAchievementRate { get; set; }

        /// <summary>
        /// 前月总业绩
        /// </summary>
        public decimal BeforeMonthTotalAchievement { get; set; }
        #endregion

        #region 环比

        /// <summary>
        /// 环比派单数
        /// </summary>
        public int ChainRatioMonthSendOrderNum { get; set; }
        /// <summary>
        /// 环比新客前门数
        /// </summary>

        public int ChainRatioMonthNewCustomerVisitNum { get; set; }

        /// <summary>
        /// 环比新客前门率
        /// </summary>
        public decimal ChainRatioMonthNewCustomerVisitRate { get; set; }

        /// <summary>
        /// 环比新客成交数
        /// </summary>

        public int ChainRatioMonthNewCustomerDealNum { get; set; }

        /// <summary>
        /// 环比新客成交率
        /// </summary>
        public decimal ChainRatioMonthNewCustomerDealRate { get; set; }

        /// <summary>
        /// 环比新客业绩
        /// </summary>

        public int ChainRatioMonthNewCustomerDealPrice { get; set; }

        /// <summary>
        /// 环比新客客单价
        /// </summary>
        public decimal ChainRatioMonthNewCustomerUnitPrice { get; set; }


        /// <summary>
        /// 环比老客前门数
        /// </summary>

        public int ChainRatioMonthOldCustomerVisitNum { get; set; }

        /// <summary>
        /// 环比老客成交数
        /// </summary>

        public int ChainRatioMonthOldCustomerDealNum { get; set; }

        /// <summary>
        /// 环比老客成交率
        /// </summary>
        public decimal ChainRatioMonthOldCustomerDealRate { get; set; }

        /// <summary>
        /// 环比老客业绩
        /// </summary>

        public int ChainRatioMonthOldCustomerDealPrice { get; set; }

        /// <summary>
        /// 环比老客客单价
        /// </summary>
        public decimal ChainRatioMonthOldCustomerUnitPrice { get; set; }

        /// <summary>
        /// 环比老客业绩占比
        /// </summary>
        public decimal ChainRatioMonthOldCustomerAchievementRate { get; set; }

        /// <summary>
        /// 环比总业绩
        /// </summary>
        public decimal ChainRatioMonthTotalAchievement { get; set; }
        #endregion
    }
}
