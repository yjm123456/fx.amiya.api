using Fx.Amiya.BusinessWechat.Api.Vo.Login;
using Fx.Amiya.Common;
using Fx.Amiya.IService;
using Fx.Authentication.Jwt;
using Fx.Identity.Core;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fx.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Authorization.Attributes;
using Fx.Amiya.BusinessWeChat.Api.Vo.CustomerInfo;
using Fx.Amiya.BusinessWeChat.Api.Vo.Base;
using Fx.Amiya.BusinessWeChat.Api.Vo.BindCustomerService;
using Fx.Common;
using Fx.Amiya.BusinessWechat.Api.Vo;
using Fx.Amiya.Dto.BindCustomerService;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.Dto.OperationLog;
using Newtonsoft.Json;

namespace Fx.Amiya.BusinessWechat.Api.Controllers
{
    /// <summary>
    /// 绑定客服板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class BindCustomerServiceController : ControllerBase
    {
        private IBindCustomerServiceService bindCustomerService;
        private IHttpContextAccessor httpContextAccessor;
        private IContentPlateFormOrderService _contentPlatFormOrderService;
        private IOperationLogService operationLogService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bindCustomerService"></param>
        /// <param name="httpContextAccessor"></param>
        public BindCustomerServiceController(IBindCustomerServiceService bindCustomerService,
            IContentPlateFormOrderService contentPlatFormOrderService,
            IHttpContextAccessor httpContextAccessor, IOperationLogService operationLogService)
        {
            this.bindCustomerService = bindCustomerService;
            _contentPlatFormOrderService = contentPlatFormOrderService;
            this.httpContextAccessor = httpContextAccessor;
            this.operationLogService = operationLogService;
        }


        /// <summary>
        /// 根据手机号筛选归属客服
        /// </summary>
        /// <param name="phone"></param>
        /// <returns>查找成功返回名称，查找失败返回“未绑定”</returns>
        [HttpGet("getCustomerServiceNameByPhone")]

        public async Task<ResultData<string>> GetBindCustomerNameByPhoneAsync(string phone)
        {
            var result = await bindCustomerService.GetBindCustomerServiceNameByPhone(phone);
            return ResultData<string>.Success().AddData("CustomerServiceNameByPhone", result);
        }

        /// <summary>
        /// 获取我的客户（放在前端缓存中）
        /// </summary>
        /// <returns></returns>
        [HttpGet("getMyCustomer")]
        public async Task<ResultData<MyCustomerInfoVo>> GetMyCustomerAsync()
        {

            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var customer = await bindCustomerService.GetCustomerCountByEmployeeIdAsync(employeeId);
            MyCustomerInfoVo myCustomerInfoVo = new MyCustomerInfoVo();
            myCustomerInfoVo.MyCustomerCount = customer.MyCustomerCount;
            myCustomerInfoVo.SevenDaysInsertCount = customer.SevenDaysInsertCount;
            myCustomerInfoVo.TodayInsertCount = customer.TodayInsertCount;
            return ResultData<MyCustomerInfoVo>.Success().AddData("myCustomer", myCustomerInfoVo);
        }

        /// <summary>
        /// 获取客户池客服下的手机号（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getPublicPoolPhone")]

        public async Task<ResultData<FxPageInfo<BindCustomerInfoVo>>> GetPublicPoolPhoneAsync([FromQuery] BaseQueryVo query)
        {
            try
            {
                var q = await bindCustomerService.GetPublicPoolPhoneAsync(query.StartDate, query.EndDate, query.KeyWord, query.PageNum.Value, query.PageSize.Value);
                var billReturnBackPriceData = from d in q.List
                                              select new BindCustomerInfoVo
                                              {
                                                  CustomerServiceName = d.CustomerServiceName,
                                                  Phone = d.BuyerPhone,
                                                  EncryptPhone = d.EncryptPhone,
                                                  FirstProjectDemand = d.FirstProjectDemand,
                                                  CreateDate = d.CreateDate,
                                                  NewContentPlatForm = d.NewContentPlatForm,
                                              };

                FxPageInfo<BindCustomerInfoVo> pageInfo = new FxPageInfo<BindCustomerInfoVo>();
                pageInfo.TotalCount = q.TotalCount;
                pageInfo.List = billReturnBackPriceData;

                return ResultData<FxPageInfo<BindCustomerInfoVo>>.Success().AddData("getPublicPoolPhone", pageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<BindCustomerInfoVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 改绑公共池客户
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("updatePublicPoolPhone")]
        public async Task<ResultData> updatePublicPoolPhoneAsync(UpdateBindCustomerServiceVo updateVo)
        {
            OperationAddDto operationLog = new OperationAddDto();
            operationLog.Source = (int)RequestSource.AmiyaBusinessWechat;
            operationLog.Code = 0;
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                operationLog.OperationBy = employeeId;
                UpdateBindCustomerServiceDto updateDto = new UpdateBindCustomerServiceDto();
                updateDto.CustomerServiceId = updateVo.CustomerServiceId;
                updateDto.EncryptPhoneList = updateVo.EncryptPhoneList;
                await bindCustomerService.UpdateAsync(updateDto, employeeId);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                operationLog.Message = ex.Message;
                operationLog.Code = -1;
                throw ex;
            }
            finally
            {
                operationLog.Parameters = JsonConvert.SerializeObject(updateVo);
                operationLog.RequestType = (int)RequestType.Update;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationLog);
            }
        }

        /// <summary>
        /// 内容平台修改绑定客服
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("ContentPlatFormOrderListBindCustomerService")]
        public async Task<ResultData> ContentPlatFormOrderListBindCustomerUpdateAsync(UpdateBindCustomerServiceVo updateVo)
        {
            OperationAddDto operationLog = new OperationAddDto();
            operationLog.Source = (int)RequestSource.AmiyaBackground;
            operationLog.Code = 0;
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                operationLog.OperationBy = employeeId;
                UpdateBindCustomerServiceDto updateDto = new UpdateBindCustomerServiceDto();
                updateDto.CustomerServiceId = updateVo.CustomerServiceId;
                updateDto.EncryptPhoneList = updateVo.EncryptPhoneList;
                await bindCustomerService.UpdateAsync(updateDto, employeeId);

                foreach (var x in updateVo.EncryptPhoneList)
                {
                    //(todo;)
                    var orderList = await _contentPlatFormOrderService.GetListByEncryptPhoneAsync(x, 1, 9999);
                    var orderIdList = orderList.List.Select(x => x.Id).ToList();
                    UpdateBelongEmpInfoOrderDto updateOrderBelongEmpIdDto = new UpdateBelongEmpInfoOrderDto();
                    updateOrderBelongEmpIdDto.OrderId = orderIdList;
                    updateOrderBelongEmpIdDto.BelongEmpId = updateVo.CustomerServiceId;
                    await _contentPlatFormOrderService.UpdateOrderBelongEmpIdAsync(updateOrderBelongEmpIdDto);
                }
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                operationLog.Message = ex.Message;
                operationLog.Code = -1;
                throw ex;
            }
            finally
            {
                operationLog.Parameters = JsonConvert.SerializeObject(updateVo);
                operationLog.RequestType = (int)RequestType.Update;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationLog);
            }
        }

    }
}
