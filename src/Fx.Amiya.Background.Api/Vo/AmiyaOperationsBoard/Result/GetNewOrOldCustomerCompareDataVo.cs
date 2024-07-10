﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class GetNewOrOldCustomerCompareDataVo
    {


        /// <summary>
        /// 整体流量分析-部门
        /// </summary>
        public OperationBoardBelongChannelPerformanceDataVo TotalBelongChannelPerformance { get; set; }
        /// <summary>
        /// 刀刀组流量分析-部门
        /// </summary>
        public OperationBoardBelongChannelPerformanceDataVo GroupDaoDaoBelongChannelPerformance { get; set; }
        /// <summary>
        /// 吉娜组流量分析-部门
        /// </summary>
        public OperationBoardBelongChannelPerformanceDataVo GroupJiNaBelongChannelPerformance { get; set; }

        /// <summary>
        /// 整体流量分析-新老客
        /// </summary>
        public OperationBoardGetNewOrOldCustomerCompareDataDetailsVo TotalNewOrOldCustomer { get; set; }
        /// <summary>
        /// 刀刀组流量分析-新老客
        /// </summary>
        public OperationBoardGetNewOrOldCustomerCompareDataDetailsVo GroupDaoDaoNewOrOldCustomer { get; set; }
        /// <summary>
        /// 吉娜组流量分析-新老客
        /// </summary>
        public OperationBoardGetNewOrOldCustomerCompareDataDetailsVo GroupJiNaNewOrOldCustomer { get; set; }


        /// <summary>
        /// 整体流量分析-有效/潜在
        /// </summary>
        public OperationBoardGetIsEffictivePerformanceVo TotalIsEffictivePerformance { get; set; }
        /// <summary>
        /// 刀刀组流量分析-有效/潜在
        /// </summary>
        public OperationBoardGetIsEffictivePerformanceVo GroupDaoDaoIsEffictivePerformance { get; set; }
        /// <summary>
        /// 吉娜组流量分析-有效/潜在
        /// </summary>
        public OperationBoardGetIsEffictivePerformanceVo GroupJiNaIsEffictivePerformance { get; set; }


        /// <summary>
        /// 整体流量分析-当月/历史
        /// </summary>
        public OperationBoardGetIsHistoryPerformanceVo TotalIsHistoryPerformance { get; set; }
        /// <summary>
        /// 刀刀组流量分析-当月/历史
        /// </summary>
        public OperationBoardGetIsHistoryPerformanceVo GroupDaoDaoIsHistoryPerformance { get; set; }
        /// <summary>
        /// 吉娜组流量分析-当月/历史
        /// </summary>
        public OperationBoardGetIsHistoryPerformanceVo GroupJiNaIsHistoryPerformance { get; set; }
    }
    /// <summary>
    /// 新老客占比
    /// </summary>
    public class OperationBoardGetNewOrOldCustomerCompareDataDetailsVo
    {

        /// <summary>
        /// 新客占比
        /// </summary>
        public decimal? TotalPerformanceNewCustomerRate { get; set; }

        /// <summary>
        /// 老客占比
        /// </summary>
        public decimal? TotalPerformanceOldCustomerRate { get; set; }

        /// <summary>
        /// 新客数值
        /// </summary>
        public decimal? TotalPerformanceNewCustomerNumber { get; set; }

        /// <summary>
        /// 老客数值
        /// </summary>
        public decimal? TotalPerformanceOldCustomerNumber { get; set; }

        /// <summary>
        /// 总业绩数值
        /// </summary>
        public decimal? TotalPerformanceNumber { get; set; }


    }
    /// <summary>
    /// 部门占比
    /// </summary>
    public class OperationBoardBelongChannelPerformanceDataVo
    {
        /// <summary>
        /// 直播前（占比）
        /// </summary>
        public decimal? BeforeLivingRate { get; set; }
        /// <summary>
        /// 直播中（占比）
        /// </summary>
        public decimal? LivingRate { get; set; }

        /// <summary>
        /// 直播后（占比）
        /// </summary>
        public decimal? AfterLivingRate { get; set; }

        /// <summary>
        /// 其他（占比）
        /// </summary>
        public decimal? OtherRate { get; set; }
        /// <summary>
        /// 直播前（数值）
        /// </summary>
        public decimal? BeforeLivingNumber { get; set; }
        /// <summary>
        /// 直播中（数值）
        /// </summary>
        public decimal? LivingNumber { get; set; }

        /// <summary>
        /// 直播后（数值）
        /// </summary>
        public decimal? AfterLivingNumber { get; set; }

        /// <summary>
        /// 其他（数值）
        /// </summary>
        public decimal? OtherNumber { get; set; }
        /// <summary>
        /// 总业绩数值
        /// </summary>
        public decimal? TotalPerformanceNumber { get; set; }
    }
    /// <summary>
    /// 当月/历史占比
    /// </summary>
    public class OperationBoardGetIsHistoryPerformanceVo
    {
        /// <summary>
        /// 当月数值
        /// </summary>
        public decimal? ThisMonthPerformanceNumber { get; set; }
        /// <summary>
        /// 当月占比
        /// </summary>
        public decimal? ThisMonthPerformanceRate { get; set; }

        /// <summary>
        /// 历史数值
        /// </summary>
        public decimal? HistoryPerformanceNumber { get; set; }

        /// <summary>
        /// 历史占比
        /// </summary>
        public decimal? HistoryPerformanceRate { get; set; }
        /// <summary>
        /// 总业绩数值
        /// </summary>
        public decimal? TotalPerformanceNumber { get; set; }
    }


    /// <summary>
    /// 有效/潜在占比
    /// </summary>
    public class OperationBoardGetIsEffictivePerformanceVo
    {
        /// <summary>
        /// 有效数值
        /// </summary>
        public decimal? EffictivePerformanceNumber { get; set; }
        /// <summary>
        /// 有效占比
        /// </summary>
        public decimal? EffictivePerformanceRate { get; set; }

        /// <summary>
        /// 潜在数值
        /// </summary>
        public decimal? NotEffictivePerformanceNumber { get; set; }

        /// <summary>
        /// 潜在占比
        /// </summary>
        public decimal? NotEffictivePerformanceRate { get; set; }
        /// <summary>
        /// 总业绩数值
        /// </summary>
        public decimal? TotalPerformanceNumber { get; set; }
    }


}
