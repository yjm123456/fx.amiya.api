using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.BusinessWechat.Api;
using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlatFormOrderAddWork;
using Fx.Amiya.Dto.ContentPlatFormOrderAddWork;
using Fx.Amiya.Dto.ContentPlatFormOrderAddWork.Input;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.BusinessWeChat.Api.Controllers
{
    /// <summary>
    /// 录单申请
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ContentPlatFormOrderAddWorkController : ControllerBase
    {
        private IContentPlatFormOrderAddWorkService contentPlatFormOrderAddWorkService;
        private IHttpContextAccessor _httpContextAccessor;

        public ContentPlatFormOrderAddWorkController(IHttpContextAccessor httpContextAccessor, IContentPlatFormOrderAddWorkService contentPlatFormOrderAddWorkService)
        {
            this.contentPlatFormOrderAddWorkService = contentPlatFormOrderAddWorkService;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>

        [HttpGet("listWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<ContentPlatFormOrderAddWorkVo>>> GetListWithPageAsync([FromQuery] QueryContentPlatFormOrderAddWorkVo query)
        {
            try
            {
                QueryContentPlatFormOrderAddWorkPageDto queryDto = new QueryContentPlatFormOrderAddWorkPageDto();
                queryDto.StartDate = query.StartDate;
                queryDto.EndDate = query.EndDate;
                queryDto.KeyWord = query.KeyWord;
                queryDto.HospitalId = query.HospitalId;
                queryDto.CheckState = query.CheckState;
                queryDto.CreateBy = query.CreateBy;
                queryDto.AcceptBy = query.AcceptBy;
                queryDto.PageNum = query.PageNum;
                queryDto.PageSize = query.PageSize;
                var q = await contentPlatFormOrderAddWorkService.GetListByPageAsync(queryDto);
                var contentPlatFormOrderAddWork = from e in q.List
                                                  select new ContentPlatFormOrderAddWorkVo
                                                  {
                                                      Id = e.Id,
                                                      HospitalId = e.HospitalId,
                                                      HospitalName = e.HospitalName,
                                                      AcceptBy = e.AcceptBy,
                                                      AcceptByEmpName = e.AcceptByEmpName,
                                                      Phone = e.Phone,
                                                      EncryptPhone = e.EncryptPhone,
                                                      SendRemark = e.SendRemark,
                                                      AddWorkTypeText = e.AddWorkTypeText,
                                                      CreateBy = e.CreateBy,
                                                      CreateByEmpName = e.CreateByEmpName,
                                                      CreateDate = e.CreateDate,
                                                      BelongCustomerServiceId = e.BelongCustomerServiceId,
                                                      CheckState = e.CheckState,
                                                      CheckStateText = e.CheckStateText,
                                                      CheckRemark = e.CheckRemark,
                                                      CheckDate = e.CheckDate,
                                                      BelongCustomerServiceName = e.BelongCustomerServiceName,
                                                  };

                FxPageInfo<ContentPlatFormOrderAddWorkVo> tagPageInfo = new FxPageInfo<ContentPlatFormOrderAddWorkVo>();
                tagPageInfo.TotalCount = q.TotalCount;
                tagPageInfo.List = contentPlatFormOrderAddWork;

                return ResultData<FxPageInfo<ContentPlatFormOrderAddWorkVo>>.Success().AddData("contentPlatFormOrderAddWork", tagPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<ContentPlatFormOrderAddWorkVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 添加录单申请
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddContentPlatFormOrderAddWorkVo addVo)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                AddContentPlatFormOrderAddWorkDto addDto = new AddContentPlatFormOrderAddWorkDto();
                addDto.HospitalId = addVo.HospitalId;
                addDto.CreateBy = employeeId;
                addDto.AcceptBy = addVo.AcceptBy;
                addDto.Phone = addVo.Phone;
                addDto.AddWorkType = addVo.AddWorkType;
                addDto.SendRemark = addVo.SendRemark;
                await contentPlatFormOrderAddWorkService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据录单申请编号获取录单申请信息
        /// </summary>
        /// <param name="id">录单申请编号</param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<ContentPlatFormOrderAddWorkVo>> GetByIdAsync(string id)
        {
            try
            {
                var selectResult = await contentPlatFormOrderAddWorkService.GetByIdAsync(id);
                ContentPlatFormOrderAddWorkVo result = new ContentPlatFormOrderAddWorkVo();
                result.Id = selectResult.Id;
                result.HospitalId = selectResult.HospitalId;
                result.AcceptBy = selectResult.AcceptBy;
                result.Phone = selectResult.Phone;
                result.SendRemark = selectResult.SendRemark;
                result.AddWorkType = selectResult.AddWorkType;
                result.CreateBy = selectResult.CreateBy;
                result.CreateDate = selectResult.CreateDate;
                result.BelongCustomerServiceId = selectResult.BelongCustomerServiceId;
                result.CheckState = selectResult.CheckState;
                result.CheckStateText = selectResult.CheckStateText;
                result.CheckRemark = selectResult.CheckRemark;
                result.CheckDate = selectResult.CheckDate;
                return ResultData<ContentPlatFormOrderAddWorkVo>.Success().AddData("contentPlatFormOrderAddWork", result);
            }
            catch (Exception ex)
            {
                return ResultData<ContentPlatFormOrderAddWorkVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据录单申请手机号获取录单申请信息
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        [HttpGet("byPhone/{phone}")]
        [FxInternalAuthorize]
        public async Task<ResultData<ContentPlatFormOrderAddWorkVo>> GetByPhoneAsync(string phone)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var selectResult = await contentPlatFormOrderAddWorkService.GetByPhoneAsync(phone, employeeId);
                ContentPlatFormOrderAddWorkVo result = new ContentPlatFormOrderAddWorkVo();
                result.Id = selectResult.Id;
                result.HospitalId = selectResult.HospitalId;
                result.AcceptBy = selectResult.AcceptBy;
                result.Phone = selectResult.Phone;
                result.SendRemark = selectResult.SendRemark;
                result.AddWorkType = selectResult.AddWorkType;
                result.AddWorkTypeText = selectResult.AddWorkTypeText;
                result.CreateBy = selectResult.CreateBy;
                result.CreateDate = selectResult.CreateDate;
                result.BelongCustomerServiceId = selectResult.BelongCustomerServiceId;
                result.CheckState = selectResult.CheckState;
                result.CheckStateText = selectResult.CheckStateText;
                result.CheckRemark = selectResult.CheckRemark;
                result.CheckDate = selectResult.CheckDate;
                return ResultData<ContentPlatFormOrderAddWorkVo>.Success().AddData("contentPlatFormOrderAddWork", result);
            }
            catch (Exception ex)
            {
                return ResultData<ContentPlatFormOrderAddWorkVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改录单申请信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateContentPlatFormOrderAddWorkVo updateVo)
        {
            try
            {
                UpdateContentPlatFormOrderAddWorkDto updateDto = new UpdateContentPlatFormOrderAddWorkDto();
                updateDto.Id = updateVo.Id;
                updateDto.AcceptBy = updateVo.AcceptBy;
                updateDto.Phone = updateVo.Phone;
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.SendRemark = updateVo.SendRemark;
                updateDto.AddWorkType = updateVo.AddWorkType;
                await contentPlatFormOrderAddWorkService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 转移录单申请信息
        /// </summary>
        /// <param name="updateAcceptByVo"></param>
        /// <returns></returns>
        [HttpPut("updateAcceptBy")]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAcceptByAsync(UpdateAcceptByVo updateAcceptByVo)
        {
            try
            {
                UpdateAcceptByDto updateDto = new UpdateAcceptByDto();
                updateDto.Id = updateAcceptByVo.Id;
                updateDto.AcceptBy = updateAcceptByVo.AcceptBy;

                await contentPlatFormOrderAddWorkService.UpdateAcceptByAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 审核录单申请信息
        /// </summary>
        /// <param name="checkVo"></param>
        /// <returns></returns>
        [HttpPut("check")]
        [FxInternalAuthorize]
        public async Task<ResultData> CheckAsync(CheckContentPlatFormOrderAddWorkVo checkVo)
        {
            try
            {
                CheckContentPlatFormOrderAddWorkDto updateDto = new CheckContentPlatFormOrderAddWorkDto();
                updateDto.Id = checkVo.Id;
                updateDto.BelongCustomerServiceId = checkVo.BelongCustomerServiceId;
                updateDto.HospitalId = checkVo.HospitalId;
                updateDto.CheckRemark = checkVo.CheckRemark;
                updateDto.CheckState = checkVo.CheckState;

                await contentPlatFormOrderAddWorkService.CheckAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 作废录单申请
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                List<string> idList = new List<string>();
                idList.Add(id);
                await contentPlatFormOrderAddWorkService.DeleteAsync(idList);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


    }
}