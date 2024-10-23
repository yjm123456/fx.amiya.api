using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.EmployeePerformanceLadder.Input;
using Fx.Amiya.Background.Api.Vo.EmployeePerformanceLadder.Result;
using Fx.Amiya.Dto.EmployeePerformanceLadder.Input;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 助理业绩提点阶梯
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class EmployeePerformanceLadderController : ControllerBase
    {
        private IEmployeePerformanceLadderService employeePerformanceLadderService;
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="employeePerformanceLadderService"></param>
        public EmployeePerformanceLadderController(IHttpContextAccessor httpContextAccessor, IEmployeePerformanceLadderService employeePerformanceLadderService)
        {
            this.employeePerformanceLadderService = employeePerformanceLadderService;
            this._httpContextAccessor = httpContextAccessor;
        }



        /// <summary>
        /// 根据条件获取助理业绩提点阶梯信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<EmployeePerformanceLadderVo>>> GetListWithPageAsync([FromQuery] QueryEmployeePerformanceLadderVo query)
        {
            try
            {
                QueryEmployeePerformanceLadderDto queryDto = new QueryEmployeePerformanceLadderDto();
                queryDto.StartDate = query.StartDate;
                queryDto.EndDate = query.EndDate;
                queryDto.PageNum = query.PageNum;
                queryDto.PageSize = query.PageSize;
                queryDto.Valid = query.Valid;
                queryDto.KeyWord = query.KeyWord;
                var q = await employeePerformanceLadderService.GetListAsync(queryDto);
                var employeePerformanceLadder = from d in q.List
                                                select new EmployeePerformanceLadderVo
                                                {
                                                    Id = d.Id,
                                                    CreateDate = d.CreateDate,
                                                    UpdateDate = d.UpdateDate,
                                                    Valid = d.Valid,
                                                    DeleteDate = d.DeleteDate,
                                                    CustomerServiceId = d.CustomerServiceId,
                                                    CustomerServiceName = d.CustomerServiceName,
                                                    IsPersonalConfig = d.IsPersonalConfig,
                                                    PerformanceLowerLimit = d.PerformanceLowerLimit,
                                                    PerformanceUpperLimit = d.PerformanceUpperLimit,
                                                    BasePerformance = d.BasePerformance,
                                                    Year = d.Year,
                                                    Month = d.Month,
                                                    Point = d.Point,
                                                    Remark = d.Remark,
                                                };

                FxPageInfo<EmployeePerformanceLadderVo> pageInfo = new FxPageInfo<EmployeePerformanceLadderVo>();
                pageInfo.TotalCount = q.TotalCount;
                pageInfo.List = employeePerformanceLadder;

                return ResultData<FxPageInfo<EmployeePerformanceLadderVo>>.Success().AddData("employeePerformanceLadder", pageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<EmployeePerformanceLadderVo>>.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 添加助理业绩提点阶梯
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddEmployeePerformanceLadderVo addVo)
        {
            try
            {
                AddEmployeePerformanceLadderDto addDto = new AddEmployeePerformanceLadderDto();
                addDto.CustomerServiceId = addVo.CustomerServiceId;
                addDto.IsPersonalConfig = addVo.IsPersonalConfig;
                addDto.PerformanceLowerLimit = addVo.PerformanceLowerLimit;
                addDto.PerformanceUpperLimit = addVo.PerformanceUpperLimit;
                addDto.BasePerformance = addVo.BasePerformance;
                addDto.Year = addVo.Year;
                addDto.Month = addVo.Month;
                addDto.Remark = addVo.Remark;
                addDto.Point = addVo.Point;
                await employeePerformanceLadderService.AddAsync(addDto);

                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据助理业绩提点阶梯编号获取助理业绩提点阶梯信息
        /// </summary>
        /// <param name="id">助理业绩提点阶梯编号</param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<EmployeePerformanceLadderVo>> GetByIdAsync(string id)
        {
            try
            {
                var employeePerformanceLadder = await employeePerformanceLadderService.GetByIdAsync(id);
                EmployeePerformanceLadderVo employeePerformanceLadderVo = new EmployeePerformanceLadderVo();
                employeePerformanceLadderVo.Id = employeePerformanceLadder.Id;
                employeePerformanceLadderVo.CreateDate = employeePerformanceLadder.CreateDate;
                employeePerformanceLadderVo.Valid = employeePerformanceLadder.Valid;
                employeePerformanceLadderVo.CustomerServiceId = employeePerformanceLadder.CustomerServiceId;
                employeePerformanceLadderVo.IsPersonalConfig = employeePerformanceLadder.IsPersonalConfig;
                employeePerformanceLadderVo.PerformanceLowerLimit = employeePerformanceLadder.PerformanceLowerLimit;
                employeePerformanceLadderVo.PerformanceUpperLimit = employeePerformanceLadder.PerformanceUpperLimit;
                employeePerformanceLadderVo.BasePerformance = employeePerformanceLadder.BasePerformance;
                employeePerformanceLadderVo.Year = employeePerformanceLadder.Year;
                employeePerformanceLadderVo.Month = employeePerformanceLadder.Month;
                employeePerformanceLadderVo.Remark = employeePerformanceLadder.Remark;
                employeePerformanceLadderVo.Point = employeePerformanceLadder.Point;
                return ResultData<EmployeePerformanceLadderVo>.Success().AddData("employeePerformanceLadder", employeePerformanceLadderVo);
            }
            catch (Exception ex)
            {
                return ResultData<EmployeePerformanceLadderVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改助理业绩提点阶梯信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateEmployeePerformanceLadderVo updateVo)
        {
            try
            {
                UpdateEmployeePerformanceLadderDto updateDto = new UpdateEmployeePerformanceLadderDto();
                updateDto.Id = updateVo.Id;

                updateDto.CustomerServiceId = updateVo.CustomerServiceId;
                updateDto.IsPersonalConfig = updateVo.IsPersonalConfig;
                updateDto.PerformanceLowerLimit = updateVo.PerformanceLowerLimit;
                updateDto.PerformanceUpperLimit = updateVo.PerformanceUpperLimit;
                updateDto.BasePerformance = updateVo.BasePerformance;
                updateDto.Year = updateVo.Year;
                updateDto.Month = updateVo.Month;
                updateDto.Remark = updateVo.Remark;
                updateDto.Point = updateVo.Point;
                await employeePerformanceLadderService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 作废助理业绩提点阶梯
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await employeePerformanceLadderService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 获取有效的助理业绩提点阶梯信息（下拉框使用）
        /// </summary>
        /// <returns></returns>
        [HttpGet("ValidKeyAndValue")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetValidByKeyAndValueAsync()
        {
            try
            {
                var q = await employeePerformanceLadderService.GetValidListAsync();
                var employeePerformanceLadder = from d in q
                                                select new BaseIdAndNameVo
                                                {
                                                    Id = d.Key,
                                                    Name = d.Value,
                                                };

                return ResultData<List<BaseIdAndNameVo>>.Success().AddData("employeePerformanceLadder", employeePerformanceLadder.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<BaseIdAndNameVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据总成交额和归属客服获取业绩提点
        /// </summary>
        /// <param name="totalPerformance"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// <returns></returns>
        [HttpGet("getByDealPriceAndEmployee")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<decimal>> GetPointByEmployeeAndDealPriceAsync(decimal totalPerformance, int employeeId)
        {
            var result = await employeePerformanceLadderService.GetPointByPerformanceAsync(totalPerformance, employeeId);
            return ResultData<decimal>.Success().AddData("point", result);
        }
        /// <summary>
        /// 根据成交编号和归属客服获取业绩提点
        /// </summary>
        /// <param name="dealId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// <returns></returns>
        [HttpGet("getByDealIdAndEmployee")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<decimal>> GetPointByEmployeeAndDealIdAsync(string dealId, int employeeId)
        {
            var result = await employeePerformanceLadderService.GetPointByDealIdAndEmpIdAsync(dealId, employeeId);
            return ResultData<decimal>.Success().AddData("point", result);
        }
    }
}