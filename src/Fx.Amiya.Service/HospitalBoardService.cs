using Fx.Amiya.Dto.HospitalBoard;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class HospitalBoardService : IHospitalBoardService
    {
        private readonly IContentPlateFormOrderService contentPlateFormOrderService;

        public HospitalBoardService(IContentPlateFormOrderService contentPlateFormOrderService)
        {
            this.contentPlateFormOrderService = contentPlateFormOrderService;
        }
        /// <summary>
        /// 获取成交看板咨询数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<OperateConsultantRankDataDto>> GetDealConsultantRankDataAsync(int year, int month, int hospitalId)
        {
            var date = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month);
            return await contentPlateFormOrderService.GetDealConsultantDataAsync(date.StartDate,date.EndDate,hospitalId);
        }
        /// <summary>
        /// 获取成交看板接诊数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<OperateConsultantRankDataDto>> GetDealSceneRankDataAsync(int year, int month, int hospitalId)
        {
            var date = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month);
            return await contentPlateFormOrderService.GetDealSceneConsultantDataAsync(date.StartDate, date.EndDate, hospitalId);
        }
        /// <summary>
        /// 获取成交看板科室数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<OperateDepartmentRankDto>> GetDealDepartmentRankDataAsync(int year, int month, int hospitalId)
        {
            var date = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month);
            return await contentPlateFormOrderService.GetDealDepartmentDataAsync(date.StartDate, date.EndDate, hospitalId);
        }
        /// <summary>
        /// 获取成交看板业绩数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<DealPerformanceBordDataDto> GetDealPerformanceDataAsync(int year, int month, int hospitalId)
        {
            var date = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month);
            var thisMonthData = await contentPlateFormOrderService.GetDealDataAsync(date.StartDate, date.EndDate, hospitalId);

            var lastMonthData = await contentPlateFormOrderService.GetDealDataAsync(date.LastMonthStartDate, date.LastMonthEndDate, hospitalId);

            var lastYearThisMonthData = await contentPlateFormOrderService.GetDealDataAsync(date.LastYearThisMonthStartDate, date.LastYearThisMonthEndDate, hospitalId);
            DealPerformanceBordDataDto dealPerformanceBordDataDto = new DealPerformanceBordDataDto();
            dealPerformanceBordDataDto.TotalPerformance = thisMonthData.TotalPerformance;
            dealPerformanceBordDataDto.TotalPerformanceChainRatio = DecimalExtension.CalculateChain(thisMonthData.TotalPerformance, lastMonthData.TotalPerformance);
            dealPerformanceBordDataDto.TotalPerformanceYearOnYear = DecimalExtension.CalculateChain(lastYearThisMonthData.TotalPerformance, lastYearThisMonthData.TotalPerformance);

            dealPerformanceBordDataDto.NewCustomerPerformance = thisMonthData.NewCustomerPerformance;
            dealPerformanceBordDataDto.NewCustomerPerformanceChainRatio = DecimalExtension.CalculateChain(thisMonthData.NewCustomerPerformance, lastMonthData.NewCustomerPerformance);
            dealPerformanceBordDataDto.TotalPerformanceYearOnYear = DecimalExtension.CalculateChain(lastMonthData.NewCustomerPerformance, lastYearThisMonthData.NewCustomerPerformance);

            dealPerformanceBordDataDto.OldCustomerPerformance = thisMonthData.OldCustomerPerformance;
            dealPerformanceBordDataDto.OldCustomerPerformanceChainRatio = DecimalExtension.CalculateChain(thisMonthData.OldCustomerPerformance, lastMonthData.OldCustomerPerformance);
            dealPerformanceBordDataDto.OldCustomerPerformanceYearOnYear = DecimalExtension.CalculateChain(lastMonthData.OldCustomerPerformance, lastYearThisMonthData.OldCustomerPerformance);

            return dealPerformanceBordDataDto;
        }




        /// <summary>
        /// 获取机构排名数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<HospitalRankDto> GetHospitalRankDataAsync(int year, int month,int hospitalId)
        {
            var date = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month);
            var rankList= await contentPlateFormOrderService.GetRankDataAsync(date.StartDate,date.EndDate);
            HospitalRankDto hospitalRankDto = new HospitalRankDto();
            hospitalRankDto.RankList = rankList;
            hospitalRankDto.MyRank = rankList.Where(e => e.HospitalId == hospitalId).SingleOrDefault();
            return hospitalRankDto;
        }
        /// <summary>
        /// 获取运营看板数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<OperateDataDto> GetOperateDataAsync(int year, int month,int hospitalId)
        {
            var date = DateTimeExtension.GetSequentialDateByStartAndEndDate(year, month);
            var thisMonthData = await contentPlateFormOrderService.GetOperateDataByMonthAsync(date.StartDate, date.EndDate, hospitalId);

            var lastMonthData = await contentPlateFormOrderService.GetOperateDataByMonthAsync(date.LastMonthStartDate, date.LastMonthEndDate, hospitalId);

            var lastYearThisMonthData = await contentPlateFormOrderService.GetOperateDataByMonthAsync(date.LastYearThisMonthStartDate, date.LastYearThisMonthEndDate, hospitalId);
            OperateDataDto operateData = new OperateDataDto();
            operateData.NewCustomerToHospitalCount = thisMonthData.NewCustomerToHospitalCount;
            operateData.NewCustomerToHospitalChainRatio = DecimalExtension.CalculateChain(thisMonthData.NewCustomerToHospitalCount,lastMonthData.NewCustomerToHospitalCount);
            operateData.NewCustomerToHospitalYearOnYear = DecimalExtension.CalculateChain(lastMonthData.NewCustomerToHospitalCount, lastYearThisMonthData.NewCustomerToHospitalCount);

            operateData.NewCustomerDealCount = thisMonthData.NewCustomerDealCount;
            operateData.NewCustomerDealChainRatio = DecimalExtension.CalculateChain(thisMonthData.NewCustomerDealCount, lastMonthData.NewCustomerDealCount);
            operateData.NewCustomerDealYearOnYear = DecimalExtension.CalculateChain(thisMonthData.NewCustomerDealCount, lastYearThisMonthData.NewCustomerDealCount);

            operateData.OldCustomerDealCount = thisMonthData.OldCustomerDealCount;
            operateData.OldCustomerDealChainRatio= DecimalExtension.CalculateChain(thisMonthData.OldCustomerDealCount, lastMonthData.OldCustomerDealCount);
            operateData.OldCustomerDealYearOnYear = DecimalExtension.CalculateChain(thisMonthData.OldCustomerDealCount, lastYearThisMonthData.OldCustomerDealCount);

            operateData.NewCustomerToHospitalRatio = thisMonthData.NewCustomerToHospitalRatio;
            operateData.NewCustomerToHospitalRatioChainRatio= DecimalExtension.CalculateChain(thisMonthData.NewCustomerToHospitalRatio.Value, lastMonthData.NewCustomerToHospitalRatio.Value);
            operateData.NewCustomerToHospitalRatioYearOnYear= DecimalExtension.CalculateChain(thisMonthData.NewCustomerToHospitalRatio.Value, lastYearThisMonthData.NewCustomerToHospitalRatio.Value);
            operateData.NewCustomerToHospitalRatioHealthValue = thisMonthData.NewCustomerToHospitalRatioHealthValue;

            operateData.NewCustomerDealRation = thisMonthData.NewCustomerDealRation;
            operateData.NewCustomerDealRationChainRatio= DecimalExtension.CalculateChain(thisMonthData.NewCustomerDealRation.Value, lastMonthData.NewCustomerDealRation.Value);
            operateData.NewCustomerDealRationYearOnYear= DecimalExtension.CalculateChain(thisMonthData.NewCustomerDealRation.Value, lastYearThisMonthData.NewCustomerDealRation.Value);
            operateData.NewCustomerDealRationHealthValue = thisMonthData.NewCustomerDealRationHealthValue;

            operateData.OldCustomerRepurchaseRatio = thisMonthData.OldCustomerRepurchaseRatio;
            operateData.OldCustomerRepurchaseRatioChainRatio= DecimalExtension.CalculateChain(thisMonthData.OldCustomerRepurchaseRatio.Value, lastMonthData.OldCustomerRepurchaseRatio.Value);
            operateData.OldCustomerRepurchaseRatioYearOnYear= DecimalExtension.CalculateChain(thisMonthData.OldCustomerRepurchaseRatio.Value, lastYearThisMonthData.OldCustomerRepurchaseRatio.Value);
            operateData.OldCustomerRepurchaseRatioHealthValue = thisMonthData.OldCustomerRepurchaseRatioHealthValue;

            operateData.AccumulateNewCustomerToHospitalCount = thisMonthData.AccumulateNewCustomerToHospitalCount;
            operateData.AccumulateNewCustomerToHospitalCountChainRatio = DecimalExtension.CalculateChain(thisMonthData.AccumulateNewCustomerToHospitalCount,lastMonthData.AccumulateNewCustomerToHospitalCount);
            operateData.AccumulateNewCustomerToHospitalCountYearOnYear = DecimalExtension.CalculateChain(thisMonthData.AccumulateNewCustomerToHospitalCount, lastYearThisMonthData.AccumulateNewCustomerToHospitalCount);

            operateData.AccumulateNewCustomerDealCount = thisMonthData.AccumulateNewCustomerDealCount;
            operateData.AccumulateNewCustomerDealCountChainRatio = DecimalExtension.CalculateChain(thisMonthData.AccumulateNewCustomerDealCount,lastMonthData.AccumulateNewCustomerDealCount);
            operateData.AccumulateNewCustomerDealCountYearOnYear = DecimalExtension.CalculateChain(thisMonthData.AccumulateNewCustomerDealCount,lastYearThisMonthData.AccumulateNewCustomerDealCount);

            operateData.AccumulateOldCustomerDealCount = thisMonthData.AccumulateOldCustomerDealCount;
            operateData.AccumulateOldCustomerDealCountChainRatio = DecimalExtension.CalculateChain(thisMonthData.AccumulateOldCustomerDealCount,lastMonthData.AccumulateOldCustomerDealCount);
            operateData.AccumulateOldCustomerDealCountYearOnYear = DecimalExtension.CalculateChain(thisMonthData.AccumulateOldCustomerDealCount, lastYearThisMonthData.AccumulateOldCustomerDealCount);

            operateData.AccumulateNewCustomerToHospitalRatio = thisMonthData.AccumulateNewCustomerToHospitalRatio;
            operateData.AccumulateNewCustomerToHospitalRatioChainRatio = DecimalExtension.CalculateChain(thisMonthData.AccumulateNewCustomerToHospitalRatio,lastMonthData.AccumulateNewCustomerToHospitalRatio);
            operateData.AccumulateNewCustomerToHospitalRatioYearOnYear = DecimalExtension.CalculateChain(thisMonthData.AccumulateNewCustomerToHospitalRatio,lastYearThisMonthData.AccumulateNewCustomerToHospitalRatio);

            operateData.AccumulateNewCustomerDealRation = thisMonthData.AccumulateNewCustomerDealRation;
            operateData.AccumulateNewCustomerDealRationChainRatio = DecimalExtension.CalculateChain(thisMonthData.AccumulateNewCustomerDealRation,lastMonthData.AccumulateNewCustomerDealRation);
            operateData.AccumulateNewCustomerDealRationYearOnYear = DecimalExtension.CalculateChain(thisMonthData.AccumulateNewCustomerDealRation, lastYearThisMonthData.AccumulateNewCustomerDealRation);

            return operateData;
        }
        /// <summary>
        /// 获取订单看板数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>

        public async Task<OrderDataDto> GetOrderBoardDataAsync(int year, int month, int hospitalId)
        {
            var date = DateTimeExtension.GetSequentialDateByStartAndEndDate(year,month);

            var thisMonthData=await contentPlateFormOrderService.GetOrderDataByMonthAsync(date.StartDate,date.EndDate,hospitalId);

            var lastMonthData=await contentPlateFormOrderService.GetOrderDataByMonthAsync(date.LastMonthStartDate, date.LastMonthEndDate, hospitalId);

            var lastYearThisMonthData=await contentPlateFormOrderService.GetOrderDataByMonthAsync(date.LastYearThisMonthStartDate, date.LastYearThisMonthEndDate, hospitalId);

            var accumulateOrderData = await contentPlateFormOrderService.GetAccumulateOrderDataAsync(hospitalId);

            OrderDataDto orderDataDto = new OrderDataDto();
            orderDataDto.SendOrderCount = thisMonthData.SendOrderCount;
            orderDataDto.SendOrderCountChainRatio = DecimalExtension.CalculateChain(thisMonthData.SendOrderCount,lastMonthData.SendOrderCount);
            orderDataDto.SendOrderCountYearOnYear = DecimalExtension.CalculateChain(thisMonthData.SendOrderCount,lastYearThisMonthData.SendOrderCount);


            orderDataDto.ProcessedOrderCount = thisMonthData.ProcessedOrderCount;
            orderDataDto.ProcessedOrderChainRatio= DecimalExtension.CalculateChain(thisMonthData.ProcessedOrderCount, lastMonthData.ProcessedOrderCount);
            orderDataDto.ProcessedOrderYearOnYear = DecimalExtension.CalculateChain(thisMonthData.ProcessedOrderCount, lastYearThisMonthData.ProcessedOrderCount);




            orderDataDto.UntreatedOrderCount = thisMonthData.UntreatedOrderCount;
            orderDataDto.UntreatedChainRatio = DecimalExtension.CalculateChain(thisMonthData.UntreatedOrderCount, lastMonthData.UntreatedOrderCount);
            orderDataDto.UntreatedYearOnYear= DecimalExtension.CalculateChain(thisMonthData.UntreatedOrderCount, lastYearThisMonthData.UntreatedOrderCount);



            orderDataDto.SendOrderNotToHospitalCount = thisMonthData.SendOrderNotToHospitalCount;
            orderDataDto.SendOrderNotToHospitalChainRatio= DecimalExtension.CalculateChain(thisMonthData.SendOrderNotToHospitalCount, lastMonthData.SendOrderNotToHospitalCount);
            orderDataDto.SendOrderNotToHospitalYearOnYear = DecimalExtension.CalculateChain(thisMonthData.SendOrderNotToHospitalCount, lastYearThisMonthData.SendOrderNotToHospitalCount);


            orderDataDto.ToHospitalNoDealCount = thisMonthData.ToHospitalNoDealCount;
            orderDataDto.ToHospitalNoDealChainRatio= DecimalExtension.CalculateChain(thisMonthData.ToHospitalNoDealCount, lastMonthData.ToHospitalNoDealCount);
            orderDataDto.ToHospitalNoDealYearOnYear= DecimalExtension.CalculateChain(thisMonthData.ToHospitalNoDealCount, lastYearThisMonthData.ToHospitalNoDealCount);



            orderDataDto.DealNoRepurchaseCount = thisMonthData.DealNoRepurchaseCount;
            orderDataDto.DealNoRepurchaseChainRatio= DecimalExtension.CalculateChain(thisMonthData.DealNoRepurchaseCount, lastMonthData.DealNoRepurchaseCount);
            orderDataDto.DealNoRepurchaseYearOnYear = DecimalExtension.CalculateChain(thisMonthData.DealNoRepurchaseCount, lastYearThisMonthData.DealNoRepurchaseCount);


            orderDataDto.AccumulateSendOrderCount = accumulateOrderData.AccumulateSendOrderCount;
            orderDataDto.AccumulateProcessedOrderCount = accumulateOrderData.AccumulateProcessedOrderCount;
            orderDataDto.AccumulateUntreatedOrderCount = accumulateOrderData.AccumulateUntreatedOrderCount;
            orderDataDto.AccumulateSendOrderNotToHospitalCount = accumulateOrderData.AccumulateSendOrderNotToHospitalCount;
            orderDataDto.AccumulateToHospitalNoDealCount = accumulateOrderData.AccumulateToHospitalNoDealCount;
            orderDataDto.AccumulateDealNoRepurchaseCount = accumulateOrderData.AccumulateDealNoRepurchaseCount;


            return orderDataDto;
        }

        
    }
}
