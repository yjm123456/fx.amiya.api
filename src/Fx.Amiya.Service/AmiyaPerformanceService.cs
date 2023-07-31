using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.FinancialBoard;
using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
using Fx.Amiya.Dto.OrderReport;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.Dto.Performance.BusinessWechatDto;
using Fx.Amiya.Dto.ShoppingCartRegistration;
using Fx.Amiya.IService;
using Fx.Common.Extensions;
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
        private readonly IHealthValueService healthValueService;
        private readonly ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService;
        private readonly ILiveAnchorMonthlyTargetAfterLivingService liveAnchorMonthlyTargetAfterLivingService;
        private readonly IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private readonly ILiveAnchorBaseInfoService liveAnchorBaseInfoService;
        private readonly ILiveAnchorService liveAnchorService;
        private readonly IShoppingCartRegistrationService shoppingCartRegistrationService;
        private readonly IAmiyaEmployeeService amiyaEmployeeService;
        private readonly IContentPlateFormOrderService contentPlateFormOrderService;

        public AmiyaPerformanceService(IHealthValueService healthValueService,
            IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService,
            ILiveAnchorService liveAnchorService,
            ILiveAnchorBaseInfoService liveAnchorBaseInfoService,
            ILiveAnchorMonthlyTargetAfterLivingService liveanchorMonthlyTargetAfterLivingService,
            ILiveAnchorMonthlyTargetLivingService liveAnchorMonthlyTargetLivingService,
            IShoppingCartRegistrationService shoppingCartRegistrationService,
            IAmiyaEmployeeService amiyaEmployeeService,
            IContentPlateFormOrderService contentPlateFormOrderService)
        {
            this.healthValueService = healthValueService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.liveAnchorBaseInfoService = liveAnchorBaseInfoService;
            this.liveAnchorMonthlyTargetAfterLivingService = liveanchorMonthlyTargetAfterLivingService;
            this.liveAnchorMonthlyTargetLivingService = liveAnchorMonthlyTargetLivingService;
            this.liveAnchorService = liveAnchorService;
            this.shoppingCartRegistrationService = shoppingCartRegistrationService;
            this.amiyaEmployeeService = amiyaEmployeeService;
            this.contentPlateFormOrderService = contentPlateFormOrderService;
        }

        //管理端

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
            var livingTarget = await liveAnchorMonthlyTargetLivingService.GetPerformance(year, month, LiveAnchorInfo);
            var afterLivingTarget = await liveAnchorMonthlyTargetAfterLivingService.GetPerformance(year, month, LiveAnchorInfo);
            var commercePerformanceYearOnYearLiving = await liveAnchorMonthlyTargetLivingService.GetPerformance(year - 1, month, LiveAnchorInfo);
            LiveAnchorMonthTargetPerformanceDto liveAnchorMonthTargetPerformanceDto = new LiveAnchorMonthTargetPerformanceDto();
            if (month == 1)
            {
                liveAnchorMonthTargetPerformanceDto = await liveAnchorMonthlyTargetLivingService.GetPerformance(year - 1, 12, LiveAnchorInfo);
            }
            else
            {
                liveAnchorMonthTargetPerformanceDto = await liveAnchorMonthlyTargetLivingService.GetPerformance(year, month - 1, LiveAnchorInfo);
            }
            #endregion


            MonthPerformanceRatioDto monthPerformanceRatioDto = new MonthPerformanceRatioDto
            {
                CueerntMonthTotalPerformance = curTotalPerformance + livingTarget.CommerceCompletePerformance,
                CurrentMonthNewCustomerPerformance = curNewCustomer,
                CurrentMonthOldCustomerPerformance = curOldCustomer,
                CurrentMonthCommercePerformance = livingTarget.CommerceCompletePerformance,
                TotalPerformanceYearOnYear = CalculateYearOnYear(curTotalPerformance + livingTarget.CommerceCompletePerformance, totalPerformanceYearOnYear + commercePerformanceYearOnYearLiving.CommerceCompletePerformance),
                TotalPerformanceChainratio = CalculateChainratio(curTotalPerformance + livingTarget.CommerceCompletePerformance, totalPerformanceChainRatio + liveAnchorMonthTargetPerformanceDto.CommerceCompletePerformance),
                TotalPerformanceTargetComplete = CalculateTargetComplete(curTotalPerformance + afterLivingTarget.CommerceCompletePerformance, livingTarget.CommercePerformanceTarget + afterLivingTarget.TotalPerformanceTarget),
                NewCustomerPerformanceYearOnYear = CalculateYearOnYear(curNewCustomer, newPerformanceYearOnYear),
                NewCustomerPerformanceChainRatio = CalculateChainratio(curNewCustomer, newPerformanceChainRatio),
                NewCustomerPerformanceTargetComplete = CalculateTargetComplete(curNewCustomer, afterLivingTarget.NewCustomerPerformanceTarget),
                OldCustomerPerformanceYearOnYear = CalculateYearOnYear(curOldCustomer, oldPerformanceYearOnYear),
                OldCustomerPerformanceChainRatio = CalculateChainratio(curOldCustomer, oldPerformanceRatio),
                OldCustomerTargetComplete = CalculateTargetComplete(curOldCustomer, afterLivingTarget.OldCustomerPerformanceTarget),
                CommercePerformanceYearOnYear = CalculateYearOnYear(livingTarget.CommerceCompletePerformance, commercePerformanceYearOnYearLiving.CommerceCompletePerformance),
                CommercePerformanceChainRatio = CalculateChainratio(livingTarget.CommerceCompletePerformance, liveAnchorMonthTargetPerformanceDto.CommerceCompletePerformance),
                CommercePerformanceTargetComplete = CalculateTargetComplete(livingTarget.CommerceCompletePerformance, livingTarget.CommercePerformanceTarget),
                NewCustomerPerformanceRatio = CalculateTargetComplete(curNewCustomer, curTotalPerformance + livingTarget.CommerceCompletePerformance),
                OldCustomerPerformanceRatio = CalculateTargetComplete(curOldCustomer, curTotalPerformance + livingTarget.CommerceCompletePerformance),
                CommercePerformanceRatio = CalculateTargetComplete(livingTarget.CommerceCompletePerformance, curTotalPerformance + livingTarget.CommerceCompletePerformance)
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

            var groupDaoDaoPerformance = await liveAnchorMonthlyTargetAfterLivingService.GetLiveAnchorBaseIdPerformance(year, month, liveAnchorDaoDaoBaseInfo.Id);
            var LiveAnchorDaoDaoInfo = await this.GetLiveAnchorIdsByNameAsync("刀刀");

            var groupDaoDaoOrderDealPerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month, null, LiveAnchorDaoDaoInfo);
            //本月量
            groupPerformanceDto.GroupDaoDaoPerformance = groupDaoDaoOrderDealPerformance.Sum(x => x.Price);
            //同比
            var groupDaoDaoPerformanceYearToYear = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, null, LiveAnchorDaoDaoInfo);
            groupPerformanceDto.GroupDaoDaoPerformanceYearOnYear = CalculateYearOnYear(groupPerformanceDto.GroupDaoDaoPerformance.Value, groupDaoDaoPerformanceYearToYear.Sum(x => x.Price));
            //环比
            List<ContentPlatFormOrderDealInfoDto> monthGroupDaodaoPerformance = new List<ContentPlatFormOrderDealInfoDto>();
            if (month == 1)
            {
                monthGroupDaodaoPerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, null, LiveAnchorDaoDaoInfo);
            }
            else
            {
                monthGroupDaodaoPerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, null, LiveAnchorDaoDaoInfo);
            }
            groupPerformanceDto.GroupDaoDaoPerformanceChainRatio = CalculateChainratio(groupPerformanceDto.GroupDaoDaoPerformance.Value, monthGroupDaodaoPerformance.Sum(x => x.Price));
            //目标达成
            groupPerformanceDto.GroupDaoDaoPerformanceCompleteRate = CalculateTargetComplete(groupPerformanceDto.GroupDaoDaoPerformance.Value, groupDaoDaoPerformance.GroupTargetPerformance);

            #endregion

            #region 【吉娜组业绩】
            var liveAnchorJinaBaseInfo = await liveAnchorBaseInfoService.GetByNameAsync("吉娜");

            var groupJinaPerformance = await liveAnchorMonthlyTargetAfterLivingService.GetLiveAnchorBaseIdPerformance(year, month, liveAnchorJinaBaseInfo.Id);
            var LiveAnchorJinaInfo = await this.GetLiveAnchorIdsByNameAsync("吉娜");

            var groupJinaOrderDealPerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month, null, LiveAnchorJinaInfo);
            //本月量
            groupPerformanceDto.GroupJinaPerformance = groupJinaOrderDealPerformance.Sum(x => x.Price);
            //同比
            var groupJinaPerformanceYearToYear = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, null, LiveAnchorJinaInfo);
            groupPerformanceDto.GroupJinaPerformanceYearOnYear = CalculateYearOnYear(groupPerformanceDto.GroupJinaPerformance.Value, groupJinaPerformanceYearToYear.Sum(x => x.Price));
            //环比
            List<ContentPlatFormOrderDealInfoDto> monthGroupJinaPerformance = new List<ContentPlatFormOrderDealInfoDto>();
            if (month == 1)
            {
                monthGroupJinaPerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, null, LiveAnchorJinaInfo);
            }
            else
            {
                monthGroupJinaPerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, null, LiveAnchorJinaInfo);
            }
            groupPerformanceDto.GroupJinaPerformanceChainRatio = CalculateChainratio(groupPerformanceDto.GroupJinaPerformance.Value, monthGroupJinaPerformance.Sum(x => x.Price));
            //目标达成
            groupPerformanceDto.GroupJinaPerformanceCompleteRate = CalculateTargetComplete(groupPerformanceDto.GroupJinaPerformance.Value, groupJinaPerformance.GroupTargetPerformance);


            #endregion


            //各分组业绩占比
            decimal sumPerformance = groupPerformanceDto.GroupDaoDaoPerformance.Value + groupPerformanceDto.GroupJinaPerformance.Value;
            groupPerformanceDto.AccountedForGroupDaoDaoPerformance = CalculateTargetComplete(groupPerformanceDto.GroupDaoDaoPerformance.Value, sumPerformance);


            groupPerformanceDto.AccountedForGroupJinaPerformance = CalculateTargetComplete(groupPerformanceDto.GroupJinaPerformance.Value, sumPerformance);

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
            var targetLiving = await liveAnchorMonthlyTargetLivingService.GetPerformance(year, month, LiveAnchorInfo);
            var targetAfterLiving = await liveAnchorMonthlyTargetAfterLivingService.GetPerformance(year, month, LiveAnchorInfo);
            var commercePerformanceYearOnYear = await liveAnchorMonthlyTargetLivingService.GetPerformance(year - 1, month, LiveAnchorInfo);
            LiveAnchorMonthTargetPerformanceDto liveAnchorMonthTargetPerformanceDto = new LiveAnchorMonthTargetPerformanceDto();
            if (month == 1)
            {
                liveAnchorMonthTargetPerformanceDto = await liveAnchorMonthlyTargetLivingService.GetPerformance(year - 1, 12, LiveAnchorInfo);
            }
            else
            {
                liveAnchorMonthTargetPerformanceDto = await liveAnchorMonthlyTargetLivingService.GetPerformance(year, month - 1, LiveAnchorInfo);
            }
            #endregion


            MonthPerformanceRatioDto monthPerformanceRatioDto = new MonthPerformanceRatioDto
            {
                CueerntMonthTotalPerformance = curTotalPerformance + targetLiving.CommerceCompletePerformance,
                CurrentMonthNewCustomerPerformance = curNewCustomer,
                CurrentMonthOldCustomerPerformance = curOldCustomer,
                CurrentMonthCommercePerformance = targetLiving.CommerceCompletePerformance,
                TotalPerformanceYearOnYear = CalculateYearOnYear(curTotalPerformance + targetLiving.CommerceCompletePerformance, totalPerformanceYearOnYear + commercePerformanceYearOnYear.CommerceCompletePerformance),
                TotalPerformanceChainratio = CalculateChainratio(curTotalPerformance + targetLiving.CommerceCompletePerformance, totalPerformanceChainRatio + liveAnchorMonthTargetPerformanceDto.CommerceCompletePerformance),
                TotalPerformanceTargetComplete = CalculateTargetComplete(curTotalPerformance + targetLiving.CommerceCompletePerformance, targetLiving.CommercePerformanceTarget + targetAfterLiving.TotalPerformanceTarget),
                NewCustomerPerformanceYearOnYear = CalculateYearOnYear(curNewCustomer, newPerformanceYearOnYear),
                NewCustomerPerformanceChainRatio = CalculateChainratio(curNewCustomer, newPerformanceChainRatio),
                NewCustomerPerformanceTargetComplete = CalculateTargetComplete(curNewCustomer, targetAfterLiving.NewCustomerPerformanceTarget),
                OldCustomerPerformanceYearOnYear = CalculateYearOnYear(curOldCustomer, oldPerformanceYearOnYear),
                OldCustomerPerformanceChainRatio = CalculateChainratio(curOldCustomer, oldPerformanceRatio),
                OldCustomerTargetComplete = CalculateTargetComplete(curOldCustomer, targetAfterLiving.OldCustomerPerformanceTarget),
                CommercePerformanceYearOnYear = CalculateYearOnYear(targetLiving.CommerceCompletePerformance, commercePerformanceYearOnYear.CommerceCompletePerformance),
                CommercePerformanceChainRatio = CalculateChainratio(targetLiving.CommerceCompletePerformance, liveAnchorMonthTargetPerformanceDto.CommerceCompletePerformance),
                CommercePerformanceTargetComplete = CalculateTargetComplete(targetLiving.CommerceCompletePerformance, targetLiving.CommercePerformanceTarget),
                NewCustomerPerformanceRatio = CalculateTargetComplete(curNewCustomer, curTotalPerformance + targetLiving.CommerceCompletePerformance),
                OldCustomerPerformanceRatio = CalculateTargetComplete(curOldCustomer, curTotalPerformance + targetLiving.CommerceCompletePerformance),
                CommercePerformanceRatio = CalculateTargetComplete(targetLiving.CommerceCompletePerformance, curTotalPerformance + targetLiving.CommerceCompletePerformance)
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
        public async Task<GroupVideoAndPicturePerformanceDto> GetContentPlatFormOrderPerformanceByLiveAnchorNameAsync(int year, int month, string liveAnchorName)
        {
            GroupVideoAndPicturePerformanceDto monthPerformanceDto = new GroupVideoAndPicturePerformanceDto();
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);

            #region 【照片面诊业绩】
            var picturePerformance = await contentPlateFormOrderService.GetPictureOrVideoPerformanceByLiveAnchorAsync(year, month, false, LiveAnchorInfo);
            //照片面诊业绩
            monthPerformanceDto.PicturePerformance = picturePerformance.Sum(x => x.DealAmount.Value);

            List<ContentPlatFormOrderInfoSimpleDto> lastMonthPicturePerformance = new List<ContentPlatFormOrderInfoSimpleDto>();
            if (month == 1)
            {
                lastMonthPicturePerformance = await contentPlateFormOrderService.GetPictureOrVideoPerformanceByLiveAnchorAsync(year - 1, 12, false, LiveAnchorInfo);
            }
            else
            {
                lastMonthPicturePerformance = await contentPlateFormOrderService.GetPictureOrVideoPerformanceByLiveAnchorAsync(year, month - 1, false, LiveAnchorInfo);
            }
            //上月的照片面诊业绩
            var lastMonthPictureTotalPerformance = lastMonthPicturePerformance.Sum(x => x.DealAmount.Value);
            monthPerformanceDto.LastMonthPicturePerformance = CalculateChainratio(monthPerformanceDto.PicturePerformance, lastMonthPictureTotalPerformance);
            //上年的照片面诊业绩
            var lastYearPicturePerformance = await contentPlateFormOrderService.GetPictureOrVideoPerformanceByLiveAnchorAsync(year - 1, month, false, LiveAnchorInfo);
            var lastYearTotalPicturePerformance = lastYearPicturePerformance.Sum(x => x.DealAmount.Value);
            monthPerformanceDto.LastYearPicturePerformance = CalculateYearOnYear(monthPerformanceDto.PicturePerformance, lastYearTotalPicturePerformance);

            #endregion

            #region 【视频面诊业绩】
            var videoPerformance = await contentPlateFormOrderService.GetPictureOrVideoPerformanceByLiveAnchorAsync(year, month, true, LiveAnchorInfo);
            //视频面诊业绩
            monthPerformanceDto.VideoPerformance = videoPerformance.Sum(x => x.DealAmount.Value);

            List<ContentPlatFormOrderInfoSimpleDto> lastMonthVideoPerformance = new List<ContentPlatFormOrderInfoSimpleDto>();
            if (month == 1)
            {
                lastMonthVideoPerformance = await contentPlateFormOrderService.GetPictureOrVideoPerformanceByLiveAnchorAsync(year - 1, 12, true, LiveAnchorInfo);
            }
            else
            {
                lastMonthVideoPerformance = await contentPlateFormOrderService.GetPictureOrVideoPerformanceByLiveAnchorAsync(year, month - 1, true, LiveAnchorInfo);
            }
            //上月的视频面诊业绩
            var lastMonthVideoTotalPerformance = lastMonthVideoPerformance.Sum(x => x.DealAmount.Value);
            monthPerformanceDto.LastMonthVideoPerformance = CalculateChainratio(monthPerformanceDto.VideoPerformance, lastMonthVideoTotalPerformance);
            //上年的视频面诊业绩
            var lastYearVideoPerformance = await contentPlateFormOrderService.GetPictureOrVideoPerformanceByLiveAnchorAsync(year - 1, month, false, LiveAnchorInfo);
            var lastYearTotalVideoPerformance = lastYearVideoPerformance.Sum(x => x.DealAmount.Value);
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
            independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformance = liveAnchorPerformance.Sum(x => x.Price);

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
            var lastMonthLiveAnchorIndependentPerformance = lastMonthLiveAnchorIndenpendentPerformance.Sum(x => x.Price);
            independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformanceChainRatio = CalculateChainratio(independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformance.Value, lastMonthLiveAnchorIndependentPerformance);
            //上年的主播独立业绩
            var lastYearLiveAnchorIndependentPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year - 1, month, false, LiveAnchorInfo, employeeInfo.Id);
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
                lastMonthCustomerServiceIndenpendentPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year, month - 1, false, LiveAnchorInfo, 0);
            }
            //上月的助理独立业绩
            var lastMonthCustomerServiceIndependentPerformance = lastMonthCustomerServiceIndenpendentPerformance.Sum(x => x.Price);
            independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformanceChainRatio = CalculateChainratio(independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformance.Value, lastMonthCustomerServiceIndependentPerformance);
            //上年的助理独立业绩
            var lastYearCustomerServiceIndependentPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year - 1, month, false, LiveAnchorInfo, 0);
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
                lastMonthCustomerServiceAssistPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year, month - 1, true, LiveAnchorInfo, 0);
            }
            //上月的助理协助业绩
            var lastMonthCustomerServiceAssistTotalPerformance = lastMonthCustomerServiceAssistPerformance.Sum(x => x.Price);
            independentOrAssistPerformanceDto.CustomerServiceAssistPerformanceChainRatio = CalculateChainratio(independentOrAssistPerformanceDto.CustomerServiceAssistPerformance.Value, lastMonthCustomerServiceAssistTotalPerformance);
            //上年的助理协助业绩
            var lastYearCustomerServiceAssistPerformance = await contentPlatFormOrderDealInfoService.GetIndependentOrAssistPerformanceByYearAndMonth(year - 1, month, true, LiveAnchorInfo, 0);
            var lastYearCustomerServiceAssistTotalPerformance = lastYearCustomerServiceAssistPerformance.Sum(x => x.Price);
            independentOrAssistPerformanceDto.CustomerServiceAssistPerformanceYearOnYear = CalculateYearOnYear(independentOrAssistPerformanceDto.CustomerServiceAssistPerformance.Value, lastYearCustomerServiceAssistTotalPerformance);

            #endregion


            independentOrAssistPerformanceDto.AccountForLiveAnchorIndenpendentPerformance = CalculateTargetComplete(independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformance.Value, independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformance.Value + independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformance.Value + independentOrAssistPerformanceDto.CustomerServiceAssistPerformance.Value);

            independentOrAssistPerformanceDto.AccountForCustomerServiceIndenpendentPerformance = CalculateTargetComplete(independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformance.Value, independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformance.Value + independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformance.Value + independentOrAssistPerformanceDto.CustomerServiceAssistPerformance.Value);

            independentOrAssistPerformanceDto.AccountForCustomerServiceAssistPerformance = CalculateTargetComplete(independentOrAssistPerformanceDto.CustomerServiceAssistPerformance.Value, independentOrAssistPerformanceDto.LiveAnchorIndenpendentPerformance.Value + independentOrAssistPerformanceDto.CustomerServiceIndenpendentPerformance.Value + independentOrAssistPerformanceDto.CustomerServiceAssistPerformance.Value);


            return independentOrAssistPerformanceDto;
        }



        /// <summary>
        /// 基础经营看板
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        public async Task<BaseBusinessPerformanceDto> GetBaseBusinessPerformanceByLiveAnchorNameAsync(int year, int month, string liveAnchorName)
        {
            BaseBusinessPerformanceDto baseBusinessPerformanceDto = new BaseBusinessPerformanceDto();
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            var groupPerformanceTargetLiving = await liveAnchorMonthlyTargetLivingService.GetBasePerformanceTargetAsync(year, month, LiveAnchorInfo);
            var groupPerformanceTarget = await liveAnchorMonthlyTargetAfterLivingService.GetBasePerformanceTargetAsync(year, month, LiveAnchorInfo);

            var baseBusinessPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month, null, null, LiveAnchorInfo);

            #region 【加v】
            //加v
            baseBusinessPerformanceDto.AddWeChatNum = baseBusinessPerformance.Where(x => x.IsAddWeChat == true).Count();

            List<ShoppingCartRegistrationDto> lastMonthAddWechatPerformance = null;
            if (month == 1)
            {
                lastMonthAddWechatPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, 12, null, null, LiveAnchorInfo);
            }
            else
            {
                lastMonthAddWechatPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month - 1, null, null, LiveAnchorInfo);
            }
            //上月的加v业绩
            var lastMonthAddWechatPerformanceCount = lastMonthAddWechatPerformance.Where(x => x.IsAddWeChat == true).Count();
            baseBusinessPerformanceDto.AddWeChatNumRatioVo = CalculateChainratio(baseBusinessPerformanceDto.AddWeChatNum.Value, lastMonthAddWechatPerformanceCount);
            //上年的加v
            var lastYearBAddWechatPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, month, null, null, LiveAnchorInfo);
            var lastYearTotalAddWechatPerformance = lastYearBAddWechatPerformance.Where(x => x.IsAddWeChat == true).Count();
            baseBusinessPerformanceDto.AddWeChatNumYearOnYear = CalculateYearOnYear(baseBusinessPerformanceDto.AddWeChatNum.Value, lastYearTotalAddWechatPerformance);

            //目标达成
            baseBusinessPerformanceDto.AddWeChatNumTargetComplete = CalculateTargetComplete(baseBusinessPerformanceDto.AddWeChatNum.Value, groupPerformanceTarget.AddWeChatTarget);

            #endregion

            #region 【面诊卡下单】
            //面诊卡下单
            baseBusinessPerformanceDto.ConsulationCardNum = baseBusinessPerformance.Count();

            List<ShoppingCartRegistrationDto> lastMonthConsulationCardPerformance = null;
            if (month == 1)
            {
                lastMonthConsulationCardPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, 12, null, null, LiveAnchorInfo);
            }
            else
            {
                lastMonthConsulationCardPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month - 1, null, null, LiveAnchorInfo);
            }
            //上月的面诊卡下单
            var lastMonthConsulationCardPerformanceCount = lastMonthConsulationCardPerformance.Count();
            baseBusinessPerformanceDto.ConsulationCardNumRatioVo = CalculateChainratio(baseBusinessPerformanceDto.ConsulationCardNum.Value, lastMonthConsulationCardPerformanceCount);
            //上年的面诊卡下单
            var lastYearConsulationCardPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, month, null, null, LiveAnchorInfo);
            var lastYearTotalConsulationCardPerformance = lastYearConsulationCardPerformance.Count();
            baseBusinessPerformanceDto.ConsulationCardNumYearOnYear = CalculateYearOnYear(baseBusinessPerformanceDto.ConsulationCardNum.Value, lastYearTotalConsulationCardPerformance);
            //目标达成
            baseBusinessPerformanceDto.ConsulationCardNumTargetComplete = CalculateTargetComplete(baseBusinessPerformanceDto.ConsulationCardNum.Value, groupPerformanceTargetLiving.ConsulationCardTarget);

            #endregion

            #region 【当月面诊卡消耗】
            //当月面诊卡消耗
            var thisMonthConsulationCardConsumedNum = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month, false, null, LiveAnchorInfo);
            baseBusinessPerformanceDto.ThisMonthConsulationCardConsumedNum = thisMonthConsulationCardConsumedNum.Where(x => x.IsConsultation == true).Count();

            List<ShoppingCartRegistrationDto> lastMonthThisMonthConsulationCardConsumedPerformance = null;
            if (month == 1)
            {
                lastMonthThisMonthConsulationCardConsumedPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, 12, false, null, LiveAnchorInfo);
            }
            else
            {
                lastMonthThisMonthConsulationCardConsumedPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month - 1, false, null, LiveAnchorInfo);
            }
            //上月的当月面诊卡消耗
            var lastMonthThisMonthConsulationCardConsumedPerformanceCount = lastMonthThisMonthConsulationCardConsumedPerformance.Where(x => x.IsConsultation == true).Count();
            baseBusinessPerformanceDto.ThisMonthConsulationCardConsumedNumRatioVo = CalculateChainratio(baseBusinessPerformanceDto.ThisMonthConsulationCardConsumedNum.Value, lastMonthThisMonthConsulationCardConsumedPerformanceCount);
            //上年的当月面诊卡消耗
            var lastYearThisMonthConsulationCardConsumedPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, month, false, null, LiveAnchorInfo);
            var lastYearTotalThisMonthConsulationCardConsumedPerformance = lastYearThisMonthConsulationCardConsumedPerformance.Where(x => x.IsConsultation == true).Count();
            baseBusinessPerformanceDto.ThisMonthConsulationCardConsumedNumYearOnYear = CalculateYearOnYear(baseBusinessPerformanceDto.ThisMonthConsulationCardConsumedNum.Value, lastYearTotalThisMonthConsulationCardConsumedPerformance);
            //目标达成
            baseBusinessPerformanceDto.ThisMonthConsulationCardConsumedNumTargetComplete = CalculateTargetComplete(baseBusinessPerformanceDto.ThisMonthConsulationCardConsumedNum.Value, groupPerformanceTarget.ConsulationCardConsumedTarget);

            #endregion

            #region 【历史面诊卡消耗】
            //历史面诊卡消耗
            var historyConsulationCardConsumedNum = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month, true, null, LiveAnchorInfo);
            baseBusinessPerformanceDto.HistoryConsulationCardConsumedNum = historyConsulationCardConsumedNum.Where(x => x.IsConsultation == true).Count();

            List<ShoppingCartRegistrationDto> lastMonthHistoryConsulationCardConsumedPerformance = new List<ShoppingCartRegistrationDto>();
            if (month == 1)
            {
                lastMonthHistoryConsulationCardConsumedPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, 12, true, null, LiveAnchorInfo);
            }
            else
            {
                lastMonthHistoryConsulationCardConsumedPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month - 1, true, null, LiveAnchorInfo);
            }
            //上月的历史面诊卡消耗
            var lastMonthHistoryConsulationCardConsumedPerformanceCount = lastMonthHistoryConsulationCardConsumedPerformance.Where(x => x.IsConsultation == true).Count();
            baseBusinessPerformanceDto.HistoryConsulationCardConsumedNumRatioVo = CalculateChainratio(baseBusinessPerformanceDto.HistoryConsulationCardConsumedNum.Value, lastMonthHistoryConsulationCardConsumedPerformanceCount);
            //上年的历史面诊卡消耗
            var lastYearHistoryConsulationCardConsumedPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, month, true, null, LiveAnchorInfo);
            var lastYearTotalHistoryConsulationCardConsumedPerformance = lastYearHistoryConsulationCardConsumedPerformance.Where(x => x.IsConsultation == true).Count();
            baseBusinessPerformanceDto.HistoryConsulationCardConsumedNumYearOnYear = CalculateYearOnYear(baseBusinessPerformanceDto.HistoryConsulationCardConsumedNum.Value, lastYearTotalHistoryConsulationCardConsumedPerformance);
            //目标达成
            baseBusinessPerformanceDto.HistoryConsulationCardConsumedNumTargetComplete = CalculateTargetComplete(baseBusinessPerformanceDto.HistoryConsulationCardConsumedNum.Value, groupPerformanceTarget.HistoryConsulationCardConsumedTarget);

            #endregion

            #region 【当月面诊卡退单】
            //当月面诊卡退单
            var thisMonthConsulationCardRefundNum = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month, null, false, LiveAnchorInfo);
            baseBusinessPerformanceDto.ThisMonthConsulationCardRefundNum = thisMonthConsulationCardRefundNum.Count();

            List<ShoppingCartRegistrationDto> lastMonthThisMonthConsulationCardRefundPerformance = null;
            if (month == 1)
            {
                lastMonthThisMonthConsulationCardRefundPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, 12, null, false, LiveAnchorInfo);
            }
            else
            {
                lastMonthThisMonthConsulationCardRefundPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month - 1, null, false, LiveAnchorInfo);
            }
            //上月的当月面诊卡退单
            var lastMonthThisMonthConsulationCardRefundPerformanceCount = lastMonthThisMonthConsulationCardRefundPerformance.Count();
            baseBusinessPerformanceDto.ThisMonthConsulationCardRefundNumRatioVo = CalculateChainratio(baseBusinessPerformanceDto.ThisMonthConsulationCardRefundNum.Value, lastMonthThisMonthConsulationCardRefundPerformanceCount);
            //上年的当月面诊卡退单
            var lastYearThisMonthConsulationCardRefundPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, month, null, false, LiveAnchorInfo);
            var lastYearTotalThisMonthConsulationCardRefundPerformance = lastYearThisMonthConsulationCardRefundPerformance.Count();
            baseBusinessPerformanceDto.ThisMonthConsulationCardRefundNumYearOnYear = CalculateYearOnYear(baseBusinessPerformanceDto.ThisMonthConsulationCardRefundNum.Value, lastYearTotalThisMonthConsulationCardRefundPerformance);
            //目标达成
            baseBusinessPerformanceDto.ThisMonthConsulationCardRefundNumTargetComplete = CalculateTargetComplete(baseBusinessPerformanceDto.ThisMonthConsulationCardRefundNum.Value, groupPerformanceTarget.ConsulationCardRefundTarget);

            #endregion

            #region 【历史面诊卡退单】
            //历史面诊卡退单
            var historyConsulationCardRefundNum = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month, null, true, LiveAnchorInfo);
            baseBusinessPerformanceDto.HistoryConsulationCardRefundNum = historyConsulationCardRefundNum.Count();

            List<ShoppingCartRegistrationDto> lastMonthHistoryConsulationCardRefundPerformance = null;
            if (month == 1)
            {
                lastMonthHistoryConsulationCardRefundPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, 12, null, true, LiveAnchorInfo);
            }
            else
            {
                lastMonthHistoryConsulationCardRefundPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month - 1, null, true, LiveAnchorInfo);
            }
            //上月的历史面诊卡退单
            var lastMonthHistoryConsulationCardRefundPerformanceCount = lastMonthHistoryConsulationCardRefundPerformance.Count();
            baseBusinessPerformanceDto.HistoryConsulationCardRefundNumRatioVo = CalculateChainratio(baseBusinessPerformanceDto.HistoryConsulationCardRefundNum.Value, lastMonthHistoryConsulationCardRefundPerformanceCount);
            //上年的历史面诊卡退单
            var lastYearHistoryConsulationCardRefundPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, month, null, true, LiveAnchorInfo);
            var lastYearTotalHistoryConsulationCardRefundPerformance = lastYearHistoryConsulationCardRefundPerformance.Count();
            baseBusinessPerformanceDto.HistoryConsulationCardRefundNumYearOnYear = CalculateYearOnYear(baseBusinessPerformanceDto.HistoryConsulationCardRefundNum.Value, lastYearTotalHistoryConsulationCardRefundPerformance);

            #endregion

            #region 【面诊卡库存】
            var inventoryInfo = await shoppingCartRegistrationService.GetShoppingCartRegistrationInventoryAsync(LiveAnchorInfo);
            baseBusinessPerformanceDto.ConsulationCardInventoryNum = inventoryInfo.Count;
            #endregion

            return baseBusinessPerformanceDto;

        }



        /// <summary>
        /// 派单成交经营看板
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        public async Task<SendAndDealPerformanceByLiveAnchorDto> GetSendOrDealByLiveAnchorAsync(int year, int month, string liveAnchorName)
        {
            //开始月份
            DateTime currentDate = new DateTime(year, month, 1);
            //结束月份
            DateTime endDate = new DateTime(year, month, 1).AddMonths(1);
            SendAndDealPerformanceByLiveAnchorDto sendAndDealPerformanceDto = new SendAndDealPerformanceByLiveAnchorDto();
            //获取各个平台的主播ID
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            var groupPerformanceTarget = await liveAnchorMonthlyTargetAfterLivingService.GetSendOrDealTargetAsync(year, month, LiveAnchorInfo);
            //获取总体数据
            var liveAnchorSendOrderNum = await contentPlateFormOrderService.GetSendOrDealPerformanceByLiveAnchorAsync(LiveAnchorInfo);


            //环比月份操作
            //开始月份
            DateTime monthStartDate = new DateTime();
            DateTime monthEndDate = new DateTime();
            if (month == 1)
            {
                monthStartDate = new DateTime(year - 1, 12, 1);
                monthEndDate = new DateTime(year - 1, 12, 1).AddMonths(1);
            }
            else
            {
                monthStartDate = new DateTime(year, month - 1, 1);
                //结束月份
                monthEndDate = new DateTime(year, month, 1);
            }


            //上年的派单数
            var lastYearThisMonthStartDate = new DateTime(year - 1, month, 1);
            var lastYearThisMonthEndDate = new DateTime(year - 1, month, 1).AddMonths(1);

            #region 【派单数】

            var sendResult = liveAnchorSendOrderNum.Where(d => d.SendDate.HasValue == true && d.SendDate.Value >= currentDate && d.SendDate.Value < endDate).ToList();
            sendAndDealPerformanceDto.SendOrderNum = sendResult.Count();
            //上月派单数
            var lastMonthSendOrDealTotalCount = liveAnchorSendOrderNum.Where(d => d.SendDate.HasValue == true && d.SendDate.Value >= monthStartDate && d.SendDate.Value < monthEndDate).ToList();
            sendAndDealPerformanceDto.SendOrderNumChainRatio = CalculateChainratio(sendAndDealPerformanceDto.SendOrderNum.Value, lastMonthSendOrDealTotalCount.Count());

            var lastYearSendOrDealTotalCount = liveAnchorSendOrderNum.Where(d => d.SendDate.HasValue == true && d.SendDate.Value >= lastYearThisMonthStartDate && d.SendDate.Value < lastYearThisMonthEndDate).ToList();
            sendAndDealPerformanceDto.SendOrderNumYearOnYear = CalculateYearOnYear(sendAndDealPerformanceDto.SendOrderNum.Value, lastYearSendOrDealTotalCount.Count);
            //目标达成
            sendAndDealPerformanceDto.SendOrderNumCompleteRate = CalculateTargetComplete(sendResult.Count, groupPerformanceTarget.SendOrderTarget);

            #endregion

            #region 【总上门数】
            var liveAnchorTotalToHospitalNum = liveAnchorSendOrderNum.Where(d => d.IsToHospital == true && d.ToHospitalDate.HasValue == true && d.ToHospitalDate.Value >= currentDate && d.ToHospitalDate.Value < endDate).ToList();
            //总上门数
            sendAndDealPerformanceDto.TotalVisitNum = liveAnchorTotalToHospitalNum.Count();

            //上月的总上门数
            var lastMonthTotalToHospitalTotalCount = liveAnchorSendOrderNum.Where(d => d.ToHospitalDate.HasValue == true && d.ToHospitalDate.Value >= monthStartDate && d.ToHospitalDate.Value < monthEndDate).ToList();
            sendAndDealPerformanceDto.TotalVisitNumChainRatio = CalculateChainratio(sendAndDealPerformanceDto.TotalVisitNum.Value, lastMonthTotalToHospitalTotalCount.Count());
            //上年的总上门数
            var lastYearTotalToHospitalTotalCount = liveAnchorSendOrderNum.Where(d => d.ToHospitalDate.HasValue == true && d.ToHospitalDate.Value >= lastYearThisMonthStartDate && d.ToHospitalDate.Value < lastYearThisMonthEndDate).ToList();
            sendAndDealPerformanceDto.TotalVisitNumYearOnYear = CalculateYearOnYear(sendAndDealPerformanceDto.TotalVisitNum.Value, lastYearTotalToHospitalTotalCount.Count());
            //目标达成
            sendAndDealPerformanceDto.TotalVisitNumCompleteRate = CalculateTargetComplete(liveAnchorTotalToHospitalNum.Count(), groupPerformanceTarget.TotalVisitTarget);

            #endregion

            #region 【新客上门数】
            //新客上门数
            sendAndDealPerformanceDto.NewCustomerVisitNum = liveAnchorTotalToHospitalNum.Where(x => x.IsOldCustomer == false).Count();
            //上月的新客上门数
            var lastMonthNewCustomerToHospitalTotalCount = lastMonthTotalToHospitalTotalCount.Where(x => x.IsOldCustomer == false).Count();
            sendAndDealPerformanceDto.NewCustomerVisitNumChainRatio = CalculateChainratio(sendAndDealPerformanceDto.NewCustomerVisitNum.Value, lastMonthNewCustomerToHospitalTotalCount);
            //上年的新客上门数
            var lastYearNewCustomerToHospitalTotalCount = lastYearTotalToHospitalTotalCount.Where(x => x.IsOldCustomer == false).Count();
            sendAndDealPerformanceDto.NewCustomerVisitNumYearOnYear = CalculateYearOnYear(sendAndDealPerformanceDto.NewCustomerVisitNum.Value, lastYearNewCustomerToHospitalTotalCount);
            //目标达成
            sendAndDealPerformanceDto.NewCustomerVisitNumCompleteRate = CalculateTargetComplete(sendAndDealPerformanceDto.NewCustomerVisitNum.Value, groupPerformanceTarget.NewCustomerVisitTarget);

            #endregion

            #region 【老客上门数】
            sendAndDealPerformanceDto.OldCustomerVisitNum = liveAnchorTotalToHospitalNum.Where(x => x.IsOldCustomer == true).Count();
            //上月的老客上门数
            var lastMonthOldCustomerToHospitalTotalCount = lastMonthTotalToHospitalTotalCount.Where(x => x.IsOldCustomer == true).Count();
            sendAndDealPerformanceDto.OldCustomerVisitNumChainRatio = CalculateChainratio(sendAndDealPerformanceDto.OldCustomerVisitNum.Value, lastMonthOldCustomerToHospitalTotalCount);
            //上年的老客上门数
            var lastYearOldCustomerToHospitalTotalCount = lastYearTotalToHospitalTotalCount.Where(x => x.IsOldCustomer == true).Count();
            sendAndDealPerformanceDto.OldCustomerVisitNumYearOnYear = CalculateYearOnYear(sendAndDealPerformanceDto.OldCustomerVisitNum.Value, lastYearOldCustomerToHospitalTotalCount);
            //目标达成
            sendAndDealPerformanceDto.OldCustomerVisitNumCompleteRate = CalculateTargetComplete(sendAndDealPerformanceDto.OldCustomerVisitNum.Value, groupPerformanceTarget.OldCustomerVisitTarget);

            #endregion

            #region 【总成交数】
            var liveAnchorTotalDealNum = liveAnchorSendOrderNum.Where(d => d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete && d.DealDate.HasValue == true && d.DealDate.Value >= currentDate && d.DealDate.Value < endDate).ToList();
            //总成交数
            sendAndDealPerformanceDto.TotalDealNum = liveAnchorTotalDealNum.Count();
            //上月的总成交数
            var lastMonthTotalDealTotalCount = liveAnchorSendOrderNum.Where(d => d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete && d.DealDate.HasValue == true && d.DealDate.Value >= monthStartDate && d.DealDate.Value < monthEndDate).ToList();
            sendAndDealPerformanceDto.TotalDealNumChainRatio = CalculateChainratio(sendAndDealPerformanceDto.TotalDealNum.Value, lastMonthTotalDealTotalCount.Count());
            //上年的总成交数
            var lastYearTotalDealTotalCount = lastYearTotalToHospitalTotalCount.Where(d => d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete && d.DealDate.HasValue == true && d.DealDate.Value >= lastYearThisMonthStartDate && d.DealDate.Value < lastYearThisMonthEndDate);
            sendAndDealPerformanceDto.TotalDealNumYearOnYear = CalculateYearOnYear(sendAndDealPerformanceDto.TotalDealNum.Value, lastYearTotalDealTotalCount.Count());
            //目标达成
            sendAndDealPerformanceDto.TotalDealNumCompleteRate = CalculateTargetComplete(liveAnchorTotalDealNum.Count(), groupPerformanceTarget.TotalDealTarget);

            #endregion

            #region 【新客成交数】
            var liveAnchorNewCustomerDealNum = liveAnchorTotalDealNum.Where(x => x.IsOldCustomer == false);
            //新客成交数
            sendAndDealPerformanceDto.NewCustomerDealNum = liveAnchorNewCustomerDealNum.Count();
            //上月的新客成交数
            var lastMonthNewCustomerDealTotalCount = lastMonthTotalDealTotalCount.Where(x => x.IsOldCustomer == false).Count();
            sendAndDealPerformanceDto.NewCustomerDealNumChainRatio = CalculateChainratio(sendAndDealPerformanceDto.NewCustomerDealNum.Value, lastMonthNewCustomerDealTotalCount);
            //上年的新客成交数
            var lastYearNewCustomerDealTotalCount = lastYearTotalDealTotalCount.Where(x => x.IsOldCustomer == false).Count();
            sendAndDealPerformanceDto.NewCustomerDealNumYearOnYear = CalculateYearOnYear(sendAndDealPerformanceDto.NewCustomerDealNum.Value, lastYearNewCustomerDealTotalCount);
            //目标达成
            sendAndDealPerformanceDto.NewCustomerDealNumCompleteRate = CalculateTargetComplete(liveAnchorNewCustomerDealNum.Count(), groupPerformanceTarget.NewCustomerDealTarget);

            #endregion

            #region 【老客成交数】
            var liveAnchorOldCustomerDealNum = liveAnchorTotalDealNum.Where(x => x.IsOldCustomer == true);
            //老客成交数
            sendAndDealPerformanceDto.OldCustomerDealNum = liveAnchorOldCustomerDealNum.Count();
            //上月的老客成交数
            var lastMonthOldCustomerDealTotalCount = lastMonthTotalDealTotalCount.Where(x => x.IsOldCustomer == false).Count();
            sendAndDealPerformanceDto.OldCustomerDealNumChainRatio = CalculateChainratio(sendAndDealPerformanceDto.OldCustomerDealNum.Value, lastMonthOldCustomerDealTotalCount);
            //上年的老客成交数
            var lastYearOldCustomerDealTotalCount = lastYearTotalDealTotalCount.Where(x => x.IsOldCustomer == false).Count();
            sendAndDealPerformanceDto.OldCustomerDealNumYearOnYear = CalculateYearOnYear(sendAndDealPerformanceDto.OldCustomerDealNum.Value, lastYearOldCustomerDealTotalCount);
            //目标达成
            sendAndDealPerformanceDto.OldCustomerDealNumCompleteRate = CalculateTargetComplete(liveAnchorOldCustomerDealNum.Count(), groupPerformanceTarget.OldCustomerDealTarget);


            #endregion


            return sendAndDealPerformanceDto;
        }


        /// <summary>
        /// 客单价经营看板
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        public async Task<GuestUnitPricePerformanceDto> GetGuestUnitPricePerformanceByLiveAnchorAsync(int year, int month, string liveAnchorName)
        {
            GuestUnitPricePerformanceDto independentOrAssistPerformanceDto = new GuestUnitPricePerformanceDto();
            //获取各个平台的主播ID
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);

            #region 【总客单价】
            var liveAnchorTotalPerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month, null, LiveAnchorInfo);
            //总客单价
            if (liveAnchorTotalPerformance.Count > 0)
            {

                independentOrAssistPerformanceDto.TotalGuestUnitPricePerformance = liveAnchorTotalPerformance.Sum(x => x.Price) / liveAnchorTotalPerformance.Count;
            }
            else
            {
                independentOrAssistPerformanceDto.TotalGuestUnitPricePerformance = 0.00M;
            }
            List<ContentPlatFormOrderDealInfoDto> lastMonthTotalGuestUnitPricePerformance = null;
            if (month == 1)
            {
                lastMonthTotalGuestUnitPricePerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, null, LiveAnchorInfo);
            }
            else
            {
                lastMonthTotalGuestUnitPricePerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, null, LiveAnchorInfo);
            }
            //上月的总客单价
            decimal lastMonthTotalGuestUnitPriceTotalPerformance = 0.00M;
            if (lastMonthTotalGuestUnitPricePerformance.Count > 0)
            {
                lastMonthTotalGuestUnitPriceTotalPerformance = lastMonthTotalGuestUnitPricePerformance.Sum(x => x.Price) / lastMonthTotalGuestUnitPricePerformance.Count;
            }
            independentOrAssistPerformanceDto.TotalGuestUnitPricePerformanceChainRatio = CalculateChainratio(independentOrAssistPerformanceDto.TotalGuestUnitPricePerformance.Value, lastMonthTotalGuestUnitPriceTotalPerformance);
            //上年的总客单价
            var lastYearTotalGuestUnitPriceTotalPerformance = 0.00M;
            var lastYearTotalGuestUnitPricePerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, null, LiveAnchorInfo);
            if (lastYearTotalGuestUnitPricePerformance.Count > 0)
            {
                lastYearTotalGuestUnitPriceTotalPerformance = lastYearTotalGuestUnitPricePerformance.Sum(x => x.Price) / lastYearTotalGuestUnitPricePerformance.Count;
            }
            independentOrAssistPerformanceDto.TotalGuestUnitPricePerformanceYearOnYear = CalculateYearOnYear(independentOrAssistPerformanceDto.TotalGuestUnitPricePerformance.Value, lastYearTotalGuestUnitPriceTotalPerformance);

            #endregion

            #region 【新诊客单价】
            var liveAnchorNewPerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month, false, LiveAnchorInfo);
            //新诊客单价
            if (liveAnchorNewPerformance.Count > 0)
            {

                independentOrAssistPerformanceDto.NewGuestUnitPricePerformance = liveAnchorNewPerformance.Sum(x => x.Price) / liveAnchorNewPerformance.Count;
            }
            else
            {
                independentOrAssistPerformanceDto.NewGuestUnitPricePerformance = 0.00M;
            }
            List<ContentPlatFormOrderDealInfoDto> lastMonthNewGuestUnitPricePerformance = null;
            if (month == 1)
            {
                lastMonthNewGuestUnitPricePerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, false, LiveAnchorInfo);
            }
            else
            {
                lastMonthNewGuestUnitPricePerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, false, LiveAnchorInfo);
            }
            //上月的新诊客单价
            decimal lastMonthNewGuestUnitPriceNewPerformance = 0.00M;
            if (lastMonthNewGuestUnitPricePerformance.Count > 0)
            {
                lastMonthNewGuestUnitPriceNewPerformance = lastMonthNewGuestUnitPricePerformance.Sum(x => x.Price) / lastMonthNewGuestUnitPricePerformance.Count;
            }
            independentOrAssistPerformanceDto.NewGuestUnitPricePerformanceChainRatio = CalculateChainratio(independentOrAssistPerformanceDto.NewGuestUnitPricePerformance.Value, lastMonthNewGuestUnitPriceNewPerformance);
            //上年的新诊客单价
            var lastYearNewGuestUnitPriceNewPerformance = 0.00M;
            var lastYearNewGuestUnitPricePerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, false, LiveAnchorInfo);
            if (lastYearNewGuestUnitPricePerformance.Count > 0)
            {
                lastYearNewGuestUnitPriceNewPerformance = lastYearNewGuestUnitPricePerformance.Sum(x => x.Price) / lastYearNewGuestUnitPricePerformance.Count;
            }
            independentOrAssistPerformanceDto.NewGuestUnitPricePerformanceYearOnYear = CalculateYearOnYear(independentOrAssistPerformanceDto.NewGuestUnitPricePerformance.Value, lastYearNewGuestUnitPriceNewPerformance);

            #endregion

            #region 【老客客单价】
            var liveAnchorOldPerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month, true, LiveAnchorInfo);
            //老客客单价
            if (liveAnchorOldPerformance.Count > 0)
            {

                independentOrAssistPerformanceDto.OldGuestUnitPricePerformance = liveAnchorOldPerformance.Sum(x => x.Price) / liveAnchorOldPerformance.Count;
            }
            else
            {
                independentOrAssistPerformanceDto.OldGuestUnitPricePerformance = 0.00M;
            }
            List<ContentPlatFormOrderDealInfoDto> lastMonthOldGuestUnitPricePerformance = null;
            if (month == 1)
            {
                lastMonthOldGuestUnitPricePerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, 12, true, LiveAnchorInfo);
            }
            else
            {
                lastMonthOldGuestUnitPricePerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year, month - 1, true, LiveAnchorInfo);
            }
            //上月的老客客单价
            decimal lastMonthOldGuestUnitPriceOldPerformance = 0.00M;
            if (lastMonthOldGuestUnitPricePerformance.Count > 0)
            {
                lastMonthOldGuestUnitPriceOldPerformance = lastMonthOldGuestUnitPricePerformance.Sum(x => x.Price) / lastMonthOldGuestUnitPricePerformance.Count;
            }
            independentOrAssistPerformanceDto.OldGuestUnitPricePerformanceChainRatio = CalculateChainratio(independentOrAssistPerformanceDto.OldGuestUnitPricePerformance.Value, lastMonthOldGuestUnitPriceOldPerformance);
            //上年的老客客单价
            var lastYearOldGuestUnitPriceOldPerformance = 0.00M;
            var lastYearOldGuestUnitPricePerformance = await contentPlatFormOrderDealInfoService.GetPerformanceByYearAndMonth(year - 1, month, true, LiveAnchorInfo);
            if (lastYearOldGuestUnitPricePerformance.Count > 0)
            {
                lastYearOldGuestUnitPriceOldPerformance = lastYearOldGuestUnitPricePerformance.Sum(x => x.Price) / lastYearOldGuestUnitPricePerformance.Count;
            }
            independentOrAssistPerformanceDto.OldGuestUnitPricePerformanceYearOnYear = CalculateYearOnYear(independentOrAssistPerformanceDto.OldGuestUnitPricePerformance.Value, lastYearOldGuestUnitPriceOldPerformance);

            #endregion


            return independentOrAssistPerformanceDto;
        }


        /// <summary>
        /// 各版块占比看板
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        public async Task<GroupTargetCompleteRateDto> GetPerformanceCompleteRateByLiveAnchorNameAsync(int year, int month, string liveAnchorName)
        {
            #region 【定义时间格式】


            //开始月份
            DateTime currentDate = new DateTime(year, month, 1);
            //结束月份
            DateTime endDate = new DateTime(year, month, 1).AddMonths(1);

            //环比月份操作
            //开始月份
            DateTime monthStartDate = new DateTime();
            //结束月份
            DateTime monthEndDate = new DateTime();

            if (month == 1)
            {
                monthStartDate = new DateTime(year - 1, 12, 1);
                monthEndDate = new DateTime(year - 1, 12, 1).AddMonths(1);
            }
            else
            {
                //开始月份
                monthStartDate = new DateTime(year, month - 1, 1);
                //结束月份
                monthEndDate = new DateTime(year, month - 1, 1).AddMonths(1);
            }

            //上年的
            var lastYearThisMonthStartDate = new DateTime(year - 1, month, 1);
            var lastYearThisMonthEndDate = new DateTime(year - 1, month, 1).AddMonths(1);
            #endregion

            GroupTargetCompleteRateDto baseBusinessPerformanceDto = new GroupTargetCompleteRateDto();
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            var groupPerformanceTarget = await liveAnchorMonthlyTargetAfterLivingService.GetBasePerformanceTargetAsync(year, month, LiveAnchorInfo);
            var groupSendOrDealTarget = await liveAnchorMonthlyTargetAfterLivingService.GetSendOrDealTargetAsync(year, month, LiveAnchorInfo);
            //获取总体数据
            var liveAnchorSendOrderNum = await contentPlateFormOrderService.GetSendOrDealPerformanceByLiveAnchorAsync(LiveAnchorInfo);
            var baseBusinessPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month, null, null, LiveAnchorInfo);
            var totalLiveAnchorOrders = await contentPlateFormOrderService.GetAddOrderPerformanceByLiveAnchorAsync(year, month, LiveAnchorInfo);

            #region 【加v率】
            var addWechatCount = baseBusinessPerformance.Where(x => x.IsAddWeChat == true).Count();
            baseBusinessPerformanceDto.AddWeChatCompleteRate = CalculateTargetComplete(addWechatCount, baseBusinessPerformance.Count());

            List<ShoppingCartRegistrationDto> lastMonthAddWechatPerformance = null;
            if (month == 1)
            {
                lastMonthAddWechatPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, 12, null, null, LiveAnchorInfo);
            }
            else
            {
                lastMonthAddWechatPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month - 1, null, null, LiveAnchorInfo);
            }
            //上月的加v业绩
            var lastMonthAddWechatPerformanceCount = lastMonthAddWechatPerformance.Where(x => x.IsAddWeChat == true).Count();
            baseBusinessPerformanceDto.AddWeChatCompleteRateChainRatio = CalculateChainratio(addWechatCount, lastMonthAddWechatPerformanceCount);
            //上年的加v
            var lastYearBAddWechatPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, month, null, null, LiveAnchorInfo);
            var lastYearTotalAddWechatPerformance = lastYearBAddWechatPerformance.Where(x => x.IsAddWeChat == true).Count();
            baseBusinessPerformanceDto.AddWeChatCompleteRateYearOnYear = CalculateYearOnYear(addWechatCount, lastYearTotalAddWechatPerformance);

            //目标达成
            baseBusinessPerformanceDto.AddWeChatCompleteRateTarget = CalculateTargetComplete(addWechatCount, groupPerformanceTarget.AddWeChatTarget);

            #endregion

            #region 【当月面诊卡消耗率】
            //当月面诊卡消耗
            var thisMonthConsulationCardConsumedNum = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month, false, null, LiveAnchorInfo);
            var consulationCardUsedNum = thisMonthConsulationCardConsumedNum.Where(x => x.IsConsultation == true).Count();
            baseBusinessPerformanceDto.ConsulationCardUsedCompleteRate = CalculateTargetComplete(consulationCardUsedNum, baseBusinessPerformance.Count());
            List<ShoppingCartRegistrationDto> lastMonthThisMonthConsulationCardConsumedPerformance = null;
            if (month == 1)
            {
                lastMonthThisMonthConsulationCardConsumedPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, 12, false, null, LiveAnchorInfo);
            }
            else
            {
                lastMonthThisMonthConsulationCardConsumedPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month - 1, false, null, LiveAnchorInfo);
            }
            //上月的当月面诊卡消耗
            var lastMonthThisMonthConsulationCardConsumedPerformanceCount = lastMonthThisMonthConsulationCardConsumedPerformance.Where(x => x.IsConsultation == true).Count();
            baseBusinessPerformanceDto.ConsulationCardUsedCompleteRateChainRatio = CalculateChainratio(consulationCardUsedNum, lastMonthThisMonthConsulationCardConsumedPerformanceCount);
            //上年的当月面诊卡消耗
            var lastYearThisMonthConsulationCardConsumedPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, month, false, null, LiveAnchorInfo);
            var lastYearTotalThisMonthConsulationCardConsumedPerformance = lastYearThisMonthConsulationCardConsumedPerformance.Where(x => x.IsConsultation == true).Count();
            baseBusinessPerformanceDto.ConsulationCardUsedCompleteRateYearOnYear = CalculateYearOnYear(consulationCardUsedNum, lastYearTotalThisMonthConsulationCardConsumedPerformance);
            //目标达成
            baseBusinessPerformanceDto.ConsulationCardUsedCompleteRateTarget = CalculateTargetComplete(consulationCardUsedNum, groupPerformanceTarget.ConsulationCardConsumedTarget);

            #endregion

            #region 【历史面诊卡消耗率】
            ////历史面诊卡消耗
            //var historyConsulationCardConsumedNum = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month, true, null, LiveAnchorInfo);
            //baseBusinessPerformanceDto.HistoryConsulationCardConsumedNum = historyConsulationCardConsumedNum.Where(x => x.IsConsultation == true).Count();

            //List<ShoppingCartRegistrationDto> lastMonthHistoryConsulationCardConsumedPerformance = new List<ShoppingCartRegistrationDto>();
            //if (month == 1)
            //{
            //    lastMonthHistoryConsulationCardConsumedPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, 12, true, null, LiveAnchorInfo);
            //}
            //else
            //{
            //    lastMonthHistoryConsulationCardConsumedPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month - 1, true, null, LiveAnchorInfo);
            //}
            ////上月的历史面诊卡消耗
            //var lastMonthHistoryConsulationCardConsumedPerformanceCount = lastMonthHistoryConsulationCardConsumedPerformance.Where(x => x.IsConsultation == true).Count();
            //baseBusinessPerformanceDto.HistoryConsulationCardConsumedNumRatioVo = CalculateChainratio(baseBusinessPerformanceDto.HistoryConsulationCardConsumedNum.Value, lastMonthHistoryConsulationCardConsumedPerformanceCount);
            ////上年的历史面诊卡消耗
            //var lastYearHistoryConsulationCardConsumedPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, month, true, null, LiveAnchorInfo);
            //var lastYearTotalHistoryConsulationCardConsumedPerformance = lastYearHistoryConsulationCardConsumedPerformance.Where(x => x.IsConsultation == true).Count();
            //baseBusinessPerformanceDto.HistoryConsulationCardConsumedNumYearOnYear = CalculateYearOnYear(baseBusinessPerformanceDto.HistoryConsulationCardConsumedNum.Value, lastYearTotalHistoryConsulationCardConsumedPerformance);
            ////目标达成
            //baseBusinessPerformanceDto.HistoryConsulationCardConsumedNumTargetComplete = CalculateTargetComplete(baseBusinessPerformanceDto.HistoryConsulationCardConsumedNum.Value, groupPerformanceTarget.HistoryConsulationCardConsumedTarget);

            #endregion

            #region 【派单率】

            var sendResult = liveAnchorSendOrderNum.Where(d => d.SendDate.HasValue == true && d.SendDate.Value >= currentDate && d.SendDate.Value < endDate && d.CreateDate >= currentDate && d.CreateDate < endDate).ToList();
            var sendOrderNum = sendResult.Count();
            baseBusinessPerformanceDto.SendOrderCompleteRate = CalculateTargetComplete(sendOrderNum, totalLiveAnchorOrders.Count());
            //上月派单数
            var lastMonthSendOrDealTotalCount = liveAnchorSendOrderNum.Where(d => d.SendDate.HasValue == true && d.SendDate.Value >= monthStartDate && d.SendDate.Value < monthEndDate).ToList();
            baseBusinessPerformanceDto.SendOrderCompleteRateChainRatio = CalculateChainratio(sendOrderNum, lastMonthSendOrDealTotalCount.Count());

            var lastYearSendOrDealTotalCount = liveAnchorSendOrderNum.Where(d => d.SendDate.HasValue == true && d.SendDate.Value >= lastYearThisMonthStartDate && d.SendDate.Value < lastYearThisMonthEndDate).ToList();
            baseBusinessPerformanceDto.SendOrderCompleteRateYearOnYear = CalculateYearOnYear(sendOrderNum, lastYearSendOrDealTotalCount.Count);
            //目标达成
            baseBusinessPerformanceDto.SendOrderCompleteRateTarget = CalculateTargetComplete(liveAnchorSendOrderNum.Count, groupSendOrDealTarget.SendOrderTarget);

            #endregion

            #region 【新客上门率】
            var liveAnchorTotalToHospitalNum = liveAnchorSendOrderNum.Where(d => d.IsToHospital == true && d.ToHospitalDate.HasValue == true && d.ToHospitalDate.Value >= currentDate && d.IsOldCustomer == false && d.ToHospitalDate.Value < endDate).ToList();
            //新客上门数
            var newCustomerVisitCount = liveAnchorTotalToHospitalNum.Count();
            baseBusinessPerformanceDto.NewCustomerVisitCompleteRate = CalculateTargetComplete(newCustomerVisitCount, sendOrderNum);
            //上月的新客上门数

            //上月的总上门数
            var lastMonthTotalToHospitalTotalCount = liveAnchorSendOrderNum.Where(d => d.ToHospitalDate.HasValue == true && d.IsOldCustomer == false && d.ToHospitalDate.Value >= monthStartDate && d.ToHospitalDate.Value < monthEndDate).ToList();
            var lastMonthNewCustomerToHospitalTotalCount = lastMonthTotalToHospitalTotalCount.Count();
            baseBusinessPerformanceDto.NewCustomerVisitCompleteRateChainRatio = CalculateChainratio(newCustomerVisitCount, lastMonthNewCustomerToHospitalTotalCount);
            //上年的新客上门数
            var lastYearTotalToHospitalTotalCount = liveAnchorSendOrderNum.Where(d => d.ToHospitalDate.HasValue == true && d.ToHospitalDate.Value >= lastYearThisMonthStartDate && d.ToHospitalDate.Value < lastYearThisMonthEndDate).ToList();
            var lastYearNewCustomerToHospitalTotalCount = lastYearTotalToHospitalTotalCount.Where(x => x.IsOldCustomer == false).Count();
            baseBusinessPerformanceDto.NewCustomerVisitCompleteRateYearOnYear = CalculateYearOnYear(newCustomerVisitCount, lastYearNewCustomerToHospitalTotalCount);
            //目标达成
            baseBusinessPerformanceDto.NewCustomerVisitCompleteRateTarget = CalculateTargetComplete(newCustomerVisitCount, groupSendOrDealTarget.NewCustomerVisitTarget);

            #endregion

            #region 【新客成交率】
            var liveAnchorTotalDealNum = liveAnchorSendOrderNum.Where(d => d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete && d.DealDate.HasValue == true && d.IsOldCustomer == false && d.DealDate.Value >= currentDate && d.DealDate.Value < endDate).ToList();
            //新客成交数
            var newCustomerDealCount = liveAnchorTotalDealNum.Count();
            baseBusinessPerformanceDto.NewCustomerDealCompleteRate = CalculateTargetComplete(newCustomerDealCount, newCustomerVisitCount);
            //上月的新客成交数

            //上月的总成交数
            var lastMonthTotalDealTotalCount = liveAnchorSendOrderNum.Where(d => d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete && d.DealDate.HasValue == true && d.IsOldCustomer == false && d.DealDate.Value >= monthStartDate && d.DealDate.Value < monthEndDate).ToList();
            var lastMonthNewCustomerDealTotalCount = lastMonthTotalDealTotalCount.Count();
            baseBusinessPerformanceDto.NewCustomerDealCompleteRateChainRatio = CalculateChainratio(newCustomerDealCount, lastMonthNewCustomerDealTotalCount);
            //上年的新客成交数
            var lastYearTotalDealTotalCount = liveAnchorSendOrderNum.Where(d => d.OrderStatus == (int)ContentPlateFormOrderStatus.OrderComplete && d.DealDate.HasValue == true && d.IsOldCustomer == false && d.DealDate.Value >= lastYearThisMonthStartDate && d.DealDate.Value < lastYearThisMonthEndDate).ToList();
            var lastYearNewCustomerDealTotalCount = lastYearTotalDealTotalCount.Where(x => x.IsOldCustomer == false).Count();
            baseBusinessPerformanceDto.NewCustomerDealCompleteRateYearOnYear = CalculateYearOnYear(newCustomerDealCount, lastYearNewCustomerDealTotalCount);
            //目标达成
            baseBusinessPerformanceDto.NewCustomerDealCompleteRateTarget = CalculateTargetComplete(newCustomerDealCount, groupSendOrDealTarget.NewCustomerDealTarget);

            #endregion

            #region 【当月面诊卡退单率】
            //当月面诊卡退单
            var thisMonthConsulationCardRefundNum = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month, null, false, LiveAnchorInfo);
            var thisMonthConsulationCardRefundCount = thisMonthConsulationCardRefundNum.Count();
            baseBusinessPerformanceDto.ThisMonthConsulationCardRefundCompleteRate = CalculateTargetComplete(thisMonthConsulationCardRefundCount, baseBusinessPerformance.Count());
            List<ShoppingCartRegistrationDto> lastMonthThisMonthConsulationCardRefundPerformance = null;
            if (month == 1)
            {
                lastMonthThisMonthConsulationCardRefundPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, 12, null, false, LiveAnchorInfo);
            }
            else
            {
                lastMonthThisMonthConsulationCardRefundPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month - 1, null, false, LiveAnchorInfo);
            }
            //上月的当月面诊卡退单
            var lastMonthThisMonthConsulationCardRefundPerformanceCount = lastMonthThisMonthConsulationCardRefundPerformance.Count();
            baseBusinessPerformanceDto.ThisMonthConsulationCardRefundCompleteRateChainRatio = CalculateChainratio(thisMonthConsulationCardRefundCount, lastMonthThisMonthConsulationCardRefundPerformanceCount);
            //上年的当月面诊卡退单
            var lastYearThisMonthConsulationCardRefundPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, month, null, false, LiveAnchorInfo);
            var lastYearTotalThisMonthConsulationCardRefundPerformance = lastYearThisMonthConsulationCardRefundPerformance.Count();
            baseBusinessPerformanceDto.ThisMonthConsulationCardRefundCompleteRateYearOnYear = CalculateYearOnYear(thisMonthConsulationCardRefundCount, lastYearTotalThisMonthConsulationCardRefundPerformance);
            //目标达成
            baseBusinessPerformanceDto.ThisMonthConsulationCardRefundCompleteRateTarget = CalculateTargetComplete(thisMonthConsulationCardRefundCount, groupPerformanceTarget.ConsulationCardRefundTarget);

            #endregion

            #region 【历史面诊卡退单率】
            //历史面诊卡退单
            var historyConsulationCardRefundNum = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month, null, true, LiveAnchorInfo);
            var historyConsulationCardRefundCount = historyConsulationCardRefundNum.Count();
            var inventoryInfo = await shoppingCartRegistrationService.GetShoppingCartRegistrationInventoryAsync(LiveAnchorInfo);//获取历史面诊卡总量
            baseBusinessPerformanceDto.HistoryConsulationCardRefundCompleteRate = CalculateTargetComplete(historyConsulationCardRefundCount, inventoryInfo.Count);
            List<ShoppingCartRegistrationDto> lastMonthHistoryConsulationCardRefundPerformance = null;
            if (month == 1)
            {
                lastMonthHistoryConsulationCardRefundPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, 12, null, true, LiveAnchorInfo);
            }
            else
            {
                lastMonthHistoryConsulationCardRefundPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year, month - 1, null, true, LiveAnchorInfo);
            }
            //上月的历史面诊卡退单
            var lastMonthHistoryConsulationCardRefundPerformanceCount = lastMonthHistoryConsulationCardRefundPerformance.Count();
            baseBusinessPerformanceDto.HistoryConsulationCardRefundCompleteRateChainRatio = CalculateChainratio(historyConsulationCardRefundCount, lastMonthHistoryConsulationCardRefundPerformanceCount);
            //上年的历史面诊卡退单
            var lastYearHistoryConsulationCardRefundPerformance = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameAsync(year - 1, month, null, true, LiveAnchorInfo);
            var lastYearTotalHistoryConsulationCardRefundPerformance = lastYearHistoryConsulationCardRefundPerformance.Count();
            baseBusinessPerformanceDto.HistoryConsulationCardRefundCompleteRateYearOnYear = CalculateYearOnYear(historyConsulationCardRefundCount, lastYearTotalHistoryConsulationCardRefundPerformance);

            #endregion


            return baseBusinessPerformanceDto;

        }
        #endregion


        #region[新运营看板业务层]
        /// <summary>
        /// 运营看板
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        public async Task<AmiyaOperationDataDto> GetPerformanceOperationDataAsync(int year, int month, string contentPlatFormId, bool isEffectiveCustomerData)
        {
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month);
            AmiyaOperationDataDto amiyaOperationDataDto = new AmiyaOperationDataDto();
            var groupPerformanceTargetLiving = await liveAnchorMonthlyTargetLivingService.GetConsulationCardAddTargetByDateAsync(year, month);
            var groupPerformanceTarget = await liveAnchorMonthlyTargetAfterLivingService.GetAfterLivingTargetByDateAsync(year, month);


            NewCustomerOperationDataDto newCustomerOperationDataDto = new NewCustomerOperationDataDto();
            newCustomerOperationDataDto.newCustomerOperationDataDetails = new List<NewCustomerOperationDataDetails>();
            OldCustomerOperationDataDto oldCustomerOperationDataDto = new OldCustomerOperationDataDto();
            #region{小黄车数据}

            //小黄车数据
            var baseBusinessPerformance = await shoppingCartRegistrationService.GetNewBaseBusinessPerformanceByLiveAnchorNameAsync(sequentialDate.StartDate, sequentialDate.EndDate, isEffectiveCustomerData, contentPlatFormId);
            //上月的小黄车数据
            List<ShoppingCartRegistrationDto> lastMonthShoppingCardPerformance = null;
            lastMonthShoppingCardPerformance = await shoppingCartRegistrationService.GetNewBaseBusinessPerformanceByLiveAnchorNameAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, isEffectiveCustomerData, contentPlatFormId);
            //上年的小黄车数据
            var lastYearShoppingCardPerformance = await shoppingCartRegistrationService.GetNewBaseBusinessPerformanceByLiveAnchorNameAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, isEffectiveCustomerData, contentPlatFormId);
            #endregion

            #region{订单数据}
            var baseOrderPerformance = await contentPlateFormOrderService.GetOrderSendAndDealDataByMonthAsync(sequentialDate.StartDate, sequentialDate.EndDate, isEffectiveCustomerData, contentPlatFormId);

            var baseLastMonthOrderPerformance = await contentPlateFormOrderService.GetOrderSendAndDealDataByMonthAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, isEffectiveCustomerData, contentPlatFormId);

            var baseLastYearOrderPerformance = await contentPlateFormOrderService.GetOrderSendAndDealDataByMonthAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, isEffectiveCustomerData, contentPlatFormId);
            #endregion

            #region 【面诊卡下单】
            //面诊卡下单
            NewCustomerOperationDataDetails addCarddetails = new NewCustomerOperationDataDetails();
            addCarddetails.Key = "AddCard";
            addCarddetails.Name = "下卡量";
            addCarddetails.Value = baseBusinessPerformance.Count();


            //上月的面诊卡下单
            var lastMonthConsulationAddCardPerformanceCount = lastMonthShoppingCardPerformance.Count();
            addCarddetails.ChainRatioValue = CalculateChainratio(addCarddetails.Value, lastMonthConsulationAddCardPerformanceCount);

            var lastYearTotalConsulationAddCardPerformance = lastYearShoppingCardPerformance.Count();
            addCarddetails.YearToYearValue = CalculateYearOnYear(addCarddetails.Value, lastYearTotalConsulationAddCardPerformance);
            //目标达成
            addCarddetails.TargetCompleteRate = CalculateTargetComplete(addCarddetails.Value, groupPerformanceTargetLiving.ConsulationCardTarget);
            newCustomerOperationDataDto.newCustomerOperationDataDetails.Add(addCarddetails);
            #endregion

            #region 【面诊卡退单】
            //面诊卡退款
            NewCustomerOperationDataDetails refundCarddetails = new NewCustomerOperationDataDetails();
            refundCarddetails.Key = "RefundCard";
            refundCarddetails.Name = "退卡量";
            refundCarddetails.Value = baseBusinessPerformance.Where(x => x.IsReturnBackPrice == true).Count();

            //上月的面诊卡退款
            var lastMonthConsulationRefundCardPerformanceCount = lastMonthShoppingCardPerformance.Where(x => x.IsReturnBackPrice == true).Count();
            refundCarddetails.ChainRatioValue = CalculateChainratio(refundCarddetails.Value, lastMonthConsulationRefundCardPerformanceCount);
            //上年的面诊卡退款
            var lastYearTotalConsulationRefundCardPerformance = lastYearShoppingCardPerformance.Where(x => x.IsReturnBackPrice == true).Count();
            refundCarddetails.YearToYearValue = CalculateYearOnYear(refundCarddetails.Value, lastYearTotalConsulationRefundCardPerformance);
            //目标达成
            refundCarddetails.TargetCompleteRate = CalculateTargetComplete(refundCarddetails.Value, groupPerformanceTargetLiving.LivingRefundCardTarget + groupPerformanceTarget.ConsulationCardRefundTarget);
            newCustomerOperationDataDto.newCustomerOperationDataDetails.Add(refundCarddetails);
            #endregion
            //退卡率
            newCustomerOperationDataDto.RefundCardRate = CalculateTargetComplete(refundCarddetails.Value, addCarddetails.Value);
            newCustomerOperationDataDto.RefundCardRateHealthValueSum = await healthValueService.GetValueByCode("RefundCardHealthValueSum");
            newCustomerOperationDataDto.RefundCardRateHealthValueThisMonth = await healthValueService.GetValueByCode("RefundCardHealthValueThisMonth");

            #region 【分诊】
            //分诊
            NewCustomerOperationDataDetails consulationdetails = new NewCustomerOperationDataDetails();
            consulationdetails.Key = "Consulation";
            consulationdetails.Name = "分诊量";
            consulationdetails.Value = baseBusinessPerformance.Where(x => x.AssignEmpId != 0 && x.AssignEmpId.HasValue && x.IsReturnBackPrice == false).Count();

            //上月的分诊
            var lastMonthConsulationConsulationPerformanceCount = lastMonthShoppingCardPerformance.Where(x => x.AssignEmpId != 0 && x.AssignEmpId.HasValue).Count();
            consulationdetails.ChainRatioValue = CalculateChainratio(consulationdetails.Value, lastMonthConsulationConsulationPerformanceCount);
            //上年的分诊
            var lastYearTotalConsulationConsulationPerformance = lastYearShoppingCardPerformance.Where(x => x.AssignEmpId != 0 && x.AssignEmpId.HasValue).Count();
            consulationdetails.YearToYearValue = CalculateYearOnYear(consulationdetails.Value, lastYearTotalConsulationConsulationPerformance);
            //目标达成
            consulationdetails.TargetCompleteRate = CalculateTargetComplete(consulationdetails.Value, groupPerformanceTarget.ConsulationCardConsumedTarget);
            newCustomerOperationDataDto.newCustomerOperationDataDetails.Add(consulationdetails);
            #endregion

            #region 【加v】
            NewCustomerOperationDataDetails addWechatdetails = new NewCustomerOperationDataDetails();
            //加v
            addWechatdetails.Key = "AddWeChat";
            addWechatdetails.Name = "加v量";
            addWechatdetails.Value = baseBusinessPerformance.Where(x => x.IsAddWeChat == true && x.AssignEmpId != 0 && x.AssignEmpId.HasValue && x.IsReturnBackPrice == false).Count();

            //上月的分诊
            var lastMonthAddWechatPerformanceCount = lastMonthShoppingCardPerformance.Where(x => x.IsAddWeChat == true).Count();
            addWechatdetails.ChainRatioValue = CalculateChainratio(addWechatdetails.Value, lastMonthAddWechatPerformanceCount);
            //上年的分诊
            var lastYearTotalAddWechatPerformance = lastYearShoppingCardPerformance.Where(x => x.IsAddWeChat == true).Count();
            addWechatdetails.YearToYearValue = CalculateYearOnYear(addWechatdetails.Value, lastYearTotalAddWechatPerformance);
            //目标达成
            addWechatdetails.TargetCompleteRate = CalculateTargetComplete(addWechatdetails.Value, groupPerformanceTarget.AddWeChatTarget);
            newCustomerOperationDataDto.newCustomerOperationDataDetails.Add(addWechatdetails);
            #endregion
            //加v率
            newCustomerOperationDataDto.AddWeChatRate = CalculateTargetComplete(addWechatdetails.Value, consulationdetails.Value);
            newCustomerOperationDataDto.AddWeChatRateHealthValueSum = await healthValueService.GetValueByCode("AddWeChatHealthValueSum");
            newCustomerOperationDataDto.AddWeChatRateHealthValueThisMonth = await healthValueService.GetValueByCode("AddWeChatHealthValueThisMonth");

            #region 【派单】
            NewCustomerOperationDataDetails sendOrderdetails = new NewCustomerOperationDataDetails();
            //派单
            sendOrderdetails.Key = "AddWeChat";
            sendOrderdetails.Name = "派单量";
            sendOrderdetails.Value = baseOrderPerformance.SendOrderNum;

            //上月的派单
            var lastMonthSendOrderPerformanceCount = baseLastMonthOrderPerformance.SendOrderNum;
            sendOrderdetails.ChainRatioValue = CalculateChainratio(sendOrderdetails.Value, lastMonthSendOrderPerformanceCount);
            //上年的派单
            var lastYearTotalSendOrderPerformance = baseLastYearOrderPerformance.SendOrderNum;
            sendOrderdetails.YearToYearValue = CalculateYearOnYear(sendOrderdetails.Value, lastYearTotalSendOrderPerformance);
            //目标达成
            sendOrderdetails.TargetCompleteRate = CalculateTargetComplete(sendOrderdetails.Value, groupPerformanceTarget.SendOrderTarget);
            newCustomerOperationDataDto.newCustomerOperationDataDetails.Add(sendOrderdetails);
            #endregion
            //派单率
            newCustomerOperationDataDto.SendOrderRate = CalculateTargetComplete(sendOrderdetails.Value, addWechatdetails.Value);
            newCustomerOperationDataDto.SendOrderRateHealthValueSum = await healthValueService.GetValueByCode("SendOrderRateHealthValueSum");
            newCustomerOperationDataDto.SendOrderRateHealthValueThisMonth = await healthValueService.GetValueByCode("SendOrderRateHealthValueThisMonth");

            #region 【上门】
            NewCustomerOperationDataDetails visitdetails = new NewCustomerOperationDataDetails();
            //上门
            visitdetails.Key = "AddWeChat";
            visitdetails.Name = "上门量";
            visitdetails.Value = baseOrderPerformance.VisitNum;

            //上月的上门
            var lastMonthVisitPerformanceCount = baseLastMonthOrderPerformance.VisitNum;
            visitdetails.ChainRatioValue = CalculateChainratio(visitdetails.Value, lastMonthVisitPerformanceCount);
            //上年的上门
            var lastYearTotalVisitPerformance = baseLastYearOrderPerformance.VisitNum;
            visitdetails.YearToYearValue = CalculateYearOnYear(visitdetails.Value, lastYearTotalVisitPerformance);
            //目标达成
            visitdetails.TargetCompleteRate = CalculateTargetComplete(visitdetails.Value, groupPerformanceTarget.NewCustomerVisitTarget);
            newCustomerOperationDataDto.newCustomerOperationDataDetails.Add(visitdetails);
            #endregion
            //上门率
            newCustomerOperationDataDto.ToHospitalRate = CalculateTargetComplete(visitdetails.Value, sendOrderdetails.Value);
            newCustomerOperationDataDto.ToHospitalRateHealthValueSum = await healthValueService.GetValueByCode("ToHospitalRateHealthValueSum");
            newCustomerOperationDataDto.ToHospitalRateHealthValueThisMonth = await healthValueService.GetValueByCode("ToHospitalRateHealthValueThisMonth");

            #region 【成交】
            NewCustomerOperationDataDetails dealdetails = new NewCustomerOperationDataDetails();
            //成交
            dealdetails.Key = "AddWeChat";
            dealdetails.Name = "成交量";
            dealdetails.Value = baseOrderPerformance.DealNum;

            //上月的成交
            var lastMonthDealPerformanceCount = baseLastMonthOrderPerformance.DealNum;
            dealdetails.ChainRatioValue = CalculateChainratio(dealdetails.Value, lastMonthDealPerformanceCount);
            //上年的成交
            var lastYearTotalDealPerformance = baseLastYearOrderPerformance.DealNum;
            dealdetails.YearToYearValue = CalculateYearOnYear(dealdetails.Value, lastYearTotalDealPerformance);
            //目标达成
            dealdetails.TargetCompleteRate = CalculateTargetComplete(dealdetails.Value, groupPerformanceTarget.NewCustomerDealTarget);
            newCustomerOperationDataDto.newCustomerOperationDataDetails.Add(dealdetails);
            #endregion
            //成交率
            newCustomerOperationDataDto.DealRate = CalculateTargetComplete(dealdetails.Value, visitdetails.Value);
            newCustomerOperationDataDto.DealRateHealthValueThisMonth = await healthValueService.GetValueByCode("DealRateHealthValueThisMonth");
            newCustomerOperationDataDto.DealRateHealthValueSum = await healthValueService.GetValueByCode("DealRateHealthValueSum");


            //派单成交转化率
            newCustomerOperationDataDto.SendOrderToDealRate = CalculateTargetComplete(dealdetails.Value, sendOrderdetails.Value);
            //分诊成交转化率
            newCustomerOperationDataDto.AllocationConsulationToDealRate = CalculateTargetComplete(dealdetails.Value, consulationdetails.Value);
            if (baseOrderPerformance.DealPrice.HasValue)
            {
                if (sendOrderdetails.Value != 0)
                    //派单成交能效
                    newCustomerOperationDataDto.SendOrderToDealPrice = Math.Round(baseOrderPerformance.DealPrice.Value / sendOrderdetails.Value, 2, MidpointRounding.AwayFromZero);
                if (consulationdetails.Value != 0)
                    //分诊成交能效
                    newCustomerOperationDataDto.AllocationConsulationToDealPrice = Math.Round(baseOrderPerformance.DealPrice.Value / consulationdetails.Value, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                //派单成交能效
                newCustomerOperationDataDto.SendOrderToDealPrice = 0.00M;
                //分诊成交能效
                newCustomerOperationDataDto.AllocationConsulationToDealPrice = 0.00M;
            }

            amiyaOperationDataDto.NewCustomerData = newCustomerOperationDataDto;
            //老客数据
            var oldCustomerData = await contentPlateFormOrderService.GetOldCustomerBuyAgainByMonthAsync(sequentialDate.StartDate,isEffectiveCustomerData,contentPlatFormId);
            oldCustomerOperationDataDto.TotalDealPeople = oldCustomerData.TotalDealCustomer;
            oldCustomerOperationDataDto.SecondDealPeople = oldCustomerData.SecondDealCustomer;
            oldCustomerOperationDataDto.ThirdDealPeople = oldCustomerData.ThirdDealCustomer;
            oldCustomerOperationDataDto.FourthOrMoreDealPeople = oldCustomerData.FourthOrMoreDealCustomer;
            oldCustomerOperationDataDto.SecondTimeBuyRate = CalculateTargetComplete(Convert.ToDecimal(oldCustomerOperationDataDto.SecondDealPeople), Convert.ToDecimal(oldCustomerOperationDataDto.TotalDealPeople)).Value;
            oldCustomerOperationDataDto.SecondTimeBuyRateProportion = oldCustomerOperationDataDto.SecondTimeBuyRate;

            oldCustomerOperationDataDto.ThirdTimeBuyRate = CalculateTargetComplete(Convert.ToDecimal(oldCustomerOperationDataDto.ThirdDealPeople), Convert.ToDecimal(oldCustomerOperationDataDto.TotalDealPeople)).Value;
            oldCustomerOperationDataDto.ThirdTimeBuyRateProportion = oldCustomerOperationDataDto.ThirdTimeBuyRate;

            oldCustomerOperationDataDto.FourthTimeOrMoreBuyRate = CalculateTargetComplete(Convert.ToDecimal(oldCustomerOperationDataDto.FourthOrMoreDealPeople), Convert.ToDecimal(oldCustomerOperationDataDto.TotalDealPeople)).Value;
            oldCustomerOperationDataDto.FourthTimeOrMoreBuyRateProportion = oldCustomerOperationDataDto.FourthTimeOrMoreBuyRate;

            oldCustomerOperationDataDto.BuyRate = CalculateTargetComplete(Convert.ToDecimal(oldCustomerOperationDataDto.FourthOrMoreDealPeople + oldCustomerOperationDataDto.ThirdDealPeople + oldCustomerOperationDataDto.SecondDealPeople), Convert.ToDecimal(oldCustomerOperationDataDto.TotalDealPeople)).Value;

            amiyaOperationDataDto.OldCustomerData = oldCustomerOperationDataDto;
            return amiyaOperationDataDto;

        }
        #endregion

        //企业微信

        #region 【公司累计总业绩】
        /// <summary>
        /// 公司累计总业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<CompanyMonthPerformanceBWDto> GetMonthPerformanceAsync(int year, int month)
        {
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month);
            //获取自播主播ID
            var SelfLiveAnchorInfo = await this.GetLiveAnchorIdsByBaseIdAndIsSelfLiveAnchorAsync("", true);
            //获取合作达人主播ID
            var OtherLiveAnchorInfo = await this.GetLiveAnchorIdsByBaseIdAndIsSelfLiveAnchorAsync("", false);
            //获取自播达人目标
            var selfLiveAnchortarget = await liveAnchorMonthlyTargetAfterLivingService.GetPerformance(year, month, SelfLiveAnchorInfo);
            //获取合作达人目标
            var otherLiveAnchortarget = await liveAnchorMonthlyTargetAfterLivingService.GetPerformance(year, month, OtherLiveAnchorInfo);

            #region 自播达人业绩
            //总业绩
            var selfLiveAnchorOrder = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAsync(sequentialDate.StartDate, sequentialDate.EndDate, SelfLiveAnchorInfo);
            var curSelfLiveAnchorTotalPerformance = selfLiveAnchorOrder.Sum(o => o.Price);
            //同比业绩
            var selfLiveAnchorOrderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, SelfLiveAnchorInfo);
            var selfLiveAnchorTotalPerformanceYearOnYear = selfLiveAnchorOrderYearOnYear.Sum(o => o.Price);
            //环比业绩
            var selfLiveAnchorOrderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, SelfLiveAnchorInfo);
            var selfLiveAnchorTotalPerformanceChainRatio = selfLiveAnchorOrderChain.Sum(o => o.Price);
            #endregion

            #region 合作达人业绩
            //总业绩
            var otherLiveAnchorOrder = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAsync(sequentialDate.StartDate, sequentialDate.EndDate, OtherLiveAnchorInfo);
            var curOtherLiveAnchorTotalPerformance = otherLiveAnchorOrder.Sum(o => o.Price);
            //同比业绩
            var otherLiveAnchorOrderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, OtherLiveAnchorInfo);
            var otherLiveAnchorTotalPerformanceYearOnYear = otherLiveAnchorOrderYearOnYear.Sum(o => o.Price);
            //环比业绩
            var otherLiveAnchorOrderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, OtherLiveAnchorInfo);
            var otherLiveAnchorTotalPerformanceChainRatio = otherLiveAnchorOrderChain.Sum(o => o.Price);
            #endregion

            #region 带货业绩
            List<int> LiveAnchorInfo = new List<int>();
            var target = await liveAnchorMonthlyTargetLivingService.GetPerformance(year, month, LiveAnchorInfo);
            var commercePerformanceYearOnYear = await liveAnchorMonthlyTargetLivingService.GetPerformance(sequentialDate.LastYearThisMonthStartDate.Year, sequentialDate.LastYearThisMonthEndDate.Month, LiveAnchorInfo);
            var commercePerformanceChainRatio = await liveAnchorMonthlyTargetLivingService.GetPerformance(sequentialDate.LastMonthStartDate.Year, sequentialDate.LastMonthEndDate.Month, LiveAnchorInfo);
            #endregion

            #region 其他业绩(todo;)

            #endregion

            #region 总业绩
            var totalPerformance = Math.Round(curSelfLiveAnchorTotalPerformance + curOtherLiveAnchorTotalPerformance + target.CommerceCompletePerformance, MidpointRounding.AwayFromZero);
            var lastMonthPerformance = Math.Round(selfLiveAnchorTotalPerformanceChainRatio + otherLiveAnchorTotalPerformanceChainRatio + commercePerformanceChainRatio.CommerceCompletePerformance, MidpointRounding.AwayFromZero);
            #endregion

            //数据组合
            CompanyMonthPerformanceBWDto monthPerformanceRatioDto = new CompanyMonthPerformanceBWDto
            {

                SelfLiveAnchorPerformance = curSelfLiveAnchorTotalPerformance,
                SelfLiveAnchorPerformanceTarget = DecimalExtension.ChangePriceToTenThousand(selfLiveAnchortarget.TotalPerformanceTarget),
                SelfLiveAnchorPerformanceCompleteRate = CalculateTargetComplete(curSelfLiveAnchorTotalPerformance, selfLiveAnchortarget.TotalPerformanceTarget),
                SelfLiveAnchorPerformanceYearToYear = CalculateYearOnYear(curSelfLiveAnchorTotalPerformance, selfLiveAnchorTotalPerformanceYearOnYear),
                SelfLiveAnchorPerformanceChainRatio = CalculateChainratio(curSelfLiveAnchorTotalPerformance, selfLiveAnchorTotalPerformanceChainRatio),

                OtherLiveAnchorPerformance = curOtherLiveAnchorTotalPerformance,
                OtherLiveAnchorPerformanceTarget = DecimalExtension.ChangePriceToTenThousand(otherLiveAnchortarget.TotalPerformanceTarget),
                OtherLiveAnchorPerformanceCompleteRate = CalculateTargetComplete(curOtherLiveAnchorTotalPerformance, otherLiveAnchortarget.TotalPerformanceTarget),
                OtherLiveAnchorPerformanceYearToYear = CalculateYearOnYear(curOtherLiveAnchorTotalPerformance, otherLiveAnchorTotalPerformanceYearOnYear),
                OtherLiveAnchorPerformanceChainRatio = CalculateChainratio(curOtherLiveAnchorTotalPerformance, otherLiveAnchorTotalPerformanceChainRatio),

                CommercePerformance = target.CommerceCompletePerformance,
                CommercePerformanceTarget = DecimalExtension.ChangePriceToTenThousand(target.CommercePerformanceTarget),
                CommercePerformanceCompleteRate = CalculateTargetComplete(target.CommerceCompletePerformance, target.CommercePerformanceTarget),
                CommercePerformanceYearToYear = CalculateYearOnYear(target.CommerceCompletePerformance, commercePerformanceYearOnYear.CommerceCompletePerformance),
                CommercePerformanceChainRatio = CalculateChainratio(target.CommerceCompletePerformance, commercePerformanceChainRatio.CommerceCompletePerformance),

                OtherPerformance = 0.00M,
                OtherPerformanceTarget = 0.00M,
                OtherPerformanceCompleteRate = 0.00M,
                OtherPerformanceYearToYear = 0.00M,
                OtherPerformanceChainRatio = 0.00M,

                TotalPerformance = totalPerformance,
                TotalPerformanceChainRatio = CalculateChainratio(totalPerformance, lastMonthPerformance),
                SelfLiveAnchorPerformanceRatio = CalculateTargetComplete(curSelfLiveAnchorTotalPerformance, totalPerformance),
                OtherLiveAnchorPerformanceRatio = CalculateTargetComplete(curOtherLiveAnchorTotalPerformance, totalPerformance),
                CommercePerformanceRatio = CalculateTargetComplete(target.CommerceCompletePerformance, totalPerformance),
                OtherPerformanceRatio = 0.00M,
            };

            return monthPerformanceRatioDto;
        }

        #endregion

        #region 【自播/合作达人总业绩】
        /// <summary>
        /// 自播/合作达人总业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<MonthPerformanceBWDto> GetMonthPerformanceBySelfLiveAnchorAsync(int year, int month, string liveAnchorBaseId, bool? isSelfLiveAnchor)
        {
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month);
            //获取各个平台的主播ID
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByBaseIdAndIsSelfLiveAnchorAsync(liveAnchorBaseId, isSelfLiveAnchor);
            //获取目标
            var target = await liveAnchorMonthlyTargetAfterLivingService.GetPerformance(year, month, LiveAnchorInfo);

            #region 总业绩
            //总业绩
            var order = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAsync(sequentialDate.StartDate, sequentialDate.EndDate, LiveAnchorInfo);
            var curTotalPerformance = order.Sum(o => o.Price);
            //同比业绩
            var orderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, LiveAnchorInfo);
            var totalPerformanceYearOnYear = orderYearOnYear.Sum(o => o.Price);
            //环比业绩
            var orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, LiveAnchorInfo);
            var totalPerformanceChainRatio = orderChain.Sum(o => o.Price);
            #endregion

            #region 新客业绩
            var curNewCustomer = order.Where(o => o.IsOldCustomer == false).Sum(o => o.Price);
            var newOrderYearOnYear = orderYearOnYear.Where(x => x.IsOldCustomer == false);
            var newPerformanceYearOnYear = newOrderYearOnYear.Sum(o => o.Price);
            List<ContentPlatFormOrderDealInfoDto> newOrderChainRatio = orderChain.Where(x => x.IsOldCustomer == false).ToList();
            var newPerformanceChainRatio = newOrderChainRatio.Sum(o => o.Price);
            #endregion

            #region 老客业绩
            var curOldCustomer = order.Where(o => o.IsOldCustomer == true).Sum(o => o.Price);
            var oldOrderYearOnYear = orderYearOnYear.Where(x => x.IsOldCustomer == true);
            var oldPerformanceYearOnYear = oldOrderYearOnYear.Sum(o => o.Price);
            List<ContentPlatFormOrderDealInfoDto> oldOrderChainRatio = orderChain.Where(x => x.IsOldCustomer == true).ToList();
            var oldPerformanceRatio = oldOrderChainRatio.Sum(o => o.Price);
            #endregion

            #region 视频业绩
            var curVideoPerformance = order.Where(o => o.ConsultationType == (int)ContentPlateFormOrderConsultationType.Collaboration).Sum(o => o.Price);
            var videoYearOnYearr = orderYearOnYear.Where(x => x.ConsultationType == (int)ContentPlateFormOrderConsultationType.Collaboration).ToList();
            var videoPerformanceYearOnYear = videoYearOnYearr.Sum(o => o.Price);
            var videoOrderChainRatio = orderChain.Where(x => x.ConsultationType == (int)ContentPlateFormOrderConsultationType.Collaboration).ToList();
            var videoPerformanceRatio = videoOrderChainRatio.Sum(o => o.Price);
            #endregion

            #region 照片业绩
            var curPicturePerformance = order.Where(o => o.ConsultationType == (int)ContentPlateFormOrderConsultationType.IndependentFollowUp).Sum(o => o.Price);
            var pictureYearOnYearr = orderYearOnYear.Where(x => x.ConsultationType == (int)ContentPlateFormOrderConsultationType.IndependentFollowUp).ToList();
            var picturePerformanceYearOnYear = pictureYearOnYearr.Sum(o => o.Price);
            var pictureOrderChainRatio = orderChain.Where(x => x.ConsultationType == (int)ContentPlateFormOrderConsultationType.IndependentFollowUp).ToList();
            var picturePerformanceRatio = pictureOrderChainRatio.Sum(o => o.Price);
            #endregion

            #region 主播接诊业绩
            var curLiveAnchorAcompanyingPerformance = order.Where(o => o.IsAcompanying == true).Sum(o => o.Price);
            var liveAnchorAcompanyingYearOnYearr = orderYearOnYear.Where(x => x.IsAcompanying == true).ToList();
            var liveAnchorAcompanyingPerformanceYearOnYear = liveAnchorAcompanyingYearOnYearr.Sum(o => o.Price);
            var liveAnchorAcompanyingOrderChainRatio = orderChain.Where(x => x.IsAcompanying == true).ToList();
            var liveAnchorAcompanyingPerformanceRatio = liveAnchorAcompanyingOrderChainRatio.Sum(o => o.Price);
            #endregion

            #region 非主播接诊业绩
            var curNotLiveAnchorAcompanyingPerformance = order.Where(o => o.IsAcompanying == false).Sum(o => o.Price);
            var notLiveAnchorAcompanyingYearOnYearr = orderYearOnYear.Where(x => x.IsAcompanying == false).ToList();
            var notLiveAnchorAcompanyingPerformanceYearOnYear = notLiveAnchorAcompanyingYearOnYearr.Sum(o => o.Price);
            var notLiveAnchorAcompanyingOrderChainRatio = orderChain.Where(x => x.IsAcompanying == false).ToList();
            var notLiveAnchorAcompanyingPerformanceRatio = notLiveAnchorAcompanyingOrderChainRatio.Sum(o => o.Price);
            #endregion

            #region 有效业绩
            //199业绩
            var curHavingPricePerformance = order.Where(o => o.AddOrderPrice > 0).Sum(o => o.Price);
            var havingPriceYearOnYearr = orderYearOnYear.Where(x => x.AddOrderPrice > 0).ToList();
            var havingPricePerformanceYearOnYear = havingPriceYearOnYearr.Sum(o => o.Price);
            var havingPriceOrderChainRatio = orderChain.Where(x => x.AddOrderPrice > 0).ToList();
            var havingPricePerformanceRatio = havingPriceOrderChainRatio.Sum(o => o.Price);

            //负数业绩
            curHavingPricePerformance += order.Where(o => o.AddOrderPrice < 0).Sum(o => o.Price);
            havingPricePerformanceYearOnYear += orderYearOnYear.Where(x => x.AddOrderPrice < 0).Sum(o => o.Price);
            havingPricePerformanceRatio += orderChain.Where(x => x.AddOrderPrice < 0).Sum(o => o.Price);
            #endregion

            #region 潜在业绩
            var curNotHavePricePerformance = order.Where(o => o.AddOrderPrice == 0).Sum(o => o.Price);
            var notHavePriceYearOnYearr = orderYearOnYear.Where(x => x.AddOrderPrice == 0).ToList();
            var notHavePricePerformanceYearOnYear = notHavePriceYearOnYearr.Sum(o => o.Price);
            var notHavePriceOrderChainRatio = orderChain.Where(x => x.AddOrderPrice == 0).ToList();
            var notHavePricePerformanceRatio = notHavePriceOrderChainRatio.Sum(o => o.Price);
            #endregion

            #region 当月派单当月成交业绩
            //总业绩
            var thisMonthSendAndDealInfo = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceAsync(sequentialDate.StartDate, sequentialDate.EndDate, false, LiveAnchorInfo);
            var thisMonthSendAndDealPerformance = thisMonthSendAndDealInfo.Sum(o => o.Price);
            //同比业绩
            var thisMonthSendAndDealInfoYearOnYear = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, false, LiveAnchorInfo);
            var thisMonthSendAndDealPerformanceYearOnYear = thisMonthSendAndDealInfoYearOnYear.Sum(o => o.Price);
            //环比业绩
            var thisMonthSendAndDealPerformanceChain = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, false, LiveAnchorInfo);
            var thisMonthSendAndDealPerformanceChainRatio = orderChain.Sum(o => o.Price);
            #endregion

            #region 历史派单当月成交业绩
            //总业绩
            var historyMonthSendAndDealInfo = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceAsync(sequentialDate.StartDate, sequentialDate.EndDate, true, LiveAnchorInfo);
            var historyMonthSendAndDealPerformance = historyMonthSendAndDealInfo.Sum(o => o.Price);
            //同比业绩
            var historyMonthSendAndDealInfoYearOnYear = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, true, LiveAnchorInfo);
            var historyMonthSendAndDealPerformanceYearOnYear = historyMonthSendAndDealInfoYearOnYear.Sum(o => o.Price);
            //环比业绩
            var historyMonthSendAndDealPerformanceChain = await contentPlatFormOrderDealInfoService.GetSendAndDealPerformanceAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, true, LiveAnchorInfo);
            var historyMonthSendAndDealPerformanceChainRatio = orderChain.Sum(o => o.Price);
            #endregion

            //数据组合
            MonthPerformanceBWDto monthPerformanceRatioDto = new MonthPerformanceBWDto
            {
                CueerntMonthTotalPerformance = DecimalExtension.ChangePriceToTenThousand(curTotalPerformance),
                TotalPerformanceYearOnYear = CalculateYearOnYear(curTotalPerformance, totalPerformanceYearOnYear),
                TotalPerformanceChainratio = CalculateChainratio(curTotalPerformance, totalPerformanceChainRatio),
                TotalPerformanceTarget = DecimalExtension.ChangePriceToTenThousand(target.TotalPerformanceTarget),
                TotalPerformanceTargetComplete = CalculateTargetComplete(curTotalPerformance, target.TotalPerformanceTarget),

                CurrentMonthNewCustomerPerformance = DecimalExtension.ChangePriceToTenThousand(curNewCustomer),
                NewCustomerPerformanceRatio = CalculateTargetComplete(curNewCustomer, curTotalPerformance),
                NewCustomerPerformanceYearOnYear = CalculateYearOnYear(curNewCustomer, newPerformanceYearOnYear),
                NewCustomerPerformanceChainRatio = CalculateChainratio(curNewCustomer, newPerformanceChainRatio),
                NewCustomerPerformanceTarget = DecimalExtension.ChangePriceToTenThousand(target.NewCustomerPerformanceTarget),
                NewCustomerPerformanceTargetComplete = CalculateTargetComplete(curNewCustomer, target.NewCustomerPerformanceTarget),

                CurrentMonthOldCustomerPerformance = DecimalExtension.ChangePriceToTenThousand(curOldCustomer),
                OldCustomerPerformanceRatio = CalculateTargetComplete(curOldCustomer, curTotalPerformance),
                OldCustomerPerformanceYearOnYear = CalculateYearOnYear(curOldCustomer, oldPerformanceYearOnYear),
                OldCustomerPerformanceChainRatio = CalculateChainratio(curOldCustomer, oldPerformanceRatio),
                OldCustomerTarget = DecimalExtension.ChangePriceToTenThousand(target.OldCustomerPerformanceTarget),
                OldCustomerTargetComplete = CalculateTargetComplete(curOldCustomer, target.OldCustomerPerformanceTarget),


                PictureConsultationPerformance = DecimalExtension.ChangePriceToTenThousand(curPicturePerformance),
                PictureConsultationPerformanceRatio = CalculateTargetComplete(curPicturePerformance, curTotalPerformance),
                PictureConsultationPerformanceYearOnYear = CalculateYearOnYear(curPicturePerformance, picturePerformanceYearOnYear),
                PictureConsultationPerformanceChainRatio = CalculateChainratio(curPicturePerformance, picturePerformanceRatio),

                VideoConsultationPerformance = DecimalExtension.ChangePriceToTenThousand(curVideoPerformance),
                VideoConsultationPerformanceRatio = CalculateTargetComplete(curVideoPerformance, curTotalPerformance),
                VideoConsultationPerformanceYearOnYear = CalculateYearOnYear(curVideoPerformance, videoPerformanceYearOnYear),
                VideoConsultationPerformanceChainRatio = CalculateChainratio(curVideoPerformance, videoPerformanceRatio),


                AcompanyingPerformance = DecimalExtension.ChangePriceToTenThousand(curLiveAnchorAcompanyingPerformance),
                AcompanyingPerformanceRatio = CalculateTargetComplete(curLiveAnchorAcompanyingPerformance, curTotalPerformance),
                AcompanyingPerformanceYearOnYear = CalculateYearOnYear(curLiveAnchorAcompanyingPerformance, liveAnchorAcompanyingPerformanceYearOnYear),
                AcompanyingPerformanceChainRatio = CalculateChainratio(curLiveAnchorAcompanyingPerformance, liveAnchorAcompanyingPerformanceRatio),


                NotAcompanyingPerformance = DecimalExtension.ChangePriceToTenThousand(curNotLiveAnchorAcompanyingPerformance),
                NotAcompanyingPerformanceRatio = CalculateTargetComplete(curNotLiveAnchorAcompanyingPerformance, curTotalPerformance),
                NotAcompanyingPerformanceYearOnYear = CalculateYearOnYear(curNotLiveAnchorAcompanyingPerformance, notLiveAnchorAcompanyingPerformanceYearOnYear),
                NotAcompanyingPerformanceChainRatio = CalculateChainratio(curNotLiveAnchorAcompanyingPerformance, notLiveAnchorAcompanyingPerformanceRatio),


                ZeroPricePerformance = DecimalExtension.ChangePriceToTenThousand(curNotHavePricePerformance),
                ZeroPricePerformanceRatio = CalculateTargetComplete(curNotHavePricePerformance, curTotalPerformance),
                ZeroPricePerformanceYearOnYear = CalculateYearOnYear(curNotHavePricePerformance, notHavePricePerformanceYearOnYear),
                ZeroPricePerformanceChainRatio = CalculateChainratio(curNotHavePricePerformance, notHavePricePerformanceRatio),


                ExistPricePerformance = DecimalExtension.ChangePriceToTenThousand(curHavingPricePerformance),
                ExistPricePerformanceRatio = CalculateTargetComplete(curHavingPricePerformance, curTotalPerformance),
                ExistPricePerformanceYearOnYear = CalculateYearOnYear(curHavingPricePerformance, havingPricePerformanceYearOnYear),
                ExistPricePerformanceChainRatio = CalculateChainratio(curHavingPricePerformance, havingPricePerformanceRatio),


                DuringMonthSendDuringMonthDeal = DecimalExtension.ChangePriceToTenThousand(thisMonthSendAndDealPerformance),
                DuringMonthSendDuringMonthDealPerformanceRatio = CalculateTargetComplete(thisMonthSendAndDealPerformance, curTotalPerformance),
                DuringMonthSendDuringMonthDealYearOnYear = CalculateYearOnYear(thisMonthSendAndDealPerformance, thisMonthSendAndDealPerformanceYearOnYear),
                DuringMonthSendDuringMonthDealChainRatio = CalculateChainratio(thisMonthSendAndDealPerformance, thisMonthSendAndDealPerformanceChainRatio),


                HistorySendDuringMonthDeal = DecimalExtension.ChangePriceToTenThousand(historyMonthSendAndDealPerformance),
                HistorySendDuringMonthDealPerformanceRatio = CalculateTargetComplete(historyMonthSendAndDealPerformance, curTotalPerformance),
                HistorySendDuringMonthDealYearOnYear = CalculateYearOnYear(historyMonthSendAndDealPerformance, historyMonthSendAndDealPerformanceYearOnYear),
                HistorySendDuringMonthDealChainRatio = CalculateChainratio(historyMonthSendAndDealPerformance, historyMonthSendAndDealPerformanceChainRatio),

            };
            return monthPerformanceRatioDto;
        }

        #endregion

        #region 【助理业绩】
        /// <summary>
        /// 根据主播基础id获取助理业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<List<CustomerPerformanceBWDto>> GetBelongCustomerServicePerformanceByLiveAnchorBaseIdAsync(int year, int month, string liveAnchorBaseId)
        {
            List<int> amiyaEmployeeIds = new List<int>();
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month);
            //获取绑定了该主播基础id的客服id集合
            var employeeInfos = await amiyaEmployeeService.GetByLiveAnchorBaseIdAsync(liveAnchorBaseId);
            amiyaEmployeeIds = employeeInfos.Select(x => x.Id).ToList();

            var dealInfo = await contentPlateFormOrderService.GetCustomerServiceBelongBoardDataByCustomerServiceIdAsync(sequentialDate.StartDate, sequentialDate.EndDate, amiyaEmployeeIds);
            //数据组合
            var monthPerformanceRatioDto = from d in dealInfo
                                           select new CustomerPerformanceBWDto()
                                           {
                                               CustomerServiceId = d.CustomerServiceId,
                                               CustomerServiceName = d.CustomerServiceName,
                                               NewCustomerPerformance = DecimalExtension.ChangePriceToTenThousand(d.NewCustomerPrice),
                                               OldCustomerPerformance = DecimalExtension.ChangePriceToTenThousand(d.OldCustomerPrice),
                                               TotalPerformance = DecimalExtension.ChangePriceToTenThousand(d.TotalServicePrice),
                                               VisitNumRatio = d.VisitNumRatio,
                                           };

            return monthPerformanceRatioDto.ToList();
        }

        /// <summary>
        /// 根据助理id获取助理简单业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="customerServiceId"></param>
        /// <returns></returns>
        public async Task<CustomerServiceSimplePerformanceDto> GetSimpleCustomerServicePerformanceDetails(int year, int month, int customerServiceId)
        {
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month);
            var dealInfo = await contentPlateFormOrderService.GetCustomerServiceSimpleByCustomerServiceIdAsync(sequentialDate.StartDate, sequentialDate.EndDate, customerServiceId);
            return dealInfo;
        }

        /// <summary>
        /// 获取我的排名
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="customerServiceId"></param>
        /// <returns></returns>
        public async Task<string> GetMyRankAsync(int year, int month, int customerServiceId)
        {
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month);
            var dealInfo = await contentPlateFormOrderService.GetMyRankAsync(sequentialDate.StartDate, sequentialDate.EndDate, customerServiceId);
            return dealInfo;
        }

        /// <summary>
        /// 根据助理id获取助理详细业绩
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="customerServiceId"></param>
        /// <returns></returns>
        public async Task<DetailCustomerPerformanceBWDto> GetCustomerServicePerformanceDetails(int year, int month, int customerServiceId)
        {
            List<int> customerServiceIdList = new List<int>();
            customerServiceIdList.Add(customerServiceId);
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month);
            var dealInfo = await contentPlateFormOrderService.GetCustomerServiceBelongBoardDataByCustomerServiceIdAsync(sequentialDate.StartDate, sequentialDate.EndDate, customerServiceIdList);
            var result = new DetailCustomerPerformanceBWDto();
            var selectResult = dealInfo.FirstOrDefault();
            if (selectResult == null)
            {
                return result;
            }
            //数据组合
            result = new DetailCustomerPerformanceBWDto()
            {
                CustomerServiceId = selectResult.CustomerServiceId,
                CustomerServiceName = selectResult.CustomerServiceName,
                NewCustomerPerformance = DecimalExtension.ChangePriceToTenThousand(selectResult.NewCustomerPrice),
                OldCustomerPerformance = DecimalExtension.ChangePriceToTenThousand(selectResult.OldCustomerPrice),
                TotalPerformance = DecimalExtension.ChangePriceToTenThousand(selectResult.TotalServicePrice),
                SupportPerformance = DecimalExtension.ChangePriceToTenThousand(selectResult.SupportPrice),
                VisitNumRatio = selectResult.VisitNumRatio,
                ThisMonthSendThisMonthVisitNumRatio = selectResult.ThisMonthSendThisMonthVisitNumRatio,

                VideoPerformance = DecimalExtension.ChangePriceToTenThousand(selectResult.VideoPerformance),
                PicturePerformance = DecimalExtension.ChangePriceToTenThousand(selectResult.PicturePerformance),
                VideoAndPictureCompare = selectResult.VideoAndPictureCompare,

                ZeroPerformance = DecimalExtension.ChangePriceToTenThousand(selectResult.ZeroPerformance),
                HavingPricePerformance = DecimalExtension.ChangePriceToTenThousand(selectResult.HavingPricePerformance),
                ZeroAndHavingPriceCompare = selectResult.ZeroAndHavingPriceCompare,

                AcompanyingPerformance = DecimalExtension.ChangePriceToTenThousand(selectResult.AcompanyingPerformance),
                NotAcompanyingPerformance = DecimalExtension.ChangePriceToTenThousand(selectResult.NotAcompanyingPerformance),
                IsAcompanyingCompare = selectResult.IsAcompanyingCompare,

                HistorySendThisMonthDealPerformance = DecimalExtension.ChangePriceToTenThousand(selectResult.HistorySendThisMonthDealPerformance),
                ThisMonthSendThisMonthDealPerformance = DecimalExtension.ChangePriceToTenThousand(selectResult.ThisMonthSendThisMonthDealPerformance),
                HistoryAndThisMonthCompare = selectResult.HistoryAndThisMonthCompare
            };

            return result;
        }

        #endregion

        #region 业绩看板

        /// <summary>
        /// 总业绩数据
        /// </summary>
        /// <param name="baseLiveanchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public async Task<AmiyaAchievementDataDto> GetTotalAndLiveanchorPerformanceAsync(string baseLiveanchorId, int year, int month, int day)
        {

            AmiyaAchievementDataDto amiyaAchievementDataDto = new AmiyaAchievementDataDto();
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month == 0 ? 1 : month);
            List<int> liveAnchorIds = new List<int>();
            if (!string.IsNullOrEmpty(baseLiveanchorId))
            {
                liveAnchorIds = await this.GetLiveAnchorIdsByBaseIdAndIsSelfLiveAnchorAsync(baseLiveanchorId, null);
            }
            var type = DetermineQueryTime(year, month, day);
            if (type == "year")
            {
                sequentialDate.StartDate = new DateTime(year, 1, 1);
                sequentialDate.EndDate = new DateTime(year + 1, 1, 1);
                sequentialDate.LastYearThisMonthStartDate = new DateTime(year - 1, 1, 1);
                sequentialDate.LastYearThisMonthEndDate = new DateTime(year, 1, 1);
            }
            if (type == "day")
            {
                sequentialDate.StartDate = new DateTime(year, month, day);
                sequentialDate.EndDate = sequentialDate.StartDate.AddDays(1);
                sequentialDate.LastYearThisMonthStartDate = sequentialDate.StartDate.AddYears(-1);
                sequentialDate.LastYearThisMonthEndDate = sequentialDate.LastYearThisMonthStartDate.AddDays(1);
                sequentialDate.LastMonthStartDate = sequentialDate.StartDate.AddDays(-1);
                sequentialDate.LastMonthEndDate = sequentialDate.StartDate;
            }
            //获取目标
            var target = await liveAnchorMonthlyTargetAfterLivingService.GetPerformanceTargetAsync(year, month, liveAnchorIds);

            //总业绩
            var order = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAndLiveAnchorIdsAsync(sequentialDate.StartDate, sequentialDate.EndDate, liveAnchorIds);
            //同比业绩
            var orderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAndLiveAnchorIdsAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, liveAnchorIds);
            //环比业绩
            List<PerformanceDto> orderChain = new List<PerformanceDto>();
            if (type != "year")
            {
                orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceByDateAndLiveAnchorIdsAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, liveAnchorIds);
            }

            var curTotalPerformance = order.Sum(o => o.Price);
            var totalPerformanceYearOnYear = orderYearOnYear.Sum(o => o.Price);
            var totalPerformanceChainRatio = orderChain.Sum(o => o.Price);
            amiyaAchievementDataDto.TotalPerformance = curTotalPerformance;

            amiyaAchievementDataDto.TotalPerformanceChainRatio = DecimalExtension.CalculateChain(curTotalPerformance, totalPerformanceChainRatio).Value;
            amiyaAchievementDataDto.TotalPerformanceYearOnYear = DecimalExtension.CalculateChain(curTotalPerformance, totalPerformanceYearOnYear).Value;
            if (type != "day")
            {
                amiyaAchievementDataDto.TotalPerformanceCompleteRate = DecimalExtension.CalculateTargetComplete(curTotalPerformance, target.TotalPerformanceTarget).Value;
            }
            if (type == "month")
            {
                var totalperformanceSchedule = this.CalculateSchedule(target.TotalPerformanceTarget, curTotalPerformance, year, month);
                amiyaAchievementDataDto.TotalPerformanceToDateSchedule = totalperformanceSchedule.ContrastTimeSchedule;
                amiyaAchievementDataDto.TotalPerformanceDeviation = totalperformanceSchedule.PerformanceDeviation;
                amiyaAchievementDataDto.LaterCompleteEveryDayTotalPerformance = totalperformanceSchedule.ResidueTimeNeedCompletePerformance;
            }

            //退款业绩
            decimal refundPerformance = 0m;
            if (string.IsNullOrEmpty(baseLiveanchorId))
            {
                refundPerformance = order.Where(e => e.ToHospitalType == (int)ContentPlateFormOrderToHospitalType.REFUND).Sum(e => e.Price);
            }
            else
            {
                refundPerformance = order.Where(e => e.ToHospitalType == (int)ContentPlateFormOrderToHospitalType.REFUND && liveAnchorIds.Contains(e.LiveAnchorId.Value)).Sum(e => e.Price);
            }
            amiyaAchievementDataDto.RefundPerformance = refundPerformance;
            if (string.IsNullOrEmpty(baseLiveanchorId))
            {

                var liveAnchorList = await liveAnchorService.GetValidListByLiveAnchorBaseIdAsync(new List<string> { "f0a77257-c905-4719-95c4-ad2c4f33855c", "af69dcf5-f749-41ea-8b50-fe685facdd8b" });
                var daodaoLiveanchorIds = liveAnchorList.Where(e => e.LiveAnchorBaseId == "f0a77257-c905-4719-95c4-ad2c4f33855c").Select(e => e.Id).ToList();
                var jinaLiveanchorIds = liveAnchorList.Where(e => e.LiveAnchorBaseId == "af69dcf5-f749-41ea-8b50-fe685facdd8b").Select(e => e.Id).ToList();
                var daodaoTarget = await liveAnchorMonthlyTargetAfterLivingService.GetPerformance(year, month, daodaoLiveanchorIds);
                var jinaTarget = await liveAnchorMonthlyTargetAfterLivingService.GetPerformance(year, month, jinaLiveanchorIds);

                amiyaAchievementDataDto.GroupDaoDaoPerformance = order.Where(e => e.LiveAnchorId.HasValue).Where(e => daodaoLiveanchorIds.Contains(e.LiveAnchorId.Value)).Sum(e => e.Price);
                amiyaAchievementDataDto.GroupDaoDaoPerformanceChainRatio = DecimalExtension.CalculateChain(amiyaAchievementDataDto.GroupDaoDaoPerformance, orderChain.Where(e => e.LiveAnchorId.HasValue).Where(e => daodaoLiveanchorIds.Contains(e.LiveAnchorId.Value)).Sum(e => e.Price)).Value;
                amiyaAchievementDataDto.GroupDaoDaoPerformanceYearOnYear = DecimalExtension.CalculateChain(amiyaAchievementDataDto.GroupDaoDaoPerformance, orderYearOnYear.Where(e => e.LiveAnchorId.HasValue).Where(e => daodaoLiveanchorIds.Contains(e.LiveAnchorId.Value)).Sum(e => e.Price)).Value;
                amiyaAchievementDataDto.GroupDaoDaoPerformanceProportion = DecimalExtension.CalculateTargetComplete(amiyaAchievementDataDto.GroupDaoDaoPerformance, curTotalPerformance).Value;
                if (type != "day")
                {
                    amiyaAchievementDataDto.GroupDaoDaoPerformanceCompleteRate = DecimalExtension.CalculateTargetComplete(amiyaAchievementDataDto.GroupDaoDaoPerformance, daodaoTarget.TotalPerformanceTarget).Value;
                }
                if (type == "month")
                {
                    var daodaoPerformanceSchedule = this.CalculateSchedule(daodaoTarget.TotalPerformanceTarget, amiyaAchievementDataDto.GroupDaoDaoPerformance, year, month);
                    amiyaAchievementDataDto.GroupDaoDaoPerformanceToDateSchedule = daodaoPerformanceSchedule.ContrastTimeSchedule;
                    amiyaAchievementDataDto.GroupDaoDaoPerformanceDeviation = daodaoPerformanceSchedule.PerformanceDeviation;
                    amiyaAchievementDataDto.LaterCompleteEveryDayGroupDaoDaoPerformance = daodaoPerformanceSchedule.ResidueTimeNeedCompletePerformance;
                }


                amiyaAchievementDataDto.GroupJinaPerformance = order.Where(e => e.LiveAnchorId.HasValue).Where(e => jinaLiveanchorIds.Contains(e.LiveAnchorId.Value)).Sum(e => e.Price);
                amiyaAchievementDataDto.GroupJinaPerformanceChainRatio = DecimalExtension.CalculateChain(amiyaAchievementDataDto.GroupJinaPerformance, orderChain.Where(e => e.LiveAnchorId.HasValue).Where(e => jinaLiveanchorIds.Contains(e.LiveAnchorId.Value)).Sum(e => e.Price)).Value;
                amiyaAchievementDataDto.GroupJinaPerformanceYearOnYear = DecimalExtension.CalculateChain(amiyaAchievementDataDto.GroupJinaPerformance, orderYearOnYear.Where(e => e.LiveAnchorId.HasValue).Where(e => jinaLiveanchorIds.Contains(e.LiveAnchorId.Value)).Sum(e => e.Price)).Value;
                amiyaAchievementDataDto.GroupJinaPerformanceProportion = DecimalExtension.CalculateTargetComplete(amiyaAchievementDataDto.GroupJinaPerformance, curTotalPerformance).Value;
                if (type != "day")
                {
                    amiyaAchievementDataDto.GroupJinaPerformanceCompleteRate = DecimalExtension.CalculateTargetComplete(amiyaAchievementDataDto.GroupJinaPerformance, jinaTarget.TotalPerformanceTarget).Value;
                }
                if (type == "month")
                {
                    var jinaPerformanceSchedule = this.CalculateSchedule(jinaTarget.TotalPerformanceTarget, amiyaAchievementDataDto.GroupJinaPerformance, year, month);
                    amiyaAchievementDataDto.GroupJinaPerformanceToDateSchedule = jinaPerformanceSchedule.ContrastTimeSchedule;
                    amiyaAchievementDataDto.GroupJinaPerformanceDeviation = jinaPerformanceSchedule.PerformanceDeviation;
                    amiyaAchievementDataDto.LaterCompleteEveryDayGroupJinaPerformance = jinaPerformanceSchedule.ResidueTimeNeedCompletePerformance;
                }

            }
            return amiyaAchievementDataDto;
        }
        /// <summary>
        /// 业绩看板获取业绩详情
        /// </summary>
        /// <param name="baseLiveanchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public async Task<AmiyaAchievementDetailDataDto> GetDetailPerformanceAsync(string baseLiveanchorId, int year, int month, int day)
        {
            AmiyaAchievementDetailDataDto amiyaAchievementDetailDataDto = new AmiyaAchievementDetailDataDto();
            var sequentialDate = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month == 0 ? 1 : month);
            //获取各个平台的主播ID
            List<int> LiveAnchorInfo = new List<int>();
            if (!string.IsNullOrEmpty(baseLiveanchorId))
            {
                LiveAnchorInfo = await this.GetLiveAnchorIdsByBaseIdAndIsSelfLiveAnchorAsync(baseLiveanchorId, null);
            }
            var type = DetermineQueryTime(year, month, day);
            //获取目标
            var target = await liveAnchorMonthlyTargetAfterLivingService.GetPerformanceTargetAsync(year, month, LiveAnchorInfo);
            if (type == "year")
            {
                sequentialDate.StartDate = new DateTime(year, 1, 1);
                sequentialDate.EndDate = new DateTime(year + 1, 1, 1);
                sequentialDate.LastYearThisMonthStartDate = new DateTime(year - 1, 1, 1);
                sequentialDate.LastYearThisMonthEndDate = new DateTime(year, 1, 1);
            }
            if (type == "day")
            {
                sequentialDate.StartDate = new DateTime(year, month, day);
                sequentialDate.EndDate = sequentialDate.StartDate.AddDays(1);
                sequentialDate.LastYearThisMonthStartDate = sequentialDate.StartDate.AddYears(-1);
                sequentialDate.LastYearThisMonthEndDate = sequentialDate.LastYearThisMonthStartDate.AddDays(1);
                sequentialDate.LastMonthStartDate = sequentialDate.StartDate.AddDays(-1);
                sequentialDate.LastMonthEndDate = sequentialDate.StartDate;
            }
            #region 总业绩
            //总业绩
            var order = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAsync(sequentialDate.StartDate, sequentialDate.EndDate, LiveAnchorInfo);
            var curTotalPerformance = order.Sum(o => o.Price);
            //同比业绩
            var orderYearOnYear = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAsync(sequentialDate.LastYearThisMonthStartDate, sequentialDate.LastYearThisMonthEndDate, LiveAnchorInfo);
            //环比业绩
            List<ContentPlatFormOrderDealInfoDto> orderChain = new List<ContentPlatFormOrderDealInfoDto>();
            if (type != "year")
            {
                orderChain = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAsync(sequentialDate.LastMonthStartDate, sequentialDate.LastMonthEndDate, LiveAnchorInfo);
            }
            #endregion

            #region 新客业绩
            var curNewCustomer = order.Where(o => o.IsOldCustomer == false).Sum(o => o.Price);
            var newOrderYearOnYear = orderYearOnYear.Where(x => x.IsOldCustomer == false).Sum(o => o.Price);
            var newOrderChainRatio = orderChain.Where(x => x.IsOldCustomer == false).Sum(o => o.Price);
            amiyaAchievementDetailDataDto.NewCustomerPerformance = ChangePriceToTenThousand(curNewCustomer);
            amiyaAchievementDetailDataDto.NewCustomerPerformanceChainRatio = DecimalExtension.CalculateChain(curNewCustomer, newOrderChainRatio).Value;
            amiyaAchievementDetailDataDto.NewCustomerPerformanceYearOnYear = DecimalExtension.CalculateChain(curNewCustomer, newOrderYearOnYear).Value;
            if (type != "day")
            {
                amiyaAchievementDetailDataDto.NewCustomerPerformanceCompleteRate = DecimalExtension.CalculateTargetComplete(curNewCustomer, target.NewCustomerPerformanceTarget).Value;
            }
            if (type == "month")
            {
                var newCustomerSchedule = CalculateSchedule(target.NewCustomerPerformanceTarget, curNewCustomer, year, month);
                amiyaAchievementDetailDataDto.NewCustomerPerformanceProportion = DecimalExtension.CalculateTargetComplete(curNewCustomer, curTotalPerformance).Value;
                amiyaAchievementDetailDataDto.NewCustomerPerformanceToDateSchedule = newCustomerSchedule.ContrastTimeSchedule;
                amiyaAchievementDetailDataDto.NewCustomerPerformanceDeviation = newCustomerSchedule.PerformanceDeviation;
                amiyaAchievementDetailDataDto.LaterCompleteEveryDayNewCustomerPerformance = newCustomerSchedule.ResidueTimeNeedCompletePerformance;
            }
            #endregion

            #region 老客业绩
            var curOldCustomer = order.Where(o => o.IsOldCustomer == true).Sum(o => o.Price);
            var oldOrderYearOnYear = orderYearOnYear.Where(x => x.IsOldCustomer == true).Sum(o => o.Price);
            var oldOrderChainRatio = orderChain.Where(x => x.IsOldCustomer == true).Sum(o => o.Price);
            amiyaAchievementDetailDataDto.OldCustomerPerformance = ChangePriceToTenThousand(curOldCustomer);
            amiyaAchievementDetailDataDto.OldCustomerPerformanceChainRatio = DecimalExtension.CalculateChain(curOldCustomer, oldOrderChainRatio).Value;
            amiyaAchievementDetailDataDto.OldCustomerPerformanceYearOnYear = DecimalExtension.CalculateChain(curOldCustomer, oldOrderYearOnYear).Value;
            if (type != "day")
            {
                amiyaAchievementDetailDataDto.OldCustomerPerformanceCompleteRate = DecimalExtension.CalculateTargetComplete(curOldCustomer, target.OldCustomerPerformanceTarget).Value;
            }
            if (type == "month")
            {
                var oldCustomerSchedule = CalculateSchedule(target.OldCustomerPerformanceTarget, curOldCustomer, year, month);
                amiyaAchievementDetailDataDto.OldCustomerPerformanceProportion = DecimalExtension.CalculateTargetComplete(curOldCustomer, curTotalPerformance).Value;
                amiyaAchievementDetailDataDto.OldCustomerPerformanceToDateSchedule = oldCustomerSchedule.ContrastTimeSchedule;
                amiyaAchievementDetailDataDto.OldCustomerPerformanceDeviation = oldCustomerSchedule.PerformanceDeviation;
                amiyaAchievementDetailDataDto.LaterCompleteEveryDayOldCustomerPerformance = oldCustomerSchedule.ResidueTimeNeedCompletePerformance;
            }
            #endregion

            #region 有效业绩
            var curHavingPricePerformance = order.Where(o => o.AddOrderPrice > 0).Sum(o => o.Price);
            var havingPriceYearOnYearr = orderYearOnYear.Where(x => x.AddOrderPrice > 0).Sum(o => o.Price);
            var havingPriceOrderChainRatio = orderChain.Where(x => x.AddOrderPrice > 0).Sum(o => o.Price);
            amiyaAchievementDetailDataDto.EffectivePerformance = ChangePriceToTenThousand(curHavingPricePerformance);
            amiyaAchievementDetailDataDto.EffectivePerformanceChainRatio = DecimalExtension.CalculateChain(curHavingPricePerformance, havingPriceOrderChainRatio).Value;
            amiyaAchievementDetailDataDto.EffectivePerformanceYearOnYear = DecimalExtension.CalculateChain(curHavingPricePerformance, havingPriceYearOnYearr).Value;
            if (type != "day")
            {
                amiyaAchievementDetailDataDto.EffectivePerformanceCompleteRate = DecimalExtension.CalculateTargetComplete(curHavingPricePerformance, target.EffectivePerformance).Value;
            }
            if (type == "month")
            {
                var havingPricePerformanceSchedule = CalculateSchedule(target.EffectivePerformance, curHavingPricePerformance, year, month);
                amiyaAchievementDetailDataDto.EffectivePerformanceProportion = DecimalExtension.CalculateTargetComplete(curHavingPricePerformance, curTotalPerformance).Value;
                amiyaAchievementDetailDataDto.EffectivePerformanceToDateSchedule = havingPricePerformanceSchedule.ContrastTimeSchedule;
                amiyaAchievementDetailDataDto.EffectivePerformanceDeviation = havingPricePerformanceSchedule.PerformanceDeviation;
                amiyaAchievementDetailDataDto.LaterCompleteEveryDayEffectivePerformance = havingPricePerformanceSchedule.ResidueTimeNeedCompletePerformance;
            }
            #endregion

            #region 潜在业绩
            var curNotHavePricePerformance = order.Where(o => o.AddOrderPrice == 0).Sum(o => o.Price);
            var notHavePriceYearOnYearr = orderYearOnYear.Where(x => x.AddOrderPrice == 0).Sum(o => o.Price);
            var notHavePriceOrderChainRatio = orderChain.Where(x => x.AddOrderPrice == 0).Sum(o => o.Price);
            amiyaAchievementDetailDataDto.PotentialPerformance = ChangePriceToTenThousand(curNotHavePricePerformance);
            amiyaAchievementDetailDataDto.PotentialPerformanceChainRatio = DecimalExtension.CalculateChain(curNotHavePricePerformance, notHavePriceOrderChainRatio).Value;
            amiyaAchievementDetailDataDto.PotentialPerformanceYearOnYear = DecimalExtension.CalculateChain(curNotHavePricePerformance, notHavePriceYearOnYearr).Value;
            if (type != "day")
            {
                amiyaAchievementDetailDataDto.PotentialPerformanceCompleteRate = DecimalExtension.CalculateTargetComplete(curNotHavePricePerformance, target.PotentialPerformance).Value;
            }
            if (type == "month")
            {
                var notHavePricePerformanceSchedule = CalculateSchedule(target.PotentialPerformance, curNotHavePricePerformance, year, month);
                amiyaAchievementDetailDataDto.PotentialPerformanceProportion = DecimalExtension.CalculateTargetComplete(curNotHavePricePerformance, curTotalPerformance).Value;
                amiyaAchievementDetailDataDto.PotentialPerformanceToDateSchedule = notHavePricePerformanceSchedule.ContrastTimeSchedule;
                amiyaAchievementDetailDataDto.PotentialPerformanceDeviation = notHavePricePerformanceSchedule.PerformanceDeviation;
                amiyaAchievementDetailDataDto.LaterCompleteEveryDayPotentialPerformance = notHavePricePerformanceSchedule.ResidueTimeNeedCompletePerformance;
            }
            #endregion


            #region 当月派单当月成交业绩

            if (type != "year")
            {
                var thisMonthSendAndDealPerformance = order.Where(e => e.SendDate >= sequentialDate.StartDate && e.SendDate < sequentialDate.EndDate).Sum(o => o.Price);
                var thisMonthSendAndDealPerformanceYearOnYear = orderYearOnYear.Where(e => e.SendDate >= sequentialDate.LastYearThisMonthStartDate && e.SendDate < sequentialDate.LastYearThisMonthEndDate).Sum(o => o.Price);
                var thisMonthSendAndDealPerformanceChainRatio = orderChain.Where(e => e.SendDate >= sequentialDate.LastMonthStartDate && e.SendDate < sequentialDate.LastMonthEndDate).Sum(o => o.Price);
                amiyaAchievementDetailDataDto.ThisMonthSendOrderPerformance = ChangePriceToTenThousand(thisMonthSendAndDealPerformance);
                amiyaAchievementDetailDataDto.ThisMonthSendOrderPerformanceChainRatio = DecimalExtension.CalculateChain(thisMonthSendAndDealPerformance, thisMonthSendAndDealPerformanceChainRatio).Value;
                amiyaAchievementDetailDataDto.ThisMonthSendOrderPerformanceYearOnYear = DecimalExtension.CalculateChain(thisMonthSendAndDealPerformance, thisMonthSendAndDealPerformanceYearOnYear).Value;
                amiyaAchievementDetailDataDto.ThisMonthSendOrderPerformanceProportion = DecimalExtension.CalculateTargetComplete(thisMonthSendAndDealPerformance, curTotalPerformance).Value;
            }

            #endregion

            #region 历史派单当月成交业绩
            if (type != "year")
            {
                var historyMonthSendAndDealPerformance = order.Where(e => e.SendDate < sequentialDate.StartDate).Sum(o => o.Price);
                var historyMonthSendAndDealPerformanceYearOnYear = orderYearOnYear.Where(e => e.SendDate < sequentialDate.LastYearThisMonthStartDate).Sum(o => o.Price);
                var historyMonthSendAndDealPerformanceChainRatio = orderChain.Where(e => e.SendDate < sequentialDate.LastMonthStartDate).Sum(o => o.Price);
                amiyaAchievementDetailDataDto.HistorySendOrderPerformance = ChangePriceToTenThousand(historyMonthSendAndDealPerformance);
                amiyaAchievementDetailDataDto.HistorySendOrderPerformanceChainRatio = DecimalExtension.CalculateChain(historyMonthSendAndDealPerformance, historyMonthSendAndDealPerformanceChainRatio).Value;
                amiyaAchievementDetailDataDto.HistorySendOrderPerformanceYearOnYear = DecimalExtension.CalculateChain(historyMonthSendAndDealPerformance, historyMonthSendAndDealPerformanceYearOnYear).Value;
                amiyaAchievementDetailDataDto.HistorySendOrderPerformanceProportion = DecimalExtension.CalculateTargetComplete(historyMonthSendAndDealPerformance, curTotalPerformance).Value;
            }
            #endregion

            #region 抖音业绩

            var tiktokPerformance = order.Where(e => e.ContentPlatFormId == "4e4e9564-f6c3-47b6-a7da-e4518bab66a1").Sum(e => e.Price);
            var tiktokPerformanceChain = orderChain.Where(e => e.ContentPlatFormId == "4e4e9564-f6c3-47b6-a7da-e4518bab66a1").Sum(e => e.Price);
            var tiktokPerformanceYearOnYear = orderYearOnYear.Where(e => e.ContentPlatFormId == "4e4e9564-f6c3-47b6-a7da-e4518bab66a1").Sum(e => e.Price);
            amiyaAchievementDetailDataDto.TikTokPerformance = ChangePriceToTenThousand(tiktokPerformance);
            amiyaAchievementDetailDataDto.TikTokPerformanceChainRatio = DecimalExtension.CalculateChain(tiktokPerformance, tiktokPerformanceChain).Value;
            amiyaAchievementDetailDataDto.TikTokPerformanceYearOnYear = DecimalExtension.CalculateChain(tiktokPerformance, tiktokPerformanceYearOnYear).Value;
            amiyaAchievementDetailDataDto.TikTokPerformanceProportion = DecimalExtension.CalculateTargetComplete(tiktokPerformance, curTotalPerformance).Value;

            #endregion

            #region 视频号业绩

            var videoNoPerformance = order.Where(e => e.ContentPlatFormId == "9196b247-1ab9-4d0c-a11e-a1ef09019878").Sum(e => e.Price);
            var videoNoPerformanceChain = orderChain.Where(e => e.ContentPlatFormId == "9196b247-1ab9-4d0c-a11e-a1ef09019878").Sum(e => e.Price);
            var videoNoPerformanceYearOnYear = orderYearOnYear.Where(e => e.ContentPlatFormId == "9196b247-1ab9-4d0c-a11e-a1ef09019878").Sum(e => e.Price);
            amiyaAchievementDetailDataDto.VideoPerformance = ChangePriceToTenThousand(videoNoPerformance);
            amiyaAchievementDetailDataDto.VideoPerformanceChainRatio = DecimalExtension.CalculateChain(videoNoPerformance, videoNoPerformanceChain).Value;
            amiyaAchievementDetailDataDto.VideoPerformanceYearOnYear = DecimalExtension.CalculateChain(videoNoPerformance, videoNoPerformanceYearOnYear).Value;
            amiyaAchievementDetailDataDto.VideoPerformanceProportion = DecimalExtension.CalculateTargetComplete(videoNoPerformance, curTotalPerformance).Value;
            #endregion

            #region 视频业绩
            var curVideoPerformance = order.Where(o => o.ConsultationType == (int)ContentPlateFormOrderConsultationType.Collaboration).Sum(o => o.Price);
            var videoYearOnYearr = orderYearOnYear.Where(x => x.ConsultationType == (int)ContentPlateFormOrderConsultationType.Collaboration).Sum(o => o.Price);
            var videoOrderChainRatio = orderChain.Where(x => x.ConsultationType == (int)ContentPlateFormOrderConsultationType.Collaboration).Sum(o => o.Price);
            amiyaAchievementDetailDataDto.LiveAnchorVideoPerformance = ChangePriceToTenThousand(curVideoPerformance);
            amiyaAchievementDetailDataDto.LiveAnchorVideoPerformanceChainRatio = DecimalExtension.CalculateChain(curVideoPerformance, videoOrderChainRatio).Value;
            amiyaAchievementDetailDataDto.LiveAnchorVideoPerformanceYearOnYear = DecimalExtension.CalculateChain(curVideoPerformance, videoYearOnYearr).Value;
            amiyaAchievementDetailDataDto.LiveAnchorVideoPerformanceProportion = DecimalExtension.CalculateTargetComplete(curVideoPerformance, curTotalPerformance).Value;
            #endregion

            #region 照片业绩

            var curPicturePerformance = order.Where(o => o.ConsultationType == (int)ContentPlateFormOrderConsultationType.IndependentFollowUp).Sum(o => o.Price);
            var pictureYearOnYearr = orderYearOnYear.Where(x => x.ConsultationType == (int)ContentPlateFormOrderConsultationType.IndependentFollowUp).Sum(o => o.Price);
            var pictureOrderChainRatio = orderChain.Where(x => x.ConsultationType == (int)ContentPlateFormOrderConsultationType.IndependentFollowUp).Sum(o => o.Price);
            amiyaAchievementDetailDataDto.AssistantPhotoPerformance = ChangePriceToTenThousand(curPicturePerformance);
            amiyaAchievementDetailDataDto.AssistantPhotoPerformanceChainRatio = DecimalExtension.CalculateChain(curPicturePerformance, pictureOrderChainRatio).Value;
            amiyaAchievementDetailDataDto.AssistantPhotoPerformanceYearOnYear = DecimalExtension.CalculateChain(curPicturePerformance, pictureYearOnYearr).Value;
            amiyaAchievementDetailDataDto.AssistantPhotoPerformanceProportion = DecimalExtension.CalculateTargetComplete(curPicturePerformance, curTotalPerformance).Value;
            #endregion

            #region 主播接诊业绩

            var curLiveAnchorAcompanyingPerformance = order.Where(o => o.IsAcompanying == true).Sum(o => o.Price);
            var liveAnchorAcompanyingYearOnYearr = orderYearOnYear.Where(x => x.IsAcompanying == true).Sum(o => o.Price);
            var liveAnchorAcompanyingOrderChainRatio = orderChain.Where(x => x.IsAcompanying == true).Sum(o => o.Price);
            amiyaAchievementDetailDataDto.LiveAnchorReceptionPerformance = ChangePriceToTenThousand(curLiveAnchorAcompanyingPerformance);
            amiyaAchievementDetailDataDto.LiveAnchorReceptionPerformanceChainRatio = DecimalExtension.CalculateChain(curLiveAnchorAcompanyingPerformance, liveAnchorAcompanyingOrderChainRatio).Value;
            amiyaAchievementDetailDataDto.LiveAnchorReceptionPerformanceYearOnYear = DecimalExtension.CalculateChain(curLiveAnchorAcompanyingPerformance, liveAnchorAcompanyingYearOnYearr).Value;
            amiyaAchievementDetailDataDto.LiveAnchorReceptionPerformanceProportion = DecimalExtension.CalculateTargetComplete(curLiveAnchorAcompanyingPerformance, curTotalPerformance).Value;
            #endregion

            #region 非主播接诊业绩
            var curNotLiveAnchorAcompanyingPerformance = order.Where(o => o.IsAcompanying == false).Sum(o => o.Price);
            var notLiveAnchorAcompanyingYearOnYearr = orderYearOnYear.Where(x => x.IsAcompanying == false).Sum(o => o.Price);
            var notLiveAnchorAcompanyingOrderChainRatio = orderChain.Where(x => x.IsAcompanying == false).Sum(o => o.Price);
            amiyaAchievementDetailDataDto.NoLiveAnchorReceptionPerformance = ChangePriceToTenThousand(curNotLiveAnchorAcompanyingPerformance);
            amiyaAchievementDetailDataDto.NoLiveAnchorReceptionPerformanceChainRatio = DecimalExtension.CalculateChain(curNotLiveAnchorAcompanyingPerformance, notLiveAnchorAcompanyingOrderChainRatio).Value;
            amiyaAchievementDetailDataDto.NoLiveAnchorReceptionPerformanceYearOnYear = DecimalExtension.CalculateChain(curNotLiveAnchorAcompanyingPerformance, notLiveAnchorAcompanyingYearOnYearr).Value;
            amiyaAchievementDetailDataDto.NoLiveAnchorReceptionPerformanceProportion = DecimalExtension.CalculateTargetComplete(curNotLiveAnchorAcompanyingPerformance, curTotalPerformance).Value;
            #endregion

            return amiyaAchievementDetailDataDto;
        }

        /// <summary>
        /// 业绩看板获取折线图
        /// </summary>
        /// <param name="baseLiveanchorId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public async Task<AmiyaAchievementBrokenLineListDto> GetAmiyaAchievementBrokenLineListDataAsync(string baseLiveanchorId, int year, int month)
        {
            AmiyaAchievementBrokenLineListDto amiyaAchievementDetailDataDto = new AmiyaAchievementBrokenLineListDto();
            //获取各个平台的主播ID
            List<int> LiveAnchorInfo = new List<int>();
            if (!string.IsNullOrEmpty(baseLiveanchorId))
            {
                LiveAnchorInfo = await this.GetLiveAnchorIdsByBaseIdAndIsSelfLiveAnchorAsync(baseLiveanchorId, null);
            }

            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            var type = DetermineQueryTime(year, month, 0);
            if (type == "year")
            {
                startDate = new DateTime(year, 1, 1);
                endDate = new DateTime(year + 1, 1, 1);
            }
            else
            {
                startDate = new DateTime(year, month, 1);
                endDate = new DateTime(year, month + 1, 1);
            }

            var order = await contentPlatFormOrderDealInfoService.GetPerformanceDetailByDateAsync(startDate, endDate, LiveAnchorInfo);
            List<GroupByTimeBrokenLineListDto> dataList = new List<GroupByTimeBrokenLineListDto>();
            if (type == "year")
            {
                dataList = order.GroupBy(e => e.CreateDate.Month)
                    .Select(x => new GroupByTimeBrokenLineListDto
                    {
                        Time = x.Key,
                        NewCustomerPerformance = x.Where(e => e.IsOldCustomer == false).Sum(e => e.Price),
                        OldCustomerPerformance = x.Where(e => e.IsOldCustomer == true).Sum(e => e.Price),
                        EffectivePerformance = x.Where(e => e.AddOrderPrice > 0).Sum(e => e.Price),
                        PotentialPerformance = x.Where(e => e.AddOrderPrice == 0).Sum(e => e.Price),
                        ThisMonthSendOrderPerformance = x.Where(e => e.SendDate >= new DateTime(year, x.Key, 1) && e.SendDate < new DateTime(year, x.Key, 1).AddMonths(1)).Sum(e => e.Price),
                        HistorySendOrderPerformance = x.Where(e => e.SendDate < new DateTime(year, x.Key, 1)).Sum(e => e.Price),
                        TikTokPerformance = x.Where(e => e.ContentPlatFormId == "4e4e9564-f6c3-47b6-a7da-e4518bab66a1").Sum(e => e.Price),
                        VideoPerformance = x.Where(e => e.ContentPlatFormId == "9196b247-1ab9-4d0c-a11e-a1ef09019878").Sum(e => e.Price),
                        LiveAnchorVideoPerformance = x.Where(e => e.ConsultationType == (int)ContentPlateFormOrderConsultationType.Collaboration).Sum(e => e.Price),
                        AssistantPhotoPerformance = x.Where(e => e.ConsultationType == (int)ContentPlateFormOrderConsultationType.IndependentFollowUp).Sum(e => e.Price),
                        LiveAnchorReceptionPerformance = x.Where(e => e.IsAcompanying == true).Sum(e => e.Price),
                        NoLiveAnchorReceptionPerformance = x.Where(e => e.IsAcompanying == false).Sum(e => e.Price),
                    }).ToList();
            }
            else
            {
                dataList = order.GroupBy(e => e.CreateDate.Day)
                    .Select(x => new GroupByTimeBrokenLineListDto
                    {
                        Time = x.Key,
                        NewCustomerPerformance = x.Where(e => e.IsOldCustomer == false).Sum(e => e.Price),
                        OldCustomerPerformance = x.Where(e => e.IsOldCustomer == true).Sum(e => e.Price),
                        EffectivePerformance = x.Where(e => e.AddOrderPrice > 0).Sum(e => e.Price),
                        PotentialPerformance = x.Where(e => e.AddOrderPrice == 0).Sum(e => e.Price),
                        ThisMonthSendOrderPerformance = x.Where(e => e.SendDate >= new DateTime(year, month, 1) && e.SendDate < new DateTime(year, month, 1).AddMonths(1)).Sum(e => e.Price),
                        HistorySendOrderPerformance = x.Where(e => e.SendDate < new DateTime(year, month, 1)).Sum(e => e.Price),
                        TikTokPerformance = x.Where(e => e.ContentPlatFormId == "4e4e9564-f6c3-47b6-a7da-e4518bab66a1").Sum(e => e.Price),
                        VideoPerformance = x.Where(e => e.ContentPlatFormId == "9196b247-1ab9-4d0c-a11e-a1ef09019878").Sum(e => e.Price),
                        LiveAnchorVideoPerformance = x.Where(e => e.ConsultationType == (int)ContentPlateFormOrderConsultationType.Collaboration).Sum(e => e.Price),
                        AssistantPhotoPerformance = x.Where(e => e.ConsultationType == (int)ContentPlateFormOrderConsultationType.IndependentFollowUp).Sum(e => e.Price),
                        LiveAnchorReceptionPerformance = x.Where(e => e.IsAcompanying == true).Sum(e => e.Price),
                        NoLiveAnchorReceptionPerformance = x.Where(e => e.IsAcompanying == false).Sum(e => e.Price),
                    }).ToList();
            }
            amiyaAchievementDetailDataDto.NewCustomerPerformanceBrokenLineList = this.FillDate(type, year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = ChangePriceToTenThousand(e.NewCustomerPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.OldCustomerPerformanceBrokenLineList = this.FillDate(type, year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = ChangePriceToTenThousand(e.OldCustomerPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.EffectivePerformanceBrokenLineList = this.FillDate(type, year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = ChangePriceToTenThousand(e.EffectivePerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.PotentialPerformanceBrokenLineList = this.FillDate(type, year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = ChangePriceToTenThousand(e.PotentialPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.ThisMonthSendOrderPerformanceBrokenLineList = this.FillDate(type, year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = ChangePriceToTenThousand(e.ThisMonthSendOrderPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.HistorySendOrderPerformanceBrokenLineList = this.FillDate(type, year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = ChangePriceToTenThousand(e.HistorySendOrderPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.TikTokPerformanceBrokenLineList = this.FillDate(type, year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = ChangePriceToTenThousand(e.TikTokPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.VideoPerformanceBrokenLineList = this.FillDate(type, year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = ChangePriceToTenThousand(e.VideoPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.LiveAnchorVideoPerformanceBrokenLineList = this.FillDate(type, year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = ChangePriceToTenThousand(e.LiveAnchorVideoPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.AssistantPhotoPerformanceBrokenLineList = this.FillDate(type, year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = ChangePriceToTenThousand(e.AssistantPhotoPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.LiveAnchorReceptionPerformanceBrokenLineList = this.FillDate(type, year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = ChangePriceToTenThousand(e.LiveAnchorReceptionPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            amiyaAchievementDetailDataDto.NoLiveAnchorReceptionPerformanceBrokenLineList = this.FillDate(type, year, month, dataList).Select(e => new PeformanceBrokenLineListInfoDto { date = e.Time.ToString(), Performance = ChangePriceToTenThousand(e.NoLiveAnchorReceptionPerformance) }).OrderBy(e => Convert.ToInt32(e.date)).ToList();
            return amiyaAchievementDetailDataDto;
        }
        /// <summary>
        /// 计算金额类数值以万展示
        /// </summary>
        /// <param name="currentMonthPerformance"></param>
        /// <param name="performanceChainRatio"></param>
        /// <returns></returns>
        private decimal ChangePriceToTenThousand(decimal currentPrice)
        {
            if (currentPrice == 0m)
                return 0;
            var result = Math.Round((currentPrice / 10000), 2, MidpointRounding.AwayFromZero);
            return result;
        }
        /// <summary>
        /// 计算对比进度,业绩偏差和后期需完成业绩
        /// </summary>
        /// <param name="performanceTarget">总业绩目标</param>
        /// <param name="currentPerformance">当前完成业绩</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        private PerformanceScheduleDto CalculateSchedule(decimal performanceTarget, decimal currentPerformance, int year, int month)
        {
            PerformanceScheduleDto performanceScheduleDto = new PerformanceScheduleDto();
            if (performanceTarget == 0m || currentPerformance == 0m)
            {
                performanceScheduleDto.ContrastTimeSchedule = 0;
                performanceScheduleDto.PerformanceDeviation = 0;
                performanceScheduleDto.ResidueTimeNeedCompletePerformance = 0;
                return performanceScheduleDto;
            }

            decimal timeSchedule = 0;
            var now = DateTime.Now;
            var totalDay = DateTime.DaysInMonth(now.Year, now.Month);
            var nowDay = now.Day;
            if (year != now.Year || month != now.Month)
            {
                timeSchedule = 100m;
            }
            else
            {
                timeSchedule = Math.Round(Convert.ToDecimal(nowDay) / Convert.ToDecimal(totalDay) * 100, 2, MidpointRounding.AwayFromZero);
            }
            decimal performanceSchedule = Math.Round(currentPerformance / performanceTarget * 100, 2, MidpointRounding.AwayFromZero);
            performanceScheduleDto.ContrastTimeSchedule = performanceSchedule - timeSchedule;
            performanceScheduleDto.PerformanceDeviation = Math.Round(performanceTarget * (timeSchedule - performanceSchedule) / 100, 2);
            performanceScheduleDto.ResidueTimeNeedCompletePerformance = timeSchedule == 100m ? performanceScheduleDto.PerformanceDeviation : Math.Round((performanceTarget - currentPerformance) / (totalDay - nowDay), 2, MidpointRounding.AwayFromZero);
            return performanceScheduleDto;

        }
        /// <summary>
        /// 判断要筛选的时间类型
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        private string DetermineQueryTime(int year, int month, int day)
        {
            var type = "";
            if (day != 0)
            {
                type = "day";
            }
            if (day == 0 && month != 0)
            {
                type = "month";
            }
            if (day == 0 && month == 0)
            {
                type = "year";
            }
            return type;
        }
        /// <summary>
        /// 填充日期数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dataList"></param>
        /// <returns></returns>
        private List<GroupByTimeBrokenLineListDto> FillDate(string type, int year, int month, List<GroupByTimeBrokenLineListDto> dataList)
        {
            List<GroupByTimeBrokenLineListDto> list = new List<GroupByTimeBrokenLineListDto>();
            if (type == "year")
            {
                for (int i = 1; i < 13; i++)
                {
                    GroupByTimeBrokenLineListDto item = new GroupByTimeBrokenLineListDto();
                    item.Time = i;
                    item.NewCustomerPerformance = dataList.Where(e => e.Time == i).Select(e => e.NewCustomerPerformance).SingleOrDefault();
                    item.OldCustomerPerformance = dataList.Where(e => e.Time == i).Select(e => e.OldCustomerPerformance).SingleOrDefault();
                    item.EffectivePerformance = dataList.Where(e => e.Time == i).Select(e => e.EffectivePerformance).SingleOrDefault();
                    item.PotentialPerformance = dataList.Where(e => e.Time == i).Select(e => e.PotentialPerformance).SingleOrDefault();
                    item.ThisMonthSendOrderPerformance = dataList.Where(e => e.Time == i).Select(e => e.ThisMonthSendOrderPerformance).SingleOrDefault();
                    item.HistorySendOrderPerformance = dataList.Where(e => e.Time == i).Select(e => e.HistorySendOrderPerformance).SingleOrDefault();
                    item.TikTokPerformance = dataList.Where(e => e.Time == i).Select(e => e.TikTokPerformance).SingleOrDefault();
                    item.VideoPerformance = dataList.Where(e => e.Time == i).Select(e => e.VideoPerformance).SingleOrDefault();
                    item.LiveAnchorVideoPerformance = dataList.Where(e => e.Time == i).Select(e => e.LiveAnchorVideoPerformance).SingleOrDefault();
                    item.AssistantPhotoPerformance = dataList.Where(e => e.Time == i).Select(e => e.AssistantPhotoPerformance).SingleOrDefault();
                    item.LiveAnchorReceptionPerformance = dataList.Where(e => e.Time == i).Select(e => e.LiveAnchorReceptionPerformance).SingleOrDefault();
                    item.NoLiveAnchorReceptionPerformance = dataList.Where(e => e.Time == i).Select(e => e.NoLiveAnchorReceptionPerformance).SingleOrDefault();
                    list.Add(item);
                }
            }
            if (type == "month")
            {
                var totalDays = DateTime.DaysInMonth(year, month);
                for (int i = 1; i < totalDays + 1; i++)
                {
                    GroupByTimeBrokenLineListDto item = new GroupByTimeBrokenLineListDto();
                    item.Time = i;
                    item.NewCustomerPerformance = dataList.Where(e => e.Time == i).Select(e => e.NewCustomerPerformance).SingleOrDefault();
                    item.OldCustomerPerformance = dataList.Where(e => e.Time == i).Select(e => e.OldCustomerPerformance).SingleOrDefault();
                    item.EffectivePerformance = dataList.Where(e => e.Time == i).Select(e => e.EffectivePerformance).SingleOrDefault();
                    item.PotentialPerformance = dataList.Where(e => e.Time == i).Select(e => e.PotentialPerformance).SingleOrDefault();
                    item.ThisMonthSendOrderPerformance = dataList.Where(e => e.Time == i).Select(e => e.ThisMonthSendOrderPerformance).SingleOrDefault();
                    item.HistorySendOrderPerformance = dataList.Where(e => e.Time == i).Select(e => e.HistorySendOrderPerformance).SingleOrDefault();
                    item.TikTokPerformance = dataList.Where(e => e.Time == i).Select(e => e.TikTokPerformance).SingleOrDefault();
                    item.VideoPerformance = dataList.Where(e => e.Time == i).Select(e => e.VideoPerformance).SingleOrDefault();
                    item.LiveAnchorVideoPerformance = dataList.Where(e => e.Time == i).Select(e => e.LiveAnchorVideoPerformance).SingleOrDefault();
                    item.AssistantPhotoPerformance = dataList.Where(e => e.Time == i).Select(e => e.AssistantPhotoPerformance).SingleOrDefault();
                    item.LiveAnchorReceptionPerformance = dataList.Where(e => e.Time == i).Select(e => e.LiveAnchorReceptionPerformance).SingleOrDefault();
                    item.NoLiveAnchorReceptionPerformance = dataList.Where(e => e.Time == i).Select(e => e.NoLiveAnchorReceptionPerformance).SingleOrDefault();
                    list.Add(item);
                }
            }
            return list;
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
            var brokenLine = await contentPlatFormOrderDealInfoService.GetPerformanceBrokenLineAsync(year, month, isCustomer, LiveAnchorInfo);
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
            var brokenLine = await liveAnchorMonthlyTargetLivingService.GetLiveAnchorCommercePerformance(year, month, LiveAnchorInfo);
            return BreakLineClassUtil<PerformanceInfoByDateDto>.Convert(month, brokenLine);
        }

        /// <summary>
        /// 获取照片/视频面诊折线图
        /// </summary>
        /// <param name="year">登记日期年</param>
        /// <param name="month">登记日期月</param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetPictureOrVideoConsultationAsync(int year, int month, bool isVideo, string liveAnchorName)
        {
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            var brokenLine = await contentPlateFormOrderService.GetPictureOrVideoPerformanceByLiveAnchorBrokenLineAsync(year, month, isVideo, LiveAnchorInfo);
            return BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, brokenLine);

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
            if (isLiveAnchorIndependence == true)
            {
                var employeeInfo = await amiyaEmployeeService.GetByNameAsync(liveAnchorName);
                empId = employeeInfo.Id;
            }
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            var brokenLine = await contentPlatFormOrderDealInfoService.GetIndependenceOrAssistAsync(year, month, IsAssist, LiveAnchorInfo, empId);
            return BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, brokenLine);

        }

        /// <summary>
        /// 获取分组经营看板折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorBaseId"></param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetBaseBusinessPerformanceBrokenLineAsync(int year, int month, bool? isHistoryConsulationCardConsumed, bool? isConsulationCardRefund, bool? isAddWechat, bool? isConsulation, string liveAnchorBaseName)
        {
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorBaseName);
            var brokenLine = await shoppingCartRegistrationService.GetBaseBusinessPerformanceByLiveAnchorNameBrokenLineAsync(year, month, isHistoryConsulationCardConsumed, isConsulationCardRefund, isAddWechat, isConsulation, LiveAnchorInfo);
            return BreakLineClassUtil<PerformanceBrokenLine>.Convert(month, brokenLine);

        }



        /// <summary>
        /// 获取派单成交业绩折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isSend"></param>
        /// <param name="isDeal"></param>
        /// <param name="isToHospital"></param>
        /// <param name="isOldCustomer"></param>
        /// <param name="liveAnchorBaseName"></param>
        /// <returns></returns>
        public async Task<List<ContentPlatFormOrderInfoDto>> GetSendOrDealBrokenLineAsync(bool? isSend, bool? isDeal, bool? isToHospital, bool? isOldCustomer, string liveAnchorBaseName)
        {
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorBaseName);
            return await contentPlateFormOrderService.GetSendOrDealPerformanceByLiveAnchorBrokenLineAsync(isSend, isDeal, isToHospital, isOldCustomer, LiveAnchorInfo);

        }


        /// <summary>
        ///  获取主播客单价折线图
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="isOldCustomer">新诊/老客</param>
        /// <param name="liveAnchorName">主播名称</param>
        /// <returns></returns>
        public async Task<List<PerformanceBrokenLine>> GetGuestUnitPricePerformanceAsync(int year, int month, bool? isOldCustomer, string liveAnchorName)
        {
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            var brokenLine = await contentPlatFormOrderDealInfoService.GetGuestUnitPricePerformanceBrokenLineAsync(year, month, isOldCustomer, LiveAnchorInfo);
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
            var result = Math.Round((currentMonthPerformance - performanceYearOnYear) / performanceYearOnYear * 100, 2, MidpointRounding.AwayFromZero);
            if (result > 99.99M)
            {
                result = Math.Round(result, 1, MidpointRounding.AwayFromZero);
            }
            if (result > 999.99M)
            {
                result = Math.Round(result, 0, MidpointRounding.AwayFromZero);
            }
            return result;

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
            var result = Math.Round((currentMonthPerformance - performanceChainRatio) / performanceChainRatio * 100, 2, MidpointRounding.AwayFromZero);
            if (result > 99.99M)
            {
                result = Math.Round(result, 1, MidpointRounding.AwayFromZero);
            }
            if (result > 999.99M)
            {
                result = Math.Round(result, 0, MidpointRounding.AwayFromZero);
            }
            return result;
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
            var result = Math.Round(completePerformance / monthTarget * 100, 2, MidpointRounding.AwayFromZero);
            if (result > 99.99M)
            {
                result = Math.Round(result, 1, MidpointRounding.AwayFromZero);
            }
            if (result > 999.99M)
            {
                result = Math.Round(result, 0, MidpointRounding.AwayFromZero);
            }
            return result;
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

        /// <summary>
        /// 根据主播id与是否自播获取主播id集合
        /// </summary>
        /// <param name="liveAnchorName"></param>
        /// <returns></returns>
        private async Task<List<int>> GetLiveAnchorIdsByBaseIdAndIsSelfLiveAnchorAsync(string baseLiveAnchorId, bool? isSelfLiveAnchor)
        {
            List<int> LiveAnchorInfo = new List<int>();
            //获取主播基础信息id
            var liveAnchorBaseInfo = await liveAnchorBaseInfoService.GetByIdAndIsSelfLiveAnchorAsync(baseLiveAnchorId, isSelfLiveAnchor);
            var liveanchorBaseIds = liveAnchorBaseInfo.Select(x => x.Id).ToList();
            if (liveanchorBaseIds.Count != 0)
            {
                var liveAnchor = await liveAnchorService.GetValidListByLiveAnchorBaseIdAsync(liveanchorBaseIds);
                LiveAnchorInfo = liveAnchor.Select(x => x.Id).ToList();
            }
            return LiveAnchorInfo;
        }



        #endregion
    }
}