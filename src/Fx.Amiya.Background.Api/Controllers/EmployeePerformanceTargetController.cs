using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.EmployeePerformanceTarget.Input;
using Fx.Amiya.Background.Api.Vo.EmployeePerformanceTarget.Result;
using Fx.Amiya.Dto.EmployeePerformanceTarget;
using Fx.Amiya.Dto.EmployeePerformanceTarget.Input;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Infrastructure;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 助理业绩目标
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class EmployeePerformanceTargetController : ControllerBase
    {
        private IEmployeePerformanceTargetService employeePerformanceTargetService;
        private IHttpContextAccessor _httpContextAccessor;

        public EmployeePerformanceTargetController(IHttpContextAccessor httpContextAccessor, IEmployeePerformanceTargetService employeePerformanceTargetService)
        {
            this.employeePerformanceTargetService = employeePerformanceTargetService;
            _httpContextAccessor = httpContextAccessor;
        }



        /// <summary>
        /// 根据条件获取助理业绩目标信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<EmployeePerformanceTargetVo>>> GetListWithPageAsync([FromQuery]QueryEmployeePerformanceTargetVo query)
        {
            try
            {
                QueryEmployeePerformanceTargetDto queryDto = new QueryEmployeePerformanceTargetDto();
                queryDto.StartDate = query.StartDate;
                queryDto.EndDate = query.EndDate;
                queryDto.EmployeeId = query.EmployeeId;
                queryDto.PageNum = query.PageNum;
                queryDto.PageSize = query.PageSize;
                var q = await employeePerformanceTargetService.GetListAsync(queryDto);
                var employeePerformanceTarget = from d in q.List
                                                  select new EmployeePerformanceTargetVo
                                                  {
                                                      Id = d.Id,
                                                      CreateDate = d.CreateDate,
                                                      EmployeeId = d.EmployeeId,
                                                      EmployeeName = d.EmployeeName,
                                                      UpdateDate = d.UpdateDate,
                                                      Valid = d.Valid,
                                                      DeleteDate = d.DeleteDate,
                                                      BelongMonth = d.BelongMonth,
                                                      BelongYear = d.BelongYear,
                                                      ConsulationCardTarget = d.ConsulationCardTarget,
                                                      AddWechatTarget = d.AddWechatTarget,
                                                      SendOrderTarget = d.SendOrderTarget,
                                                      VisitTarget = d.VisitTarget,
                                                      NewCustomerDealTarget = d.NewCustomerDealTarget,
                                                      OldCustomerDealTarget = d.OldCustomerDealTarget,
                                                      NewCustomerPerformanceTarget = d.NewCustomerPerformanceTarget,
                                                      OldCustomerPerformanceTarget = d.OldCustomerPerformanceTarget,
                                                      PerformanceTarget = d.PerformanceTarget,
                                                  };

                FxPageInfo<EmployeePerformanceTargetVo> pageInfo = new FxPageInfo<EmployeePerformanceTargetVo>();
                pageInfo.TotalCount = q.TotalCount;
                pageInfo.List = employeePerformanceTarget;

                return ResultData<FxPageInfo<EmployeePerformanceTargetVo>>.Success().AddData("employeePerformanceTarget", pageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<EmployeePerformanceTargetVo>>.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 添加助理业绩目标
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddEmployeePerformanceTargetVo addVo)
        {
            try
            {
                AddEmployeePerformanceTargetDto addDto = new AddEmployeePerformanceTargetDto();
                addDto.EmployeeId = addVo.EmployeeId;
                addDto.BelongYear = addVo.BelongYear;
                addDto.BelongMonth = addVo.BelongMonth;
                addDto.ConsulationCardTarget = addVo.ConsulationCardTarget;
                addDto.AddWechatTarget = addVo.AddWechatTarget;
                addDto.SendOrderTarget = addVo.SendOrderTarget;
                addDto.VisitTarget = addVo.VisitTarget;
                addDto.NewCustomerDealTarget = addVo.NewCustomerDealTarget;
                addDto.OldCustomerDealTarget = addVo.OldCustomerDealTarget;
                addDto.NewCustomerPerformanceTarget = addVo.NewCustomerPerformanceTarget;
                addDto.OldCustomerPerformanceTarget = addVo.OldCustomerPerformanceTarget;
                addDto.PerformanceTarget = addVo.PerformanceTarget;
                await employeePerformanceTargetService.AddAsync(addDto);

                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据助理业绩目标编号获取助理业绩目标信息
        /// </summary>
        /// <param name="id">助理业绩目标编号</param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<EmployeePerformanceTargetVo>> GetByIdAsync(string id)
        {
            try
            {
                var employeePerformanceTarget = await employeePerformanceTargetService.GetByIdAsync(id);
                EmployeePerformanceTargetVo employeePerformanceTargetVo = new EmployeePerformanceTargetVo();
                employeePerformanceTargetVo.Id = employeePerformanceTarget.Id;
                employeePerformanceTargetVo.CreateDate = employeePerformanceTarget.CreateDate;
                employeePerformanceTargetVo.EmployeeId = employeePerformanceTarget.EmployeeId;
                employeePerformanceTargetVo.EmployeeName = employeePerformanceTarget.EmployeeName;
                employeePerformanceTargetVo.Valid = employeePerformanceTarget.Valid;
                employeePerformanceTargetVo.BelongYear = employeePerformanceTarget.BelongYear;
                employeePerformanceTargetVo.BelongMonth = employeePerformanceTarget.BelongMonth;
                employeePerformanceTargetVo.ConsulationCardTarget = employeePerformanceTarget.ConsulationCardTarget;
                employeePerformanceTargetVo.AddWechatTarget = employeePerformanceTarget.AddWechatTarget;
                employeePerformanceTargetVo.SendOrderTarget = employeePerformanceTarget.SendOrderTarget;
                employeePerformanceTargetVo.VisitTarget = employeePerformanceTarget.VisitTarget;
                employeePerformanceTargetVo.NewCustomerDealTarget = employeePerformanceTarget.NewCustomerDealTarget;
                employeePerformanceTargetVo.OldCustomerDealTarget = employeePerformanceTarget.OldCustomerDealTarget;
                employeePerformanceTargetVo.NewCustomerPerformanceTarget = employeePerformanceTarget.NewCustomerPerformanceTarget;
                employeePerformanceTargetVo.OldCustomerPerformanceTarget = employeePerformanceTarget.OldCustomerPerformanceTarget;
                employeePerformanceTargetVo.PerformanceTarget = employeePerformanceTarget.PerformanceTarget;
                return ResultData<EmployeePerformanceTargetVo>.Success().AddData("employeePerformanceTarget", employeePerformanceTargetVo);
            }
            catch (Exception ex)
            {
                return ResultData<EmployeePerformanceTargetVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改助理业绩目标信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateEmployeePerformanceTargetVo updateVo)
        {
            try
            {
                UpdateEmployeePerformanceTargetDto updateDto = new UpdateEmployeePerformanceTargetDto();
                updateDto.Id = updateVo.Id;
                updateDto.EmployeeId = updateVo.EmployeeId;
                updateDto.BelongYear = updateVo.BelongYear;
                updateDto.BelongMonth = updateVo.BelongMonth;
                updateDto.ConsulationCardTarget = updateVo.ConsulationCardTarget;
                updateDto.AddWechatTarget = updateVo.AddWechatTarget;
                updateDto.SendOrderTarget = updateVo.SendOrderTarget;
                updateDto.VisitTarget = updateVo.VisitTarget;
                updateDto.NewCustomerDealTarget = updateVo.NewCustomerDealTarget;
                updateDto.OldCustomerDealTarget = updateVo.OldCustomerDealTarget;
                updateDto.NewCustomerPerformanceTarget = updateVo.NewCustomerPerformanceTarget;
                updateDto.OldCustomerPerformanceTarget = updateVo.OldCustomerPerformanceTarget;
                updateDto.PerformanceTarget = updateVo.PerformanceTarget;
                await employeePerformanceTargetService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 作废助理业绩目标
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await employeePerformanceTargetService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

    }
}