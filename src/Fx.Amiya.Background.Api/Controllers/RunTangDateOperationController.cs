using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.RunTangDateOperation.Input;
using Fx.Amiya.Background.Api.Vo.RunTangDateOperation.Result;
using Fx.Amiya.Dto.RunTangDateOperation.Input;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 润棠运营添加反馈
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class RunTangDateOperationController : ControllerBase
    {
        private IRunTangDateOperationService runTangDateOperationService;
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="runTangDateOperationService"></param>
        public RunTangDateOperationController(IHttpContextAccessor httpContextAccessor, IRunTangDateOperationService runTangDateOperationService)
        {
            this.runTangDateOperationService = runTangDateOperationService;
            this._httpContextAccessor = httpContextAccessor;
        }



        /// <summary>
        /// 根据条件获取润棠运营添加反馈信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<RunTangDateOperationVo>>> GetListWithPageAsync([FromQuery] QueryRunTangDateOperationVo query)
        {
            try
            {
                QueryRunTangDateOperationDto queryDto = new QueryRunTangDateOperationDto();
                queryDto.StartDate = query.StartDate;
                queryDto.EndDate = query.EndDate;
                queryDto.PageNum = query.PageNum;
                queryDto.PageSize = query.PageSize;
                queryDto.Valid = query.Valid;
                queryDto.KeyWord = query.KeyWord;
                var q = await runTangDateOperationService.GetListAsync(queryDto);
                var runTangDateOperation = from d in q.List
                                                select new RunTangDateOperationVo
                                                {
                                                    Id = d.Id,
                                                    CreateDate = d.CreateDate,
                                                    RecordDate = d.RecordDate,
                                                    UpdateDate = d.UpdateDate,
                                                    Valid = d.Valid,
                                                    DeleteDate = d.DeleteDate,
                                                    CreateBy = d.CreateBy,
                                                    CreateByName = d.CreateByName,
                                                    LiveAnchorBaseId = d.LiveAnchorBaseId,
                                                    LiveAnchorBaseName = d.LiveAnchorBaseName,
                                                    CustomerAddNum = d.CustomerAddNum,
                                                    CompanyAddNum = d.CompanyAddNum,
                                                    TotalAddNum = d.TotalAddNum,
                                                    EffictiveCommunicationNum = d.EffictiveCommunicationNum,
                                                    EffictiveCommunicationRate = d.EffictiveCommunicationRate,
                                                    InvalidCustomerNum = d.InvalidCustomerNum,
                                                    EffictiveCustomerNum = d.EffictiveCustomerNum,
                                                    EffictiveCustomerRate = d.EffictiveCustomerRate,
                                                    Remark = d.Remark,
                                                };

                FxPageInfo<RunTangDateOperationVo> pageInfo = new FxPageInfo<RunTangDateOperationVo>();
                pageInfo.TotalCount = q.TotalCount;
                pageInfo.List = runTangDateOperation;

                return ResultData<FxPageInfo<RunTangDateOperationVo>>.Success().AddData("runTangDateOperation", pageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<RunTangDateOperationVo>>.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 添加润棠运营添加反馈
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddRunTangDateOperationVo addVo)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                AddRunTangDateOperationDto addDto = new AddRunTangDateOperationDto();
                addDto.CreateBy = employeeId;
                addDto.RecordDate = addVo.RecordDate;
                addDto.LiveAnchorBaseId = addVo.LiveAnchorBaseId;
                addDto.CustomerAddNum = addVo.CustomerAddNum;
                addDto.CompanyAddNum = addVo.CompanyAddNum;
                addDto.TotalAddNum = addVo.TotalAddNum;
                addDto.EffictiveCommunicationNum = addVo.EffictiveCommunicationNum;
                addDto.EffictiveCommunicationRate = addVo.EffictiveCommunicationRate;
                addDto.InvalidCustomerNum = addVo.InvalidCustomerNum;
                addDto.EffictiveCustomerNum = addVo.EffictiveCustomerNum;
                addDto.EffictiveCustomerRate = addVo.EffictiveCustomerRate;
                addDto.Remark = addVo.Remark;
                await runTangDateOperationService.AddAsync(addDto);

                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据润棠运营添加反馈编号获取润棠运营添加反馈信息
        /// </summary>
        /// <param name="id">润棠运营添加反馈编号</param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<RunTangDateOperationVo>> GetByIdAsync(string id)
        {
            try
            {
                var result = await runTangDateOperationService.GetByIdAsync(id);
                RunTangDateOperationVo returnResult = new RunTangDateOperationVo();
                returnResult.Id = result.Id;
                returnResult.CreateDate = result.CreateDate;
                returnResult.Valid = result.Valid;
                returnResult.CreateBy = result.CreateBy;
                returnResult.RecordDate = result.RecordDate;
                returnResult.LiveAnchorBaseId = result.LiveAnchorBaseId;
                returnResult.CustomerAddNum = result.CustomerAddNum;
                returnResult.CompanyAddNum = result.CompanyAddNum;
                returnResult.TotalAddNum = result.TotalAddNum;
                returnResult.EffictiveCommunicationNum = result.EffictiveCommunicationNum;
                returnResult.EffictiveCommunicationRate = result.EffictiveCommunicationRate;
                returnResult.InvalidCustomerNum = result.InvalidCustomerNum;
                returnResult.EffictiveCustomerNum = result.EffictiveCustomerNum;
                returnResult.EffictiveCustomerRate = result.EffictiveCustomerRate;
                returnResult.Remark = result.Remark;
                return ResultData<RunTangDateOperationVo>.Success().AddData("runTangDateOperation", returnResult);
            }
            catch (Exception ex)
            {
                return ResultData<RunTangDateOperationVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改润棠运营添加反馈信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateRunTangDateOperationVo updateVo)
        {
            try
            {
                UpdateRunTangDateOperationDto updateDto = new UpdateRunTangDateOperationDto();
                updateDto.Id = updateVo.Id;

                updateDto.RecordDate = updateVo.RecordDate;
                updateDto.LiveAnchorBaseId = updateVo.LiveAnchorBaseId;
                updateDto.CustomerAddNum = updateVo.CustomerAddNum;
                updateDto.CompanyAddNum = updateVo.CompanyAddNum;
                updateDto.TotalAddNum = updateVo.TotalAddNum;
                updateDto.EffictiveCommunicationNum = updateVo.EffictiveCommunicationNum;
                updateDto.EffictiveCommunicationRate = updateVo.EffictiveCommunicationRate;
                updateDto.InvalidCustomerNum = updateVo.InvalidCustomerNum;
                updateDto.EffictiveCustomerNum = updateVo.EffictiveCustomerNum;
                updateDto.EffictiveCustomerRate = updateVo.EffictiveCustomerRate;
                updateDto.Remark = updateVo.Remark;
                await runTangDateOperationService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 作废润棠运营添加反馈
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await runTangDateOperationService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

    }
}