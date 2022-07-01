using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.Activity;
using Fx.Amiya.Dto.Activity;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Identity.Core;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class ActivityController : ControllerBase
    {
        private IActivityService activityService;
        private IHttpContextAccessor httpContextAccessor;
        public ActivityController(IActivityService activityService, IHttpContextAccessor httpContextAccessor)
        {
            this.activityService = activityService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取报价活动列表（分页）
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="activityName"></param>
        /// <param name="status">null:全部，0：已完成，1：未完成</param>
        /// <param name="valid">bool类型，默认筛选true</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("infoListWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<ActivityInfoVo>>> GetInfoListWithPageAsync(DateTime? startDate, DateTime? endDate, string activityName, int? status,bool valid, int pageNum, int pageSize)
        {
            var q = await activityService.GetInfoListWithPageAsync(startDate, endDate, activityName, status,valid, pageNum, pageSize);
            var activity = from d in q.List
                           select new ActivityInfoVo
                           {
                               Id = d.Id,
                               Name = d.Name,
                               Description = d.Description,
                               StartDate = d.StartDate,
                               EndDate = d.EndDate,
                               Valid = d.Valid,
                               CreateBy = d.CreateBy,
                               CreateName = d.CreateName,
                               CreateDate = d.CreateDate,
                               UpdateBy = d.UpdateBy,
                               UpdateName = d.UpdateName,
                               UpdateDate = d.UpdateDate
                           };
            FxPageInfo<ActivityInfoVo> activityPageInfo = new FxPageInfo<ActivityInfoVo>();
            activityPageInfo.TotalCount = q.TotalCount;
            activityPageInfo.List = activity;
            return ResultData<FxPageInfo<ActivityInfoVo>>.Success().AddData("activity", activityPageInfo);
        }



        /// <summary>
        /// 获取有效的活动信息列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("validInfoList")]
        [FxTenantAuthorize]
        public async Task<ResultData<FxPageInfo<ActivityInfoSimpleVo>>> GetValidListAsync(int pageNum, int pageSize)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            
            var activityPage = await activityService.GetValidListAsync(employee.HospitalId, pageNum, pageSize);
            var activityInfos = from d in activityPage.List
                                select new ActivityInfoSimpleVo
                                {
                                    Id = d.Id,
                                    Name = d.Name,
                                    Description = d.Description,
                                    StartDate = d.StartDate,
                                    EndDate = d.EndDate,
                                    IsPartake = d.IsPartake,
                                };
            FxPageInfo<ActivityInfoSimpleVo> activityPageInfo = new FxPageInfo<ActivityInfoSimpleVo>();
            activityPageInfo.TotalCount = activityPage.TotalCount;
            activityPageInfo.List = activityInfos;
            return ResultData<FxPageInfo<ActivityInfoSimpleVo>>.Success().AddData("activity", activityPageInfo);
        }





        /// <summary>
        /// 添加报价活动信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("info")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddInfoAsync(AddActivityInfoVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            AddActivityInfoDto addDto = new AddActivityInfoDto();
            addDto.Name = addVo.Name;
            addDto.Description = addVo.Description;
            addDto.StartDate = addVo.StartDate;
            addDto.EndDate = addVo.EndDate;
            await activityService.AddInfoAsync(addDto, employeeId);
            return ResultData.Success();
        }


        /// <summary>
        /// 根据活动编号获取报价活动信息
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        [HttpGet("infoById/{activityId}")]
        [FxInternalAuthorize]
        public async Task<ResultData<ActivityInfoVo>> GetInfoByIdAsync(int activityId)
        {
            var activity = await activityService.GetInfoByIdAsync(activityId);
            ActivityInfoVo activityInfoVo = new ActivityInfoVo();
            activityInfoVo.Id = activity.Id;
            activityInfoVo.Name = activity.Name;
            activityInfoVo.Description = activity.Description;
            activityInfoVo.StartDate = activity.StartDate;
            activityInfoVo.EndDate = activity.EndDate;
            activityInfoVo.Valid = activity.Valid;
            activityInfoVo.CreateBy = activity.CreateBy;
            activityInfoVo.CreateName = activity.CreateName;
            activityInfoVo.CreateDate = activity.CreateDate;
            activityInfoVo.UpdateBy = activity.UpdateBy;
            activityInfoVo.UpdateName = activity.UpdateName;
            activityInfoVo.UpdateDate = activity.UpdateDate;
            return ResultData<ActivityInfoVo>.Success().AddData("activity", activityInfoVo);
        }


        /// <summary>
        /// 修改报价活动
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("info")]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateInfoAsync(UpdateActivityInfoVo updateVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            UpdateActivityInfoDto updateDto = new UpdateActivityInfoDto();
            updateDto.Id = updateVo.Id;
            updateDto.Name = updateVo.Name;
            updateDto.Description = updateVo.Description;
            updateDto.StartDate = updateVo.StartDate;
            updateDto.EndDate = updateVo.EndDate;
            updateDto.Valid = updateVo.Valid;

            await activityService.UpdateInfoAsync(updateDto, employeeId);
            return ResultData.Success();
        }



        /// <summary>
        /// 删除报价活动
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        [HttpDelete("info/{activityId}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteInfoAsync(int activityId)
        {
            await activityService.DeleteInfoAsync(activityId);
            return ResultData.Success();
        }


        /// <summary>
        /// 批量添加活动报价项目
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("detailList")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddDetailAsync(AddActivityItemDetailVo addVo)
        {
            List<AddActivityItemDto> addActivityItemDtoList = new List<AddActivityItemDto>();
            foreach (var item in addVo.ActivityItemList)
            {
                AddActivityItemDto addActivityItemDto = new AddActivityItemDto();
                addActivityItemDto.ItemId = item.ItemId;
                addActivityItemDto.SalePrice = item.SalePrice; 
                addActivityItemDto.LivePrice = item.LivePrice;
                addActivityItemDtoList.Add(addActivityItemDto);
            }

            AddActivityItemDetailDto addDto = new AddActivityItemDetailDto();
            addDto.ActivityId = addVo.ActivityId;
            addDto.AddActivityItemList = addActivityItemDtoList;

            await activityService.AddDetailAsync(addDto);
            return ResultData.Success();
        }





        /// <summary>
        /// 根据活动编号获取报价项目列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="activityId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("detailListByActivityIdWithPage")]
        [FxTenantAuthorize]
        public async Task<ResultData<FxPageInfo<ActivityItemDetailVo>>> GetDetailListByActivityIdWithPageAsync(string keyword, int activityId, int pageNum, int pageSize)
        {
            var q = await activityService.GetDetailListByActivityIdWithPageAsync(keyword, activityId, pageNum, pageSize);
            var itemDetail = from d in q.List
                             select new ActivityItemDetailVo
                             {
                                 Id = d.Id,
                                 ActivityId = d.ActivityId,
                                 ItemId = d.ItemId,
                                 ThumbPicUrl = d.ThumbPicUrl,
                                 Name = d.Name,
                                 Description = d.Description,
                                 Standard = d.Standard,
                                 Parts = d.Parts,
                                 SalePrice = d.SalePrice,
                                 LivePrice = d.LivePrice,
                                 IsLimitBuy = d.IsLimitBuy,
                                 LimitBuyQuantity = d.LimitBuyQuantity,
                                 Remark = d.Remark
                             };

            FxPageInfo<ActivityItemDetailVo> detailPageInfo = new FxPageInfo<ActivityItemDetailVo>();
            detailPageInfo.TotalCount = q.TotalCount;
            detailPageInfo.List = itemDetail;
            return ResultData<FxPageInfo<ActivityItemDetailVo>>.Success().AddData("activityDetail", detailPageInfo);
        }

        /// <summary>
        /// 根据活动编号获取报价项目列表
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        [HttpGet("detailListByActivityId")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<ActivityItemDetailVo>>> GetDetailListByActivityIdAsync(int activityId)
        {
            var itemDetail = from d in await activityService.GetDetailListByActivityIdAsync(activityId)
                             select new ActivityItemDetailVo
                             {
                                 Id = d.Id,
                                 ActivityId = d.ActivityId,
                                 ItemId = d.ItemId,
                                 ThumbPicUrl = d.ThumbPicUrl,
                                 Name = d.Name,
                                 Description = d.Description,
                                 Standard = d.Standard,
                                 Parts = d.Parts,
                                 SalePrice = d.SalePrice,
                                 LivePrice = d.LivePrice,
                                 IsLimitBuy = d.IsLimitBuy,
                                 LimitBuyQuantity = d.LimitBuyQuantity,
                                 Remark = d.Remark
                             };
            return ResultData<List<ActivityItemDetailVo>>.Success().AddData("activityDetail", itemDetail.ToList());
        }





        /// <summary>
        /// 医院获取参与过的活动列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("hospitalPartakeList")]
        [FxTenantAuthorize]
        public async Task<ResultData<FxPageInfo<ActivityInfoVo>>> GetHospitalPartakeListAsync(string keyword, int pageNum, int pageSize)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;

            int hospitalId = employee.HospitalId;
            var q = await activityService.GetListByHospitalIdAsync(hospitalId, keyword, pageNum, pageSize);
            var activitys = from d in q.List
                            select new ActivityInfoVo
                            {
                                Id = d.Id,
                                Name = d.Name,
                                Description = d.Description,
                                StartDate = d.StartDate,
                                EndDate = d.EndDate,
                                Valid = d.Valid,
                                CreateBy = d.CreateBy,
                                CreateDate = d.CreateDate,
                                CreateName = d.CreateName,
                                UpdateBy = d.UpdateBy,
                                UpdateDate = d.UpdateDate,
                                UpdateName = d.UpdateName
                            };
            FxPageInfo<ActivityInfoVo> activityPageInfo = new FxPageInfo<ActivityInfoVo>();
            activityPageInfo.TotalCount = q.TotalCount;
            activityPageInfo.List = activitys;
            return ResultData<FxPageInfo<ActivityInfoVo>>.Success().AddData("activity", activityPageInfo);
        }



        /// <summary>
        /// 获取所有活动名称列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("nameList")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<ActivityNameVo>>> GetNameListAsync(string keyword, int pageNum, int pageSize)
        {
            var q = await activityService.GetNameListAsync(keyword,pageNum,pageSize);
            var activitys = from d in q.List
                            select new ActivityNameVo
                            { 
                                Id=d.Id,
                                Name=d.Name
                            };
            FxPageInfo<ActivityNameVo> activityPageInfo = new FxPageInfo<ActivityNameVo>();
            activityPageInfo.TotalCount = q.TotalCount;
            activityPageInfo.List = activitys;
            return ResultData<FxPageInfo<ActivityNameVo>>.Success().AddData("activitys",activityPageInfo);
        }
    }
}