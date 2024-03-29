﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aliyun.Acs.Core;
using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Response;
using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Infrastructure;
using Fx.Amiya.Core.Interfaces.Goods;
using Fx.Amiya.Core.Interfaces.GoodsHospitalPrice;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.BindCustomerService;
using Fx.Amiya.Dto.ConsumptionVoucher;
using Fx.Amiya.Dto.HuiShouQianPay;
using Fx.Amiya.Dto.Order;
using Fx.Amiya.Dto.OrderAppInfo;
using Fx.Amiya.Dto.OrderRefund;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.Order;
using Fx.Amiya.MiniProgram.Api.Vo.TmallOrder;
using Fx.Amiya.Service;
using Fx.Common;
using Fx.Common.Utils;
using Fx.Infrastructure.DataAccess;
using Fx.Infrastructure.Utils;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    /// <summary>
    /// 订单接口
    /// </summary>
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]

    public class OrderController : ControllerBase
    {
        private IOrderService orderService;
        private IOrderHistoryService orderHistoryService;
        private TokenReader tokenReader;
        private IBindCustomerServiceService _bindCustomerService;
        private IMiniSessionStorage sessionStorage;
        private IGoodsInfo goodsInfoService;
        private IHospitalInfoService _hospitalInfoService;
        private ICustomerService customerService;
        private IDalBindCustomerService _dalBindCustomerService;
        private Domain.IRepository.IWxMiniUserRepository _wxMiniUserRepository;
        private IIntegrationAccount integrationAccountService;
        private IAliPayService _aliPayService;
        private ICustomerIntegralOrderRefundService _customerIntegralOrderRefundService;
        private IMemberCard memberCardService;
        private IMemberRankInfo memberRankInfoService;
        private readonly ITaskService taskService;
        private readonly IBalanceAccountService balanceAccountService;
        private readonly IBalanceService balanceService;
        private readonly ICustomerConsumptionVoucherService customerConsumptionVoucherService;
        private readonly IGoodsHospitalsPrice goodsHospitalsPrice;
        private readonly IMemberCardHandleService memberCardHandleService;
        private readonly IOrderRefundService orderRefundService;
        private readonly IUserService userService;
        private readonly IHuiShouQianPaymentService huiShouQianPaymentService;
        private readonly IGoodsStandardsPriceService goodsStandardsPriceService;
        private readonly IUnitOfWork unitOfWork;



        private static readonly AsyncLock _mutex = new AsyncLock();
        public OrderController(IOrderService orderService,
            IOrderHistoryService orderHistoryService,
            TokenReader tokenReader,
            IDalBindCustomerService dalBindCustomerService,
            IMiniSessionStorage sessionStorage,
            IGoodsInfo goodsInfoService,
            IUserService userService,
            IBindCustomerServiceService bindCustomerServiceService,
            ICustomerService customerService,
            IHospitalInfoService hospitalInfoService,
            IAliPayService aliPayService,
            Domain.IRepository.IWxMiniUserRepository wxMiniUserRepository,
            IIntegrationAccount integrationAccountService,
            ICustomerIntegralOrderRefundService customerIntegralOrderRefundService, IMemberCard memberCardService, IMemberRankInfo memberRankInfoService, ITaskService taskService, IBalanceAccountService balanceAccountService, IBalanceService balanceService, IUnitOfWork unitOfWork, ICustomerConsumptionVoucherService customerConsumptionVoucherService, IGoodsHospitalsPrice goodsHospitalsPrice, IMemberCardHandleService memberCardHandleService, IOrderRefundService orderRefundService, IHuiShouQianPaymentService huiShouQianPaymentService, IGoodsStandardsPriceService goodsStandardsPriceService)
        {
            this.orderHistoryService = orderHistoryService;
            this.orderService = orderService;
            this.tokenReader = tokenReader;
            this.sessionStorage = sessionStorage;
            this.goodsInfoService = goodsInfoService;
            this.customerService = customerService;
            this.integrationAccountService = integrationAccountService;
            _wxMiniUserRepository = wxMiniUserRepository;
            _dalBindCustomerService = dalBindCustomerService;
            _hospitalInfoService = hospitalInfoService;
            _aliPayService = aliPayService;
            _customerIntegralOrderRefundService = customerIntegralOrderRefundService;
            _bindCustomerService = bindCustomerServiceService;
            this.memberCardService = memberCardService;
            this.memberRankInfoService = memberRankInfoService;
            this.taskService = taskService;
            this.balanceAccountService = balanceAccountService;
            this.balanceService = balanceService;
            this.unitOfWork = unitOfWork;
            this.customerConsumptionVoucherService = customerConsumptionVoucherService;
            this.goodsHospitalsPrice = goodsHospitalsPrice;
            this.memberCardHandleService = memberCardHandleService;
            this.orderRefundService = orderRefundService;
            this.userService = userService;
            this.huiShouQianPaymentService = huiShouQianPaymentService;
            this.goodsStandardsPriceService = goodsStandardsPriceService;
        }


        /// <summary>
        /// 获取未领取礼品的订单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("unReceiveGiftOrderList")]
        public async Task<ResultData<List<TmallOrderSimpleVo>>> GetUnReceiveGiftOrderListByCustomerIdAsync()
        {
            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;

            var order = from d in await orderService.GetUnReceiveGiftOrderListByCustomerIdAsync(customerId)
                        select new TmallOrderSimpleVo
                        {
                            OrderId = d.Id,
                            GoodsName = d.GoodsName,
                            ThumbPicUrl = d.ThumbPicUrl
                        };
            return ResultData<List<TmallOrderSimpleVo>>.Success().AddData("order", order.ToList());
        }

        /// <summary>
        /// 根据订单编号获取订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet("getOrderInfoById")]
        public async Task<ResultData<OrderInfoMiniProgramDetailVo>> getOrderInfoById(string orderId)
        {
            OrderInfoMiniProgramDetailVo orderInfoResult = new OrderInfoMiniProgramDetailVo();
            var orderInfo = await orderService.GetByIdAsync(orderId);
            orderInfoResult.OrderId = orderInfo.Id;
            orderInfoResult.StatusCode = orderInfo.StatusCode;
            orderInfoResult.StatusText = orderInfo.StatusText;
            orderInfoResult.CreateDate = orderInfo.CreateDate.Value.ToString("yyyy-MM-dd hh:mm:ss");
            orderInfoResult.ThumbPicUrl = orderInfo.ThumbPicUrl;
            orderInfoResult.GoodsName = orderInfo.GoodsName;
            orderInfoResult.OrderType = (orderInfo.OrderType.HasValue) ? Convert.ToInt16(orderInfo.OrderType.Value) : 0;
            orderInfoResult.appType = orderInfo.AppType;
            orderInfoResult.AppointmentCity = orderInfo.AppointmentCity;
            orderInfoResult.ExchangeType = orderInfo.ExchangeType ?? 10;
            if (orderInfo.AppointmentDate.HasValue)
            {
                orderInfoResult.AppointmentDate = orderInfo.AppointmentDate.Value.ToString("yyyy-MM-dd");
            }

            if (orderInfo.OrderType == 0 && orderInfo.ExchangeType != 0)
            {
                if (orderInfo.Quantity.HasValue)
                {
                    if (orderInfo.Quantity.Value > 0)
                    {
                        orderInfoResult.SinglePrice = orderInfo.ActualPayment / orderInfo.Quantity;
                    }
                    else
                    {
                        orderInfoResult.SinglePrice = orderInfo.ActualPayment;
                    }

                }
                else
                {
                    orderInfoResult.SinglePrice = orderInfo.ActualPayment;
                }
                var hospitalInfo = await _hospitalInfoService.GetBaseByNameAsync(orderInfo.AppointmentHospital);
                if (hospitalInfo != null)
                { orderInfoResult.HospitalAddress = hospitalInfo.Address; }
                orderInfoResult.AppointmentHospital = orderInfo.AppointmentHospital;
                orderInfoResult.ActualPayment = orderInfo.ActualPayment;
                orderInfoResult.WriteOffCode = orderInfo.WriteOffCode;
            }
            else
            {
                if (orderInfo.ExchangeType != (byte)ExchangeType.Integration)
                {
                    if (orderInfo.Quantity.HasValue)
                    {
                        orderInfoResult.SinglePrice = orderInfo.ActualPayment / orderInfo.Quantity;
                    }
                    else
                    {
                        orderInfoResult.SinglePrice = orderInfo.ActualPayment;
                    }
                    orderInfoResult.ActualPayment = orderInfo.ActualPayment;
                    if (orderInfo.ExchangeType == (byte)ExchangeType.PointAndMoney)
                    {
                        orderInfoResult.IntegrationQuantity = orderInfo.IntegrationQuantity;
                    }

                }
                else
                {
                    if (orderInfo.Quantity.HasValue)
                    {
                        orderInfoResult.SingleIntegrationQuantity = orderInfo.IntegrationQuantity / orderInfo.Quantity;
                    }
                    else
                    {
                        orderInfoResult.SingleIntegrationQuantity = orderInfo.IntegrationQuantity;
                    }

                    RefundOrderInfo refundOrderInfo = new RefundOrderInfo();
                    var refundOrderInfoResult = await _customerIntegralOrderRefundService.GetByOrderIdAsync(orderId);
                    refundOrderInfo.CheckTypeText = refundOrderInfoResult.CheckStateText;
                    refundOrderInfo.CheckReason = refundOrderInfoResult.CheckReason;
                    refundOrderInfo.RefundReason = refundOrderInfoResult.RefundReasong;
                    orderInfoResult.RefundOrderInfo = refundOrderInfo;
                    orderInfoResult.IntegrationQuantity = orderInfo.IntegrationQuantity;
                    if (orderInfo.OrderType == (byte)OrderType.VirtualOrder)
                    {
                        var hospitalInfo = await _hospitalInfoService.GetBaseByNameAsync(orderInfo.AppointmentHospital);
                        if (hospitalInfo != null)
                        { orderInfoResult.HospitalAddress = hospitalInfo.Address; }
                        orderInfoResult.AppointmentHospital = orderInfo.AppointmentHospital;
                        orderInfoResult.WriteOffCode = orderInfo.WriteOffCode;
                    }
                }
            }
            if (orderInfo.StatusCode == OrderStatusCode.CHECK_FAIL)
            {
                RefundOrderInfo refundOrderInfo = new RefundOrderInfo();
                var refundOrderInfoResult = await orderRefundService.GetOrderRefundByOrderId(orderId);
                refundOrderInfo.CheckTypeText = refundOrderInfoResult.CheckStateText;
                refundOrderInfo.CheckReason = refundOrderInfoResult.UncheckReason;
                refundOrderInfo.RefundReason = refundOrderInfoResult.Remark;
                orderInfoResult.RefundOrderInfo = refundOrderInfo;
            }
            orderInfoResult.Quantity = (orderInfo.Quantity.HasValue) ? orderInfo.Quantity.Value : 0;
            orderInfoResult.BuyerNick = orderInfo.BuyerNick;
            orderInfoResult.DeductMoney = orderInfo.DeductMoney;
            return ResultData<OrderInfoMiniProgramDetailVo>.Success().AddData("orderDetailResult", orderInfoResult);
        }

        /// <summary>
        /// 根据核销id画二维码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("qrcodeImage/{id}")]
        public async Task<IActionResult> GetQrCodeImage(int id)
        {
            var writeOffData = new { writeOffCode = id };
            string content = JsonConvert.SerializeObject(writeOffData);
            string encryptConent = new DesHelper("test1234").EncryptToBase64String(content);
            var imageBytes = await ImageUtil.ImageToBytesAsync(await QrCodeUtil.GetQrCodeAsync(content));
            return File(imageBytes, "image/jpeg");
        }

        /// <summary>
        /// 根据核销id画二维码（Base64）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("qrcodeBase64/{id}")]
        public async Task<ResultData<string>> GetQrCodeBase64(int id)
        {
            try
            {
                var writeOffData = new { writeOffCode = id };
                string content = JsonConvert.SerializeObject(writeOffData);
                string encryptConent = new DesHelper("test1234").EncryptToBase64String(content);
                var imageBytes = await ImageUtil.ImageToBytesAsync(await QrCodeUtil.GetQrCodeAsync(encryptConent));
                if (imageBytes != null)
                {
                    return ResultData<string>.Success().AddData("qrCodeBase64", Convert.ToBase64String(imageBytes));
                }
                else
                {
                    return ResultData<string>.Fail("核销二维码获取失败");
                }
            }
            catch (Exception ex)
            {
                return ResultData<string>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 核销好礼接口
        /// </summary>
        /// <returns></returns>
        [HttpGet("ReceiveGiftOrderList")]
        public async Task<ResultData<FxPageInfo<WriteOffOrderVo>>> GetReceiveGiftOrderListByCustomerIdAsync([Required] int pageNum, [Required] int pageSize)
        {
            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            var q = await orderService.GetReceiveGiftOrderListByCustomerIdAsync(customerId, pageNum, pageSize);
            var order = from d in q.List
                        select new WriteOffOrderVo
                        {
                            OrderId = d.Id,
                            GoodsName = d.GoodsName,
                            ThumbPicUrl = d.ThumbPicUrl,
                            AppType = d.appType,
                            AppointmentHospital = d.AppointmentHospital
                        };
            FxPageInfo<WriteOffOrderVo> orderWriteOffInfo = new FxPageInfo<WriteOffOrderVo>();
            orderWriteOffInfo.TotalCount = q.TotalCount;
            orderWriteOffInfo.List = order;
            orderWriteOffInfo.PageSize = pageSize;
            orderWriteOffInfo.PageCount = order.Count();
            orderWriteOffInfo.CurrentPageIndex = pageNum;
            return ResultData<FxPageInfo<WriteOffOrderVo>>.Success().AddData("orders", orderWriteOffInfo);
        }

        /// <summary>
        /// 获取已购买订单
        /// </summary>
        /// <param name="ExchangeType">交易方式:0：积分订单，1：其他订单</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("getAlreadyBuyOrderList")]
        public async Task<ResultData<FxPageInfo<TmallOrderSimpleVo>>> GetAlreadyBuyOrderListAsync([Required] int ExchangeType, [Required] int pageNum, [Required] int pageSize)
        {
            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            var q = await orderService.GetAlreadyBuyOrderListAsync(customerId, ExchangeType, pageNum, pageSize);
            var order = from d in q.List
                        select new TmallOrderSimpleVo
                        {
                            OrderId = d.Id,
                            GoodsName = d.GoodsName,
                            ThumbPicUrl = d.ThumbPicUrl,
                            AppointmentHospital = d.AppointmentHospital,
                            CreateDate = d.CreateDate.ToString("yyyy-MM-dd hh:mm:ss"),
                            IntegrationQuantity = (d.IntegrationQuantity.HasValue) ? d.IntegrationQuantity : 0,
                            Quantity = d.Quantity,
                            SinglePrice = (d.SinglePrice.HasValue) ? d.SinglePrice : 0,
                            ActualPayment = (d.ActualPayment.HasValue) ? d.ActualPayment : 0,
                            SingleIntegrationQuantity = (d.SingleIntegrationQuantity.HasValue) ? d.SingleIntegrationQuantity : 0,
                            GoodsCategory = d.GoodsCategory,
                            StatusCode = d.StatusCode,
                            StatusCodeInfo = d.StatusCodeInfo,
                            appType = d.appType,
                            TradeId = d.TradeId
                        };
            FxPageInfo<TmallOrderSimpleVo> orderResultInfo = new FxPageInfo<TmallOrderSimpleVo>();
            orderResultInfo.TotalCount = q.TotalCount;
            orderResultInfo.List = order;
            orderResultInfo.PageSize = pageSize;
            orderResultInfo.PageCount = order.Count();
            orderResultInfo.CurrentPageIndex = pageNum;
            return ResultData<FxPageInfo<TmallOrderSimpleVo>>.Success().AddData("orders", orderResultInfo);
        }


        /// <summary>
        /// 获取已购买订单历史数据
        /// </summary>
        /// <param name="ExchangeType">交易方式:0：积分订单，1：其他订单</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("getAlreadyBuyOrderListHistory")]
        public async Task<ResultData<FxPageInfo<TmallOrderSimpleVo>>> GetAlreadyBuyOrderListHistoryAsync([Required] int ExchangeType, [Required] int pageNum, [Required] int pageSize)
        {
            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            var q = await orderHistoryService.GetAlreadyBuyOrderListAsync(customerId, ExchangeType, pageNum, pageSize);
            var order = from d in q.List
                        select new TmallOrderSimpleVo
                        {
                            OrderId = d.Id,
                            GoodsName = d.GoodsName,
                            ThumbPicUrl = d.ThumbPicUrl,
                            AppointmentHospital = d.AppointmentHospital,
                            CreateDate = d.CreateDate.ToString("yyyy-MM-dd hh:mm:ss"),
                            IntegrationQuantity = (d.IntegrationQuantity.HasValue) ? d.IntegrationQuantity : 0,
                            Quantity = d.Quantity,
                            SinglePrice = (d.SinglePrice.HasValue) ? d.SinglePrice : 0,
                            ActualPayment = (d.ActualPayment.HasValue) ? d.ActualPayment : 0,
                            SingleIntegrationQuantity = (d.SingleIntegrationQuantity.HasValue) ? d.SingleIntegrationQuantity : 0,
                            GoodsCategory = d.GoodsCategory,
                            StatusCode = d.StatusCode,
                            StatusCodeInfo = d.StatusCodeInfo,
                            appType = d.appType,
                            TradeId = d.TradeId
                        };
            FxPageInfo<TmallOrderSimpleVo> orderResultInfo = new FxPageInfo<TmallOrderSimpleVo>();
            orderResultInfo.TotalCount = q.TotalCount;
            orderResultInfo.List = order;
            orderResultInfo.PageSize = pageSize;
            orderResultInfo.PageCount = order.Count();
            orderResultInfo.CurrentPageIndex = pageNum;
            return ResultData<FxPageInfo<TmallOrderSimpleVo>>.Success().AddData("orders", orderResultInfo);
        }



        /// <summary>
        /// 生成订单
        /// </summary>
        /// <returns>交易编号</returns>
        [HttpPost]
        public async Task<ResultData<OrderAddResultVo>> AddOrderAsync(OrderAddVo orderAdd)
        {
            if (orderAdd.ExchangeType != 0 && orderAdd.ExchangeType != 4 && orderAdd.ExchangeType != 2)
            {
                throw new Exception("不支持的支付方式");
            }
            var token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            string appId = sessionInfo.AppId;
            string userId = sessionInfo.FxUserId;
            //积分余额
            decimal integrationBalance = await integrationAccountService.GetIntegrationBalanceByCustomerIDAsync(customerId);
            var customerInfo = await customerService.GetByIdAsync(customerId);
            if (customerInfo == null) throw new Exception("下单前请先绑定手机号");
            string phone = await customerService.GetPhoneByCustomerIdAsync(customerId);
            var miniUserInfo = await _wxMiniUserRepository.GetByUserIdAsync(customerInfo.UserId);
            string OpenId = miniUserInfo.OpenId;
            DateTime date = DateTime.Now;
            //订单中是否存在金额支付
            bool IsExistThirdPartPay = false;
            //是否存在余额支付订单
            bool IsExistBalancePay = false;
            //是否使用专用商品抵用券(默认没有使用)
            bool IsUseSpecifyVoucher = false;
            List<OrderInfoAddDto> amiyaOrderList = new List<OrderInfoAddDto>();
            Dictionary<string, int> inventoryQuantityDict = new Dictionary<string, int>();
            CustomerConsumptioVoucherInfoDto voucher = null;
            if (!string.IsNullOrEmpty(orderAdd.VoucherId) && orderAdd.VoucherId != "0")
            {
                voucher = await customerConsumptionVoucherService.GetVoucherByCustomerIdAndVoucherIdAsync(customerId, orderAdd.VoucherId);
                if (voucher == null) throw new Exception("没有此抵用券信息");
                if (voucher.IsUsed) throw new Exception("该抵用券已被使用");
            }

            //获取用户绑定的主播id
            var belongLiveAnchorId = await userService.BindUserBelongAppIdAsync(userId, customerId);

            //商品下单
            foreach (var item in orderAdd.OrderItemList)
            {
                if (item.Quantity <= 0) throw new Exception("下单数量错误");

                if (item.IsSkinCare)
                {
                    var orderExist = await orderService.IsExistMFCard(customerId);
                    if (orderExist)
                    {
                        throw new Exception("亲,每人仅限购买1张哦～推荐给你的好友吧");
                    }
                }
                var goodsInfo = await goodsInfoService.GetByIdAsync(item.GoodsId);
                var isOverLimitCount = await orderService.IsOverLimitOrderAsync(goodsInfo.Id, customerId, item.Quantity);
                if (isOverLimitCount)
                {
                    throw new Exception("已超出商品限购数量！");
                }
                if (goodsInfo.ExchangeType != ExchangeType.Integration && goodsInfo.ExchangeType != ExchangeType.ThirdPartyPayment) throw new Exception("付款方式错误");
                OrderInfoAddDto amiyaOrder = new OrderInfoAddDto();
                if (goodsInfo.ExchangeType == ExchangeType.ThirdPartyPayment)
                {
                    if (orderAdd.ExchangeType != 4 && orderAdd.ExchangeType != 2) throw new Exception("付款方式错误");
                    IsExistThirdPartPay = true;
                    if (orderAdd.ExchangeType == 4)
                    {
                        amiyaOrder.ExchangeType = (int)ExchangeType.HuiShouQian;
                    }
                    else if (orderAdd.ExchangeType == 2)
                    {
                        amiyaOrder.ExchangeType = (int)ExchangeType.Wechat;
                    }
                }
                //积分商品计算所选规格价
                if (goodsInfo.ExchangeType == ExchangeType.Integration)
                {
                    if (orderAdd.ExchangeType != 0) throw new Exception("付款方式错误");
                    var standard = await goodsStandardsPriceService.GetByGoodsId(item.GoodsId);
                    var find = standard.Find(e => e.Id == item.SelectStandard);
                    if (find == null) throw new Exception("规格错误");
                    amiyaOrder.IntegrationQuantity = find.Price * item.Quantity;
                    amiyaOrder.ExchangeType = (int)ExchangeType.Integration;

                }
                if (orderAdd.ExchangeType == (int)ExchangeType.BalancePay)
                {
                    IsExistBalancePay = true;
                }
                if (goodsInfo.IsMaterial == true)
                {
                    if (goodsInfo.IsMaterial && orderAdd.AddressId == null)
                        throw new Exception("收货地址不能为空");
                }
                else
                {
                    //获取虚拟商品和美肤券预约门店名称
                    if (goodsInfo.ExchangeType != ExchangeType.Integration && !item.IsFaceCard && !item.IsSkinCare)
                    {
                        if (item.HospitalId.Value == 0)
                        {
                            throw new Exception("请选择门店医院");
                        }
                        var hospitalInfo = await _hospitalInfoService.GetByIdAsync(item.HospitalId.Value);
                        amiyaOrder.AppointmentHospital = hospitalInfo.Name;
                    }
                    amiyaOrder.Description = goodsInfo.Description;
                    amiyaOrder.Standard = goodsInfo.Standard;
                    amiyaOrder.Part = "";
                }
                if (goodsInfo.InventoryQuantity < item.Quantity)
                    throw new Exception("库存不足");
                amiyaOrder.Id = CreateOrderIdHelper.GetNextNumber();
                amiyaOrder.GoodsId = item.GoodsId;
                amiyaOrder.GoodsName = goodsInfo.Name;
                amiyaOrder.StatusCode = OrderStatusCode.WAIT_BUYER_PAY;
                if (goodsInfo.InventoryQuantity != null)
                    inventoryQuantityDict.Add(item.GoodsId, item.Quantity);
                amiyaOrder.Quantity = item.Quantity;
                //美肤卡和面诊卡使用前端传递的昵称
                if (item.IsSkinCare || item.IsFaceCard)
                {
                    amiyaOrder.BuyerNick = orderAdd.NickName;
                }
                else
                {
                    amiyaOrder.BuyerNick = customerInfo.NickName;
                }
                /*amiyaOrder.BuyerNick = customerInfo.NickName;*/
                amiyaOrder.CreateDate = date;
                amiyaOrder.UpdateDate = date;
                amiyaOrder.ThumbPicUrl = goodsInfo.ThumbPicUrl;
                amiyaOrder.AppType = (byte)AppType.MiniProgram;
                amiyaOrder.OrderType = goodsInfo.IsMaterial == true ? (byte)OrderType.MaterialOrder : (byte)OrderType.VirtualOrder;

                //从数据库查询商品价格
                if (goodsInfo.IsMaterial)
                {
                    //判断是否包含会员价
                    if (goodsInfo.GoodsMemberRankPrice.Count > 0)
                    {
                        var member = await memberCardHandleService.GetMemberCardByCustomeridAsync(customerId);
                        var memberPrice = goodsInfo.GoodsMemberRankPrice.Find(p => p.MemberRankId == member.MemberRankId);
                        if (memberPrice != null)
                        {
                            amiyaOrder.ActualPayment = memberPrice.Price * item.Quantity;
                        }
                        else
                        {
                            var standard = await goodsStandardsPriceService.GetByGoodsId(item.GoodsId);
                            var find = standard.Find(e => e.Id == item.SelectStandard);
                            if (find == null) throw new Exception("规格错误");
                            amiyaOrder.ActualPayment = find.Price * item.Quantity;
                            amiyaOrder.Standard = find.Standards;
                        }
                    }
                    else
                    {
                        //计算规格
                        var standard = await goodsStandardsPriceService.GetByGoodsId(item.GoodsId);
                        var find = standard.Find(e => e.Id == item.SelectStandard);
                        if (find == null) throw new Exception("规格错误");
                        amiyaOrder.ActualPayment = find.Price * item.Quantity;
                        amiyaOrder.Standard = find.Standards;
                    }
                }
                else
                {
                    if (item.IsFaceCard || item.IsSkinCare)
                    {
                        //面诊卡或美肤券
                        amiyaOrder.ActualPayment = goodsInfo.SalePrice * item.Quantity;
                    }
                    else
                    {
                        //其他虚拟商品
                        var hospitalPrice = await goodsHospitalsPrice.GetByGoodsIdAndHospitalId(goodsInfo.Id, item.HospitalId.Value);
                        if (hospitalPrice == null)
                        {
                            amiyaOrder.ActualPayment = goodsInfo.SalePrice * item.Quantity;
                        }
                        else
                        {
                            amiyaOrder.ActualPayment = hospitalPrice.Price * item.Quantity;
                        }
                    }
                }
                if (IsExistThirdPartPay)
                {
                    // 只有当抵用券为指定商品可用时才计算价格,全局商品抵用券在添加订单后再计算支付价格
                    if (voucher != null && voucher.IsSpecifyProduct)
                    {
                        if (goodsInfo.GoodsConsumptionVoucher.Exists(e => e.ConsumptionVoucherId == voucher.ConsumptionVoucherId))
                        {
                            IsUseSpecifyVoucher = true;
                            amiyaOrder.IsUseCoupon = true;
                            amiyaOrder.CouponId = voucher.Id;
                            //指定商品价格抵用券计算方式:(原价*数量)*折扣||(原价*数量)-折扣
                            if (voucher.Type == (int)ConsumptionVoucherType.Discount)
                            {
                                var payCount = amiyaOrder.ActualPayment;
                                amiyaOrder.ActualPayment = Math.Ceiling((amiyaOrder.ActualPayment.Value) * (voucher.DeductMoney));
                                amiyaOrder.DeductMoney = payCount.Value - amiyaOrder.ActualPayment.Value;
                            }
                            else
                            {
                                amiyaOrder.DeductMoney = voucher.DeductMoney;
                                amiyaOrder.ActualPayment = amiyaOrder.ActualPayment - voucher.DeductMoney;
                            }
                        }

                    }
                    //抵用券抵扣后付款小于0,赋值为0.01
                    if (amiyaOrder.ActualPayment <= 0)
                    {
                        amiyaOrder.ActualPayment = 0.01m;
                    }
                }
                if (orderAdd.ExchangeType == (int)ExchangeType.BalancePay)
                {
                    //余额支付
                    amiyaOrder.ExchangeType = (byte)ExchangeType.BalancePay;
                }

                if (item.IsFaceCard || item.IsSkinCare)
                {
                    amiyaOrder.Phone = orderAdd.Phone;
                    amiyaOrder.TradeId = orderAdd.Phone;
                }
                else
                {
                    amiyaOrder.Phone = phone;
                    amiyaOrder.TradeId = phone;
                }
                int bindCustomerId;
                if (item.IsFaceCard || item.IsSkinCare)
                {
                    bindCustomerId = await _bindCustomerService.GetEmployeeIdByPhone(orderAdd.Phone);
                }
                else
                {
                    bindCustomerId = await _bindCustomerService.GetEmployeeIdByPhone(phone);
                }
                //美肤卡添加预约时间和预约城市
                if (item.IsSkinCare)
                {
                    amiyaOrder.AppointmentCity = item.AppointmentCity;
                    amiyaOrder.AppointmentDate = item.AppointmentDate;
                }
                if (bindCustomerId == 0)
                {
                    AddBindCustomerServiceDto addBindCustomerServiceDto = new AddBindCustomerServiceDto();
                    addBindCustomerServiceDto.CustomerServiceId = 188;
                    var orderIdList = await orderService.GetOrderIdListByPhone(amiyaOrder.Phone);
                    UpdateBelongEmpInfoOrderDto updateOrderBelongEmpIdDto = new UpdateBelongEmpInfoOrderDto();
                    updateOrderBelongEmpIdDto.OrderId = orderIdList;
                    updateOrderBelongEmpIdDto.BelongEmpId = addBindCustomerServiceDto.CustomerServiceId;
                    //修改订单归属客服
                    await orderService.UpdateOrderBelongEmpIdAsync(updateOrderBelongEmpIdDto);
                    addBindCustomerServiceDto.OrderIdList = orderIdList;
                    //添加客服绑定关系
                    await _bindCustomerService.AddAsync(addBindCustomerServiceDto, 1);
                    bindCustomerId = 188;
                }
                amiyaOrder.BelongEmpId = bindCustomerId;
                if (belongLiveAnchorId.HasValue)
                {
                    amiyaOrder.LiveAnchorId = belongLiveAnchorId.HasValue ? belongLiveAnchorId.Value : 0;
                }
                amiyaOrderList.Add(amiyaOrder);
            }
            if (amiyaOrderList.Sum(e => e.IntegrationQuantity) > integrationBalance)
                throw new Exception("积分余额不足");
            if (orderAdd.ExchangeType == (int)ExchangeType.BalancePay)
            {
                var balance = await balanceAccountService.GetAccountInfoAsync(customerId);
                if (balance == null || amiyaOrderList.Sum(e => e.ActualPayment.Value) > balance.Balance)
                    throw new Exception("余额不足");
            }
            //减库存
            foreach (KeyValuePair<string, int> item in inventoryQuantityDict)
            {
                await goodsInfoService.ReductionGoodsInventoryQuantityAsync(item.Key, item.Value);
            }
            OrderTradeAddDto orderTradeAdd = new OrderTradeAddDto();
            orderTradeAdd.CustomerId = customerId;
            orderTradeAdd.CreateDate = date;
            orderTradeAdd.AddressId = orderAdd.AddressId;
            orderTradeAdd.Remark = orderAdd.Remark;
            orderTradeAdd.OrderInfoAddList = amiyaOrderList;
            if (IsExistThirdPartPay == true && !IsExistBalancePay)
            {
                //将全局抵用券添加传递给订单计算交易支付金额
                if (voucher != null && !voucher.IsSpecifyProduct)
                {
                    orderTradeAdd.VoucherId = orderAdd.VoucherId;
                }
            }
            string tradeId = await orderService.AddAmiyaOrderAsync(orderTradeAdd);
            OrderAddResultVo orderAddResult = new OrderAddResultVo();
            orderAddResult.TradeId = tradeId;
            if (IsExistThirdPartPay == true && !IsExistBalancePay)
            {
                //三方支付
                string orderId = "";
                string goodsName = "";
                decimal totalFee = 0M;
                foreach (var x in amiyaOrderList)
                {
                    orderId += x.Id + ",";
                    totalFee += x.ActualPayment.Value;
                    goodsName += x.GoodsName + ",";
                }
                if (totalFee < 0) throw new Exception("支付金额异常");
                orderId = orderId.Trim(',');
                goodsName = goodsName.Trim(',');


                //修改抵用券使用状态
                if (voucher != null)
                {
                    if ((voucher.IsSpecifyProduct && IsUseSpecifyVoucher) || !voucher.IsSpecifyProduct)
                    {
                        UpdateCustomerConsumptionVoucherDto update = new UpdateCustomerConsumptionVoucherDto
                        {
                            CustomerVoucherId = orderAdd.VoucherId,
                            IsUsed = true,
                            UseDate = DateTime.Now
                        };
                        await customerConsumptionVoucherService.UpdateCustomerConsumptionVoucherUseStatusAsync(update);
                    }
                }

                //微信支付
                if (orderAdd.ExchangeType == 2)
                {
                    WxPackageInfo packageInfo = new WxPackageInfo();
                    packageInfo.AppId = appId;
                    packageInfo.Body = orderId;
                    //回调地址需重新设置(todo;)                   
                    packageInfo.NotifyUrl = string.Format("{0}/amiya/wxmini/Notify/orderpayresult", "https://app.ameiyes.com/amiyamini");
                    //packageInfo.NotifyUrl = string.Format("{0}/amiya/wxmini/Notify/orderpayresult", "http://ymjxui.gnway.cc");
                    packageInfo.OutTradeNo = tradeId;
                    packageInfo.Attach = tradeId;
                    packageInfo.TotalFee = (int)(totalFee * 100m);
                    if (packageInfo.TotalFee < 1m)
                    {
                        packageInfo.TotalFee = 1m;
                    }
                    //支付人
                    packageInfo.OpenId = OpenId;
                    string CheckValue = "";
                    //验证参数
                    if (orderService.CheckVxSetParams(out CheckValue))
                    {
                        if (!orderService.CheckVxPackage(packageInfo, out CheckValue))
                        {
                            throw new Exception(CheckValue.ToString());
                        }
                        var payRequest = await orderService.BuildPayRequest(packageInfo);
                        PayRequestInfoVo payRequestInfo = new PayRequestInfoVo();
                        payRequestInfo.appId = payRequest.appId;
                        payRequestInfo.package = payRequest.package;
                        payRequestInfo.timeStamp = payRequest.timeStamp;
                        payRequestInfo.nonceStr = payRequest.nonceStr;
                        payRequestInfo.paySign = payRequest.paySign;
                        orderAddResult.PayRequestInfo = payRequestInfo;
                    }
                    //交易信息添加支付交易订单号
                    await orderService.TradeAddTransNoAsync(tradeId, tradeId);
                }
                else if (orderAdd.ExchangeType == 1)
                {
                    #region 支付宝支付
                    SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
                    AliPayConfig Config = new AliPayConfig();
                    sParaTemp.Add("service", Config.service);
                    sParaTemp.Add("partner", Config.seller_id);
                    sParaTemp.Add("seller_id", Config.seller_id);
                    sParaTemp.Add("_input_charset", Config.input_charset.ToLower());
                    sParaTemp.Add("payment_type", Config.payment_type);
                    sParaTemp.Add("notify_url", Config.notify_url);
                    sParaTemp.Add("return_url", Config.return_url);
                    sParaTemp.Add("anti_phishing_key", Config.anti_phishing_key);
                    sParaTemp.Add("exter_invoke_ip", Config.exter_invoke_ip);
                    sParaTemp.Add("out_trade_no", tradeId);
                    sParaTemp.Add("subject", orderId);
                    sParaTemp.Add("total_fee", totalFee.ToString("0.00"));
                    sParaTemp.Add("body", goodsName);
                    var res = _aliPayService.BuildRequest(sParaTemp);
                    orderAddResult.AlipayUrl = res.Result;
                    #endregion
                }
                else if (orderAdd.ExchangeType == 4)
                {
                    #region 慧收钱支付
                    HuiShouQianPayRequestInfo huiShouQianPayRequestInfo = new HuiShouQianPayRequestInfo();
                    huiShouQianPayRequestInfo.TransNo = Guid.NewGuid().ToString().Replace("-", "");
                    huiShouQianPayRequestInfo.PayType = "WECHAT_APPLET";
                    huiShouQianPayRequestInfo.OrderAmt = (totalFee * 100m).ToString().Split(".")[0];
                    huiShouQianPayRequestInfo.GoodsInfo = "商品付款";
                    huiShouQianPayRequestInfo.RequestDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                    huiShouQianPayRequestInfo.Extend = tradeId;
                    var result = await huiShouQianPaymentService.CreateHuiShouQianOrder(huiShouQianPayRequestInfo, OpenId, customerId);
                    if (result.Success == false) throw new Exception("下单失败,请重新下单");

                    //交易信息添加支付交易订单号
                    await orderService.TradeAddTransNoAsync(tradeId, huiShouQianPayRequestInfo.TransNo);

                    PayRequestInfoVo payRequestInfo = new PayRequestInfoVo();
                    payRequestInfo.appId = result.PayParam.AppId;
                    payRequestInfo.package = result.PayParam.Package;
                    payRequestInfo.timeStamp = result.PayParam.TimeStamp;
                    payRequestInfo.nonceStr = result.PayParam.NonceStr;
                    payRequestInfo.paySign = result.PayParam.PaySign;
                    orderAddResult.PayRequestInfo = payRequestInfo;
                    #endregion
                }
            }
            return ResultData<OrderAddResultVo>.Success().AddData("orderAddResult", orderAddResult);
        }

        /// <summary>
        /// 新的购物车下单接口 
        /// </summary>
        /// <param name="cartOrder"></param>
        /// <returns></returns>
        [HttpPost("newCartOrder")]
        public async Task<ResultData<PayResultVo>> NewCartOrderAsync(CartOrderAddVo add)
        {
            var token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var customerInfo = await customerService.GetByIdAsync(customerId);
            string phone = await customerService.GetPhoneByCustomerIdAsync(customerId);
            var miniUserInfo = await _wxMiniUserRepository.GetByUserIdAsync(customerInfo.UserId);
            string OpenId = miniUserInfo.OpenId;
            string appId = sessionInfo.AppId;
            CartOrderAddDto cartOrderAdd = new CartOrderAddDto();
            cartOrderAdd.CustomerId = customerId;
            cartOrderAdd.OpenId = OpenId;
            cartOrderAdd.AddressId = add.AddressId;
            cartOrderAdd.Remark = add.Remark;
            cartOrderAdd.VoucherId = add.VoucherId;
            cartOrderAdd.ExchageType = add.ExchageType;
            cartOrderAdd.AppId = appId;
            cartOrderAdd.OrderItemList = add.OrderItemList.Select(e => new Fx.Amiya.Dto.Order.OrderItem
            {
                GoodsId = e.GoodsId,
                Quantity = e.Quantity,
                StandardId = e.StandardId
            }).ToList();
            var payResult = await orderService.NewCartOrderAsync(cartOrderAdd);
            PayResultVo payRequestInfo = new PayResultVo();
            payRequestInfo.appId = payResult.appId;
            payRequestInfo.package = payResult.package;
            payRequestInfo.timeStamp = payResult.timeStamp;
            payRequestInfo.nonceStr = payResult.nonceStr;
            payRequestInfo.paySign = payResult.paySign;

            return ResultData<PayResultVo>.Success().AddData("payInfo", payRequestInfo);
        }

        /// <summary>
        /// 积分虚拟商品下单接口
        /// </summary>
        /// <returns></returns>
        [HttpPost("newIntegralVirtualOrder")]
        public async Task<ResultData<string>> NewIntegralVirtualOrderAsync(CreateIntegralVirtualOrderVo createOrder)
        {
            var token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var customerInfo = await customerService.GetByIdAsync(customerId);
            string phone = await customerService.GetPhoneByCustomerIdAsync(customerId);
            var miniUserInfo = await _wxMiniUserRepository.GetByUserIdAsync(customerInfo.UserId);
            CreateIntegralVirtualOrderDto order = new CreateIntegralVirtualOrderDto();
            order.CustomerId = customerId;
            order.Phone = phone;
            order.BuyerNick = miniUserInfo.NickName;
            order.Remark = createOrder.Remark;
            order.GoodsId = createOrder.GoodsId;
            order.HospitalId = createOrder.HospitalId;
            order.Quantity = createOrder.Quantity;
            var tradeId = await orderService.CreateIntegralVirtualOrderAsync(order);
            return ResultData<string>.Success().AddData("tradeId", tradeId);
        }

        /// <summary>
        /// 订单重新支付
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        [HttpPost("wechatPay/{tradeId}")]
        public async Task<ResultData<OrderAddResultVo>> GetWechatPayAsync(string tradeId)
        {
            var token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var orderTrade = await orderService.GetOrderTradeByTradeIdAsync(tradeId);
            var customerInfo = await customerService.GetByIdAsync(customerId);
            var miniUserInfo = await _wxMiniUserRepository.GetByUserIdAsync(customerInfo.UserId);
            string OpenId = miniUserInfo.OpenId;
            string appId = sessionInfo.AppId;
            OrderAddResultVo orderPayResult = new OrderAddResultVo();
            if (orderTrade.StatusCode != "WAIT_BUYER_PAY")
            {
                throw new Exception("订单状态已改变不能重新支付!");
            }
            foreach (var item in orderTrade.OrderInfoList)
            {
                if (item.ExchangeType != (int)ExchangeType.HuiShouQian && item.ExchangeType != (int)ExchangeType.PointAndMoney && item.ExchangeType != (int)ExchangeType.Wechat)
                {
                    throw new Exception("该订单不支持重新支付,请取消订单重新下单并支付!");
                }
            }
            /*string orderId = "";
            string goodsName = "";
            decimal totalFee = 0M;
            bool IsExistThirdPartPay = false;

            foreach (var x in orderTrade.OrderInfoList)
            {
                orderId += x.Id + ",";
                totalFee += x.ActualPayment.Value;
                goodsName += x.GoodsName + ",";
                if (Convert.ToInt16(x.ExchangeType) == Convert.ToInt16(ExchangeType.ThirdPartyPayment))
                {
                    IsExistThirdPartPay = true;
                }
            }
            orderId = orderId.Trim(',');
            goodsName = goodsName.Trim(',');
            orderId = orderId.Trim(',');
            OrderAddResultVo orderPayResult = new OrderAddResultVo();*/
            #region 微信支付
            PayRequestInfoVo payRequestInfo = new PayRequestInfoVo();
            //支付时使用的订单号
            var transNo = "";
            if (appId == "wx8747b7f34c0047eb")
            {
                WxPackageInfo packageInfo = new WxPackageInfo();
                packageInfo.AppId = appId;
                packageInfo.Body = tradeId;
                packageInfo.Attach = tradeId;
                //回调地址需重新设置(todo;)
                //packageInfo.NotifyUrl = string.Format("http://{0}/pay/wx_Pay.aspx", Request.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString() + ":" + Request.HttpContext.Connection.LocalPort);
                packageInfo.NotifyUrl = string.Format("{0}/amiya/wxmini/Notify/orderpayresult", "https://app.ameiyes.com/amiyamini");
                //packageInfo.NotifyUrl = string.Format("{0}/amiya/wxmini/Notify/orderpayresult", "https://www.amyk.cn");
                packageInfo.OutTradeNo = Guid.NewGuid().ToString().Replace("-", "");
                packageInfo.TotalFee = (int)(orderTrade.TotalAmount * 100m);
                if (packageInfo.TotalFee < 1m)
                {
                    packageInfo.TotalFee = 1m;
                }
                //支付人
                packageInfo.OpenId = OpenId;
                string CheckValue = "";
                //验证参数
                if (orderService.CheckVxSetParams(out CheckValue))
                {
                    if (!orderService.CheckVxPackage(packageInfo, out CheckValue))
                    {
                        throw new Exception(CheckValue.ToString());
                    }
                    var payRequest = await orderService.BuildPayRequest(packageInfo);
                    payRequestInfo.appId = payRequest.appId;
                    payRequestInfo.package = payRequest.package;
                    payRequestInfo.timeStamp = payRequest.timeStamp;
                    payRequestInfo.nonceStr = payRequest.nonceStr;
                    payRequestInfo.paySign = payRequest.paySign;
                    orderPayResult.PayRequestInfo = payRequestInfo;
                }
                transNo = packageInfo.OutTradeNo;
            }
            #endregion

            #region 慧收钱支付


            if (appId != "wx8747b7f34c0047eb")
            {
                HuiShouQianPayRequestInfo huiShouQianPayRequestInfo = new HuiShouQianPayRequestInfo();
                huiShouQianPayRequestInfo.TransNo = Guid.NewGuid().ToString().Replace("-", "");
                huiShouQianPayRequestInfo.PayType = "WECHAT_APPLET";
                huiShouQianPayRequestInfo.OrderAmt = (orderTrade.TotalAmount * 100m).ToString().Split(".")[0];
                huiShouQianPayRequestInfo.GoodsInfo = "商品付款";
                huiShouQianPayRequestInfo.RequestDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                huiShouQianPayRequestInfo.Extend = tradeId;
                var result = await huiShouQianPaymentService.CreateHuiShouQianOrder(huiShouQianPayRequestInfo, OpenId, customerId);
                if (result.Success == false) throw new Exception("下单失败,请重新下单");
                payRequestInfo.appId = result.PayParam.AppId;
                payRequestInfo.package = result.PayParam.Package;
                payRequestInfo.timeStamp = result.PayParam.TimeStamp;
                payRequestInfo.nonceStr = result.PayParam.NonceStr;
                payRequestInfo.paySign = result.PayParam.PaySign;
                orderPayResult.PayRequestInfo = payRequestInfo;
                transNo = huiShouQianPayRequestInfo.TransNo;
            }
            //交易信息添加支付交易订单号
            await orderService.TradeAddTransNoAsync(tradeId, transNo);
            #endregion


            return ResultData<OrderAddResultVo>.Success().AddData("orderPayGetResult", orderPayResult);
        }


        /// <summary>
        /// 积分加钱购商品下单
        /// </summary>
        /// <returns></returns>
        [HttpPost("pointAndMoneyOrder")]
        public async Task<ResultData<OrderAddResultVo>> AddPointAndMoneyOrder(PointMoneyOrderAddVo orderAdd)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var token = tokenReader.GetToken();
                var sessionInfo = sessionStorage.GetSession(token);
                string customerId = sessionInfo.FxCustomerId;
                string userId = sessionInfo.FxUserId;
                string appId = sessionInfo.AppId;
                if (string.IsNullOrEmpty(customerId)) throw new Exception("请先绑定手机号！");
                var belongLiveAnchorId = await userService.BindUserBelongAppIdAsync(userId, customerId);
                //积分余额
                decimal integrationBalance = await integrationAccountService.GetIntegrationBalanceByCustomerIDAsync(customerId);
                var customerInfo = await customerService.GetByIdAsync(customerId);
                string phone = await customerService.GetPhoneByCustomerIdAsync(customerId);
                var miniUserInfo = await _wxMiniUserRepository.GetByUserIdAsync(customerInfo.UserId);
                string OpenId = miniUserInfo.OpenId;
                DateTime date = DateTime.Now;
                List<OrderInfoAddDto> amiyaOrderList = new List<OrderInfoAddDto>();
                Dictionary<string, int> inventoryQuantityDict = new Dictionary<string, int>();
                CustomerConsumptioVoucherInfoDto voucher = null;
                bool IsSpecifyVoucher = false;
                if (!string.IsNullOrEmpty(orderAdd.VoucherId) && orderAdd.VoucherId != "0")
                {
                    voucher = await customerConsumptionVoucherService.GetVoucherByCustomerIdAndVoucherIdAsync(customerId, orderAdd.VoucherId);
                    if (voucher == null) throw new Exception("没有此抵用券信息");
                    if (voucher.IsUsed) throw new Exception("该抵用券已被使用");
                    if (voucher.IsSpecifyProduct) IsSpecifyVoucher = true;
                }
                //商品下单
                foreach (var item in orderAdd.OrderItemList)
                {
                    if (item.Quantity <= 0) throw new Exception("下单数量错误");
                    var goodsInfo = await goodsInfoService.GetByIdAsync(item.GoodsId);
                    var isOverLimitCount = await orderService.IsOverLimitOrderAsync(item.GoodsId, customerId, item.Quantity);
                    if (isOverLimitCount)
                    {
                        throw new Exception("已超出商品限购数量！");
                    }
                    if (goodsInfo.ExchangeType != ExchangeType.PointAndMoney)
                    {
                        throw new Exception("该商品不支持积分加钱购");
                    }

                    /*if (goodsInfo.GoodsConsumptionVoucher.Contains(orderAdd.VoucherId)) { } else {
                        throw new Exception();
                    }*/
                    OrderInfoAddDto amiyaOrder = new OrderInfoAddDto();
                    //计算所需积分和支付金额
                    var standard = await goodsStandardsPriceService.GetByGoodsId(item.GoodsId);
                    var find = standard.Find(e => e.Id == item.Standard);
                    if (find == null) throw new Exception("规格错误");
                    amiyaOrder.IntegrationQuantity = find.IntegralAmount * item.Quantity;
                    amiyaOrder.ActualPayment = find.Price * item.Quantity;
                    if (voucher != null && IsSpecifyVoucher)
                    {
                        if (voucher.Type == (int)ConsumptionVoucherType.Material)
                        {
                            amiyaOrder.ActualPayment = (amiyaOrder.ActualPayment - voucher.DeductMoney <= 0) ? 0.01m : (amiyaOrder.ActualPayment - voucher.DeductMoney);
                            amiyaOrder.DeductMoney = voucher.DeductMoney;
                            amiyaOrder.IsUseCoupon = true;
                            amiyaOrder.CouponId = voucher.Id;
                        }
                        else if (voucher.Type == (int)ConsumptionVoucherType.Discount)
                        {
                            var payCount = amiyaOrder.ActualPayment;
                            amiyaOrder.ActualPayment = Math.Ceiling(amiyaOrder.ActualPayment.Value * voucher.DeductMoney) <= 0 ? 0.01m : Math.Ceiling(amiyaOrder.ActualPayment.Value * voucher.DeductMoney);
                            amiyaOrder.DeductMoney = payCount.Value - amiyaOrder.ActualPayment.Value;
                            amiyaOrder.IsUseCoupon = true;
                            amiyaOrder.CouponId = voucher.Id;
                        }

                    }
                    amiyaOrder.ExchangeType = (int)ExchangeType.PointAndMoney;
                    amiyaOrder.Standard = find.Standards;
                    if (goodsInfo.IsMaterial == true)
                    {
                        if (goodsInfo.IsMaterial && orderAdd.AddressId == null)
                            throw new Exception("收货地址不能为空");
                    }
                    if (goodsInfo.InventoryQuantity < item.Quantity)
                        throw new Exception("库存不足");
                    amiyaOrder.Id = CreateOrderIdHelper.GetNextNumber();
                    amiyaOrder.GoodsId = item.GoodsId;
                    amiyaOrder.GoodsName = goodsInfo.Name;
                    amiyaOrder.StatusCode = OrderStatusCode.WAIT_BUYER_PAY;
                    if (goodsInfo.InventoryQuantity != null)
                        inventoryQuantityDict.Add(item.GoodsId, item.Quantity);
                    amiyaOrder.Quantity = item.Quantity;
                    amiyaOrder.BuyerNick = customerInfo.NickName;
                    amiyaOrder.CreateDate = date;
                    amiyaOrder.UpdateDate = date;
                    amiyaOrder.ThumbPicUrl = goodsInfo.ThumbPicUrl;
                    amiyaOrder.AppType = (byte)AppType.MiniProgram;
                    amiyaOrder.OrderType = goodsInfo.IsMaterial == true ? (byte)OrderType.MaterialOrder : (byte)OrderType.VirtualOrder;
                    amiyaOrder.Phone = phone;
                    amiyaOrder.TradeId = phone;
                    amiyaOrder.LiveAnchorId = belongLiveAnchorId.HasValue ? belongLiveAnchorId.Value : 0;
                    int bindCustomerId;
                    bindCustomerId = await _bindCustomerService.GetEmployeeIdByPhone(phone);
                    if (bindCustomerId == 0)
                    {
                        AddBindCustomerServiceDto addBindCustomerServiceDto = new AddBindCustomerServiceDto();
                        addBindCustomerServiceDto.CustomerServiceId = 188;
                        var orderIdList = await orderService.GetOrderIdListByPhone(amiyaOrder.Phone);
                        UpdateBelongEmpInfoOrderDto updateOrderBelongEmpIdDto = new UpdateBelongEmpInfoOrderDto();
                        updateOrderBelongEmpIdDto.OrderId = orderIdList;
                        updateOrderBelongEmpIdDto.BelongEmpId = addBindCustomerServiceDto.CustomerServiceId;
                        //修改订单归属客服
                        await orderService.UpdateOrderBelongEmpIdAsync(updateOrderBelongEmpIdDto);
                        addBindCustomerServiceDto.OrderIdList = orderIdList;
                        //添加客服绑定关系
                        await _bindCustomerService.AddAsync(addBindCustomerServiceDto, 1);
                    }
                    amiyaOrder.BelongEmpId = bindCustomerId;
                    amiyaOrderList.Add(amiyaOrder);
                }
                if (amiyaOrderList.Sum(e => e.IntegrationQuantity) > integrationBalance)
                    throw new Exception("积分余额不足");
                //减库存
                foreach (KeyValuePair<string, int> item in inventoryQuantityDict)
                {
                    await goodsInfoService.ReductionGoodsInventoryQuantityAsync(item.Key, item.Value);
                }
                OrderTradeAddDto orderTradeAdd = new OrderTradeAddDto();
                orderTradeAdd.CustomerId = customerId;
                orderTradeAdd.CreateDate = date;
                orderTradeAdd.AddressId = orderAdd.AddressId;
                orderTradeAdd.Remark = orderAdd.Remark;
                orderTradeAdd.OrderInfoAddList = amiyaOrderList;


                //不管用户是否支付金额先扣除积分(取消支付,支付超时自动取消后退还)
                //放在添加订单前确保订单生成成功一定会扣除积分
                List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();

                if (voucher != null && !IsSpecifyVoucher)
                {
                    orderTradeAdd.VoucherId = voucher.Id;
                }
                string tradeId = await orderService.AddAmiyaOrderWithNoTransactionAsync(orderTradeAdd);
                OrderAddResultVo orderAddResult = new OrderAddResultVo();
                orderAddResult.TradeId = tradeId;
                //三方支付
                string orderId = "";
                string goodsName = "";
                decimal totalFee = 0M;
                foreach (var x in amiyaOrderList)
                {
                    orderId += x.Id + ",";
                    totalFee += x.ActualPayment.Value;
                    goodsName += x.GoodsName + ",";
                }
                if (totalFee < 0) throw new Exception("支付金额异常");
                orderId = orderId.Trim(',');
                goodsName = goodsName.Trim(',');


                PayRequestInfoVo payRequestInfo = new PayRequestInfoVo();
                # region 微信支付


                if (appId == "wx8747b7f34c0047eb")
                {
                    //啊美雅美容使用微信支付    
                    WxPackageInfo packageInfo = new WxPackageInfo();
                    packageInfo.AppId = appId;
                    packageInfo.Body = orderId;
                    //回调地址需重新设置(todo;)                   
                    packageInfo.NotifyUrl = string.Format("{0}/amiya/wxmini/Notify/orderpayresult", "https://app.ameiyes.com/amiyamini");
                    //packageInfo.NotifyUrl = string.Format("{0}/amiya/wxmini/Notify/orderpayresult", "https://www.amyk.cn");
                    packageInfo.OutTradeNo = tradeId;
                    packageInfo.Attach = tradeId;
                    packageInfo.TotalFee = (int)(totalFee * 100m);
                    if (packageInfo.TotalFee < 1m)
                    {
                        packageInfo.TotalFee = 1m;
                    }
                    //支付人
                    packageInfo.OpenId = OpenId;
                    string CheckValue = "";
                    //验证参数
                    if (orderService.CheckVxSetParams(out CheckValue))
                    {
                        if (!orderService.CheckVxPackage(packageInfo, out CheckValue))
                        {
                            throw new Exception(CheckValue.ToString());
                        }
                        var payRequest = await orderService.BuildPayRequest(packageInfo);

                        payRequestInfo.appId = payRequest.appId;
                        payRequestInfo.package = payRequest.package;
                        payRequestInfo.timeStamp = payRequest.timeStamp;
                        payRequestInfo.nonceStr = payRequest.nonceStr;
                        payRequestInfo.paySign = payRequest.paySign;
                        orderAddResult.PayRequestInfo = payRequestInfo;
                    }
                    //交易信息添加支付交易订单号
                    await orderService.TradeAddTransNoAsync(tradeId, tradeId);
                }

                #endregion

                #region 慧收钱支付
                if (appId != "wx8747b7f34c0047eb")
                {
                    HuiShouQianPayRequestInfo huiShouQianPayRequestInfo = new HuiShouQianPayRequestInfo();
                    huiShouQianPayRequestInfo.TransNo = Guid.NewGuid().ToString().Replace("-", "");
                    huiShouQianPayRequestInfo.PayType = "WECHAT_APPLET";
                    huiShouQianPayRequestInfo.OrderAmt = (totalFee * 100m).ToString().Split(".")[0];
                    huiShouQianPayRequestInfo.GoodsInfo = "商品付款";
                    huiShouQianPayRequestInfo.RequestDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                    huiShouQianPayRequestInfo.Extend = tradeId;
                    var result = await huiShouQianPaymentService.CreateHuiShouQianOrder(huiShouQianPayRequestInfo, OpenId, customerId);

                    if (result.Success == false) throw new Exception("下单失败,请重新下单");
                    //交易信息添加支付交易订单号
                    await orderService.TradeAddTransNoAsync(tradeId, huiShouQianPayRequestInfo.TransNo);

                    payRequestInfo.appId = result.PayParam.AppId;
                    payRequestInfo.package = result.PayParam.Package;
                    payRequestInfo.timeStamp = result.PayParam.TimeStamp;
                    payRequestInfo.nonceStr = result.PayParam.NonceStr;
                    payRequestInfo.paySign = result.PayParam.PaySign;
                    orderAddResult.PayRequestInfo = payRequestInfo;
                }
                //更新抵用券使用状态
                if (voucher != null)
                {
                    UpdateCustomerConsumptionVoucherDto update = new UpdateCustomerConsumptionVoucherDto
                    {
                        CustomerVoucherId = orderAdd.VoucherId,
                        IsUsed = true,
                        UseDate = DateTime.Now
                    };
                    await customerConsumptionVoucherService.UpdateCustomerConsumptionVoucherUseStatusAsync(update);
                }
                foreach (var item in orderTradeAdd.OrderInfoAddList)
                {
                    UseIntegrationDto useIntegrationDto = new UseIntegrationDto();
                    useIntegrationDto.CustomerId = customerId;
                    useIntegrationDto.OrderId = item.Id;
                    useIntegrationDto.Date = DateTime.Now;
                    useIntegrationDto.UseQuantity = (decimal)item.IntegrationQuantity;
                    await integrationAccountService.UseByGoodsConsumption(useIntegrationDto);
                }
                unitOfWork.Commit();
                return ResultData<OrderAddResultVo>.Success().AddData("orderAddResult", orderAddResult);
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
            #endregion

        }
        /// <summary>
        /// 积分订单重新支付
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        [HttpPost("pay/{tradeId}")]
        public async Task<ResultData> IntegrationPayAsync(string tradeId)
        {

            try
            {
                unitOfWork.BeginTransaction();
                var token = tokenReader.GetToken();
                var sessionInfo = sessionStorage.GetSession(token);
                string customerId = sessionInfo.FxCustomerId;
                //是否是虚拟订单
                bool isMaterialOrder = false;

                var orderTrade = await orderService.GetOrderTradeByTradeIdAsync(tradeId);
                isMaterialOrder = orderTrade.OrderInfoList.Where(e => e.OrderType == (byte)OrderType.MaterialOrder).Count() > 0;
                decimal integrationBalance = await integrationAccountService.GetIntegrationBalanceByCustomerIDAsync(customerId);
                if (orderTrade.TotalIntegration > integrationBalance)
                    throw new Exception("积分余额不足！");
                List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
                foreach (var item in orderTrade.OrderInfoList)
                {
                    if (item.ExchangeType != (byte)ExchangeType.Integration) throw new Exception("支付方式错误");

                    UpdateOrderDto updateOrder = new UpdateOrderDto();
                    updateOrder.OrderId = item.Id;
                    if (isMaterialOrder)
                    {
                        updateOrder.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
                    }
                    else
                    {
                        updateOrder.StatusCode = OrderStatusCode.TRADE_BUYER_PAID;
                    }

                    if (item.ActualPayment.HasValue && item.ActualPayment > 0)
                    {
                        updateOrder.Actual_payment = item.ActualPayment.Value;

                        var bind = await _dalBindCustomerService.GetAll().FirstOrDefaultAsync(e => e.BuyerPhone == item.Phone);
                        if (bind != null)
                        {
                            bind.NewConsumptionDate = DateTime.Now;
                            bind.NewConsumptionContentPlatform = (int)OrderFrom.ThirdPartyOrder;
                            bind.NewContentPlatForm = ServiceClass.GetAppTypeText(item.AppType);
                            bind.AllPrice += item.ActualPayment.Value;
                            bind.AllOrderCount += item.Quantity;
                            await _dalBindCustomerService.UpdateAsync(bind, true);
                        }

                    }
                    if (item.IntegrationQuantity.HasValue)
                    {
                        updateOrder.IntergrationQuantity = item.IntegrationQuantity;
                    }
                    Random random = new Random();
                    updateOrder.AppType = item.AppType;
                    updateOrder.WriteOffCode = random.Next().ToString().Substring(0, 8);
                    var exist = orderService.WriteOffCodeIsExist(updateOrder.WriteOffCode);
                    if (exist)
                    {
                        updateOrder.WriteOffCode = random.Next().ToString().Substring(0, 8);
                    }
                    updateOrderList.Add(updateOrder);
                }

                //修改订单状态
                await orderService.UpdateWithNoTranstionAsync(updateOrderList);
                foreach (var item in orderTrade.OrderInfoList)
                {
                    if (item.ExchangeType == (byte)ExchangeType.Integration && item.IntegrationQuantity > 0)
                    {
                        UseIntegrationDto useIntegrationDto = new UseIntegrationDto();
                        useIntegrationDto.CustomerId = customerId;
                        useIntegrationDto.OrderId = item.Id;
                        useIntegrationDto.Date = DateTime.Now;
                        useIntegrationDto.UseQuantity = (decimal)item.IntegrationQuantity;
                        await integrationAccountService.UseByGoodsConsumption(useIntegrationDto);
                    }
                }
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
            return ResultData.Success();
        }

        /// <summary>
        /// 余额支付
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        [HttpPost("balancePay/{tradeId}")]
        public async Task<ResultData> BalancePayAsync(string tradeId)
        {
            var token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;

            var orderTrade = await orderService.GetOrderTradeByTradeIdAsync(tradeId);
            if (orderTrade.StatusCode != OrderStatusCode.WAIT_BUYER_PAY) throw new Exception("订单状态已更改,无法支付!");
            //余额支付
            foreach (var x in orderTrade.OrderInfoList)
            {
                if (x.ActualPayment <= 0) throw new Exception("支付金额异常");
                await balanceService.BalancePayAsync(customerId, x.Id, x.ActualPayment.Value);
            }
            //修改订单状态
            List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
            foreach (var item in orderTrade.OrderInfoList)
            {

                UpdateOrderDto updateOrder = new UpdateOrderDto();
                updateOrder.OrderId = item.Id;
                updateOrder.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
                if (item.ActualPayment.HasValue)
                {
                    updateOrder.Actual_payment = item.ActualPayment.Value;
                }
                if (item.IntegrationQuantity.HasValue)
                {
                    updateOrder.IntergrationQuantity = item.IntegrationQuantity;
                }
                Random random = new Random();
                updateOrder.AppType = item.AppType;
                updateOrder.WriteOffCode = random.Next().ToString().Substring(0, 8);
                updateOrderList.Add(updateOrder);
            }

            //修改订单状态
            await orderService.UpdateAsync(updateOrderList);

            UpdateOrderTradeDto updateOrderTrade = new UpdateOrderTradeDto();
            updateOrderTrade.TradeId = tradeId;
            updateOrderTrade.AddressId = orderTrade.AddressId;
            updateOrderTrade.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
            await orderService.UpdateOrderTradeAsync(updateOrderTrade);
            return ResultData.Success();
        }

        [HttpPost("refundOrder")]
        public Task<ResultData> RefundOrder(RefundOrderVo refundOrderVo)
        {
            return null;
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="statusCode">状态码：WAIT_BUYER_PAY=待付款，WAIT_SELLER_SEND_GOODS=待发货，WAIT_BUYER_CONFIRM_GOODS=待收货</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<OrderTradeVo>>> GetOrderListForAmiyaByCustomerId(string statusCode, int pageNum, int pageSize)
        {
            var token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var q = await orderService.GetOrderListForAmiyaByCustomerId(customerId, statusCode, pageNum, pageSize);
            var orders = from d in q.List
                         select new OrderTradeVo
                         {
                             TradeId = d.TradeId,
                             CustomerId = d.CustomerId,
                             CreateDate = d.CreateDate,
                             AddressId = d.AddressId,
                             TotalAmount = d.TotalAmount,
                             TotalIntegration = d.TotalIntegration,
                             Remark = d.Remark,
                             StatusCode = d.StatusCode,
                             StatusText = d.StatusText,
                             OrderInfoList = (from o in d.OrderInfoList
                                              select new OrderInfoVo
                                              {
                                                  Id = o.Id,
                                                  GoodsName = o.GoodsName,
                                                  GoodsId = o.GoodsId,
                                                  ThumbPicUrl = o.ThumbPicUrl,
                                                  ActualPayment = o.ActualPayment,
                                                  SinglePrice = o.ActualPayment.HasValue && o.Quantity > 0 ? (o.ActualPayment / o.Quantity) : 0.00M,
                                                  OrderType = o.OrderType,
                                                  OrderTypeText = o.OrderTypeText,
                                                  Quantity = o.Quantity,
                                                  IntegrationQuantity = o.IntegrationQuantity,
                                                  SingleIntegrationQuantity = o.IntegrationQuantity.HasValue && o.Quantity > 0 ? (o.IntegrationQuantity / o.Quantity) : 0.00M,
                                                  ExchangeType = o.ExchangeType,
                                                  ExchangeTypeText = o.ExchangeTypeText,
                                                  TradeId = o.TradeId,
                                                  Standard = goodsInfoService.GetByIdAsync(o.GoodsId).Result.Standard,
                                                  IsUseCoupon = o.IsUseCoupon,
                                                  DeductMoney = o.DeductMoney
                                              }).ToList()
                         };



            FxPageInfo<OrderTradeVo> orderTradePageInfo = new FxPageInfo<OrderTradeVo>();
            orderTradePageInfo.TotalCount = q.TotalCount;
            orderTradePageInfo.List = orders;
            return ResultData<FxPageInfo<OrderTradeVo>>.Success().AddData("orders", orderTradePageInfo);
        }

        /// <summary>
        /// 获取所有平台的订单列表
        /// </summary>
        /// <param name="statusCode">状态码：WAIT_BUYER_PAY=待付款，WAIT_SELLER_SEND_GOODS=待发货，WAIT_BUYER_CONFIRM_GOODS=待收货</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("alllist")]
        public async Task<ResultData<FxPageInfo<OrderTradeVo>>> GetOrderListForAllAmiyaByCustomerId(string statusCode, int pageNum, int pageSize)
        {
            var token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var q = await orderService.GetOrderListForAllAmiyaByCustomerId(customerId, statusCode, pageNum, pageSize);
            var orders = from d in q.List
                         select new OrderTradeVo
                         {
                             TradeId = d.TradeId,
                             CustomerId = d.CustomerId,
                             CreateDate = d.CreateDate,
                             AddressId = d.AddressId,
                             TotalAmount = d.TotalAmount,
                             TotalIntegration = d.TotalIntegration,
                             Remark = d.Remark,
                             StatusCode = d.StatusCode,
                             StatusText = d.StatusText,
                             OrderInfoList = (from o in d.OrderInfoList
                                              orderby o.CreateDate descending
                                              select new OrderInfoVo
                                              {
                                                  Id = o.Id,
                                                  GoodsName = o.GoodsName,
                                                  GoodsId = o.GoodsId,
                                                  ThumbPicUrl = o.ThumbPicUrl,
                                                  ActualPayment = o.ActualPayment,
                                                  SinglePrice = o.ActualPayment.HasValue && o.Quantity > 0 ? (o.ActualPayment / o.Quantity) : 0.00M,
                                                  OrderType = o.OrderType,
                                                  OrderTypeText = o.OrderTypeText,
                                                  Quantity = o.Quantity,
                                                  IntegrationQuantity = o.IntegrationQuantity,
                                                  SingleIntegrationQuantity = o.IntegrationQuantity.HasValue && o.Quantity > 0 ? (o.IntegrationQuantity / o.Quantity) : 0.00M,
                                                  ExchangeType = o.ExchangeType,
                                                  ExchangeTypeText = o.ExchangeTypeText,
                                                  TradeId = o.TradeId,
                                                  Standard = goodsInfoService.GetByIdAsync(o.GoodsId).Result.Standard,
                                                  AppType = o.AppType,
                                                  AppTypeText = o.AppTypeText,
                                                  StatusCode = o.StatusCode,
                                                  StatusCodeText = o.StatusText
                                              }).ToList()
                         };



            FxPageInfo<OrderTradeVo> orderTradePageInfo = new FxPageInfo<OrderTradeVo>();
            orderTradePageInfo.TotalCount = q.TotalCount;
            orderTradePageInfo.List = orders;
            return ResultData<FxPageInfo<OrderTradeVo>>.Success().AddData("orders", orderTradePageInfo);
        }


        /// <summary>
        /// 获取下级订单列表
        /// </summary>
        /// <param name="statusCode">状态码：WAIT_BUYER_PAY=待付款，WAIT_SELLER_SEND_GOODS=待发货，WAIT_BUYER_CONFIRM_GOODS=待收货</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("subordinatelist")]
        public async Task<ResultData<FxPageInfo<SubordinateOrderVo>>> GetSubordinateListByCustomerId(string customerId, int pageNum, int pageSize)
        {
            var q = await orderService.GetSubordinateOrder(customerId, pageNum, pageSize);
            var orders = from d in q.List
                         select new SubordinateOrderVo
                         {
                             GoodsName = d.GoodsName,
                             GoodsImgUrl = d.GoodsImgUrl,
                             OrderDate = d.OrderDate,
                             Price = d.Price,
                             StatusCodeText = d.StatusCodeText
                         };
            FxPageInfo<SubordinateOrderVo> orderTradePageInfo = new FxPageInfo<SubordinateOrderVo>();
            orderTradePageInfo.TotalCount = q.TotalCount;
            orderTradePageInfo.List = orders;
            return ResultData<FxPageInfo<SubordinateOrderVo>>.Success().AddData("orders", orderTradePageInfo);
        }


        /// <summary>
        /// 根据交易编号获取订单交易详情
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        [HttpGet("tradeDetail/{tradeId}")]
        public async Task<ResultData<OrderTradeVo>> GetOrderTradeByTradeIdAsync(string tradeId)
        {
            var orderTrade = await orderService.GetOrderTradeByTradeIdAsync(tradeId);
            OrderTradeVo orderTradeVo = new OrderTradeVo();
            orderTradeVo.TradeId = orderTrade.TradeId;
            orderTradeVo.CustomerId = orderTrade.CustomerId;
            orderTradeVo.CreateDate = orderTrade.CreateDate;
            orderTradeVo.UpdateDate = orderTrade.UpdateDate;
            orderTradeVo.AddressId = orderTrade.AddressId;
            orderTradeVo.TotalAmount = orderTrade.TotalAmount;
            orderTradeVo.TotalIntegration = orderTrade.TotalIntegration;
            orderTradeVo.Remark = orderTrade.Remark;
            orderTradeVo.StatusCode = orderTrade.StatusCode;
            orderTradeVo.StatusText = orderTrade.StatusText;
            orderTradeVo.OrderInfoList = (from o in orderTrade.OrderInfoList
                                          select new OrderInfoVo
                                          {
                                              Id = o.Id,
                                              GoodsName = o.GoodsName,
                                              GoodsId = o.GoodsId,
                                              ThumbPicUrl = o.ThumbPicUrl,
                                              ActualPayment = o.ActualPayment,
                                              OrderType = o.OrderType,
                                              OrderTypeText = o.OrderTypeText,
                                              Quantity = o.Quantity,
                                              IntegrationQuantity = o.IntegrationQuantity,
                                              ExchangeType = o.ExchangeType,
                                              ExchangeTypeText = o.ExchangeTypeText,
                                              TradeId = o.TradeId,
                                              Standard = goodsInfoService.GetByIdAsync(o.GoodsId).Result.Standard
                                          }).ToList();
            return ResultData<OrderTradeVo>.Success().AddData("orderTrade", orderTradeVo);
        }


        /// <summary>
        /// 根据交易编号获取物流信息
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        [HttpGet("expressInfo/{tradeId}/{orderId}")]
        public async Task<ResultData<OrderExpressInfoVo>> GetExpressInfoAsync(string tradeId, string orderId)
        {
            var orderExpressInfoDto = await orderService.GetOrderExpressInfoAsync(tradeId, orderId);
            var orderExpressInfoDetails = from d in orderExpressInfoDto.data
                                          select new ExpressDetailsVo
                                          {
                                              time = d.time,
                                              content = d.context
                                          };
            OrderExpressInfoVo orderExpressInfoVo = new OrderExpressInfoVo();
            orderExpressInfoVo.ExpressNo = orderExpressInfoDto.ExpressNo;
            orderExpressInfoVo.ExpressName = orderExpressInfoDto.ExpressName;
            orderExpressInfoVo.state = KuaiDi100Utils.GetExpressState(orderExpressInfoDto.state);
            orderExpressInfoVo.ExpressDetailList = orderExpressInfoDetails.ToList();
            return ResultData<OrderExpressInfoVo>.Success().AddData("orderExpressInfoVo", orderExpressInfoVo);
        }


        /// <summary>
        /// 根据交易编号取消订单
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        [HttpGet("cancel/{tradeId}")]
        public async Task<ResultData> CancelOrderByTradeIdAsync(string tradeId)
        {
            var orderTrade = await orderService.GetOrderTradeByTradeIdAsync(tradeId);
            List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
            foreach (var item in orderTrade.OrderInfoList)
            {
                UpdateOrderDto updateOrder = new UpdateOrderDto();
                updateOrder.OrderId = item.Id;
                updateOrder.StatusCode = OrderStatusCode.TRADE_CLOSED_BY_TAOBAO;
                updateOrder.AppType = (byte)AppType.MiniProgram;
                updateOrderList.Add(updateOrder);
                if (item.GoodsId != "00000000")
                {
                    await goodsInfoService.AddGoodsInventoryQuantityAsync(item.GoodsId, (int)item.Quantity);
                }
                //退还抵用券
                if (item.IsUseCoupon)
                {
                    UpdateCustomerConsumptionVoucherDto updateCustomerConsumptionVoucherDto = new UpdateCustomerConsumptionVoucherDto();
                    updateCustomerConsumptionVoucherDto.CustomerVoucherId = item.CouponId;
                    updateCustomerConsumptionVoucherDto.IsUsed = false;
                    await customerConsumptionVoucherService.UpdateCustomerConsumptionVoucherUseStatusAsync(updateCustomerConsumptionVoucherDto);
                }
            }
            await orderService.UpdateAsync(updateOrderList);
            return ResultData.Success();
        }


        /// <summary>
        /// 取消积分加钱购订单
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        [HttpPost("canclePointAndMoneyOrder/{tradeId}")]
        public async Task<ResultData<bool>> CanclePointAndMoneyOrder(string tradeId)
        {
            var token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            await orderService.CancelPointAndMoneyOrderAsync(tradeId, customerId);
            return ResultData<bool>.Success().AddData("cacelStatus", true);
        }



        /// <summary>
        /// 确认收货
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        [HttpGet("confirmReceive/{tradeId}")]
        public async Task<ResultData> ConfirmReceiveByTradeIdAsync(string tradeId)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var token = tokenReader.GetToken();
                var sessionInfo = sessionStorage.GetSession(token);
                string customerId = sessionInfo.FxCustomerId;
                var orderTrade = await orderService.GetOrderTradeByTradeIdAsync(tradeId);
                var userInfo = await userService.GetUserInfoByUserIdAsync(sessionInfo.FxUserId);
                List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
                foreach (var item in orderTrade.OrderInfoList)
                {
                    UpdateOrderDto updateOrder = new UpdateOrderDto();
                    updateOrder.OrderId = item.Id;
                    updateOrder.StatusCode = OrderStatusCode.TRADE_FINISHED;
                    updateOrder.AppType = (byte)AppType.MiniProgram;
                    updateOrderList.Add(updateOrder);
                }
                await orderService.UpdateWithNoTranstionAsync(updateOrderList);
                #region 本人积分奖励
                decimal integrationPercent = 0m;
                var memberCard = await memberCardService.GetMemberCardHandelByCustomerIdAsync(customerId);
                if (memberCard != null)
                {
                    integrationPercent = memberCard.GenerateIntegrationPercent;
                }
                else
                {
                    var memberRank = await memberRankInfoService.GetMinGeneratePercentMemberRankInfoAsync();
                    integrationPercent = memberRank.GenerateIntegrationPercent;
                }
                foreach (var item in orderTrade.OrderInfoList)
                {
                    if (item.ExchangeType != 0 && item.ExchangeType != null)
                    {
                        var exist = await integrationAccountService.GetIsIntegrationGenerateRecordByOrderIdAndCustomerIdAsync(item.Id, customerId);
                        if (exist) throw new Exception("该订单已赠送过积分");
                        ConsumptionIntegrationDto consumptionIntegrationDto = new ConsumptionIntegrationDto
                        {
                            Quantity = Math.Floor(integrationPercent * (decimal)item.ActualPayment),
                            Percent = integrationPercent,
                            AmountOfConsumption = item.ActualPayment.Value,
                            Date = DateTime.Now,
                            CustomerId = customerId,
                            ExpiredDate = DateTime.Now.AddMonths(12),
                            OrderId = item.Id
                        };
                        await integrationAccountService.AddByConsumptionAsync(consumptionIntegrationDto);
                    }

                }
                #endregion
                #region 上级奖励积分
                /*if (!string.IsNullOrEmpty(userInfo.SuperiorId)) {
                    var superiorUserInfo = await customerService.GetCustomerByUserIdAsync(userInfo.SuperiorId);

                    decimal superiorIntegrationPercent = 0m;
                    var superiorMemberCard = await memberCardService.GetMemberCardHandelByCustomerIdAsync(superiorUserInfo.Id);
                    if (superiorMemberCard != null)
                    {
                        superiorIntegrationPercent = superiorMemberCard.ReferralsIntegrationPercent;
                    }
                    else
                    {
                        var memberRank = await memberRankInfoService.GetMinReferralsGeneratePercentMemberRankInfoAsync();
                        superiorIntegrationPercent = memberRank.ReferralsIntegrationPercent;
                    }
                    foreach (var item in orderTrade.OrderInfoList)
                    {
                        if (item.ExchangeType != 0 && item.ExchangeType != null)
                        {
                            var exist=await integrationAccountService.GetIsIntegrationGenerateRecordByOrderIdAndCustomerIdAsync(item.Id, superiorUserInfo.Id);
                            if (exist) throw new Exception("该订单已赠送过积分");
                            ConsumptionIntegrationDto consumptionIntegrationDto = new ConsumptionIntegrationDto
                            {
                                Quantity = Math.Floor(superiorIntegrationPercent * (decimal)item.ActualPayment),
                                Percent = superiorIntegrationPercent,
                                AmountOfConsumption = item.ActualPayment.Value,
                                Date = DateTime.Now,
                                CustomerId = superiorUserInfo.Id,
                                ExpiredDate = DateTime.Now.AddMonths(12),
                                OrderId = item.Id
                            };
                            await integrationAccountService.AddByConsumptionAsync(consumptionIntegrationDto);
                        }

                    }
                }*/
                #endregion
                #region 成长值奖励
                //foreach (var item in orderTrade.OrderInfoList)
                //{
                //    if (item.ExchangeType != 0 && item.ExchangeType != null)
                //    {
                //        if (item.ActualPayment.HasValue && item.ActualPayment.Value >= 1)
                //        {
                //            await taskService.CompleteShopOrderTaskAsync(customerId, item.ActualPayment.Value, item.Id);
                //        }
                //    }
                //}
                #endregion
                unitOfWork.Commit();
                return ResultData.Success();
            }
            catch (Exception)
            {
                unitOfWork.RollBack();
                throw new Exception("确认收货失败");
            }
        }
        /// <summary>
        /// 微信支付回调地址
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        [HttpPost("wxpay/{tradeId}")]
        public async Task<ResultData> WeiXinPayAsync(string tradeId)
        {
            var token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var orderTrade = await orderService.GetOrderTradeByTradeIdAsync(tradeId);
            List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
            foreach (var item in orderTrade.OrderInfoList)
            {
                if (item.ExchangeType == (byte)ExchangeType.Integration && item.IntegrationQuantity > 0)
                {
                    //积分余额
                    decimal integrationBalance = await integrationAccountService.GetIntegrationBalanceByCustomerIDAsync(customerId);
                    if (orderTrade.TotalIntegration > integrationBalance)
                        throw new Exception("积分余额不足");
                    UseIntegrationDto useIntegrationDto = new UseIntegrationDto();
                    useIntegrationDto.CustomerId = customerId;
                    useIntegrationDto.OrderId = item.Id;
                    useIntegrationDto.Date = DateTime.Now;
                    useIntegrationDto.UseQuantity = (decimal)item.IntegrationQuantity;
                    await integrationAccountService.UseByGoodsConsumption(useIntegrationDto);
                }
                UpdateOrderDto updateOrder = new UpdateOrderDto();
                updateOrder.OrderId = item.Id;
                updateOrder.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
                if (item.ActualPayment.HasValue)
                {
                    updateOrder.Actual_payment = item.ActualPayment.Value;

                    var bind = await _dalBindCustomerService.GetAll().FirstOrDefaultAsync(e => e.BuyerPhone == item.Phone);
                    if (bind != null)
                    {
                        bind.NewConsumptionDate = DateTime.Now;
                        bind.NewConsumptionContentPlatform = (int)OrderFrom.ThirdPartyOrder;
                        bind.NewContentPlatForm = ServiceClass.GetAppTypeText(item.AppType);
                        bind.AllPrice += item.ActualPayment.Value;
                        bind.AllOrderCount += item.Quantity;
                        await _dalBindCustomerService.UpdateAsync(bind, true);
                    }

                }
                if (item.IntegrationQuantity.HasValue)
                {
                    updateOrder.IntergrationQuantity = item.IntegrationQuantity;
                }
                Random random = new Random();
                updateOrder.AppType = item.AppType;
                updateOrder.WriteOffCode = random.Next().ToString().Substring(0, 8);
                updateOrderList.Add(updateOrder);
            }

            //修改订单状态
            await orderService.UpdateAsync(updateOrderList);

            UpdateOrderTradeDto updateOrderTrade = new UpdateOrderTradeDto();
            updateOrderTrade.TradeId = tradeId;
            updateOrderTrade.AddressId = orderTrade.AddressId;
            updateOrderTrade.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
            await orderService.UpdateOrderTradeAsync(updateOrderTrade);
            return ResultData.Success();
        }
        /// <summary>
        /// 订单退款
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        [HttpPost("refund")]
        public async Task<ResultData> OrderRefundAsync(RefundOrderVo refundOrder)
        {
            var token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            try
            {
                using (await _mutex.LockAsync())
                {
                    unitOfWork.BeginTransaction();
                    CreateRefundOrderDto createRefundOrderDto = new CreateRefundOrderDto();
                    createRefundOrderDto.CustomerId = customerId;
                    createRefundOrderDto.TradeId = refundOrder.TradeId;
                    createRefundOrderDto.OrderId = refundOrder.OrderId;
                    createRefundOrderDto.Remark = refundOrder.Remark;
                    var result = await orderRefundService.CreateRefundOrderAsync(createRefundOrderDto);
                    if (result.Result)
                    {
                        unitOfWork.Commit();
                        return ResultData.Success();
                    }
                    else
                    {
                        unitOfWork.RollBack();
                        return ResultData.Fail();
                    }
                }
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
    }
}