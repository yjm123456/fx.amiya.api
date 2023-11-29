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
                var q = await _liveAnchorMonthlyTargetBeforeLivingService.GetListWithPageAsync(year, month, liveAnchorId,employeeId ,pageNum, pageSize);

                var liveAnchorMonthlyTargetBeforeLiving = from d in q.List
                                              select new LiveAnchorMonthlyTargetBeforeLivingVo
                                              {
                                                  Id = d.Id,
                                                  Year = d.Year,
                                                  Month = d.Month,
                                                  MonthlyTargetName = d.MonthlyTargetName,
                                                  LiveAnchorId = d.LiveAnchorId,
                                                  LiveAnchorName = d.LiveAnchorName,
                                                  ContentPlatFormId=d.ContentPlatFormId,

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
                                                  TikTokShowcaseIncomeTarget=d.TikTokShowcaseIncomeTarget,
                                                  CumulativeTikTokShowcaseIncome=d.CumulativeTikTokShowcaseIncome,
                                                  TikTokShowcaseIncomeCompleteRate=d.TikTokShowcaseIncomeCompleteRate,

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
                var q = await _liveAnchorMonthlyTargetBeforeLivingService.GetIdAndNames(year,month);

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

                addDto.TikTokReleaseTarget = addVo.TikTokReleaseTarget;
                addDto.TikTokFlowinvestmentTarget = addVo.TikTokFlowinvestmentTarget;
                addDto.TikTokShowcaseIncomeTarget = addVo.TikTokShowcaseIncomeTarget;

                addDto.XiaoHongShuReleaseTarget = addVo.XiaoHongShuReleaseTarget;
                addDto.XiaoHongShuFlowinvestmentTarget = addVo.XiaoHongShuFlowinvestmentTarget;

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

                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuReleaseTarget = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuReleaseTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeXiaoHongShuRelease = liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuRelease;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuReleaseCompleteRate = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuReleaseCompleteRate;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuFlowinvestmentTarget = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuFlowinvestmentTarget;
                liveAnchorMonthlyTargetBeforeLivingVo.CumulativeXiaoHongShuFlowinvestment = liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuFlowinvestment;
                liveAnchorMonthlyTargetBeforeLivingVo.XiaoHongShuFlowinvestmentCompleteRate = liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuFlowinvestmentCompleteRate;

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
                updateDto.TikTokFlowinvestmentTarget = updateVo.TikTokFlowinvestmentTarget;
                updateDto.ZhihuFlowinvestmentTarget = updateVo.ZhihuFlowinvestmentTarget;
                updateDto.XiaoHongShuFlowinvestmentTarget = updateVo.XiaoHongShuFlowinvestmentTarget;
                updateDto.SinaWeiBoFlowinvestmentTarget = updateVo.SinaWeiBoFlowinvestmentTarget;
                updateDto.VideoFlowinvestmentTarget = updateVo.VideoFlowinvestmentTarget;

                updateDto.ReleaseTarget = updateVo.ReleaseTarget;
                updateDto.FlowInvestmentTarget = updateVo.FlowInvestmentTarget;
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
