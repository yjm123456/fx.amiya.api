using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.LiveAnchorMonthlyTarget;
using Fx.Amiya.Background.Api.Vo.LiveAnchorMonthlyTarget.BeforeLiving;
using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
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
    /// 直播前主播月度运营目标情况数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LiveAnchorMonthlyTargetBeforeLivingController : ControllerBase
    {
        private ILiveAnchorMonthlyTargetBeforeLivingService _liveAnchorMonthlyTargetBeforeLivingService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        public LiveAnchorMonthlyTargetBeforeLivingController(ILiveAnchorMonthlyTargetBeforeLivingService liveAnchorMonthlyTargetBeforeLivingService,
            IHttpContextAccessor httpContextAccessor)
        {
            _liveAnchorMonthlyTargetBeforeLivingService = liveAnchorMonthlyTargetBeforeLivingService;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 获取直播前主播月度运营目标情况
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<LiveAnchorMonthlyTargetBeforeLivingVo>>> GetListWithPageAsync(int year, int month, int? liveAnchorId, int pageNum, int pageSize)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await _liveAnchorMonthlyTargetBeforeLivingService.GetListWithPageAsync(year, month, liveAnchorId, employeeId, pageNum, pageSize);

                var liveAnchorMonthlyTargetBeforeLiving = from d in q.List
                                                          select new LiveAnchorMonthlyTargetBeforeLivingVo
                                                          {
                                                              Id = d.Id,
                                                              Year = d.Year,
                                                              Month = d.Month,
                                                              MonthlyTargetName = d.MonthlyTargetName,
                                                              LiveAnchorId = d.LiveAnchorId,
                                                              LiveAnchorName = d.LiveAnchorName,
                                                              ContentPlatFormId = d.ContentPlatFormId,

                                                              ZhihuReleaseTarget = d.ZhihuReleaseTarget,
                                                              CumulativeZhihuRelease = d.CumulativeZhihuRelease,
                                                              ZhihuReleaseCompleteRate = d.ZhihuReleaseCompleteRate,
                                                              ZhihuFlowinvestmentTarget = d.ZhihuFlowinvestmentTarget,
                                                              CumulativeZhihuFlowinvestment = d.CumulativeZhihuFlowinvestment,
                                                              ZhihuFlowinvestmentCompleteRate = d.ZhihuFlowinvestmentCompleteRate,

                                                              VideoReleaseTarget = d.VideoReleaseTarget,
                                                              CumulativeVideoRelease = d.CumulativeVideoRelease,
                                                              VideoReleaseCompleteRate = d.VideoReleaseCompleteRate,
                                                              VideoFlowinvestmentTarget = d.VideoFlowinvestmentTarget,
                                                              CumulativeVideoFlowinvestment = d.CumulativeVideoFlowinvestment,
                                                              VideoFlowinvestmentCompleteRate = d.VideoFlowinvestmentCompleteRate,

                                                              TikTokReleaseTarget = d.TikTokReleaseTarget,
                                                              CumulativeTikTokRelease = d.CumulativeTikTokRelease,
                                                              TikTokReleaseCompleteRate = d.TikTokReleaseCompleteRate,
                                                              TikTokFlowinvestmentTarget = d.TikTokFlowinvestmentTarget,
                                                              CumulativeTikTokFlowinvestment = d.CumulativeTikTokFlowinvestment,
                                                              TikTokFlowinvestmentCompleteRate = d.TikTokFlowinvestmentCompleteRate,
                                                              

                                                              XiaoHongShuReleaseTarget = d.XiaoHongShuReleaseTarget,
                                                              CumulativeXiaoHongShuRelease = d.CumulativeXiaoHongShuRelease,
                                                              XiaoHongShuReleaseCompleteRate = d.XiaoHongShuReleaseCompleteRate,
                                                              XiaoHongShuFlowinvestmentTarget = d.XiaoHongShuFlowinvestmentTarget,
                                                              CumulativeXiaoHongShuFlowinvestment = d.CumulativeXiaoHongShuFlowinvestment,
                                                              XiaoHongShuFlowinvestmentCompleteRate = d.XiaoHongShuFlowinvestmentCompleteRate,

                                                              SinaWeiBoReleaseTarget = d.SinaWeiBoReleaseTarget,
                                                              CumulativeSinaWeiBoRelease = d.CumulativeSinaWeiBoRelease,
                                                              SinaWeiBoReleaseCompleteRate = d.SinaWeiBoReleaseCompleteRate,
                                                              SinaWeiBoFlowinvestmentTarget = d.SinaWeiBoFlowinvestmentTarget,
                                                              CumulativeSinaWeiBoFlowinvestment = d.CumulativeSinaWeiBoFlowinvestment,
                                                              SinaWeiBoFlowinvestmentCompleteRate = d.SinaWeiBoFlowinvestmentCompleteRate,

                                                              ReleaseTarget = d.ReleaseTarget,
                                                              CumulativeRelease = d.CumulativeRelease,
                                                              ReleaseCompleteRate = d.ReleaseCompleteRate,
                                                              FlowInvestmentTarget = d.FlowInvestmentTarget,
                                                              CumulativeFlowInvestment = d.CumulativeFlowInvestment,
                                                              FlowInvestmentCompleteRate = d.FlowInvestmentCompleteRate,
                                                              CreateDate = d.CreateDate,
                                                              TikTokShowcaseIncomeTarget = d.TikTokShowcaseIncomeTarget,
                                                              CumulativeTikTokShowcaseIncome = d.CumulativeTikTokShowcaseIncome,
                                                              TikTokShowcaseIncomeCompleteRate = d.TikTokShowcaseIncomeCompleteRate,
                                                              TikTokCluesTarget = d.TikTokCluesTarget,
                                                              CumulativeTikTokClues = d.CumulativeTikTokClues,
                                                              TikTokCluesCompleteRate = d.TikTokCluesCompleteRate,
                                                              TikTokIncreaseFansTarget = d.TikTokIncreaseFansTarget,
                                                              CumulativeTikTokIncreaseFans = d.CumulativeTikTokIncreaseFans,
                                                              TikTokIncreaseFanseCompleteRate = d.TikTokIncreaseFanseCompleteRate,
                                                              TikTokIncreaseFansFeesCostTarget = d.TikTokIncreaseFansFeesCostTarget,
                                                              CumulativeTikTokIncreaseFansFeesCost = d.CumulativeTikTokIncreaseFansFeesCost,
                                                              TikTokIncreaseFansFeesCostCompleteRate = d.TikTokIncreaseFansFeesCostCompleteRate,
                                                              TikTokIncreaseFansFeesTarget = d.TikTokIncreaseFansFeesTarget,
                                                              CumulativeTikTokIncreaseFansFees = d.CumulativeTikTokIncreaseFansFees,
                                                              TikTokIncreaseFansFeesCompleteRate = d.TikTokIncreaseFansFeesCompleteRate,
                                                              XiaoHongShuShowcaseIncomeTarget = d.XiaoHongShuShowcaseIncomeTarget,
                                                              CumulativeXiaoHongShuShowcaseIncome = d.CumulativeXiaoHongShuShowcaseIncome,
                                                              XiaoHongShuShowcaseIncomeCompleteRate = d.XiaoHongShuShowcaseIncomeCompleteRate,
                                                              XiaoHongShuCluesTarget = d.XiaoHongShuCluesTarget,
                                                              CumulativeXiaoHongShuClues = d.CumulativeXiaoHongShuClues,
                                                              XiaoHongShuCluesCompleteRate = d.XiaoHongShuCluesCompleteRate,
                                                              XiaoHongShuIncreaseFansTarget = d.XiaoHongShuIncreaseFansTarget,
                                                              CumulativeXiaoHongShuIncreaseFans = d.CumulativeXiaoHongShuIncreaseFans,
                                                              XiaoHongShuIncreaseFanseCompleteRate = d.XiaoHongShuIncreaseFanseCompleteRate,
                                                              XiaoHongShuIncreaseFansFeesCostTarget = d.XiaoHongShuIncreaseFansFeesCostTarget,
                                                              CumulativeXiaoHongShuIncreaseFansFeesCost = d.CumulativeXiaoHongShuIncreaseFansFeesCost,
                                                              XiaoHongShuIncreaseFansFeesCostCompleteRate = d.XiaoHongShuIncreaseFansFeesCostCompleteRate,
                                                              XiaoHongShuIncreaseFansFeesTarget = d.XiaoHongShuIncreaseFansFeesTarget,
                                                              CumulativeXiaoHongShuIncreaseFansFees = d.CumulativeXiaoHongShuIncreaseFansFees,
                                                              XiaoHongShuIncreaseFansFeesCompleteRate = d.XiaoHongShuIncreaseFansFeesCompleteRate,
                                                              VideoShowcaseIncomeTarget = d.VideoShowcaseIncomeTarget,
                                                              CumulativeVideoShowcaseIncome = d.CumulativeVideoShowcaseIncome,
                                                              VideoShowcaseIncomeCompleteRate = d.VideoShowcaseIncomeCompleteRate,
                                                              VideoCluesTarget = d.VideoCluesTarget,
                                                              CumulativeVideoClues = d.CumulativeVideoClues,
                                                              VideoCluesCompleteRate = d.VideoCluesCompleteRate,
                                                              VideoIncreaseFansTarget = d.VideoIncreaseFansTarget,
                                                              CumulativeVideoIncreaseFans = d.CumulativeVideoIncreaseFans,
                                                              VideoIncreaseFanseCompleteRate = d.VideoIncreaseFanseCompleteRate,
                                                              VideoIncreaseFansFeesCostTarget = d.VideoIncreaseFansFeesCostTarget,
                                                              CumulativeVideoIncreaseFansFeesCost = d.CumulativeVideoIncreaseFansFeesCost,
                                                              VideoIncreaseFansFeesCostCompleteRate = d.VideoIncreaseFansFeesCostCompleteRate,
                                                              VideoIncreaseFansFeesTarget = d.VideoIncreaseFansFeesTarget,
                                                              CumulativeVideoIncreaseFansFees = d.CumulativeVideoIncreaseFansFees,
                                                              VideoIncreaseFansFeesCompleteRate = d.VideoIncreaseFansFeesCompleteRate,
                                                              TikTokShowCaseFeeTarget = d.TikTokShowCaseFeeTarget,
                                                              CumulativeTikTokShowCaseFee=d.CumulativeTikTokShowCaseFee,
                                                              TikTokShowCaseFeeCompleteRate=d.TikTokShowCaseFeeCompleteRate,
                                                              XiaoHongShuShowCaseFeeTarget = d.XiaoHongShuShowCaseFeeTarget,
                                                              CumulativeXiaoHongShuShowCaseFee = d.CumulativeXiaoHongShuShowCaseFee,
                                                              XiaoHongShuShowCaseFeeCompleteRate = d.XiaoHongShuShowCaseFeeCompleteRate,
                                                              VideoShowCaseFeeTarget = d.VideoShowCaseFeeTarget,
                                                              CumulativeVideoShowCaseFee = d.CumulativeVideoShowCaseFee,
                                                              VideoShowCaseFeeCompleteRate = d.VideoShowCaseFeeCompleteRate,
                                                          };

                FxPageInfo<LiveAnchorMonthlyTargetBeforeLivingVo> liveAnchorMonthlyTargetBeforeLivingPageInfo = new FxPageInfo<LiveAnchorMonthlyTargetBeforeLivingVo>();
                liveAnchorMonthlyTargetBeforeLivingPageInfo.TotalCount = q.TotalCount;
                liveAnchorMonthlyTargetBeforeLivingPageInfo.List = liveAnchorMonthlyTargetBeforeLiving;

                return ResultData<FxPageInfo<LiveAnchorMonthlyTargetBeforeLivingVo>>.Success().AddData("liveAnchorMonthlyTargetBeforeLivingInfo", liveAnchorMonthlyTargetBeforeLivingPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<LiveAnchorMonthlyTargetBeforeLivingVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据年月获取id和名称（下拉框使用）
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns></returns>
        [HttpGet("getLiveAnchorMonthlyTargetBeforeLiving")]
        public async Task<ResultData<List<LiveAnchorMonthlyTargetKeyAndValueVo>>> getExpressList(int year, int month)
        {
            try
            {
                if (year == 0 || month == 0)
                {
                    throw new Exception("请选择年月后再进行月目标选取！");
                }
                var q = await _liveAnchorMonthlyTargetBeforeLivingService.GetIdAndNames(year, month);

                var liveAnchorMonthlyTargetBeforeLiving = from d in q
                                                          select new LiveAnchorMonthlyTargetKeyAndValueVo
                                                          {
                                                              Id = d.Id,
                                                              Name = d.Name
                                                          };

                return ResultData<List<LiveAnchorMonthlyTargetKeyAndValueVo>>.Success().AddData("liveAnchorMonthlyTargetBeforeLiving", liveAnchorMonthlyTargetBeforeLiving.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<LiveAnchorMonthlyTargetKeyAndValueVo>>.Fail().AddData("liveAnchorMonthlyTargetBeforeLiving", new List<LiveAnchorMonthlyTargetKeyAndValueVo>());
            }
        }


        /// <summary>
        /// 添加直播前主播月度运营目标情况
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddLiveAnchorMonthlyTargetBeforeLivingVo addVo)
        {
            try
            {
                AddLiveAnchorMonthlyTargetBeforeLivingDto addDto = new AddLiveAnchorMonthlyTargetBeforeLivingDto();
                addDto.Year = addVo.Year;
                addDto.Month = addVo.Month;
                addDto.MonthlyTargetName = addVo.MonthlyTargetName;
                addDto.LiveAnchorId = addVo.LiveAnchorId;

                addDto.ZhihuReleaseTarget = addVo.ZhihuReleaseTarget;
                addDto.ZhihuFlowinvestmentTarget = addVo.ZhihuFlowinvestmentTarget;
                addDto.VideoReleaseTarget = addVo.VideoReleaseTarget;
                addDto.VideoFlowinvestmentTarget = addVo.VideoFlowinvestmentTarget;
                addDto.VideoShowcaseIncomeTarget = addVo.VideoShowcaseIncomeTarget;
                addDto.VideoCluesTarget = addVo.VideoCluesTarget;
                addDto.VideoIncreaseFansTarget = addVo.VideoIncreaseFansTarget;
                addDto.VideoIncreaseFansFeesTarget = addVo.VideoIncreaseFansFeesTarget;              
                addDto.VideoShowCaseFeeTarget = addVo.VideoShowCaseFeeTarget;
                addDto.TikTokReleaseTarget = addVo.TikTokReleaseTarget;
                addDto.TikTokFlowinvestmentTarget = addVo.TikTokFlowinvestmentTarget;
                addDto.TikTokShowcaseIncomeTarget = addVo.TikTokShowcaseIncomeTarget;
                addDto.TikTokCluesTarget = addVo.TikTokCluesTarget;
                addDto.TikTokIncreaseFansTarget = addVo.TikTokIncreaseFansTarget;
                addDto.TikTokIncreaseFansFeesTarget = addVo.TikTokIncreaseFansFeesTarget;              
                addDto.TikTokShowCaseFeeTarget = addVo.TikTokShowCaseFeeTarget;
                addDto.XiaoHongShuReleaseTarget = addVo.XiaoHongShuReleaseTarget;
                addDto.XiaoHongShuFlowinvestmentTarget = addVo.XiaoHongShuFlowinvestmentTarget;
                addDto.XiaoHongShuShowcaseIncomeTarget = addVo.XiaoHongShuShowcaseIncomeTarget;
                addDto.XiaoHongShuCluesTarget = addVo.XiaoHongShuCluesTarget;
                addDto.XiaoHongShuIncreaseFansTarget = addVo.XiaoHongShuIncreaseFansTarget;
                addDto.XiaoHongShuIncreaseFansFeesTarget = addVo.XiaoHongShuIncreaseFansFeesTarget;               
                addDto.XiaoHongShuShowCaseFeeTarget = addVo.XiaoHongShuShowCaseFeeTarget;
                addDto.SinaWeiBoReleaseTarget = addVo.SinaWeiBoReleaseTarget;
                addDto.SinaWeiBoFlowinvestmentTarget = addVo.SinaWeiBoFlowinvestmentTarget;
                addDto.ReleaseTarget = addVo.ReleaseTarget;
                addDto.FlowInvestmentTarget = addVo.FlowInvestmentTarget;               
                await _liveAnchorMonthlyTargetBeforeLivingService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据id获取直播前主播月度运营目标情况
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<LiveAnchorMonthlyTargetBeforeLivingVo>> GetByIdAsync(string id)
        {
            try
            {
                var liveAnchorMonthlyTargetBeforeLiving = await _liveAnchorMonthlyTargetBeforeLivingService.GetByIdAsync(id);
                LiveAnchorMonthlyTargetBeforeLivingVo liveAnchorMonthlyTargetBeforeLivingVo = new LiveAnchorMonthlyTargetBeforeLivingVo();
                liveAnchorMonthlyTargetBeforeLivingVo.Id = liveAnchorMonthlyTargetBeforeLiving.Id;
                liveAnchorMonthlyTargetBeforeLivingVo.Year = liveAnchorMonthlyTargetBeforeLiving.Year;
                liveAnchorMonthlyTargetBeforeLivingVo.Month = liveAnchorMonthlyTargetBeforeLiving.Month;
                liveAnchorMonthlyTargetBeforeLivingVo.MonthlyTargetName = liveAnchorMonthlyTargetBeforeLiving.MonthlyTargetName;
                liveAnchorMonthlyTargetBeforeLivingVo.LiveAnchorId = liveAnchorMonthlyTargetBeforeLiving.LiveAnchorId;
                liveAnchorMonthlyTargetBeforeLivingVo.ContentPlatFormId = liveAnchorMonthlyTargetBeforeLiving.ContentPlatFormId;

                liveAnchorMonthlyTargetBeforeLivingVo.TikTokReleaseTarget = liveAnchorMonthlyTargetBeforeLiving.TikTokReleaseTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeTikTokRelease = liveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokRelease;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokReleaseCompleteRate = liveAnchorMonthlyTargetBeforeLiving.TikTokReleaseCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokFlowinvestmentTarget = liveAnchorMonthlyTargetBeforeLiving.TikTokFlowinvestmentTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeTikTokFlowinvestment = liveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokFlowinvestment;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokFlowinvestmentCompleteRate = liveAnchorMonthlyTargetBeforeLiving.TikTokFlowinvestmentCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokShowcaseIncomeTarget = liveAnchorMonthlyTargetBeforeLiving.TikTokShowcaseIncomeTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeTikTokShowcaseIncome = liveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokShowcaseIncome;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokShowcaseIncomeCompleteRate = liveAnchorMonthlyTargetBeforeLiving.TikTokShowcaseIncomeCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokCluesTarget = liveAnchorMonthlyTargetBeforeLiving.TikTokCluesTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeTikTokClues = liveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokClues;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokCluesCompleteRate = liveAnchorMonthlyTargetBeforeLiving.TikTokCluesCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokIncreaseFansTarget = liveAnchorMonthlyTargetBeforeLiving.TikTokIncreaseFansTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeTikTokIncreaseFans = liveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokIncreaseFans;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokIncreaseFanseCompleteRate = liveAnchorMonthlyTargetBeforeLiving.TikTokIncreaseFanseCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokIncreaseFansFeesCostTarget = liveAnchorMonthlyTargetBeforeLiving.TikTokIncreaseFansFeesCostTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeTikTokIncreaseFansFeesCost = liveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokIncreaseFansFeesCost;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokIncreaseFansFeesCostCompleteRate = liveAnchorMonthlyTargetBeforeLiving.TikTokIncreaseFansFeesCostCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokIncreaseFansFeesTarget = liveAnchorMonthlyTargetBeforeLiving.TikTokIncreaseFansFeesTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeTikTokIncreaseFansFees = liveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokIncreaseFansFees;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokIncreaseFansFeesCompleteRate = liveAnchorMonthlyTargetBeforeLiving.TikTokIncreaseFansFeesCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokShowCaseFeeTarget = liveAnchorMonthlyTargetBeforeLiving.TikTokShowCaseFeeTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeTikTokShowCaseFee = liveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokShowCaseFee;
                liveAnchorMonthlyTargetBeforeLivingVo.TikTokShowCaseFeeCompleteRate = liveAnchorMonthlyTargetBeforeLiving.TikTokShowCaseFeeCompleteRate;

                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuReleaseTarget = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuReleaseTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeXiaoHongShuRelease = liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuRelease;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuReleaseCompleteRate = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuReleaseCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuFlowinvestmentTarget = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuFlowinvestmentTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeXiaoHongShuFlowinvestment = liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuFlowinvestment;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuFlowinvestmentCompleteRate = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuFlowinvestmentCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuShowcaseIncomeTarget = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuShowcaseIncomeTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeXiaoHongShuShowcaseIncome = liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuShowcaseIncome;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuShowcaseIncomeCompleteRate = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuShowcaseIncomeCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuCluesTarget = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuCluesTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeXiaoHongShuClues = liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuClues;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuCluesCompleteRate = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuCluesCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuIncreaseFansTarget = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuIncreaseFansTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeXiaoHongShuIncreaseFans = liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuIncreaseFans;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuIncreaseFanseCompleteRate = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuIncreaseFanseCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuIncreaseFansFeesCostTarget = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuIncreaseFansFeesCostTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeXiaoHongShuIncreaseFansFeesCost = liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuIncreaseFansFeesCost;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuIncreaseFansFeesCostCompleteRate = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuIncreaseFansFeesCostCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuIncreaseFansFeesTarget = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuIncreaseFansFeesTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeXiaoHongShuIncreaseFansFees = liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuIncreaseFansFees;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuIncreaseFansFeesCompleteRate = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuIncreaseFansFeesCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuShowCaseFeeTarget = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuShowCaseFeeTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeXiaoHongShuShowCaseFee = liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuShowCaseFee;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuShowCaseFeeCompleteRate = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuShowCaseFeeCompleteRate;

                liveAnchorMonthlyTargetBeforeLivingVo.SinaWeiBoReleaseTarget = liveAnchorMonthlyTargetBeforeLiving.SinaWeiBoReleaseTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeSinaWeiBoRelease = liveAnchorMonthlyTargetBeforeLiving.CumulativeSinaWeiBoRelease;
                liveAnchorMonthlyTargetBeforeLivingVo.SinaWeiBoReleaseCompleteRate = liveAnchorMonthlyTargetBeforeLiving.SinaWeiBoReleaseCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.SinaWeiBoFlowinvestmentTarget = liveAnchorMonthlyTargetBeforeLiving.SinaWeiBoFlowinvestmentTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeSinaWeiBoFlowinvestment = liveAnchorMonthlyTargetBeforeLiving.CumulativeSinaWeiBoFlowinvestment;
                liveAnchorMonthlyTargetBeforeLivingVo.SinaWeiBoFlowinvestmentCompleteRate = liveAnchorMonthlyTargetBeforeLiving.SinaWeiBoFlowinvestmentCompleteRate;

                liveAnchorMonthlyTargetBeforeLivingVo.ZhihuReleaseTarget = liveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeZhihuRelease = liveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuRelease;
                liveAnchorMonthlyTargetBeforeLivingVo.ZhihuReleaseCompleteRate = liveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.ZhihuFlowinvestmentTarget = liveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeZhihuFlowinvestment = liveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuFlowinvestment;
                liveAnchorMonthlyTargetBeforeLivingVo.ZhihuFlowinvestmentCompleteRate = liveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentCompleteRate;

                liveAnchorMonthlyTargetBeforeLivingVo.VideoReleaseTarget = liveAnchorMonthlyTargetBeforeLiving.VideoReleaseTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeVideoRelease = liveAnchorMonthlyTargetBeforeLiving.CumulativeVideoRelease;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoReleaseCompleteRate = liveAnchorMonthlyTargetBeforeLiving.VideoReleaseCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoFlowinvestmentTarget = liveAnchorMonthlyTargetBeforeLiving.VideoFlowinvestmentTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeVideoFlowinvestment = liveAnchorMonthlyTargetBeforeLiving.CumulativeVideoFlowinvestment;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoFlowinvestmentCompleteRate = liveAnchorMonthlyTargetBeforeLiving.VideoFlowinvestmentCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoShowcaseIncomeTarget = liveAnchorMonthlyTargetBeforeLiving.VideoShowcaseIncomeTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeVideoShowcaseIncome = liveAnchorMonthlyTargetBeforeLiving.CumulativeVideoShowcaseIncome;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoShowcaseIncomeCompleteRate = liveAnchorMonthlyTargetBeforeLiving.VideoShowcaseIncomeCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoCluesTarget = liveAnchorMonthlyTargetBeforeLiving.VideoCluesTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeVideoClues = liveAnchorMonthlyTargetBeforeLiving.CumulativeVideoClues;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoCluesCompleteRate = liveAnchorMonthlyTargetBeforeLiving.VideoCluesCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoIncreaseFansTarget = liveAnchorMonthlyTargetBeforeLiving.VideoIncreaseFansTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeVideoIncreaseFans = liveAnchorMonthlyTargetBeforeLiving.CumulativeVideoIncreaseFans;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoIncreaseFanseCompleteRate = liveAnchorMonthlyTargetBeforeLiving.VideoIncreaseFanseCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoIncreaseFansFeesCostTarget = liveAnchorMonthlyTargetBeforeLiving.VideoIncreaseFansFeesCostTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeVideoIncreaseFansFeesCost = liveAnchorMonthlyTargetBeforeLiving.CumulativeVideoIncreaseFansFeesCost;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoIncreaseFansFeesCostCompleteRate = liveAnchorMonthlyTargetBeforeLiving.VideoIncreaseFansFeesCostCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoIncreaseFansFeesTarget = liveAnchorMonthlyTargetBeforeLiving.VideoIncreaseFansFeesTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeVideoIncreaseFansFees = liveAnchorMonthlyTargetBeforeLiving.CumulativeVideoIncreaseFansFees;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoIncreaseFansFeesCompleteRate = liveAnchorMonthlyTargetBeforeLiving.VideoIncreaseFansFeesCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoShowCaseFeeTarget = liveAnchorMonthlyTargetBeforeLiving.VideoShowCaseFeeTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeVideoShowCaseFee = liveAnchorMonthlyTargetBeforeLiving.CumulativeVideoShowCaseFee;
                liveAnchorMonthlyTargetBeforeLivingVo.VideoShowCaseFeeCompleteRate = liveAnchorMonthlyTargetBeforeLiving.VideoShowCaseFeeCompleteRate;

                liveAnchorMonthlyTargetBeforeLivingVo.ReleaseTarget = liveAnchorMonthlyTargetBeforeLiving.ReleaseTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeRelease = liveAnchorMonthlyTargetBeforeLiving.CumulativeRelease;
                liveAnchorMonthlyTargetBeforeLivingVo.ReleaseCompleteRate = liveAnchorMonthlyTargetBeforeLiving.ReleaseCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.FlowInvestmentTarget = liveAnchorMonthlyTargetBeforeLiving.FlowInvestmentTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeFlowInvestment = liveAnchorMonthlyTargetBeforeLiving.CumulativeFlowInvestment;
                liveAnchorMonthlyTargetBeforeLivingVo.FlowInvestmentCompleteRate = liveAnchorMonthlyTargetBeforeLiving.FlowInvestmentCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.CreateDate = liveAnchorMonthlyTargetBeforeLiving.CreateDate;

                return ResultData<LiveAnchorMonthlyTargetBeforeLivingVo>.Success().AddData("liveAnchorMonthlyTargetBeforeLivingInfo", liveAnchorMonthlyTargetBeforeLivingVo);
            }
            catch (Exception ex)
            {
                return ResultData<LiveAnchorMonthlyTargetBeforeLivingVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改直播前主播月度运营目标情况
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateLiveAnchorMonthlyTargetBeforeLivingVo updateVo)
        {
            try
            {
                UpdateLiveAnchorMonthlyTargetBeforeLivingDto updateDto = new UpdateLiveAnchorMonthlyTargetBeforeLivingDto();
                updateDto.Id = updateVo.Id;
                updateDto.Year = updateVo.Year;
                updateDto.Month = updateVo.Month;
                updateDto.MonthlyTargetName = updateVo.MonthlyTargetName;
                updateDto.LiveAnchorId = updateVo.LiveAnchorId;
                updateDto.TikTokReleaseTarget = updateVo.TikTokReleaseTarget;
                updateDto.ZhihuReleaseTarget = updateVo.ZhihuReleaseTarget;
                updateDto.XiaoHongShuReleaseTarget = updateVo.XiaoHongShuReleaseTarget;
                updateDto.SinaWeiBoReleaseTarget = updateVo.SinaWeiBoReleaseTarget;
                updateDto.VideoReleaseTarget = updateVo.VideoReleaseTarget;
                updateDto.TikTokShowcaseIncomeTarget = updateVo.TikTokShowcaseIncomeTarget;
                updateDto.TikTokCluesTarget = updateVo.TikTokCluesTarget;
                updateDto.TikTokIncreaseFansTarget = updateVo.TikTokIncreaseFansTarget;
                updateDto.TikTokIncreaseFansFeesTarget = updateVo.TikTokIncreaseFansFeesTarget;               
                updateDto.TikTokFlowinvestmentTarget = updateVo.TikTokFlowinvestmentTarget;
                updateDto.ZhihuFlowinvestmentTarget = updateVo.ZhihuFlowinvestmentTarget;
                updateDto.XiaoHongShuFlowinvestmentTarget = updateVo.XiaoHongShuFlowinvestmentTarget;
                updateDto.SinaWeiBoFlowinvestmentTarget = updateVo.SinaWeiBoFlowinvestmentTarget;
                updateDto.VideoFlowinvestmentTarget = updateVo.VideoFlowinvestmentTarget;
                updateDto.ReleaseTarget = updateVo.ReleaseTarget;
                updateDto.FlowInvestmentTarget = updateVo.FlowInvestmentTarget;
                updateDto.XiaoHongShuShowcaseIncomeTarget = updateVo.XiaoHongShuShowcaseIncomeTarget;
                updateDto.XiaoHongShuCluesTarget = updateVo.XiaoHongShuCluesTarget;
                updateDto.XiaoHongShuIncreaseFansTarget = updateVo.XiaoHongShuIncreaseFansTarget;
                updateDto.XiaoHongShuIncreaseFansFeesTarget = updateVo.XiaoHongShuIncreaseFansFeesTarget;              
                updateDto.VideoShowcaseIncomeTarget = updateVo.VideoShowcaseIncomeTarget;
                updateDto.VideoCluesTarget = updateVo.VideoCluesTarget;
                updateDto.VideoIncreaseFansTarget = updateVo.VideoIncreaseFansTarget;
                updateDto.VideoIncreaseFansFeesTarget = updateVo.VideoIncreaseFansFeesTarget;               
                updateDto.VideoShowcaseFeeTarget=updateVo.VideoShowcaseFeeTarget;
                updateDto.TikTokShowcaseFeeTarget = updateVo.TikTokShowcaseFeeTarget;
                updateDto.XiaoHongShuShowcaseFeeTarget = updateVo.XiaoHongShuShowcaseFeeTarget;
                await _liveAnchorMonthlyTargetBeforeLivingService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除直播前主播月度运营目标情况
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _liveAnchorMonthlyTargetBeforeLivingService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                throw new Exception("该条数据下已产生相应的日数据，请先删除日数据后再删除该条数据！");
            }
        }

    }
}
