using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.CallRecord;
using Fx.Amiya.Background.Api.Vo.Track;
using Fx.Amiya.Background.Api.Vo.Track.Input;
using Fx.Amiya.Dto.Track;
using Fx.Amiya.Dto.TrackTypeThemeModel;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Infrastructure.DataAccess.Mongodb.Standard;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private ITrackService trackService;
        private IHttpContextAccessor httpContextAccessor;
        private IMongoRepository<CallRecordVo> repository;
        public TrackController(ITrackService trackService,
            IHttpContextAccessor httpContextAccessor,
            IMongoRepository<CallRecordVo> repository)
        {
            this.trackService = trackService;
            this.httpContextAccessor = httpContextAccessor;
            this.repository = repository;
        }




        /// <summary>
        /// 获取回访类型列表（分页）
        /// </summary>
        /// <param name="query">查询类</param>
        /// <returns></returns>
        [HttpGet("typeListWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<TrackTypeVo>>> GetTrackTypeListWithPageAsync([FromQuery] QueryTarckVo query)
        {
            var q = await trackService.GetTrackTypeListWithPageAsync(query.Valid, query.PageNum.Value, query.PageSize.Value);
            var trackType = from d in q.List
                            select new TrackTypeVo
                            {
                                Id = d.Id,
                                Name = d.Name,
                                Valid = d.Valid,
                                HasModel = d.HasModel,
                                IsOldCustomer = d.IsOldCustomer
                            };
            FxPageInfo<TrackTypeVo> trackTypePageInfo = new FxPageInfo<TrackTypeVo>();
            trackTypePageInfo.TotalCount = q.TotalCount;
            trackTypePageInfo.List = trackType;
            return ResultData<FxPageInfo<TrackTypeVo>>.Success().AddData("trackType", trackTypePageInfo);
        }







        /// <summary>
        /// 获取有效的回访类型列表
        ///  <param name="isOldCustomer">true:老客,false:新客</param>
        /// </summary>
        /// <returns></returns>
        [HttpGet("typeList")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<TrackTypeVo>>> GetTrackTypeListAsync(bool? isOldCustomer)
        {
            var trackType = from d in await trackService.GetTrackTypeListAsync(isOldCustomer)
                            select new TrackTypeVo
                            {
                                Id = d.Id,
                                Name = d.Name,
                                Valid = d.Valid,
                                HasModel = d.HasModel,
                            };
            return ResultData<List<TrackTypeVo>>.Success().AddData("trackType", trackType.ToList());
        }





        /// <summary>
        /// 添加回访类型
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("type")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddTrackTypeAsync(AddTrackTypeVo addVo)
        {
            AddTrackTypeDto addDto = new AddTrackTypeDto();
            addDto.Name = addVo.Name;
            addDto.HasModel = addVo.HasModel;
            addDto.IsOldCustomer = addVo.IsOldCustomer;
            if (addVo.HasModel == true)
            {
                List<AddTrackTypeThemeModelDto> trackTypeThemeModelDto = new List<AddTrackTypeThemeModelDto>();
                foreach (var x in addVo.TrackTypeThemeModelVo)
                {
                    AddTrackTypeThemeModelDto dto = new AddTrackTypeThemeModelDto();
                    dto.TrackTypeId = x.TrackTypeId;
                    dto.TrackThemeId = x.TrackThemeId;
                    dto.DaysLater = x.DaysLater;
                    dto.TrackPlan = x.TrackPlan;
                    trackTypeThemeModelDto.Add(dto);
                }
                addDto.TrackTypeThemeModelDto = trackTypeThemeModelDto;
            }
            await trackService.AddTrackTypeAsync(addDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 根据编号获取回访类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<TrackTypeVo>> GetByIdAsync(int id)
        {
            var trackType = await trackService.GetbyIdAsync(id);
            TrackTypeVo trackTypeVo = new TrackTypeVo();
            trackTypeVo.Id = trackType.Id;
            trackTypeVo.Name = trackType.Name;
            trackTypeVo.HasModel = trackType.HasModel;
            trackTypeVo.IsOldCustomer = trackType.IsOldCustomer;
            trackTypeVo.Valid = trackType.Valid;
            List<TrackTypeThemeModelVo> trackTypeThemeModel = new List<TrackTypeThemeModelVo>();
            foreach (var x in trackType.TrackTypeThemeModelDto)
            {
                TrackTypeThemeModelVo resutModel = new TrackTypeThemeModelVo();
                resutModel.Id = x.Id;
                resutModel.TrackTypeId = x.TrackTypeId;
                resutModel.TrackTypeName = x.TrackTypeName;
                resutModel.TrackThemeId = x.TrackThemeId;
                resutModel.TrackThemeName = x.TrackThemeName;
                resutModel.DaysLater = x.DaysLater;
                resutModel.TrackPlan = x.TrackPlan;
                trackTypeThemeModel.Add(resutModel);
            }
            trackTypeVo.TrackTypeThemeModel = trackTypeThemeModel;
            return ResultData<TrackTypeVo>.Success().AddData("giftInfo", trackTypeVo);
        }



        /// <summary>
        /// 修改回访类型
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("type")]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateTrackTypeAsync(UpdateTrackTypeVo updateVo)
        {
            UpdateTrackTypeDto updateDto = new UpdateTrackTypeDto();
            updateDto.Id = updateVo.Id;
            updateDto.Name = updateVo.Name;
            updateDto.Valid = updateVo.Valid;
            updateDto.HasModel = updateVo.HasModel;
            updateDto.IsOldCustomer = updateVo.IsOldCustomer;
            if (updateVo.HasModel == true)
            {
                List<AddTrackTypeThemeModelDto> trackTypeThemeModelDto = new List<AddTrackTypeThemeModelDto>();
                foreach (var x in updateVo.TrackTypeThemeModelVo)
                {
                    AddTrackTypeThemeModelDto dto = new AddTrackTypeThemeModelDto();
                    dto.TrackTypeId = x.TrackTypeId;
                    dto.TrackThemeId = x.TrackThemeId;
                    dto.DaysLater = x.DaysLater;
                    dto.TrackPlan = x.TrackPlan;
                    trackTypeThemeModelDto.Add(dto);
                }
                updateDto.AddTrackTypeThemeModelDto = trackTypeThemeModelDto;
            }
            await trackService.UpdateTrackTypeAsync(updateDto);
            return ResultData.Success();
        }





        /// <summary>
        /// 删除回访类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("type/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteTrackTypeAsync(int id)
        {
            await trackService.DeleteTrackTypeAsync(id);
            return ResultData.Success();
        }






        /// <summary>
        /// 获取回访工具列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("toolListWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<TrackToolVo>>> GetTrackToolListWithPageAsync([FromQuery] QueryTarckVo query)
        {
            var q = await trackService.GetTrackToolListWithPageAsync(query.Valid, query.PageNum.Value, query.PageSize.Value);
            var trackTool = from d in q.List
                            select new TrackToolVo
                            {
                                Id = d.Id,
                                Name = d.Name,
                                Valid = d.Valid
                            };
            FxPageInfo<TrackToolVo> trackToolPageInfo = new FxPageInfo<TrackToolVo>();
            trackToolPageInfo.TotalCount = q.TotalCount;
            trackToolPageInfo.List = trackTool;
            return ResultData<FxPageInfo<TrackToolVo>>.Success().AddData("trackTool", trackToolPageInfo);
        }





        /// <summary>
        /// 获取有效的回访工具列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("toolList")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<TrackToolVo>>> GetTrackToolListAsync()
        {
            var trackTool = from d in await trackService.GetTrackToolListAsync()
                            select new TrackToolVo
                            {
                                Id = d.Id,
                                Name = d.Name,
                                Valid = d.Valid
                            };
            return ResultData<List<TrackToolVo>>.Success().AddData("trackTool", trackTool.ToList());
        }





        /// <summary>
        /// 添加回访工具
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("tool")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddTrackToolAsync(AddTrackToolVo addVo)
        {
            AddTrackToolDto addDto = new AddTrackToolDto();
            addDto.Name = addVo.Name;
            await trackService.AddTrackToolAsync(addDto);
            return ResultData.Success();
        }





        /// <summary>
        /// 修改回访工具
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("tool")]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateTrackToolAsync(UpdateTrackToolVo updateVo)
        {
            UpdateTrackToolDto updateDto = new UpdateTrackToolDto();
            updateDto.Id = updateVo.Id;
            updateDto.Name = updateVo.Name;
            updateDto.Valid = updateVo.Valid;
            await trackService.UpdateTrackToolAsync(updateDto);
            return ResultData.Success();
        }





        /// <summary>
        /// 删除回访工具
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("tool/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteTrackToolAsync(int id)
        {
            await trackService.DeleteTrackToolAsync(id);
            return ResultData.Success();
        }






        /// <summary>
        /// 获取回访记录（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isOldCustomerTrack">新/老客回访</param>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("recordListWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<TrackRecordVo>>> GetRecordListWithPageAsync(string keyword, DateTime? startDate, DateTime? endDate, int? employeeId, bool? isOldCustomerTrack, int pageNum, int pageSize)
        {
            try
            {
                if (employeeId == null)
                {
                    var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                    employeeId = Convert.ToInt32(employee.Id);
                }

                var q = await trackService.GetRecordListWithPageAsync(keyword, startDate, endDate, (int)employeeId, isOldCustomerTrack, pageNum, pageSize);

                var trackRecord = from d in q.List
                                  select new TrackRecordVo
                                  {
                                      Id = d.Id,
                                      Phone = d.Phone,
                                      EncryptPhone = d.EncryptPhone,
                                      TrackDate = d.TrackDate,
                                      TrackContent = d.TrackContent,
                                      TrackThemeId = d.TrackThemeId,
                                      TrackPlan = d.TrackPlan,
                                      TrackTheme = d.TrackTheme,
                                      TrackTypeId = d.TrackTypeId,
                                      TrackTypeName = d.TrackTypeName,
                                      TrackToolId = d.TrackToolId,
                                      TrackToolName = d.TrackToolName,
                                      EmployeeId = d.EmployeeId,
                                      EmployeeName = d.EmployeeName,
                                      Valid = d.Valid,
                                      CallRecordId = d.CallRecordId,
                                      TrackPicture1 = d.TrackPicture1,
                                      TrackPicture2 = d.TrackPicture2,
                                      TrackPicture3 = d.TrackPicture3,
                                      IsOldCustomerTrack = d.IsOldCustomerTrack
                                  };

                FxPageInfo<TrackRecordVo> trackRecordPageInfo = new FxPageInfo<TrackRecordVo>();
                trackRecordPageInfo.TotalCount = q.TotalCount;
                trackRecordPageInfo.List = trackRecord;
                return ResultData<FxPageInfo<TrackRecordVo>>.Success().AddData("trackRecord", trackRecordPageInfo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }






        /// <summary>
        /// 根据加密电话文本获取回访记录列表（分页）
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <param name="shoppingCartRegistionId">小黄车登记列表id（可空）</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("recordListByEncryptPhone")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<TrackRecordVo>>> GetRecordListByEncryptPhoneWithPageAsync(string encryptPhone, string shoppingCartRegistionId, int pageNum, int pageSize)
        {
            var q = await trackService.GetRecordListByEncryptPhoneWithPageAsync(encryptPhone, shoppingCartRegistionId, pageNum, pageSize);

            var trackRecord = from d in q.List
                              select new TrackRecordVo
                              {
                                  Id = d.Id,
                                  Phone = d.Phone,
                                  TrackDate = d.TrackDate,
                                  TrackContent = d.TrackContent,
                                  TrackTheme = d.TrackTheme,
                                  TrackThemeId = d.TrackThemeId,
                                  TrackTypeId = d.TrackTypeId,
                                  TrackTypeName = d.TrackTypeName,
                                  TrackPlan = d.TrackPlan,
                                  TrackToolId = d.TrackToolId,
                                  TrackToolName = d.TrackToolName,
                                  EmployeeId = d.EmployeeId,
                                  EmployeeName = d.EmployeeName,
                                  Valid = d.Valid,
                                  CallRecordId = d.CallRecordId,
                                  IsPlanTrack = d.IsPlanTrack,
                                  PlanTrackTheme = d.PlanTrackTheme,
                                  TrackPicture1 = d.TrackPicture1,
                                  TrackPicture2 = d.TrackPicture2,
                                  TrackPicture3 = d.TrackPicture3,
                                  IsOldCustomerTrack = d.IsOldCustomerTrack,
                                  IsAddWechat = d.IsAddWechat,
                                  UnAddWechatReason = d.UnAddWechatReason,
                                  UnAddWechatReasonId = d.UnAddWechatReasonId
                              };
            FxPageInfo<TrackRecordVo> trackRecordPageInfo = new FxPageInfo<TrackRecordVo>();
            trackRecordPageInfo.TotalCount = q.TotalCount;
            trackRecordPageInfo.List = trackRecord;
            return ResultData<FxPageInfo<TrackRecordVo>>.Success().AddData("trackRecord", trackRecordPageInfo);
        }






        /// <summary>
        /// 添加回访记录
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>  
        [HttpPost("trackRecord")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> AddTrackRecordAsync(AddTrackRecordVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);

            AddTrackRecordDto addDto = new AddTrackRecordDto();
            addDto.WaitTrackId = addVo.WaitTrackId;
            addDto.EncryptPhone = addVo.EncryptPhone;
            addDto.TrackContent = addVo.TrackContent;
            addDto.TrackToolId = addVo.TrackToolId;
            addDto.TrackPlan = addVo.TrackPlan;
            addDto.TrackTypeId = addVo.TrackTypeId;
            addDto.TrackThemeId = addVo.TrackThemeId;
            addDto.Valid = addVo.Valid;
            addDto.CallRecordId = addVo.CallRecordId;
            addDto.TrackPicture1 = addVo.TrackPicture1;
            addDto.TrackPicture2 = addVo.TrackPicture2;
            addDto.TrackPicture3 = addVo.TrackPicture3;
            addDto.ShoppingCartRegistionId = addVo.ShoppingCartRegistionId;
            addDto.IsOldCustomerTrack = addVo.IsOldCustomerTrack;
            addDto.IsAddWechat = addVo.IsAddWechat;
            addDto.UnAddWechatReasonId = addVo.UnAddWechatReasonId;
            List<AddWaitTrackCustomerDto> waitTrackRecordList = new List<AddWaitTrackCustomerDto>();
            if (addVo.AddWaitTrackCustomer != null)
            {
                foreach (var x in addVo.AddWaitTrackCustomer)
                {
                    AddWaitTrackCustomerDto addList = new AddWaitTrackCustomerDto();
                    addList = new AddWaitTrackCustomerDto()
                    {
                        PlanTrackDate = x.PlanTrackDate,
                        TrackTypeId = x.TrackTypeId,
                        TrackThemeId = x.TrackThemeId,
                        OtherTrackEmployeeId = x.OtherTrackEmployeeId,
                        TrackPlan = x.TrackPlan
                    };
                    waitTrackRecordList.Add(addList);
                }
            }
            addDto.AddWaitTrackCustomer = waitTrackRecordList;
            int result = await trackService.AddTrackRecordAsync(addDto, employeeId);
            return ResultData.Success();

        }

        /// <summary>
        /// 添加回访记录(医院端)
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>  
        [HttpPost("trackRecordByHospital")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> AddTrackRecordByHospitalAsync(AddTrackRecordVo addVo)
        {
           

            AddTrackRecordDto addDto = new AddTrackRecordDto();
            addDto.WaitTrackId = addVo.WaitTrackId;
            addDto.EncryptPhone = addVo.EncryptPhone;
            addDto.TrackContent = addVo.TrackContent;
            addDto.TrackToolId = addVo.TrackToolId;
            addDto.TrackPlan = addVo.TrackPlan;
            addDto.TrackTypeId = addVo.TrackTypeId;
            addDto.TrackThemeId = addVo.TrackThemeId;
            addDto.Valid = addVo.Valid;
            addDto.CallRecordId = addVo.CallRecordId;
            addDto.TrackPicture1 = addVo.TrackPicture1;
            addDto.TrackPicture2 = addVo.TrackPicture2;
            addDto.TrackPicture3 = addVo.TrackPicture3;
            addDto.ShoppingCartRegistionId = addVo.ShoppingCartRegistionId;
            addDto.IsOldCustomerTrack = addVo.IsOldCustomerTrack;
            addDto.IsAddWechat = addVo.IsAddWechat;
            addDto.UnAddWechatReasonId = addVo.UnAddWechatReasonId;
            List<AddWaitTrackCustomerDto> waitTrackRecordList = new List<AddWaitTrackCustomerDto>();
            if (addVo.AddWaitTrackCustomer != null)
            {
                foreach (var x in addVo.AddWaitTrackCustomer)
                {
                    AddWaitTrackCustomerDto addList = new AddWaitTrackCustomerDto();
                    addList = new AddWaitTrackCustomerDto()
                    {
                        PlanTrackDate = x.PlanTrackDate,
                        TrackTypeId = x.TrackTypeId,
                        TrackThemeId = x.TrackThemeId,
                        OtherTrackEmployeeId = x.OtherTrackEmployeeId,
                        TrackPlan = x.TrackPlan
                    };
                    waitTrackRecordList.Add(addList);
                }
            }
            addDto.AddWaitTrackCustomer = waitTrackRecordList;
            //线上改为266
            int result = await trackService.AddTrackRecordAsync(addDto, 193);
            return ResultData.Success();

        }



        /// <summary>
        /// 获取待回访列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("waitTrackListWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<WaitTrackCustomerVo>>> GetWaitTrackListWithPageAsync(string keyword, DateTime? startDate, DateTime? endDate, int? employeeId, int pageNum, int pageSize)
        {
            if (employeeId == null)
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
            }

            var q = await trackService.GetWaitTrackListWithPageAsync(keyword, startDate, endDate, (int)employeeId, pageNum, pageSize);

            var waitTrack = from d in q.List
                            select new WaitTrackCustomerVo
                            {
                                Id = d.Id,
                                Phone = d.Phone,
                                EncryptPhone = d.EncryptPhone,
                                PlanTrackDate = d.PlanTrackDate,
                                TrackTypeId = d.TrackTypeId,
                                TrackTypeName = d.TrackTypeName,
                                TrackThemeId = d.TrackThemeId,
                                TrackPlan = d.TrackPlan,
                                TrackTheme = d.TrackTheme,
                                CreateDate = d.CreateDate,
                                CreateBy = d.CreateBy,
                                CreateName = d.CreateName,
                                Status = d.Status,
                                PlanTrackEmployeeId = d.PlanTrackEmployeeId,
                                PlanTrackEnmployeeName = d.PlanTrackEnmployeeName
                            };
            FxPageInfo<WaitTrackCustomerVo> waitTrackPageInfo = new FxPageInfo<WaitTrackCustomerVo>();
            waitTrackPageInfo.TotalCount = q.TotalCount;
            waitTrackPageInfo.List = waitTrack;
            return ResultData<FxPageInfo<WaitTrackCustomerVo>>.Success().AddData("waitTrack", waitTrackPageInfo);
        }
        /// <summary>
        /// 未加V原因
        /// </summary>
        /// <returns></returns>
        [HttpGet("unAddWechatReasonNameList")]
        [FxInternalOrPartnerAuthorize]
        public async Task<ResultData<List<BaseIdAndNameVo<int>>>> GetUnAddWechatReasonNameListAsync()
        {
            var res = await trackService.GetUnAddWechatReasonNameListAsync();
            var nameList = res.Select(e => new BaseIdAndNameVo<int>
            {
                Id = e.Key,
                Name = e.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo<int>>>.Success().AddData("nameList", nameList);
        }
    }
}