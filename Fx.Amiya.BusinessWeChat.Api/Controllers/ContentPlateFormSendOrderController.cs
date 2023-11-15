

using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlatFormOrderSend;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWechat.Api.Controllers
{
    /// <summary>
    /// 派单API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ContentPlateFormSendOrderController : ControllerBase
    {


        private IHttpContextAccessor _httpContextAccessor;
        private IContentPlatformOrderSendService _sendOrderInfoService;
        private IWxAppConfigService _wxAppConfigService;
        private IContentPlatFormOrderDealInfoService orderDealInfoService;
        private IHospitalCustomerInfoService hospitalCustomerInfoService;
        /// <summary>
        /// 派单API
        /// </summary>
        /// <param name="sendOrderInfoService"></param>
        /// <param name="orderDealInfoService"></param>
        /// <param name="hospitalCustomerInfoService"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="wxAppConfigService"></param>
        public ContentPlateFormSendOrderController(IContentPlatformOrderSendService sendOrderInfoService,
            IContentPlatFormOrderDealInfoService orderDealInfoService,
            IHospitalCustomerInfoService hospitalCustomerInfoService,
            IHttpContextAccessor httpContextAccessor,
             IWxAppConfigService wxAppConfigService)
        {
            _sendOrderInfoService = sendOrderInfoService;
            this.orderDealInfoService = orderDealInfoService;
            _wxAppConfigService = wxAppConfigService;
            this.hospitalCustomerInfoService = hospitalCustomerInfoService;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 根据编号获取简单的派单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("simpleById/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<ContentPlatFormSendOrderInfoSimpleVo>> GetSimpleByIdAsync(int id)
        {
            var sendOrderInfo = await _sendOrderInfoService.GetSimpleByIdAsync(id);
            ContentPlatFormSendOrderInfoSimpleVo sendOrderInfoSimpleVo = new ContentPlatFormSendOrderInfoSimpleVo();
            sendOrderInfoSimpleVo.Id = sendOrderInfo.Id;
            sendOrderInfoSimpleVo.HospitalId = sendOrderInfo.HospitalId;
            sendOrderInfoSimpleVo.IsUncertainDate = sendOrderInfo.IsUncertainDate;
            sendOrderInfoSimpleVo.AppointmentDate = sendOrderInfo.AppointmentDate;
            sendOrderInfoSimpleVo.IsUncertainDate = sendOrderInfo.IsUncertainDate;
            sendOrderInfoSimpleVo.IsMainHospital = sendOrderInfo.IsMainHospital;
            return ResultData<ContentPlatFormSendOrderInfoSimpleVo>.Success().AddData("sendOrderInfo", sendOrderInfoSimpleVo);
        }



        /// <summary>
        /// 获取内容平台订单已派单信息列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="employeeId"> -1(归属客服)查询全部</param>
        /// <param name="sendBy"> 派单人（空查询全部）</param>
        /// <param name="isAcompanying">是否陪诊，为空查询所有</param>
        /// <param name="isOldCustomer">新老客业绩，为空查询所有</param>
        /// <param name="commissionRatio">佣金比例，为空查询所有</param>
        /// <param name="belongMonth">归属月份</param>
        /// <param name="minAddOrderPrice">最小下单金额</param>
        /// <param name="maxAddOrderPrice">最大下单金额</param>
        /// <param name="liveAnchorId">归属主播ID</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <param name="consultationEmpId">面诊员id</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>        
        /// <param name="hospitalId"></param>        
        /// <param name="IsToHospital">是否到院，为空查询全部</param>
        /// <param name="toHospitalStartDate">到院时间起</param>
        /// <param name="toHospitalEndDate">到院时间止</param>           
        /// <param name="toHospitalType">到院类型</param>        
        /// <param name="orderSource">订单来源， -1查询全部</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<SendContentPlatformOrderVo>>> GetSendOrderList(string keyword, int? belongMonth, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int? liveAnchorId, int? consultationEmpId, int? employeeId, int? sendBy, bool? isAcompanying, bool? isOldCustomer, decimal? commissionRatio, int? orderStatus, string contentPlatFormId, DateTime? startDate, DateTime? endDate, int? hospitalId, bool? IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, int orderSource, int pageNum, int pageSize)
        {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            var LoginEmployeeId = Convert.ToInt32(employee.Id);
            List<int?> liveAnchorIds = new List<int?>();
            if (liveAnchorId.HasValue)
            {
                liveAnchorIds.Add(liveAnchorId);
            }
            if (!employeeId.HasValue)
            {
                employeeId = -1;
            }
            var orders = await _sendOrderInfoService.GetSendOrderList(liveAnchorIds, consultationEmpId, sendBy, isAcompanying, isOldCustomer, commissionRatio, keyword, belongMonth, minAddOrderPrice, maxAddOrderPrice, LoginEmployeeId, (int)employeeId, orderStatus, contentPlatFormId, startDate, endDate, hospitalId, IsToHospital, toHospitalStartDate, toHospitalEndDate, toHospitalType, orderSource, pageNum, pageSize);

            var contentPlatformOrders = from d in orders.List
                                        select new SendContentPlatformOrderVo
                                        {
                                            Id = d.Id,
                                            OrderId = d.OrderId,
                                            ContentPlatFormName = d.ContentPlatFormName,
                                            LiveAnchorName = d.LiveAnchorName,
                                            LiveAnchorWeChatNo = d.LiveAnchorWeChatNo,
                                            IsOldCustomer = d.IsOldCustomer,
                                            IsAcompanying = d.IsAcompanying,
                                            CommissionRatio = d.CommissionRatio,
                                            CustomerName = d.CustomerName,
                                            Phone = d.Phone,
                                            EncryptPhone = d.EncryptPhone,
                                            BelongMonth = d.BelongMonth,
                                            AddOrderPrice = d.AddOrderPrice,
                                            SendHospitalId = d.SendHospitalId,
                                            IsHospitalCheckPhone = d.IsHospitalCheckPhone,
                                            AppointmentHospital = d.AppointmentHospital,
                                            AppointmentDate = d.AppointmentDate,
                                            GoodsName = d.GoodsName,
                                            ThumbPictureUrl = d.ThumbPictureUrl,
                                            LateProjectStage = d.LateProjectStage,
                                            OrderTypeText = d.OrderTypeText,
                                            OrderStatusText = d.OrderStatusText,
                                            DepositAmount = d.DepositAmount,
                                            DealAmount = d.DealAmount,
                                            DealPictureUrl = d.DealPictureUrl,
                                            IsToHospital = d.IsToHospital,
                                            ToHospitalTypeText = d.ToHospitalTypeText,
                                            ToHospitalDate = d.ToHospitalDate,
                                            UnDealReason = d.UnDealReason,
                                            Sender = d.Sender,
                                            SenderName = d.SenderName,
                                            SendDate = d.SendDate,
                                            SendHospital = d.SendHospital,
                                            DealDate = d.DealDate,
                                            SendOrderRemark = d.SendOrderRemark,
                                            OrderRemark = d.OrderRemark,
                                            ConsultingContent = d.ConsultingContent,
                                            HospitalRemark = d.HospitalRemark,
                                            UnDealPictureUrl = d.UnDealPictureUrl,
                                            AcceptConsulting = d.AcceptConsulting,
                                            OrderSourceText = d.OrderSourceText,
                                            ConsultatioType = d.ConsultationTypeText,
                                            CheckState = d.CheckState,
                                            OtherContentPlatFormOrderId = d.OtherContentPlatFormOrderId,
                                            IsRepeatProfundityOrder = d.IsRepeatProfundityOrder,
                                            IsMainHospital= d.IsMainHospital,
                                        };
            FxPageInfo<SendContentPlatformOrderVo> pageInfo = new FxPageInfo<SendContentPlatformOrderVo>();
            pageInfo.TotalCount = orders.TotalCount;
            pageInfo.List = contentPlatformOrders;
            return ResultData<FxPageInfo<SendContentPlatformOrderVo>>.Success().AddData("sendOrders", pageInfo);
        }



        /// <summary>
        /// 根据订单号获取订单成交情况
        /// </summary>
        /// <param name="contentPlatFormOrderId">订单号</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("contentPlatFormOrderDealInfo")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<ContentPlatFormOrderDealInfoVo>>> GetDealInfo(string contentPlatFormOrderId, int pageNum, int pageSize)
        {

            var result = await orderDealInfoService.GetListWithPageAsync(contentPlatFormOrderId, pageNum, pageSize);

            var contentPlatformOrders = from d in result.List
                                        select new ContentPlatFormOrderDealInfoVo
                                        {
                                            Id = d.Id,
                                            ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                            CreateDate = d.CreateDate,
                                            IsDeal = d.IsDeal,
                                            CheckState = d.CheckState,
                                            IsToHospital = d.IsToHospital,
                                            ToHospitalType = d.ToHospitalType,
                                            ToHospitalTypeText = d.ToHospitalTypeText,
                                            TohospitalDate = d.ToHospitalDate,
                                            DealPerformanceTypeText = d.DealPerformanceTypeText,
                                            DealHospital = d.LastDealHospital,
                                            DealPicture = d.DealPicture,
                                            Remark = d.Remark,
                                            Price = d.Price,
                                            OtherOrderId = d.OtherAppOrderId,
                                            DealDate = d.DealDate,
                                            IsAcompanying = d.IsAcompanying,
                                            IsOldCustomer = d.IsOldCustomer,
                                            CommissionRatio = d.CommissionRatio,
                                            IsRepeatProfundityOrder = d.IsRepeatProfundityOrder,
                                            ConsumptionType = d.ConsumptionType,
                                            ConsumptionTypeText = d.ConsumptionTypeText
                                        };
            FxPageInfo<ContentPlatFormOrderDealInfoVo> pageInfo = new FxPageInfo<ContentPlatFormOrderDealInfoVo>();
            pageInfo.TotalCount = result.TotalCount;
            pageInfo.List = contentPlatformOrders;
            return ResultData<FxPageInfo<ContentPlatFormOrderDealInfoVo>>.Success().AddData("contentPlatFormOrderDealInfo", pageInfo);
        }
    }
}
