using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.Dto.ShoppingCartRegistration;
using Fx.Amiya.IService;
using jos_sdk_net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class AmiyaPerformanceService : IAmiyaPerformanceService
    {
        private readonly ILiveAnchorMonthlyTargetService liveAnchorMonthlyTargetService;
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private readonly ILiveAnchorBaseInfoService liveAnchorBaseInfoService;
        private readonly ILiveAnchorService liveAnchorService;
        private readonly IShoppingCartRegistrationService shoppingCartRegistrationService;
        private readonly IAmiyaEmployeeService amiyaEmployeeService;

        public AmiyaPerformanceService(ILiveAnchorMonthlyTargetService liveAnchorMonthlyTargetService,
            IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService,
            ILiveAnchorService liveAnchorService,
            ILiveAnchorBaseInfoService liveAnchorBaseInfoService,
            IShoppingCartRegistrationService shoppingCartRegistrationService,
            IAmiyaEmployeeService amiyaEmployeeService)
        {
            this.liveAnchorMonthlyTargetService = liveAnchorMonthlyTargetService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.liveAnchorBaseInfoService = liveAnchorBaseInfoService;
            this.liveAnchorService = liveAnchorService;
            this.shoppingCartRegistrationService = shoppingCartRegistrationService;
            this.amiyaEmployeeService = amiyaEmployeeService;
        }

        #region 【啊美雅业绩】

        /// <summary>
        /// 啊美雅业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<MonthPerformanceRatioDto> GetMonthPerformanceAndRation(int year, int month)
        {
            List<int> liveAnchorIds = new List<int>();
            var order = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month, null, liveAnchorIds);
            #region 总业绩
            var curTotalPerformance = order.Sum(o => o.Price);
            var orderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, null, liveAnchorIds);
            var totalPerformanceYearOnYear = orderYearOnYear.Sum(o => o.Price);

            List<ContentPlatFormOrderDealInfoDto> orderChain = null;
            if (month == 1)
            {
                orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, null, liveAnchorIds);
            }
            else
            {
                orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, null, liveAnchorIds);
            }
            var totalPerformanceChainRatio = orderChain.Sum(o => o.Price);
            #endregion


            #region 新客业绩
            var curNewCustomer = order.Where(o => o.IsOldCustomer == false).Sum(o => o.Price);
            var newOrderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, false, liveAnchorIds);
            var newPerformanceYearOnYear = newOrderYearOnYear.Sum(o => o.Price);
            List<ContentPlatFormOrderDealInfoDto> newOrderChainRatio = null;
            if (month == 1)
            {
                newOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, false, liveAnchorIds);
            }
            else
            {
                newOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, false, liveAnchorIds);
            }
            var newPerformanceChainRatio = newOrderChainRatio.Sum(o => o.Price);
            #endregion


            #region 老客业绩
            var curOldCustomer = order.Where(o => o.IsOldCustomer == true).Sum(o => o.Price);

            var oldOrderYearOnYearr = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, true, liveAnchorIds);
            var oldPerformanceYearOnYear = oldOrderYearOnYearr.Sum(o => o.Price);
            List<ContentPlatFormOrderDealInfoDto> oldOrderChainRatio = null;
            if (month == 1)
            {
                oldOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, true, liveAnchorIds);
            }
            else
            {
                oldOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, true, liveAnchorIds);
            }
            var oldPerformanceRatio = oldOrderChainRatio.Sum(o => o.Price);
            #endregion


            #region 带货业绩
            List<int> LiveAnchorInfo = new List<int>();
            var target = await liveAnchorMonthlyTargetService.GetPerformance(year, month, LiveAnchorInfo);
            var commercePerformanceYearOnYear = await liveAnchorMonthlyTargetService.GetPerformance(year - 1, month, LiveAnchorInfo);
            LiveAnchorMonthTargetPerformanceDto liveAnchorMonthTargetPerformanceDto = new LiveAnchorMonthTargetPerformanceDto();
            if (month == 1)
            {
                liveAnchorMonthTargetPerformanceDto = await liveAnchorMonthlyTargetService.GetPerformance(year - 1, 12, LiveAnchorInfo);
            }
            else
            {
                liveAnchorMonthTargetPerformanceDto = await liveAnchorMonthlyTargetService.GetPerformance(year, month - 1, LiveAnchorInfo);
            }
            #endregion


            MonthPerformanceRatioDto monthPerformanceRatioDto = new MonthPerformanceRatioDto
            {
                CueerntMonthTotalPerformance = curTotalPerformance + target.CommerceCompletePerformance,
                CurrentMonthNewCustomerPerformance = curNewCustomer,
                CurrentMonthOldCustomerPerformance = curOldCustomer,
                CurrentMonthCommercePerformance = target.CommerceCompletePerformance,
                TotalPerformanceYearOnYear = CalculateYearOnYear(curTotalPerformance + target.CommerceCompletePerformance, totalPerformanceYearOnYear + commercePerformanceYearOnYear.CommerceCompletePerformance),
                TotalPerformanceChainratio = CalculateChainratio(curTotalPerformance + target.CommerceCompletePerformance, totalPerformanceChainRatio + liveAnchorMonthTargetPerformanceDto.CommerceCompletePerformance),
                TotalPerformanceTargetComplete = CalculateTargetComplete(curTotalPerformance + target.CommerceCompletePerformance, target.CommercePerformanceTarget + target.TotalPerformanceTarget),
                NewCustomerPerformanceYearOnYear = CalculateYearOnYear(curNewCustomer, newPerformanceYearOnYear),
                NewCustomerPerformanceChainRatio = CalculateChainratio(curNewCustomer, newPerformanceChainRatio),
                NewCustomerPerformanceTargetComplete = CalculateTargetComplete(curNewCustomer, target.NewCustomerPerformanceTarget),
                OldCustomerPerformanceYearOnYear = CalculateYearOnYear(curOldCustomer, oldPerformanceYearOnYear),
                OldCustomerPerformanceChainRatio = CalculateChainratio(curOldCustomer, oldPerformanceRatio),
                OldCustomerTargetComplete = CalculateTargetComplete(curOldCustomer, target.OldCustomerPerformanceTarget),
                CommercePerformanceYearOnYear = CalculateYearOnYear(target.CommerceCompletePerformance, commercePerformanceYearOnYear.CommerceCompletePerformance),
                CommercePerformanceChainRatio = CalculateChainratio(target.CommerceCompletePerformance, liveAnchorMonthTargetPerformanceDto.CommerceCompletePerformance),
                CommercePerformanceTargetComplete = CalculateTargetComplete(target.CommerceCompletePerformance, target.CommercePerformanceTarget),
                NewCustomerPerformanceRatio = CalculateTargetComplete(curNewCustomer, curTotalPerformance + target.CommerceCompletePerformance),
                OldCustomerPerformanceRatio = CalculateTargetComplete(curOldCustomer, curTotalPerformance + target.CommerceCompletePerformance),
                CommercePerformanceRatio = CalculateTargetComplete(target.CommerceCompletePerformance, curTotalPerformance + target.CommerceCompletePerformance)
            };


            return monthPerformanceRatioDto;
        }

        /// <summary>
        /// 派单成交业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<MonthDealPerformanceDto> GetMonthDealPerformanceAsync(int year, int month)
        {
            MonthDealPerformanceDto monthPerformanceDto = new MonthDealPerformanceDto();

            List<int> liveanchorIds = new List<int>();
            #region 【当月派单当月成交数据】
            var thisMonthSendOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month, false, liveanchorIds);
            //当月派单当月成交
            monthPerformanceDto.ThisMonthSendOrderDealPrice = thisMonthSendOrder.Sum(x => x.Price);

            List<ContentPlatFormOrderDealInfoDto> lastThisMonthOrder = null;
            if (month == 1)
            {
                lastThisMonthOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, 12, false, liveanchorIds);
            }
            else
            {
                lastThisMonthOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month - 1, false, liveanchorIds);
            }
            //上月的当月派单当月成交
            var lastMonthTotalPerformance = lastThisMonthOrder.Sum(o => o.Price);
            monthPerformanceDto.LastMonthTotalPerformance = CalculateChainratio(monthPerformanceDto.ThisMonthSendOrderDealPrice, lastMonthTotalPerformance);
            //上年的当月派单当月成交
            var lastYearOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, month, false, liveanchorIds);
            var lastYearTotalPerformance = lastYearOrder.Sum(o => o.Price);
            monthPerformanceDto.LastYearTotalPerformance = CalculateYearOnYear(monthPerformanceDto.ThisMonthSendOrderDealPrice, lastYearTotalPerformance);

            #endregion

            #region 【历史派单当月成交数据】
            var historyMonthSendOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month, true, liveanchorIds);
            //历史派单当月成交
            monthPerformanceDto.HistoryMonthSendOrderDealPrice = historyMonthSendOrder.Sum(x => x.Price);
            List<ContentPlatFormOrderDealInfoDto> lastHisToryMonthOrder = null;
            if (month == 1)
            {
                lastHisToryMonthOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, 12, true, liveanchorIds);
            }
            else
            {
                lastHisToryMonthOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month - 1, true, liveanchorIds);
            }
            //上月的历史派单当月成交
            var lastMonthHistorySendTotalPerformance = lastHisToryMonthOrder.Sum(o => o.Price);
            monthPerformanceDto.LastMonthHistorySendTotalPerformance = CalculateChainratio(monthPerformanceDto.HistoryMonthSendOrderDealPrice, lastMonthHistorySendTotalPerformance);

            //上年的历史派单当月成交
            var lastYearHistorySendOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, month, true, liveanchorIds);
            var lastYearHistorySendTotalPerformance = lastYearHistorySendOrder.Sum(o => o.Price);
            monthPerformanceDto.LastYearHistorySendTotalPerformance = CalculateYearOnYear(monthPerformanceDto.HistoryMonthSendOrderDealPrice, lastYearHistorySendTotalPerformance);
            #endregion

            monthPerformanceDto.AccountedForDuringMonthSendDuringMonthDealDetails = CalculateTargetComplete(monthPerformanceDto.ThisMonthSendOrderDealPrice, monthPerformanceDto.ThisMonthSendOrderDealPrice + monthPerformanceDto.HistoryMonthSendOrderDealPrice);

            monthPerformanceDto.AccountedForHistorySendDuringMonthDealDetails = CalculateTargetComplete(monthPerformanceDto.HistoryMonthSendOrderDealPrice, monthPerformanceDto.ThisMonthSendOrderDealPrice + monthPerformanceDto.HistoryMonthSendOrderDealPrice);
            return monthPerformanceDto;

        }

        /// <summary>
        /// 总业绩中的分组业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<GroupPerformanceDto> GetGroupPerformanceAsync(int year, int month)
        {
            GroupPerformanceDto groupPerformanceDto = new GroupPerformanceDto();

            #region 【刀刀组业绩】
            var liveAnchorDaoDaoBaseInfo = await liveAnchorBaseInfoService.GetByNameAsync("刀刀");

            var groupDaoDaoPerformance = await liveAnchorMonthlyTargetService.GetLiveAnchorBaseIdPerformance(year, month, liveAnchorDaoDaoBaseInfo.Id);
            //本月量
            groupPerformanceDto.GroupDaoDaoPerformance = groupDaoDaoPerformance.GroupPerformance;
            //同比
            var groupDaoDaoPerformanceYearToYear = await liveAnchorMonthlyTargetService.GetLiveAnchorBaseIdPerformance(year - 1, month, liveAnchorDaoDaoBaseInfo.Id);
            groupPerformanceDto.GroupDaoDaoPerformanceYearOnYear = CalculateYearOnYear(groupDaoDaoPerformance.GroupPerformance, groupDaoDaoPerformanceYearToYear.GroupPerformance);
            //环比
            GroupPerformanceListDto monthGroupDaodaoPerformance = new GroupPerformanceListDto();
            if (month == 1)
            {
                monthGroupDaodaoPerformance = await liveAnchorMonthlyTargetService.GetLiveAnchorBaseIdPerformance(year - 1, 12, liveAnchorDaoDaoBaseInfo.Id);
            }
            else
            {
                monthGroupDaodaoPerformance = await liveAnchorMonthlyTargetService.GetLiveAnchorBaseIdPerformance(year, month - 1, liveAnchorDaoDaoBaseInfo.Id);
            }
            groupPerformanceDto.GroupDaoDaoPerformanceChainRatio = CalculateChainratio(groupDaoDaoPerformance.GroupPerformance, monthGroupDaodaoPerformance.GroupPerformance);
            //目标达成
            groupPerformanceDto.GroupDaoDaoPerformanceCompleteRate = CalculateTargetComplete(groupDaoDaoPerformance.GroupPerformance, groupDaoDaoPerformance.GroupTargetPerformance);

            #endregion

            #region 【吉娜组业绩】
            var liveAnchorJinaBaseInfo = await liveAnchorBaseInfoService.GetByNameAsync("吉娜");

            var groupJinaPerformance = await liveAnchorMonthlyTargetService.GetLiveAnchorBaseIdPerformance(year, month, liveAnchorJinaBaseInfo.Id);
            //本月量
            groupPerformanceDto.GroupJinaPerformance = groupJinaPerformance.GroupPerformance;
            //同比
            var groupJinaPerformanceYearToYear = await liveAnchorMonthlyTargetService.GetLiveAnchorBaseIdPerformance(year - 1, month, liveAnchorJinaBaseInfo.Id);
            groupPerformanceDto.GroupJinaPerformanceYearOnYear = CalculateYearOnYear(groupJinaPerformance.GroupPerformance, groupJinaPerformanceYearToYear.GroupPerformance);
            //环比
            GroupPerformanceListDto monthGroupJinaPerformance = new GroupPerformanceListDto();
            if (month == 1)
            {
                monthGroupJinaPerformance = await liveAnchorMonthlyTargetService.GetLiveAnchorBaseIdPerformance(year - 1, 12, liveAnchorJinaBaseInfo.Id);
            }
            else
            {
                monthGroupJinaPerformance = await liveAnchorMonthlyTargetService.GetLiveAnchorBaseIdPerformance(year, month - 1, liveAnchorJinaBaseInfo.Id);
            }
            groupPerformanceDto.GroupJinaPerformanceChainRatio = CalculateChainratio(groupJinaPerformance.GroupPerformance, monthGroupJinaPerformance.GroupPerformance);
            //目标达成
            groupPerformanceDto.GroupJinaPerformanceCompleteRate = CalculateTargetComplete(groupJinaPerformance.GroupPerformance, groupJinaPerformance.GroupTargetPerformance);

            #endregion

            #region 【合作达人业绩】
            var cooperationLiveAnchorPerformance = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year, month, "d2e71501-7327-4883-9294-371a77c4cabd");
            //本月量
            groupPerformanceDto.CooperationLiveAnchorPerformance = cooperationLiveAnchorPerformance.GroupPerformance;
            //同比
            var cooperationLiveAnchorPerformanceYearToYear = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year - 1, month, "d2e71501-7327-4883-9294-371a77c4cabd");
            groupPerformanceDto.CooperationLiveAnchorPerformanceYearOnYear = CalculateYearOnYear(cooperationLiveAnchorPerformance.GroupPerformance, cooperationLiveAnchorPerformanceYearToYear.GroupPerformance);
            //环比
            GroupPerformanceListDto monthCooperationLiveAnchorPerformance = new GroupPerformanceListDto();
            if (month == 1)
            {
                monthCooperationLiveAnchorPerformance = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year - 1, 12, "d2e71501-7327-4883-9294-371a77c4cabd");
            }
            else
            {
                monthCooperationLiveAnchorPerformance = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year, month - 1, "d2e71501-7327-4883-9294-371a77c4cabd");
            }
            groupPerformanceDto.CooperationLiveAnchorPerformanceChainRatio = CalculateChainratio(cooperationLiveAnchorPerformance.GroupPerformance, monthCooperationLiveAnchorPerformance.GroupPerformance);
            //目标达成
            groupPerformanceDto.CooperationLiveAnchorPerformanceCompleteRate = CalculateTargetComplete(cooperationLiveAnchorPerformance.GroupPerformance, cooperationLiveAnchorPerformance.GroupTargetPerformance);
            #endregion

            #region 【黄V组业绩】
            var groupYellowVPerformance = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year, month, "2bd8b9ad-afd7-4982-b783-fcad7d342f11");
            //本月量
            groupPerformanceDto.GroupYellowVPerformance = groupYellowVPerformance.GroupPerformance;
            //同比
            var groupYellowVPerformanceYearToYear = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year - 1, month, "2bd8b9ad-afd7-4982-b783-fcad7d342f11");
            groupPerformanceDto.GroupYellowVPerformanceYearOnYear = CalculateYearOnYear(groupYellowVPerformance.GroupPerformance, groupYellowVPerformanceYearToYear.GroupPerformance);
            //环比
            GroupPerformanceListDto monthGroupYellowVPerformance = new GroupPerformanceListDto();
            if (month == 1)
            {
                monthGroupYellowVPerformance = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year - 1, 12, "2bd8b9ad-afd7-4982-b783-fcad7d342f11");
            }
            else
            {
                monthGroupYellowVPerformance = await liveAnchorMonthlyTargetService.GetCooperationLiveAnchorPerformance(year, month - 1, "2bd8b9ad-afd7-4982-b783-fcad7d342f11");
            }
            groupPerformanceDto.GroupYellowVPerformanceChainRatio = CalculateChainratio(groupYellowVPerformance.GroupPerformance, monthGroupYellowVPerformance.GroupPerformance);
            //目标达成
            groupPerformanceDto.GroupYellowVPerformanceCompleteRate = CalculateTargetComplete(groupYellowVPerformance.GroupPerformance, groupYellowVPerformance.GroupTargetPerformance);
            #endregion

            //各分组业绩占比
            decimal sumPerformance = groupPerformanceDto.GroupDaoDaoPerformance.Value + groupPerformanceDto.GroupJinaPerformance.Value + groupPerformanceDto.CooperationLiveAnchorPerformance.Value + groupPerformanceDto.GroupYellowVPerformance.Value;
            groupPerformanceDto.AccountedForGroupDaoDaoPerformance = CalculateTargetComplete(groupPerformanceDto.GroupDaoDaoPerformance.Value, sumPerformance);


            groupPerformanceDto.AccountedForGroupJinaPerformance = CalculateTargetComplete(groupPerformanceDto.GroupJinaPerformance.Value, sumPerformance);


            groupPerformanceDto.AccountedForCooperationLiveAnchorPerformance = CalculateTargetComplete(groupPerformanceDto.CooperationLiveAnchorPerformance.Value, sumPerformance);


            groupPerformanceDto.AccountedForGroupYellowVPerformance = CalculateTargetComplete(groupPerformanceDto.GroupYellowVPerformance.Value, sumPerformance);

            return groupPerformanceDto;

        }

     

        #endregion

        #region 【分组业绩】


        /// <summary>
        /// 分组总业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        public async Task<MonthPerformanceRatioDto> GetByLiveAnchorPerformanceAsync(int year, int month, string liveAnchorName)
        {
            //获取各个平台的主播ID
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            var order = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month, null, LiveAnchorInfo);
            #region 总业绩
            var curTotalPerformance = order.Sum(o => o.Price);
            var orderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, null, LiveAnchorInfo);
            var totalPerformanceYearOnYear = orderYearOnYear.Sum(o => o.Price);

            List<ContentPlatFormOrderDealInfoDto> orderChain = null;
            if (month == 1)
            {
                orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, null, LiveAnchorInfo);
            }
            else
            {
                orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, null, LiveAnchorInfo);
            }
            var totalPerformanceChainRatio = orderChain.Sum(o => o.Price);
            #endregion


            #region 新客业绩
            var curNewCustomer = order.Where(o => o.IsOldCustomer == false).Sum(o => o.Price);
            var newOrderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, false, LiveAnchorInfo);
            var newPerformanceYearOnYear = newOrderYearOnYear.Sum(o => o.Price);
            List<ContentPlatFormOrderDealInfoDto> newOrderChainRatio = null;
            if (month == 1)
            {
                newOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, false, LiveAnchorInfo);
            }
            else
            {
                newOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, false, LiveAnchorInfo);
            }
            var newPerformanceChainRatio = newOrderChainRatio.Sum(o => o.Price);
            #endregion


            #region 老客业绩
            var curOldCustomer = order.Where(o => o.IsOldCustomer == true).Sum(o => o.Price);

            var oldOrderYearOnYearr = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, true, LiveAnchorInfo);
            var oldPerformanceYearOnYear = oldOrderYearOnYearr.Sum(o => o.Price);
            List<ContentPlatFormOrderDealInfoDto> oldOrderChainRatio = null;
            if (month == 1)
            {
                oldOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, true, LiveAnchorInfo);
            }
            else
            {
                oldOrderChainRatio = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, true, LiveAnchorInfo);
            }
            var oldPerformanceRatio = oldOrderChainRatio.Sum(o => o.Price);
            #endregion


            #region 带货业绩
            var target = await liveAnchorMonthlyTargetService.GetPerformance(year, month, LiveAnchorInfo);
            var commercePerformanceYearOnYear = await liveAnchorMonthlyTargetService.GetPerformance(year - 1, month, LiveAnchorInfo);
            LiveAnchorMonthTargetPerformanceDto liveAnchorMonthTargetPerformanceDto = new LiveAnchorMonthTargetPerformanceDto();
            if (month == 1)
            {
                liveAnchorMonthTargetPerformanceDto = await liveAnchorMonthlyTargetService.GetPerformance(year - 1, 12, LiveAnchorInfo);
            }
            else
            {
                liveAnchorMonthTargetPerformanceDto = await liveAnchorMonthlyTargetService.GetPerformance(year, month - 1, LiveAnchorInfo);
            }
            #endregion


            MonthPerformanceRatioDto monthPerformanceRatioDto = new MonthPerformanceRatioDto
            {
                CueerntMonthTotalPerformance = curTotalPerformance + target.CommerceCompletePerformance,
                CurrentMonthNewCustomerPerformance = curNewCustomer,
                CurrentMonthOldCustomerPerformance = curOldCustomer,
                CurrentMonthCommercePerformance = target.CommerceCompletePerformance,
                TotalPerformanceYearOnYear = CalculateYearOnYear(curTotalPerformance + target.CommerceCompletePerformance, totalPerformanceYearOnYear + commercePerformanceYearOnYear.CommerceCompletePerformance),
                TotalPerformanceChainratio = CalculateChainratio(curTotalPerformance + target.CommerceCompletePerformance, totalPerformanceChainRatio + liveAnchorMonthTargetPerformanceDto.CommerceCompletePerformance),
                TotalPerformanceTargetComplete = CalculateTargetComplete(curTotalPerformance + target.CommerceCompletePerformance, target.CommercePerformanceTarget + target.TotalPerformanceTarget),
                NewCustomerPerformanceYearOnYear = CalculateYearOnYear(curNewCustomer, newPerformanceYearOnYear),
                NewCustomerPerformanceChainRatio = CalculateChainratio(curNewCustomer, newPerformanceChainRatio),
                NewCustomerPerformanceTargetComplete = CalculateTargetComplete(curNewCustomer, target.NewCustomerPerformanceTarget),
                OldCustomerPerformanceYearOnYear = CalculateYearOnYear(curOldCustomer, oldPerformanceYearOnYear),
                OldCustomerPerformanceChainRatio = CalculateChainratio(curOldCustomer, oldPerformanceRatio),
                OldCustomerTargetComplete = CalculateTargetComplete(curOldCustomer, target.OldCustomerPerformanceTarget),
                CommercePerformanceYearOnYear = CalculateYearOnYear(target.CommerceCompletePerformance, commercePerformanceYearOnYear.CommerceCompletePerformance),
                CommercePerformanceChainRatio = CalculateChainratio(target.CommerceCompletePerformance, liveAnchorMonthTargetPerformanceDto.CommerceCompletePerformance),
                CommercePerformanceTargetComplete = CalculateTargetComplete(target.CommerceCompletePerformance, target.CommercePerformanceTarget),
                NewCustomerPerformanceRatio = CalculateTargetComplete(curNewCustomer, curTotalPerformance + target.CommerceCompletePerformance),
                OldCustomerPerformanceRatio = CalculateTargetComplete(curOldCustomer, curTotalPerformance + target.CommerceCompletePerformance),
                CommercePerformanceRatio = CalculateTargetComplete(target.CommerceCompletePerformance, curTotalPerformance + target.CommerceCompletePerformance)
            };


            return monthPerformanceRatioDto;
        }

        /// <summary>
        /// 分组派单成交业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<MonthDealPerformanceDto> GetMonthDealPerformanceByLiveAnchorNameAsync(int year, int month, string liveAnchorName)
        {
            MonthDealPerformanceDto monthPerformanceDto = new MonthDealPerformanceDto();
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);

            #region 【当月派单当月成交数据】
            var thisMonthSendOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month, false, LiveAnchorInfo);
            //当月派单当月成交
            monthPerformanceDto.ThisMonthSendOrderDealPrice = thisMonthSendOrder.Sum(x => x.Price);

            List<ContentPlatFormOrderDealInfoDto> lastThisMonthOrder = null;
            if (month == 1)
            {
                lastThisMonthOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, 12, false, LiveAnchorInfo);
            }
            else
            {
                lastThisMonthOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month - 1, false, LiveAnchorInfo);
            }
            //上月的当月派单当月成交
            var lastMonthTotalPerformance = lastThisMonthOrder.Sum(o => o.Price);
            monthPerformanceDto.LastMonthTotalPerformance = CalculateChainratio(monthPerformanceDto.ThisMonthSendOrderDealPrice, lastMonthTotalPerformance);
            //上年的当月派单当月成交
            var lastYearOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, month, false, LiveAnchorInfo);
            var lastYearTotalPerformance = lastYearOrder.Sum(o => o.Price);
            monthPerformanceDto.LastYearTotalPerformance = CalculateYearOnYear(monthPerformanceDto.ThisMonthSendOrderDealPrice, lastYearTotalPerformance);

            #endregion

            #region 【历史派单当月成交数据】
            var historyMonthSendOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month, true, LiveAnchorInfo);
            //历史派单当月成交
            monthPerformanceDto.HistoryMonthSendOrderDealPrice = historyMonthSendOrder.Sum(x => x.Price);
            List<ContentPlatFormOrderDealInfoDto> lastHisToryMonthOrder = null;
            if (month == 1)
            {
                lastHisToryMonthOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, 12, true, LiveAnchorInfo);
            }
            else
            {
                lastHisToryMonthOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month - 1, true, LiveAnchorInfo);
            }
            //上月的历史派单当月成交
            var lastMonthHistorySendTotalPerformance = lastHisToryMonthOrder.Sum(o => o.Price);
            monthPerformanceDto.LastMonthHistorySendTotalPerformance = CalculateChainratio(monthPerformanceDto.HistoryMonthSendOrderDealPrice, lastMonthHistorySendTotalPerformance);

            //上年的历史派单当月成交
            var lastYearHistorySendOrder = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, month, true, LiveAnchorInfo);
            var lastYearHistorySendTotalPerformance = lastYearHistorySendOrder.Sum(o => o.Price);
            monthPerformanceDto.LastYearHistorySendTotalPerformance = CalculateYearOnYear(monthPerformanceDto.HistoryMonthSendOrderDealPrice, lastYearHistorySendTotalPerformance);
            #endregion

            monthPerformanceDto.AccountedForDuringMonthSendDuringMonthDealDetails = CalculateTargetComplete(monthPerformanceDto.ThisMonthSendOrderDealPrice, monthPerformanceDto.ThisMonthSendOrderDealPrice + monthPerformanceDto.HistoryMonthSendOrderDealPrice);

            monthPerformanceDto.AccountedForHistorySendDuringMonthDealDetails = CalculateTargetComplete(monthPerformanceDto.HistoryMonthSendOrderDealPrice, monthPerformanceDto.ThisMonthSendOrderDealPrice + monthPerformanceDto.HistoryMonthSendOrderDealPrice);
            return monthPerformanceDto;

        }


        /// <summary>
        /// 分组照片/视频面诊业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        public async Task<GroupVideoAndPicturePerformanceDto> GetShoppingCartPerformanceByLiveAnchorNameAsync(int year, int month, string liveAnchorName)
        {
            GroupVideoAndPicturePerformanceDto monthPerformanceDto = new GroupVideoAndPicturePerformanceDto();
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);

            #region 【照片面诊业绩】
            var picturePerformance = await shoppingCartRegistrationService.GetShoppingCartRegistrationListByLiveAnchorNameAndIsVideoAsync(year, month, false, LiveAnchorInfo);
            //照片面诊业绩
            monthPerformanceDto.PicturePerformance = picturePerformance.Count;

            List<ShoppingCartRegistrationDto> lastMonthPicturePerformance = null;
            if (month == 1)
            {
                lastMonthPicturePerformance = await shoppingCartRegistrationService.GetShoppingCartRegistrationListByLiveAnchorNameAndIsVideoAsync(year - 1, 12, false, LiveAnchorInfo);
            }
            else
            {
                lastMonthPicturePerformance = await shoppingCartRegistrationService.GetShoppingCartRegistrationListByLiveAnchorNameAndIsVideoAsync(year, month - 1, false, LiveAnchorInfo);
            }
            //上月的照片面诊业绩
            var lastMonthPictureTotalPerformance = lastMonthPicturePerformance.Count;
            monthPerformanceDto.LastMonthPicturePerformance = CalculateChainratio(monthPerformanceDto.PicturePerformance, lastMonthPictureTotalPerformance);
            //上年的照片面诊业绩
            var lastYearPicturePerformance = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, month, false, LiveAnchorInfo);
            var lastYearTotalPicturePerformance = lastYearPicturePerformance.Count;
            monthPerformanceDto.LastYearPicturePerformance = CalculateYearOnYear(monthPerformanceDto.PicturePerformance, lastYearTotalPicturePerformance);

            #endregion

            #region 【视频面诊业绩】
            var videoPerformance = await shoppingCartRegistrationService.GetShoppingCartRegistrationListByLiveAnchorNameAndIsVideoAsync(year, month, true, LiveAnchorInfo);
            //视频面诊业绩
            monthPerformanceDto.VideoPerformance = videoPerformance.Count;
            List<ShoppingCartRegistrationDto> lastMonthVideoPerformance = null;
            if (month == 1)
            {
                lastMonthVideoPerformance = await shoppingCartRegistrationService.GetShoppingCartRegistrationListByLiveAnchorNameAndIsVideoAsync(year - 1, 12, true, LiveAnchorInfo);
            }
            else
            {
                lastMonthVideoPerformance = await shoppingCartRegistrationService.GetShoppingCartRegistrationListByLiveAnchorNameAndIsVideoAsync(year, month - 1, true, LiveAnchorInfo);
            }
            //上月的视频面诊业绩
            var lastMonthVideoTotalPerformance = lastMonthVideoPerformance.Count;
            monthPerformanceDto.LastMonthVideoPerformance = CalculateChainratio(monthPerformanceDto.VideoPerformance, lastMonthVideoTotalPerformance);

            //上年的视频面诊业绩
            var lastYearVideoPerformance = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year - 1, month, false, LiveAnchorInfo);
            var lastYearTotalVideoPerformance = lastYearVideoPerformance.Count;
            monthPerformanceDto.LastYearVideoPerformance = CalculateYearOnYear(monthPerformanceDto.VideoPerformance, lastYearTotalVideoPerformance);
            #endregion

            monthPerformanceDto.AccountedForPicturePerformance = CalculateTargetComplete(monthPerformanceDto.PicturePerformance, monthPerformanceDto.PicturePerformance + monthPerformanceDto.VideoPerformance);

            monthPerformanceDto.AccountedForVideoPerformance = CalculateTargetComplete(monthPerformanceDto.VideoPerformance, monthPerformanceDto.PicturePerformance + monthPerformanceDto.VideoPerformance);
            return monthPerformanceDto;

        }

        /// <summary>
        /// 分组独立/协助业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        public async Task<IndependentOrAssistPerformanceDto> GetIndependentOrAssistByLiveAnchorPerformanceAsync(int year, int month, string liveAnchorName)
        {
            IndependentOrAssistPerformanceDto independentOrAssistPerformanceDto = new IndependentOrAssistPerformanceDto();
            //获取各个平台的主播ID
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            var employeeInfo = await amiyaEmployeeService.GetByNameAsync(liveAnchorName);

            #region 【主播独立业绩】
            var liveAnchorPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year, month, false, LiveAnchorInfo, employeeInfo.Id);
            //主播独立业绩
            independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformance = liveAnchorPerformance.Sum(x=>x.Price);

            List<ContentPlatFormOrderDealInfoDto> lastMonthLiveAnchorIndenpendentPerformance = null;
            if (month == 1)
            {
                lastMonthLiveAnchorIndenpendentPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year - 1, 12, false, LiveAnchorInfo, employeeInfo.Id);
            }
            else
            {
                lastMonthLiveAnchorIndenpendentPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year, month - 1, false, LiveAnchorInfo, employeeInfo.Id);
            }
            //上月的主播独立业绩
            var lastMonthLiveAnchorIndependentPerformance = lastMonthLiveAnchorIndenpendentPerformance.Sum(x=>x.Price);
            independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformanceChainRatio = CalculateChainratio(independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformance.Value, lastMonthLiveAnchorIndependentPerformance);
            //上年的主播独立业绩
            var lastYearLiveAnchorIndependentPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year, month, false, LiveAnchorInfo, employeeInfo.Id);
            var lastYearLiveAnchorIndependentTotalPerformance = lastYearLiveAnchorIndependentPerformance.Sum(x => x.Price);
            independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformanceYearOnYear = CalculateYearOnYear(independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformance.Value, lastYearLiveAnchorIndependentTotalPerformance);

            #endregion

            #region 【助理独立业绩】
            var customerServiceIndependentPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year, month, false, LiveAnchorInfo, 0);
            //助理独立业绩
            independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformance = customerServiceIndependentPerformance.Sum(x => x.Price);

            List<ContentPlatFormOrderDealInfoDto> lastMonthCustomerServiceIndenpendentPerformance = null;
            if (month == 1)
            {
                lastMonthCustomerServiceIndenpendentPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year - 1, 12, false, LiveAnchorInfo, 0);
            }
            else
            {
                lastMonthCustomerServiceIndenpendentPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year, month-1, false, LiveAnchorInfo, 0);
            }
            //上月的助理独立业绩
            var lastMonthCustomerServiceIndependentPerformance = lastMonthCustomerServiceIndenpendentPerformance.Sum(x => x.Price);
            independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformanceChainRatio = CalculateChainratio(independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformance.Value, lastMonthCustomerServiceIndependentPerformance);
            //上年的助理独立业绩
            var lastYearCustomerServiceIndependentPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year, month, false, LiveAnchorInfo, 0);
            var lastYearCustomerServiceTotalIndependentPerformance = lastYearCustomerServiceIndependentPerformance.Sum(x => x.Price);
            independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformanceYearOnYear = CalculateYearOnYear(independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformance.Value, lastYearCustomerServiceTotalIndependentPerformance);

            #endregion

            #region 【助理协助业绩】
            var customerServiceAssistPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year, month, true, LiveAnchorInfo, 0);
            //助理协助业绩
            independentOrAssistPerformanceDto.CustomerServiceAssistPerformance = customerServiceAssistPerformance.Sum(x => x.Price);

            List<ContentPlatFormOrderDealInfoDto> lastMonthCustomerServiceAssistPerformance = null;
            if (month == 1)
            {
                lastMonthCustomerServiceAssistPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year - 1, 12, true, LiveAnchorInfo, 0);
            }
            else
            {
                lastMonthCustomerServiceAssistPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year, month-1, true, LiveAnchorInfo, 0);
            }
            //上月的助理协助业绩
            var lastMonthCustomerServiceAssistTotalPerformance = lastMonthCustomerServiceAssistPerformance.Sum(x => x.Price);
            independentOrAssistPerformanceDto.CustomerServiceAssistPerformanceChainRatio = CalculateChainratio(independentOrAssistPerformanceDto.CustomerServiceAssistPerformance.Value, lastMonthCustomerServiceAssistTotalPerformance);
            //上年的助理协助业绩
            var lastYearCustomerServiceAssistPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year, month, true, LiveAnchorInfo, 0);
            var lastYearCustomerServiceAssistTotalPerformance = lastYearCustomerServiceAssistPerformance.Sum(x => x.Price);
            independentOrAssistPerformanceDto.CustomerServiceAssistPerformanceYearOnYear = CalculateYearOnYear(independentOrAssistPerformanceDto.CustomerServiceAssistPerformance.Value, lastYearCustomerServiceAssistTotalPerformance);

            #endregion


            independentOrAssistPerformanceDto.AccountForLiveAnchorIndenpendentPerformance = CalculateTargetComplete(independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformance.Value, independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformance.Value + independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformance.Value+ independentOrAssistPerformanceDto.CustomerServiceAssistPerformance.Value);

            independentOrAssistPerformanceDto.AccountForCustomerServiceIndenpendentPerformance = CalculateTargetComplete(independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformance.Value, independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformance.Value + independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformance.Value + independentOrAssistPerformanceDto.CustomerServiceAssistPerformance.Value);

            independentOrAssistPerformanceDto.AccountForCustomerServiceAssistPerformance = CalculateTargetComplete(independentOrAssistPerformanceDto.CustomerServiceAssistPerformance.Value, independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformance.Value + independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformance.Value + independentOrAssistPerformanceDto.CustomerServiceAssistPerformance.Value);


            return independentOrAssistPerformanceDto;
        }

        #endregion

        #region【公共使用业务，包括折线图，业绩明细等】
        /// <summary>
        /// 获取当月/历史派单当月成交折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetHistorySendThisMonthDealOrders(int year, int month, bool isOldSendOrder, string liveAnchorName)
        {
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            var brokenLine = await contentPlatFormOrderDealInfoService.GetHistoryAndThisMonthOrderPerformance(year, month, isOldSendOrder, LiveAnchorInfo);
            var list = brokenLine.ToList();
            return BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, list);

        }

        /// <summary>
        /// 根据主播平台获取折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="contentPlatFormId"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetLiveAnchorPerformanceAsync(int year, int month, string contentPlatFormId)
        {
            var brokenLine = await liveAnchorMonthlyTargetService.GetLiveAnchorPerformanceBrokenLineAsync(year, contentPlatFormId);
            var list = brokenLine.ToList();
            return BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, list);

        }


        /// <summary>
        /// 根据主播获取折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorBaseId"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetLiveAnchorPerformanceByBaseIdAsync(int year, int month, string liveAnchorBaseName)
        {
            var liveAnchorBaseInfo = await liveAnchorBaseInfoService.GetByNameAsync(liveAnchorBaseName);
            var brokenLine = await liveAnchorMonthlyTargetService.GetLiveAnchorPerformanceByBaseIdBrokenLineAsync(year, liveAnchorBaseInfo.Id);
            return BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, brokenLine);

        }
        /// <summary>
        /// 根据主播名称获取新/老客业绩数据折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isCustomer"></param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        public async Task<List<PerformanceInfoByDateDto>> GetNewOrOldPerformanceBrokenLineAsync(int year, int month, bool? isCustomer, string liveAnchorName)
        {
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            var brokenLine= await contentPlatFormOrderDealInfoService.GetPerformanceBrokenLineAsync(year, month, isCustomer, LiveAnchorInfo);
            return BreakLineClassUtil<PerformanceInfoByDateDto>.Convert(month, brokenLine);
        }

        /// <summary>
        /// 根据主播名称获取带货业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        public async Task<List<PerformanceInfoByDateDto>> GetLiveAnchorCommercePerformanceByLiveAnchorIdAsync(int year, int month, string liveAnchorName)
        {
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            var brokenLine= await liveAnchorMonthlyTargetService.GetLiveAnchorCommercePerformance(year, month, LiveAnchorInfo);
            return BreakLineClassUtil<PerformanceInfoByDateDto>.Convert(month, brokenLine);
        }

        /// <summary>
        /// 获取照片/视频面诊折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<List<PerformanceInfoByDateDto>> GetPictureOrVideoConsultationAsync(int year, int month, bool isVideo, string liveAnchorName)
        {
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            var brokenLine = await shoppingCartRegistrationService.GetPictureOrVideoConsultationBrokenLineAsync(year, month, isVideo, LiveAnchorInfo);
            return BreakLineClassUtil<PerformanceInfoByDateDto>.Convert(month, brokenLine);

        }
        /// <summary>
        ///  获取独立/协助业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="IsAssist">是否协助</param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <param name="isLiveAnchorIndependence">是否为主播独立</param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetIndependenceOrAssistAsync(int year, int month, bool IsAssist, string liveAnchorName, bool isLiveAnchorIndependence)
        {
            int empId = 0;
            if(isLiveAnchorIndependence==true)
            {
                var employeeInfo = await amiyaEmployeeService.GetByNameAsync(liveAnchorName);
                empId = employeeInfo.Id;
            }
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            var brokenLine = await contentPlatFormOrderDealInfoService.GetIndependenceOrAssistAsync(year, month, IsAssist, LiveAnchorInfo, empId);
            return BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, brokenLine);

        }

        /// <summary>
        /// 获取派单成交业绩明细
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldSend">历史/当月派单,true为历史派单当月成交，false为当月派单当月成交</param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderDealInfoDto>> GetSendAndDealPerformanceByYearAndMonthAndLiveAnchorNameAsync(int year, int month, bool? isOldSend, string liveAnchorName)
        {
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            return await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceByYearAndMonth(year, month, isOldSend, LiveAnchorInfo);
        }

        /// <summary>
        /// 获取照片/视频面诊明细
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isVideo"></param>
        /// <param name="LiveAnchorName"></param>
        /// <returns></returns>
        public async Task<List<ShoppingCartRegistrationDto>> GetPictureOrVideoConsultationByLiveAnchorAsync(int year, int month, bool isVideo, string LiveAnchorName)
        {
            var lliveanchorInfo = await this.GetLiveAnchorIdsByNameAsync(LiveAnchorName);
            return await shoppingCartRegistrationService.GetShoppingCartRegistrationListByLiveAnchorNameAndIsVideoAsync(year, month, isVideo, lliveanchorInfo);
        }
        #endregion

        #region  【内部方法】



        /// <summary>
        /// 计算同比增长率
        /// </summary>
        /// <param name="currentMonthPerformance">当前月业绩</param>
        /// <param name="performanceYearOnYear">同比业绩</param>
        /// <returns></returns>
        private decimal? CalculateYearOnYear(decimal currentMonthPerformance, decimal performanceYearOnYear)
        {
            if (performanceYearOnYear == 0m)
                return null;
            return Math.Round((currentMonthPerformance - performanceYearOnYear) / performanceYearOnYear * 100, 2);
        }
        /// <summary>
        /// 计算环比增长率
        /// </summary>
        /// <param name="currentMonthPerformance">当前月业绩</param>
        /// <param name="performanceChainRatio">环比业绩</param>
        /// <returns></returns>
        private decimal? CalculateChainratio(decimal currentMonthPerformance, decimal performanceChainRatio)
        {
            if (performanceChainRatio == 0m)
                return null;
            return Math.Round((currentMonthPerformance - performanceChainRatio) / performanceChainRatio * 100, 2);
        }
        /// <summary>
        /// 计算目标达成率
        /// </summary>
        /// <param name="completePerformance">已完成业绩</param>
        /// <param name="monthTarget">目标业绩</param>
        /// <returns></returns>
        private decimal? CalculateTargetComplete(decimal completePerformance, decimal monthTarget)
        {
            if (monthTarget == 0m)
                return null;
            return Math.Round(completePerformance / monthTarget * 100, 2);
        }

        /// <summary>
        /// 根据主播名称获取主播id集合
        /// </summary>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        private async Task<List<int>> GetLiveAnchorIdsByNameAsync(string liveAnchorName)
        {
            if (string.IsNullOrEmpty(liveAnchorName))
            { return new List<int>(); }
            List<int> LiveAnchorInfo = new List<int>();
            //获取主播基础信息id
            var liveAnchorBaseInfo = await liveAnchorBaseInfoService.GetByNameAsync(liveAnchorName);
            var liveanchorBaseId = liveAnchorBaseInfo.Id;
            if (liveanchorBaseId != null)
            {
                var liveAnchor = await liveAnchorService.GetValidListByLiveAnchorBaseIdAsync(liveanchorBaseId);
                LiveAnchorInfo = liveAnchor.Select(x => x.Id).ToList();
            }
            return LiveAnchorInfo;
        }

        #endregion
    }
}
