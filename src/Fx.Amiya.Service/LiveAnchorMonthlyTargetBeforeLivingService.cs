using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
using Fx.Amiya.Dto.Performance;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using jos_sdk_net.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class LiveAnchorMonthlyTargetBeforeLivingService : ILiveAnchorMonthlyTargetBeforeLivingService
    {
        private IDalLiveAnchorMonthlyTargetBeforeLiving dalLiveAnchorMonthlyTargetBeforeLiving;
        private ILiveAnchorService _liveanchorService;
        private IAmiyaEmployeeService _amiyaEmployeeService;
        private IEmployeeBindLiveAnchorService employeeBindLiveAnchorService;

        public LiveAnchorMonthlyTargetBeforeLivingService(IDalLiveAnchorMonthlyTargetBeforeLiving dalLiveAnchorMonthlyTargetBeforeLiving,
            ILiveAnchorService liveAnchorService,
            IEmployeeBindLiveAnchorService employeeBindLiveAnchorService,
            IAmiyaEmployeeService amiyaEmployeeService)
        {
            this.dalLiveAnchorMonthlyTargetBeforeLiving = dalLiveAnchorMonthlyTargetBeforeLiving;
            _amiyaEmployeeService = amiyaEmployeeService;
            this.employeeBindLiveAnchorService = employeeBindLiveAnchorService;
            _liveanchorService = liveAnchorService;
        }



        public async Task<FxPageInfo<LiveAnchorMonthlyTargetBeforeLivingDto>> GetListWithPageAsync(int Year, int Month, int? LiveAnchorId, int employeeId, int pageNum, int pageSize)
        {
            try
            {
                List<int> liveAnchorIds = new List<int>();
                if (LiveAnchorId.HasValue)
                {
                    liveAnchorIds.Add(LiveAnchorId.Value);
                }
                else
                {
                    var empInfo = await _amiyaEmployeeService.GetByIdAsync(employeeId);
                    if (empInfo.PositionId == 19)
                    {
                        var bindLiveAnchorInfo = await employeeBindLiveAnchorService.GetByEmpIdAsync(employeeId);
                        foreach (var x in bindLiveAnchorInfo)
                        {
                            liveAnchorIds.Add(x.LiveAnchorId);
                        }
                    }
                }
                var liveAnchorMonthlyTargetBeforeLiving = from d in dalLiveAnchorMonthlyTargetBeforeLiving.GetAll().Include(e => e.LiveAnchor)
                                                          where (d.Year == Year)
                                                          && (d.Month == Month)
                                                          && (liveAnchorIds.Count == 0 || liveAnchorIds.Contains(d.LiveAnchorId))
                                                          select new LiveAnchorMonthlyTargetBeforeLivingDto
                                                          {
                                                              Id = d.Id,
                                                              Year = d.Year,
                                                              Month = d.Month,
                                                              MonthlyTargetName = d.MonthlyTargetName,
                                                              LiveAnchorId = d.LiveAnchorId,
                                                              LiveAnchorName = d.LiveAnchor.Name,
                                                              ContentPlatFormId = d.LiveAnchor.ContentPlateFormId,

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
                                                          };

                FxPageInfo<LiveAnchorMonthlyTargetBeforeLivingDto> liveAnchorMonthlyTargetBeforeLivingPageInfo = new FxPageInfo<LiveAnchorMonthlyTargetBeforeLivingDto>();
                liveAnchorMonthlyTargetBeforeLivingPageInfo.TotalCount = await liveAnchorMonthlyTargetBeforeLiving.CountAsync();
                liveAnchorMonthlyTargetBeforeLivingPageInfo.List = await liveAnchorMonthlyTargetBeforeLiving.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                return liveAnchorMonthlyTargetBeforeLivingPageInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task AddAsync(AddLiveAnchorMonthlyTargetBeforeLivingDto addDto)
        {
            try
            {
                LiveAnchorMonthlyTargetBeforeLiving liveAnchorMonthlyTarget = new LiveAnchorMonthlyTargetBeforeLiving();
                liveAnchorMonthlyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorMonthlyTarget.Year = addDto.Year;
                liveAnchorMonthlyTarget.Month = addDto.Month;
                liveAnchorMonthlyTarget.MonthlyTargetName = addDto.MonthlyTargetName;
                liveAnchorMonthlyTarget.LiveAnchorId = addDto.LiveAnchorId;

                liveAnchorMonthlyTarget.ZhihuReleaseTarget = addDto.ZhihuReleaseTarget;
                liveAnchorMonthlyTarget.CumulativeZhihuRelease = 0;
                liveAnchorMonthlyTarget.ZhihuReleaseCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.ZhihuFlowinvestmentTarget = addDto.ZhihuFlowinvestmentTarget;
                liveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment = 0;
                liveAnchorMonthlyTarget.ZhihuFlowinvestmentCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.VideoReleaseTarget = addDto.VideoReleaseTarget;
                liveAnchorMonthlyTarget.CumulativeVideoRelease = 0;
                liveAnchorMonthlyTarget.VideoReleaseCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.VideoFlowinvestmentTarget = addDto.VideoFlowinvestmentTarget;
                liveAnchorMonthlyTarget.CumulativeVideoFlowinvestment = 0;
                liveAnchorMonthlyTarget.VideoFlowinvestmentCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.TikTokReleaseTarget = addDto.TikTokReleaseTarget;
                liveAnchorMonthlyTarget.CumulativeTikTokRelease = 0;
                liveAnchorMonthlyTarget.TikTokReleaseCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.TikTokFlowinvestmentTarget = addDto.TikTokFlowinvestmentTarget;
                liveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment = 0;
                liveAnchorMonthlyTarget.TikTokFlowinvestmentCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.XiaoHongShuReleaseTarget = addDto.XiaoHongShuReleaseTarget;
                liveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease = 0;
                liveAnchorMonthlyTarget.XiaoHongShuReleaseCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentTarget = addDto.XiaoHongShuFlowinvestmentTarget;
                liveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment = 0;
                liveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentCompleteRate = 0.00M;



                liveAnchorMonthlyTarget.SinaWeiBoReleaseTarget = addDto.SinaWeiBoReleaseTarget;
                liveAnchorMonthlyTarget.CumulativeSinaWeiBoRelease = 0;
                liveAnchorMonthlyTarget.SinaWeiBoReleaseCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentTarget = addDto.SinaWeiBoFlowinvestmentTarget;
                liveAnchorMonthlyTarget.CumulativeSinaWeiBoFlowinvestment = 0;
                liveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentCompleteRate = 0.00M;


                liveAnchorMonthlyTarget.ReleaseTarget = addDto.ReleaseTarget;
                liveAnchorMonthlyTarget.CumulativeRelease = 0;
                liveAnchorMonthlyTarget.ReleaseCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.FlowInvestmentTarget = addDto.FlowInvestmentTarget;
                liveAnchorMonthlyTarget.CumulativeFlowInvestment = 0;
                liveAnchorMonthlyTarget.FlowInvestmentCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.CreateDate = DateTime.Now;

                await dalLiveAnchorMonthlyTargetBeforeLiving.AddAsync(liveAnchorMonthlyTarget, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<List<LiveAnchorMonthlyTargetKeyAndValueDto>> GetIdAndNames(int year, int month)
        {
            try
            {
                var liveAnchorMonthlyTargetBeforeLiving = from d in dalLiveAnchorMonthlyTargetBeforeLiving.GetAll()
                                                          where (d.Year == year && d.Month == month)
                                                          select new LiveAnchorMonthlyTargetKeyAndValueDto
                                                          {
                                                              Id = d.Id,
                                                              Name = d.MonthlyTargetName
                                                          };
                return liveAnchorMonthlyTargetBeforeLiving.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<LiveAnchorMonthlyTargetBeforeLivingDto> GetByIdAsync(string id)
        {
            try
            {
                var liveAnchorMonthlyTarget = await dalLiveAnchorMonthlyTargetBeforeLiving.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (liveAnchorMonthlyTarget == null)
                {
                    throw new Exception("直播前主播月度运营目标情况编号错误！");
                }

                LiveAnchorMonthlyTargetBeforeLivingDto liveAnchorMonthlyTargetDto = new LiveAnchorMonthlyTargetBeforeLivingDto();
                liveAnchorMonthlyTargetDto.Id = liveAnchorMonthlyTarget.Id;
                liveAnchorMonthlyTargetDto.Year = liveAnchorMonthlyTarget.Year;
                liveAnchorMonthlyTargetDto.Month = liveAnchorMonthlyTarget.Month;
                liveAnchorMonthlyTargetDto.MonthlyTargetName = liveAnchorMonthlyTarget.MonthlyTargetName;
                liveAnchorMonthlyTargetDto.LiveAnchorId = liveAnchorMonthlyTarget.LiveAnchorId;

                liveAnchorMonthlyTargetDto.TikTokReleaseTarget = liveAnchorMonthlyTarget.TikTokReleaseTarget;
                liveAnchorMonthlyTargetDto.CumulativeTikTokRelease = liveAnchorMonthlyTarget.CumulativeTikTokRelease;
                liveAnchorMonthlyTargetDto.TikTokReleaseCompleteRate = liveAnchorMonthlyTarget.TikTokReleaseCompleteRate;
                liveAnchorMonthlyTargetDto.TikTokFlowinvestmentTarget = liveAnchorMonthlyTarget.TikTokFlowinvestmentTarget;
                liveAnchorMonthlyTargetDto.CumulativeTikTokFlowinvestment = liveAnchorMonthlyTarget.CumulativeTikTokFlowinvestment;
                liveAnchorMonthlyTargetDto.TikTokFlowinvestmentCompleteRate = liveAnchorMonthlyTarget.TikTokFlowinvestmentCompleteRate;

                liveAnchorMonthlyTargetDto.XiaoHongShuReleaseTarget = liveAnchorMonthlyTarget.XiaoHongShuReleaseTarget;
                liveAnchorMonthlyTargetDto.CumulativeXiaoHongShuRelease = liveAnchorMonthlyTarget.CumulativeXiaoHongShuRelease;
                liveAnchorMonthlyTargetDto.XiaoHongShuReleaseCompleteRate = liveAnchorMonthlyTarget.XiaoHongShuReleaseCompleteRate;
                liveAnchorMonthlyTargetDto.XiaoHongShuFlowinvestmentTarget = liveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentTarget;
                liveAnchorMonthlyTargetDto.CumulativeXiaoHongShuFlowinvestment = liveAnchorMonthlyTarget.CumulativeXiaoHongShuFlowinvestment;
                liveAnchorMonthlyTargetDto.XiaoHongShuFlowinvestmentCompleteRate = liveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentCompleteRate;

                liveAnchorMonthlyTargetDto.SinaWeiBoReleaseTarget = liveAnchorMonthlyTarget.SinaWeiBoReleaseTarget;
                liveAnchorMonthlyTargetDto.CumulativeSinaWeiBoRelease = liveAnchorMonthlyTarget.CumulativeSinaWeiBoRelease;
                liveAnchorMonthlyTargetDto.SinaWeiBoReleaseCompleteRate = liveAnchorMonthlyTarget.SinaWeiBoReleaseCompleteRate;
                liveAnchorMonthlyTargetDto.SinaWeiBoFlowinvestmentTarget = liveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentTarget;
                liveAnchorMonthlyTargetDto.CumulativeSinaWeiBoFlowinvestment = liveAnchorMonthlyTarget.CumulativeSinaWeiBoFlowinvestment;
                liveAnchorMonthlyTargetDto.SinaWeiBoFlowinvestmentCompleteRate = liveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentCompleteRate;

                liveAnchorMonthlyTargetDto.ZhihuReleaseTarget = liveAnchorMonthlyTarget.ZhihuReleaseTarget;
                liveAnchorMonthlyTargetDto.CumulativeZhihuRelease = liveAnchorMonthlyTarget.CumulativeZhihuRelease;
                liveAnchorMonthlyTargetDto.ZhihuReleaseCompleteRate = liveAnchorMonthlyTarget.ZhihuReleaseCompleteRate;
                liveAnchorMonthlyTargetDto.ZhihuFlowinvestmentTarget = liveAnchorMonthlyTarget.ZhihuFlowinvestmentTarget;
                liveAnchorMonthlyTargetDto.CumulativeZhihuFlowinvestment = liveAnchorMonthlyTarget.CumulativeZhihuFlowinvestment;
                liveAnchorMonthlyTargetDto.ZhihuFlowinvestmentCompleteRate = liveAnchorMonthlyTarget.ZhihuFlowinvestmentCompleteRate;

                liveAnchorMonthlyTargetDto.VideoReleaseTarget = liveAnchorMonthlyTarget.VideoReleaseTarget;
                liveAnchorMonthlyTargetDto.CumulativeVideoRelease = liveAnchorMonthlyTarget.CumulativeVideoRelease;
                liveAnchorMonthlyTargetDto.VideoReleaseCompleteRate = liveAnchorMonthlyTarget.VideoReleaseCompleteRate;
                liveAnchorMonthlyTargetDto.VideoFlowinvestmentTarget = liveAnchorMonthlyTarget.VideoFlowinvestmentTarget;
                liveAnchorMonthlyTargetDto.CumulativeVideoFlowinvestment = liveAnchorMonthlyTarget.CumulativeVideoFlowinvestment;
                liveAnchorMonthlyTargetDto.VideoFlowinvestmentCompleteRate = liveAnchorMonthlyTarget.VideoFlowinvestmentCompleteRate;

                liveAnchorMonthlyTargetDto.ReleaseTarget = liveAnchorMonthlyTarget.ReleaseTarget;
                liveAnchorMonthlyTargetDto.CumulativeRelease = liveAnchorMonthlyTarget.CumulativeRelease;
                liveAnchorMonthlyTargetDto.ReleaseCompleteRate = liveAnchorMonthlyTarget.ReleaseCompleteRate;
                liveAnchorMonthlyTargetDto.FlowInvestmentTarget = liveAnchorMonthlyTarget.FlowInvestmentTarget;
                liveAnchorMonthlyTargetDto.CumulativeFlowInvestment = liveAnchorMonthlyTarget.CumulativeFlowInvestment;
                liveAnchorMonthlyTargetDto.FlowInvestmentCompleteRate = liveAnchorMonthlyTarget.FlowInvestmentCompleteRate;
                liveAnchorMonthlyTargetDto.CreateDate = liveAnchorMonthlyTarget.CreateDate;
                var liveAnchor = await _liveanchorService.GetByIdAsync(liveAnchorMonthlyTargetDto.LiveAnchorId);
                liveAnchorMonthlyTargetDto.ContentPlatFormId = liveAnchor.ContentPlateFormId;
                return liveAnchorMonthlyTargetDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task UpdateAsync(UpdateLiveAnchorMonthlyTargetBeforeLivingDto updateDto)
        {
            try
            {
                var liveAnchorMonthlyTarget = await dalLiveAnchorMonthlyTargetBeforeLiving.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (liveAnchorMonthlyTarget == null)
                    throw new Exception("直播前主播月度运营目标情况编号错误！");

                liveAnchorMonthlyTarget.Year = updateDto.Year;
                liveAnchorMonthlyTarget.Month = updateDto.Month;
                liveAnchorMonthlyTarget.MonthlyTargetName = updateDto.MonthlyTargetName;
                liveAnchorMonthlyTarget.LiveAnchorId = updateDto.LiveAnchorId;

                liveAnchorMonthlyTarget.TikTokReleaseTarget = updateDto.TikTokReleaseTarget;
                liveAnchorMonthlyTarget.ZhihuReleaseTarget = updateDto.ZhihuReleaseTarget;
                liveAnchorMonthlyTarget.XiaoHongShuReleaseTarget = updateDto.XiaoHongShuReleaseTarget;
                liveAnchorMonthlyTarget.SinaWeiBoReleaseTarget = updateDto.SinaWeiBoReleaseTarget;
                liveAnchorMonthlyTarget.VideoReleaseTarget = updateDto.VideoReleaseTarget;


                liveAnchorMonthlyTarget.TikTokFlowinvestmentTarget = updateDto.TikTokFlowinvestmentTarget;
                liveAnchorMonthlyTarget.ZhihuFlowinvestmentTarget = updateDto.ZhihuFlowinvestmentTarget;
                liveAnchorMonthlyTarget.XiaoHongShuFlowinvestmentTarget = updateDto.XiaoHongShuFlowinvestmentTarget;
                liveAnchorMonthlyTarget.SinaWeiBoFlowinvestmentTarget = updateDto.SinaWeiBoFlowinvestmentTarget;
                liveAnchorMonthlyTarget.VideoFlowinvestmentTarget = updateDto.VideoFlowinvestmentTarget;

                liveAnchorMonthlyTarget.ReleaseTarget = updateDto.ReleaseTarget;
                liveAnchorMonthlyTarget.FlowInvestmentTarget = updateDto.FlowInvestmentTarget;
                await dalLiveAnchorMonthlyTargetBeforeLiving.UpdateAsync(liveAnchorMonthlyTarget, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 更新每日数据时调用并且添加累计信息
        /// </summary>
        /// <param name="editDto"></param>
        /// <returns></returns>
        public async Task EditAsync(UpdateLiveAnchorMonthlyBeforeLivingTargetRateAndNumDto editDto)
        {
            try
            {
                var liveAnchorMonthlyTargetBeforeLiving = await dalLiveAnchorMonthlyTargetBeforeLiving.GetAll().SingleOrDefaultAsync(e => e.Id == editDto.Id);
                if (liveAnchorMonthlyTargetBeforeLiving == null)
                    throw new Exception("直播前主播月度运营目标情况编号错误！");

                #region #知乎发布
                liveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuRelease += editDto.CumulativeZhihuRelease;
                if (liveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuRelease <= 0)
                {
                    liveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuRelease) / Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.ZhihuReleaseTarget)) * 100, 2);
                }
                #endregion
                #region #知乎投流
                liveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuFlowinvestment += editDto.CumulativeZhihuFlowinvestment;
                if (liveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuFlowinvestment <= 0)
                {
                    liveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.CumulativeZhihuFlowinvestment) / Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.ZhihuFlowinvestmentTarget)) * 100, 2);
                }
                #endregion

                #region #视频号发布
                liveAnchorMonthlyTargetBeforeLiving.CumulativeVideoRelease += editDto.CumulativeVideoRelease;
                if (liveAnchorMonthlyTargetBeforeLiving.CumulativeVideoRelease <= 0)
                {
                    liveAnchorMonthlyTargetBeforeLiving.VideoReleaseCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTargetBeforeLiving.VideoReleaseCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.CumulativeVideoRelease) / Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.VideoReleaseTarget)) * 100, 2);
                }
                #endregion
                #region #视频号投流
                liveAnchorMonthlyTargetBeforeLiving.CumulativeVideoFlowinvestment += editDto.CumulativeVideoFlowinvestment;
                if (liveAnchorMonthlyTargetBeforeLiving.CumulativeVideoFlowinvestment <= 0)
                {
                    liveAnchorMonthlyTargetBeforeLiving.VideoFlowinvestmentCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTargetBeforeLiving.VideoFlowinvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.CumulativeVideoFlowinvestment) / Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.VideoFlowinvestmentTarget)) * 100, 2);
                }
                #endregion

                #region #抖音发布
                liveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokRelease += editDto.CumulativeTikTokRelease;
                if (liveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokRelease <= 0)
                {
                    liveAnchorMonthlyTargetBeforeLiving.TikTokReleaseCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTargetBeforeLiving.TikTokReleaseCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokRelease) / Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.TikTokReleaseTarget)) * 100, 2);
                }
                #endregion
                #region #抖音投流
                liveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokFlowinvestment += editDto.CumulativeTikTokFlowinvestment;
                if (liveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokFlowinvestment <= 0)
                {
                    liveAnchorMonthlyTargetBeforeLiving.TikTokFlowinvestmentCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTargetBeforeLiving.TikTokFlowinvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.CumulativeTikTokFlowinvestment) / Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.TikTokFlowinvestmentTarget)) * 100, 2);
                }
                #endregion

                #region #小红书发布
                liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuRelease += editDto.CumulativeXiaoHongShuRelease;
                if (liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuRelease <= 0)
                {
                    liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuReleaseCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuReleaseCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuRelease) / Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuReleaseTarget)) * 100, 2);
                }
                #endregion
                #region #小红书投流
                liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuFlowinvestment += editDto.CumulativeXiaoHongShuFlowinvestment;
                if (liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuFlowinvestment <= 0)
                {
                    liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuFlowinvestmentCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuFlowinvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.CumulativeXiaoHongShuFlowinvestment) / Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.XiaoHongShuFlowinvestmentTarget)) * 100, 2);
                }
                #endregion

                #region #微博发布
                liveAnchorMonthlyTargetBeforeLiving.CumulativeSinaWeiBoRelease += editDto.CumulativeSinaWeiBoRelease;
                if (liveAnchorMonthlyTargetBeforeLiving.CumulativeSinaWeiBoRelease <= 0)
                {
                    liveAnchorMonthlyTargetBeforeLiving.SinaWeiBoReleaseCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTargetBeforeLiving.SinaWeiBoReleaseCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.CumulativeSinaWeiBoRelease) / Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.SinaWeiBoReleaseTarget)) * 100, 2);
                }
                #endregion
                #region #微博投流
                liveAnchorMonthlyTargetBeforeLiving.CumulativeSinaWeiBoFlowinvestment += editDto.CumulativeSinaWeiBoFlowinvestment;
                if (liveAnchorMonthlyTargetBeforeLiving.CumulativeSinaWeiBoFlowinvestment <= 0)
                {
                    liveAnchorMonthlyTargetBeforeLiving.SinaWeiBoFlowinvestmentCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTargetBeforeLiving.SinaWeiBoFlowinvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.CumulativeSinaWeiBoFlowinvestment) / Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.SinaWeiBoFlowinvestmentTarget)) * 100, 2);
                }
                #endregion

                #region #发布
                liveAnchorMonthlyTargetBeforeLiving.CumulativeRelease += editDto.CumulativeRelease;
                if (liveAnchorMonthlyTargetBeforeLiving.CumulativeRelease <= 0)
                {
                    liveAnchorMonthlyTargetBeforeLiving.ReleaseCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTargetBeforeLiving.ReleaseCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.CumulativeRelease) / Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.ReleaseTarget)) * 100, 2);
                }
                #endregion

                #region #运营渠道投流
                liveAnchorMonthlyTargetBeforeLiving.CumulativeFlowInvestment += editDto.CumulativeFlowInvestment;
                if (liveAnchorMonthlyTargetBeforeLiving.CumulativeFlowInvestment <= 0)
                {
                    liveAnchorMonthlyTargetBeforeLiving.FlowInvestmentCompleteRate = 0.00M;
                }
                else
                {

                    liveAnchorMonthlyTargetBeforeLiving.FlowInvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.CumulativeFlowInvestment) / Convert.ToDecimal(liveAnchorMonthlyTargetBeforeLiving.FlowInvestmentTarget)) * 100, 2);
                }
                #endregion


                await dalLiveAnchorMonthlyTargetBeforeLiving.UpdateAsync(liveAnchorMonthlyTargetBeforeLiving, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var liveAnchorMonthlyTargetBeforeLiving = await dalLiveAnchorMonthlyTargetBeforeLiving.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (liveAnchorMonthlyTargetBeforeLiving == null)
                    throw new Exception("直播前主播月度运营目标情况编号错误");

                await dalLiveAnchorMonthlyTargetBeforeLiving.DeleteAsync(liveAnchorMonthlyTargetBeforeLiving, true);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        ///// <summary>
        ///// 获取带货业绩
        ///// </summary>
        ///// <param name="year"></param>
        ///// <param name="month"></param>
        ///// <param name="liveAnchorIds"></param>
        ///// <returns></returns>
        //public async Task<List<PerformanceInfoByDateDto>> GetLiveAnchorCommercePerformance(int year, int month, List<int> liveAnchorIds)
        //{
        //    var list = dalLiveAnchorMonthlyTargetBeforeLiving.GetAll()
        //        .Where(o => o.Year == year && o.Month >= 1 && o.Month <= month)
        //        .Where(o => liveAnchorIds.Count == 0 || liveAnchorIds.Contains(o.LiveAnchorId))
        //        .GroupBy(o => o.Month).OrderBy(o => o.Key).Select(o => new PerformanceInfoByDateDto
        //        {
        //            Date = o.Key.ToString(),
        //            PerfomancePrice = o.Sum(o => o.CumulativeCargoSettlementCommission)
        //        }).ToList();
        //    return list;
        //}

        ///// <summary>
        ///// 获取业绩目标
        ///// </summary>
        ///// <param name="year"></param>
        ///// <param name="month"></param>
        ///// <param name="liveAnchorIds">各个平台的主播ID集合</param>
        ///// <returns></returns>
        //public async Task<LiveAnchorMonthTargetBeforeLivingPerformanceDto> GetPerformance(int year, int month, List<int> liveAnchorIds)
        //{
        //    var performance = dalLiveAnchorMonthlyTargetBeforeLiving.GetAll().Where(t => t.Year == year && t.Month == month)
        //        .Where(o => liveAnchorIds.Count == 0 || liveAnchorIds.Contains(o.LiveAnchorId));
        //    LiveAnchorMonthTargetBeforeLivingPerformanceDto performanceInfoDto = new LiveAnchorMonthTargetBeforeLivingPerformanceDto
        //    {
        //        TotalPerformanceTargetBeforeLiving = await performance.SumAsync(t => t.PerformanceTargetBeforeLiving),
        //        CommercePerformanceTargetBeforeLiving = await performance.SumAsync(t => t.CargoSettlementCommissionTargetBeforeLiving),
        //        OldCustomerPerformanceTargetBeforeLiving = await performance.SumAsync(t => t.OldCustomerPerformanceTargetBeforeLiving),
        //        NewCustomerPerformanceTargetBeforeLiving = await performance.SumAsync(t => t.NewCustomerPerformanceTargetBeforeLiving),
        //        CommerceCompletePerformance = await performance.SumAsync(t => t.CumulativeCargoSettlementCommission),

        //    };
        //    return performanceInfoDto;
        //}


        ///// <summary>
        ///// 根据平台id按年月获取数据
        ///// </summary>
        ///// <param name="year"></param>
        ///// <param name="month"></param>
        ///// <param name="contentPlatFormId">内容平台id</param>
        ///// <returns></returns>
        //public async Task<GroupPerformanceListDto> GetCooperationLiveAnchorPerformance(int year, int month, string contentPlatFormId)
        //{
        //    var performance = dalLiveAnchorMonthlyTargetBeforeLiving.GetAll().Include(x => x.LiveAnchor).Where(t => t.Year == year && t.Month == month && t.LiveAnchor.ContentPlateFormId == contentPlatFormId);
        //    GroupPerformanceListDto performanceInfoDto = new GroupPerformanceListDto
        //    {
        //        GroupPerformance = await performance.SumAsync(t => t.CumulativePerformance),
        //        GroupTargetBeforeLivingPerformance = await performance.SumAsync(t => t.PerformanceTargetBeforeLiving),
        //    };
        //    return performanceInfoDto;
        //}

        ///// <summary>
        ///// 根据主播基础id按年月获取数据
        ///// </summary>
        ///// <param name="year"></param>
        ///// <param name="month"></param>
        ///// <param name="contentPlatFormId">内容平台id</param>
        ///// <returns></returns>
        //public async Task<GroupPerformanceListDto> GetLiveAnchorBaseIdPerformance(int year, int month, string liveAnchorBaseId)
        //{
        //    var performance = dalLiveAnchorMonthlyTargetBeforeLiving.GetAll().Include(x => x.LiveAnchor).Where(t => t.Year == year && t.Month == month && t.LiveAnchor.LiveAnchorBaseId == liveAnchorBaseId);
        //    GroupPerformanceListDto performanceInfoDto = new GroupPerformanceListDto
        //    {
        //        GroupPerformance = await performance.SumAsync(t => t.CumulativePerformance),
        //        GroupTargetBeforeLivingPerformance = await performance.SumAsync(t => t.PerformanceTargetBeforeLiving),
        //    };
        //    return performanceInfoDto;
        //}



        ///// <summary>
        ///// 根据主播基础id按年月获取折线图
        ///// </summary>
        ///// <param name="year"></param>
        ///// <param name="month"></param>
        ///// <param name="contentPlatFormId">内容平台id</param>
        ///// <returns></returns>
        //public async Task<List<PerformanceBrokenLine>> GetLiveAnchorPerformanceByBaseIdBrokenLineAsync(int year, string liveAnchorBaseId)
        //{
        //    var orderinfo = await dalLiveAnchorMonthlyTargetBeforeLiving.GetAll().Include(x => x.LiveAnchor).Where(o => o.Year == year && o.LiveAnchor.LiveAnchorBaseId == liveAnchorBaseId).ToListAsync();

        //    return orderinfo.GroupBy(x => x.Month).Select(x => new PerformanceBrokenLine { Date = x.Key.ToString(), PerfomancePrice = x.Sum(z => z.CumulativePerformance) }).ToList();
        //}


        ///// <summary>
        ///// 基础经营看板业绩
        ///// </summary>
        ///// <param name="year"></param>
        ///// <param name="month"></param>
        ///// <param name="liveAnchorIds">各个平台的主播ID集合</param>
        ///// <returns></returns>
        //public async Task<LiveAnchorBaseBusinessMonthTargetBeforeLivingPerformanceDto> GetBasePerformanceTargetBeforeLivingAsync(int year, int month, List<int> liveAnchorIds)
        //{
        //    var performance = dalLiveAnchorMonthlyTargetBeforeLiving.GetAll().Where(t => t.Year == year && t.Month == month)
        //        .Where(o => liveAnchorIds.Count == 0 || liveAnchorIds.Contains(o.LiveAnchorId));
        //    LiveAnchorBaseBusinessMonthTargetBeforeLivingPerformanceDto performanceInfoDto = new LiveAnchorBaseBusinessMonthTargetBeforeLivingPerformanceDto
        //    {
        //        AddWeChatTargetBeforeLiving = await performance.SumAsync(t => t.AddWechatTargetBeforeLiving),
        //        ConsulationCardTargetBeforeLiving = await performance.SumAsync(t => t.ConsultationTargetBeforeLiving + t.ConsultationTargetBeforeLiving2),
        //        ConsulationCardConsumedTargetBeforeLiving = await performance.SumAsync(t => t.ConsultationCardConsumedTargetBeforeLiving + t.ConsultationCardConsumedTargetBeforeLiving2),
        //        HistoryConsulationCardConsumedTargetBeforeLiving = await performance.SumAsync(t => t.ActivateHistoricalConsultationTargetBeforeLiving),
        //        ConsulationCardRefundTargetBeforeLiving = await performance.SumAsync(t => t.MinivanRefundTargetBeforeLiving),

        //    };
        //    return performanceInfoDto;
        //}

        ///// <summary>
        ///// 派单成交看板业绩目标
        ///// </summary>
        ///// <param name="year"></param>
        ///// <param name="month"></param>
        ///// <param name="liveAnchorIds">各个平台的主播ID集合</param>
        ///// <returns></returns>
        //public async Task<LiveAnchorBaseBusinessMonthTargetBeforeLivingSendOrDealDto> GetSendOrDealTargetBeforeLivingAsync(int year, int month, List<int> liveAnchorIds)
        //{
        //    var performance = dalLiveAnchorMonthlyTargetBeforeLiving.GetAll().Where(t => t.Year == year && t.Month == month)
        //        .Where(o => liveAnchorIds.Count == 0 || liveAnchorIds.Contains(o.LiveAnchorId));
        //    LiveAnchorBaseBusinessMonthTargetBeforeLivingSendOrDealDto performanceInfoDto = new LiveAnchorBaseBusinessMonthTargetBeforeLivingSendOrDealDto
        //    {
        //        SendOrderTargetBeforeLiving = await performance.SumAsync(t => t.SendOrderTargetBeforeLiving),
        //        TotalVisitTargetBeforeLiving = await performance.SumAsync(t => t.VisitTargetBeforeLiving),
        //        NewCustomerVisitTargetBeforeLiving = await performance.SumAsync(t => t.NewCustomerVisitTargetBeforeLiving),
        //        OldCustomerVisitTargetBeforeLiving = await performance.SumAsync(t => t.OldCustomerVisitTargetBeforeLiving),
        //        TotalDealTargetBeforeLiving = await performance.SumAsync(t => t.DealTargetBeforeLiving),
        //        NewCustomerDealTargetBeforeLiving = await performance.SumAsync(t => t.NewCustomerDealTargetBeforeLiving),
        //        OldCustomerDealTargetBeforeLiving = await performance.SumAsync(t => t.OldCustomerDealTargetBeforeLiving),

        //    };
        //    return performanceInfoDto;
        //}

    }
}
