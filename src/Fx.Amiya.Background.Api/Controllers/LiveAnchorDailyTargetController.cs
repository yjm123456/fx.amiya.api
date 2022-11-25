using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.LiveAnchorDailyTarget;
using Fx.Amiya.Dto.ExpressManage;
using Fx.Amiya.Dto.LiveAnchorDailyTarget;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 主播日运营目标情况数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LiveAnchorDailyTargetController : ControllerBase
    {
        private ILiveAnchorDailyTargetService _liveAnchorDailyTargetService;
        private IHttpContextAccessor httpContextAccessor;
        private IShoppingCartRegistrationService shoppingCartRegistrationService;
        private IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService;
        private IContentPlatformOrderSendService contentPlatformOrderSendService;

        /// <summary>
        /// 构造函数
        /// </summary>
        public LiveAnchorDailyTargetController(ILiveAnchorDailyTargetService liveAnchorDailyTargetService,
            IHttpContextAccessor httpContextAccessor,
            IShoppingCartRegistrationService shoppingCartRegistrationService,
            IContentPlatformOrderSendService contentPlatformOrderSendService,
            IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService)
        {
            _liveAnchorDailyTargetService = liveAnchorDailyTargetService;
            this.httpContextAccessor = httpContextAccessor;
            this.shoppingCartRegistrationService = shoppingCartRegistrationService;
            this.contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.contentPlatformOrderSendService = contentPlatformOrderSendService;
        }

        /// <summary>
        /// 获取主播日运营目标情况
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="operationEmpId">运营人员id</param>
        /// <param name="netWorkConEmpId">网咨人员id</param>
        /// <param name="liveAnchorId">主播ip账户id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<LiveAnchorDailyTargetVo>>> GetListWithPageAsync(DateTime startDate, DateTime endDate,  int? liveAnchorId, int pageNum, int pageSize)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await _liveAnchorDailyTargetService.GetListWithPageAsync(startDate, endDate,  liveAnchorId, pageNum, pageSize, employeeId);

                var liveAnchorDailyTarget = from d in q.List
                                            select new LiveAnchorDailyTargetVo
                                            {
                                                Id = d.Id,
                                                LiveAnchor = d.LiveAnchor,
                                                CreateDate = d.CreateDate,
                                                RecordDate = d.RecordDate,

                                                SinaWeiBoOperationEmployeeName = d.SinaWeiBoOperationEmployeeName,
                                                SinaWeiBoSendNum = d.SinaWeiBoSendNum,
                                                SinaWeiBoFlowInvestmentNum = d.SinaWeiBoFlowInvestmentNum,

                                                TikTokOperationEmployeeName = d.TikTokOperationEmployeeName,
                                                TikTokSendNum = d.TikTokSendNum,
                                                TikTokFlowInvestmentNum = d.TikTokFlowInvestmentNum,

                                                VideoOperationEmployeeName = d.VideoOperationEmployeeName,
                                                VideoSendNum = d.VideoSendNum,
                                                VideoFlowInvestmentNum = d.VideoFlowInvestmentNum,

                                                XiaoHongShuOperationEmployeeName = d.XiaoHongShuOperationEmployeeName,
                                                XiaoHongShuSendNum = d.XiaoHongShuSendNum,
                                                XiaoHongShuFlowInvestmentNum = d.XiaoHongShuFlowInvestmentNum,

                                                ZhihuOperationEmployeeName = d.ZhihuOperationEmployeeName,
                                                ZhihuSendNum = d.ZhihuSendNum,
                                                ZhihuFlowInvestmentNum = d.ZhihuFlowInvestmentNum,

                                                TodaySendNum = d.TodaySendNum,
                                                FlowInvestmentNum = d.FlowInvestmentNum,
                                                LivingRoomFlowInvestmentNum = d.LivingRoomFlowInvestmentNum,
                                                CluesNum = d.CluesNum,
                                                AddFansNum = d.AddFansNum,
                                                AddWechatNum = d.AddWechatNum,
                                                Consultation = d.Consultation,
                                                ConsultationCardConsumed = d.ConsultationCardConsumed,
                                                Consultation2 = d.Consultation2,
                                                ConsultationCardConsumed2 = d.ConsultationCardConsumed2,
                                                ActivateHistoricalConsultation = d.ActivateHistoricalConsultation,
                                                SendOrderNum = d.SendOrderNum,
                                                NewVisitNum = d.NewVisitNum,
                                                SubsequentVisitNum = d.SubsequentVisitNum,
                                                OldCustomerVisitNum = d.OldCustomerVisitNum,
                                                VisitNum = d.VisitNum,
                                                NewDealNum = d.NewDealNum,
                                                SubsequentDealNum = d.SubsequentDealNum,
                                                OldCustomerDealNum = d.OldCustomerDealNum,
                                                DealNum = d.DealNum,
                                                CargoSettlementCommission = d.CargoSettlementCommission,
                                                NewPerformanceNum = d.NewPerformanceNum,
                                                SubsequentPerformanceNum = d.SubsequentPerformanceNum,
                                                OldCustomerPerformanceNum = d.OldCustomerPerformanceNum,
                                                NewCustomerPerformanceCountNum = d.NewCustomerPerformanceCountNum,
                                                PerformanceNum = d.PerformanceNum,
                                                MinivanRefund = d.MinivanRefund,
                                                MiniVanBadReviews = d.MiniVanBadReviews,
                                                NetWorkConsultingEmployeeName = d.NetWorkConsultingEmployeeName,
                                                LivingTrackingEmployeeName = d.LivingTrackingEmployeeName,
                                                TikTokUpdateDate=d.TikTokUpdateDate,
                                                LivingUpdateDate=d.LivingUpdateDate,
                                                AfterLivingUpdateDate=d.AfterLivingUpdateDate
                                                
                                            };

                FxPageInfo<LiveAnchorDailyTargetVo> liveAnchorDailyTargetPageInfo = new FxPageInfo<LiveAnchorDailyTargetVo>();
                liveAnchorDailyTargetPageInfo.TotalCount = q.TotalCount;
                liveAnchorDailyTargetPageInfo.List = liveAnchorDailyTarget;
                
                return ResultData<FxPageInfo<LiveAnchorDailyTargetVo>>.Success().AddData("liveAnchorDailyTargetInfo", liveAnchorDailyTargetPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<LiveAnchorDailyTargetVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据id获取主播日运营目标情况
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="type">直播前类型（1：抖音；2：知乎；3：微博；4：小红书；5：视频号；6：直播中；7：直播后）</param>
        /// <returns></returns>
        [HttpGet("getByIdAndType")]
        public async Task<ResultData<LiveAnchorDailyTargetByIdVo>> GetByIdAndTypeAsync(string id,int type)
        {
            try
            {
                var liveAnchorDailyTarget = await _liveAnchorDailyTargetService.GetByIdAndTypeAsync(id, type);
                LiveAnchorDailyTargetByIdVo liveAnchorDailyTargetVo = new LiveAnchorDailyTargetByIdVo();
                liveAnchorDailyTargetVo.Id = liveAnchorDailyTarget.Id;
                liveAnchorDailyTargetVo.LiveAnchorId = liveAnchorDailyTarget.LiveAnchorId;
                liveAnchorDailyTargetVo.LiveanchorMonthlyTargetId = liveAnchorDailyTarget.LiveanchorMonthlyTargetId;
                liveAnchorDailyTargetVo.LivingTrackingEmployeeId = liveAnchorDailyTarget.LivingTrackingEmployeeId;
                liveAnchorDailyTargetVo.NetWorkConsultingEmployeeId = liveAnchorDailyTarget.NetWorkConsultingEmployeeId;

                liveAnchorDailyTargetVo.TikTokOperationEmployeeId = liveAnchorDailyTarget.TikTokOperationEmployeeId;
                liveAnchorDailyTargetVo.TikTokSendNum = liveAnchorDailyTarget.TikTokSendNum;
                liveAnchorDailyTargetVo.TikTokFlowInvestmentNum = liveAnchorDailyTarget.TikTokFlowInvestmentNum;

                liveAnchorDailyTargetVo.ZhihuOperationEmployeeId = liveAnchorDailyTarget.ZhihuOperationEmployeeId;
                liveAnchorDailyTargetVo.ZhihuSendNum = liveAnchorDailyTarget.ZhihuSendNum;
                liveAnchorDailyTargetVo.ZhihuFlowInvestmentNum = liveAnchorDailyTarget.ZhihuFlowInvestmentNum;

                liveAnchorDailyTargetVo.XiaoHongShuOperationEmployeeId = liveAnchorDailyTarget.XiaoHongShuOperationEmployeeId;
                liveAnchorDailyTargetVo.XiaoHongShuSendNum = liveAnchorDailyTarget.XiaoHongShuSendNum;
                liveAnchorDailyTargetVo.XiaoHongShuFlowInvestmentNum = liveAnchorDailyTarget.XiaoHongShuFlowInvestmentNum;

                liveAnchorDailyTargetVo.SinaWeiBoOperationEmployeeId = liveAnchorDailyTarget.SinaWeiBoOperationEmployeeId;
                liveAnchorDailyTargetVo.SinaWeiBoSendNum = liveAnchorDailyTarget.SinaWeiBoSendNum;
                liveAnchorDailyTargetVo.SinaWeiBoFlowInvestmentNum = liveAnchorDailyTarget.SinaWeiBoFlowInvestmentNum;

                liveAnchorDailyTargetVo.VideoOperationEmployeeId = liveAnchorDailyTarget.VideoOperationEmployeeId;
                liveAnchorDailyTargetVo.VideoSendNum = liveAnchorDailyTarget.VideoSendNum;
                liveAnchorDailyTargetVo.VideoFlowInvestmentNum = liveAnchorDailyTarget.VideoFlowInvestmentNum;
                liveAnchorDailyTargetVo.TodaySendNum = liveAnchorDailyTarget.TodaySendNum;
                liveAnchorDailyTargetVo.FlowInvestmentNum = liveAnchorDailyTarget.FlowInvestmentNum;
                liveAnchorDailyTargetVo.LivingRoomFlowInvestmentNum = liveAnchorDailyTarget.LivingRoomFlowInvestmentNum;
                liveAnchorDailyTargetVo.CluesNum = liveAnchorDailyTarget.CluesNum;
                liveAnchorDailyTargetVo.AddFansNum = liveAnchorDailyTarget.AddFansNum;
                liveAnchorDailyTargetVo.AddWechatNum = liveAnchorDailyTarget.AddWechatNum;
                liveAnchorDailyTargetVo.Consultation = liveAnchorDailyTarget.Consultation;
                liveAnchorDailyTargetVo.Consultation2 = liveAnchorDailyTarget.Consultation2;
                liveAnchorDailyTargetVo.ActivateHistoricalConsultation = liveAnchorDailyTarget.ActivateHistoricalConsultation;
                liveAnchorDailyTargetVo.ConsultationCardConsumed = liveAnchorDailyTarget.ConsultationCardConsumed;
                liveAnchorDailyTargetVo.ConsultationCardConsumed2 = liveAnchorDailyTarget.ConsultationCardConsumed2;
                liveAnchorDailyTargetVo.SendOrderNum = liveAnchorDailyTarget.SendOrderNum;
                liveAnchorDailyTargetVo.NewVisitNum = liveAnchorDailyTarget.NewVisitNum;
                liveAnchorDailyTargetVo.SubsequentVisitNum = liveAnchorDailyTarget.SubsequentVisitNum;
                liveAnchorDailyTargetVo.OldCustomerVisitNum = liveAnchorDailyTarget.OldCustomerVisitNum;
                liveAnchorDailyTargetVo.VisitNum = liveAnchorDailyTarget.VisitNum;
                liveAnchorDailyTargetVo.NewDealNum = liveAnchorDailyTarget.NewDealNum;
                liveAnchorDailyTargetVo.SubsequentDealNum = liveAnchorDailyTarget.SubsequentDealNum;
                liveAnchorDailyTargetVo.OldCustomerDealNum = liveAnchorDailyTarget.OldCustomerDealNum;
                liveAnchorDailyTargetVo.DealNum = liveAnchorDailyTarget.DealNum;
                liveAnchorDailyTargetVo.CargoSettlementCommission = liveAnchorDailyTarget.CargoSettlementCommission;
                liveAnchorDailyTargetVo.NewPerformanceNum = liveAnchorDailyTarget.NewPerformanceNum;
                liveAnchorDailyTargetVo.SubsequentPerformanceNum = liveAnchorDailyTarget.SubsequentPerformanceNum;
                liveAnchorDailyTargetVo.NewCustomerPerformanceCountNum = liveAnchorDailyTarget.NewCustomerPerformanceCountNum;
                liveAnchorDailyTargetVo.OldCustomerPerformanceNum = liveAnchorDailyTarget.OldCustomerPerformanceNum;
                liveAnchorDailyTargetVo.PerformanceNum = liveAnchorDailyTarget.PerformanceNum;
                liveAnchorDailyTargetVo.CreateDate = liveAnchorDailyTarget.CreateDate;
                liveAnchorDailyTargetVo.RecordDate = liveAnchorDailyTarget.RecordDate;
                liveAnchorDailyTargetVo.MinivanRefund = liveAnchorDailyTarget.MinivanRefund;
                liveAnchorDailyTargetVo.MiniVanBadReviews = liveAnchorDailyTarget.MiniVanBadReviews;

                return ResultData<LiveAnchorDailyTargetByIdVo>.Success().AddData("liveAnchorDailyTargetInfo", liveAnchorDailyTargetVo);
            }
            catch (Exception ex)
            {
                return ResultData<LiveAnchorDailyTargetByIdVo>.Fail(ex.Message);
            }
        }

        #region 【直播前】  

        #region [抖音]
        /// <summary>
        /// 添加直播前抖音主播日运营目标情况
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("BeforeTikTokLivingAdd")]
        public async Task<ResultData> BeforeLivingTikTokAddAsync(BeforeLivingTikTokAddLiveAnchorDailyTargetVo addVo)
        {
            try
            {
                var selectResult = await _liveAnchorDailyTargetService.GetLiveAnchorInfoByMonthlyTargetIdAndDate(addVo.LiveanchorMonthlyTargetId, addVo.RecordDate);
                if (selectResult != null)
                {
                    throw new Exception("当前填报日期的主播日运营数据已创建，请根据筛选条件查询到对应数据编辑！");
                }
                else
                {
                    BeforeLivingTikTokAddLiveAnchorDailyTargetDto addDto = new BeforeLivingTikTokAddLiveAnchorDailyTargetDto();
                    addDto.LiveanchorMonthlyTargetId = addVo.LiveanchorMonthlyTargetId;
                    addDto.TikTokOperationEmployeeId = addVo.TikTokOperationEmployeeId;
                    addDto.TikTokFlowInvestmentNum = addVo.TikTokFlowInvestmentNum;
                    addDto.TikTokSendNum = addVo.TikTokSendNum;
                    addDto.TodaySendNum = addVo.TodaySendNum;
                    addDto.FlowInvestmentNum = addVo.FlowInvestmentNum;
                    addDto.RecordDate = addVo.RecordDate;
                    await _liveAnchorDailyTargetService.BeforeLivingTikTokAddAsync(addDto);
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改直播前抖音主播日运营目标情况
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("BeforeLivingTikTokUpdate")]
        public async Task<ResultData> BeforeLivingTikTokUpdateAsync(BeforeLivingTikTokUpdateLiveAnchorDailyTargetVo updateVo)
        {
            try
            {
                BeforeLivingTikTokUpdateLiveAnchorDailyTargetDto updateDto = new BeforeLivingTikTokUpdateLiveAnchorDailyTargetDto();
                updateDto.Id = updateVo.Id;
                updateDto.LiveanchorMonthlyTargetId = updateVo.LiveanchorMonthlyTargetId;
                updateDto.TikTokOperationEmployeeId = updateVo.TikTokOperationEmployeeId;
                updateDto.TikTokSendNum = updateVo.TikTokSendNum;
                updateDto.TikTokFlowInvestmentNum = updateVo.TikTokFlowInvestmentNum;
                updateDto.TodaySendNum = updateVo.TodaySendNum;
                updateDto.FlowInvestmentNum = updateVo.FlowInvestmentNum;
                updateDto.RecordDate = updateVo.RecordDate;
                await _liveAnchorDailyTargetService.BeforeLivingTikTokUpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        #endregion

        #region [知乎]
        /// <summary>
        /// 添加直播前知乎主播日运营目标情况
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("BeforeZhihuLivingAdd")]
        public async Task<ResultData> BeforeLivingZhihuAddAsync(BeforeLivingZhihuAddLiveAnchorDailyTargetVo addVo)
        {
            try
            {
                var selectResult = await _liveAnchorDailyTargetService.GetLiveAnchorInfoByMonthlyTargetIdAndDate(addVo.LiveanchorMonthlyTargetId, addVo.RecordDate);
                if (selectResult != null)
                {
                    throw new Exception("当前填报日期的主播日运营数据已创建，请根据筛选条件查询到对应数据编辑！");
                }
                else
                {
                    BeforeLivingZhihuAddLiveAnchorDailyTargetDto addDto = new BeforeLivingZhihuAddLiveAnchorDailyTargetDto();
                    addDto.LiveanchorMonthlyTargetId = addVo.LiveanchorMonthlyTargetId;
                    addDto.ZhihuOperationEmployeeId = addVo.ZhihuOperationEmployeeId;
                    addDto.ZhihuSendNum = addVo.ZhihuSendNum;
                    addDto.ZhihuFlowInvestmentNum = addVo.ZhihuFlowInvestmentNum;
                    addDto.TodaySendNum = addVo.TodaySendNum;
                    addDto.FlowInvestmentNum = addVo.FlowInvestmentNum;
                    //addDto.CluesNum = addVo.CluesNum;
                    //addDto.AddFansNum = addVo.AddFansNum;
                    addDto.RecordDate = addVo.RecordDate;
                    await _liveAnchorDailyTargetService.BeforeLivingZhihuAddAsync(addDto);
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改直播前知乎主播日运营目标情况
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("BeforeLivingZhihuUpdate")]
        public async Task<ResultData> BeforeLivingZhihuUpdateAsync(BeforeLivingZhihuUpdateLiveAnchorDailyTargetVo updateVo)
        {
            try
            {
                BeforeLivingZhihuUpdateLiveAnchorDailyTargetDto updateDto = new BeforeLivingZhihuUpdateLiveAnchorDailyTargetDto();
                updateDto.Id = updateVo.Id;
                updateDto.LiveanchorMonthlyTargetId = updateVo.LiveanchorMonthlyTargetId;
                updateDto.ZhihuOperationEmployeeId = updateVo.ZhihuOperationEmployeeId;
                updateDto.ZhihuSendNum = updateVo.ZhihuSendNum;
                updateDto.ZhihuFlowInvestmentNum = updateVo.ZhihuFlowInvestmentNum;
                updateDto.TodaySendNum = updateVo.TodaySendNum;
                updateDto.FlowInvestmentNum = updateVo.FlowInvestmentNum;
                //updateDto.CluesNum = updateVo.CluesNum;
                //updateDto.AddFansNum = updateVo.AddFansNum;
                updateDto.RecordDate = updateVo.RecordDate;
                await _liveAnchorDailyTargetService.BeforeLivingZhihuUpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        #endregion

        #region [微博]
        /// <summary>
        /// 添加直播前微博主播日运营目标情况
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("BeforeSinaWeiBoLivingAdd")]
        public async Task<ResultData> BeforeLivingSinaWeiBoAddAsync(BeforeLivingSinaWeiBoAddLiveAnchorDailyTargetVo addVo)
        {
            try
            {
                var selectResult = await _liveAnchorDailyTargetService.GetLiveAnchorInfoByMonthlyTargetIdAndDate(addVo.LiveanchorMonthlyTargetId, addVo.RecordDate);
                if (selectResult != null)
                {
                    throw new Exception("当前填报日期的主播日运营数据已创建，请根据筛选条件查询到对应数据编辑！");
                }
                else
                {
                    BeforeLivingSinaWeiBoAddLiveAnchorDailyTargetDto addDto = new BeforeLivingSinaWeiBoAddLiveAnchorDailyTargetDto();
                    addDto.LiveanchorMonthlyTargetId = addVo.LiveanchorMonthlyTargetId;
                    addDto.SinaWeiBoOperationEmployeeId = addVo.SinaWeiBoOperationEmployeeId;
                    addDto.SinaWeiBoSendNum = addVo.SinaWeiBoSendNum;
                    addDto.SinaWeiBoFlowInvestmentNum = addVo.SinaWeiBoFlowInvestmentNum;
                    addDto.TodaySendNum = addVo.TodaySendNum;
                    addDto.FlowInvestmentNum = addVo.FlowInvestmentNum;
                    //addDto.CluesNum = addVo.CluesNum;
                    //addDto.AddFansNum = addVo.AddFansNum;
                    addDto.RecordDate = addVo.RecordDate;
                    await _liveAnchorDailyTargetService.BeforeLivingSinaWeiBoAddAsync(addDto);
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改直播前微博主播日运营目标情况
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("BeforeLivingSinaWeiBoUpdate")]
        public async Task<ResultData> BeforeLivingSinaWeiBoUpdateAsync(BeforeLivingSinaWeiBoUpdateLiveAnchorDailyTargetVo updateVo)
        {
            try
            {
                BeforeLivingSinaWeiBoUpdateLiveAnchorDailyTargetDto updateDto = new BeforeLivingSinaWeiBoUpdateLiveAnchorDailyTargetDto();
                updateDto.Id = updateVo.Id;
                updateDto.LiveanchorMonthlyTargetId = updateVo.LiveanchorMonthlyTargetId;
                updateDto.SinaWeiBoOperationEmployeeId = updateVo.SinaWeiBoOperationEmployeeId;
                updateDto.SinaWeiBoSendNum = updateVo.SinaWeiBoSendNum;
                updateDto.SinaWeiBoFlowInvestmentNum = updateVo.SinaWeiBoFlowInvestmentNum;
                updateDto.TodaySendNum = updateVo.TodaySendNum;
                updateDto.FlowInvestmentNum = updateVo.FlowInvestmentNum;
                //updateDto.CluesNum = updateVo.CluesNum;
                //updateDto.AddFansNum = updateVo.AddFansNum;
                updateDto.RecordDate = updateVo.RecordDate;
                await _liveAnchorDailyTargetService.BeforeLivingSinaWeiBoUpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        #endregion

        #region [小红书]
        /// <summary>
        /// 添加直播前小红书主播日运营目标情况
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("BeforeXiaoHongShuLivingAdd")]
        public async Task<ResultData> BeforeLivingXiaoHongShuAddAsync(BeforeLivingXiaoHongShuAddLiveAnchorDailyTargetVo addVo)
        {
            try
            {
                var selectResult = await _liveAnchorDailyTargetService.GetLiveAnchorInfoByMonthlyTargetIdAndDate(addVo.LiveanchorMonthlyTargetId, addVo.RecordDate);
                if (selectResult != null)
                {
                    throw new Exception("当前填报日期的主播日运营数据已创建，请根据筛选条件查询到对应数据编辑！");
                }
                else
                {
                    BeforeLivingXiaoHongShuAddLiveAnchorDailyTargetDto addDto = new BeforeLivingXiaoHongShuAddLiveAnchorDailyTargetDto();
                    addDto.LiveanchorMonthlyTargetId = addVo.LiveanchorMonthlyTargetId;
                    addDto.XiaoHongShuOperationEmployeeId = addVo.XiaoHongShuOperationEmployeeId;
                    addDto.XiaoHongShuSendNum = addVo.XiaoHongShuSendNum;
                    addDto.XiaoHongShuFlowInvestmentNum = addVo.XiaoHongShuFlowInvestmentNum;
                    addDto.TodaySendNum = addVo.TodaySendNum;
                    addDto.FlowInvestmentNum = addVo.FlowInvestmentNum;
                    addDto.RecordDate = addVo.RecordDate;
                    await _liveAnchorDailyTargetService.BeforeLivingXiaoHongShuAddAsync(addDto);
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改直播前小红书主播日运营目标情况
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("BeforeLivingXiaoHongShuUpdate")]
        public async Task<ResultData> BeforeLivingXiaoHongShuUpdateAsync(BeforeLivingXiaoHongShuUpdateLiveAnchorDailyTargetVo updateVo)
        {
            try
            {
                BeforeLivingXiaoHongShuUpdateLiveAnchorDailyTargetDto updateDto = new BeforeLivingXiaoHongShuUpdateLiveAnchorDailyTargetDto();
                updateDto.Id = updateVo.Id;
                updateDto.LiveanchorMonthlyTargetId = updateVo.LiveanchorMonthlyTargetId;
                updateDto.XiaoHongShuOperationEmployeeId = updateVo.XiaoHongShuOperationEmployeeId;
                updateDto.XiaoHongShuSendNum = updateVo.XiaoHongShuSendNum;
                updateDto.XiaoHongShuFlowInvestmentNum = updateVo.XiaoHongShuFlowInvestmentNum;
                updateDto.TodaySendNum = updateVo.TodaySendNum;
                updateDto.FlowInvestmentNum = updateVo.FlowInvestmentNum;
                //updateDto.CluesNum = updateVo.CluesNum;
                //updateDto.AddFansNum = updateVo.AddFansNum;
                updateDto.RecordDate = updateVo.RecordDate;
                await _liveAnchorDailyTargetService.BeforeLivingXiaoHongShuUpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        #endregion

        #region [视频号]
        /// <summary>
        /// 添加直播前视频号主播日运营目标情况
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("BeforeVideoLivingAdd")]
        public async Task<ResultData> BeforeLivingVideoAddAsync(BeforeLivingVideoAddLiveAnchorDailyTargetVo addVo)
        {
            try
            {
                var selectResult = await _liveAnchorDailyTargetService.GetLiveAnchorInfoByMonthlyTargetIdAndDate(addVo.LiveanchorMonthlyTargetId, addVo.RecordDate);
                if (selectResult != null)
                {
                    throw new Exception("当前填报日期的主播日运营数据已创建，请根据筛选条件查询到对应数据编辑！");
                }
                else
                {
                    BeforeLivingVideoAddLiveAnchorDailyTargetDto addDto = new BeforeLivingVideoAddLiveAnchorDailyTargetDto();
                    addDto.LiveanchorMonthlyTargetId = addVo.LiveanchorMonthlyTargetId;
                    addDto.VideoOperationEmployeeId = addVo.VideoOperationEmployeeId;
                    addDto.VideoSendNum = addVo.VideoSendNum;
                    addDto.VideoFlowInvestmentNum = addVo.VideoFlowInvestmentNum;
                    addDto.TodaySendNum = addVo.TodaySendNum;
                    addDto.FlowInvestmentNum = addVo.FlowInvestmentNum;
                    //addDto.CluesNum = addVo.CluesNum;
                    //addDto.AddFansNum = addVo.AddFansNum;
                    addDto.RecordDate = addVo.RecordDate;
                    await _liveAnchorDailyTargetService.BeforeLivingVideoAddAsync(addDto);
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改直播前视频号主播日运营目标情况
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("BeforeLivingVideoUpdate")]
        public async Task<ResultData> BeforeLivingVideoUpdateAsync(BeforeLivingVideoUpdateLiveAnchorDailyTargetVo updateVo)
        {
            try
            {
                BeforeLivingVideoUpdateLiveAnchorDailyTargetDto updateDto = new BeforeLivingVideoUpdateLiveAnchorDailyTargetDto();
                updateDto.Id = updateVo.Id;
                updateDto.LiveanchorMonthlyTargetId = updateVo.LiveanchorMonthlyTargetId;
                updateDto.VideoOperationEmployeeId = updateVo.VideoOperationEmployeeId;
                updateDto.VideoSendNum = updateVo.VideoSendNum;
                updateDto.VideoFlowInvestmentNum = updateVo.VideoFlowInvestmentNum;
                updateDto.TodaySendNum = updateVo.TodaySendNum;
                updateDto.FlowInvestmentNum = updateVo.FlowInvestmentNum;
                //updateDto.CluesNum = updateVo.CluesNum;
                //updateDto.AddFansNum = updateVo.AddFansNum;
                updateDto.RecordDate = updateVo.RecordDate;
                await _liveAnchorDailyTargetService.BeforeLivingVideoUpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        #endregion

        #endregion

        #region 【直播中】  
        /// <summary>
        /// 添加直播中主播日运营目标情况
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("livingAdd")]
        public async Task<ResultData> LivingAddAsync(LivingAddLiveAnchorDailyTargetVo addVo)
        {
            try
            {
                var selectResult = await _liveAnchorDailyTargetService.GetLiveAnchorInfoByMonthlyTargetIdAndDate(addVo.LiveanchorMonthlyTargetId, addVo.RecordDate);
                if (selectResult != null)
                {
                    throw new Exception("当前填报日期的主播日运营数据已创建，请根据筛选条件查询到对应数据编辑！");
                }
                else
                {
                    LivingAddLiveAnchorDailyTargetDto addDto = new LivingAddLiveAnchorDailyTargetDto();
                    addDto.LiveanchorMonthlyTargetId = addVo.LiveanchorMonthlyTargetId;
                    addDto.LivingTrackingEmployeeId = addVo.LivingTrackingEmployeeId;
                    addDto.LivingRoomFlowInvestmentNum = addVo.LivingRoomFlowInvestmentNum;
                    addDto.Consultation = addVo.Consultation;
                    addDto.Consultation2 = addVo.Consultation2;
                    addDto.CargoSettlementCommission = addVo.CargoSettlementCommission;
                    addDto.RecordDate = addVo.RecordDate;
                    await _liveAnchorDailyTargetService.LivingAddAsync(addDto);
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改直播中主播日运营目标情况
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("livingUpdate")]
        public async Task<ResultData> LivingUpdateAsync(LivingUpdateLiveAnchorDailyTargetVo updateVo)
        {
            try
            {
                LivingUpdateLiveAnchorDailyTargetDto updateDto = new LivingUpdateLiveAnchorDailyTargetDto();
                updateDto.Id = updateVo.Id;
                updateDto.LiveanchorMonthlyTargetId = updateVo.LiveanchorMonthlyTargetId;
                updateDto.LivingTrackingEmployeeId = updateVo.LivingTrackingEmployeeId;
                updateDto.LivingRoomFlowInvestmentNum = updateVo.LivingRoomFlowInvestmentNum;
                updateDto.Consultation = updateVo.Consultation;
                updateDto.Consultation2 = updateVo.Consultation2;
                updateDto.CargoSettlementCommission = updateVo.CargoSettlementCommission;
                updateDto.RecordDate = updateVo.RecordDate;
                await _liveAnchorDailyTargetService.LivingUpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        #endregion


        #region 【直播后】  

        /// <summary>
        /// 根据主播id自动生成业绩
        /// </summary>
        /// <param name="liveAnchorId"></param>
        /// <param name="recordDate">填报日期</param>
        /// <returns></returns>
        [HttpGet("getLiveAnchorPerformance")]
        public async Task<AfterLivingUpdateLiveAnchorDailyTargetVo> GetAfterLivingAchievementByLiveAnchorId(int liveAnchorId, DateTime recordDate)
        {
            AfterLivingUpdateLiveAnchorDailyTargetVo result = new AfterLivingUpdateLiveAnchorDailyTargetVo();

            var cardConsumed = await shoppingCartRegistrationService.GetDialyConsulationCardInfoByLiveAnchorId(liveAnchorId, recordDate);
            result.ConsultationCardConsumed = cardConsumed.Where(x => x.ConsultationType == (int)ShoppingCartConsultationType.Picture).Count();
            result.ConsultationCardConsumed2 = cardConsumed.Where(x => x.ConsultationType == (int)ShoppingCartConsultationType.Video).Count();
            result.ActivateHistoricalConsultation = cardConsumed.Where(x => x.RecordDate.Month != x.ConsultationDate.Value.Month).Count();
            var addWeChatOrSendOrderInfo = await shoppingCartRegistrationService.GetDialyAddWeChatInfoByLiveAnchorId(liveAnchorId, recordDate);
            result.AddWechatNum = addWeChatOrSendOrderInfo.Count();
            var sendOrderInfo = await contentPlatformOrderSendService.GetTodaySendOrderByLiveAnchorIdAsync(liveAnchorId, recordDate);

            result.SendOrderNum = sendOrderInfo.Count();

            var toHospitalAndDealInfo = await contentPlatFormOrderDealInfoService.GetTodaySendPerformanceAsync(liveAnchorId, recordDate);

            result.NewVisitNum = toHospitalAndDealInfo.Where(x => x.ToHospitalType == (int)ContentPlateFormOrderToHospitalType.FIRST_SEEK_ADVICE).Count();
            result.SubsequentVisitNum = toHospitalAndDealInfo.Where(x => x.ToHospitalType == (int)ContentPlateFormOrderToHospitalType.AGAIN_SEEK_ADVICE).Count();
            result.OldCustomerVisitNum = toHospitalAndDealInfo.Where(x => x.IsOldCustomer == true).Count();
            result.VisitNum = result.NewVisitNum + result.SubsequentVisitNum + result.OldCustomerVisitNum;

            result.NewDealNum = toHospitalAndDealInfo.Where(x => x.IsDeal == true && x.ToHospitalType == (int)ContentPlateFormOrderToHospitalType.FIRST_SEEK_ADVICE).Count();
            result.SubsequentDealNum = toHospitalAndDealInfo.Where(x => x.IsDeal == true && x.ToHospitalType == (int)ContentPlateFormOrderToHospitalType.AGAIN_SEEK_ADVICE).Count();
            result.OldCustomerDealNum = toHospitalAndDealInfo.Where(x => x.IsDeal == true && x.IsOldCustomer == true).Count();
            result.DealNum = result.NewDealNum + result.SubsequentDealNum + result.OldCustomerDealNum;

            result.NewPerformanceNum = toHospitalAndDealInfo.Where(x => x.IsDeal == true && x.ToHospitalType == (int)ContentPlateFormOrderToHospitalType.FIRST_SEEK_ADVICE).Sum(x => x.Price);
            result.SubsequentPerformanceNum = toHospitalAndDealInfo.Where(x => x.IsDeal == true && x.ToHospitalType == (int)ContentPlateFormOrderToHospitalType.AGAIN_SEEK_ADVICE).Sum(x => x.Price);
            result.OldCustomerPerformanceNum = toHospitalAndDealInfo.Where(x => x.IsDeal == true && x.IsOldCustomer == true).Sum(x => x.Price);
            result.NewCustomerPerformanceCountNum = result.NewPerformanceNum + result.SubsequentPerformanceNum;
            result.PerformanceNum = result.NewPerformanceNum + result.SubsequentPerformanceNum + result.OldCustomerPerformanceNum;

            var shoppingCardRefundInfo = await shoppingCartRegistrationService.GetDialyYellowCardRefundInfoByLiveAnchorId(liveAnchorId, recordDate);
            result.MinivanRefund = shoppingCardRefundInfo.Count();
            var shoppingCardBadViewInfo = await shoppingCartRegistrationService.GetDialyYellowCardBadReviewInfoByLiveAnchorId(liveAnchorId, recordDate);
            result.MiniVanBadReviews = shoppingCardBadViewInfo.Count();
            return result;
        }

        /// <summary>
        /// 添加直播后主播日运营目标情况
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("afterLivingAdd")]
        public async Task<ResultData> AfterLivingAddAsync(AfterLivingAddLiveAnchorDailyTargetVo addVo)
        {
            try
            {
                var selectResult = await _liveAnchorDailyTargetService.GetLiveAnchorInfoByMonthlyTargetIdAndDate(addVo.LiveanchorMonthlyTargetId, addVo.RecordDate);
                if (selectResult != null)
                {

                    throw new Exception("当前填报日期的主播日运营数据已创建，请根据筛选条件查询到对应数据编辑！");
                }
                else
                {
                    AfterLivingAddLiveAnchorDailyTargetDto addDto = new AfterLivingAddLiveAnchorDailyTargetDto();
                    addDto.LiveanchorMonthlyTargetId = addVo.LiveanchorMonthlyTargetId;
                    addDto.NetWorkConsultingEmployeeId = addVo.NetWorkConsultingEmployeeId;
                    addDto.ConsultationCardConsumed = addVo.ConsultationCardConsumed;
                    addDto.ConsultationCardConsumed2 = addVo.ConsultationCardConsumed2;
                    addDto.ActivateHistoricalConsultation = addVo.ActivateHistoricalConsultation;
                    addDto.AddWechatNum = addVo.AddWechatNum;
                    addDto.SendOrderNum = addVo.SendOrderNum;
                    addDto.NewVisitNum = addVo.NewVisitNum;
                    addDto.SubsequentVisitNum = addVo.SubsequentVisitNum;
                    addDto.OldCustomerVisitNum = addVo.OldCustomerVisitNum;
                    addDto.VisitNum = addVo.VisitNum;
                    addDto.NewDealNum = addVo.NewDealNum;
                    addDto.SubsequentDealNum = addVo.SubsequentDealNum;
                    addDto.OldCustomerDealNum = addVo.OldCustomerDealNum;
                    addDto.DealNum = addVo.DealNum;
                    addDto.NewPerformanceNum = addVo.NewPerformanceNum;
                    addDto.SubsequentPerformanceNum = addVo.SubsequentPerformanceNum;
                    addDto.NewCustomerPerformanceCountNum = addVo.NewCustomerPerformanceCountNum;
                    addDto.OldCustomerPerformanceNum = addVo.OldCustomerPerformanceNum;
                    addDto.PerformanceNum = addVo.PerformanceNum;
                    addDto.MinivanRefund = addVo.MinivanRefund;
                    addDto.MiniVanBadReviews = addVo.MiniVanBadReviews;
                    addDto.RecordDate = addVo.RecordDate;
                    await _liveAnchorDailyTargetService.AfterLivingAddAsync(addDto);
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改直播后主播日运营目标情况
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("afterLivingUpdate")]
        public async Task<ResultData> AfterLivingUpdateAsync(AfterLivingUpdateLiveAnchorDailyTargetVo updateVo)
        {
            try
            {
                AfterLivingUpdateLiveAnchorDailyTargetDto updateDto = new AfterLivingUpdateLiveAnchorDailyTargetDto();
                updateDto.Id = updateVo.Id;
                updateDto.LiveanchorMonthlyTargetId = updateVo.LiveanchorMonthlyTargetId;
                updateDto.NetWorkConsultingEmployeeId = updateVo.NetWorkConsultingEmployeeId;
                updateDto.ConsultationCardConsumed = updateVo.ConsultationCardConsumed;
                updateDto.ConsultationCardConsumed2 = updateVo.ConsultationCardConsumed2;
                updateDto.ActivateHistoricalConsultation = updateVo.ActivateHistoricalConsultation;
                updateDto.AddWechatNum = updateVo.AddWechatNum;
                updateDto.SendOrderNum = updateVo.SendOrderNum;
                updateDto.NewVisitNum = updateVo.NewVisitNum;
                updateDto.SubsequentVisitNum = updateVo.SubsequentVisitNum;
                updateDto.OldCustomerVisitNum = updateVo.OldCustomerVisitNum;
                updateDto.VisitNum = updateVo.VisitNum;
                updateDto.NewDealNum = updateVo.NewDealNum;
                updateDto.SubsequentDealNum = updateVo.SubsequentDealNum;
                updateDto.OldCustomerDealNum = updateVo.OldCustomerDealNum;
                updateDto.DealNum = updateVo.DealNum;
                updateDto.NewPerformanceNum = updateVo.NewPerformanceNum;
                updateDto.SubsequentPerformanceNum = updateVo.SubsequentPerformanceNum;
                updateDto.NewCustomerPerformanceCountNum = updateVo.NewCustomerPerformanceCountNum;
                updateDto.OldCustomerPerformanceNum = updateVo.OldCustomerPerformanceNum;
                updateDto.PerformanceNum = updateVo.PerformanceNum;
                updateDto.MinivanRefund = updateVo.MinivanRefund;
                updateDto.MiniVanBadReviews = updateVo.MiniVanBadReviews;
                updateDto.RecordDate = updateVo.RecordDate;
                updateDto.AfterLivingUpdateDate = DateTime.Now;
                await _liveAnchorDailyTargetService.AfterLivingUpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// 删除主播日运营目标情况
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _liveAnchorDailyTargetService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
