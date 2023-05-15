using Fx.Amiya.Background.Api.Vo.HospitalBoard;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 医院看板
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxTenantAuthorize]
    public class HospitalBoardController : ControllerBase
    {
        private readonly IHospitalBoardService hospitalBoardService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public HospitalBoardController(IHospitalBoardService hospitalBoardService, IHttpContextAccessor httpContextAccessor)
        {
            this.hospitalBoardService = hospitalBoardService;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 订单数据看板
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("orderData")]
        public async Task<ResultData<OrderBordDataVo>> GetHospitalOrderData(int year,int month) {
            int hospitalId = 0;
            if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
                hospitalId = tenant.HospitalId;

            if (hospitalId == 0)
                throw new Exception("医院编号不能为空");
            var orderData= await hospitalBoardService.GetOrderBoardDataAsync(year,month,hospitalId);
            OrderBordDataVo orderBordData = new OrderBordDataVo();
            orderBordData.SendOrderCount = orderData.SendOrderCount;
            orderBordData.SendOrderCountChainRatio = orderData.SendOrderCountChainRatio;
            orderBordData.SendOrderCountYearOnYear = orderData.SendOrderCountYearOnYear;
            orderBordData.ProcessedOrderCount = orderData.ProcessedOrderCount;
            orderBordData.ProcessedOrderChainRatio = orderData.ProcessedOrderChainRatio;
            orderBordData.ProcessedOrderYearOnYear = orderData.ProcessedOrderYearOnYear;
            orderBordData.UntreatedOrderCount = orderData.UntreatedOrderCount;
            orderBordData.UntreatedChainRatio = orderData.UntreatedChainRatio;
            orderBordData.UntreatedYearOnYear = orderData.UntreatedYearOnYear;
            orderBordData.SendOrderNotToHospitalCount = orderData.SendOrderNotToHospitalCount;
            orderBordData.SendOrderNotToHospitalChainRatio = orderData.SendOrderNotToHospitalChainRatio;
            orderBordData.SendOrderNotToHospitalYearOnYear = orderData.SendOrderNotToHospitalYearOnYear;
            orderBordData.ToHospitalNoDealCount = orderData.ToHospitalNoDealCount;
            orderBordData.ToHospitalNoDealChainRatio = orderData.ToHospitalNoDealChainRatio;
            orderBordData.ToHospitalNoDealYearOnYear = orderData.ToHospitalNoDealYearOnYear;
            orderBordData.DealNoRepurchaseCount = orderData.DealNoRepurchaseCount;
            orderBordData.DealNoRepurchaseChainRatio = orderData.DealNoRepurchaseChainRatio;
            orderBordData.DealNoRepurchaseYearOnYear = orderData.DealNoRepurchaseYearOnYear;
            return ResultData<OrderBordDataVo>.Success().AddData("orderData", orderBordData);
        }

        /// <summary>
        /// 运营数据看板
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("operationData")]
        public async Task<ResultData<OperateDataVo>> GetHospitalOperateDataAsync(int year, int month) {
            int hospitalId = 0;
            if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
                hospitalId = tenant.HospitalId;

            if (hospitalId == 0)
                throw new Exception("医院编号不能为空");
            var operateData = await hospitalBoardService.GetOperateDataAsync(year, month, hospitalId);
            OperateDataVo operateDataVo = new OperateDataVo();
            operateDataVo.NewCustomerToHospitalCount = operateData.NewCustomerToHospitalCount;
            operateDataVo.NewCustomerToHospitalChainRatio = operateData.NewCustomerToHospitalChainRatio;
            operateDataVo.NewCustomerToHospitalYearOnYear = operateData.NewCustomerToHospitalYearOnYear;

            operateDataVo.NewCustomerDealCount = operateData.NewCustomerDealCount;
            operateDataVo.NewCustomerDealChainRatio = operateData.NewCustomerDealChainRatio;
            operateDataVo.NewCustomerDealYearOnYear = operateData.NewCustomerDealYearOnYear;

            operateDataVo.OldCustomerToHospitalCount = operateData.OldCustomerToHospitalCount;
            operateDataVo.OldCustomerToHospitalChainRatio = operateData.OldCustomerToHospitalChainRatio;
            operateDataVo.OldCustomerToHospitalYearOnYear = operateData.OldCustomerToHospitalYearOnYear;

            operateDataVo.OldCustomerDealCount = operateData.OldCustomerDealCount;
            operateDataVo.OldCustomerDealChainRatio = operateData.OldCustomerDealChainRatio;
            operateDataVo.OldCustomerDealYearOnYear = operateData.OldCustomerDealYearOnYear;

            operateDataVo.NewCustomerToHospitalRatio = operateData.NewCustomerToHospitalRatio;
            operateDataVo.NewCustomerToHospitalRatioChainRatio = operateData.NewCustomerToHospitalRatioChainRatio;
            operateDataVo.NewCustomerToHospitalRatioYearOnYear = operateData.NewCustomerToHospitalRatioYearOnYear;
            operateDataVo.NewCustomerToHospitalRatioHealthValue = operateData.NewCustomerToHospitalRatioHealthValue;

            operateDataVo.NewCustomerDealRation = operateData.NewCustomerDealRation;
            operateDataVo.NewCustomerDealRationChainRatio = operateData.NewCustomerDealRationChainRatio;
            operateDataVo.NewCustomerDealRationYearOnYear = operateData.NewCustomerDealRationYearOnYear;
            operateDataVo.NewCustomerDealRationHealthValue = operateData.NewCustomerDealRationHealthValue;

            operateDataVo.OldCustomerRepurchaseRatio = operateData.OldCustomerRepurchaseRatio;
            operateDataVo.OldCustomerRepurchaseRatioChainRatio = operateData.OldCustomerRepurchaseRatioChainRatio;
            operateDataVo.OldCustomerRepurchaseRatioYearOnYear = operateData.OldCustomerRepurchaseRatioYearOnYear;
            operateDataVo.OldCustomerRepurchaseRatioHealthValue = operateData.OldCustomerRepurchaseRatioHealthValue;

            operateDataVo.OldCustomerDealRation = operateData.OldCustomerDealRation;
            operateDataVo.OldCustomerDealRationChainRatio = operateData.OldCustomerDealRationChainRatio;
            operateDataVo.OldCustomerDealRationYearOnYear = operateData.OldCustomerDealRationYearOnYear;
            operateDataVo.OldCustomerDealRationHealthValue = operateData.OldCustomerDealRationHealthValue;

            return ResultData<OperateDataVo>.Success().AddData("operateData", operateDataVo);

        }
        /// <summary>
        /// 成交看板业绩数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("dealPerformance")]
        public async Task<ResultData<DealPerformanceVo>> GetDealPerformanceAsync(int year, int month) {
            int hospitalId = 0;
            if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
                hospitalId = tenant.HospitalId;

            if (hospitalId == 0)
                throw new Exception("医院编号不能为空");
            var data=await hospitalBoardService.GetDealPerformanceDataAsync(year,month,hospitalId);
            DealPerformanceVo performance = new DealPerformanceVo();
            performance.TotalPerformance = data.TotalPerformance;
            performance.TotalPerformanceChainRatio = data.TotalPerformanceChainRatio;
            performance.TotalPerformanceYearOnYear = data.TotalPerformanceYearOnYear;
            performance.NewCustomerPerformance = data.NewCustomerPerformance;
            performance.NewCustomerPerformanceChainRatio = data.NewCustomerPerformanceChainRatio;
            performance.NewCustomerPerformanceYearOnYear = data.NewCustomerPerformanceYearOnYear;
            performance.OldCustomerPerformance = data.OldCustomerPerformance;
            performance.OldCustomerPerformanceChainRatio = data.OldCustomerPerformanceChainRatio;
            performance.OldCustomerPerformanceYearOnYear = data.OldCustomerPerformanceYearOnYear;
            return ResultData<DealPerformanceVo>.Success().AddData("dealPerformance", performance);
        }
        /// <summary>
        /// 获取科室排名数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("departmentRankList")]
        public async Task<ResultData<List<OperateDepartmentRankVo>>> GetDealDepartmentRankAsync(int year,int month) {
            int hospitalId = 0;
            if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
                hospitalId = tenant.HospitalId;

            if (hospitalId == 0)
                throw new Exception("医院编号不能为空");
            var data = await hospitalBoardService.GetDealDepartmentRankDataAsync(year, month, hospitalId);
            var rankList = data.Select(e => new OperateDepartmentRankVo {
                Rank=e.Rank,
                DepartMentName=e.DepartMentName,
                ToHospitalRatio=e.ToHospitalRatio,
                DealRation=e.DealRation,
                AccumulateToHospitalRatio=e.AccumulateToHospitalRatio,
                AccumulateDealRation=e.AccumulateDealRation,
                NewCustomerUnitPrice=e.NewCustomerUnitPrice,
                OldCustomerUnitPrice=e.OldCustomerUnitPrice,
                Performance=e.Performance,
                PerformanceRatio=e.PerformanceRatio

            }).ToList();
            return ResultData<List<OperateDepartmentRankVo>>.Success().AddData("rankList", rankList);
        }
        /// <summary>
        /// 获取咨询排名数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("consultantRankList")]
        public async Task<ResultData<List<OperaConsultantRankDataVo>>> GetDealConsultantRankAsync(int year, int month)
        {
            int hospitalId = 0;
            if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
                hospitalId = tenant.HospitalId;

            if (hospitalId == 0)
                throw new Exception("医院编号不能为空");
            var data = await hospitalBoardService.GetDealConsultantRankDataAsync(year, month, hospitalId);
            var rankList = data.Select(e => new OperaConsultantRankDataVo
            {
                Rank = e.Rank,
                Name = e.Name,
                ToHospitalRatio = e.ToHospitalRatio,
                DealRation = e.DealRation,
                AccumulateToHospitalRatio=e.AccumulateToHospitalRatio,
                AccumulateDealRation=e.AccumulateDealRation,
                NewCustomerUnitPrice = e.NewCustomerUnitPrice,
                OldCustomerUnitPrice = e.OldCustomerUnitPrice,
                Performance = e.Performance,
                PerformanceRatio = e.PerformanceRatio

            }).ToList();
            return ResultData<List<OperaConsultantRankDataVo>>.Success().AddData("rankList", rankList);
        }
        /// <summary>
        /// 获取接诊排名数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("sceneConsultantRankList")]
        public async Task<ResultData<List<OperaConsultantRankDataVo>>> GetDealSceneConsultantRankAsync(int year, int month)
        {
            int hospitalId = 0;
            if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
                hospitalId = tenant.HospitalId;

            if (hospitalId == 0)
                throw new Exception("医院编号不能为空");
            var data = await hospitalBoardService.GetDealSceneRankDataAsync(year, month, hospitalId);
            var rankList = data.Select(e => new OperaConsultantRankDataVo
            {
                Rank = e.Rank,
                Name = e.Name,
                ToHospitalRatio = e.ToHospitalRatio,
                DealRation = e.DealRation,
                AccumulateToHospitalRatio=e.AccumulateToHospitalRatio,
                AccumulateDealRation=e.AccumulateDealRation,
                NewCustomerUnitPrice = e.NewCustomerUnitPrice,
                OldCustomerUnitPrice = e.OldCustomerUnitPrice,
                Performance = e.Performance,
                PerformanceRatio = e.PerformanceRatio

            }).ToList();
            return ResultData<List<OperaConsultantRankDataVo>>.Success().AddData("rankList", rankList);
        }
        /// <summary>
        /// 获取机构排名数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("rankData")]
        public async Task<ResultData<RankDataVo>> GetRankDataAsync(int year,int month) {
            int hospitalId = 0;
            if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
                hospitalId = tenant.HospitalId;

            if (hospitalId == 0)
                throw new Exception("医院编号不能为空");
            var rank=await hospitalBoardService.GetHospitalRankDataAsync(year,month,hospitalId);
            RankDataVo rankDataVo = new RankDataVo();
            rankDataVo.RankList = rank.RankList.Select(e => new RankData
            {
                Rank=e.Rank,
                Name=e.Name,
                ToHospitalRatio=e.ToHospitalRatio,
                DealRatio=e.DealRatio,
                RepurchaseRatio=e.RepurchaseRatio,
                NewCustomerUnitPrice=e.NewCustomerUnitPrice,
            }).ToList();
            if (rank.MyRank == null)
            {
                rankDataVo.MyRank = null;
            }
            else {
                RankData rankData = new RankData();
                rankData.Rank = rank.MyRank.Rank;
                rankData.Name = rank.MyRank.Name;
                rankData.ToHospitalRatio = rank.MyRank.ToHospitalRatio;
                rankData.DealRatio = rank.MyRank.DealRatio;
                rankData.RepurchaseRatio = rank.MyRank.RepurchaseRatio;
                rankData.NewCustomerUnitPrice = rank.MyRank.NewCustomerUnitPrice;
                rankDataVo.MyRank = rankData;
            }
            return ResultData<RankDataVo>.Success().AddData("rankData", rankDataVo);

        }
    }
}
