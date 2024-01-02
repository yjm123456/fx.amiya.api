using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.SendOrderInfo;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.Dto.SendOrderInfo;
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
    [Route("[controller]")]
    [ApiController]

    public class SendOrderInfoController : ControllerBase
    {
        private ISendOrderInfoService sendOrderInfoService;
        private IHttpContextAccessor httpContextAccessor;
        private IHospitalInfoService hospitalInfoService;
        private IOrderService _orderService;
        private IOperationLogService operationLogService;

        public SendOrderInfoController(ISendOrderInfoService sendOrderInfoService,
            IHospitalInfoService hospitalInfoService,
            IOrderService orderService,
            IHttpContextAccessor httpContextAccessor, IOperationLogService operationLogService)
        {
            this.sendOrderInfoService = sendOrderInfoService;
            this.httpContextAccessor = httpContextAccessor;
            this.hospitalInfoService = hospitalInfoService;
            _orderService = orderService;
            this.operationLogService = operationLogService;
        }



        /// <summary>
        /// 获取派单信息列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="appType">下单平台</param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>e
        [HttpGet("listWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<SendOrderInfoVo>>> GetListWithPageAsync(string keyword, DateTime? startDate, DateTime? endDate, byte? appType, int? employeeId, string statusCode, int? hospitalId, int pageNum, int pageSize)
        {
            if (employeeId == null)
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
            }

            var q = await sendOrderInfoService.GetListWithPageAsync(keyword, (int)employeeId, startDate, endDate, appType, statusCode, hospitalId, pageNum, pageSize);
            var sendOrder = from d in q.List
                            select new SendOrderInfoVo
                            {
                                Id = d.Id,
                                OrderId = d.OrderId,
                                HospitalId = d.HospitalId,
                                HospitalName = d.HospitalName,
                                SendBy = d.SendBy,
                                SendName = d.SendName,
                                SendDate = d.SendDate,
                                IsUncertainDate = d.IsUncertainDate,
                                AppointmentDate = d.AppointmentDate,
                                TimeType = d.TimeType,
                                Time = d.Time,
                                GoodsId = d.GoodsId,
                                GoodsName = d.GoodsName,
                                PurchaseNum = d.PurchaseNum,
                                PurchaseSinglePrice = d.PurchaseSinglePrice,
                                ActualPayment = d.ActualPayment,
                                ThumbPicUrl = d.ThumbPicUrl,
                                Description = d.Description,
                                Standard = d.Standard,
                                Parts = d.Parts,
                                Phone = d.Phone,
                                EncryptPhone = d.EncryptPhone,
                                IsHospitalCheckPhone = d.IsHospitalCheckPhone,
                                StatusText = d.StatusText,
                                StatusCode = d.StatusCode,
                                AppType = d.AppType,
                                AppTypeText = d.AppTypeText,
                                FirstMessageContent = d.FirstMessageContent,
                                IsMainHospital = d.IsMainHospital
                            };

            FxPageInfo<SendOrderInfoVo> snedOrderPageInfo = new FxPageInfo<SendOrderInfoVo>();
            snedOrderPageInfo.TotalCount = q.TotalCount;
            snedOrderPageInfo.List = sendOrder;
            return ResultData<FxPageInfo<SendOrderInfoVo>>.Success().AddData("sendOrder", snedOrderPageInfo);
        }





        /// <summary>
        /// 获取未派单订单列表（分页）
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="appType">下单平台</param>
        /// <param name="employeeId">-1查全部</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("unSendOrderList")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<UnSendOrderInfoVo>>> GetUnSendOrderListWithPageAsync(string keyword, byte? appType, int? employeeId, string statusCode, int pageNum, int pageSize)
        {
            if (employeeId == null)
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
            }

            var q = await sendOrderInfoService.GetUnSendOrderListWithPageAsync(keyword, (int)employeeId, appType, statusCode, pageNum, pageSize);
            var unSendOrder = from d in q.List
                              select new UnSendOrderInfoVo
                              {
                                  OrderId = d.OrderId,
                                  GoodsId = d.GoodsId,
                                  GoodsName = d.GoodsName,
                                  Phone = d.Phone,
                                  EncryptPhone = d.EncryptPhone,
                                  ActualPayment = d.ActualPayment,
                                  AppointmentHospital = d.AppointmentHospital,
                                  ThumbPicUrl = d.ThumbPicUrl,
                                  Description = d.Description,
                                  CreateDate = d.CreateDate,
                                  Standard = d.Standard,
                                  Parts = d.Parts,
                                  StatusCode = d.StatusCode,
                                  StatusText = d.StatusText,
                                  AppType = d.AppType,
                                  AppTypeText = d.AppTypeText
                              };
            FxPageInfo<UnSendOrderInfoVo> pageInfo = new FxPageInfo<UnSendOrderInfoVo>();
            pageInfo.TotalCount = q.TotalCount;
            pageInfo.List = unSendOrder;
            return ResultData<FxPageInfo<UnSendOrderInfoVo>>.Success().AddData("unSendOrder", pageInfo);
        }



        /// <summary>
        /// 添加派单
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddSendOrderInfoVo addVo)
        {
            OperationAddDto operationLog = new OperationAddDto();
            operationLog.Source = (int)RequestSource.AmiyaBackground;
            operationLog.Code = 0;
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                operationLog.OperationBy = employeeId;
                AddSendOrderInfoDto addDto = new AddSendOrderInfoDto();
                addDto.HospitalId = addVo.HospitalId;
                addDto.PurchaseSinglePrice = addVo.PurchaseSinglePrice;
                addDto.PurchaseNum = addVo.PurchaseNum;
                addDto.OrderId = addVo.OrderId;
                addDto.IsUncertainDate = addVo.IsUncertainDate;
                addDto.AppointmentDate = addVo.AppointmentDate;
                addDto.OtherHospitalId = addVo.OtherHospitalId;
                addDto.TimeType = addVo.TimeType;
                addDto.Content = addVo.Content;
                await sendOrderInfoService.AddAsync(addDto, employeeId);
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
                operationLog.Parameters = JsonConvert.SerializeObject(addVo);
                operationLog.RequestType = (int)RequestType.Update;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationLog);
            }
        }
        /// <summary>
        /// 分配医院
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("DistributeToHospital")]
        [FxInternalAuthorize]
        public async Task<ResultData> DistributeToHospitalAsync(AddSendOrderInfoVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            AddSendOrderInfoDto addDto = new AddSendOrderInfoDto();
            addDto.HospitalId = addVo.HospitalId;
            addDto.PurchaseSinglePrice = addVo.PurchaseSinglePrice;
            addDto.PurchaseNum = addVo.PurchaseNum;
            addDto.OrderId = addVo.OrderId;
            addDto.IsUncertainDate = addVo.IsUncertainDate;
            addDto.AppointmentDate = addVo.AppointmentDate;
            addDto.TimeType = addVo.TimeType;
            addDto.Content = addVo.Content;
            await _orderService.FinishOrderAsync(addDto.OrderId);
            await sendOrderInfoService.AddAsync(addDto, employeeId);

            return ResultData.Success();
        }



        /// <summary>
        /// 根据编号获取简单的派单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("simpleById/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<SendOrderInfoSimpleVo>> GetSimpleByIdAsync(int id)
        {
            var sendOrderInfo = await sendOrderInfoService.GetSimpleByIdAsync(id);
            SendOrderInfoSimpleVo sendOrderInfoSimpleVo = new SendOrderInfoSimpleVo();
            sendOrderInfoSimpleVo.Id = sendOrderInfo.Id;
            sendOrderInfoSimpleVo.OrderId = sendOrderInfo.OrderId;
            sendOrderInfoSimpleVo.HospitalId = sendOrderInfo.HospitalId;
            sendOrderInfoSimpleVo.PurchaseNum = sendOrderInfo.PurchaseNum;
            sendOrderInfoSimpleVo.PurchaseSiglePrice = sendOrderInfo.PurchaseSiglePrice;
            sendOrderInfoSimpleVo.HospitalName = sendOrderInfo.HospitalName;
            sendOrderInfoSimpleVo.IsUncertainDate = sendOrderInfo.IsUncertainDate;
            sendOrderInfoSimpleVo.AppointmentDate = sendOrderInfo.AppointmentDate;
            sendOrderInfoSimpleVo.Time = sendOrderInfo.Time;
            sendOrderInfoSimpleVo.TimeType = sendOrderInfo.TimeType;
            sendOrderInfoSimpleVo.GoodsId = sendOrderInfo.GoodsId;
            sendOrderInfoSimpleVo.GoodsName = sendOrderInfo.GoodsName;
            sendOrderInfoSimpleVo.AppType = sendOrderInfo.AppType;
            sendOrderInfoSimpleVo.AppTypeText = sendOrderInfo.AppTypeText;
            sendOrderInfoSimpleVo.IsMainHospital = sendOrderInfo.IsMainHospital;

            return ResultData<SendOrderInfoSimpleVo>.Success().AddData("sendOrderInfo", sendOrderInfoSimpleVo);
        }



        /// <summary>
        /// 修改派单
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateSendOrderInfoVo updateVo)
        {
            OperationAddDto operationLog = new OperationAddDto();
            operationLog.Source = (int)RequestSource.AmiyaBackground;
            operationLog.Code = 0;
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                operationLog.OperationBy = employeeId;
                UpdateSendOrderInfoDto updateDto = new UpdateSendOrderInfoDto();
                updateDto.Id = updateVo.Id;
                updateDto.HospitalId = updateVo.HospitalId;
                updateDto.PurchaseSinglePrice = updateVo.PurchaseSinglePrice;
                updateDto.PurchaseNum = updateVo.PurchaseNum;
                updateDto.IsUncertainDate = updateVo.IsUncertainDate;
                updateDto.AppointmentDate = updateVo.AppointmentDate;
                updateDto.TimeType = updateVo.TimeType;
                updateDto.Content = updateVo.Content;

                await sendOrderInfoService.UpdateAsync(updateDto, employeeId);
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
        /// 医院获取派单信息
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listOfHospital")]
        [FxTenantAuthorize]
        public async Task<ResultData<FxPageInfo<SendOrderInfoVo>>> GetListByHospitalIdAsync(string keyword, DateTime? startDate, DateTime? endDate, int pageNum, int pageSize)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;
            var q = await sendOrderInfoService.GetListByHospitalIdAsync(hospitalId, keyword, startDate, endDate, pageNum, pageSize, false);
            var sendOrder = from d in q.List
                            select new SendOrderInfoVo
                            {
                                Id = d.Id,
                                OrderId = d.OrderId,
                                HospitalId = d.HospitalId,
                                HospitalName = d.HospitalName,
                                SendBy = d.SendBy,
                                SendName = d.SendName,
                                SendDate = d.SendDate,
                                IsUncertainDate = d.IsUncertainDate,
                                AppointmentDate = d.AppointmentDate,
                                TimeType = d.TimeType,
                                Time = d.Time,
                                GoodsId = d.GoodsId,
                                GoodsName = d.GoodsName,
                                ActualPayment = d.ActualPayment,
                                PurchaseNum = d.PurchaseNum,
                                PurchaseSinglePrice = d.PurchaseSinglePrice,
                                ThumbPicUrl = d.ThumbPicUrl,
                                Description = d.Description,
                                Standard = d.Standard,
                                Parts = d.Parts,
                                Phone = d.Phone,
                                EncryptPhone = d.EncryptPhone,
                                AppType = d.AppType,
                                AppTypeText = d.AppTypeText,
                                FirstMessageContent = d.FirstMessageContent
                            };

            FxPageInfo<SendOrderInfoVo> sendOrderPageInfo = new FxPageInfo<SendOrderInfoVo>();
            sendOrderPageInfo.TotalCount = q.TotalCount;
            sendOrderPageInfo.List = sendOrder;
            return ResultData<FxPageInfo<SendOrderInfoVo>>.Success().AddData("sendOrderInfo", sendOrderPageInfo);
        }

        /// <summary>
        /// 医院导出(下单平台)派单信息
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("exportOfHospital")]
        [FxTenantAuthorize]
        public async Task<FileStreamResult> ExportListByHospitalIdAsync(string keyword, DateTime? startDate, DateTime? endDate)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;
            var hospitalInfo = await hospitalInfoService.GetBaseByIdAsync(hospitalId);
            var q = await sendOrderInfoService.GetHospitalOrderReportAsync(startDate, endDate, hospitalInfo.Name, false);
            var sendOrder = from d in q
                            select new ExportSendOrderInfoVo
                            {
                                OrderId = d.OrderId,
                                SendDate = d.SendDate,
                                AppointmentDate = d.Time,
                                GoodsName = d.GoodsName,
                                PurchaseNum = d.PurchaseNum,
                                PurchaseSinglePrice = d.PurchaseSinglePrice.Value,
                                Description = d.Description,
                                Standard = d.Standard,
                                Phone = d.EncryptPhone
                            };

            var exportSendOrder = sendOrder.ToList();
            var stream = ExportExcelHelper.ExportExcel(exportSendOrder);
            var result = File(stream, "application/vnd.ms-excel", $"" + startDate.Value.ToString("yyyy年MM月dd日") + "-" + endDate.Value.ToString("yyyy年MM月dd日") + "下单平台派单报表.xls");
            return result;
        }





        /// <summary>
        /// 医院根据客户的加密电话获取派给该医院的订单列表
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("customerHospitalOrders")]
        [FxTenantAuthorize]
        public async Task<ResultData<FxPageInfo<SendOrderInfoVo>>> GetCustomerHospitalOrdersAsync(string encryptPhone, int pageNum, int pageSize)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;

            var orderPageInfo = await sendOrderInfoService.GetCustomerHospitalOrdersAsync(hospitalId, encryptPhone, pageNum, pageSize);
            var orders = from d in orderPageInfo.List
                         select new SendOrderInfoVo
                         {
                             Id = d.Id,
                             OrderId = d.OrderId,
                             HospitalId = d.HospitalId,
                             HospitalName = d.HospitalName,
                             SendBy = d.SendBy,
                             SendName = d.SendName,
                             SendDate = d.SendDate,
                             IsUncertainDate = d.IsUncertainDate,
                             AppointmentDate = d.AppointmentDate,
                             TimeType = d.TimeType,
                             Time = d.Time,
                             GoodsId = d.GoodsId,
                             GoodsName = d.GoodsName,
                             ActualPayment = d.ActualPayment,
                             ThumbPicUrl = d.ThumbPicUrl,
                             Description = d.Description,
                             Standard = d.Standard,
                             Parts = d.Parts,
                             Phone = d.Phone,
                             EncryptPhone = d.EncryptPhone,
                             StatusCode = d.StatusCode,
                             StatusText = d.StatusText,
                             AppType = d.AppType,
                             AppTypeText = d.AppTypeText,
                             FirstMessageContent = d.FirstMessageContent
                         };
            FxPageInfo<SendOrderInfoVo> sendOrderPageInfo = new FxPageInfo<SendOrderInfoVo>();
            sendOrderPageInfo.TotalCount = orderPageInfo.TotalCount;
            sendOrderPageInfo.List = orders;
            return ResultData<FxPageInfo<SendOrderInfoVo>>.Success().AddData("sendOrderInfo", sendOrderPageInfo);
        }


        /// <summary>
        /// 添加派单留言板
        /// </summary>
        /// <param name="addSendOrderMessageBoard"></param>
        /// <returns></returns>
        [HttpPost("messageBoard")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData> AddSendOrderMessageBoardAsync(AddSendOrderMessageBoardVo addSendOrderMessageBoard)
        {
            AddSendOrderMessageBoardDto addSendOrderMessageBoardDto = new AddSendOrderMessageBoardDto();

            if (httpContextAccessor.HttpContext.User is FxAmiyaEmployeeIdentity employee)

            {
                if (addSendOrderMessageBoard.HospitalId == null)
                    throw new Exception("医院编号不能为空");
                addSendOrderMessageBoardDto.Type = (byte)SendOrderMessageBoardType.Amiya;
                addSendOrderMessageBoardDto.AmiyaEmployeeId = Convert.ToInt32(employee.Id);
                addSendOrderMessageBoardDto.HospitalId = (int)addSendOrderMessageBoard.HospitalId;
            }
            if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
            {
                addSendOrderMessageBoardDto.Type = (byte)SendOrderMessageBoardType.Hospital;
                addSendOrderMessageBoardDto.HospitalEmployeeId = Convert.ToInt32(tenant.Id);
                addSendOrderMessageBoardDto.HospitalId = tenant.HospitalId;
            }
            addSendOrderMessageBoardDto.SendOrderInfoId = addSendOrderMessageBoard.Id;
            addSendOrderMessageBoardDto.Content = addSendOrderMessageBoard.Content;

            await sendOrderInfoService.AddSendOrderMessageBoardAsync(addSendOrderMessageBoardDto);
            return ResultData.Success();
        }




        /// <summary>
        /// 根据派单信息编号获取派单留言板列表
        /// </summary>
        /// <param name="id">派单信息编号</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("messageBoardListById")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<FxPageInfo<SendOrderMessageBoardVo>>> GetSendOrderMessageBoardListByIdAsync(int id, int pageNum, int pageSize)
        {
            int? hospitalId = null;

            if (httpContextAccessor.HttpContext.User is FxAmiyaHospitalEmployeeIdentity tenant)
            {
                hospitalId = tenant.HospitalId;
            }
            var q = await sendOrderInfoService.GetSendOrderMessageBoardListByIdAsync(hospitalId, id, pageNum, pageSize);
            var sendOrderMessageBoards = from d in q.List
                                         select new SendOrderMessageBoardVo
                                         {
                                             Id = d.Id,
                                             Date = d.Date,
                                             Type = d.Type,
                                             TypeName = d.TypeName,
                                             SendOrderInfoId = d.SendOrderInfoId,
                                             HospitalLogo = d.HospitalLogo,
                                             HospitalId = d.HospitalId,
                                             Content = d.Content
                                         };

            FxPageInfo<SendOrderMessageBoardVo> pageInfo = new FxPageInfo<SendOrderMessageBoardVo>();
            pageInfo.TotalCount = q.TotalCount;
            pageInfo.List = sendOrderMessageBoards;
            return ResultData<FxPageInfo<SendOrderMessageBoardVo>>.Success().AddData("sendOrderMessageBoards", pageInfo);
        }
    }
}