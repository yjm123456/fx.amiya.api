using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.Appointment;
using Fx.Amiya.Background.Api.Vo.OrderReport.OutPut;
using Fx.Amiya.Background.Api.Vo.OrderReport.Input;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{

    /// <summary>
    /// 报表接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class OrderReportController : ControllerBase
    {
        private IOperationLogService operationLogService;
        private IOrderService orderService;
        private ISendOrderInfoService _sendOrderInfoService;
        private IShoppingCartRegistrationService _shoppingCartRegistrationService;
        private IContentPlatFormOrderDealInfoService _contentPlatFormOrderDealInfoService;
        private IHospitalInfoService _hospitalInfoService;
        private IShootingAndClipService shootingAndClipService;
        private ICustomerService customerService;
        private IHttpContextAccessor httpContextAccessor;
        private IContentPlateFormOrderService _contentPlatFormOrderService;
        private IContentPlatformOrderSendService _sendContentPlatFormOrderInfoService;
        private IAppointmentService appointmentService;
        private ICustomerHospitalConsumeService _customerHospitalConsumeService;
        private ILiveAnchorDailyTargetService _liveAnchorDailyTargetService;
        private IOperationLogService operatonLogService;
        private ILiveAnchorService liveAnchorService;
        public OrderReportController(IOrderService orderService,
            IContentPlatformOrderSendService sendContentPlatFormOrderInfoService,
            IAppointmentService appointmentService,
            IHttpContextAccessor httpContextAccessor,
            IShootingAndClipService shootingAndClipService,
            IOperationLogService operationLogService,
            ICustomerService customerService,
            IContentPlateFormOrderService contentPlatFormOrderService,
            IHospitalInfoService hospitalInfoService,
            IContentPlatFormOrderDealInfoService contentPlatFormOrderDealInfoService,
            ISendOrderInfoService sendOrderInfoService,
            ICustomerHospitalConsumeService customerHospitalConsumeService,
            IShoppingCartRegistrationService shoppingCartRegistrationService,
            ILiveAnchorDailyTargetService liveAnchorDailyTargetService, IOperationLogService operatonLogService, ILiveAnchorService liveAnchorService)
        {
            this.orderService = orderService;
            _sendContentPlatFormOrderInfoService = sendContentPlatFormOrderInfoService;
            _sendOrderInfoService = sendOrderInfoService;
            this.httpContextAccessor = httpContextAccessor;
            this.appointmentService = appointmentService;
            this.operationLogService = operationLogService;
            _contentPlatFormOrderDealInfoService = contentPlatFormOrderDealInfoService;
            this.shootingAndClipService = shootingAndClipService;
            this.customerService = customerService;
            _hospitalInfoService = hospitalInfoService;
            _shoppingCartRegistrationService = shoppingCartRegistrationService;
            _contentPlatFormOrderService = contentPlatFormOrderService;
            _customerHospitalConsumeService = customerHospitalConsumeService;
            _liveAnchorDailyTargetService = liveAnchorDailyTargetService;
            this.operatonLogService = operatonLogService;
            this.liveAnchorService = liveAnchorService;
        }

        /// <summary>
        /// 获取订单经营情况
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns></returns>
        [HttpGet("OrderOperationCondition")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<OrderOperationConditionVo>>> GetOrderOperationConditionAsync(DateTime? startDate, DateTime? endDate)
        {
            TimeSpan timeSpan = endDate.Value - startDate.Value;
            var date = timeSpan.TotalDays;
            List<OrderOperationConditionVo> orderOperationCondition = new List<OrderOperationConditionVo>();
            var q = await orderService.GetOrderOperationConditionAsync(startDate, endDate);
            for (int x = 0; x <= date; x++)
            {
                OrderOperationConditionVo condition = new OrderOperationConditionVo();
                condition.Date = endDate.Value.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderNum = 0;
                orderOperationCondition.Add(condition);
            }
            foreach (var x in q)
            {
                orderOperationCondition.Find(z => z.Date == x.Date).OrderNum = x.OrderNum;
            }
            return ResultData<List<OrderOperationConditionVo>>.Success().AddData("orderOperationCondition", orderOperationCondition);
        }

        /// <summary>
        ///  获取预约经营情况
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns></returns>
        [HttpGet("AppointmentOperationCondition")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<AppointmentOperationConditionVo>>> GetAppointmentOperationConditionAsync(DateTime? startDate, DateTime? endDate)
        {
            TimeSpan timeSpan = endDate.Value - startDate.Value;
            var date = timeSpan.TotalDays;
            List<AppointmentOperationConditionVo> appointmentOperationCondition = new List<AppointmentOperationConditionVo>();
            var q = await appointmentService.GetAppointmentOperationConditionAsync(startDate, endDate);
            for (int x = 0; x <= date; x++)
            {
                AppointmentOperationConditionVo condition = new AppointmentOperationConditionVo();
                condition.Date = endDate.Value.AddDays(-x).ToString("yyyy-MM-dd");
                condition.AppointmentNum = 0;
                appointmentOperationCondition.Add(condition);
            }
            foreach (var x in q)
            {
                appointmentOperationCondition.Find(z => z.Date == x.Date).AppointmentNum = x.AppointmentNum;
            }
            return ResultData<List<AppointmentOperationConditionVo>>.Success().AddData("appointmentOperationCondition", appointmentOperationCondition);
        }


        /// <summary>
        /// 付款订单报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("OrderBuyReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<BuyOrderReportVo>>> GetOrderBuyAsync([FromQuery] GetOrderBuyExportVo query)
        {

            var q = await orderService.GetOrderBuyAsync(query.StartDate, query.EndDate, query.BelongEmpId, true);
            var res = from d in q
                      select new BuyOrderReportVo()
                      {
                          Id = d.Id,
                          GoodsName = d.GoodsName,
                          NickName = d.NickName,
                          Phone = d.Phone,
                          AppointmentHospital = d.AppointmentHospital,
                          UpdateDate = d.UpdateDate,
                          StatusText = d.StatusText,
                          ActualPayment = d.ActualPayment,
                          CreateDate = d.CreateDate,
                          AppTypeText = d.AppTypeText,
                          Quantity = d.Quantity,
                          BelongEmpName = d.BelongEmpName
                      };
            return ResultData<List<BuyOrderReportVo>>.Success().AddData("OrderWriteOffReport", res.ToList());
        }
        /// <summary>
        /// 付款订单报表导出
        /// </summary>
        /// <returns></returns>
        [HttpGet("OrderBuyReportExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> GetOrderBuyExportAsync([FromQuery] GetOrderBuyExportVo query)
        {
            OperationAddDto operationAddDto = new OperationAddDto();
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                bool isHidePhone = true;

                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                operationAddDto.OperationBy = Convert.ToInt32(employee.Id);
                var q = await orderService.GetOrderBuyAsync(query.StartDate, query.EndDate, query.BelongEmpId, isHidePhone);
                var res = from d in q
                          select new BuyOrderReportVo()
                          {
                              Id = d.Id,
                              Phone = d.Phone,
                              GoodsName = d.GoodsName,
                              NickName = d.NickName,
                              UpdateDate = d.UpdateDate,
                              AppointmentHospital = d.AppointmentHospital,
                              StatusText = d.StatusText,
                              ActualPayment = d.ActualPayment,
                              CreateDate = d.CreateDate,
                              AppTypeText = d.AppTypeText,
                              Quantity = d.Quantity,
                              BelongEmpName = d.BelongEmpName
                          };
                var exportOrderWriteOff = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "已付款订单报表.xls");
                return result;
            }
            catch (Exception err)
            {
                operationAddDto.Code = -1;
                operationAddDto.Message = err.Message.ToString();
                throw new Exception(err.Message.ToString());
            }
            finally
            {
                
                operationAddDto.Parameters = JsonConvert.SerializeObject(query);
                operationAddDto.RequestType = (int)RequestType.Export;
                operationAddDto.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationAddDto);
            }
        }

        /// <summary>
        /// 退款订单报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("OrderCloseReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<BuyOrderReportVo>>> GetOrderCloseAsync([FromQuery] BaseQueryVo query)
        {

            var q = await orderService.GetOrderCloseAsync(query.StartDate, query.EndDate, true);
            var res = from d in q
                      select new BuyOrderReportVo()
                      {
                          Id = d.Id,
                          GoodsName = d.GoodsName,
                          NickName = d.NickName,
                          Phone = d.Phone,
                          AppointmentHospital = d.AppointmentHospital,
                          UpdateDate = d.UpdateDate,
                          StatusText = d.StatusText,
                          ActualPayment = d.ActualPayment,
                          CreateDate = d.CreateDate,
                          AppTypeText = d.AppTypeText,
                          Quantity = d.Quantity,
                      };
            return ResultData<List<BuyOrderReportVo>>.Success().AddData("OrderWriteOffReport", res.ToList());
        }
        /// <summary>
        /// 退款订单报表导出
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("OrderCloseReportExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> GetOrderCloseExportAsync([FromQuery] BaseQueryVo query)
        {
            OperationAddDto operationAddDto = new OperationAddDto();
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                operationAddDto.OperationBy = Convert.ToInt32(employee.Id);
                bool isHidePhone = true;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                var q = await orderService.GetOrderCloseAsync(query.StartDate, query.EndDate, isHidePhone);
                var res = from d in q
                          select new BuyOrderReportVo()
                          {
                              Id = d.Id,
                              Phone = d.Phone,
                              GoodsName = d.GoodsName,
                              NickName = d.NickName,
                              UpdateDate = d.UpdateDate,
                              AppointmentHospital = d.AppointmentHospital,
                              StatusText = d.StatusText,
                              ActualPayment = d.ActualPayment,
                              CreateDate = d.CreateDate,
                              AppTypeText = d.AppTypeText,
                              Quantity = d.Quantity,
                          };
                var exportOrderWriteOff = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "退款订单报表.xls");
                return result;
            }
            catch (Exception err)
            {
                operationAddDto.Code = -1;
                operationAddDto.Message = err.Message.ToString();
                throw new Exception(err.Message.ToString());
            }
            finally
            {
                
                operationAddDto.Parameters = JsonConvert.SerializeObject(query);
                operationAddDto.RequestType = (int)RequestType.Export;
                operationAddDto.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationAddDto);
            }
        }

        /// <summary>
        /// 订单核销报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("OrderWriteOffReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<WriteOffOrderReportVo>>> GetOrderWriteOffAsync([FromQuery] BaseQueryVo query)
        {
            var q = await orderService.GetOrderWriteOffAsync(query.StartDate, query.EndDate, true);
            var res = from d in q
                      select new WriteOffOrderReportVo()
                      {
                          Id = d.Id,
                          GoodsName = d.GoodsName,
                          NickName = d.NickName,
                          EncryptPhone = d.EncryptPhone,
                          AppointmentHospital = d.AppointmentHospital,
                          StatusText = d.StatusText,
                          ActualPayment = d.ActualPayment,
                          CreateDate = d.CreateDate,
                          WriteOffDate = d.WriteOffDate,
                          AppTypeText = d.AppTypeText,
                          Quantity = d.Quantity,
                          SendOrderHospital = d.SendOrderHospital
                      };
            return ResultData<List<WriteOffOrderReportVo>>.Success().AddData("OrderWriteOffReport", res.ToList());

        }
        /// <summary>
        /// 订单核销报表导出
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("OrderWriteOffReportExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> GetOrderWriteOffExportAsync([FromQuery] BaseQueryVo query)
        {
            OperationAddDto operationAddDto = new OperationAddDto();
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                operationAddDto.OperationBy = Convert.ToInt32(employee.Id);
                bool isHidePhone = true;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                var q = await orderService.GetOrderWriteOffAsync(query.StartDate, query.EndDate, isHidePhone);
                var res = from d in q
                          select new WriteOffOrderReportVo()
                          {
                              Id = d.Id,
                              GoodsName = d.GoodsName,
                              NickName = d.NickName,
                              EncryptPhone = d.EncryptPhone,
                              AppointmentHospital = d.AppointmentHospital,
                              StatusText = d.StatusText,
                              ActualPayment = d.ActualPayment,
                              CreateDate = d.CreateDate,
                              WriteOffDate = d.WriteOffDate,
                              AppTypeText = d.AppTypeText,
                              Quantity = d.Quantity,
                              SendOrderHospital = d.SendOrderHospital
                          };
                var exportOrderWriteOff = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "订单核销报表.xls");
                return result;
            }
            catch (Exception err)
            {
                operationAddDto.Code = -1;
                operationAddDto.Message = err.Message.ToString();
                throw new Exception(err.Message.ToString());
            }
            finally
            {
                
                operationAddDto.Parameters = JsonConvert.SerializeObject(query);
                operationAddDto.RequestType = (int)RequestType.Export;
                operationAddDto.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationAddDto);
            }
        }


        /// <summary>
        /// 小黄车登记报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("ShoppingCartRegistrationReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<ShoppingCartRegistrationReportVo>>> GetShoppingCartRegistrationAsync([FromQuery] QueryShoppingCartRegistrationReportVo query)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var q = await _shoppingCartRegistrationService.GetShoppingCartRegistrationReportAsync(query.StartDate, query.EndDate, query.emergencyLevel, query.LiveAnchorId, query.IsCreateOrder, query.IsSendOrder, employeeId, query.IsAddWechat, query.IsWriteOff, query.IsConsultation, query.IsReturnBackPrice, query.KeyWord, query.ContentPlatFormId, true,query.BaseLiveAnchorId,query.Source);
            var res = from d in q
                      select new ShoppingCartRegistrationReportVo()
                      {
                          Id = d.Id,
                          RecordDate = d.RecordDate,
                          ContentPlatFormName = d.ContentPlatFormName,
                          LiveAnchorName = d.LiveAnchorName,
                          IsAddWechat = d.IsAddWeChat == true ? "是" : "否",
                          EmergencyLevelText = ServiceClass.GetShopCartRegisterEmergencyLevelText(d.EmergencyLevel),
                          LiveAnchorWechatNo = d.LiveAnchorWechatNo,
                          CustomerNickName = d.CustomerNickName,
                          BaseLiveAnchorName = d.BaseLiveAnchorName,
                          SourceText = d.SourceText,
                          Phone = d.Phone,
                          Price = d.Price,
                          ConsultationTypeText = d.ConsultationTypeText,
                          IsCreateOrder = d.IsCreateOrder == true ? "是" : "否",
                          IsSendOrder = d.IsSendOrder == true ? "是" : "否",
                          IsWriteOff = d.IsWriteOff == true ? "是" : "否",
                          IsConsultation = d.IsConsultation == true ? "是" : "否",
                          IsReturnBackPrice = d.IsReturnBackPrice == true ? "是" : "否",
                          Remark = d.Remark,
                          CreateBy = d.CreateByName,
                          CreateDate = d.CreateDate,
                          ProductTypeText = d.ProductTypeText

                      };
            return ResultData<List<ShoppingCartRegistrationReportVo>>.Success().AddData("OrderWriteOffReport", res.ToList());
        }
        /// <summary>
        /// 小黄车登记报表导出
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("ShoppingCartRegistrationExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> GetShoppingCartRegistrationExportAsync([FromQuery] QueryShoppingCartRegistrationReportVo query)
        {
            OperationAddDto operationAddDto = new OperationAddDto();
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                operationAddDto.OperationBy = Convert.ToInt32(employee.Id);
                bool isHidePhone = true;
                int employeeId = Convert.ToInt32(employee.Id);
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                var q = await _shoppingCartRegistrationService.GetShoppingCartRegistrationReportAsync(query.StartDate, query.EndDate, query.emergencyLevel, query.LiveAnchorId, query.IsCreateOrder, query.IsSendOrder, employeeId, query.IsAddWechat, query.IsWriteOff, query.IsConsultation, query.IsReturnBackPrice, query.KeyWord, query.ContentPlatFormId, isHidePhone,query.BaseLiveAnchorId,query.Source);
                var res = from d in q
                          select new ShoppingCartRegistrationReportVo()
                          {
                              Id = d.Id,
                              RecordDate = d.RecordDate,
                              ContentPlatFormName = d.ContentPlatFormName,
                              EmergencyLevelText = ServiceClass.GetShopCartRegisterEmergencyLevelText(d.EmergencyLevel),
                              LiveAnchorName = d.LiveAnchorName,
                              IsAddWechat = d.IsAddWeChat == true ? "是" : "否",
                              BaseLiveAnchorName=d.BaseLiveAnchorName,
                              SourceText=d.SourceText,
                              IsCreateOrder = d.IsCreateOrder == true ? "是" : "否",
                              IsSendOrder = d.IsSendOrder == true ? "是" : "否",
                              LiveAnchorWechatNo = d.LiveAnchorWechatNo,
                              CustomerNickName = d.CustomerNickName,
                              Phone = d.Phone,
                              Price = d.Price,
                              ConsultationTypeText = d.ConsultationTypeText,
                              IsWriteOff = d.IsWriteOff == true ? "是" : "否",
                              IsConsultation = d.IsConsultation == true ? "是" : "否",
                              IsReturnBackPrice = d.IsReturnBackPrice == true ? "是" : "否",
                              Remark = d.Remark,
                              CreateBy = d.CreateByName,
                              CreateDate = d.CreateDate,
                              ProductTypeText=d.ProductTypeText
                          };
                var exportOrderWriteOff = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "小黄车登记报表.xls");
                return result;
            }
            catch (Exception err)
            {
                operationAddDto.Code = -1;
                operationAddDto.Message = err.Message.ToString();
                throw new Exception(err.Message.ToString());
            }
            finally
            {
                
                operationAddDto.Parameters = JsonConvert.SerializeObject(query);
                operationAddDto.RequestType = (int)RequestType.Export;
                operationAddDto.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationAddDto);
            }
        }
        /// <summary>
        /// 内容平台订单成交报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("ContentPlatFormOrderDealReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<ContentPlatFormOrderDealInfoVo>>> GetContentPlatFormOrderDealAsync([FromQuery] QueryContentPlatFormOrderDeal query)
        {
            var q = await _contentPlatFormOrderService.GetOrderDealAsync(query.StartDate, query.EndDate, query.BelongMonth, query.MinAddOrderPrice, query.MaxAddOrderPrice, query.DealHospitalId, query.CheckState, query.LiveAnchorId, true);
            var res = from d in q
                      select new ContentPlatFormOrderDealInfoVo()
                      {
                          Id = d.Id,
                          OrderTypeText = d.OrderTypeText,
                          ContentPlatformName = d.ContentPlatformName,
                          LiveAnchorName = d.LiveAnchorName,
                          BelongMonth = d.BelongMonth == 0 ? "当月" : "次月",
                          AddOrderPrice = d.AddOrderPrice,
                          LiveAnchorWeChatNo = d.LiveAnchorWeChatNo,
                          IsOldCustomer = d.IsOldCustomer == true ? "老客业绩" : "新客业绩",
                          IsAcompanying = d.IsAcompanying == true ? "是" : "否",
                          CreateDate = d.CreateDate,
                          CustomerName = d.CustomerName,
                          Phone = d.Phone,
                          AppointmentHospitalName = d.AppointmentHospitalName,
                          GoodsName = d.GoodsName,
                          ConsultationTypeText = d.ConsultationTypeText,
                          ConsultingContent = d.ConsultingContent,
                          OrderStatusText = d.OrderStatusText,
                          DepositAmount = d.DepositAmount,
                          DealAmount = d.DealAmount,
                          DealDate = d.DealDate,
                          UnDealReason = d.UnDealReason,
                          LateProjectStage = d.LateProjectStage,
                          Remark = d.Remark,
                          CheckStateText = d.CheckStateText,
                          CheckPrice = d.CheckPrice,
                          SettlePrice = d.SettlePrice,
                          LastDealHospital = d.LastDealHospital,
                          CheckDate = d.CheckDate,
                          CheckByName = d.CheckByName,
                          BelongEmpName = d.BelongEmpName,
                          CheckRemark = d.CheckRemark,
                          IsReturnBackPrice = d.IsReturnBackPrice,
                          ReturnBackDate = d.ReturnBackDate,
                          ReturnBackPrice = d.ReturnBackPrice,
                          OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                          CommissionRatio = d.CommissionRatio,
                      };
            return ResultData<List<ContentPlatFormOrderDealInfoVo>>.Success().AddData("ContentPlatFormOrderDealInfo", res.ToList());
        }

        /// <summary>
        /// 内容平台订单成交报表导出
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("ExportContentPlatFormOrderDealReport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> ExportContentPlatFormOrderDealAsync([FromQuery] QueryContentPlatFormOrderDeal query)
        {
            OperationAddDto operationAddDto = new OperationAddDto();
            try
            {
                bool isHidePhone = true;
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                operationAddDto.OperationBy = Convert.ToInt32(employee.Id);
                var q = await _contentPlatFormOrderService.GetOrderDealAsync(query.StartDate, query.EndDate, query.BelongMonth, query.MinAddOrderPrice, query.MaxAddOrderPrice, query.DealHospitalId, query.CheckState, query.LiveAnchorId, isHidePhone);
                var res = from d in q
                          select new ContentPlatFormOrderDealInfoVo()
                          {
                              Id = d.Id,
                              OrderTypeText = d.OrderTypeText,
                              BelongMonth = d.BelongMonth == 0 ? "当月" : "次月",
                              AddOrderPrice = d.AddOrderPrice,
                              ContentPlatformName = d.ContentPlatformName,
                              LiveAnchorName = d.LiveAnchorName,
                              LiveAnchorWeChatNo = d.LiveAnchorWeChatNo,
                              ConsultationTypeText = d.ConsultationTypeText,
                              IsOldCustomer = d.IsOldCustomer == true ? "老客业绩" : "新客业绩",
                              IsAcompanying = d.IsAcompanying == true ? "是" : "否",
                              CreateDate = d.CreateDate,
                              CustomerName = d.CustomerName,
                              Phone = d.Phone,
                              AppointmentHospitalName = d.AppointmentHospitalName,
                              GoodsName = d.GoodsName,
                              ConsultingContent = d.ConsultingContent,
                              OrderStatusText = d.OrderStatusText,
                              DepositAmount = d.DepositAmount,
                              DealAmount = d.DealAmount,
                              DealDate = d.DealDate,
                              UnDealReason = d.UnDealReason,
                              LateProjectStage = d.LateProjectStage,
                              Remark = d.Remark,
                              CheckStateText = d.CheckStateText,
                              CheckPrice = d.CheckPrice,
                              SettlePrice = d.SettlePrice,
                              CheckDate = d.CheckDate,
                              CheckByName = d.CheckByName,
                              BelongEmpName = d.BelongEmpName,
                              CheckRemark = d.CheckRemark,
                              IsReturnBackPrice = d.IsReturnBackPrice,
                              ReturnBackDate = d.ReturnBackDate,
                              ReturnBackPrice = d.ReturnBackPrice,
                              OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                              LastDealHospital = d.LastDealHospital,
                              CommissionRatio = d.CommissionRatio,
                          };
                var exportContentPlatFormDealOrder = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportContentPlatFormDealOrder);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "内容平台订单成交报表.xls");
                return result;
            }
            catch (Exception err)
            {
                operationAddDto.Code = -1;
                operationAddDto.Message = err.Message.ToString();
                throw new Exception(err.Message.ToString());
            }
            finally
            {
                
                operationAddDto.Parameters = JsonConvert.SerializeObject(query);
                operationAddDto.RequestType = (int)RequestType.Export;
                operationAddDto.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationAddDto);
            }
        }

        /// <summary>
        /// 获取成交情况列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("contentPlatFormOrderDealInfo")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<ContentPlatFormOrderDealInfoReportVo>>> GetDealInfo([FromQuery] QueryContentPlatFormOrderDealInfoVo query)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            List<int?> liveAnchorIds = new List<int?>();
            if (!string.IsNullOrEmpty(query.BaseLiveAnchorId))
            {
                var list = (await liveAnchorService.GetLiveAnchorListByBaseInfoId(query.BaseLiveAnchorId)).Select(e => e.Id).ToList();
                foreach (var item in list)
                {
                    liveAnchorIds.Add(item);
                }
            }
            
            var result = await _contentPlatFormOrderDealInfoService.GetOrderDealInfoListReportAsync(query.StartDate, query.EndDate, query.SendStartDate, query.SendEndDate, query.MinAddOrderPrice, query.MaxAddOrderPrice, query.ConsultationType, query.IsToHospital, query.TohospitalStartDate, query.ToHospitalEndDate, query.ToHospitalType, query.IsDeal, query.LastDealHospitalId, query.IsAccompanying, query.IsOldCustomer, query.CheckState, query.CheckStartDate, query.CheckEndDate, query.IsCreateBill, query.IsReturnBakcPrice, query.ReturnBackPriceStartDate, query.ReturnBackPriceEndDate, query.CustomerServiceId, query.BelongCompanyId, query.KeyWord, employeeId, true,query.ConsumptionType, liveAnchorIds);

            var contentPlatformOrders = from d in result
                                        select new ContentPlatFormOrderDealInfoReportVo
                                        {
                                            Id = d.Id,
                                            ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                            CreateDate = d.CreateDate,
                                            SendOrderDate = d.SendDate,
                                            OrderCreateDate = d.OrderCreateDate,
                                            ContentPlatFormName = d.ContentPlatFormName,
                                            LiveAnchorName = d.LiveAnchorName,
                                            AddOrderPrice = d.AddOrderPrice,
                                            GoodsName = d.GoodsName,
                                            CustomerNickName = d.CustomerNickName,
                                            ConsultationType = d.ConsultationTypeText,
                                            IsDeal = d.IsDeal == true ? "是" : "否",
                                            IsOldCustomer = d.IsOldCustomer == true ? "老客业绩" : "新客业绩",
                                            IsAcompanying = d.IsAcompanying == true ? "是" : "否",
                                            /*CommissionRatio = d.CommissionRatio,*/
                                            Phone = d.Phone,
                                            DealPerformanceTypeText = d.DealPerformanceTypeText,
                                            IsToHospital = d.IsToHospital == true ? "是" : "否",
                                            ToHospitalTypeText = d.ToHospitalTypeText,
                                            TohospitalDate = d.ToHospitalDate,
                                            LastDealHospital = d.LastDealHospital,
                                            Remark = d.Remark,
                                            Price = d.Price,
                                            DealDate = d.DealDate,
                                            OtherOrderId = d.OtherAppOrderId,
                                            CheckStateText = d.CheckStateText,
                                            CheckPrice = d.CheckPrice,
                                            CheckDate = d.CheckDate,
                                            CheckBy = d.CheckByEmpName,
                                            InformationPrice = d.InformationPrice,
                                            SystemUpdatePrice = d.SystemUpdatePrice,
                                            SettlePrice = d.SettlePrice,
                                            CheckRemark = d.CheckRemark,
                                            BelongCompanyName = d.BelongCompanyName,
                                            IsCreateBill = d.IsCreateBill == true ? "是" : "否",
                                            IsReturnBackPrice = d.IsReturnBackPrice == true ? "是" : "否",
                                            ReturnBackDate = d.ReturnBackDate,
                                            ReturnBackPrice = d.ReturnBackPrice,
                                            CreateByEmpName = d.CreateByEmpName,
                                            ConsumptionTypeText=d.ConsumptionTypeText,
                                            IsRepeatProfundityOrder = d.IsRepeatProfundityOrder == true ? "是" : "否",
                                            CustomerServiceSettlePrice=d.CustomerServiceSettlePrice
                                        };
            List<ContentPlatFormOrderDealInfoReportVo> pageInfo = new List<ContentPlatFormOrderDealInfoReportVo>();
            pageInfo = contentPlatformOrders.ToList();
            return ResultData<List<ContentPlatFormOrderDealInfoReportVo>>.Success().AddData("contentPlatFormOrderDealInfo", pageInfo);
        }

        /// <summary>
        /// 导出成交情况列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("exportContentPlatFormOrderDealInfo")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> ExportDealInfo([FromQuery] QueryContentPlatFormOrderDealInfoVo query)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                bool isHidePhone = true;
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                int employeeId = Convert.ToInt32(employee.Id);
                operationLog.OperationBy = employeeId;
                List<int?> liveAnchorIds = new List<int?>();
                if (!string.IsNullOrEmpty(query.BaseLiveAnchorId))
                {
                    var list = (await liveAnchorService.GetLiveAnchorListByBaseInfoId(query.BaseLiveAnchorId)).Select(e => e.Id).ToList();
                    foreach (var item in list)
                    {
                        liveAnchorIds.Add(item);
                    }
                }

                var result = await _contentPlatFormOrderDealInfoService.GetOrderDealInfoListReportAsync(query.StartDate, query.EndDate, query.SendStartDate, query.SendEndDate, query.MinAddOrderPrice, query.MaxAddOrderPrice, query.ConsultationType, query.IsToHospital, query.TohospitalStartDate, query.ToHospitalEndDate, query.ToHospitalType, query.IsDeal, query.LastDealHospitalId, query.IsAccompanying, query.IsOldCustomer, query.CheckState, query.CheckStartDate, query.CheckEndDate, query.IsCreateBill, query.IsReturnBakcPrice, query.ReturnBackPriceStartDate, query.ReturnBackPriceEndDate, query.CustomerServiceId, query.BelongCompanyId, query.KeyWord, employeeId, isHidePhone,query.ConsumptionType,liveAnchorIds);

                var contentPlatformOrders = from d in result
                                            select new ContentPlatFormOrderDealInfoReportVo
                                            {
                                                Id = d.Id,
                                                ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                                CreateDate = d.CreateDate,
                                                SendOrderDate = d.SendDate,
                                                OrderCreateDate = d.OrderCreateDate,
                                                ContentPlatFormName = d.ContentPlatFormName,
                                                LiveAnchorName = d.LiveAnchorName,
                                                GoodsName = d.GoodsName,
                                                CustomerNickName = d.CustomerNickName,
                                                ConsultationType = d.ConsultationTypeText,
                                                IsDeal = d.IsDeal == true ? "是" : "否",
                                                IsOldCustomer = d.IsOldCustomer == true ? "老客业绩" : "新客业绩",
                                                IsAcompanying = d.IsAcompanying == true ? "是" : "否",
                                                /* CommissionRatio = d.CommissionRatio,*/
                                                AddOrderPrice = d.AddOrderPrice,
                                                Phone = d.Phone,
                                                DealPerformanceTypeText = d.DealPerformanceTypeText,
                                                IsToHospital = d.IsToHospital == true ? "是" : "否",
                                                ToHospitalTypeText = d.ToHospitalTypeText,
                                                TohospitalDate = d.ToHospitalDate,
                                                LastDealHospital = d.LastDealHospital,
                                                Remark = d.Remark,
                                                Price = d.Price,
                                                DealDate = d.DealDate,
                                                ConsumptionTypeText=d.ConsumptionTypeText,
                                                OtherOrderId = d.OtherAppOrderId,
                                                BelongCompanyName = d.BelongCompanyName,
                                                IsCreateBill = d.IsCreateBill == true ? "是" : "否",
                                                CheckStateText = d.CheckStateText,
                                                CheckPrice = d.CheckPrice,
                                                CheckDate = d.CheckDate,
                                                CheckBy = d.CheckByEmpName,
                                                InformationPrice = d.InformationPrice,
                                                SystemUpdatePrice = d.SystemUpdatePrice,
                                                SettlePrice = d.SettlePrice,
                                                CheckRemark = d.CheckRemark,
                                                IsReturnBackPrice = d.IsReturnBackPrice == true ? "是" : "否",
                                                ReturnBackDate = d.ReturnBackDate,
                                                ReturnBackPrice = d.ReturnBackPrice,
                                                CreateByEmpName = d.CreateByEmpName,
                                                IsRepeatProfundityOrder = d.IsRepeatProfundityOrder == true ? "是" : "否",
                                                CustomerServiceSettlePrice=d.CustomerServiceSettlePrice
                                            };
                var exportContentPlatFormDealOrder = contentPlatformOrders.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportContentPlatFormDealOrder);
                var exportInfo = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "内容平台成交情况报表.xls");
                return exportInfo;
            }
            catch (Exception ex)
            {
                operationLog.Code = -1;
                operationLog.Message = ex.Message;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                
                operationLog.Parameters = JsonConvert.SerializeObject(query);
                operationLog.RequestType = (int)RequestType.Export;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operatonLogService.AddOperationLogAsync(operationLog);
            }
        }



        /// <summary>
        /// 下单平台订单派单报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("sendOrderReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<SendOrderReportVo>>> GetSendOrderAsync([FromQuery] QueryTmallSendOrderVo query)
        {

            var q = await _sendOrderInfoService.GetSendOrderReportAsync(query.StartDate, query.EndDate, query.Status, true);
            var res = from d in q
                      select new SendOrderReportVo()
                      {
                          OrderId = d.OrderId,
                          HospitalName = d.HospitalName,
                          SendName = d.SendName,
                          SendDate = d.SendDate,
                          Time = d.Time,
                          GoodsName = d.GoodsName,
                          ActualPayment = d.ActualPayment,
                          EncryptPhone = d.EncryptPhone,
                          StatusText = d.StatusText,
                          PurchaseSinglePrice = d.PurchaseSinglePrice,
                          PurchaseNum = d.PurchaseNum,
                          PurchasePrice = d.PurchasePrice,
                          AppTypeText = d.AppTypeText,
                      };
            return ResultData<List<SendOrderReportVo>>.Success().AddData("sendOrderReport", res.ToList());
        }
        /// <summary>
        /// 下单平台订单派单报表导出
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("sendOrderReportExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> GetSendOrderExportAsync([FromQuery] QueryTmallSendOrderVo query)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                bool isHidePhone = true;
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                operationLog.OperationBy = Convert.ToInt32(employee.Id);
                var q = await _sendOrderInfoService.GetSendOrderReportAsync(query.StartDate, query.EndDate, query.Status, isHidePhone);
                var res = from d in q
                          select new SendOrderReportVo()
                          {
                              OrderId = d.OrderId,
                              HospitalName = d.HospitalName,
                              SendName = d.SendName,
                              SendDate = d.SendDate,
                              Time = d.Time,
                              GoodsName = d.GoodsName,
                              PurchaseSinglePrice = d.PurchaseSinglePrice,
                              PurchaseNum = d.PurchaseNum,
                              PurchasePrice = d.PurchasePrice,
                              ActualPayment = d.ActualPayment,
                              EncryptPhone = d.EncryptPhone,
                              StatusText = d.StatusText,
                              AppTypeText = d.AppTypeText,
                          };
                var exportSendOrder = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportSendOrder);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "订单派单报表.xls");
                return result;
            }
            catch (Exception ex)
            {
                operationLog.Code = -1;
                operationLog.Message = ex.Message;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                
                operationLog.Parameters = JsonConvert.SerializeObject(query);
                operationLog.RequestType = (int)RequestType.Export;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operatonLogService.AddOperationLogAsync(operationLog);
            }
        }



        /// <summary>
        /// 客户预约报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerAppointmentReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<AppointmentReportVo>>> GetCustomerAppointmentAsync([FromQuery] QueryCustomerAppointmentVo query)
        {

            var q = await appointmentService.GetAppointmentReportAsync(query.StartDate, query.EndDate, query.Status, true);
            var res = from d in q
                      select new AppointmentReportVo()
                      {
                          AppointmentDate = d.AppointmentDate,
                          Week = d.Week,
                          Time = d.Time,
                          StatusText = d.StatusText,
                          ItemName = d.ItemName,
                          Phone = d.Phone,
                          HospitalName = d.HospitalName,
                          Remark = d.Remark
                      };
            return ResultData<List<AppointmentReportVo>>.Success().AddData("customerAppointmentReport", res.ToList());
        }
        /// <summary>
        /// 客户预约报表导出
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerAppointmentReportExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> GetCustomerAppointmentReportExportAsync([FromQuery] QueryCustomerAppointmentVo query)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                bool isHidePhone = true;
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                operationLog.OperationBy = Convert.ToInt32(employee.Id);
                var q = await appointmentService.GetAppointmentReportAsync(query.StartDate, query.EndDate, query.Status, isHidePhone);
                var res = from d in q
                          select new AppointmentReportVo()
                          {
                              AppointmentDate = d.AppointmentDate,
                              Week = d.Week,
                              Time = d.Time,
                              StatusText = d.StatusText,
                              ItemName = d.ItemName,
                              Phone = d.Phone,
                              HospitalName = d.HospitalName,
                              Remark = d.Remark
                          };
                var exportSendOrder = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportSendOrder);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "客户预约报表.xls");
                return result;
            }
            catch (Exception ex)
            {
                operationLog.Code = -1;
                operationLog.Message = ex.Message;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                
                operationLog.Parameters = JsonConvert.SerializeObject(query);
                operationLog.RequestType = (int)RequestType.Export;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operatonLogService.AddOperationLogAsync(operationLog);
            }
        }

        /// <summary>
        /// 医院订单量报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("hospitalOrderReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<HospitalOrderReportVo>>> GetHospitalOrderReportAsync([FromQuery] QueryHospitalOrderReportVo query)
        {

            var q = await _sendOrderInfoService.GetHospitalOrderReportAsync(query.StartDate, query.EndDate, query.HospitalName, true);
            var res = from d in q
                      select new HospitalOrderReportVo()
                      {
                          HospitalName = d.HospitalName,
                          OrderId = d.OrderId,
                          SendName = d.SendName,
                          SendDate = d.SendDate,
                          Time = d.Time,
                          GoodsName = d.GoodsName,
                          PurchaseSinglePrice = d.PurchaseSinglePrice,
                          PurchaseNum = d.PurchaseNum,
                          PurchasePrice = d.PurchasePrice,
                          ActualPayment = d.ActualPayment,
                          EncryptPhone = d.EncryptPhone,
                          StatusText = d.StatusText,
                          AppTypeText = d.AppTypeText
                      };
            return ResultData<List<HospitalOrderReportVo>>.Success().AddData("hospitalOrderReport", res.ToList());
        }
        /// <summary>
        /// 医院订单量报表导出
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("hospitalOrderReportExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> GetHospitalOrderExportAsync([FromQuery] QueryHospitalOrderReportVo query)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                bool isHidePhone = true;
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                operationLog.OperationBy = Convert.ToInt32(employee.Id);
                var q = await _sendOrderInfoService.GetHospitalOrderReportAsync(query.StartDate, query.EndDate, query.HospitalName, isHidePhone);
                var res = from d in q
                          select new HospitalOrderReportVo()
                          {
                              OrderId = d.OrderId,
                              HospitalName = d.HospitalName,
                              SendName = d.SendName,
                              SendDate = d.SendDate,
                              Time = d.Time,
                              GoodsName = d.GoodsName,
                              PurchaseSinglePrice = d.PurchaseSinglePrice,
                              PurchaseNum = d.PurchaseNum,
                              PurchasePrice = d.PurchasePrice,
                              ActualPayment = d.ActualPayment,
                              EncryptPhone = d.EncryptPhone,
                              StatusText = d.StatusText,
                              AppTypeText = d.AppTypeText
                          };
                var exportSendOrder = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportSendOrder);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "医院订单量报表.xls");
                return result;
            }
            catch (Exception ex)
            {
                operationLog.Code = -1;
                operationLog.Message = ex.Message;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                
                operationLog.Parameters = JsonConvert.SerializeObject(query);
                operationLog.RequestType = (int)RequestType.Export;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operatonLogService.AddOperationLogAsync(operationLog);
            }
        }

        /// <summary>
        /// 医院预约量报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("hospitalAppointmentReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<HospitalAppointmentReportVo>>> GetHospitalAppointmentAsync([FromQuery] QueryHospitalOrderReportVo query)
        {

            var q = await appointmentService.GetHospitalAppointmentReportAsync(query.StartDate, query.EndDate, query.HospitalName, true);
            var res = from d in q
                      select new HospitalAppointmentReportVo()
                      {
                          AppointmentDate = d.AppointmentDate,
                          Week = d.Week,
                          Time = d.Time,
                          StatusText = d.StatusText,
                          ItemName = d.ItemName,
                          Phone = d.Phone,
                          HospitalName = d.HospitalName,
                          Remark = d.Remark
                      };
            return ResultData<List<HospitalAppointmentReportVo>>.Success().AddData("hospitalAppointmentReport", res.ToList());
        }
        /// <summary>
        /// 医院预约量报表导出
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("hospitalAppointmentReportExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> GetHospitalAppointmentReportExportAsync([FromQuery] QueryHospitalOrderReportVo query)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                bool isHidePhone = true;
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                operationLog.OperationBy = Convert.ToInt32(employee.Id);
                var q = await appointmentService.GetHospitalAppointmentReportAsync(query.StartDate, query.EndDate, query.HospitalName, isHidePhone);
                var res = from d in q
                          select new HospitalAppointmentReportVo()
                          {
                              AppointmentDate = d.AppointmentDate,
                              Week = d.Week,
                              Time = d.Time,
                              StatusText = d.StatusText,
                              ItemName = d.ItemName,
                              Phone = d.Phone,
                              HospitalName = d.HospitalName,
                              Remark = d.Remark
                          };
                var exportSendOrder = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportSendOrder);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "医院预约量报表.xls");
                return result;
            }
            catch (Exception ex)
            {
                operationLog.Code = -1;
                operationLog.Message = ex.Message;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                
                operationLog.Parameters = JsonConvert.SerializeObject(query);
                operationLog.RequestType = (int)RequestType.Export;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operatonLogService.AddOperationLogAsync(operationLog);
            }
        }

        /// <summary>
        /// 下单平台客服已派单报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerSendOrderReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<CustomerSendOrderReportVo>>> GetCustomerSendOrderAsync([FromQuery] QueryCustomerSendTmallOrderVo query)
        {
            if (!query.StartDate.HasValue && !query.EndDate.HasValue)
            { throw new Exception("请选择时间进行查询"); }
            if (query.StartDate.HasValue && query.EndDate.HasValue)
            {
                if ((query.EndDate.Value - query.StartDate.Value).TotalDays > 31)
                {
                    throw new Exception("开始时间与结束时间不能超过一个月，请重新选择后再进行查询！");
                }
            }
            var q = await _sendOrderInfoService.GetCustomerSendOrderReportAsync(query.StartDate, query.EndDate, query.EmployeeId, query.BelongEmpId, query.OrderStatus, true);
            var res = from d in q
                      select new CustomerSendOrderReportVo()
                      {
                          OrderId = d.OrderId,
                          HospitalName = d.HospitalName,
                          SendName = d.SendName,
                          SendDate = d.SendDate,
                          Time = d.Time,
                          GoodsName = d.GoodsName,
                          PurchaseSinglePrice = d.PurchaseSinglePrice,
                          BelongEmpName = d.BelongEmpName,
                          PurchaseNum = d.PurchaseNum,
                          PurchasePrice = d.PurchasePrice,
                          ActualPayment = d.ActualPayment,
                          EncryptPhone = d.EncryptPhone,
                          StatusText = d.StatusText,
                          AppTypeText = d.AppTypeText,
                      };
            return ResultData<List<CustomerSendOrderReportVo>>.Success().AddData("customerSendOrderReport", res.ToList());
        }


        /// <summary>
        /// 下单平台客服已派单报表导出
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerSendOrderReportExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> GetCustomerSendOrderExportAsync([FromQuery] QueryCustomerSendTmallOrderVo query)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                if (!query.StartDate.HasValue && !query.EndDate.HasValue)
                { throw new Exception("请选择时间进行查询"); }
                if (query.StartDate.HasValue && query.EndDate.HasValue)
                {
                    if ((query.EndDate.Value - query.StartDate.Value).TotalDays > 31)
                    {
                        throw new Exception("开始时间与结束时间不能超过一个月，请重新选择后再进行查询！");
                    }
                }
                bool isHidePhone = true;
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                operationLog.OperationBy = Convert.ToInt32(employee.Id);
                var q = await _sendOrderInfoService.GetCustomerSendOrderReportAsync(query.StartDate, query.EndDate, query.EmployeeId, query.BelongEmpId, query.OrderStatus, isHidePhone);
                var res = from d in q
                          select new CustomerSendOrderReportVo()
                          {
                              OrderId = d.OrderId,
                              HospitalName = d.HospitalName,
                              SendName = d.SendName,
                              SendDate = d.SendDate,
                              Time = d.Time,
                              GoodsName = d.GoodsName,
                              PurchaseSinglePrice = d.PurchaseSinglePrice,
                              PurchaseNum = d.PurchaseNum,
                              PurchasePrice = d.PurchasePrice,
                              ActualPayment = d.ActualPayment,
                              EncryptPhone = d.EncryptPhone,
                              StatusText = d.StatusText,
                              AppTypeText = d.AppTypeText,
                              BelongEmpName = d.BelongEmpName,
                          };
                var exportSendOrder = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportSendOrder);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "客服已派单报表.xls");
                return result;
            }
            catch (Exception ex)
            {
                operationLog.Code = -1;
                operationLog.Message = ex.Message;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                
                operationLog.Parameters = JsonConvert.SerializeObject(query);
                operationLog.RequestType = (int)RequestType.Export;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operatonLogService.AddOperationLogAsync(operationLog);
            }
        }

        /// <summary>
        /// 客服下单平台未派单报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerUnSendOrderReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<CustomerUnSendOrderReportVo>>> GetCustomerUnSendOrderAsync([FromQuery] QueryCustomerTmallUnSendOrderVo query)
        {
            if (!query.StartDate.HasValue && !query.EndDate.HasValue)
            { throw new Exception("请选择时间进行查询"); }
            if (query.StartDate.HasValue && query.EndDate.HasValue)
            {
                if ((query.EndDate.Value - query.StartDate.Value).TotalDays > 31)
                {
                    throw new Exception("开始时间与结束时间不能超过一个月，请重新选择后再进行查询！");
                }
            }
            var q = await _sendOrderInfoService.GetUnSendOrderReportWithPageAsync(query.StartDate, query.EndDate, query.EmployeeId, true);
            var res = from d in q
                      select new CustomerUnSendOrderReportVo()
                      {
                          OrderId = d.OrderId,
                          GoodsName = d.GoodsName,
                          EncryptPhone = d.EncryptPhone,
                          AppointmentHospital = d.AppointmentHospital,
                          ActualPayment = d.ActualPayment,
                          CreateDate = d.CreateDate,
                          StatusText = d.StatusText,
                          AppTypeText = d.AppTypeText,
                          BindCustomerServiceName = d.BindCustomerServiceName,
                      };
            return ResultData<List<CustomerUnSendOrderReportVo>>.Success().AddData("customerUnSendOrderReport", res.ToList());
        }

        /// <summary>
        /// 客服下单平台未派单报表导出
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerUnSendOrderReportExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> GetCustomerUnSendOrderExportAsync([FromQuery] QueryCustomerTmallUnSendOrderVo query)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                if (!query.StartDate.HasValue && !query.EndDate.HasValue)
                { throw new Exception("请选择时间进行查询"); }
                if (query.StartDate.HasValue && query.EndDate.HasValue)
                {
                    if ((query.EndDate.Value - query.StartDate.Value).TotalDays > 31)
                    {
                        throw new Exception("开始时间与结束时间不能超过一个月，请重新选择后再进行查询！");
                    }
                }
                bool isHidePhone = true;
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                operationLog.OperationBy = Convert.ToInt32(employee.Id);
                var q = await _sendOrderInfoService.GetUnSendOrderReportWithPageAsync(query.StartDate, query.EndDate, query.EmployeeId, isHidePhone);
                var res = from d in q
                          select new CustomerUnSendOrderReportVo()
                          {
                              OrderId = d.OrderId,
                              GoodsName = d.GoodsName,
                              EncryptPhone = d.EncryptPhone,
                              AppointmentHospital = d.AppointmentHospital,
                              ActualPayment = d.ActualPayment,
                              CreateDate = d.CreateDate,
                              StatusText = d.StatusText,
                              AppTypeText = d.AppTypeText,
                              BindCustomerServiceName = d.BindCustomerServiceName,
                          };
                var exportSendOrder = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportSendOrder);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "下单平台客服未派单报表.xls");
                return result;
            }
            catch (Exception ex)
            {
                operationLog.Code = -1;
                operationLog.Message = ex.Message;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                
                operationLog.Parameters = JsonConvert.SerializeObject(query);
                operationLog.RequestType = (int)RequestType.Export;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operatonLogService.AddOperationLogAsync(operationLog);
            }
        }

        /// <summary>
        ///  内容平台客服已派单报表
        /// </summary>
        /// <param name="query">派单开始时间</param>
        /// <returns></returns>
        [HttpGet("customerSendContentPlatFormOrderReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<CustomerSendContentPlatFormOrderReportVo>>> GetCustomerSendContentPlatFormOrderAsync([FromQuery] QueryCustomerSendContentPlatFormOrderVo query)
        {
            if (!query.StartDate.HasValue && !query.EndDate.HasValue)
            { throw new Exception("请选择时间进行查询"); }

            if (query.EmployeeId == 0)
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                query.EmployeeId = Convert.ToInt32(employee.Id);
            }
            var q = await _sendContentPlatFormOrderInfoService.GetSendOrderReportList(query.LiveAnchorId, query.BelongMonth, query.MinAddOrderPrice, query.MaxAddOrderPrice, query.HospitalId, query.EmployeeId, query.BelongEmpId, query.OrderStatus, query.IsAcompanying, query.IsOldCustomer, query.CommissionRatio, query.ContentPlatFormId, query.IsToHospital, query.ToHospitalStartDate, query.ToHospitalEndDate, query.ToHospitalType, query.StartDate, query.EndDate, true);
            var res = from d in q
                      select new CustomerSendContentPlatFormOrderReportVo()
                      {
                          SenderName = d.SenderName,
                          SendDate = d.SendDate,
                          LiveAnchorWeChatNo = d.LiveAnchorWeChatNo,
                          ConsultationTypeText = d.ConsultationTypeText,
                          OrderId = d.OrderId,
                          ContentPlatFormName = d.ContentPlatFormName,
                          LiveAnchorName = d.LiveAnchorName,
                          GoodsName = d.GoodsName,
                          CustomerName = d.CustomerName,
                          IsOldCustomer = d.IsOldCustomer,
                          IsAcompanying = d.IsAcompanying == true ? "是" : "否",
                          /*CommissionRatio = d.CommissionRatio,*/
                          Phone = d.Phone,
                          BelongEmpName = d.BelongEmpName,
                          OrderStatusText = d.OrderStatusText,
                          IsToHospital = d.IsToHospital == true ? "是" : "否",
                          ToHospitalTypeText = d.ToHospitalTypeText,
                          ToHospitalDate = d.ToHospitalDate,
                          DepositAmount = d.DepositAmount,
                          DealAmount = d.DealAmount,
                          SendHospital = d.SendHospital,
                          SendOrderRemark = d.SendOrderRemark,
                          OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                      };
            return ResultData<List<CustomerSendContentPlatFormOrderReportVo>>.Success().AddData("customerSendContentPlatFormOrderReport", res.ToList());
        }

        /// <summary>
        ///  内容平台客服已派单报表导出
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerSendContentPlatFormOrderExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> ExportCustomerSendContentPlatFormOrderAsync([FromQuery] QueryCustomerSendContentPlatFormOrderVo query)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                bool isHidePhone = true;
                if (!query.StartDate.HasValue && !query.EndDate.HasValue)
                { throw new Exception("请选择时间进行查询"); }
                //if (startDate.HasValue && endDate.HasValue)
                //{
                //    if ((endDate.Value - startDate.Value).TotalDays > 31)
                //    {
                //        throw new Exception("开始时间与结束时间不能超过一个月，请重新选择后再进行查询！");
                //    }
                //}
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                if (query.EmployeeId == 0)
                {
                    query.EmployeeId = Convert.ToInt32(employee.Id);
                }
                operationLog.OperationBy = Convert.ToInt32(employee.Id);
                var q = await _sendContentPlatFormOrderInfoService.GetSendOrderReportList(query.LiveAnchorId, query.BelongMonth, query.MinAddOrderPrice, query.MaxAddOrderPrice, query.HospitalId, query.EmployeeId, query.BelongEmpId, query.OrderStatus, query.IsAcompanying, query.IsOldCustomer, query.CommissionRatio, query.ContentPlatFormId, query.IsToHospital, query.ToHospitalStartDate, query.ToHospitalEndDate, query.ToHospitalType, query.StartDate, query.EndDate, isHidePhone);
                var res = from d in q
                          select new CustomerSendContentPlatFormOrderReportVo()
                          {
                              SenderName = d.SenderName,
                              SendDate = d.SendDate,
                              OrderId = d.OrderId,
                              ContentPlatFormName = d.ContentPlatFormName,
                              LiveAnchorName = d.LiveAnchorName,
                              ConsultationTypeText = d.ConsultationTypeText,
                              LiveAnchorWeChatNo = d.LiveAnchorWeChatNo,
                              GoodsName = d.GoodsName,
                              CustomerName = d.CustomerName,
                              IsOldCustomer = d.IsOldCustomer,
                              IsAcompanying = d.IsAcompanying == true ? "是" : "否",
                              /*CommissionRatio = d.CommissionRatio,*/
                              Phone = d.Phone,
                              OrderStatusText = d.OrderStatusText,
                              IsToHospital = d.IsToHospital == true ? "是" : "否",
                              ToHospitalTypeText = d.ToHospitalTypeText,
                              ToHospitalDate = d.ToHospitalDate,
                              DepositAmount = d.DepositAmount,
                              DealAmount = d.DealAmount,
                              BelongEmpName = d.BelongEmpName,
                              SendHospital = d.SendHospital,
                              SendOrderRemark = d.SendOrderRemark,
                              OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                          };
                var exportSendOrder = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportSendOrder);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "内容平台客服已派单报表.xls");
                return result;
            }
            catch (Exception ex)
            {
                operationLog.Code = -1;
                operationLog.Message = ex.Message;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                
                operationLog.Parameters = JsonConvert.SerializeObject(query);
                operationLog.RequestType = (int)RequestType.Export;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operatonLogService.AddOperationLogAsync(operationLog);
            }
        }

        /// <summary>
        /// 内容平台未派单报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerunContentPlatFormSendOrderList")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<CustomerUnContentPlateFormSendOrderReportInfoVo>>> GetCustomerunContentPlatFormSendOrderListAsync([FromQuery] QueryCustomerunContentPlatFormSendOrderListVo query)
        {
            if (!query.StartDate.HasValue && !query.EndDate.HasValue)
            { throw new Exception("请选择时间进行查询"); }
            if (query.StartDate.HasValue && query.EndDate.HasValue)
            {
                if ((query.EndDate.Value - query.StartDate.Value).TotalDays > 31)
                {
                    throw new Exception("开始时间与结束时间不能超过一个月，请重新选择后再进行查询！");
                }
            }
            if (query.employeeId == null)
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                query.employeeId = Convert.ToInt32(employee.Id);
            }

            var q = await _contentPlatFormOrderService.GetUnSendOrderReportListAsync(query.liveAnchorId, query.StartDate, query.EndDate, (int)query.employeeId, query.orderStatus, query.contentPlateFormId, true);
            var unSendOrder = from d in q
                              select new CustomerUnContentPlateFormSendOrderReportInfoVo
                              {
                                  EmployeeName = d.BelongEmpName,
                                  OrderId = d.OrderId,
                                  ContentPlatFormName = d.ContentPlatFormName,
                                  LiveAnchorName = d.LiveAnchorName,
                                  GoodsName = d.GoodsName,
                                  ConsultingContent = d.ConsultingContent,
                                  CustomerName = d.CustomerName,
                                  Phone = d.Phone,
                                  DealAmount = d.DealAmount,
                                  DepositAmount = d.DepositAmount.HasValue ? d.DepositAmount : 0,
                                  OrderTypeText = d.OrderTypeText,
                                  OrderStatusText = d.OrderStatusText,
                                  AppointmentHospital = d.AppointmentHospital,
                                  Remark = d.Remark,
                                  LateProjectStage = d.LateProjectStage
                              };
            List<CustomerUnContentPlateFormSendOrderReportInfoVo> pageInfo = new List<CustomerUnContentPlateFormSendOrderReportInfoVo>();
            pageInfo = unSendOrder.ToList();
            return ResultData<List<CustomerUnContentPlateFormSendOrderReportInfoVo>>.Success().AddData("unSendOrder", pageInfo);
        }

        /// <summary>
        /// 导出内容平台未派单报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerunContentPlatFormSendOrderListExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> ExportCustomerunContentPlatFormSendOrderListAsync([FromQuery] QueryCustomerunContentPlatFormSendOrderListVo query)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                bool isHidePhone = true;
                if (!query.StartDate.HasValue && !query.EndDate.HasValue)
                { throw new Exception("请选择时间进行查询"); }
                if (query.StartDate.HasValue && query.EndDate.HasValue)
                {
                    if ((query.EndDate.Value - query.StartDate.Value).TotalDays > 31)
                    {
                        throw new Exception("开始时间与结束时间不能超过一个月，请重新选择后再进行查询！");
                    }
                }
                if (query.employeeId == null)
                {
                    var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                    query.employeeId = Convert.ToInt32(employee.Id);
                    operationLog.OperationBy = Convert.ToInt32(employee.Id);
                }
                var q = await _contentPlatFormOrderService.GetUnSendOrderReportListAsync(query.liveAnchorId, query.StartDate, query.EndDate, (int)query.employeeId, query.orderStatus, query.contentPlateFormId, isHidePhone);
                var unSendOrder = from d in q
                                  select new CustomerUnContentPlateFormSendOrderReportInfoVo
                                  {
                                      EmployeeName = d.BelongEmpName,
                                      OrderId = d.OrderId,
                                      ContentPlatFormName = d.ContentPlatFormName,
                                      LiveAnchorName = d.LiveAnchorName,
                                      GoodsName = d.GoodsName,
                                      ConsultingContent = d.ConsultingContent,
                                      CustomerName = d.CustomerName,
                                      Phone = d.Phone,
                                      DealAmount = d.DealAmount,
                                      DepositAmount = d.DepositAmount.HasValue ? d.DepositAmount : 0,
                                      OrderTypeText = d.OrderTypeText,
                                      OrderStatusText = d.OrderStatusText,
                                      AppointmentHospital = d.AppointmentHospital,
                                      Remark = d.Remark,
                                      LateProjectStage = d.LateProjectStage
                                  };
                var exportSendOrder = unSendOrder.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportSendOrder);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "内容平台客服未派单报表.xls");
                return result;
            }
            catch (Exception ex)
            {
                operationLog.Code = -1;
                operationLog.Message = ex.Message;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                
                operationLog.Parameters = JsonConvert.SerializeObject(query);
                operationLog.RequestType = (int)RequestType.Export;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operatonLogService.AddOperationLogAsync(operationLog);
            }
        }



        /// <summary>
        /// 客户订单应收款统计（交易完成订单）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerOrderReceivableReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<CustomerOrderReceivableReportVo>>> GetCustomerOrderReceivableAsync([FromQuery] QueryCustomerOrderReceivableReportVo query)
        {

            var q = await orderService.GetCustomerOrderReceivableAsync(query.StartDate, query.EndDate, query.AppType, query.CheckState, query.ReturnBackPriceState, query.IsCreateBill, query.BelongCompanyId, query.CustomerName, true);
            var res = from d in q
                      select new CustomerOrderReceivableReportVo()
                      {
                          Id = d.Id,
                          GoodsName = d.GoodsName,
                          NickName = d.NickName,
                          EncryptPhone = d.EncryptPhone,
                          AppointmentHospital = d.AppointmentHospital,
                          StatusText = d.StatusText,
                          ActuralPayment = d.ActualPayment,
                          AccountReceivable = d.AccountReceivable,
                          SendOrderPirce = d.SendOrderPrice,
                          CreateDate = d.CreateDate,
                          WriteOffDate = d.WriteOffDate,
                          AppTypeText = d.AppTypeText,
                          Quantity = d.Quantity,
                          SendOrderHospital = d.SendOrderHospital,
                          SendHospitalEmployeeName = d.SendEmployeeName,
                          FinalConsumptionHospital = d.FinalConsumptionHospital,
                          BelongEmployeeName = d.BenlongEmpName,
                          IsCreateBill = d.IsCreateBill == true ? "是" : "否",
                          BelongCompanyName = d.BelongCompanyName,
                          CheckStateText = d.CheckStateText,
                          CheckPrice = d.CheckPrice,
                          CheckDate = d.CheckDate,
                          CheckBy = d.CheckByEmpName,
                          CheckRemark = d.CheckRemark,
                          SettlePrice = d.SettlePrice,
                          IsReturnBackPrice = d.IsReturnBackPrice == true ? "已回款" : "未回款",
                          ReturnBackPrice = d.ReturnBackPrice,
                          ReturnBackDate = d.ReturnBackDate
                      };
            return ResultData<List<CustomerOrderReceivableReportVo>>.Success().AddData("customerOrderReceivableReport", res.ToList());
        }
        /// <summary>
        /// 客户订单应收款统计导出（交易完成订单）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerOrderReceivableExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> GetCustomerOrderReceivableExportAsync([FromQuery] QueryCustomerOrderReceivableReportVo query)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                bool isHidePhone = true;
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                operationLog.OperationBy = Convert.ToInt32(employee.Id);

                var q = await orderService.GetCustomerOrderReceivableAsync(query.StartDate, query.EndDate, query.AppType, query.CheckState, query.ReturnBackPriceState, query.IsCreateBill, query.BelongCompanyId, query.CustomerName, isHidePhone);
                var res = from d in q
                          select new CustomerOrderReceivableReportVo()
                          {
                              Id = d.Id,
                              GoodsName = d.GoodsName,
                              NickName = d.NickName,
                              EncryptPhone = d.EncryptPhone,
                              AppointmentHospital = d.AppointmentHospital,
                              StatusText = d.StatusText,
                              ActuralPayment = d.ActualPayment,
                              AccountReceivable = d.AccountReceivable,
                              SendOrderPirce = d.SendOrderPrice,
                              CreateDate = d.CreateDate,
                              WriteOffDate = d.WriteOffDate,
                              AppTypeText = d.AppTypeText,
                              Quantity = d.Quantity,
                              SendOrderHospital = d.SendOrderHospital,
                              SendHospitalEmployeeName = d.SendEmployeeName,
                              FinalConsumptionHospital = d.FinalConsumptionHospital,
                              BelongEmployeeName = d.BenlongEmpName,
                              CheckStateText = d.CheckStateText,
                              CheckPrice = d.CheckPrice,
                              IsCreateBill = d.IsCreateBill == true ? "是" : "否",
                              BelongCompanyName = d.BelongCompanyName,
                              CheckDate = d.CheckDate,
                              CheckBy = d.CheckByEmpName,
                              CheckRemark = d.CheckRemark,
                              SettlePrice = d.SettlePrice,
                              IsReturnBackPrice = d.IsReturnBackPrice == true ? "已回款" : "未回款",
                              ReturnBackPrice = d.ReturnBackPrice,
                              ReturnBackDate = d.ReturnBackDate
                          };
                var exportOrderWriteOff = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "客户订单应收款统计（交易完成订单）.xls");
                return result;
            }
            catch (Exception ex)
            {
                operationLog.Code = -1;
                operationLog.Message = ex.Message;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                
                operationLog.Parameters = JsonConvert.SerializeObject(query);
                operationLog.RequestType = (int)RequestType.Export;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operatonLogService.AddOperationLogAsync(operationLog);
            }
        }


        /// <summary>
        /// 客户订单应收款统计（买家已付款订单）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerPaidOrderReceivableReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<CustomerOrderReceivableReportVo>>> GetCustomerPaidOrderReceivableAsync([FromQuery] QueryCustomerPaidOrderReceivableReportVo query)
        {

            var q = await orderService.GetCustomerPaidOrderReceivableAsync(query.StartDate, query.EndDate, query.CheckState, query.ReturnBackPriceState, query.CustomerName, true);
            var res = from d in q
                      select new CustomerOrderReceivableReportVo()
                      {
                          Id = d.Id,
                          GoodsName = d.GoodsName,
                          NickName = d.NickName,
                          EncryptPhone = d.EncryptPhone,
                          AppointmentHospital = d.AppointmentHospital,
                          StatusText = d.StatusText,
                          ActuralPayment = d.ActualPayment,
                          AccountReceivable = d.AccountReceivable,
                          SendOrderPirce = d.SendOrderPrice,
                          CreateDate = d.CreateDate,
                          WriteOffDate = d.WriteOffDate,
                          AppTypeText = d.AppTypeText,
                          Quantity = d.Quantity,
                          SendOrderHospital = d.SendOrderHospital,
                          SendHospitalEmployeeName = d.SendEmployeeName,
                          FinalConsumptionHospital = d.FinalConsumptionHospital,
                          BelongEmployeeName = d.BenlongEmpName,
                          CheckStateText = d.CheckStateText,
                          CheckPrice = d.CheckPrice,
                          CheckDate = d.CheckDate,
                          CheckBy = d.CheckByEmpName,
                          CheckRemark = d.CheckRemark,
                          SettlePrice = d.SettlePrice,
                          IsReturnBackPrice = d.IsReturnBackPrice == true ? "已回款" : "未回款",
                          ReturnBackPrice = d.ReturnBackPrice,
                          ReturnBackDate = d.ReturnBackDate
                      };
            return ResultData<List<CustomerOrderReceivableReportVo>>.Success().AddData("customerOrderReceivableReport", res.ToList());
        }
        /// <summary>
        /// 客户订单应收款统计导出（买家已付款订单）
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerPaidOrderReceivableExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> GetCustomerPaidOrderReceivableExportAsync([FromQuery] QueryCustomerPaidOrderReceivableReportVo query)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                bool isHidePhone = true;
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }

                operationLog.OperationBy = Convert.ToInt32(employee.Id);
                var q = await orderService.GetCustomerPaidOrderReceivableAsync(query.StartDate, query.EndDate, query.CheckState, query.ReturnBackPriceState, query.CustomerName, isHidePhone);
                var res = from d in q
                          select new CustomerOrderReceivableReportVo()
                          {
                              Id = d.Id,
                              GoodsName = d.GoodsName,
                              NickName = d.NickName,
                              EncryptPhone = d.EncryptPhone,
                              AppointmentHospital = d.AppointmentHospital,
                              StatusText = d.StatusText,
                              ActuralPayment = d.ActualPayment,
                              AccountReceivable = d.AccountReceivable,
                              SendOrderPirce = d.SendOrderPrice,
                              CreateDate = d.CreateDate,
                              WriteOffDate = d.WriteOffDate,
                              AppTypeText = d.AppTypeText,
                              Quantity = d.Quantity,
                              SendOrderHospital = d.SendOrderHospital,
                              SendHospitalEmployeeName = d.SendEmployeeName,
                              FinalConsumptionHospital = d.FinalConsumptionHospital,
                              BelongEmployeeName = d.BenlongEmpName,
                              CheckStateText = d.CheckStateText,
                              CheckPrice = d.CheckPrice,
                              CheckDate = d.CheckDate,
                              CheckBy = d.CheckByEmpName,
                              CheckRemark = d.CheckRemark,
                              SettlePrice = d.SettlePrice,
                              IsReturnBackPrice = d.IsReturnBackPrice == true ? "已回款" : "未回款",
                              ReturnBackPrice = d.ReturnBackPrice,
                              ReturnBackDate = d.ReturnBackDate
                          };
                var exportOrderWriteOff = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "客户订单应收款统计（买家已付款订单）.xls");
                return result;
            }
            catch (Exception ex)
            {
                operationLog.Code = -1;
                operationLog.Message = ex.Message;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                
                operationLog.Parameters = JsonConvert.SerializeObject(query);
                operationLog.RequestType = (int)RequestType.Export;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operatonLogService.AddOperationLogAsync(operationLog);
            }
        }



        /// <summary>
        /// 下单平台订单报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("OrderReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<OrderReportVo>>> GetTmallOrderReportAsync([FromQuery] QueryOrderReportVo query)
        {

            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            var q = await orderService.GetTmallOrderListAsync(query.StartDate, query.EndDate, query.StatusCode, employeeId, true);
            var res = from d in q
                      select new OrderReportVo()
                      {
                          Id = d.Id,
                          AppTypeText = d.AppTypeText,
                          CreateDate = d.CreateDate,
                          WriteOffDate = d.WriteOffDate,
                          OrderNatureText = d.OrderNatureText,
                          GoodsName = d.GoodsName,
                          IntegrationQuantity = d.IntegrationQuantity,
                          ActualPayment = d.ActualPayment,
                          AccountReceivable = d.AccountReceivable,
                          Quantity = d.Quantity,
                          StatusText = d.StatusText,
                          LiveAnchorPlatForm = d.LiveAnchorPlatForm,
                          LiveAnchor = d.LiveAnchorName,
                          BelongEmpName = d.BelongEmpName,
                          NickName = d.BuyerNick,
                          Phone = d.Phone,
                          AppointmentHospital = d.AppointmentHospital
                      };
            return ResultData<List<OrderReportVo>>.Success().AddData("customerOrderReceivableReport", res.ToList());
        }

        /// <summary>
        /// 下单平台订单报表导出
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("OrderReportExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> ExportTmallOrderReportAsync([FromQuery] QueryOrderReportVo query)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                bool isHidePhone = true;
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                int employeeId = Convert.ToInt32(employee.Id);
                operationLog.OperationBy = employeeId;
                var q = await orderService.GetTmallOrderListAsync(query.StartDate, query.EndDate, query.StatusCode, employeeId, isHidePhone);
                var res = from d in q
                          select new OrderReportVo()
                          {
                              Id = d.Id,
                              AppTypeText = d.AppTypeText,
                              CreateDate = d.CreateDate,
                              WriteOffDate = d.WriteOffDate,
                              OrderNatureText = d.OrderNatureText,
                              GoodsName = d.GoodsName,
                              IntegrationQuantity = d.IntegrationQuantity,
                              ActualPayment = d.ActualPayment,
                              AccountReceivable = d.AccountReceivable,
                              Quantity = d.Quantity,
                              StatusText = d.StatusText,
                              LiveAnchorPlatForm = d.LiveAnchorPlatForm,
                              LiveAnchor = d.LiveAnchorName,
                              BelongEmpName = d.BelongEmpName,
                              NickName = d.BuyerNick,
                              Phone = d.Phone,
                              AppointmentHospital = d.AppointmentHospital
                          };
                var exportOrderWriteOff = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "下单平台订单报表.xls");
                return result;
            }
            catch (Exception ex)
            {
                operationLog.Code = -1;
                operationLog.Message = ex.Message;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                
                operationLog.Parameters = JsonConvert.SerializeObject(query);
                operationLog.RequestType = (int)RequestType.Export;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operatonLogService.AddOperationLogAsync(operationLog);
            }
        }


        /// <summary>
        /// 客户升单报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerBuyAgainReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<CustomerHospitalConsumeReportVo>>> GetCustomerBuyAgainReportAsync([FromQuery] QueryCustomerBuyAgainReportVo query)
        {
            bool isHidePhone = true;
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
            {
                isHidePhone = false;
            }
            var q = await _customerHospitalConsumeService.GetCustomerHospitalConsuleReportAsync(query.Channel, query.CheckDateStart, query.CheckDateEnd, query.CheckState, query.HospitalId, query.IsCreateBill, query.BelongCompanyId, query.CustomerName, query.StartDate.Value, query.EndDate.Value, isHidePhone);
            var res = from d in q
                      select new CustomerHospitalConsumeReportVo()
                      {
                          ConsumeId = d.ConsumeId,
                          CreateDate = d.CreateDate,
                          NickName = d.NickName,
                          Phone = d.Phone,
                          Channel = d.ChannelType,
                          IsAddedOrder = d.IsAddedOrder == true ? "是" : "否",
                          OrderId = d.OrderId,
                          WriteOffDate = d.WriteOffDate,
                          ConsumeTypeText = d.ConsumeTypeText,
                          ItemName = d.ItemName,
                          IsCconsultationCard = d.IsCconsultationCard == true ? "是" : "否",
                          HospitalName = d.HospitalName,
                          BuyAgainTypeText = d.BuyAgainTypeText,
                          Price = d.Price,
                          IsSelfLiving = d.IsSelfLiving == true ? "是" : "否",
                          BuyAgainTime = d.BuyAgainTime,
                          HasBuyagainEvidence = d.HasBuyagainEvidence == true ? "是" : "否",
                          IsCheckToHospital = d.IsCheckToHospital == true ? "是" : "否",
                          EmployeeName = d.EmpolyeeName,
                          PersonTime = d.PersonTime,
                          IsReceiveAdditionalPurchase = d.IsReceiveAdditionalPurchase == true ? "是" : "否",
                          CheckBuyAgainPrice = d.CheckBuyAgainPrice,
                          CheckSettlePrice = d.CheckSettlePrice,
                          CheckDate = d.CheckDate,
                          CheckState = d.CheckState,
                          IsCreateBill = d.IsCreateBill == true ? "是" : "否",
                          BelongCompanyName = d.BelongCompanyName,
                          CheckByEmpName = d.CheckByEmpName,
                          Remark = d.Remark,
                          CheckRemark = d.CheckRemark,
                          LiveAnchorName = d.LiveAnchorName,
                          OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                          IsReturnBackPrice = d.IsReturnBackPrice,
                          ReturnBackDate = d.ReturnBackDate,
                          ReturnBackPrice = d.ReturnBackPrice,
                      };
            return ResultData<List<CustomerHospitalConsumeReportVo>>.Success().AddData("customerBuyAgainReport", res.ToList());
        }
        /// <summary>
        /// 客户升单报表导出
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("customerBuyAgainReportExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> ExportCustomerBuyAgainReportAsync([FromQuery] QueryCustomerBuyAgainReportVo query)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                bool isHidePhone = true;
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                operationLog.OperationBy = Convert.ToInt32(employee.Id);
                var q = await _customerHospitalConsumeService.GetCustomerHospitalConsuleReportAsync(query.Channel, query.CheckDateStart, query.CheckDateEnd, query.CheckState, query.HospitalId, query.IsCreateBill, query.BelongCompanyId, query.CustomerName, query.StartDate.Value, query.EndDate.Value, isHidePhone);
                var res = from d in q
                          select new CustomerHospitalConsumeReportVo()
                          {
                              CreateDate = d.CreateDate,
                              NickName = d.NickName,
                              ConsumeId = d.ConsumeId,
                              Phone = d.Phone,
                              Channel = d.ChannelType,
                              IsAddedOrder = d.IsAddedOrder == true ? "是" : "否",
                              OrderId = d.OrderId,
                              WriteOffDate = d.WriteOffDate,
                              ConsumeTypeText = d.ConsumeTypeText,
                              ItemName = d.ItemName,
                              IsCconsultationCard = d.IsCconsultationCard == true ? "是" : "否",
                              HospitalName = d.HospitalName,
                              BuyAgainTypeText = d.BuyAgainTypeText,
                              OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                              Price = d.Price,
                              IsSelfLiving = d.IsSelfLiving == true ? "是" : "否",
                              BuyAgainTime = d.BuyAgainTime,
                              HasBuyagainEvidence = d.HasBuyagainEvidence == true ? "是" : "否",
                              IsCheckToHospital = d.IsCheckToHospital == true ? "是" : "否",
                              EmployeeName = d.EmpolyeeName,
                              PersonTime = d.PersonTime,
                              IsReceiveAdditionalPurchase = d.IsReceiveAdditionalPurchase == true ? "是" : "否",
                              CheckBuyAgainPrice = d.CheckBuyAgainPrice,
                              CheckSettlePrice = d.CheckSettlePrice,
                              CheckDate = d.CheckDate,
                              CheckState = d.CheckState,
                              CheckByEmpName = d.CheckByEmpName,
                              IsCreateBill = d.IsCreateBill == true ? "是" : "否",
                              BelongCompanyName = d.BelongCompanyName,
                              Remark = d.Remark,
                              CheckRemark = d.CheckRemark,
                              LiveAnchorName = d.LiveAnchorName,
                              IsReturnBackPrice = d.IsReturnBackPrice,
                              ReturnBackDate = d.ReturnBackDate,
                              ReturnBackPrice = d.ReturnBackPrice,
                          };
                var exportOrderWriteOff = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "客户升单报表.xls");
                return result;
            }
            catch (Exception ex)
            {
                operationLog.Code = -1;
                operationLog.Message = ex.Message;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                
                operationLog.Parameters = JsonConvert.SerializeObject(query);
                operationLog.RequestType = (int)RequestType.Export;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operatonLogService.AddOperationLogAsync(operationLog);
            }
        }

        /// <summary>
        /// 主播IP运营报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("liveAnchorOperatingReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<LiveAnchorOperatingReportVo>>> GetLiveAnchorOperatingReportAsync([FromQuery] BaseQueryVo query)
        {

            var q = await _liveAnchorDailyTargetService.GetByDailyAndMonthAsync(query.StartDate.Value, query.EndDate.Value);
            var res = from d in q
                      select new LiveAnchorOperatingReportVo()
                      {
                          RecordDate = d.RecordDate,
                          LiveAnchor = d.LiveAnchor,

                          TikTokOperationEmployeeName = d.TikTokOperationEmployeeName,
                          TikTokSendNum = d.TikTokSendNum,
                          TikTokReleaseTarget = d.TikTokReleaseTarget,
                          TikTokCumulativeRelease = d.TikTokCumulativeRelease,
                          TikTokReleaseCompleteRate = d.TikTokReleaseCompleteRate,
                          TikTokFlowInvestmentNum = d.TikTokFlowInvestmentNum,
                          TikTokFlowinvestmentTarget = d.TikTokFlowinvestmentTarget,
                          CumulativeTikTokFlowinvestment = d.CumulativeTikTokFlowinvestment,
                          TikTokFlowinvestmentCompleteRate = d.TikTokFlowinvestmentCompleteRate,

                          ZhihuOperationEmployeeName = d.ZhihuOperationEmployeeName,
                          ZhihuSendNum = d.ZhihuSendNum,
                          ZhihuReleaseTarget = d.ZhihuReleaseTarget,
                          ZhihuCumulativeRelease = d.ZhihuCumulativeRelease,
                          ZhihuReleaseCompleteRate = d.ZhihuReleaseCompleteRate,
                          ZhihuFlowInvestmentNum = d.ZhihuFlowInvestmentNum,
                          ZhihuFlowinvestmentTarget = d.ZhihuFlowinvestmentTarget,
                          CumulativeZhihuFlowinvestment = d.CumulativeZhihuFlowinvestment,
                          ZhihuFlowinvestmentCompleteRate = d.ZhihuFlowinvestmentCompleteRate,

                          XiaoHongShuOperationEmployeeName = d.XiaoHongShuOperationEmployeeName,
                          XiaoHongShuSendNum = d.XiaoHongShuSendNum,
                          XiaoHongShuReleaseTarget = d.XiaoHongShuReleaseTarget,
                          XiaoHongShuCumulativeRelease = d.XiaoHongShuCumulativeRelease,
                          XiaoHongShuReleaseCompleteRate = d.XiaoHongShuReleaseCompleteRate,
                          XiaoHongShuFlowInvestmentNum = d.XiaoHongShuFlowInvestmentNum,
                          XiaoHongShuFlowinvestmentTarget = d.XiaoHongShuFlowinvestmentTarget,
                          CumulativeXiaoHongShuFlowinvestment = d.CumulativeXiaoHongShuFlowinvestment,
                          XiaoHongShuFlowinvestmentCompleteRate = d.XiaoHongShuFlowinvestmentCompleteRate,

                          SinaWeiBoOperationEmployeeName = d.SinaWeiBoOperationEmployeeName,
                          SinaWeiBoSendNum = d.SinaWeiBoSendNum,
                          SinaWeiBoReleaseTarget = d.SinaWeiBoReleaseTarget,
                          SinaWeiBoCumulativeRelease = d.SinaWeiBoCumulativeRelease,
                          SinaWeiBoReleaseCompleteRate = d.SinaWeiBoReleaseCompleteRate,
                          SinaWeiBoFlowInvestmentNum = d.SinaWeiBoFlowInvestmentNum,
                          SinaWeiBoFlowinvestmentTarget = d.SinaWeiBoFlowinvestmentTarget,
                          CumulativeSinaWeiBoFlowinvestment = d.CumulativeSinaWeiBoFlowinvestment,
                          SinaWeiBoFlowinvestmentCompleteRate = d.SinaWeiBoFlowinvestmentCompleteRate,

                          VideoOperationEmployeeName = d.VideoOperationEmployeeName,
                          VideoSendNum = d.VideoSendNum,
                          VideoReleaseTarget = d.VideoReleaseTarget,
                          VideoCumulativeRelease = d.CumulativeVideoRelease,
                          VideoReleaseCompleteRate = d.VideoReleaseCompleteRate,
                          VideoFlowInvestmentNum = d.VideoFlowInvestmentNum,
                          VideoFlowinvestmentTarget = d.VideoFlowinvestmentTarget,
                          CumulativeVideoFlowinvestment = d.CumulativeVideoFlowinvestment,
                          VideoFlowinvestmentCompleteRate = d.VideoFlowinvestmentCompleteRate,

                          TodaySendNum = d.TikTokSendNum + d.ZhihuSendNum + d.XiaoHongShuSendNum + d.SinaWeiBoSendNum + d.VideoSendNum,
                          ReleaseTarget = d.ReleaseTarget,
                          CumulativeRelease = d.CumulativeRelease,
                          ReleaseCompleteRate = d.ReleaseCompleteRate,
                          FlowInvestmentNum = d.TikTokFlowInvestmentNum + d.ZhihuFlowInvestmentNum + d.XiaoHongShuFlowInvestmentNum + d.SinaWeiBoFlowInvestmentNum + d.VideoFlowInvestmentNum,
                          FlowInvestmentTarget = d.FlowInvestmentTarget,
                          CumulativeFlowInvestment = d.CumulativeFlowInvestment,
                          FlowInvestmentCompleteRate = d.FlowInvestmentCompleteRate,
                          LivingRoomFlowInvestmentNum = d.LivingRoomFlowInvestmentNum,
                          LivingRoomFlowInvestmentTarget = d.LivingRoomFlowInvestmentTarget,
                          LivingRoomCumulativeFlowInvestment = d.LivingRoomCumulativeFlowInvestment,
                          LivingRoomFlowInvestmentCompleteRate = d.LivingRoomFlowInvestmentCompleteRate,
                          CluesNum = d.CluesNum,
                          CluesNumTarget = d.CluesNumTarget,
                          CumulativeCluesNum = d.CumulativeCluesNum,
                          CluesCompleteRate = d.CluesCompleteRate,
                          AddFansNum = d.AddFansNum,
                          AddFansTarget = d.AddFansTarget,
                          CumulativeAddFansNum = d.CumulativeAddFansNum,
                          AddFansCompleteRate = d.AddFansCompleteRate,
                          AddWechatNum = d.AddWechatNum,
                          AddWechatTarget = d.AddWechatTarget,
                          CumulativeAddWechat = d.CumulativeAddWechat,
                          AddWechatCompleteRate = d.AddWechatCompleteRate,
                          Consultation = d.Consultation,
                          ConsultationTarget = d.ConsultationTarget,
                          CumulativeConsultation = d.CumulativeConsultation,
                          ConsultationCompleteRate = d.ConsultationCompleteRate,
                          Consultation2 = d.Consultation2,
                          ConsultationTarget2 = d.ConsultationTarget2,
                          CumulativeConsultation2 = d.CumulativeConsultation2,
                          ConsultationCompleteRate2 = d.ConsultationCompleteRate2,
                          ConsultationCardConsumed = d.ConsultationCardConsumed,
                          ConsultationCardConsumedTarget = d.ConsultationCardConsumedTarget,
                          CumulativeConsultationCardConsumed = d.CumulativeConsultationCardConsumed,
                          ConsultationCardConsumedCompleteRate = d.ConsultationCardConsumedCompleteRate,
                          ConsultationCardConsumed2 = d.ConsultationCardConsumed2,
                          ConsultationCardConsumedTarget2 = d.ConsultationCardConsumedTarget2,
                          CumulativeConsultationCardConsumed2 = d.CumulativeConsultationCardConsumed2,
                          ConsultationCardConsumedCompleteRate2 = d.ConsultationCardConsumedCompleteRate2,
                          ActivateHistoricalConsultation = d.ActivateHistoricalConsultation,
                          CumulativeActivateHistoricalConsultation = d.CumulativeActivateHistoricalConsultation,
                          ActivateHistoricalConsultationTarget = d.ActivateHistoricalConsultationTarget,
                          ActivateHistoricalConsultationCompleteRate = d.ActivateHistoricalConsultationCompleteRate,
                          SendOrderNum = d.SendOrderNum,
                          SendOrderTarget = d.SendOrderTarget,
                          CumulativeSendOrder = d.CumulativeSendOrder,
                          SendOrderCompleteRate = d.SendOrderCompleteRate,
                          NewVisitNum = d.NewVisitNum,
                          SubsequentVisitNum = d.SubsequentVisitNum,
                          OldCustomerVisitNum = d.OldCustomerVisitNum,
                          VisitNum = d.VisitNum,
                          VisitTarget = d.VisitTarget,
                          CumulativeVisit = d.CumulativeVisit,
                          VisitCompleteRate = d.VisitCompleteRate,
                          NewDealNum = d.NewDealNum,
                          SubsequentDealNum = d.SubsequentDealNum,
                          OldCustomerDealNum = d.OldCustomerDealNum,
                          DealNum = d.DealNum,
                          DealTarget = d.DealTarget,
                          CumulativeDealTarget = d.CumulativeDealTarget,
                          DealRate = d.DealRate,
                          CargoSettlementCommission = d.CargoSettlementCommission,
                          CargoSettlementCommissionTarget = d.CargoSettlementCommissionTarget,
                          CumulativeCargoSettlementCommission = d.CumulativeCargoSettlementCommission,
                          CargoSettlementCommissionCompleteRate = d.CargoSettlementCommissionCompleteRate,
                          NewPerformanceNum = d.NewPerformanceNum,
                          SubsequentPerformanceNum = d.SubsequentPerformanceNum,
                          NewCustomerPerformanceCountNum = d.NewCustomerPerformanceCountNum,
                          OldCustomerPerformanceNum = d.OldCustomerPerformanceNum,
                          PerformanceNum = d.PerformanceNum,
                          PerformanceTarget = d.PerformanceTarget,
                          CumulativePerformance = d.CumulativePerformance,
                          PerformanceCompleteRate = d.PerformanceCompleteRate,
                          MinivanRefund = d.MinivanRefund,
                          MinivanRefundTarget = d.MinivanRefundTarget,
                          CumulativeMinivanRefund = d.CumulativeMinivanRefund,
                          MinivanRefundCompleteRate = d.MinivanRefundCompleteRate,
                          MiniVanBadReviews = d.MiniVanBadReviews,
                          MiniVanBadReviewsTarget = d.MiniVanBadReviewsTarget,
                          CumulativeMiniVanBadReviews = d.CumulativeMiniVanBadReviews,
                          MiniVanBadReviewsCompleteRate = d.MiniVanBadReviewsCompleteRate,
                          LivingTrackingEmployeeName = d.LivingTrackingEmployeeName,
                          NetWorkConsultingEmployeeName = d.NetWorkConsultingEmployeeName,
                          TikTokUpdateDate = d.TikTokUpdateDate,
                          LivingUpdateDate = d.LivingUpdateDate,
                          AfterLivingUpdateDate = d.AfterLivingUpdateDate
                      };
            return ResultData<List<LiveAnchorOperatingReportVo>>.Success().AddData("liveAnchorOperatingReport", res.ToList());
        }
        /// <summary>
        /// 主播IP运营报表导出
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("liveAnchorOperatingReportExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> ExportLiveAnchorOperatingReportAsync([FromQuery] BaseQueryVo query)
        {
            OperationAddDto operationLog = new OperationAddDto();
            try
            {
                var q = await _liveAnchorDailyTargetService.GetByDailyAndMonthAsync(query.StartDate.Value, query.EndDate.Value);

                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                operationLog.OperationBy = Convert.ToInt32(employee.Id);
                var res = from d in q
                          select new LiveAnchorOperatingReportVo()
                          {
                              RecordDate = d.RecordDate,
                              LiveAnchor = d.LiveAnchor,


                              TikTokOperationEmployeeName = d.TikTokOperationEmployeeName,
                              TikTokSendNum = d.TikTokSendNum,
                              TikTokReleaseTarget = d.TikTokReleaseTarget,
                              TikTokCumulativeRelease = d.TikTokCumulativeRelease,
                              TikTokReleaseCompleteRate = d.TikTokReleaseCompleteRate,
                              TikTokFlowInvestmentNum = d.TikTokFlowInvestmentNum,
                              TikTokFlowinvestmentTarget = d.TikTokFlowinvestmentTarget,
                              CumulativeTikTokFlowinvestment = d.CumulativeTikTokFlowinvestment,
                              TikTokFlowinvestmentCompleteRate = d.TikTokFlowinvestmentCompleteRate,

                              ZhihuOperationEmployeeName = d.ZhihuOperationEmployeeName,
                              ZhihuSendNum = d.ZhihuSendNum,
                              ZhihuReleaseTarget = d.ZhihuReleaseTarget,
                              ZhihuCumulativeRelease = d.ZhihuCumulativeRelease,
                              ZhihuReleaseCompleteRate = d.ZhihuReleaseCompleteRate,
                              ZhihuFlowInvestmentNum = d.ZhihuFlowInvestmentNum,
                              ZhihuFlowinvestmentTarget = d.ZhihuFlowinvestmentTarget,
                              CumulativeZhihuFlowinvestment = d.CumulativeZhihuFlowinvestment,
                              ZhihuFlowinvestmentCompleteRate = d.ZhihuFlowinvestmentCompleteRate,

                              XiaoHongShuOperationEmployeeName = d.XiaoHongShuOperationEmployeeName,
                              XiaoHongShuSendNum = d.XiaoHongShuSendNum,
                              XiaoHongShuReleaseTarget = d.XiaoHongShuReleaseTarget,
                              XiaoHongShuCumulativeRelease = d.XiaoHongShuCumulativeRelease,
                              XiaoHongShuReleaseCompleteRate = d.XiaoHongShuReleaseCompleteRate,
                              XiaoHongShuFlowInvestmentNum = d.XiaoHongShuFlowInvestmentNum,
                              XiaoHongShuFlowinvestmentTarget = d.XiaoHongShuFlowinvestmentTarget,
                              CumulativeXiaoHongShuFlowinvestment = d.CumulativeXiaoHongShuFlowinvestment,
                              XiaoHongShuFlowinvestmentCompleteRate = d.XiaoHongShuFlowinvestmentCompleteRate,

                              SinaWeiBoOperationEmployeeName = d.SinaWeiBoOperationEmployeeName,
                              SinaWeiBoSendNum = d.SinaWeiBoSendNum,
                              SinaWeiBoReleaseTarget = d.SinaWeiBoReleaseTarget,
                              SinaWeiBoCumulativeRelease = d.SinaWeiBoCumulativeRelease,
                              SinaWeiBoReleaseCompleteRate = d.SinaWeiBoReleaseCompleteRate,
                              SinaWeiBoFlowInvestmentNum = d.SinaWeiBoFlowInvestmentNum,
                              SinaWeiBoFlowinvestmentTarget = d.SinaWeiBoFlowinvestmentTarget,
                              CumulativeSinaWeiBoFlowinvestment = d.CumulativeSinaWeiBoFlowinvestment,
                              SinaWeiBoFlowinvestmentCompleteRate = d.SinaWeiBoFlowinvestmentCompleteRate,

                              VideoOperationEmployeeName = d.VideoOperationEmployeeName,
                              VideoSendNum = d.VideoSendNum,
                              VideoReleaseTarget = d.VideoReleaseTarget,
                              VideoCumulativeRelease = d.CumulativeVideoRelease,
                              VideoReleaseCompleteRate = d.VideoReleaseCompleteRate,
                              VideoFlowInvestmentNum = d.VideoFlowInvestmentNum,
                              VideoFlowinvestmentTarget = d.VideoFlowinvestmentTarget,
                              CumulativeVideoFlowinvestment = d.CumulativeVideoFlowinvestment,
                              VideoFlowinvestmentCompleteRate = d.VideoFlowinvestmentCompleteRate,

                              TodaySendNum = d.TikTokSendNum + d.ZhihuSendNum + d.XiaoHongShuSendNum + d.SinaWeiBoSendNum + d.VideoSendNum,
                              ReleaseTarget = d.ReleaseTarget,
                              CumulativeRelease = d.CumulativeRelease,
                              ReleaseCompleteRate = d.ReleaseCompleteRate,
                              FlowInvestmentNum = d.TikTokFlowInvestmentNum + d.ZhihuFlowInvestmentNum + d.XiaoHongShuFlowInvestmentNum + d.SinaWeiBoFlowInvestmentNum + d.VideoFlowInvestmentNum,
                              FlowInvestmentTarget = d.FlowInvestmentTarget,
                              LivingRoomFlowInvestmentNum = d.LivingRoomFlowInvestmentNum,
                              LivingRoomFlowInvestmentTarget = d.LivingRoomFlowInvestmentTarget,
                              LivingRoomCumulativeFlowInvestment = d.LivingRoomCumulativeFlowInvestment,
                              LivingRoomFlowInvestmentCompleteRate = d.LivingRoomFlowInvestmentCompleteRate,
                              CumulativeFlowInvestment = d.CumulativeFlowInvestment,
                              FlowInvestmentCompleteRate = d.FlowInvestmentCompleteRate,
                              CluesNum = d.CluesNum,
                              CluesNumTarget = d.CluesNumTarget,
                              CumulativeCluesNum = d.CumulativeCluesNum,
                              CluesCompleteRate = d.CluesCompleteRate,
                              AddFansNum = d.AddFansNum,
                              AddFansTarget = d.AddFansTarget,
                              CumulativeAddFansNum = d.CumulativeAddFansNum,
                              AddFansCompleteRate = d.AddFansCompleteRate,
                              AddWechatNum = d.AddWechatNum,
                              AddWechatTarget = d.AddWechatTarget,
                              CumulativeAddWechat = d.CumulativeAddWechat,
                              AddWechatCompleteRate = d.AddWechatCompleteRate,
                              Consultation = d.Consultation,
                              ConsultationTarget = d.ConsultationTarget,
                              CumulativeConsultation = d.CumulativeConsultation,
                              ConsultationCompleteRate = d.ConsultationCompleteRate,
                              Consultation2 = d.Consultation2,
                              ConsultationTarget2 = d.ConsultationTarget2,
                              CumulativeConsultation2 = d.CumulativeConsultation2,
                              ConsultationCompleteRate2 = d.ConsultationCompleteRate2,
                              ConsultationCardConsumed = d.ConsultationCardConsumed,
                              ConsultationCardConsumedTarget = d.ConsultationCardConsumedTarget,
                              CumulativeConsultationCardConsumed = d.CumulativeConsultationCardConsumed,
                              ConsultationCardConsumedCompleteRate = d.ConsultationCardConsumedCompleteRate,
                              ConsultationCardConsumed2 = d.ConsultationCardConsumed2,
                              ConsultationCardConsumedTarget2 = d.ConsultationCardConsumedTarget2,
                              CumulativeConsultationCardConsumed2 = d.CumulativeConsultationCardConsumed2,
                              ConsultationCardConsumedCompleteRate2 = d.ConsultationCardConsumedCompleteRate2,
                              ActivateHistoricalConsultation = d.ActivateHistoricalConsultation,
                              CumulativeActivateHistoricalConsultation = d.CumulativeActivateHistoricalConsultation,
                              ActivateHistoricalConsultationTarget = d.ActivateHistoricalConsultationTarget,
                              ActivateHistoricalConsultationCompleteRate = d.ActivateHistoricalConsultationCompleteRate,
                              SendOrderNum = d.SendOrderNum,
                              SendOrderTarget = d.SendOrderTarget,
                              CumulativeSendOrder = d.CumulativeSendOrder,
                              SendOrderCompleteRate = d.SendOrderCompleteRate,
                              NewCustomerPerformanceCountNum = d.NewCustomerPerformanceCountNum,
                              NewVisitNum = d.NewVisitNum,
                              SubsequentVisitNum = d.SubsequentVisitNum,
                              OldCustomerVisitNum = d.OldCustomerVisitNum,
                              VisitNum = d.VisitNum,
                              VisitTarget = d.VisitTarget,
                              CumulativeVisit = d.CumulativeVisit,
                              VisitCompleteRate = d.VisitCompleteRate,
                              NewDealNum = d.NewDealNum,
                              SubsequentDealNum = d.SubsequentDealNum,
                              OldCustomerDealNum = d.OldCustomerDealNum,
                              DealNum = d.DealNum,
                              DealTarget = d.DealTarget,
                              CumulativeDealTarget = d.CumulativeDealTarget,
                              DealRate = d.DealRate,
                              CargoSettlementCommission = d.CargoSettlementCommission,
                              CargoSettlementCommissionTarget = d.CargoSettlementCommissionTarget,
                              CumulativeCargoSettlementCommission = d.CumulativeCargoSettlementCommission,
                              CargoSettlementCommissionCompleteRate = d.CargoSettlementCommissionCompleteRate,
                              NewPerformanceNum = d.NewPerformanceNum,
                              SubsequentPerformanceNum = d.SubsequentPerformanceNum,
                              OldCustomerPerformanceNum = d.OldCustomerPerformanceNum,
                              PerformanceNum = d.PerformanceNum,
                              PerformanceTarget = d.PerformanceTarget,
                              CumulativePerformance = d.CumulativePerformance,
                              PerformanceCompleteRate = d.PerformanceCompleteRate,
                              MinivanRefund = d.MinivanRefund,
                              MinivanRefundTarget = d.MinivanRefundTarget,
                              CumulativeMinivanRefund = d.CumulativeMinivanRefund,
                              MinivanRefundCompleteRate = d.MinivanRefundCompleteRate,
                              MiniVanBadReviews = d.MiniVanBadReviews,
                              MiniVanBadReviewsTarget = d.MiniVanBadReviewsTarget,
                              CumulativeMiniVanBadReviews = d.CumulativeMiniVanBadReviews,
                              MiniVanBadReviewsCompleteRate = d.MiniVanBadReviewsCompleteRate,
                              LivingTrackingEmployeeName = d.LivingTrackingEmployeeName,
                              NetWorkConsultingEmployeeName = d.NetWorkConsultingEmployeeName,
                              TikTokUpdateDate = d.TikTokUpdateDate,
                              LivingUpdateDate = d.LivingUpdateDate,
                              AfterLivingUpdateDate = d.AfterLivingUpdateDate
                          };
                var exportOrderWriteOff = res.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportOrderWriteOff);
                var result = File(stream, "application/vnd.ms-excel", $"" + query.StartDate.Value.ToString("yyyy年MM月dd日") + "-" + query.EndDate.Value.ToString("yyyy年MM月dd日") + "主播IP运营报表.xls");
                return result;
            }
            catch (Exception ex)
            {
                operationLog.Code = -1;
                operationLog.Message = ex.Message;
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                
                operationLog.Parameters = JsonConvert.SerializeObject(query);
                operationLog.RequestType = (int)RequestType.Export;
                operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operatonLogService.AddOperationLogAsync(operationLog);
            }
        }



        /// <summary>
        /// 拍剪组数据报表
        /// </summary>
        /// <param name="startDate">登记开始时间</param>
        /// <param name="endDate">登记结束时间</param>
        /// <param name="shootingEmpId">拍摄人员id</param>
        /// <param name="clipEmpId">剪辑人员id</param>
        /// <param name="liveAnchorId">主播id</param>
        /// <returns></returns>
        [HttpGet("shootingAndClipReport")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<ShootingAndClipReportVo>>> GetShootingAndClipReportAsync(DateTime? startDate, DateTime? endDate, int? shootingEmpId, int? clipEmpId, int? liveAnchorId)
        {
            if (!startDate.HasValue && !endDate.HasValue)
            { throw new Exception("请选择时间进行查询"); }
            if (startDate.HasValue && endDate.HasValue)
            {
                if ((endDate.Value - startDate.Value).TotalDays > 31)
                {
                    throw new Exception("开始时间与结束时间不能超过一个月，请重新选择后再进行查询！");
                }
            }
            var q = await shootingAndClipService.GetReportListAsync(startDate, endDate, shootingEmpId, clipEmpId, liveAnchorId);
            var res = from d in q
                      select new ShootingAndClipReportVo()
                      {
                          Title = d.Title,
                          VideoType = d.VideoTypeText,
                          ShootingEmpName = d.ShootingEmpName,
                          ClipEmpName = d.ClipEmpName,
                          LiveAnchorName = d.LiveAnchorName,
                          CreateDate = d.CreateDate,
                          RecordDate = d.RecordDate,
                      };
            return ResultData<List<ShootingAndClipReportVo>>.Success().AddData("customerSendOrderReport", res.ToList());
        }


        /// <summary>
        /// 拍剪组数据报表导出
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="shootingEmpId">派单客服</param>
        /// <param name="clipEmpId">归属客服</param>
        /// <param name="liveAnchorId">订单状态</param>
        /// <returns></returns>
        [HttpGet("shootingAndClipReportExport")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> GetShootingAndClipReportExportAsync(DateTime? startDate, DateTime? endDate, int? shootingEmpId, int? clipEmpId, int? liveAnchorId)
        {
            if (!startDate.HasValue && !endDate.HasValue)
            { throw new Exception("请选择时间进行查询"); }
            if (startDate.HasValue && endDate.HasValue)
            {
                if ((endDate.Value - startDate.Value).TotalDays > 31)
                {
                    throw new Exception("开始时间与结束时间不能超过一个月，请重新选择后再进行查询！");
                }
            }
            var q = await shootingAndClipService.GetReportListAsync(startDate, endDate, shootingEmpId, clipEmpId, liveAnchorId);
            var res = from d in q
                      select new ShootingAndClipReportVo()
                      {
                          Title = d.Title,
                          ShootingEmpName = d.ShootingEmpName,
                          VideoType = d.VideoTypeText,
                          ClipEmpName = d.ClipEmpName,
                          LiveAnchorName = d.LiveAnchorName,
                          CreateDate = d.CreateDate,
                          RecordDate = d.RecordDate,
                      };
            var exportSendOrder = res.ToList();
            var stream = ExportExcelHelper.ExportExcel(exportSendOrder);
            var result = File(stream, "application/vnd.ms-excel", $"" + startDate.Value.ToString("yyyy年MM月dd日") + "-" + endDate.Value.ToString("yyyy年MM月dd日") + "拍剪组数据报表.xls");
            return result;
        }



        /// <summary>
        /// 数据中台接口
        /// </summary>
        /// <returns></returns>
        [HttpGet("OrderCenterData")]
        [FxInternalAuthorize]
        public async Task<ResultData<OrderCenterVo>> GetOrderCenterDataAsync()
        {
            OrderCenterVo orderDataVo = new OrderCenterVo();
            orderDataVo.TodayOrderQuantity = await orderService.GetTodayIncrementQuantityAsync();
            orderDataVo.TodayWriteOffOrderQuantity = await orderService.GetTodayWriteOffQuantityAsync();
            orderDataVo.TodayClosedOrderQuantity = await orderService.GetTodayClosedQuantityAsync();

            var todaySendOrderInfo = await _sendOrderInfoService.GetTodaySendOrderAsync();
            var todaySendList = from d in todaySendOrderInfo
                                select new TodaySendOrderInfo
                                {
                                    OrderId = d.OrderId,
                                    ActuralPayment = d.ActualPayment,
                                    SendHospital = d.SendHospital,
                                    GoodsName = d.GoodsName
                                };

            orderDataVo.TodaySendOrderInfo = todaySendList.ToList();
            var todaySendContentPlatFormOrderInfo = await _sendContentPlatFormOrderInfoService.GetTodaySendOrderAsync();
            var todayContentPlatFormSendList = from d in todaySendContentPlatFormOrderInfo
                                               select new TodaySendOrderInfo
                                               {
                                                   OrderId = d.OrderId,
                                                   ActuralPayment = d.ActualPayment,
                                                   SendHospital = _hospitalInfoService.GetByIdAsync(d.SendHospitalId).Result.Name,
                                                   GoodsName = d.GoodsName
                                               };
            foreach (var x in todayContentPlatFormSendList.ToList())
            {
                orderDataVo.TodaySendOrderInfo.Add(x);
            }

            var todayHospitalOrderNum = await _sendOrderInfoService.GetTodayHospitalOrderNumAsync();
            var todayHospitalOrderContentPlatFormNum = await _sendContentPlatFormOrderInfoService.GetTodayHospitalOrderNumAsync();
            orderDataVo.TodayHospitalOrderNum = new List<TodayHospitalOrderNum>();
            for (int x = 0; x < todayHospitalOrderNum.Count; x++)
            {
                if (todayHospitalOrderNum[x].OrderNum == 0)
                    break;
                TodayHospitalOrderNum hospitalOrderNum = new TodayHospitalOrderNum();
                hospitalOrderNum.HospitalName = todayHospitalOrderNum[x].HospitalName;
                hospitalOrderNum.OrderCount = todayHospitalOrderNum[x].OrderNum;
                orderDataVo.TodayHospitalOrderNum.Add(hospitalOrderNum);
            }
            for (int x = 0; x < todayHospitalOrderContentPlatFormNum.Count; x++)
            {
                if (todayHospitalOrderContentPlatFormNum[x].OrderNum == 0)
                    break;
                var isExist = orderDataVo.TodayHospitalOrderNum.Find(z => z.HospitalName == todayHospitalOrderContentPlatFormNum[x].HospitalName);
                if (isExist != null)
                {
                    foreach (var k in orderDataVo.TodayHospitalOrderNum)
                    {
                        if (k.HospitalName == todayHospitalOrderContentPlatFormNum[x].HospitalName)
                        {
                            k.OrderCount += 1;
                        }
                    }
                }
                else
                {
                    TodayHospitalOrderNum hospitalOrderNum = new TodayHospitalOrderNum();
                    hospitalOrderNum.HospitalName = todayHospitalOrderContentPlatFormNum[x].HospitalName;
                    hospitalOrderNum.OrderCount = todayHospitalOrderContentPlatFormNum[x].OrderNum;
                    orderDataVo.TodayHospitalOrderNum.Add(hospitalOrderNum);
                }
            }
            orderDataVo.TodayHospitalOrderNum = orderDataVo.TodayHospitalOrderNum.OrderByDescending(x => x.OrderCount).Take(4).ToList();
            var todayOrderAdd = await orderService.GetTodayOrderAddAsync();
            var todayOrderAddResList = from d in todayOrderAdd
                                       select new TodayAddOrderNum
                                       {
                                           OrderId = d.OrderId,
                                           ProjectName = d.ProjectName,
                                           CustomerName = d.CustomerName,
                                           OrderType = d.OrderType
                                       };
            orderDataVo.TodayAddOrderNum = todayOrderAddResList.ToList();
            return ResultData<OrderCenterVo>.Success().AddData("orderData", orderDataVo);

        }


        /// <summary>
        /// 数据中心
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns></returns>
        [HttpGet("OrderCenter")]
        [FxInternalAuthorize]
        public async Task<ResultData<OrderCenterDetailsVo>> GetOrderCenterAsync(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            var date = timeSpan.TotalDays;
            OrderCenterDetailsVo resultInfo = new OrderCenterDetailsVo();

            #region  【派单数】
            SendListInfo sendOrderInfo = new SendListInfo();
            #region [已派单数据构造]
            List<OrderOperationConditionVo> sendOrderOperationCondition = new List<OrderOperationConditionVo>();
            //天猫已派单
            var tmallOrderSendInfo = await _sendOrderInfoService.GetOrderSendDataAsync(startDate, endDate);
            //内容平台已派单
            var contentPlatFormOrderSendInfo = await _sendContentPlatFormOrderInfoService.GetOrderSendDataAsync(startDate, endDate);
            for (int x = 0; x <= date; x++)
            {
                OrderOperationConditionVo condition = new OrderOperationConditionVo();
                condition.Date = endDate.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderNum = 0;
                sendOrderOperationCondition.Add(condition);
            }
            foreach (var x in tmallOrderSendInfo)
            {
                sendOrderOperationCondition.Find(z => z.Date == x.Date).OrderNum = x.OrderNum;
            }
            foreach (var x in contentPlatFormOrderSendInfo)
            {
                sendOrderOperationCondition.Find(z => z.Date == x.Date).OrderNum += x.OrderNum;
            }
            sendOrderInfo.AllSendOrder = sendOrderOperationCondition.Sum(z => z.OrderNum);
            sendOrderInfo.sendOrderDataListCount = sendOrderOperationCondition;
            #endregion

            #region [未派单数据构造]
            List<OrderOperationConditionVo> unSendOrderOperationCondition = new List<OrderOperationConditionVo>();
            //天猫未派单
            var tmallOrderUnSendInfo = await _sendOrderInfoService.GetOrderUnSendDataAsync(startDate, endDate);
            //内容平台未派单
            var contentPlatFormOrderUnSendInfo = await _contentPlatFormOrderService.GetOrderUnSendDataAsync(startDate, endDate);
            for (int x = 0; x <= date; x++)
            {
                OrderOperationConditionVo condition = new OrderOperationConditionVo();
                condition.Date = endDate.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderNum = 0;
                unSendOrderOperationCondition.Add(condition);
            }
            foreach (var x in tmallOrderUnSendInfo)
            {
                unSendOrderOperationCondition.Find(z => z.Date == x.Date).OrderNum = x.OrderNum;
            }
            foreach (var x in contentPlatFormOrderUnSendInfo)
            {
                unSendOrderOperationCondition.Find(z => z.Date == x.Date).OrderNum += x.OrderNum;
            }
            sendOrderInfo.AllUnSendOrder = unSendOrderOperationCondition.Sum(z => z.OrderNum);
            sendOrderInfo.UnSendOrderDataListCount = unSendOrderOperationCondition;
            #endregion

            resultInfo.SendOrderInfo = sendOrderInfo;
            #endregion

            #region  【业绩】
            Achievement achievement = new Achievement();
            #region [新客业绩]
            List<OrderPriceConditionVo> newCustomerAchievement = new List<OrderPriceConditionVo>();
            //新客业绩
            var contentPlatFormOrderPriceInfo = await _contentPlatFormOrderService.GetOrderDealPriceAsync(startDate, endDate);
            for (int x = 0; x <= date; x++)
            {
                OrderPriceConditionVo condition = new OrderPriceConditionVo();
                condition.Date = endDate.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderPrice = 0.00M;
                newCustomerAchievement.Add(condition);
            }
            foreach (var x in contentPlatFormOrderPriceInfo)
            {
                newCustomerAchievement.Find(z => z.Date == x.Date).OrderPrice = x.OrderPrice;
            }
            achievement.AllNewCustomerAchievement = newCustomerAchievement.Sum(z => z.OrderPrice);
            achievement.NewCustomerAchievement = newCustomerAchievement;
            #endregion

            #region [老客业绩]
            List<OrderPriceConditionVo> oldCustomerAchievement = new List<OrderPriceConditionVo>();
            //天猫业绩
            var tmallOrderPriceInfo = await orderService.GetOrderDealPriceDataAsync(startDate, endDate);

            //升单业绩
            var customerHospitalConsumePriceInfo = await _customerHospitalConsumeService.GetOrderDealPriceDataAsync(startDate, endDate);
            for (int x = 0; x <= date; x++)
            {
                OrderPriceConditionVo condition = new OrderPriceConditionVo();
                condition.Date = endDate.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderPrice = 0.00M;
                oldCustomerAchievement.Add(condition);
            }
            foreach (var x in tmallOrderPriceInfo)
            {
                oldCustomerAchievement.Find(z => z.Date == x.Date).OrderPrice = x.OrderPrice;
            }
            foreach (var x in customerHospitalConsumePriceInfo)
            {
                oldCustomerAchievement.Find(z => z.Date == x.Date).OrderPrice += x.OrderPrice;
            }
            achievement.AllOldCustomerAchievement = oldCustomerAchievement.Sum(z => z.OrderPrice);
            achievement.OldCustomerAchievement = oldCustomerAchievement;
            #endregion

            //总业绩
            achievement.AllAchievement = achievement.AllNewCustomerAchievement + achievement.AllOldCustomerAchievement;
            resultInfo.Achievement = achievement;
            #endregion

            #region  【上门数】
            OrderVisitInfo orderVisitInfo = new OrderVisitInfo();
            #region [新诊上门数]
            List<OrderOperationConditionVo> newOrderVisitInfo = new List<OrderOperationConditionVo>();
            var contentPlatFormOrderToHospitalInfo = await _contentPlatFormOrderService.GetOrderToHospitalDataAsync(startDate, endDate);
            for (int x = 0; x <= date; x++)
            {
                OrderOperationConditionVo condition = new OrderOperationConditionVo();
                condition.Date = endDate.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderNum = 0;
                newOrderVisitInfo.Add(condition);
            }
            foreach (var x in contentPlatFormOrderToHospitalInfo)
            {
                newOrderVisitInfo.Find(z => z.Date == x.Date).OrderNum = x.OrderNum;
            }
            orderVisitInfo.AllNewCustomerVisit = newOrderVisitInfo.Sum(z => z.OrderNum);
            orderVisitInfo.NewCustomerVisit = newOrderVisitInfo;
            #endregion

            #region [复诊上门数]
            List<OrderOperationConditionVo> oldOrderVisitInfo = new List<OrderOperationConditionVo>();
            //天猫订单
            var tmallOrderWriteOffInfo = await orderService.GetOrderToHospitalDataAsync(startDate, endDate);
            //升单订单
            var customerHospitalConsume = await _customerHospitalConsumeService.GetOrderToHospitalDataAsync(startDate, endDate);
            for (int x = 0; x <= date; x++)
            {
                OrderOperationConditionVo condition = new OrderOperationConditionVo();
                condition.Date = endDate.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderNum = 0;
                oldOrderVisitInfo.Add(condition);
            }
            foreach (var x in tmallOrderWriteOffInfo)
            {
                oldOrderVisitInfo.Find(z => z.Date == x.Date).OrderNum = x.OrderNum;
            }
            foreach (var x in customerHospitalConsume)
            {
                oldOrderVisitInfo.Find(z => z.Date == x.Date).OrderNum += x.OrderNum;
            }
            orderVisitInfo.AllOldCustomerVisit = oldOrderVisitInfo.Sum(z => z.OrderNum);
            orderVisitInfo.OldCustomerVisit = oldOrderVisitInfo;
            #endregion

            resultInfo.OrderVisitInfo = orderVisitInfo;
            #endregion

            #region  【面诊卡】
            ConsultationCardInfo consultationCardInfo = new ConsultationCardInfo();
            #region [面诊卡下单]
            List<OrderOperationConditionVo> consultationCardBuyInfo = new List<OrderOperationConditionVo>();
            var liveAnchorDailyTargetInfo1 = await _liveAnchorDailyTargetService.GetConsultingCardBuyDataAsync(startDate, endDate);
            for (int x = 0; x <= date; x++)
            {
                OrderOperationConditionVo condition = new OrderOperationConditionVo();
                condition.Date = endDate.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderNum = 0;
                consultationCardBuyInfo.Add(condition);
            }
            foreach (var x in liveAnchorDailyTargetInfo1)
            {
                consultationCardBuyInfo.Find(z => z.Date == x.Date).OrderNum = x.OrderNum;
            }
            consultationCardInfo.AllConsultationCardInfoBuy = consultationCardBuyInfo.Sum(z => z.OrderNum);
            consultationCardInfo.ConsultationCardInfoBuy = consultationCardBuyInfo;
            #endregion

            #region [面诊卡消耗]
            List<OrderOperationConditionVo> consultationCardUseInfo = new List<OrderOperationConditionVo>();
            var liveAnchorDailyTargetInfo2 = await _liveAnchorDailyTargetService.GetConsultingCardUseDataAsync(startDate, endDate);
            for (int x = 0; x <= date; x++)
            {
                OrderOperationConditionVo condition = new OrderOperationConditionVo();
                condition.Date = endDate.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderNum = 0;
                consultationCardUseInfo.Add(condition);
            }
            foreach (var x in liveAnchorDailyTargetInfo2)
            {
                consultationCardUseInfo.Find(z => z.Date == x.Date).OrderNum = x.OrderNum;
            }
            consultationCardInfo.AllConsultationCardInfoUsed = consultationCardUseInfo.Sum(z => z.OrderNum);
            consultationCardInfo.ConsultationCardInfoUsed = consultationCardUseInfo;
            #endregion

            resultInfo.ConsultationCardInfo = consultationCardInfo;
            #endregion

            #region  【医院订单量】
            #region [天猫订单成交医院]
            List<HospitalOrderAndPriceInfoVo> hospitalOrderAndPriceInfoVo = new List<HospitalOrderAndPriceInfoVo>();
            //天猫派单医院
            var tmallHospitalOrderAndPriceInfoVo = await _sendOrderInfoService.GetHospitalOrderNumAsync(startDate, endDate);
            foreach (var x in tmallHospitalOrderAndPriceInfoVo)
            {
                if (hospitalOrderAndPriceInfoVo.Where(z => z.HospitalName == x.HospitalName).Count() > 0)
                {
                    hospitalOrderAndPriceInfoVo.Find(z => z.HospitalName == x.HospitalName).Price += x.Price;
                    hospitalOrderAndPriceInfoVo.Find(z => z.HospitalName == x.HospitalName).OrderNum += 1;
                }
                else
                {
                    HospitalOrderAndPriceInfoVo hospitalOrderInfo = new HospitalOrderAndPriceInfoVo();
                    hospitalOrderInfo.OrderNum = x.OrderNum;
                    hospitalOrderInfo.Price = x.Price;
                    hospitalOrderInfo.HospitalName = x.HospitalName;
                    hospitalOrderAndPriceInfoVo.Add(hospitalOrderInfo);
                }

            }
            #endregion

            #region [内容平台派单医院]
            var contentPlatFormOrderCompleteInfo = await _contentPlatFormOrderService.GetOrderSendAndDealDataAsync(startDate, endDate);

            foreach (var x in contentPlatFormOrderCompleteInfo)
            {
                if (hospitalOrderAndPriceInfoVo.Where(z => z.HospitalName == x.HospitalName).Count() > 0)
                {
                    hospitalOrderAndPriceInfoVo.Find(z => z.HospitalName == x.HospitalName).Price += x.Price;
                    hospitalOrderAndPriceInfoVo.Find(z => z.HospitalName == x.HospitalName).OrderNum += 1;
                }
                else
                {
                    HospitalOrderAndPriceInfoVo hospitalOrderInfo = new HospitalOrderAndPriceInfoVo();
                    hospitalOrderInfo.OrderNum = x.OrderNum;
                    hospitalOrderInfo.Price = x.Price;
                    hospitalOrderInfo.HospitalName = x.HospitalName;
                    hospitalOrderAndPriceInfoVo.Add(hospitalOrderInfo);
                }
            }

            #endregion

            #region [升单医院]
            var customerHospitalConsumeInfo = await _customerHospitalConsumeService.GetOrderDealPriceAndNumDataAsync(startDate, endDate);

            foreach (var x in customerHospitalConsumeInfo)
            {
                if (hospitalOrderAndPriceInfoVo.Where(z => z.HospitalName == x.HospitalName).Count() > 0)
                {
                    hospitalOrderAndPriceInfoVo.Find(z => z.HospitalName == x.HospitalName).Price += x.Price;
                    hospitalOrderAndPriceInfoVo.Find(z => z.HospitalName == x.HospitalName).OrderNum += 1;
                }
                else
                {
                    HospitalOrderAndPriceInfoVo hospitalOrderInfo = new HospitalOrderAndPriceInfoVo();
                    hospitalOrderInfo.OrderNum = x.OrderNum;
                    hospitalOrderInfo.Price = x.Price;
                    hospitalOrderInfo.HospitalName = x.HospitalName;
                    hospitalOrderAndPriceInfoVo.Add(hospitalOrderInfo);
                }
            }

            #endregion

            //医院订单数据赋值
            resultInfo.HospitalOrderAndPriceInfoVo = hospitalOrderAndPriceInfoVo.OrderByDescending(x => x.Price).Take(10).ToList();
            #endregion

            return ResultData<OrderCenterDetailsVo>.Success().AddData("orderData", resultInfo);

        }

        /// <summary>
        /// 私域运营板块数据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("GetPrivateDomainOrderDetailsInfo")]
        public async Task<ResultData<PrivateDomainOrderCenterDetailsVo>> GetPrivateDomainOrderDetailsInfoAsync(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            var date = timeSpan.TotalDays;
            PrivateDomainOrderCenterDetailsVo resultInfo = new PrivateDomainOrderCenterDetailsVo();

            #region 【老客业绩】
            PrivateDomainAchievement achievement = new PrivateDomainAchievement();
            List<OrderPriceConditionVo> oldCustomerAchievement = new List<OrderPriceConditionVo>();
            //天猫业绩
            var tmallOrderPriceInfo = await orderService.GetOrderDealPriceDataAsync(startDate, endDate);

            //升单业绩
            var customerHospitalConsumePriceInfo = await _customerHospitalConsumeService.GetOrderDealPriceDataAsync(startDate, endDate);
            for (int x = 0; x <= date; x++)
            {
                OrderPriceConditionVo condition = new OrderPriceConditionVo();
                condition.Date = endDate.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderPrice = 0.00M;
                oldCustomerAchievement.Add(condition);
            }
            foreach (var x in tmallOrderPriceInfo)
            {
                oldCustomerAchievement.Find(z => z.Date == x.Date).OrderPrice = x.OrderPrice;
            }
            foreach (var x in customerHospitalConsumePriceInfo)
            {
                oldCustomerAchievement.Find(z => z.Date == x.Date).OrderPrice += x.OrderPrice;
            }
            achievement.AllOldCustomerAchievement = oldCustomerAchievement.Sum(z => z.OrderPrice);
            achievement.OldCustomerAchievement = oldCustomerAchievement;
            resultInfo.PrivateDomainAchievement = achievement;
            #endregion

            #region 【老客复购情况】
            var bindCustomerInfo = await customerService.GetTopBindCustomerConsumptionServiceListAsync(startDate, endDate);
            List<OldCustomerBuyInfo> oldCustomerBuyInfo = new List<OldCustomerBuyInfo>();
            foreach (var x in bindCustomerInfo)
            {
                OldCustomerBuyInfo oldCustomerBuyInfos = new OldCustomerBuyInfo();
                oldCustomerBuyInfos.Phone = x.Phone;
                oldCustomerBuyInfos.Price = x.AllConsumptionPrice;
                oldCustomerBuyInfos.OrderNum = x.CreatedOrderNum;
                oldCustomerBuyInfo.Add(oldCustomerBuyInfos);
            }
            resultInfo.OldCustomerBuyInfo = oldCustomerBuyInfo;
            #endregion

            #region  【医院订单量】
            #region [天猫订单成交医院]
            List<HospitalOrderAndPriceInfoVo> hospitalOrderAndPriceInfoVo = new List<HospitalOrderAndPriceInfoVo>();
            //天猫派单医院
            var tmallHospitalOrderAndPriceInfoVo = await _sendOrderInfoService.GetHospitalOrderNumAsync(startDate, endDate);
            foreach (var x in tmallHospitalOrderAndPriceInfoVo)
            {
                if (hospitalOrderAndPriceInfoVo.Where(z => z.HospitalName == x.HospitalName).Count() > 0)
                {
                    hospitalOrderAndPriceInfoVo.Find(z => z.HospitalName == x.HospitalName).Price += x.Price;
                    hospitalOrderAndPriceInfoVo.Find(z => z.HospitalName == x.HospitalName).OrderNum += 1;
                }
                else
                {
                    HospitalOrderAndPriceInfoVo hospitalOrderInfo = new HospitalOrderAndPriceInfoVo();
                    hospitalOrderInfo.OrderNum = x.OrderNum;
                    hospitalOrderInfo.Price = x.Price;
                    hospitalOrderInfo.HospitalName = x.HospitalName;
                    hospitalOrderAndPriceInfoVo.Add(hospitalOrderInfo);
                }

            }
            #endregion

            #region [内容平台派单医院]
            var contentPlatFormOrderCompleteInfo = await _contentPlatFormOrderService.GetOrderSendAndDealDataAsync(startDate, endDate);

            foreach (var x in contentPlatFormOrderCompleteInfo)
            {
                if (hospitalOrderAndPriceInfoVo.Where(z => z.HospitalName == x.HospitalName).Count() > 0)
                {
                    hospitalOrderAndPriceInfoVo.Find(z => z.HospitalName == x.HospitalName).Price += x.Price;
                    hospitalOrderAndPriceInfoVo.Find(z => z.HospitalName == x.HospitalName).OrderNum += 1;
                }
                else
                {
                    HospitalOrderAndPriceInfoVo hospitalOrderInfo = new HospitalOrderAndPriceInfoVo();
                    hospitalOrderInfo.OrderNum = x.OrderNum;
                    hospitalOrderInfo.Price = x.Price;
                    hospitalOrderInfo.HospitalName = x.HospitalName;
                    hospitalOrderAndPriceInfoVo.Add(hospitalOrderInfo);
                }
            }

            #endregion

            #region [升单医院]
            var customerHospitalConsumeInfo = await _customerHospitalConsumeService.GetOrderDealPriceAndNumDataAsync(startDate, endDate);

            foreach (var x in customerHospitalConsumeInfo)
            {
                if (hospitalOrderAndPriceInfoVo.Where(z => z.HospitalName == x.HospitalName).Count() > 0)
                {
                    hospitalOrderAndPriceInfoVo.Find(z => z.HospitalName == x.HospitalName).Price += x.Price;
                    hospitalOrderAndPriceInfoVo.Find(z => z.HospitalName == x.HospitalName).OrderNum += 1;
                }
                else
                {
                    HospitalOrderAndPriceInfoVo hospitalOrderInfo = new HospitalOrderAndPriceInfoVo();
                    hospitalOrderInfo.OrderNum = x.OrderNum;
                    hospitalOrderInfo.Price = x.Price;
                    hospitalOrderInfo.HospitalName = x.HospitalName;
                    hospitalOrderAndPriceInfoVo.Add(hospitalOrderInfo);
                }
            }

            #endregion

            //医院订单数据赋值
            resultInfo.HospitalOrderAndPriceInfoVo = hospitalOrderAndPriceInfoVo.OrderByDescending(x => x.Price).Take(10).ToList();
            #endregion

            return ResultData<PrivateDomainOrderCenterDetailsVo>.Success().AddData("orderData", resultInfo);
        }

        /// <summary>
        /// 成交量折线图
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("OrderDealLine")]
        [FxInternalAuthorize]
        public async Task<ResultData<OrderDealInfo>> GetOrderDealAsync(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            var date = timeSpan.TotalDays;
            OrderDealInfo resultInfo = new OrderDealInfo();

            #region [新诊成交数]
            List<OrderOperationConditionVo> newOrderDealInfo = new List<OrderOperationConditionVo>();
            var contentPlatFormOrderDealInfo = await _contentPlatFormOrderService.GetOrderDealDataAsync(startDate, endDate);
            for (int x = 0; x <= date; x++)
            {
                OrderOperationConditionVo condition = new OrderOperationConditionVo();
                condition.Date = endDate.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderNum = 0;
                newOrderDealInfo.Add(condition);
            }
            foreach (var x in contentPlatFormOrderDealInfo)
            {
                newOrderDealInfo.Find(z => z.Date == x.Date).OrderNum = x.OrderNum;
            }
            resultInfo.AllNewCustomerDeal = newOrderDealInfo.Sum(x => x.OrderNum);
            resultInfo.NewCustomerDeal = newOrderDealInfo;
            #endregion

            #region [复诊成交数]
            List<OrderOperationConditionVo> oldOrderDealInfo = new List<OrderOperationConditionVo>();
            //天猫订单
            var tmallOrderWriteOffInfo = await orderService.GetOrderToHospitalDataAsync(startDate, endDate);
            //升单订单
            var customerHospitalConsume = await _customerHospitalConsumeService.GetOrderToHospitalDataAsync(startDate, endDate);
            for (int x = 0; x <= date; x++)
            {
                OrderOperationConditionVo condition = new OrderOperationConditionVo();
                condition.Date = endDate.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderNum = 0;
                oldOrderDealInfo.Add(condition);
            }
            foreach (var x in tmallOrderWriteOffInfo)
            {
                oldOrderDealInfo.Find(z => z.Date == x.Date).OrderNum = x.OrderNum;
            }
            foreach (var x in customerHospitalConsume)
            {
                oldOrderDealInfo.Find(z => z.Date == x.Date).OrderNum += x.OrderNum;
            }
            resultInfo.AllOldCustomerDeal = oldOrderDealInfo.Sum(x => x.OrderNum);
            resultInfo.OldCustomerDeal = oldOrderDealInfo;
            #endregion
            return ResultData<OrderDealInfo>.Success().AddData("orderData", resultInfo);
        }

        /// <summary>
        /// 对账业绩折线图
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("CheckForPerformance")]
        [FxInternalAuthorize]
        public async Task<ResultData<CheckForPerformance>> GetCheckForPerformanceAsync(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            var date = timeSpan.TotalDays;
            CheckForPerformance resultInfo = new CheckForPerformance();

            #region [对账业绩]
            //天猫
            var tmallOrderInfo = await orderService.GetCheckForPerformanceDataAsync(startDate, endDate);
            //内容平台
            var contentPlatFormOrderInfo = await _contentPlatFormOrderService.GetCheckForPerformanceDataAsync(startDate, endDate);

            var customerHospitalConsume = await _customerHospitalConsumeService.GetCheckForPerformanceDataAsync(startDate, endDate);
            List<OrderPriceConditionVo> CheckForPerformance = new List<OrderPriceConditionVo>();
            for (int x = 0; x <= date; x++)
            {
                OrderPriceConditionVo condition = new OrderPriceConditionVo();
                condition.Date = endDate.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderPrice = 0.00M;
                CheckForPerformance.Add(condition);
            }
            foreach (var x in tmallOrderInfo)
            {
                CheckForPerformance.Find(z => z.Date == x.Date).OrderPrice = x.OrderPrice;
            }
            foreach (var x in contentPlatFormOrderInfo)
            {
                CheckForPerformance.Find(z => z.Date == x.Date).OrderPrice += x.OrderPrice;
            }
            foreach (var x in customerHospitalConsume)
            {
                CheckForPerformance.Find(z => z.Date == x.Date).OrderPrice += x.OrderPrice;
            }
            resultInfo.AllCheckForPerformance = CheckForPerformance.Sum(x => x.OrderPrice);
            resultInfo.CheckForPerformanceList = CheckForPerformance;
            #endregion
            #region [回款业绩]
            //天猫
            var tmallOrderReturnBackPriceInfo = await orderService.GetReturnBackPriceDataAsync(startDate, endDate);
            //内容平台
            var contentPlatFormOrderReturnBackPriceInfo = await _contentPlatFormOrderService.GetReturnBackPriceDataAsync(startDate, endDate);
            //升单
            var customerHospitalConsumeReturnBackPrice = await _customerHospitalConsumeService.GetReturnBackPriceDataAsync(startDate, endDate);
            List<OrderPriceConditionVo> ReturnBackPrice = new List<OrderPriceConditionVo>();
            for (int x = 0; x <= date; x++)
            {
                OrderPriceConditionVo condition = new OrderPriceConditionVo();
                condition.Date = endDate.AddDays(-x).ToString("yyyy-MM-dd");
                condition.OrderPrice = 0.00M;
                ReturnBackPrice.Add(condition);
            }
            foreach (var x in tmallOrderReturnBackPriceInfo)
            {
                ReturnBackPrice.Find(z => z.Date == x.Date).OrderPrice = x.OrderPrice;
            }
            foreach (var x in contentPlatFormOrderReturnBackPriceInfo)
            {
                ReturnBackPrice.Find(z => z.Date == x.Date).OrderPrice += x.OrderPrice;
            }
            foreach (var x in customerHospitalConsumeReturnBackPrice)
            {
                ReturnBackPrice.Find(z => z.Date == x.Date).OrderPrice += x.OrderPrice;
            }
            resultInfo.AllReceivablePerformance = ReturnBackPrice.Sum(x => x.OrderPrice);
            resultInfo.ReceivablePerformance = ReturnBackPrice;
            #endregion
            return ResultData<CheckForPerformance>.Success().AddData("orderData", resultInfo);
        }


        /// <summary>
        /// 咨询达人业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("LiveAnchorPerformanceInfo")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<LiveAnchorPerformance>>> GetLiveAnchorPerformanceInfoAsync(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            var date = timeSpan.TotalDays;
            List<LiveAnchorPerformance> resultInfo = new List<LiveAnchorPerformance>();

            var contentPlatFormOrderCompleteInfo = await _contentPlatFormOrderService.GetLiveAnchorPerformanceInfoAsync(startDate, endDate);

            foreach (var x in contentPlatFormOrderCompleteInfo)
            {
                if (resultInfo.Where(z => z.LiveAnchorName == x.HospitalName).Count() > 0)
                {
                    resultInfo.Find(z => z.LiveAnchorName == x.HospitalName).Performance += x.Price;
                    resultInfo.Find(z => z.LiveAnchorName == x.HospitalName).OrderNum += 1;
                }
                else
                {
                    LiveAnchorPerformance hospitalOrderInfo = new LiveAnchorPerformance();
                    hospitalOrderInfo.OrderNum = x.OrderNum;
                    hospitalOrderInfo.Performance = x.Price;
                    hospitalOrderInfo.LiveAnchorName = x.HospitalName;
                    resultInfo.Add(hospitalOrderInfo);
                }
            }
            return ResultData<List<LiveAnchorPerformance>>.Success().AddData("orderData", resultInfo.OrderByDescending(x => x.Performance).ToList());
        }

        /// <summary>
        /// 达人助理业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("ConsultationPerformanceInfo")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<LiveAnchorPerformance>>> GetConsultationPerformanceInfoAsync(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            var date = timeSpan.TotalDays;
            List<LiveAnchorPerformance> resultInfo = new List<LiveAnchorPerformance>();

            var contentPlatFormOrderCompleteInfo = await _contentPlatFormOrderService.GetConsultationPerformanceInfoAsync(startDate, endDate);

            foreach (var x in contentPlatFormOrderCompleteInfo)
            {
                if (resultInfo.Where(z => z.LiveAnchorName == x.HospitalName).Count() > 0)
                {
                    resultInfo.Find(z => z.LiveAnchorName == x.HospitalName).Performance += x.Price;
                    resultInfo.Find(z => z.LiveAnchorName == x.HospitalName).OrderNum += 1;
                }
                else
                {
                    LiveAnchorPerformance hospitalOrderInfo = new LiveAnchorPerformance();
                    hospitalOrderInfo.OrderNum = x.OrderNum;
                    hospitalOrderInfo.Performance = x.Price;
                    hospitalOrderInfo.LiveAnchorName = x.HospitalName;
                    resultInfo.Add(hospitalOrderInfo);
                }
            }
            return ResultData<List<LiveAnchorPerformance>>.Success().AddData("orderData", resultInfo.OrderByDescending(x => x.Performance).ToList());
        }

        /// <summary>
        /// 行政客服业绩
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("CustomerServicePerformanceInfo")]
        [FxInternalAuthorize]
        public async Task<ResultData<List<LiveAnchorPerformance>>> GetCustomerServicePerformanceInfoAsync(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            var date = timeSpan.TotalDays;
            List<LiveAnchorPerformance> resultInfo = new List<LiveAnchorPerformance>();
            //内容平台派单业绩
            var contentPlatFormOrderCompleteInfo = await _contentPlatFormOrderService.GetCustomerServicePerformanceInfoAsync(startDate, endDate);
            var tmallSendOrderInfo = await orderService.GetCustomerServicePerformanceInfoAsync(startDate, endDate);

            foreach (var x in contentPlatFormOrderCompleteInfo)
            {
                if (resultInfo.Where(z => z.LiveAnchorName == x.HospitalName).Count() > 0)
                {
                    resultInfo.Find(z => z.LiveAnchorName == x.HospitalName).Performance += x.Price;
                    resultInfo.Find(z => z.LiveAnchorName == x.HospitalName).OrderNum += 1;
                }
                else
                {
                    LiveAnchorPerformance hospitalOrderInfo = new LiveAnchorPerformance();
                    hospitalOrderInfo.OrderNum = x.OrderNum;
                    hospitalOrderInfo.Performance = x.Price;
                    hospitalOrderInfo.LiveAnchorName = x.HospitalName;
                    resultInfo.Add(hospitalOrderInfo);
                }
            }
            foreach (var x in tmallSendOrderInfo)
            {
                if (resultInfo.Where(z => z.LiveAnchorName == x.HospitalName).Count() > 0)
                {
                    resultInfo.Find(z => z.LiveAnchorName == x.HospitalName).Performance += x.Price;
                    resultInfo.Find(z => z.LiveAnchorName == x.HospitalName).OrderNum += 1;
                }
                else
                {
                    LiveAnchorPerformance hospitalOrderInfo = new LiveAnchorPerformance();
                    hospitalOrderInfo.OrderNum = x.OrderNum;
                    hospitalOrderInfo.Performance = x.Price;
                    hospitalOrderInfo.LiveAnchorName = x.HospitalName;
                    resultInfo.Add(hospitalOrderInfo);
                }
            }
            return ResultData<List<LiveAnchorPerformance>>.Success().AddData("orderData", resultInfo.OrderByDescending(x => x.Performance).ToList());
        }
    }
}
