

using Fx.Amiya.BusinessWeChat.Api.Vo;
using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlatFormOrderSend;
using Fx.Amiya.BusinessWeChat.Api.Vo.ThirdPartContentPlatformInfo;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Common.Utils;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private IHospitalEmployeeService hospitalEmployeeService;
        private IHospitalContentplatformCodeService hospitalContentplatformCodeService;
        private IContentPlatformOrderSendService _sendOrderInfoService;
        private IContentPlatformOrderSendService contentPlatformOrderSendService;
        private ICustomerBaseInfoService customerBaseInfoService;
        private IWxAppConfigService _wxAppConfigService;
        private IThirdPartContentplatformInfoService thirdPartContentplatformInfoService;
        private IContentPlatFormOrderDealInfoService orderDealInfoService;
        private readonly IContentPlateFormOrderService contentPlateFormOrderService;
        private IHospitalCustomerInfoService hospitalCustomerInfoService;
        private IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService;
        private IAmiyaGoodsDemandService amiyaGoodsDemandService;
        private ILiveAnchorBaseInfoService liveAnchorBaseInfoService;
        private ILiveAnchorService liveAnchorService;
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
            ILiveAnchorService liveAnchorService,
            ILiveAnchorBaseInfoService liveAnchorBaseInfoService,
            ICustomerBaseInfoService customerBaseInfoService,
            IThirdPartContentplatformInfoService thirdPartContentplatformInfoService,
             IContentPlateFormOrderService contentPlateFormOrderService,
             IAmiyaHospitalDepartmentService amiyaHospitalDepartmentService,
            IHospitalCustomerInfoService hospitalCustomerInfoService,
            IHospitalContentplatformCodeService hospitalContentplatformCodeService,
            IHospitalEmployeeService hospitalEmployeeService,
            IAmiyaGoodsDemandService amiyaGoodsDemandService,
            IContentPlatformOrderSendService contentPlatformOrderSendService,
            IHttpContextAccessor httpContextAccessor,
             IWxAppConfigService wxAppConfigService)
        {
            _sendOrderInfoService = sendOrderInfoService;
            this.hospitalEmployeeService = hospitalEmployeeService;
            this.orderDealInfoService = orderDealInfoService;
            this.customerBaseInfoService = customerBaseInfoService;
            this.liveAnchorService = liveAnchorService;
            this.liveAnchorBaseInfoService = liveAnchorBaseInfoService;
            this.amiyaGoodsDemandService = amiyaGoodsDemandService;
            this.contentPlateFormOrderService = contentPlateFormOrderService;
            _wxAppConfigService = wxAppConfigService;
            this.amiyaHospitalDepartmentService = amiyaHospitalDepartmentService;
            this.hospitalContentplatformCodeService = hospitalContentplatformCodeService;
            this.thirdPartContentplatformInfoService = thirdPartContentplatformInfoService;
            this.contentPlatformOrderSendService = contentPlatformOrderSendService;
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
        /// <param name="belongChannel"> 归属部门</param>
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
        ///<param name="isMainHospital">是否是主派(null:查所有,true:主派,false:次派)</param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<SendContentPlatformOrderVo>>> GetSendOrderList(string keyword, int? belongChannel, int? belongMonth, decimal? minAddOrderPrice, decimal? maxAddOrderPrice, int? liveAnchorId, int? consultationEmpId, int? employeeId, int? sendBy, bool? isAcompanying, bool? isOldCustomer, decimal? commissionRatio, int? orderStatus, string contentPlatFormId, DateTime? startDate, DateTime? endDate, int? hospitalId, bool? IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, int orderSource, int? hospitalEmpId, int pageNum, int pageSize, bool? isMainHospital)
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
            var orders = await _sendOrderInfoService.GetSendOrderList(liveAnchorIds, consultationEmpId, sendBy, isAcompanying, isOldCustomer, commissionRatio, keyword,belongChannel, belongMonth, minAddOrderPrice, maxAddOrderPrice, LoginEmployeeId, (int)employeeId, orderStatus, contentPlatFormId, startDate, endDate, hospitalId, IsToHospital, toHospitalStartDate, toHospitalEndDate, toHospitalType, orderSource, hospitalEmpId, pageNum, pageSize, isMainHospital);

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
                                            IsMainHospital = d.IsMainHospital,
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
        /// <summary>
        /// 根据内容派单id获取
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("sendOrderInfoList")]
        public async Task<ResultData<FxPageInfo<SimpleSendOrderInfoVo>>> GetSendOrderInfiListAsync([FromQuery] QuerySendOrderInfoListVo query)
        {
            FxPageInfo<SimpleSendOrderInfoVo> pageInfo = new FxPageInfo<SimpleSendOrderInfoVo>();
            QuerySendOrderInfoListDto queryDto = new QuerySendOrderInfoListDto();
            queryDto.ContentPlatformId = query.ContentPlatformId;
            queryDto.PageNum = query.PageNum;
            queryDto.PageSize = query.PageSize;
            var res = await _sendOrderInfoService.GetSendOrderInfoListByContentplateformIdAsync(queryDto);
            pageInfo.TotalCount = res.TotalCount;
            pageInfo.List = res.List.Select(e => new SimpleSendOrderInfoVo
            {
                Id = e.Id,
                HospitalName = e.HospitalName,
                HospitalId = e.HospitalId,
                AppointmentDate = e.AppointmentDate,
                Remark = e.Remark,
                SendBy = e.SendBy,
                IsMainHospital = e.IsMainHospital,
                SendDate = e.SendDate,
                SenderName = e.SenderName,
                HospitalRemark = e.HospitalRemark,
                OrderStatus = e.OrderStatus,
                IsSpecifyHospitalEmployee = e.IsSpecifyHospitalEmployee,
                HospitalEmployeeId = e.HospitalEmployeeId,
                HospitalEmployeeName = e.HospitalEmployeeName
            });
            return ResultData<FxPageInfo<SimpleSendOrderInfoVo>>.Success().AddData("sendOrderInfoList", pageInfo);
        }



        /// <summary>
        /// 获取有效的三方平台信息信息（下拉框使用）
        /// </summary>
        /// <param name="hospitalId">医院编号</param>
        /// <returns></returns>
        [HttpGet("ValidKeyAndValue")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetValidByKeyAndValueAsync(int hospitalId)
        {
            try
            {
                var q = await hospitalContentplatformCodeService.GetValidListAsync(hospitalId);
                var thirdPartContentplatformInfo = from d in q
                                                   select new BaseIdAndNameVo
                                                   {
                                                       Id = d.Key,
                                                       Name = d.Value,
                                                   };

                return ResultData<List<BaseIdAndNameVo>>.Success().AddData("thirdPartContentplatformInfo", thirdPartContentplatformInfo.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<BaseIdAndNameVo>>.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 管理端根据医院id和三方平台id进行查重-朗姿
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("getIsRepeateByHospitalIdAndThirdPartIdToLangZi")]
        [FxInternalOrTenantAuthroize]
        public async Task<ResultData<ThirdPartContentPlatformInfoToLangZiResultVo>> GetIsRepeateByHospitalIdAndThirdPartIdToLangZiAsync([FromQuery] QueryIsRepeateByHospitalIdAndThirdPartIdVo query)
        {
            try
            {
                var thirdcontentPlatformInfo = await thirdPartContentplatformInfoService.GetByNameAsync("朗姿");
                var url = thirdcontentPlatformInfo.ApiUrl;
                QuerySendOrderDataByLangZiVo queryData = new QuerySendOrderDataByLangZiVo();
                queryData.FWSID = "E-31-31446";
                queryData.USERID = "INTAMY";
                var hospitalContentPlatformCode = await hospitalContentplatformCodeService.GetByHospitalIdAndThirdPartContentPlatformIdAsync(query.HospitalId, query.ThirdPartContentplatformInfoId);
                queryData.JGBM = hospitalContentPlatformCode.Code;

                queryData.YWLX = query.YWLX;

                var order = await contentPlateFormOrderService.GetByOrderIdAsync(query.OrderId);

                if (query.YWLX == "P")
                {
                    queryData.PDBH = query.SendOrderId.ToString();
                    var liveAnchorId = order.LiveAnchorId;
                    var liveAnchor = await liveAnchorService.GetByIdAsync(liveAnchorId);
                    queryData.ZBID = liveAnchor.LiveAnchorBaseId;
                    var liveanchorBaseInfo = await liveAnchorBaseInfoService.GetByIdAsync(queryData.ZBID);
                    queryData.ZBNM = liveanchorBaseInfo.LiveAnchorName;
                }
                else
                {
                    queryData.PDBH = CreateOrderIdHelper.GetNextNumber();
                }
                if (query.SendOrderId != 0)
                {
                    var sendInfo = await contentPlatformOrderSendService.GetByIdAsync(Convert.ToInt32(query.SendOrderId.ToString()));
                    if (sendInfo.IsSpecifyHospitalEmployee == true)
                    {
                        queryData.PDYSID = sendInfo.HospitalEmployeeId.ToString();
                        var hospitalEmpInfo = await hospitalEmployeeService.GetByIdAsync(sendInfo.HospitalEmployeeId);
                        queryData.PDYSNM = hospitalEmpInfo.Name;
                        queryData.PDRQ = order.SendDate.Value;
                    }
                }
                var customerBaseInfo = await customerBaseInfoService.GetByPhoneAsync(order.Phone);
                queryData.KUNAM = order.CustomerName;
                //queryData.KUSEX = customerBaseInfo.Sex;
                //queryData.AGE = customerBaseInfo.Age.HasValue ? customerBaseInfo.Age.Value : 0;
                //queryData.KUPRO = customerBaseInfo.Occupation;
                //queryData.KHWX = customerBaseInfo.WechatNumber;
                var goodsDemandInfo = await amiyaGoodsDemandService.GetByIdAsync(order.GoodsId);
                var amiyaHospitalDemandInfo = await amiyaHospitalDepartmentService.GetByIdAsync(order.HospitalDepartmentId);
                queryData.PTXMLB1 = order.HospitalDepartmentName;
                queryData.PTXMLB2 = order.GoodsName;
                queryData.PTXMMC = order.GoodsDescription;
                queryData.REGION = customerBaseInfo.City;
                queryData.TEL1 = order.Phone;
                queryData.PDTZ = order.ConsultingContent;
                var data = JsonConvert.SerializeObject(queryData);
                var getResult = await HttpUtil.HTTPJsonGetHasBodyAsync(url, data);
                //var getResult = "";
                var result = JsonConvert.DeserializeObject<ThirdPartContentPlatformInfoToLangZiResultVo>(getResult);
                switch (result.RESULT)
                {
                    case "0":
                        result.REMSG += "；无重复";
                        break;
                    case "1":
                        result.REMSG += "；已被其他通路建档";
                        break;
                    case "2":
                        result.REMSG += "；已被所在通路建档";
                        break;
                }


                return ResultData<ThirdPartContentPlatformInfoToLangZiResultVo>.Success().AddData("hospitalContentplatformCode", result);
            }
            catch (Exception ex)
            {
                return ResultData<ThirdPartContentPlatformInfoToLangZiResultVo>.Fail(ex.Message);
            }
        }

    }
}
