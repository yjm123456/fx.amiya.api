using Fx.Amiya.Dto.ContentPlateFormOrder;
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
        private readonly IContentPlateFormOrderService contentPlateFormOrderService;

        public AmiyaPerformanceService(ILiveAnchorMonthlyTargetService liveAnchorMonthlyTargetService,
            IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService,
            ILiveAnchorService liveAnchorService,
            ILiveAnchorBaseInfoService liveAnchorBaseInfoService,
            IShoppingCartRegistrationService shoppingCartRegistrationService,
            IAmiyaEmployeeService amiyaEmployeeService,
            IContentPlateFormOrderService contentPlateFormOrderService)
        {
            this.liveAnchorMonthlyTargetService = liveAnchorMonthlyTargetService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.liveAnchorBaseInfoService = liveAnchorBaseInfoService;
            this.liveAnchorService = liveAnchorService;
            this.shoppingCartRegistrationService = shoppingCartRegistrationService;
            this.amiyaEmployeeService = amiyaEmployeeService;
            this.contentPlateFormOrderService = contentPlateFormOrderService;
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

            var groupJinaPerformance = await liveAnchorMonthlyTargetService.GetLiveAnchorBaseIdPerformance(year, month, liveAnchorJinaBaseInfo.Id);
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
            var groupPerformanceTarget = await liveAnchorMonthlyTargetService.GetBasePerformanceTargetAsync(year, month, LiveAnchorInfo);

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
            baseBusinessPerformanceDto.ConsulationCardNumTargetComplete = CalculateTargetComplete(baseBusinessPerformanceDto.ConsulationCardNum.Value, groupPerformanceTarget.ConsulationCardTarget);

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
            var groupPerformanceTarget = await liveAnchorMonthlyTargetService.GetSendOrDealTargetAsync(year, month, LiveAnchorInfo);
            //获取总体数据
            var liveAnchorSendOrderNum = await contentPlateFormOrderService.GetSendOrDealPerformanceByLiveAnchorAsync(LiveAnchorInfo);


            //环比月份操作
            //开始月份
            DateTime monthStartDate = new DateTime(year, month - 1, 1);
            //结束月份
            DateTime monthEndDate = new DateTime(year, month - 1, 1).AddMonths(1);

            if (month == 1)
            {
                monthStartDate = new DateTime(year - 1, 12, 1);
                monthEndDate = new DateTime(year - 1, 12, 1).AddMonths(1);
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
            DateTime monthStartDate = new DateTime(year, month - 1, 1);
            //结束月份
            DateTime monthEndDate = new DateTime(year, month - 1, 1).AddMonths(1);

            if (month == 1)
            {
                monthStartDate = new DateTime(year - 1, 12, 1);
                monthEndDate = new DateTime(year - 1, 12, 1).AddMonths(1);
            }

            //上年的
            var lastYearThisMonthStartDate = new DateTime(year - 1, month, 1);
            var lastYearThisMonthEndDate = new DateTime(year - 1, month, 1).AddMonths(1);
            #endregion

            GroupTargetCompleteRateDto baseBusinessPerformanceDto = new GroupTargetCompleteRateDto();
            var LiveAnchorInfo = await this.GetLiveAnchorIdsByNameAsync(liveAnchorName);
            var groupPerformanceTarget = await liveAnchorMonthlyTargetService.GetBasePerformanceTargetAsync(year, month, LiveAnchorInfo);
            var groupSendOrDealTarget = await liveAnchorMonthlyTargetService.GetSendOrDealTargetAsync(year, month, LiveAnchorInfo);
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
            var brokenLine = await liveAnchorMonthlyTargetService.GetLiveAnchorCommercePerformance(year, month, LiveAnchorInfo);
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