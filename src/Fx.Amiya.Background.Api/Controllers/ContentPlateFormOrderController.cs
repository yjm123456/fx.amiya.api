using Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.Background.Api.Vo.ContentPlatFormOrderSend;
using Fx.Amiya.Background.Api.Vo.Order;
using Fx.Amiya.Background.Api.Vo.OrderCheck;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{

    /// <summary>
    /// 内容平台订单模块
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ContentPlateFormOrderController : ControllerBase
    {
        private IContentPlateFormOrderService _orderService;
        private IOrderService _tmallOrderService;
        private IContentPlatFormCustomerPictureService _contentPlatFormCustomerPictureService;
        private IHttpContextAccessor _httpContextAccessor;
        public ContentPlateFormOrderController(IContentPlateFormOrderService orderService,
            IOrderService tmallOrderService,
            IContentPlatFormCustomerPictureService contentPlatFormCustomerPictureService,
            IHttpContextAccessor httpContextAccessor)
        {
            _orderService = orderService;
            _tmallOrderService = tmallOrderService;
            _httpContextAccessor = httpContextAccessor;
            _contentPlatFormCustomerPictureService = contentPlatFormCustomerPictureService;
        }

        /// <summary>
        /// 录单
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("contentPlateFormAddOrder")]
        [FxInternalAuthorize]
        public async Task<ResultData> ContentPlateFormAddOrderAsync(ContentPlateFormOrderAddVo addVo)
        {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;

            if (employee.PositionName == "客服" || employee.PositionName == "客服管理员")
            {
                var IsExistOrder = _tmallOrderService.IsExistPhoneAsync(addVo.Phone);
                if (await IsExistOrder == true)
                {
                    throw new Exception("该客户手机号已在下单平台产生过订单，请确认后联系客服主管！");
                }
            }

            //添加订单
            ContentPlateFormOrderAddDto addDto = new ContentPlateFormOrderAddDto();
            addDto.EmployeeId = addVo.BelongEmpId;
            addDto.Id = CreateOrderIdHelper.GetNextNumber();
            addDto.OrderType = addVo.OrderType;
            addDto.ContentPlateFormId = addVo.ContentPlateFormId;
            addDto.ConsultationEmpId = addVo.ConsultationEmpId;
            addDto.ConsultationType = addVo.ConsultationType;
            addDto.LiveAnchorId = addVo.LiveAnchorId;
            addDto.LiveAnchorWeChatNo = addVo.LiveAnchorWeChatNo;
            addDto.CustomerName = addVo.CustomerName;
            addDto.Phone = addVo.Phone;
            addDto.AppointmentDate = addVo.AppointmentDate;
            addDto.AppointmentHospitalId = addVo.AppointmentHospitalId;
            addDto.DepositAmount = addVo.DepositAmount;
            addDto.OrderSource = addVo.OrderSource;
            addDto.UnSendReason = addVo.UnSendReason;
            addDto.AcceptConsulting = addVo.AcceptConsulting;
            addDto.GoodsId = addVo.GoodsId;
            addDto.HospitalDepartmentId = addVo.HospitalDepartmentId;
            addDto.ConsultingContent = addVo.ConsultingContent;
            addDto.Remark = addVo.Remark;
            addDto.LateProjectStage = addVo.LateProjectStage;
            addDto.CustomerPictures = addVo.CustomerPictures;
            await _orderService.AddContentPlateFormOrderAsync(addDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 根据条件获取内容平台订单
        /// </summary>
        /// <param name="liveAnchorId">主播id</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="keyword">关键词</param>
        /// <param name="hospitalDepartmentId">科室id</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="appointmentHospital">预约医院</param>
        /// <param name="consultationType">面诊状态</param>
        /// <param name="contentPlateFormId">内容平台</param>
        /// <param name="orderSource">订单来源(-1查询全部)</param>
        /// <param name="belongEmpId">归属客服id</param>
        /// <param name="pageNum">第/页</param>
        /// <param name="pageSize">每页显示/行</param>
        /// <returns></returns>
        [HttpGet("contentPlateFormOrderLlistWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<ContentPlatFormOrderInfoVo>>> GetOrderListWithPageAsync(int? liveAnchorId, DateTime? startDate, DateTime? endDate, int? appointmentHospital, int? consultationType, string hospitalDepartmentId, string keyword, int? orderStatus, string contentPlateFormId, int? belongEmpId, int orderSource, int pageNum, int pageSize)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await _orderService.GetOrderListWithPageAsync(liveAnchorId, startDate, endDate, appointmentHospital, consultationType, hospitalDepartmentId, keyword, orderStatus, contentPlateFormId, belongEmpId, employeeId, orderSource, pageNum, pageSize);
                var order = from d in q.List
                            select new ContentPlatFormOrderInfoVo
                            {
                                Id = d.Id,
                                OrderTypeText = d.OrderTypeText,
                                ContentPlatformName = d.ContentPlatformName,
                                LiveAnchorName = d.LiveAnchorName,
                                LiveAnchorWeChatNo = d.LiveAnchorWeChatNo,
                                ConsultationType=d.ConsultationTypeText,
                                CreateDate = d.CreateDate,
                                CustomerName = d.CustomerName,
                                Phone = d.Phone,
                                AppointmentDate = d.AppointmentDate == null ? "未预约时间" : d.AppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                AppointmentHospitalName = d.AppointmentHospitalName,
                                GoodsName = d.GoodsName,
                                ThumbPictureUrl = d.ThumbPictureUrl,
                                ConsultingContent = d.ConsultingContent,
                                OrderStatusText = d.OrderStatusText,
                                DepositAmount = d.DepositAmount,
                                IsToHospital = d.IsToHospital,
                                ToHospitalDate = d.ToHospitalDate,
                                LastDealHospital = d.LastDealHospital,
                                DealAmount = d.DealAmount,
                                DealDate = d.DealDate,
                                UnDealReason = d.UnDealReason,
                                LateProjectStage = d.LateProjectStage,
                                Remark = d.Remark,
                                DepartmentName = d.DepartmentName,
                                BelongEmpName = d.BelongEmpName,
                                UnSendReason = d.UnSendReason,
                                OrderSourceText = d.OrderSourceText,
                                AcceptConsulting = d.AcceptConsulting,
                                CheckStateText = d.CheckStateText,
                                CheckDate = d.CheckDate,
                                CheckByName = d.CheckByName,
                                CheckPrice = d.CheckPrice,
                                Sender = d.Sender,
                                SendDate = d.SendDate,
                                CheckRemark = d.CheckRemark,
                                SettlePrice = d.SettlePrice,
                                IsReturnBackPrice = d.IsReturnBackPrice,
                                ReturnBackDate = d.ReturnBackDate,
                                ReturnBackPrice = d.ReturnBackPrice,
                                OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId
                            };
                FxPageInfo<ContentPlatFormOrderInfoVo> orderPageInfo = new FxPageInfo<ContentPlatFormOrderInfoVo>();
                orderPageInfo.TotalCount = q.TotalCount;
                orderPageInfo.List = order;
                return ResultData<FxPageInfo<ContentPlatFormOrderInfoVo>>.Success().AddData("contentPlatFormOrder", orderPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<ContentPlatFormOrderInfoVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取未派单订单列表（分页）
        /// </summary>
        /// <param name="liveAnchorId">归属主播id</param>
        /// <param name="keyword">关键词</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="contentPlateFormId">内容平台</param>
        /// <param name="consultationEmpId">面诊员id</param>
        /// <param name="employeeId">员工id（-1查询所有）</param>
        /// <param name="orderSource">订单来源（-1查询所有）</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("unContentPlatFormSendOrderList")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<UnContentPlateFormSendOrderInfoVo>>> GetUnSendOrderListWithPageAsync(int? liveAnchorId, DateTime? startDate, DateTime? endDate, int? consultationEmpId, string keyword, string contentPlateFormId, int? employeeId, int orderStatus, int orderSource, int pageNum, int pageSize)
        {
            if (employeeId == null)
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
            }

            var q = await _orderService.GetUnSendOrderListWithPageAsync(liveAnchorId, keyword, startDate, endDate, consultationEmpId, (int)employeeId, orderStatus, contentPlateFormId, orderSource, pageNum, pageSize);
            var unSendOrder = from d in q.List
                              select new UnContentPlateFormSendOrderInfoVo
                              {
                                  OrderId = d.OrderId,
                                  ContentPlatFormName = d.ContentPlatFormName,
                                  LiveAnchorName = d.LiveAnchorName,
                                  GoodsName = d.GoodsName,
                                  ThumbPictureUrl = d.ThumbPictureUrl,
                                  ConsultingContent = d.ConsultingContent,
                                  CustomerName = d.CustomerName,
                                  Phone = d.Phone,
                                  ConsultationTypeText=d.ConsultationTypeText,
                                  EncryptPhone = d.EncryptPhone,
                                  DealAmount = d.DealAmount,
                                  DepositAmount = d.DepositAmount.HasValue ? d.DepositAmount : 0,
                                  OrderTypeText = d.OrderTypeText,
                                  OrderStatusText = d.OrderStatusText,
                                  AppointmentHospital = d.AppointmentHospital,
                                  AppointmentDate = d.AppointmentDate,
                                  Remark = d.Remark,
                                  LateProjectStage = d.LateProjectStage,
                                  UnSendReason = d.UnSendReason,
                                  OrderSourceText = d.OrderSourceText,
                              };
            FxPageInfo<UnContentPlateFormSendOrderInfoVo> pageInfo = new FxPageInfo<UnContentPlateFormSendOrderInfoVo>();
            pageInfo.TotalCount = q.TotalCount;
            pageInfo.List = unSendOrder;
            return ResultData<FxPageInfo<UnContentPlateFormSendOrderInfoVo>>.Success().AddData("unSendOrder", pageInfo);
        }

        /// <summary>
        /// 修改内容平台订单归属客服
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("BelongEmployeeContentPlatFormOrder")]
        public async Task<ResultData> BelongEmployeeOrderAsync(BelongEmpInfoOrderVo input)
        {
            UpdateBelongEmpInfoOrderDto dto = new UpdateBelongEmpInfoOrderDto();
            dto.OrderId = input.OrderId;
            dto.BelongEmpId = input.BelongEmpInfo;
            await _orderService.UpdateOrderBelongEmpIdAsync(dto);
            return ResultData.Success();
        }

        /// <summary>
        /// 根据条件导出内容平台订单
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="keyword">关键词</param>
        /// <param name="consultationEmpId">面诊员</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="orderSource">订单来源(-1查询全部)</param>
        /// <param name="contentPlateFormId">内容平台</param>
        /// <returns></returns>
        [HttpGet("exportContentPlateFormOrderLlistWithPage")]
        [FxInternalAuthorize]
        public async Task<FileStreamResult> ExportOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, int? appointmentHospital, int? belongEmpId, int? liveAnchorId, int? consultationEmpId, string hospitalDepartmentId, string keyword, int? orderStatus, int orderSource, string contentPlateFormId)
        {
            try
            {
                bool isHidePhone = true;
                if (startDate.HasValue == false || endDate.HasValue == false)
                {
                    throw new Exception("请选择录单时间进行导出！");
                }
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                if (employee.DepartmentId == "1" || employee.DepartmentId == "7")
                {
                    isHidePhone = false;
                }
                var q = await _orderService.ExportOrderListWithPageAsync(startDate, endDate, consultationEmpId, appointmentHospital, belongEmpId, liveAnchorId, keyword, hospitalDepartmentId, orderStatus, orderSource, contentPlateFormId, employeeId, isHidePhone);
                var order = from d in q
                            select new ContentPlatFormOrderInfoVo
                            {
                                Id = d.Id,
                                OrderTypeText = d.OrderTypeText,
                                ContentPlatformName = d.ContentPlatformName,
                                LiveAnchorName = d.LiveAnchorName,
                                CreateDate = d.CreateDate,
                                CustomerName = d.CustomerName,
                                Phone = d.Phone,
                                AppointmentDate = d.AppointmentDate == null ? "未预约时间" : d.AppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                AppointmentHospitalName = d.AppointmentHospitalName,
                                GoodsName = d.GoodsName,
                                DepartmentName = d.DepartmentName,
                                ThumbPictureUrl = d.ThumbPictureUrl,
                                ConsultingContent = d.ConsultingContent,
                                IsToHospital = d.IsToHospital,
                                ToHospitalDate = d.ToHospitalDate,
                                LastDealHospital = d.LastDealHospital,
                                OrderStatusText = d.OrderStatusText,
                                Sender = d.Sender,
                                SendDate = d.SendDate,
                                DepositAmount = d.DepositAmount,
                                DealAmount = d.DealAmount,
                                UnDealReason = d.UnDealReason,
                                LateProjectStage = d.LateProjectStage,
                                Remark = d.Remark,
                                DealDate = d.DealDate,
                                OrderSourceText = d.OrderSourceText,
                                UnSendReason = d.UnSendReason,
                                AcceptConsulting = d.AcceptConsulting,
                                CheckStateText = d.CheckStateText,
                                CheckDate = d.CheckDate,
                                CheckByName = d.CheckByName,
                                CheckPrice = d.CheckPrice,
                                ConsultationType=d.ConsultationTypeText,
                                CheckRemark = d.CheckRemark,
                                SettlePrice = d.SettlePrice,
                                BelongEmpName = d.BelongEmpName,
                                IsReturnBackPrice = d.IsReturnBackPrice,
                                ReturnBackDate = d.ReturnBackDate,
                                ReturnBackPrice = d.ReturnBackPrice,
                                OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId
                            };
                var exportSendOrder = order.ToList();
                var stream = ExportExcelHelper.ExportExcel(exportSendOrder);
                var result = File(stream, "application/vnd.ms-excel", $"" + startDate.Value.ToString("yyyy年MM月dd日") + "-" + endDate.Value.ToString("yyyy年MM月dd日") + "内容平台订单报表.xls");
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 根据条件获取已成交内容平台订单
        /// </summary>
        /// <param name="liveAnchorId">主播ID</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="consultationEmpId">面诊人员</param>
        /// <param name="hospitalId">医院id</param>
        /// <param name="contentPlateFormId">内容平台</param>
        /// <param name="keyword">关键词</param>
        /// <param name="checkState">审核状态,为空查询所有</param>
        /// <param name="ReturnBackPriceState">回款状态,为空查询所有</param>
        /// <param name="toHospitalType">到院类型,为空查询所有</param>
        /// <param name="pageNum">第/页</param>
        /// <param name="pageSize">每页显示/行</param>
        /// <returns></returns>
        [HttpGet("contentPlateFormOrderDealLlistWithPage")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<ContentPlatFormCompleteOrderInfoVo>>> GetOrderDealListWithPageAsync(int? liveAnchorId, DateTime? startDate, DateTime? endDate, int? consultationEmpId, int? checkState, bool? ReturnBackPriceState, string keyword, int? hospitalId, int? toHospitalType, string contentPlateFormId, int pageNum, int pageSize)
        {
            try
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await _orderService.GetOrderDealListWithPageAsync(liveAnchorId, startDate, endDate, consultationEmpId, checkState, ReturnBackPriceState, keyword, contentPlateFormId, hospitalId, toHospitalType, employeeId, pageNum, pageSize);
                var order = from d in q.List
                            select new ContentPlatFormCompleteOrderInfoVo
                            {
                                Id = d.Id,
                                OrderTypeText = d.OrderTypeText,
                                ContentPlatformName = d.ContentPlatformName,
                                LiveAnchorName = d.LiveAnchorName,
                                LiveAnchorWeChatNo = d.LiveAnchorWeChatNo,
                                CreateDate = d.CreateDate,
                                ConsultationTypeText=d.ConsultationTypeText,
                                CustomerName = d.CustomerName,
                                IsAcompanying = d.IsAcompanying ,
                                Phone = d.Phone,
                                IsToHospital = d.IsToHospital == true ? "是" : "否",
                                ToHospitalType = d.ToHospitalTypeText,
                                AppointmentDate = d.AppointmentDate == null ? "未预约时间" : d.AppointmentDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                AppointmentHospitalName = d.AppointmentHospitalName,
                                GoodsName = d.GoodsName,
                                ThumbPictureUrl = d.ThumbPictureUrl,
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
                                CheckRemark = d.CheckRemark,
                                SettlePrice = d.SettlePrice,
                                CheckDate = d.CheckDate,
                                BelongEmpName = d.BelongEmpName,
                                IsReturnBackPrice = d.IsReturnBackPrice,
                                ReturnBackDate = d.ReturnBackDate,
                                ReturnBackPrice = d.ReturnBackPrice,
                                OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                                CommissionRatio = d.CommissionRatio,
                                IsOldCustomer = d.IsOldCustomer == false ? "新客业绩" : "老客业绩",
                            };
                FxPageInfo<ContentPlatFormCompleteOrderInfoVo> orderPageInfo = new FxPageInfo<ContentPlatFormCompleteOrderInfoVo>();
                orderPageInfo.TotalCount = q.TotalCount;
                orderPageInfo.List = order;
                return ResultData<FxPageInfo<ContentPlatFormCompleteOrderInfoVo>>.Success().AddData("contentPlatFormOrder", orderPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<ContentPlatFormCompleteOrderInfoVo>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 根据订单编号获取订单要修改的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<ContentPlateFormOrderVo>> GetByIdAsync(string id)
        {
            var order = await _orderService.GetByOrderIdAsync(id);
            ContentPlateFormOrderVo orderUpdateInfo = new ContentPlateFormOrderVo();
            orderUpdateInfo.Id = order.Id;
            orderUpdateInfo.OrderType = order.OrderType;
            orderUpdateInfo.ContentPlateFormId = order.ContentPlateFormId;
            orderUpdateInfo.ConsultationType = order.ConsultationType;
            orderUpdateInfo.LiveAnchorId = order.LiveAnchorId;
            orderUpdateInfo.GoodsId = order.GoodsId;
            orderUpdateInfo.CustomerName = order.CustomerName;
            orderUpdateInfo.Phone = order.Phone;
            orderUpdateInfo.AppointmentDate = order.AppointmentDate;
            orderUpdateInfo.ConsultationEmpId = order.ConsultationEmpId;
            orderUpdateInfo.AppointmentHospitalId = order.AppointmentHospitalId;
            orderUpdateInfo.DepositAmount = order.DepositAmount;
            orderUpdateInfo.ConsultingContent = order.ConsultingContent;
            orderUpdateInfo.OrderStatus = order.OrderStatus;
            orderUpdateInfo.OrderStatusText = order.OrderStatusText;
            orderUpdateInfo.AppointmentHospitalName = order.AppointmentHospitalName;
            orderUpdateInfo.AppointmentHospitalId = order.AppointmentHospitalId;
            orderUpdateInfo.Remark = order.Remark;
            orderUpdateInfo.LateProjectStage = order.LateProjectStage;
            orderUpdateInfo.CheckState = order.CheckState;
            orderUpdateInfo.LiveAnchorWeChatNo = order.LiveAnchorWeChatNo;
            orderUpdateInfo.IsOldCustomer = order.IsOldCustomer;
            orderUpdateInfo.IsAcompanying = order.IsAcompanying;
            orderUpdateInfo.CommissionRatio = order.CommissionRatio;
            orderUpdateInfo.CheckPrice = order.CheckPrice;
            orderUpdateInfo.HospitalDepartmentId = order.HospitalDepartmentId;
            orderUpdateInfo.SettlePrice = order.SettlePrice;
            orderUpdateInfo.OrderSource = order.OrderSource;
            orderUpdateInfo.AcceptConsulting = order.AcceptConsulting;
            orderUpdateInfo.UnSendReason = order.UnSendReason;
            orderUpdateInfo.CreateDate = order.CreateDate;
            orderUpdateInfo.SendDate = order.SendDate;
            orderUpdateInfo.UnDealPictureUrl = order.UnDealPictureUrl;
            orderUpdateInfo.DealPictureUrl = order.DealPictureUrl;
            orderUpdateInfo.UpdateDate = order.UpdateDate;
            orderUpdateInfo.DealDate = order.DealDate;
            orderUpdateInfo.DealAmount = order.DealAmount;
            orderUpdateInfo.AppointmentHospitalName = order.AppointmentHospitalName;
            orderUpdateInfo.GoodsName = order.GoodsName;
            orderUpdateInfo.ContentPlateFormName = order.ContentPlateFormName;
            orderUpdateInfo.OrderTypeText = order.OrderTypeText;
            orderUpdateInfo.OrderSourceText = order.OrderSourceText;
            orderUpdateInfo.HospitalDepartmentName = order.HospitalDepartmentName;
            orderUpdateInfo.ConsultationEmpName = order.ConsultationEmpName;
            orderUpdateInfo.LiveAnchorName = order.LiveAnchorName;
            orderUpdateInfo.CheckStateText = order.CheckStateText;
            orderUpdateInfo.BelongEmpId = order.BelongEmpId;
            orderUpdateInfo.BelongEmpName = order.BelongEmpName;
            orderUpdateInfo.LastDealHospitalId = order.LastDealHospitalId;
            orderUpdateInfo.LastDealHospitalName = order.LastDealHospitalName;
            orderUpdateInfo.OtherContentPlatFormOrderId = order.OtherContentPlatFormOrderId;
            orderUpdateInfo.ThumbPicture = order.ThumbPicture;
            orderUpdateInfo.CheckBy = order.CheckBy;
            orderUpdateInfo.CheckDate = order.CheckDate;
            orderUpdateInfo.CheckByName = order.CheckByName;
            orderUpdateInfo.IsReturnBackPrice = order.IsReturnBackPrice;
            orderUpdateInfo.ReturnBackDate = order.ReturnBackDate;
            orderUpdateInfo.ReturnBackPrice = order.ReturnBackPrice;
            orderUpdateInfo.IsToHospital = order.IsToHospital;
            orderUpdateInfo.ToHospitalType = order.ToHospitalType;
            orderUpdateInfo.ToHospitalTypeText = order.ToHospitalTypeText;
            orderUpdateInfo.ToHospitalDate = order.ToHospitalDate;
            orderUpdateInfo.SendBy = order.SendBy;
            orderUpdateInfo.SendByName = order.SendByName;
            orderUpdateInfo.SendHospitalName = order.SendHospitalName;
            var pictures = await _contentPlatFormCustomerPictureService.GetListAsync(orderUpdateInfo.Id);
            orderUpdateInfo.CustomerPictures = pictures.Select(z => z.CustomerPicture).ToList();
            return ResultData<ContentPlateFormOrderVo>.Success().AddData("orderInfo", orderUpdateInfo);
        }


        /// <summary>
        /// 生成订单喜报
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("orderProsperity/{id}")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<OrderProsperityVo>> OrderProsperityAsync(string id)
        {
            var order = await _orderService.GetByOrderIdAsync(id);
            if (order.OrderStatus != (int)ContentPlateFormOrderStatus.OrderComplete)
            { throw new Exception("该订单暂未成交，无法生成喜报！"); }
            OrderProsperityVo orderUpdateInfo = new OrderProsperityVo();
            orderUpdateInfo.Price = order.DepositAmount.Value + order.DealAmount.Value;
            orderUpdateInfo.LiveAnchorName = order.LiveAnchorName;
            orderUpdateInfo.hospitalPicture = order.SendHospitaPicture;
            orderUpdateInfo.DealDate = order.DealDate;
            return ResultData<OrderProsperityVo>.Success().AddData("orderInfo", orderUpdateInfo);
        }


        /// <summary>
        /// 根据订单编号查看重单截图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("selectRepeateOrderPic")]
        [FxInternalAuthorize]
        public async Task<ResultData<string>> SelectRepeateOrderPicAsync(string id)
        {
            var repeateOrderPictureUrl = await _orderService.SelectRepeateOrderPicAsync(id);
            return ResultData<string>.Success().AddData("repeateOrderPictureUrl", repeateOrderPictureUrl);
        }

        /// <summary>
        /// 根据加密手机号获取简易的订单列表
        /// </summary>
        /// <param name="encryptPhone">加密手机号</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listByEncryptPhone")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<ContentPlatFormOrderInfoSimpleVo>>> GetListByEncryptPhoneAsync(string encryptPhone, int pageNum, int pageSize)
        {
            try
            {
                var q = await _orderService.GetListByEncryptPhoneAsync(encryptPhone, pageNum, pageSize);

                var order = from d in q.List
                            select new ContentPlatFormOrderInfoSimpleVo
                            {
                                Id = d.Id,
                                ContentPlatformName = d.ContentPlatformName,
                                LiveAnchorName = d.LiveAnchorName,
                                GoodsName = d.GoodsName,
                                ConsultingContent = d.ConsultingContent,
                                DealAmount = d.DealAmount,
                                DepositAmount = d.DepositAmount.HasValue ? d.DepositAmount : 0,
                                OrderTypeText = d.OrderTypeText,
                                OrderStatusText = d.OrderStatusText,
                                AppointmentHospitalName = d.AppointmentHospitalName,
                                AppointmentDate = d.AppointmentDate,
                                UnDealReason = d.UnDealReason,
                                LateProjectStage = d.LateProjectStage,
                                Remark = d.Remark
                            };

                FxPageInfo<ContentPlatFormOrderInfoSimpleVo> orderPageInfo = new FxPageInfo<ContentPlatFormOrderInfoSimpleVo>();
                orderPageInfo.TotalCount = q.TotalCount;
                orderPageInfo.List = order;
                orderPageInfo.PageSize = pageSize;
                orderPageInfo.CurrentPageIndex = pageNum;
                return ResultData<FxPageInfo<ContentPlatFormOrderInfoSimpleVo>>.Success().AddData("order", orderPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<ContentPlatFormOrderInfoSimpleVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("updateContentPlateFormOrder")]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateOrderAsync(ContentPlateFormOrderUpdateVo updateVo)
        {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);

            //修改订单
            ContentPlateFormOrderUpdateDto updateDto = new ContentPlateFormOrderUpdateDto();
            updateDto.Id = updateVo.Id;
            updateDto.OrderType = updateVo.OrderType;
            updateDto.ContentPlateFormId = updateVo.ContentPlateFormId;
            updateDto.LiveAnchorWeChatNo = updateVo.LiveAnchorWeChatNo;
            updateDto.LiveAnchorId = updateVo.LiveAnchorId;
            updateDto.GoodsId = updateVo.GoodsId;
            updateDto.ConsultationType = updateVo.ConsultationType;
            updateDto.HospitalDepartmentId = updateVo.HospitalDepartmentId;
            updateDto.CustomerName = updateVo.CustomerName;
            updateDto.ConsultationEmpId = updateVo.ConsultationEmpId;
            updateDto.Phone = updateVo.Phone;
            updateDto.AppointmentDate = updateVo.AppointmentDate;
            updateDto.AppointmentHospitalId = updateVo.AppointmentHospitalId;
            updateDto.DepositAmount = updateVo.DepositAmount;
            updateDto.ConsultingContent = updateVo.ConsultingContent;
            updateDto.Remark = updateVo.Remark;
            updateDto.LateProjectStage = updateVo.LateProjectStage;
            updateDto.EmployeeId = employeeId;
            updateDto.OrderSource = updateVo.OrderSource;
            updateDto.AcceptConsulting = updateVo.AcceptConsulting;
            updateDto.UnSendReason = updateVo.UnSendReason;
            updateDto.CustomerPictures = updateVo.CustomerPictures;
            await _orderService.UpdateContentPlateFormOrderAsync(updateDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 审核订单
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("checkContentPlateFormOrder")]
        [FxInternalAuthorize]
        public async Task<ResultData> CheckOrderAsync(ContentPlateFormOrderCheckVo updateVo)
        {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            if (employee.PositionId != "1")
            {
                if (employee.PositionId != "13")
                {
                    throw new Exception("只有管理员与财务才可进行订单审核！");
                }
            }
            //修改订单
            ContentPlateFormOrderCheckDto updateDto = new ContentPlateFormOrderCheckDto();
            updateDto.Id = updateVo.Id;
            updateDto.OrderDealInfoId = updateVo.OrderDealInfoId;
            updateDto.CheckPrice = updateVo.CheckPrice;
            updateDto.CheckState = updateVo.CheckState;
            updateDto.SettlePrice = updateVo.SettlePrice;
            updateDto.employeeId = employeeId;
            updateDto.CheckRemark = updateVo.CheckRemark;
            updateDto.CheckPicture = updateVo.CheckPicture;
            await _orderService.CheckContentPlateFormOrderAsync(updateDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 订单审核后回款
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("returnBackOrder")]
        [FxInternalAuthorize]
        public async Task<ResultData> ReturnBackOrderAsync(ReturnBackOrderVo updateVo)
        {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            if (employee.PositionId != "1")
            {
                if (employee.PositionId != "13")
                {
                    throw new Exception("只有管理员与财务才可进行订单回款！");
                }
            }
            //修改订单
            ReturnBackOrderDto updateDto = new ReturnBackOrderDto();
            updateDto.OrderId = updateVo.OrderId;
            updateDto.OrderDealId = updateVo.OrderDealId;
            updateDto.ReturnBackPrice = updateVo.ReturnBackPrice;
            updateDto.ReturnBackDate = updateVo.ReturnBackDate;
            await _orderService.ReturnBackOrderAsync(updateDto);
            return ResultData.Success();
        }


        /// <summary>
        /// 添加派单
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        [FxInternalAuthorize]
        public async Task<ResultData> AddAsync(AddContentPlatFormSendOrderInfoVo addVo)
        {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            AddContentPlatFormSendOrderInfoDto addDto = new AddContentPlatFormSendOrderInfoDto();
            addDto.HospitalId = addVo.HospitalId;
            addDto.OrderId = addVo.OrderId;
            addDto.IsUncertainDate = addVo.IsUncertainDate;
            addDto.AppointmentDate = addVo.AppointmentDate;
            addDto.Remark = addVo.Remark;
            addDto.SendBy = addVo.SendBy;
            addDto.EmployeeId = employeeId;
            await _orderService.SendOrderAsync(addDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData> DeleteAsync(string id)
        {
            await _orderService.DeleteOrderAsync(id);
            return ResultData.Success();
        }
        /// <summary>
        /// 医院接单
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns></returns>
        [HttpGet("contentPlateFormOrderConfirm")]
        [FxTenantAuthorize]
        public async Task<ResultData> RepeateOrderAsync(string orderId)
        {
            await _orderService.HospitalConfirmOrderAsync(orderId);
            return ResultData.Success();
        }
        /// <summary>
        /// 医院重单打回
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("contentPlateFormOrderRepeate")]
        [FxTenantAuthorize]
        public async Task<ResultData> RepeateOrderAsync(ContentPlateFormOrderRepeateVo updateVo)
        {
            ContentPlateFormOrderRepeateDto updateDto = new ContentPlateFormOrderRepeateDto();
            updateDto.Id = updateVo.Id;
            updateDto.OrderId = updateVo.OrderId;
            updateDto.RepeatePictureUrl = updateVo.RepeatePictureUrl;
            await _orderService.RepeateContentPlateFormOrderAsync(updateDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 修改派单
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateAsync(UpdateContentPlatFormSendOrderInfoVo updateVo)
        {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            UpdateContentPlatFormSendOrderInfoDto updateDto = new UpdateContentPlatFormSendOrderInfoDto();
            updateDto.Id = updateVo.Id;
            updateDto.OrderId = updateVo.OrderId;
            updateDto.HospitalId = updateVo.HospitalId;
            updateDto.IsUncertainDate = updateVo.IsUncertainDate;
            updateDto.AppointmentDate = updateVo.AppointmentDate;
            updateDto.Remark = updateVo.Remark;

            await _orderService.UpdateAsync(updateDto, employeeId);
            return ResultData.Success();
        }

        /// <summary>
        /// 获取已绑定客服的内容平台订单列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="customerServiceId"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("bindCustomerServieOrders")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<BindCustomerServiceContentPlatformOrderVo>>> GetBindCustomerServieContentPlatformOrdersAsync(int? customerServiceId, int? liveAnchorId, DateTime? startDate, DateTime? endDate, string keyword, int pageNum, int pageSize)
        {
            var orders = await _orderService.GetBindCustomerServieContentPlatformOrdersAsync(customerServiceId, liveAnchorId, startDate, endDate, keyword, pageNum, pageSize);
            var contentPlatformOrders = from d in orders.List
                                        select new BindCustomerServiceContentPlatformOrderVo
                                        {
                                            Id = d.Id,
                                            OrderType = d.OrderType,
                                            OrderTypeText = d.OrderTypeText,
                                            ContentPlatformId = d.ContentPlatformId,
                                            ContentPlatformName = d.ContentPlatformName,
                                            LiveAnchorId = d.LiveAnchorId,
                                            LiveAnchorName = d.LiveAnchorName,
                                            CreateDate = d.CreateDate,
                                            UpdateDate = d.UpdateDate,
                                            GoodsId = d.GoodsId,
                                            GoodsName = d.GoodsName,
                                            ThumbPictureUrl = d.ThumbPictureUrl,
                                            CustomerName = d.CustomerName,
                                            AppointmentDate = d.AppointmentDate,
                                            AppointmentHospitalId = d.AppointmentHospitalId,
                                            AppointmentHospitalName = d.AppointmentHospitalName,
                                            OrderStatus = d.OrderStatus,
                                            OrderStatusText = d.OrderStatusText,
                                            Remark = d.Remark,
                                            EncryptPhone = d.EncryptPhone,
                                            Phone = d.Phone,
                                            CustomerServiceId = d.CustomerServiceId,
                                            CustomerServiceName = d.CustomerServiceName,
                                        };
            FxPageInfo<BindCustomerServiceContentPlatformOrderVo> pageInfo = new FxPageInfo<BindCustomerServiceContentPlatformOrderVo>();
            pageInfo.TotalCount = orders.TotalCount;
            pageInfo.List = contentPlatformOrders;
            return ResultData<FxPageInfo<BindCustomerServiceContentPlatformOrderVo>>.Success().AddData("orders", pageInfo);
        }


        /// <summary>
        /// 客服完成订单
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("finishContentPlateFormOrderByEmployee")]
        [FxInternalAuthorize]
        public async Task<ResultData> FinishOrderByEmployeeAsync(ContentPlateFormOrderFinishVo updateVo)
        {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            ContentPlateFormOrderFinishDto updateDto = new ContentPlateFormOrderFinishDto();
            updateDto.Id = updateVo.Id;
            updateDto.IsFinish = updateVo.IsFinish;
            updateDto.LastDealHospitalId = updateVo.LastDealHospitalId;
            updateDto.ToHospitalDate = updateVo.ToHospitalDate;
            updateDto.DealAmount = updateVo.DealAmount;
            updateDto.LastProjectStage = updateVo.LastProjectStage;
            updateDto.DealPictureUrl = updateVo.DealPictureUrl;
            updateDto.CommissionRatio = updateVo.CommissionRatio;
            updateDto.IsAcompanying = updateVo.IsAcompanying;
            updateDto.UnDealReason = updateVo.UnDealReason;
            updateDto.IsToHospital = updateVo.IsToHospital;
            updateDto.ToHospitalType = updateVo.ToHospitalType;
            updateDto.UnDealPictureUrl = updateVo.UnDealPictureUrl;
            updateDto.DealDate = updateVo.DealDate;
            updateDto.OtherContentPlatFormOrderId = updateVo.OtherContentPlatFormOrderId;
            updateDto.EmpId = Convert.ToInt32(employee.Id);
            await _orderService.FinishContentPlateFormOrderAsync(updateDto);
            return ResultData.Success();
        }



        /// <summary>
        /// 客服修改已完成订单
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("updateFinishContentPlateFormOrderByEmployee")]
        [FxInternalAuthorize]
        public async Task<ResultData> UpdateFinishOrderByEmployeeAsync(UpdateContentPlateFormOrderFinishVo updateVo)
        {
            UpdateContentPlateFormOrderFinishDto updateDto = new UpdateContentPlateFormOrderFinishDto();
            updateDto.Id = updateVo.Id;
            updateDto.DealId = updateVo.DealId;
            updateDto.IsFinish = updateVo.IsFinish;
            updateDto.LastDealHospitalId = updateVo.LastDealHospitalId;
            updateDto.ToHospitalDate = updateVo.ToHospitalDate;
            updateDto.DealAmount = updateVo.DealAmount;
            updateDto.LastProjectStage = updateVo.LastProjectStage;
            updateDto.DealPictureUrl = updateVo.DealPictureUrl;
            updateDto.UnDealReason = updateVo.UnDealReason;
            updateDto.IsToHospital = updateVo.IsToHospital;
            updateDto.ToHospitalType = updateVo.ToHospitalType;
            updateDto.UnDealPictureUrl = updateVo.UnDealPictureUrl;
            updateDto.DealDate = updateVo.DealDate;
            updateDto.CommissionRatio = updateVo.CommissionRatio;
            updateDto.IsAcompanying = updateVo.IsAcompanying;
            updateDto.OtherContentPlatFormOrderId = updateVo.OtherContentPlatFormOrderId;
            await _orderService.UpdateFinishContentPlateFormOrderAsync(updateDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 医院完成订单
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("finishContentPlateFormOrder")]
        [FxTenantAuthorize]
        public async Task<ResultData> FinishOrderAsync(ContentPlateFormOrderFinishVo updateVo)
        {
            //修改订单
            ContentPlateFormOrderFinishDto updateDto = new ContentPlateFormOrderFinishDto();
            updateDto.Id = updateVo.Id;
            updateDto.IsFinish = updateVo.IsFinish;
            updateDto.DealAmount = updateVo.DealAmount;
            updateDto.LastDealHospitalId = updateVo.LastDealHospitalId;
            updateDto.ToHospitalDate = updateVo.ToHospitalDate;
            updateDto.LastProjectStage = updateVo.LastProjectStage;
            updateDto.DealPictureUrl = updateVo.DealPictureUrl;
            updateDto.UnDealReason = updateVo.UnDealReason;
            updateDto.IsToHospital = updateVo.IsToHospital;
            updateDto.UnDealPictureUrl = updateVo.UnDealPictureUrl;
            updateDto.DealDate = updateVo.DealDate;
            updateDto.IsAcompanying = updateVo.IsAcompanying;
            updateDto.EmpId = 0;
            await _orderService.FinishContentPlateFormOrderAsync(updateDto);
            return ResultData.Success();
        }


        #region 枚举下拉框

        /// <summary>
        /// 获取内容平台面诊状态
        /// </summary>
        /// <returns></returns>
        [HttpGet("getOrderConsultationTypeList")]
        public ResultData<List<ContentPlateFormOrderTypeVo>> GetOrderConsultationTypeList()
        {
            var orderTypes = from d in _orderService.GetOrderConsultationTypeList()
                             select new ContentPlateFormOrderTypeVo
                             {
                                 OrderType = d.OrderType,
                                 OrderTypeText = d.OrderTypeText = d.OrderTypeText
                             };
            return ResultData<List<ContentPlateFormOrderTypeVo>>.Success().AddData("orderConsultationTypes", orderTypes.ToList());
        }

        /// <summary>
        /// 获取内容平台订单类型
        /// </summary>
        /// <returns></returns>
        [HttpGet("contentPlateFormOrderTypeList")]
        public ResultData<List<ContentPlateFormOrderTypeVo>> GetContentPlateFormOrderTypeList()
        {
            var orderTypes = from d in _orderService.GetOrderTypeList()
                             select new ContentPlateFormOrderTypeVo
                             {
                                 OrderType = d.OrderType,
                                 OrderTypeText = d.OrderTypeText = d.OrderTypeText
                             };
            return ResultData<List<ContentPlateFormOrderTypeVo>>.Success().AddData("orderTypes", orderTypes.ToList());
        }

        /// <summary>
        /// 获取内容平台订单状态
        /// </summary>
        /// <returns></returns>
        [HttpGet("contentPlateFormOrderStatusList")]
        public ResultData<List<ContentPlateFormOrderStatusVo>> GetContentPlateFormOrderStatusList()
        {
            var orderStatus = from d in _orderService.GetOrderStatusList()
                              select new ContentPlateFormOrderStatusVo
                              {
                                  OrderStatus = d.OrderStatus,
                                  OrderStatusText = d.OrderStatusText
                              };
            return ResultData<List<ContentPlateFormOrderStatusVo>>.Success().AddData("orderStatus", orderStatus.ToList());
        }


        /// <summary>
        /// 获取内容平台订单来源
        /// </summary>
        /// <returns></returns>
        [HttpGet("contentPlateFormOrderSourceList")]
        public ResultData<List<ContentPlateFormOrderSourceVo>> GetContentPlateFormOrderSourceList()
        {
            var orderSources = from d in _orderService.GetOrderSourceList()
                               select new ContentPlateFormOrderSourceVo
                               {
                                   OrderSource = d.OrderSource,
                                   OrderSourceText = d.OrderSourceText = d.OrderSourceText
                               };
            return ResultData<List<ContentPlateFormOrderSourceVo>>.Success().AddData("orderSources", orderSources.ToList());
        }

        /// <summary>
        /// 获取内容平台订单到院状态
        /// </summary>
        /// <returns></returns>
        [HttpGet("contentPlateFormOrderToHospitalTypeList")]
        public ResultData<List<ContentPlateFormOrderTypeVo>> GetContentPlateFormOrderToHospitalTypeList()
        {
            var orderTypes = from d in _orderService.GetOrderToHospitalTypeList()
                             select new ContentPlateFormOrderTypeVo
                             {
                                 OrderType = d.OrderType,
                                 OrderTypeText = d.OrderTypeText = d.OrderTypeText
                             };
            return ResultData<List<ContentPlateFormOrderTypeVo>>.Success().AddData("orderTypes", orderTypes.ToList());
        }
        #endregion
    }
}
