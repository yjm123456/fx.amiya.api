
using Fx.Amiya.Background.Api.Vo.LiveRequirementInfo;
using Fx.Amiya.Dto.LiveRequirementInfo;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LiveRequirementInfoController : ControllerBase
    {
        private ILiveRequirementInfoService liveRequirementInfoService;
        private IHttpContextAccessor httpContextAccessor;
        public LiveRequirementInfoController(ILiveRequirementInfoService liveRequirementInfoService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.liveRequirementInfoService = liveRequirementInfoService;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 获取总览数据
        /// </summary>
        /// <returns></returns> 
       [HttpGet("headCollectivityData")]
        public async Task<ResultData<HeadCollectivityDataVo>> GetHeadCollectivityDataAsync()
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var headCollectivityData = await liveRequirementInfoService.GetHeadCollectivityDataAsync(employeeId);
            HeadCollectivityDataVo headCollectivityDataVo = new HeadCollectivityDataVo();
            headCollectivityDataVo.TotalCount = headCollectivityData.TotalCount;
            headCollectivityDataVo.TreatedQuantity = headCollectivityData.TreatedQuantity;
            headCollectivityDataVo.UnTreatedQuantity = headCollectivityData.UnTreatedQuantity;
            headCollectivityDataVo.CancelQuantity = headCollectivityData.CancelQuantity;
            headCollectivityDataVo.TreatedRate = headCollectivityData.TreatedRate;
            headCollectivityDataVo.RequirementTypeRateList = (from d in headCollectivityData.RequirementTypeRateList
                                                              select new RequirementTypeRateVo
                                                              {
                                                                  Id = d.Id,
                                                                  Name = d.Name,
                                                                  RequirementTypeRate = d.RequirementTypeRate
                                                              }).ToList();
            headCollectivityDataVo.AvgResponseHour = headCollectivityData.AvgResponseHour;
            headCollectivityDataVo.AvgExecuteHour = headCollectivityData.AvgExecuteHour;
            headCollectivityDataVo.WaitConfirmFinishQuantity = headCollectivityData.WaitConfirmFinishQuantity;
            return ResultData<HeadCollectivityDataVo>.Success().AddData("headCollectivityData", headCollectivityDataVo);
        }

        /// <summary>
        /// 获取直播需求信息列表（分页）
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="status"></param>
        /// <param name="liveTypeId"></param>
        /// <param name="keyword"></param>
        /// <param name="fansInfo">粉丝信息</param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<LiveRequirementInfoVo>>> GetListWithPageAsync(int pageNum, int pageSize, byte? status, byte? liveTypeId, string keyword,string fansInfo)
        {
            var q = await liveRequirementInfoService.GetListWithPageAsync(pageNum, pageSize, status, liveTypeId, keyword,fansInfo);
            var liveRequirementInfo = from d in q.List
                                      select new LiveRequirementInfoVo
                                      {
                                          Id = d.Id,
                                          CreateDate = d.CreateDate,
                                          CreateBy=d.CreateBy,
                                          CreateName=d.CreateName,
                                          Anchor = d.Anchor,
                                          LiveAnchorId=d.LiveAnchorId,
                                          LiveTypeId = d.LiveTypeId,
                                          LiveTypeName = d.LiveTypeName,
                                          RequirementTypeId = d.RequirementTypeId,
                                          RequirementTypeName = d.RequirementTypeName,
                                          FansInfo = d.FansInfo,
                                          Description = d.Description,
                                          DepartmentId = d.DepartmentId,
                                          DepartmentName = d.DepartmentName,
                                          PriorityLevel = d.PriorityLevel,
                                          PriorityLevelText = d.PriorityLevelText,
                                          Status = d.Status,
                                          StatusText = d.StatusText,
                                          ResponseDate = d.ResponseDate,
                                          ResponseRemark = d.ResponseRemark,
                                          ResponseBy=d.ResponseBy,
                                          ResponseByName=d.ResponseByName,
                                          DecideBy=d.DecideBy,
                                          DecideByName=d.DecideByName,
                                          DecideDate=d.DecideDate,
                                          DecideRemark=d.DecideRemark,
                                          ExecuteDate = d.ExecuteDate,
                                          ExecuteRemark = d.ExecuteRemark,
                                          ExecuteBy = d.ExecuteBy,
                                          ExecuteByName = d.ExecuteByName
                                      };
            FxPageInfo<LiveRequirementInfoVo> requirementPageInfo = new FxPageInfo<LiveRequirementInfoVo>();
            requirementPageInfo.TotalCount = q.TotalCount;
            requirementPageInfo.List = liveRequirementInfo;
            return ResultData<FxPageInfo<LiveRequirementInfoVo>>.Success().AddData("liveRequirement", requirementPageInfo);
        }


        /// <summary>
        /// 添加直播需求
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ResultData> AddAsync(AddLiveRequirementInfoVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            AddLiveRequirementInfoDto addDto = new AddLiveRequirementInfoDto();
            addDto.LiveAnchorId = addVo.LiveAnchorId;
            addDto.LiveTypeId = addVo.LiveTypeId;
            addDto.RequirementTypeId = addVo.RequirementTypeId;
            addDto.FansInfo = addVo.FansInfo;
            addDto.Description = addVo.Description;
            addDto.DepartmentId = addVo.DepartmentId;
            addDto.PriorityLevel = addVo.PriorityLevel;
            await liveRequirementInfoService.AddAsync(addDto, employeeId);
            return ResultData.Success();
        }



        /// <summary>
        /// 修改需求信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateLiveRequirementInfoVo updateVo)
        {
            UpdateLiveRequirementInfoDto updateDto = new UpdateLiveRequirementInfoDto();
            updateDto.Id = updateVo.Id;
            updateDto.LiveAnchorId = updateVo.LiveAnchorId;
            updateDto.LiveTypeId = updateVo.LiveTypeId;
            updateDto.RequirementTypeId = updateVo.RequirementTypeId;
            updateDto.FansInfo = updateVo.FansInfo;
            updateDto.Description = updateVo.Description;
            updateDto.DepartmentId = updateVo.DepartmentId;
            updateDto.PriorityLevel = updateVo.PriorityLevel;
            await liveRequirementInfoService.UpdateAsync(updateDto);
            return ResultData.Success();
        }



        /// <summary>
        /// 获取未响应的需求列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("unResponseList")]
        public async Task<ResultData<FxPageInfo<UnResponseLiveRequirementInfoVo>>> GetUnResponseRequirementListAsync(int pageNum, int pageSize)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int departmentId = Convert.ToInt32(employee.DepartmentId);
            var q = await liveRequirementInfoService.GetUnResponseRequirementListAsync(pageNum, pageSize, departmentId);
            var liveRequirementInfo = from d in q.List
                                      select new UnResponseLiveRequirementInfoVo
                                      {
                                          Id = d.Id,
                                          CreateDate = d.CreateDate,
                                          CreateBy=d.CreateBy,
                                          CreateName=d.CreateName,
                                          Anchor = d.Anchor,
                                          LiveTypeId = d.LiveTypeId,
                                          LiveTypeName = d.LiveTypeName,
                                          RequirementTypeId = d.RequirementTypeId,
                                          RequirementTypeName = d.RequirementTypeName,
                                          FansInfo = d.FansInfo,
                                          Description = d.Description,
                                          DepartmentId = d.DepartmentId,
                                          DepartmentName = d.DepartmentName,
                                          PriorityLevel = d.PriorityLevel,
                                          PriorityLevelText = d.PriorityLevelText,
                                          Status = d.Status,
                                          StatusText = d.StatusText,

                                      };
            FxPageInfo<UnResponseLiveRequirementInfoVo> requirementPageInfo = new FxPageInfo<UnResponseLiveRequirementInfoVo>();
            requirementPageInfo.TotalCount = q.TotalCount;
            requirementPageInfo.List = liveRequirementInfo;
            return ResultData<FxPageInfo<UnResponseLiveRequirementInfoVo>>.Success().AddData("liveRequirement", requirementPageInfo);
        }




        /// <summary>
        /// 获取部门已拒绝的需求
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("unRefuseList")]
        public async Task<ResultData<FxPageInfo<LiveRequirementInfoVo>>> GetRefuseRequirementListAsync(int pageNum, int pageSize)
        {
            var q = await liveRequirementInfoService.GetRefuseRequirementListAsync(pageNum, pageSize);
            var liveRequirementInfo = from d in q.List
                                      select new LiveRequirementInfoVo
                                      {
                                          Id = d.Id,
                                          CreateDate = d.CreateDate,
                                          CreateBy=d.CreateBy,
                                          CreateName=d.CreateName,
                                          Anchor = d.Anchor,
                                          LiveAnchorId=d.LiveAnchorId,
                                          LiveTypeId = d.LiveTypeId,
                                          LiveTypeName = d.LiveTypeName,
                                          RequirementTypeId = d.RequirementTypeId,
                                          RequirementTypeName = d.RequirementTypeName,
                                          FansInfo = d.FansInfo,
                                          Description = d.Description,
                                          DepartmentId = d.DepartmentId,
                                          DepartmentName = d.DepartmentName,
                                          PriorityLevel = d.PriorityLevel,
                                          PriorityLevelText = d.PriorityLevelText,
                                          Status = d.Status,
                                          StatusText = d.StatusText,
                                          ResponseDate = d.ResponseDate,
                                          ResponseRemark = d.ResponseRemark,
                                          ResponseBy=d.ResponseBy,
                                          ResponseByName=d.ResponseByName
                                          
                                      };
            FxPageInfo<LiveRequirementInfoVo> requirementPageInfo = new FxPageInfo<LiveRequirementInfoVo>();
            requirementPageInfo.TotalCount = q.TotalCount;
            requirementPageInfo.List = liveRequirementInfo;
            return ResultData<FxPageInfo<LiveRequirementInfoVo>>.Success().AddData("liveRequirement", requirementPageInfo);
        }



        /// <summary>
        /// 获取未处理的需求列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("unTreatedList")]
        public async Task<ResultData<FxPageInfo<LiveRequirementInfoVo>>> GetUnTreatedRequirementListAsync(int pageNum, int pageSize)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int departmentId = Convert.ToInt32(employee.DepartmentId);
            var q = await liveRequirementInfoService.GetUnTreatedRequirementListAsync(pageNum, pageSize, departmentId);
            var liveRequirementInfo = from d in q.List
                                      select new LiveRequirementInfoVo
                                      {
                                          Id = d.Id,
                                          CreateDate = d.CreateDate,
                                          CreateBy=d.CreateBy,
                                          CreateName=d.CreateName,
                                          Anchor = d.Anchor,
                                          LiveAnchorId=d.LiveAnchorId,
                                          LiveTypeId = d.LiveTypeId,
                                          LiveTypeName = d.LiveTypeName,
                                          RequirementTypeId = d.RequirementTypeId,
                                          RequirementTypeName = d.RequirementTypeName,
                                          FansInfo = d.FansInfo,
                                          Description = d.Description,
                                          DepartmentId = d.DepartmentId,
                                          DepartmentName = d.DepartmentName,
                                          PriorityLevel = d.PriorityLevel,
                                          PriorityLevelText = d.PriorityLevelText,
                                          Status = d.Status,
                                          StatusText = d.StatusText,
                                          DecideBy=d.DecideBy,
                                          DecideByName=d.DecideByName,
                                          DecideDate=d.DecideDate,
                                          DecideRemark=d.DecideRemark,
                                          ResponseDate = d.ResponseDate,
                                          ResponseRemark = d.ResponseRemark,
                                          ResponseBy=d.ResponseBy,
                                          ResponseByName=d.ResponseByName
                                      };
            FxPageInfo<LiveRequirementInfoVo> requirementPageInfo = new FxPageInfo<LiveRequirementInfoVo>();
            requirementPageInfo.TotalCount = q.TotalCount;
            requirementPageInfo.List = liveRequirementInfo;
            return ResultData<FxPageInfo<LiveRequirementInfoVo>>.Success().AddData("liveRequirement", requirementPageInfo);
        }



        /// <summary>
        /// 部门评判直播需求
        /// </summary>
        /// <param name="responseRequirementVo"></param>
        /// <returns></returns>
        [HttpPut("response")]
        public async Task<ResultData> ResponseRequirementAsync(ResponseRequirementVo responseRequirementVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int departmentId = Convert.ToInt32(employee.DepartmentId);
            int employeeId = Convert.ToInt32(employee.Id);
            ResponseRequirementDto responseRequirementDto = new ResponseRequirementDto();
            responseRequirementDto.Id = responseRequirementVo.Id;
            responseRequirementDto.IsAccept = responseRequirementVo.IsAccept;
            responseRequirementDto.ResponseDescription = responseRequirementVo.ResponseDescription;
            await liveRequirementInfoService.ResponseRequirementAsync(responseRequirementDto, departmentId, employeeId);
            return ResultData.Success();
        }




        /// <summary>
        /// 评判部门拒绝的直播需求
        /// </summary>
        /// <param name="decideRequirementVo"></param>
        /// <returns></returns>
        [HttpPut("decide")]
        public async Task<ResultData> DecideRequirementAsync(DecideRequirementVo decideRequirementVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            DecideRequirementDto decideRequirementDto = new DecideRequirementDto();
            decideRequirementDto.Id = decideRequirementVo.Id;
            decideRequirementDto.IsAcceptResponse = decideRequirementVo.IsAcceptResponse;
            decideRequirementDto.DepartmentId = decideRequirementVo.DepartmentId;
            decideRequirementDto.DecideRemark = decideRequirementVo.DecideRemark;
            await liveRequirementInfoService.DecideRequirementAsync(decideRequirementDto,employeeId);
            return ResultData.Success();
        }


        /// <summary>
        /// 执行直播需求
        /// </summary>
        /// <param name="executeVo"></param>
        /// <returns></returns>
        [HttpPut("execute")]
        public async Task<ResultData> ExecuteAsync(ExecuteLiveRequirementInfoVo executeVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            ExecuteLiveRequirementInfoDto executeDto = new ExecuteLiveRequirementInfoDto();
            executeDto.Id = executeVo.Id;
            executeDto.ExecuteRemark = executeVo.ExecuteRemark;
            await liveRequirementInfoService.ExecuteAsync(executeDto, employeeId);
            return ResultData.Success();
        }



        /// <summary>
        /// 确定需求执行完成
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("confirmFinish/{id}")]
        public async Task<ResultData> ConfirmFinishAsync(int id)
        {
            await liveRequirementInfoService.ConfirmFinishAsync(id);
            return ResultData.Success();
        }


        /// <summary>
        /// 获取需求进度
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("progressBar/{id}")]
        public async Task<ResultData<ProgressBarVo>> GetProgressBarAsync(int id)
        {
            var progressBar = await liveRequirementInfoService.GetProgressBarAsync(id);
            ProgressBarVo progressBarVo = new ProgressBarVo();
            progressBarVo.CreateDate = progressBar.CreateDate;
            progressBarVo.ResponseDate = progressBar.ResponseDate;
            progressBarVo.ExecuteDate = progressBar.ExecuteDate;
            progressBarVo.ResponseSeconds = progressBar.ResponseSeconds;
            progressBarVo.ExecuteSeconds = progressBar.ExecuteSeconds;
            return ResultData<ProgressBarVo>.Success().AddData("progressBar", progressBarVo);
        }


        /// <summary>
        /// 获取未确认完成的需求列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
       [HttpGet("unConfirmList")]
        public async Task<ResultData<FxPageInfo<UnConfirmLiveRequirementInfoVo>>> GetUnConfirmFinishListAsync(int pageNum, int pageSize)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var q = await liveRequirementInfoService.GetUnConfirmFinishListAsync(employeeId, pageNum, pageSize);
            var unConfirmRequirement = from d in q.List
                                       select new UnConfirmLiveRequirementInfoVo
                                       {
                                           Id = d.Id,
                                           CreateDate = d.CreateDate,
                                           Anchor = d.Anchor,
                                           LiveAnchorId=d.LiveAnchorId,
                                           LiveTypeId = d.LiveTypeId,
                                           LiveTypeName = d.LiveTypeName,
                                           RequirementTypeId = d.RequirementTypeId,
                                           RequirementTypeName = d.RequirementTypeName,
                                           FansInfo = d.FansInfo,
                                           Description = d.Description,
                                           DepartmentId = d.DepartmentId,
                                           DepartmentName = d.DepartmentName,
                                           PriorityLevel = d.PriorityLevel,
                                           PriorityLevelText = d.PriorityLevelText,
                                           ExecuteDate = d.ExecuteDate,
                                           ExecuteRemark = d.ExecuteRemark,
                                           ExecuteBy = d.ExecuteBy,
                                           ExecuteByName = d.ExecuteByName
                                       };
            FxPageInfo<UnConfirmLiveRequirementInfoVo> requirementPageInfo = new FxPageInfo<UnConfirmLiveRequirementInfoVo>();
            requirementPageInfo.TotalCount = q.TotalCount;
            requirementPageInfo.List = unConfirmRequirement;
           return ResultData<FxPageInfo<UnConfirmLiveRequirementInfoVo>>.Success().AddData("unConfirmRequirement", requirementPageInfo);
        }
    }
}
