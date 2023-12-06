using Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.Background.Api.Vo.Order;
using Fx.Amiya.Background.Api.Vo.OrderCheck;
using Fx.Amiya.Background.Api.Vo.TikTok;
using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.TikTokOrder;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Amiya.Service;
using Fx.Amiya.SyncOrder.Core;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Common.Utils;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 抖点订单 API
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class TikTokOrderController : ControllerBase
    {
        private ITikTokOrderInfoService tikTokOrderService;
        private IHttpContextAccessor httpContextAccessor;
        private IGoodsInfo goodsInfoService;
        private IDalBindCustomerService _dalBindCustomerService;
        private IMemberCard memberCardService;
        private ICustomerService customerService;
        private IIntegrationAccount integrationAccountService;
        private IExpressManageService _expressManageService;
        private IAmiyaGoodsDemandService _amiyaGoodsDemandService;
        private IMemberRankInfo memberRankInfoService;
        private ITikTokOrderInfoService tikTokOrderInfoService;
        private IDalTikTokUserInfo dalTikTokUserInfo;
        private IDalTikTokOrderInfo dalTikTokOrderInfo;
        private ITikTokUserInfoService tikTokUserInfo;
        private IDalAmiyaEmployee dalAmiyaEmployee;
        private IDalBindCustomerService dalBindCustomerService;
        private IWxAppConfigService _wxAppConfigService;
        private ILiveAnchorService liveAnchorService;
        private IContentPlatformService contentPlatFormService;
        private ISendOrderInfoService _sendOrderInfoService;
        private ISyncTikTokOrder syncTikTokOrder;
        private IDalCustomerBaseInfo dalCustomerBaseInfo;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="orderService"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="goodsInfoService"></param>
        /// <param name="dalBindCustomerService"></param>
        /// <param name="memberCardService"></param>
        /// <param name="customerService"></param>
        /// <param name="integrationAccountService"></param>
        /// <param name="expressManageService"></param>
        /// <param name="amiyaGoodsDemandService"></param>
        /// <param name="memberRankInfoService"></param>
        /// <param name="tikTokOrderInfoService"></param>
        /// <param name="dalTikTokUserInfo"></param>
        /// <param name="tikTokUserInfo"></param>
        /// <param name="dalAmiyaEmployee"></param>
        /// <param name="wxAppConfigService"></param>
        /// <param name="liveAnchorService"></param>
        /// <param name="contentPlatFormService"></param>
        /// <param name="sendOrderInfoService"></param>
        /// <param name="tikTokOrderService"></param>
        /// <param name="dalTikTokOrderInfo"></param>
        /// <param name="syncTikTokOrder"></param>
        /// <param name="dalCustomerBaseInfo"></param>
        public TikTokOrderController(ITikTokOrderInfoService orderService, IHttpContextAccessor httpContextAccessor, IGoodsInfo goodsInfoService, IDalBindCustomerService dalBindCustomerService, IMemberCard memberCardService, ICustomerService customerService, IIntegrationAccount integrationAccountService, IExpressManageService expressManageService, IAmiyaGoodsDemandService amiyaGoodsDemandService, IMemberRankInfo memberRankInfoService, ITikTokOrderInfoService tikTokOrderInfoService, IDalTikTokUserInfo dalTikTokUserInfo, ITikTokUserInfoService tikTokUserInfo, IDalAmiyaEmployee dalAmiyaEmployee, IWxAppConfigService wxAppConfigService, ILiveAnchorService liveAnchorService, IContentPlatformService contentPlatFormService, ISendOrderInfoService sendOrderInfoService, ITikTokOrderInfoService tikTokOrderService, IDalTikTokOrderInfo dalTikTokOrderInfo, ISyncTikTokOrder syncTikTokOrder, IDalCustomerBaseInfo dalCustomerBaseInfo)
        {
            this.tikTokOrderService = orderService;
            this.httpContextAccessor = httpContextAccessor;
            this.goodsInfoService = goodsInfoService;
            _dalBindCustomerService = dalBindCustomerService;
            this.memberCardService = memberCardService;
            this.customerService = customerService;
            this.integrationAccountService = integrationAccountService;
            _expressManageService = expressManageService;
            _amiyaGoodsDemandService = amiyaGoodsDemandService;
            this.memberRankInfoService = memberRankInfoService;
            this.tikTokOrderInfoService = tikTokOrderInfoService;
            this.dalTikTokUserInfo = dalTikTokUserInfo;
            this.tikTokUserInfo = tikTokUserInfo;
            this.dalAmiyaEmployee = dalAmiyaEmployee;
            _wxAppConfigService = wxAppConfigService;
            this.liveAnchorService = liveAnchorService;
            this.contentPlatFormService = contentPlatFormService;
            _sendOrderInfoService = sendOrderInfoService;
            this.tikTokOrderService = tikTokOrderService;
            this.dalTikTokOrderInfo = dalTikTokOrderInfo;
            this.syncTikTokOrder = syncTikTokOrder;
            this.dalCustomerBaseInfo = dalCustomerBaseInfo;
        }
        /// <summary>
        /// 获取tiktok订单列表
        /// </summary>
        /// <param name="startDate">创建开始时间</param>
        /// <param name="endDate">创建结束时间</param>
        /// <param name="orderType">订单类型</param>
        /// <param name="keyword"></param>
        /// <param name="belongLiveAnchorId">归属基础主播id</param>
        /// <param name="statusCode">订单状态</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("tikTokOrderLlistWithPage")]
        public async Task<ResultData<FxPageInfo<TikTokOrderInfoVo>>> GetTikTokOrderListWithPageAsync(DateTime? startDate, DateTime? endDate, long? orderType, string keyword, int belongLiveAnchorId, string statusCode, int pageNum, int pageSize)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await tikTokOrderInfoService.GetOrderListWithPageAsync(startDate, endDate, orderType, keyword, belongLiveAnchorId, statusCode, pageNum, pageSize);
                var order = from d in q.List
                            select new TikTokOrderInfoVo
                            {
                                Id = d.Id,
                                ThumbPicUrl = d.ThumbPicUrl,
                                GoodsName = d.GoodsName,
                                NickName = d.BuyerNick,
                                GoodsId = d.GoodsId,
                                Phone = d.Phone,
                                EncryptPhone = d.EncryptPhone,
                                IsAppointment = d.IsAppointment,
                                StatusCode = d.StatusCode,
                                StatusText = d.StatusText,
                                ActualPayment = d.ActualPayment,
                                AccountReceivable = d.AccountReceivable,
                                CreateDate = d.CreateDate,
                                AppType = d.AppType,
                                AppTypeText = d.AppTypeText,
                                OrderType = d.OrderType,
                                OrderTypeText = d.OrderTypeText,
                                Quantity = d.Quantity,
                                ExchangeType = d.ExchangeType,
                                Description = d.Description,
                                ExchangeTypeText = d.ExchangeTypeText,
                                TradeId = d.TradeId,
                                LiveAnchor = d.LiveAnchorName,
                                LiveAnchorPlatForm = d.LiveAnchorPlatForm,
                                UpdateDate = d.UpdateDate,
                                FinishDate = d.FinishDate,
                                BelongLiveAnchorName = d.BelongLiveAnchorName
                            };
                FxPageInfo<TikTokOrderInfoVo> orderPageInfo = new FxPageInfo<TikTokOrderInfoVo>();
                orderPageInfo.TotalCount = q.TotalCount;
                orderPageInfo.List = order;
                return ResultData<FxPageInfo<TikTokOrderInfoVo>>.Success().AddData("order", orderPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<TikTokOrderInfoVo>>.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 用户信息解密
        /// </summary>
        /// <param name="orderid">订单id</param>
        /// <param name="belongLiveAnchorId">归属主播id</param>
        /// <returns></returns>
        [HttpGet("decryptUserInfo")]
        public async Task<ResultData> DecryptUserInfo(string orderid, int belongLiveAnchorId)
        {
            var info = dalTikTokOrderInfo.GetAll().Where(e => e.Id == orderid).Include(e => e.TikTokUserInfo).SingleOrDefault();
            if (!string.IsNullOrEmpty(info.Phone))
            {
                return ResultData.Fail("用户信息已解密,请勿重复解密");
            }
            if (info.StatusCode == "TRADE_CLOSED" || info.StatusCode == "REFUNDING")
            {
                return ResultData.Fail("订单已无法解密");
            }
            var decryptRes = await tikTokUserInfo.DecryptUserInfoAsync(info.TikTokUserInfo.Id, orderid, belongLiveAnchorId);
            if (decryptRes == null)
            {
                return ResultData.Fail("订单可解密时间已过,无法解密");
            }
            if (decryptRes != null)
            {
                if (string.IsNullOrEmpty(decryptRes.Phone)) {
                    return ResultData.Fail("解密失败");
                }
                TikTokUserInfoVo tikTokUserInfoVo = new TikTokUserInfoVo();
                tikTokUserInfoVo.Id = decryptRes.Id;
                tikTokUserInfoVo.Name = decryptRes.Name;
                tikTokUserInfoVo.Phone = decryptRes.Phone;
                return ResultData<TikTokUserInfoVo>.Success();
            }
            return ResultData.Fail("解密失败");
        }

        /// <summary>
        /// 录单
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("EntryOrder")]
        public async Task<ResultData> EntryOrderAsync(TikTokEntryOrderAddVo addVo)
        {
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            //添加订单
            List<TikTokOrderAddDto> amiyaOrderList = new List<TikTokOrderAddDto>();
            TikTokOrderAddDto addDto = new TikTokOrderAddDto();
            addDto.Id = CreateOrderIdHelper.GetNextNumber();
            addDto.GoodsName = addVo.GoodsName;
            addDto.GoodsId = addVo.GoodsId;
            addDto.Phone = addVo.Phone;
            addDto.StatusCode = addVo.StatusCode;
            addDto.ActualPayment = addVo.ActualPayment;
            addDto.AccountReceivable = addVo.AccountReceivable;
            addDto.CreateDate = DateTime.Now;
            addDto.ThumbPicUrl = addVo.ThumbPicUrl;
            addDto.BuyerNick = addVo.NickName;
            addDto.AppType = (byte)AppType.Douyin;
            addDto.BelongLiveAnchorId = addVo.BelongLiveAnchorId;
            addDto.IsAppointment = addVo.IsAppointment;
            addDto.OrderType = (addVo.OrderType.HasValue) ? addVo.OrderType.Value : 2;
            addDto.Quantity = (addVo.Quantity.HasValue) ? addVo.Quantity : 0;
            addDto.ExchangeType = addVo.ExchangeType;
            addDto.Description = addVo.Remark;
            amiyaOrderList.Add(addDto);
            OrderTradeAddDto orderTradeAdd = new OrderTradeAddDto();
            orderTradeAdd.CustomerId = "客服-" + employee.ToString();
            orderTradeAdd.CreateDate = DateTime.Now;
            orderTradeAdd.AddressId = 0;
            orderTradeAdd.Remark = addVo.Remark;
            orderTradeAdd.TikTokOrderInfoAddList = amiyaOrderList;
            orderTradeAdd.IsAdminAdd = true;
            await tikTokOrderInfoService.AddAmiyaOrderAsync(orderTradeAdd);
            return ResultData.Success();
        }
        /// <summary>
        /// 根据订单号查询要补单的信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("repairOrder")]
        public async Task<ResultData<TikTokInfoVo>> RepairOrder(TikTokRepairOrderVo input)
        {
            TikTokInfoVo result = new TikTokInfoVo();
            var amiyaOrder = await syncTikTokOrder.TranslateTradesSoldOrdersByOrderId(input.OrderId, input.belongLiveAnchorId);
            var FirstOrder = amiyaOrder.FirstOrDefault();
            if (FirstOrder == null)
            {
                throw new Exception("未找到对应的订单，请核对订单号后重试");
            }
            result.Id = FirstOrder.Id;
            result.GoodsName = FirstOrder.GoodsName;
            result.GoodsId = FirstOrder.GoodsId;
            result.Phone = FirstOrder.Phone;
            result.StatusCode = FirstOrder.StatusCode;
            result.ActualPayment = FirstOrder.ActualPayment;
            result.AccountReceivable = FirstOrder.ActualPayment;
            result.NickName = FirstOrder.BuyerNick;
            result.AppType = (byte)AppType.Douyin;
            result.IsAppointment = FirstOrder.IsAppointment;
            result.OrderType = FirstOrder.OrderType;
            result.OrderTypeText = ServiceClass.GetTikTokOrderTypeText((byte)FirstOrder.OrderType);
            result.Quantity = FirstOrder.Quantity;
            result.ThumbPicUrl = FirstOrder.ThumbPicUrl;
            result.CipherName = FirstOrder.CipherName;
            result.CipherPhone = FirstOrder.CipherPhone;
            result.Phone = FirstOrder.Phone;
            result.NickName = FirstOrder.BuyerNick;
            result.ExchangeType = 1;
            result.ExchangeTypeText = ServiceClass.GetExchangeTypeText(1);
            result.UpdateDate = FirstOrder.UpdateDate;
            result.CreateDate = FirstOrder.CreateDate;
            result.FinishDate = FirstOrder.FinishDate;
            return ResultData<TikTokInfoVo>.Success().AddData("orderData", result);
        }

        /// <summary>
        /// 补单
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost("AddOrder")]
        public async Task<ResultData> AddOrderAsync(TikTokOrderInfoAddVo addVo)
        {
            var order = dalTikTokOrderInfo.GetAll().SingleOrDefault(o => o.Id == addVo.Id);
            if (order != null)
            {
                throw new Exception("该订单已存在,请勿重复录入");
            }
            var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
            int employeeId = Convert.ToInt32(employee.Id);
            //如果通过解密获取了手机号
            if (!string.IsNullOrEmpty(addVo.Phone))
            {
                //添加订单
                List<TikTokOrderAddDto> amiyaOrderList = new List<TikTokOrderAddDto>();
                TikTokOrderAddDto addDto = new TikTokOrderAddDto();
                addDto.Id = addVo.Id;
                addDto.GoodsName = addVo.GoodsName;
                addDto.GoodsId = addVo.GoodsId;
                addDto.Phone = addVo.Phone;
                addDto.StatusCode = addVo.StatusCode;
                addDto.ActualPayment = addVo.ActualPayment;
                addDto.AccountReceivable = addVo.AccountReceivable;
                addDto.CreateDate = addVo.CreateDate;
                addDto.UpdateDate = addVo.UpdateDate;
                addDto.ThumbPicUrl = addVo.ThumbPicUrl;
                addDto.BuyerNick = addVo.NickName;
                addDto.AppType = (byte)AppType.Douyin;
                addDto.BuyerNick = addVo.NickName;
                addDto.IsAppointment = addVo.IsAppointment;
                addDto.BelongEmpId = employeeId;
                addDto.OrderType = (addVo.OrderType.HasValue) ? addVo.OrderType.Value : (byte)0;
                addDto.Quantity = (addVo.Quantity.HasValue) ? addVo.Quantity : 0;
                addDto.IntegrationQuantity = 0;
                addDto.ExchangeType = addVo.ExchangeType;
                addDto.CipherName = addVo.CipherName;
                addDto.BelongLiveAnchorId = addVo.BelongLiveAnchorId;
                addDto.CipherPhone = addVo.CipherPhone;
                //addDto.FinishDate = addVo.FinishDate;
                amiyaOrderList.Add(addDto);
                OrderTradeAddDto orderTradeAdd = new OrderTradeAddDto();
                orderTradeAdd.CustomerId = "客服-" + employee.Name.ToString();
                orderTradeAdd.CreateDate = DateTime.Now;
                orderTradeAdd.AddressId = 0;
                orderTradeAdd.Remark = addVo.Remark;
                orderTradeAdd.TikTokOrderInfoAddList = amiyaOrderList;
                orderTradeAdd.IsAdminAdd = true;
                await tikTokOrderService.AddAmiyaOrderAsync(orderTradeAdd);
            }
            else
            {
                //如果没有解密信息

                //添加tiktok用户信息
                TikTokUserInfo tikTokUserInfo = new TikTokUserInfo();
                tikTokUserInfo.CipherName = addVo.CipherName;
                tikTokUserInfo.CipherPhone = addVo.CipherPhone;
                tikTokUserInfo.Id = GuidUtil.NewGuidShortString();
                await dalTikTokUserInfo.AddAsync(tikTokUserInfo, true);

                //添加订单
                List<TikTokOrderAddDto> amiyaOrderList = new List<TikTokOrderAddDto>();
                TikTokOrderAddDto addDto = new TikTokOrderAddDto();
                addDto.Id = addVo.Id;
                addDto.GoodsName = addVo.GoodsName;
                addDto.GoodsId = addVo.GoodsId;
                addDto.Phone = addVo.Phone;
                addDto.StatusCode = addVo.StatusCode;
                addDto.ActualPayment = addVo.ActualPayment;
                addDto.AccountReceivable = addVo.AccountReceivable;
                addDto.CreateDate = addVo.CreateDate;
                addDto.UpdateDate = addVo.UpdateDate;
                addDto.ThumbPicUrl = addVo.ThumbPicUrl;
                addDto.BuyerNick = addVo.NickName;
                addDto.AppType = (byte)AppType.Douyin;
                addDto.BelongLiveAnchorId = addVo.BelongLiveAnchorId;
                addDto.BuyerNick = addVo.NickName;
                addDto.IsAppointment = addVo.IsAppointment;
                addDto.BelongEmpId = employeeId;
                addDto.OrderType = (addVo.OrderType.HasValue) ? addVo.OrderType.Value : (byte)0;
                addDto.Quantity = (addVo.Quantity.HasValue) ? addVo.Quantity : 0;
                addDto.IntegrationQuantity = 0;
                addDto.ExchangeType = addVo.ExchangeType;
                addDto.TikTokUserId = tikTokUserInfo.Id;
                addDto.CipherName = addVo.CipherName;
                addDto.CipherPhone = addVo.CipherPhone;
                addDto.UpdateDate = addVo.UpdateDate;
                //addDto.FinishDate = addVo.FinishDate;
                amiyaOrderList.Add(addDto);
                OrderTradeAddDto orderTradeAdd = new OrderTradeAddDto();
                orderTradeAdd.CustomerId = "客服-" + employee.Name.ToString();
                orderTradeAdd.CreateDate = DateTime.Now;
                orderTradeAdd.AddressId = 0;
                orderTradeAdd.Remark = addVo.Remark;
                orderTradeAdd.TikTokOrderInfoAddList = amiyaOrderList;
                orderTradeAdd.IsAdminAdd = true;
                await tikTokOrderService.AddAmiyaOrderAsync(orderTradeAdd);
            }
            return ResultData.Success();
        }
        //[HttpGet("test")]
        //public async Task Test() {
        //    List<TikTokOrder> tikTokOrderList = new List<TikTokOrder>();
        //    var douYinOrderResult = await syncTikTokOrder.TranslateTradesSoldChangedOrders(DateTime.Now.AddMinutes(-105), DateTime.Now, 1);
        //    tikTokOrderList.AddRange(douYinOrderResult);
        //    List<TikTokOrderAddDto> tikTokOrderAddList = new List<TikTokOrderAddDto>();
        //    //抖店订单
        //    foreach (var order in tikTokOrderList)
        //    {
        //        TikTokOrderAddDto tikTokOrder = new TikTokOrderAddDto();
        //        tikTokOrder.Id = order.Id;
        //        tikTokOrder.GoodsName = order.GoodsName;
        //        tikTokOrder.GoodsId = order.GoodsId;
        //        tikTokOrder.AppointmentHospital = order.AppointmentHospital;
        //        tikTokOrder.StatusCode = order.StatusCode;
        //        tikTokOrder.ActualPayment = order.ActualPayment;
        //        tikTokOrder.CreateDate = order.CreateDate;
        //        tikTokOrder.UpdateDate = order.UpdateDate;
        //        tikTokOrder.WriteOffDate = order.WriteOffDate;
        //        tikTokOrder.FinishDate = order.FinishDate;
        //        tikTokOrder.BelongLiveAnchorId = order.BelongLiveAnchorId;
        //        tikTokOrder.ThumbPicUrl = order.ThumbPicUrl;
        //        tikTokOrder.AppType = order.AppType;
        //        tikTokOrder.AccountReceivable = order.ActualPayment;
        //        tikTokOrder.IsAppointment = order.IsAppointment;
        //        tikTokOrder.OrderType = order.OrderType;
        //        tikTokOrder.Quantity = order.Quantity;
        //        tikTokOrder.ExchangeType = (byte)ExchangeType.ThirdPartyPayment;
        //        tikTokOrder.TikTokUserId = order.TikTokUserId;
        //        tikTokOrder.CipherPhone = order.CipherPhone;
        //        tikTokOrder.CipherName = order.CipherName;
        //        tikTokOrderAddList.Add(tikTokOrder);
        //    }
        //    await tikTokOrderInfoService.AddAsync(tikTokOrderAddList);
        //}

    }

}


