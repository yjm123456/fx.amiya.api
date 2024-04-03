using Fx.Amiya.Background.Api.Vo.Order;
using Fx.Amiya.Background.Api.Vo.TrackReported;
using Fx.Amiya.Dto.Track;
using Fx.Amiya.Dto.TrackReported;
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
    /// 追踪回访提报数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class TrackReportedController : ControllerBase
    {
        private ITrackReportedService _trackReportedService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="trackReportedService"></param>
        public TrackReportedController(ITrackReportedService trackReportedService,

            IHttpContextAccessor httpContextAccessor)
        {
            _trackReportedService = trackReportedService;
            this.httpContextAccessor = httpContextAccessor;
        }
        #region 【管理端】
        /// <summary>
        /// 获取追踪回访提报信息列表（分页）
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="sendHospitalId">提报医院id（为空查所有）</param>
        /// <param name="sendStatus">提报状态（为空查所有）</param>
        /// <param name="keyword">关键词（查询手机号与提报内容）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<TrackReportedVo>>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? sendHospitalId, int? sendStatus, string keyword, int pageNum, int pageSize)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await _trackReportedService.GetListWithPageAsync(startDate, endDate, sendHospitalId, employeeId, sendStatus, keyword, pageNum, pageSize);

                var trackReported = from d in q.List
                                    select new TrackReportedVo
                                    {
                                        Id = d.Id,
                                        Phone = d.Phone,
                                        SendStatus = d.SendStatus,
                                        SendStatusText = d.SendStatusText,
                                        SendContent = d.SendContent,
                                        SendHospitalId = d.SendHospitalId,
                                        SendHospital = d.SendHospital,
                                        HospitalContent = d.HospitalContent,
                                        SendDate = d.SendDate,
                                        SendBy = d.SendBy,
                                        SendByName = d.SendByName,
                                        TrackRecordId = d.TrackRecordId,
                                    };

                FxPageInfo<TrackReportedVo> trackReportedPageInfo = new FxPageInfo<TrackReportedVo>();
                trackReportedPageInfo.TotalCount = q.TotalCount;
                trackReportedPageInfo.List = trackReported;

                return ResultData<FxPageInfo<TrackReportedVo>>.Success().AddData("trackReportedInfo", trackReportedPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<TrackReportedVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 添加追踪回访提报信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddTrackReportedVo addVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);

                AddTrackReportedDto addDto = new AddTrackReportedDto();
                addDto.Phone = addVo.Phone;
                addDto.SendContent = addVo.SendContent;
                addDto.SendHospitalId = addVo.SendHospitalId;
                addDto.SendBy = employeeId;
                await _trackReportedService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据追踪回访提报编号获取追踪回访提报信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<TrackReportedVo>> GetByIdAsync(string id)
        {
            try
            {
                var trackReported = await _trackReportedService.GetByIdAsync(id);
                TrackReportedVo trackReportedVo = new TrackReportedVo();
                trackReportedVo.Id = trackReported.Id;
                trackReportedVo.Phone = trackReported.Phone;
                trackReportedVo.SendStatus = (int)SendStatus.UnSend;
                trackReportedVo.SendContent = trackReported.SendContent;
                trackReportedVo.SendHospitalId = trackReported.SendHospitalId;
                trackReportedVo.HospitalContent = trackReported.HospitalContent;
                trackReportedVo.TrackRecordId = trackReported.TrackRecordId;
                return ResultData<TrackReportedVo>.Success().AddData("trackReportedInfo", trackReportedVo);
            }
            catch (Exception ex)
            {
                return ResultData<TrackReportedVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改追踪回访提报信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateTrackReportedVo updateVo)
        {
            try
            {
                UpdateTrackReportedDto updateDto = new UpdateTrackReportedDto();
                updateDto.Id = updateVo.Id;
                updateDto.Phone = updateVo.Phone;
                updateDto.SendContent = updateVo.SendContent;
                updateDto.SendHospitalId = updateVo.SendHospitalId;
                await _trackReportedService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除追踪回访提报信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await _trackReportedService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        #endregion

        #region 【医院端】

        /// <summary>
        /// 医院端获取追踪回访提报信息列表（分页）--[待处理]
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="keyword">关键词（查询手机号与提报内容）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("hospitalSendedListWithPage")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<TrackReportedVo>>> GetHospitalUnTrackListWithPageAsync(DateTime? startDate, DateTime? endDate, string keyword, int pageNum, int pageSize)
        {
            try
            {
                var hospital = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
                int hospitalId = Convert.ToInt32(hospital.HospitalId);
                var q = await _trackReportedService.GetHospitalUnTrackListWithPageAsync(startDate, endDate, hospitalId, keyword, pageNum, pageSize);

                var trackReported = from d in q.List
                                    select new TrackReportedVo
                                    {
                                        Id = d.Id,
                                        Phone = d.Phone,
                                        EncryptPhone = d.EncryptPhone,
                                        SendStatus = d.SendStatus,
                                        SendStatusText = d.SendStatusText,
                                        SendContent = d.SendContent,
                                        SendHospitalId = d.SendHospitalId,
                                        SendHospital = d.SendHospital,
                                        HospitalContent = d.HospitalContent,
                                        SendDate = d.SendDate,
                                        SendBy = d.SendBy,
                                        SendByName = d.SendByName,
                                        TrackRecordId = d.TrackRecordId,
                                    };

                FxPageInfo<TrackReportedVo> trackReportedPageInfo = new FxPageInfo<TrackReportedVo>();
                trackReportedPageInfo.TotalCount = q.TotalCount;
                trackReportedPageInfo.List = trackReported;

                return ResultData<FxPageInfo<TrackReportedVo>>.Success().AddData("trackReportedInfo", trackReportedPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<TrackReportedVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 医院端获取追踪回访提报信息列表（分页）--[已处理]
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="isSendStatusFinished">处理是否成功</param>
        /// <param name="keyword">关键词（查询手机号与提报内容）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("hospitalDealedListWithPage")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<TrackReportedVo>>> GetHospitalDealedListWithPageAsync(DateTime? startDate, DateTime? endDate, bool? isSendStatusFinished, string keyword, int pageNum, int pageSize)
        {
            try
            {
                int? sendStatus = null;
                var hospital = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
                int hospitalId = Convert.ToInt32(hospital.HospitalId);
                if (isSendStatusFinished.HasValue)
                {
                    switch (isSendStatusFinished)
                    {
                        case true:
                            sendStatus = (int)SendStatus.FollowUpFinished;
                            break;

                        case false:
                            sendStatus = (int)SendStatus.FollowUpFailed;
                            break;
                    }
                }
                var q = await _trackReportedService.GetHospitalDealedListWithPageAsync(startDate, endDate, sendStatus, hospitalId, keyword, pageNum, pageSize);

                var trackReported = from d in q.List
                                    select new TrackReportedVo
                                    {
                                        Id = d.Id,
                                        Phone = d.Phone,
                                        SendStatus = d.SendStatus,
                                        SendStatusText = d.SendStatusText,
                                        SendContent = d.SendContent,
                                        SendHospitalId = d.SendHospitalId,
                                        SendHospital = d.SendHospital,
                                        HospitalContent = d.HospitalContent,
                                        SendDate = d.SendDate,
                                        SendBy = d.SendBy,
                                        SendByName = d.SendByName,
                                        TrackRecordId = d.TrackRecordId,
                                    };

                FxPageInfo<TrackReportedVo> trackReportedPageInfo = new FxPageInfo<TrackReportedVo>();
                trackReportedPageInfo.TotalCount = q.TotalCount;
                trackReportedPageInfo.List = trackReported;

                return ResultData<FxPageInfo<TrackReportedVo>>.Success().AddData("trackReportedInfo", trackReportedPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<TrackReportedVo>>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 医院端确认是否跟进
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>  
        [HttpPost("hospitalConfirTrackRecord")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> HospitalConfirTrackRecordAsync(HospitalConfirmTrackRecordedVo addVo)
        {

            HospitalConfirmTrackRecordedDto addDto = new HospitalConfirmTrackRecordedDto();
            addDto.Id = addVo.Id;
            addDto.IsTrackedResult = addVo.IsTrackedResult;
            addDto.HospitalContent = addVo.HospitalContent;
            AddTrackRecordDto addTrackRecordDto = new AddTrackRecordDto();
            addTrackRecordDto.WaitTrackId = addVo.addTrackRecord.WaitTrackId;
            addTrackRecordDto.EncryptPhone = addVo.addTrackRecord.EncryptPhone;
            addTrackRecordDto.TrackContent = addVo.addTrackRecord.TrackContent;
            addTrackRecordDto.TrackToolId = addVo.addTrackRecord.TrackToolId;
            addTrackRecordDto.TrackPlan ="【医院跟进】"+ addVo.addTrackRecord.TrackPlan;
            addTrackRecordDto.TrackTypeId = addVo.addTrackRecord.TrackTypeId;
            addTrackRecordDto.TrackThemeId = addVo.addTrackRecord.TrackThemeId;
            addTrackRecordDto.Valid = addVo.addTrackRecord.Valid;
            addTrackRecordDto.CallRecordId = addVo.addTrackRecord.CallRecordId;
            addTrackRecordDto.IsOldCustomerTrack = addVo.addTrackRecord.IsOldCustomerTrack;
            addTrackRecordDto.IsAddWechat = addVo.addTrackRecord.IsAddWechat;
            addTrackRecordDto.UnAddWechatReasonId = addVo.addTrackRecord.UnAddWechatReasonId;
            addTrackRecordDto.TrackPicture1 = addVo.addTrackRecord.TrackPicture1;
            addTrackRecordDto.TrackPicture2 = addVo.addTrackRecord.TrackPicture2;
            addTrackRecordDto.TrackPicture3 = addVo.addTrackRecord.TrackPicture3;
            addDto.addTrackRecord = addTrackRecordDto;
           
            await _trackReportedService.HospitalConfirTrackRecordAsync(addDto);
            return ResultData.Success();

        }

        #endregion


        #region [其他]

        /// <summary>
        /// 获取提报状态列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("sendStatusText")]
        public ResultData<List<OrderAppTypeVo>> GetSendStatusTextList()
        {
            var orderAppTypes = from d in _trackReportedService.GetSendStatusTextList()
                                select new OrderAppTypeVo
                                {
                                    OrderType = d.OrderType,
                                    AppTypeText = d.AppTypeText
                                };
            return ResultData<List<OrderAppTypeVo>>.Success().AddData("sendStatus", orderAppTypes.ToList());
        }
        #endregion
    }
}
