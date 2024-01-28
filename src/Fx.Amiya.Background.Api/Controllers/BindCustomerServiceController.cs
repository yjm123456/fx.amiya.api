using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.BindCustomerService;
using Fx.Amiya.Background.Api.Vo.CustomerInfo;
using Fx.Amiya.Dto.BindCustomerService;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class BindCustomerServiceController : ControllerBase
    {
        private IBindCustomerServiceService bindCustomerServiceService;
        private IAmiyaEmployeeService employeeService;
        private IOrderService _orderService;
        private IContentPlateFormOrderService _contentPlatFormOrderService;
        private IHttpContextAccessor httpContextAccessor;
        private IOperationLogService operationLogService;
        public BindCustomerServiceController(IBindCustomerServiceService bindCustomerServiceService,
            IOrderService orderService,
            IAmiyaEmployeeService employeeService,
            IContentPlateFormOrderService contentPlatFormOrderService,
            IHttpContextAccessor httpContextAccessor, IOperationLogService operationLogService)
        {
            this.employeeService = employeeService;
            this.bindCustomerServiceService = bindCustomerServiceService;
            this.httpContextAccessor = httpContextAccessor;
            _orderService = orderService;
            _contentPlatFormOrderService = contentPlatFormOrderService;
            this.operationLogService = operationLogService;
        }

        /// <summary>
        /// 根据手机号筛选合适的客户
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet]

        public async Task<List<string>> GetPhone(string phone)
        {
            var result = await bindCustomerServiceService.GetEmployeePhoneByPhone(phone);
            return result;
        }

        /// <summary>
        /// 根据手机号筛选归属客服
        /// </summary>
        /// <param name="phone"></param>
        /// <returns>查找成功返回名称，查找失败返回“未绑定”</returns>
        [HttpGet("getCustomerServiceNameByPhone")]

        public async Task<ResultData<string>> GetBindCustomerNameByPhoneAsync(string phone)
        {
            var result = await bindCustomerServiceService.GetBindCustomerServiceNameByPhone(phone);
            return ResultData<string>.Success().AddData("CustomerServiceNameByPhone", result);
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
                var q = await bindCustomerServiceService.GetPublicPoolPhoneAsync(query.StartDate, query.EndDate, query.KeyWord, query.PageNum.Value, query.PageSize.Value);
                var billReturnBackPriceData = from d in q.List
                                              select new BindCustomerInfoVo
                                              {
                                                  Id = d.Id.ToString(),
                                                  CustomerServiceId = d.CustomerServiceId,
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
                updateVo.OriginalCustomerServiceIds= await bindCustomerServiceService.UpdateAsync(updateDto, employeeId);
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
        ///绑定客服
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddBindCustomerServiceVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            AddBindCustomerServiceDto addDto = new AddBindCustomerServiceDto();
            addDto.CustomerServiceId = addVo.CustomerServiceId;
            List<string> orderIds = new List<string>();
            foreach (var item in addVo.OrderIdList)
            {
                orderIds.Add(item);
            }
            UpdateBelongEmpInfoOrderDto updateOrderBelongEmpIdDto = new UpdateBelongEmpInfoOrderDto();
            updateOrderBelongEmpIdDto.OrderId = orderIds;
            updateOrderBelongEmpIdDto.BelongEmpId = addVo.CustomerServiceId;
            await _orderService.UpdateOrderBelongEmpIdAsync(updateOrderBelongEmpIdDto);
            addDto.OrderIdList = orderIds;
            await bindCustomerServiceService.AddAsync(addDto, employeeId);
            return ResultData.Success();
        }


        /// <summary>
        /// 下单平台修改绑定客服
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("OrderListBindCustomerService")]
        public async Task<ResultData> OrderListBindCustomerUpdateAsync(UpdateBindCustomerServiceVo updateVo)
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
                updateVo.OriginalCustomerServiceIds= await bindCustomerServiceService.UpdateAsync(updateDto, employeeId);

                foreach (var x in updateVo.EncryptPhoneList)
                {
                    //(todo;)
                    var orderList = await _orderService.GetListByEncryptPhoneAsync(x, 1, 9999);
                    var orderIdList = orderList.List.Select(x => x.Id).ToList();
                    UpdateBelongEmpInfoOrderDto updateOrderBelongEmpIdDto = new UpdateBelongEmpInfoOrderDto();
                    updateOrderBelongEmpIdDto.OrderId = orderIdList;
                    updateOrderBelongEmpIdDto.BelongEmpId = updateVo.CustomerServiceId;
                    await _orderService.UpdateOrderBelongEmpIdAsync(updateOrderBelongEmpIdDto);
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
                updateVo.OriginalCustomerServiceIds= await bindCustomerServiceService.UpdateAsync(updateDto, employeeId);

                foreach (var x in updateVo.EncryptPhoneList)
                {
                    //(todo;)
                    var orderList = await _contentPlatFormOrderService.GetListByEncryptPhoneAsync(x, 1, 9999);
                    var orderIdList = orderList.List.Select(x => x.Id).ToList();
                    UpdateBelongEmpInfoOrderDto updateOrderBelongEmpIdDto = new UpdateBelongEmpInfoOrderDto();
                    updateOrderBelongEmpIdDto.OrderId = orderIdList;
                    updateOrderBelongEmpIdDto.BelongEmpId = updateVo.CustomerServiceId;
                    updateVo.OriginalCustomerServiceIds = await _contentPlatFormOrderService.UpdateOrderBelongEmpIdAsync(updateOrderBelongEmpIdDto);
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

        /// <summary>
        /// 根据条件获取客户RFM模型数据
        /// </summary>
        /// <param name="query">绑定客服id集合</param>
        /// <returns></returns>

        [HttpGet("getAllCustomerByRFM")]
        public async Task<ResultData<List<BindCustomerServiceRfmDataVo>>> GetAllCustomerByRFMAsync([FromQuery] GetAllCustomerByRFM query)
        {
            List<int> employeeIds = new List<int>();
            List<BindCustomerServiceRfmDataVo> bindResult = new List<BindCustomerServiceRfmDataVo>();
            if (query.EmployeeId.HasValue)
            {
                employeeIds.Add(query.EmployeeId.Value);
            }
            else
            {
                if (!string.IsNullOrEmpty(query.LiveAnchorBaseId))
                {
                    var empInfo = await employeeService.GetByLiveAnchorBaseIdAsync(query.LiveAnchorBaseId);
                    employeeIds = empInfo.Select(x => x.Id).ToList();
                }
            }
            var result = await bindCustomerServiceService.GetAllCustomerByRFMAsync(employeeIds);
            result = result.OrderByDescending(x => x.RFMType).ToList();
            for (int x = 0; x < 9; x++)
            {
                BindCustomerServiceRfmDataVo bindCustomerServiceRFMData = new BindCustomerServiceRfmDataVo();
                bindCustomerServiceRFMData.RFMType = x;
                bindCustomerServiceRFMData.RFMTypeText = ServiceClass.GetRFMTagText(x);
                bindCustomerServiceRFMData.CustomerCount = 0;
                bindCustomerServiceRFMData.CustomerIncreaseFromYesterday = 0;
                bindCustomerServiceRFMData.TotalConsumptionPrice = 0.00M;
                bindResult.Add(bindCustomerServiceRFMData);
            }
            foreach (var x in result)
            {
                if (bindResult.Exists(k => k.RFMType == x.RFMType))
                {
                    var bind = bindResult.Where(z => z.RFMType == x.RFMType).FirstOrDefault();
                    bind.CustomerCount = x.CustomerCount;
                    bind.CustomerIncreaseFromYesterday = x.CustomerIncreaseFromYesterday;
                    bind.TotalConsumptionPrice = x.TotalConsumptionPrice;
                }
            }
            return ResultData<List<BindCustomerServiceRfmDataVo>>.Success().AddData("allCustomerByRFM", bindResult);
        }

        /// <summary>
        /// 根据RFM条件获取客户RFM详情数据（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getAllCustomerByRFMType")]

        public async Task<ResultData<FxPageInfo<BindCustomerInfoVo>>> GetAllCustomerByRFMTypeAsync([FromQuery] GetAllCustomerByRFMTypeVo query)
        {
            try
            {
                List<int> employeeIds = new List<int>();
                List<BindCustomerServiceRfmDataVo> hospitalPerformanceVo = new List<BindCustomerServiceRfmDataVo>();
                if (query.EmployeeId.HasValue)
                {
                    employeeIds.Add(query.EmployeeId.Value);
                }
                else
                {
                    if (!string.IsNullOrEmpty(query.LiveAnchorBaseId))
                    {
                        var empInfo = await employeeService.GetByLiveAnchorBaseIdAsync(query.LiveAnchorBaseId);
                        employeeIds = empInfo.Select(x => x.Id).ToList();
                    }
                }
                var q = await bindCustomerServiceService.GetAllCustomerByRFMTypeAsync(employeeIds, query.rfmType, query.PageNum.Value, query.PageSize.Value);
                var billReturnBackPriceData = from d in q.List
                                              select new BindCustomerInfoVo
                                              {
                                                  Id = d.Id.ToString(),
                                                  CustomerServiceId = d.CustomerServiceId,
                                                  CustomerServiceName = d.CustomerServiceName,
                                                  Phone = d.BuyerPhone,
                                                  EncryptPhone = d.EncryptPhone,
                                                  NewConsumptionDate = d.NewConsumptionDate,
                                                  AllPrice = d.AllPrice,
                                                  AllOrderCount = d.AllOrderCount,
                                                  ConsumptionDate = d.ConsumptionDate,
                                                  RfmType = d.RfmType,
                                                  RfmTypeText = d.RfmTypeText,
                                                  ConsumerCycle = d.ConsumerCycle
                                              };

                FxPageInfo<BindCustomerInfoVo> pageInfo = new FxPageInfo<BindCustomerInfoVo>();
                pageInfo.TotalCount = q.TotalCount;
                pageInfo.List = billReturnBackPriceData;

                return ResultData<FxPageInfo<BindCustomerInfoVo>>.Success().AddData("allCustomerByRFMType", pageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<BindCustomerInfoVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取客户RFM等级更新记录（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getCustomerRFMTypeUpdateData")]

        public async Task<ResultData<FxPageInfo<BindCustomerRFMLevelUpdateLogVo>>> GetCustomerRFMTypeUpdateDataAsync([FromQuery] QueryCustomerRFMTypeUpdateDataVo query)
        {
            try
            {
                var q = await bindCustomerServiceService.GetCustomerRFMTypeUpdateDataAsync(query.StartDate.Value, query.EndDate.Value, query.KeyWord, query.customerServiceId, query.PageNum.Value, query.PageSize.Value);
                var billReturnBackPriceData = from d in q.List
                                              select new BindCustomerRFMLevelUpdateLogVo
                                              {
                                                  Id = d.Id,
                                                  CustomerServiceName = d.CustomerServiceName,
                                                  Phone = d.Phone,
                                                  EncryptPhone = d.EncryptPhone,
                                                  From = d.From,
                                                  To = d.To,
                                                  CreateDate = d.CreateDate,
                                              };

                FxPageInfo<BindCustomerRFMLevelUpdateLogVo> pageInfo = new FxPageInfo<BindCustomerRFMLevelUpdateLogVo>();
                pageInfo.TotalCount = q.TotalCount;
                pageInfo.List = billReturnBackPriceData;

                return ResultData<FxPageInfo<BindCustomerRFMLevelUpdateLogVo>>.Success().AddData("getCustomerRFMTypeUpdateData", pageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<BindCustomerRFMLevelUpdateLogVo>>.Fail(ex.Message);
            }
        }
    }
}