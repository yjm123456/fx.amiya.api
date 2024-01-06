using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.CustomerServiceCompensation.Input;
using Fx.Amiya.Background.Api.Vo.CustomerServiceCompensation.Result;
using Fx.Amiya.Dto.CustomerServiceCompensation;
using Fx.Amiya.Dto.CustomerServiceCompensation.Input;
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
    /// 助理薪资单
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CustomerServiceCompensationController : ControllerBase
    {
        private ICustomerServiceCompensationService customerServiceCompensationService;
        private IHttpContextAccessor _httpContextAccessor;
        private IOperationLogService operationLogService;

        public CustomerServiceCompensationController(IHttpContextAccessor httpContextAccessor, ICustomerServiceCompensationService customerServiceCompensationService, IOperationLogService operationLogService)
        {
            this.customerServiceCompensationService = customerServiceCompensationService;
            _httpContextAccessor = httpContextAccessor;
            this.operationLogService = operationLogService;
        }



        /// <summary>
        /// 根据条件获取助理薪资单信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<CustomerServiceCompensationVo>>> GetListWithPageAsync([FromQuery]QueryCustomerServiceCompensationVo query)
        {
            try
            {
                QueryCustomerServiceCompensationDto queryDto = new QueryCustomerServiceCompensationDto();
                queryDto.StartDate = query.StartDate;
                queryDto.EndDate = query.EndDate;
                queryDto.BelongEmpId = query.BelongEmpId;
                queryDto.Valid = query.Valid;
                queryDto.KeyWord = query.KeyWord;
                queryDto.PageNum = query.PageNum;
                queryDto.PageSize = query.PageSize;
                var q = await customerServiceCompensationService.GetListAsync(queryDto);
                var customerServiceCompensation = from d in q.List
                                                  select new CustomerServiceCompensationVo
                                                  {
                                                      Id = d.Id,
                                                      CreateDate = d.CreateDate,
                                                      CreateBy = d.CreateBy,
                                                      CreateByEmpName = d.CreateByEmpName,
                                                      UpdateDate = d.UpdateDate,
                                                      Valid = d.Valid,
                                                      DeleteDate = d.DeleteDate,
                                                      Name = d.Name,
                                                      BelongEmpId = d.BelongEmpId,
                                                      BelongEmpName = d.BelongEmpName,
                                                      TotalPrice = d.TotalPrice,
                                                      OtherPrice = d.OtherPrice,
                                                      Remark = d.Remark,
                                                  };  

                FxPageInfo<CustomerServiceCompensationVo> pageInfo = new FxPageInfo<CustomerServiceCompensationVo>();
                pageInfo.TotalCount = q.TotalCount;
                pageInfo.List = customerServiceCompensation;

                return ResultData<FxPageInfo<CustomerServiceCompensationVo>>.Success().AddData("customerServiceCompensation", pageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<CustomerServiceCompensationVo>>.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 添加助理薪资单
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddCustomerServiceCompensationVo addVo)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                AddCustomerServiceCompensationDto addDto = new AddCustomerServiceCompensationDto();
                addDto.Name = addVo.Name;
                addDto.BelongEmpId = addVo.BelongEmpId;
                addDto.TotalPrice = addVo.TotalPrice;
                addDto.OtherPrice = addVo.OtherPrice;
                addDto.Remark = addVo.Remark;
                addDto.RecommandDocumentSettleIdList = addVo.RecommandDocumentSettleIdList;
                addDto.CreateBy = employeeId;
                await customerServiceCompensationService.AddAsync(addDto);

                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据助理薪资单编号获取助理薪资单信息
        /// </summary>
        /// <param name="id">助理薪资单编号</param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<CustomerServiceCompensationVo>> GetByIdAsync(string id)
        {
            try
            {
                var customerServiceCompensation = await customerServiceCompensationService.GetByIdAsync(id);
                CustomerServiceCompensationVo customerServiceCompensationVo = new CustomerServiceCompensationVo();
                customerServiceCompensationVo.Id = customerServiceCompensation.Id;
                customerServiceCompensationVo.CreateDate = customerServiceCompensation.CreateDate;
                customerServiceCompensationVo.CreateBy = customerServiceCompensation.CreateBy;
                customerServiceCompensationVo.CreateByEmpName = customerServiceCompensation.CreateByEmpName;
                customerServiceCompensationVo.UpdateDate = customerServiceCompensation.UpdateDate;
                customerServiceCompensationVo.Valid = customerServiceCompensation.Valid;
                customerServiceCompensationVo.DeleteDate = customerServiceCompensation.DeleteDate;
                customerServiceCompensationVo.Name = customerServiceCompensation.Name;
                customerServiceCompensationVo.BelongEmpId = customerServiceCompensation.BelongEmpId;
                customerServiceCompensationVo.BelongEmpName = customerServiceCompensation.BelongEmpName;
                customerServiceCompensationVo.TotalPrice = customerServiceCompensation.TotalPrice;
                customerServiceCompensationVo.OtherPrice = customerServiceCompensation.OtherPrice;
                customerServiceCompensationVo.Remark = customerServiceCompensation.Remark;
                return ResultData<CustomerServiceCompensationVo>.Success().AddData("customerServiceCompensation", customerServiceCompensationVo);
            }
            catch (Exception ex)
            {
                return ResultData<CustomerServiceCompensationVo>.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 修改助理薪资单信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateCustomerServiceCompensationVo updateVo)
        {
            try
            {
                UpdateCustomerServiceCompensationDto updateDto = new UpdateCustomerServiceCompensationDto();
                updateDto.Id = updateVo.Id;
                updateDto.Name = updateVo.Name;
                updateDto.BelongEmpId = updateVo.BelongEmpId;
                updateDto.TotalPrice = updateVo.TotalPrice;
                updateDto.OtherPrice = updateVo.OtherPrice;
                updateDto.Remark = updateVo.Remark;
                await customerServiceCompensationService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 作废助理薪资单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await customerServiceCompensationService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }

    }
}