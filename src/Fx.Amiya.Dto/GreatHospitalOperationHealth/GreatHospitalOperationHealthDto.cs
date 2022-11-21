﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GreatHospitalOperationHealth
{
    public class GreatHospitalOperationHealthDto:BaseDto
    {

        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 归属指标id
        /// </summary>
        public string IndicatorId { get; set; }

        /// <summary>
        /// 归属指标名称
        /// </summary>
        public string IndicatorsName { get; set; }
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
        /// <summary>
        /// 前月老客复购率
        /// </summary>
        public decimal LastOldCustomerRepurchaseRate { get; set; }
        /// <summary>
        /// 上月老客复购率
        /// </summary>
        public decimal ThisOldCustomerRepurchaseRate { get; set; }
        /// <summary>
        /// 老客复购率环比
        /// </summary>
        public decimal OldCustomerRepurchaseChainRatio { get; set; }

        /// <summary>
        /// 前月老客客单价
        /// </summary>
        public decimal LastOldCustomerUnitPrice { get; set; }
        /// <summary>
        /// 上月老客客单价
        /// </summary>
        public decimal ThisOldCustomerUnitPrice { get; set; }
        /// <summary>
        /// 老客客单价环比
        /// </summary>
        public decimal OldCustomerUnitPriceChainRatio { get; set; }
    }
}
