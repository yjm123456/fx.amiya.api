﻿using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.Balance;
using Fx.Amiya.Dto.DockingHospitalCustomerInfo;
using Fx.Amiya.Dto.HuiShouQianPay;
using Fx.Amiya.Dto.HuiShouQianPayNotify;
using Fx.Amiya.Dto.OperationLog;
using Fx.Amiya.Dto.Order;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Vo.Notify;
using Fx.Amiya.Modules.Integration.Domin;
using Fx.Amiya.Service;
using Fx.Common.Utils;
using Fx.Infrastructure.DataAccess;
using Fx.Open.Infrastructure.Web.Utils;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    /// <summary>
    /// 支付回调
    /// </summary>
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private IOrderService orderService;
        private IAliPayService _aliPayService;
        private ILogger<AliPayService> logger;
        private IBalanceRechargeService balanceRechargeRecordService;
        private IBalanceAccountService balanceAccountService;
        private IUnitOfWork unitOfWork;
        private IIntegrationAccount integrationAccount;
        private readonly IRechargeRewardRuleService rechargeRewardRuleService;
        private readonly IDalBindCustomerService _dalBindCustomerService;
        private readonly IDalWechatPayInfo dalWechatPayInfo;
        private readonly IOperationLogService operationLogService;
        private readonly IDockingHospitalCustomerInfoService dockingHospitalCustomerInfoService;
        private readonly IDalWxMpUserInfo dalWxMpUser;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IHuiShouQianPaymentService huiShouQianPaymentService;
        public NotifyController(IOrderService orderService,
            IAliPayService aliPayService,
            ILogger<AliPayService> logger, IBalanceRechargeService balanceRechargeRecordService, IBalanceAccountService balanceAccountService, IUnitOfWork unitOfWork, IIntegrationAccount integrationAccount, IRechargeRewardRuleService rechargeRewardRuleService, IDalBindCustomerService dalBindCustomerService, IDalWechatPayInfo dalWechatPayInfo, IOperationLogService operationLogService, IDockingHospitalCustomerInfoService dockingHospitalCustomerInfoService, IDalWxMpUserInfo dalWxMpUser, IHttpContextAccessor httpContextAccessor, IHuiShouQianPaymentService huiShouQianPaymentService)
        {
            this.orderService = orderService;
            _aliPayService = aliPayService;
            this.logger = logger;
            this.balanceRechargeRecordService = balanceRechargeRecordService;
            this.balanceAccountService = balanceAccountService;
            this.unitOfWork = unitOfWork;
            this.integrationAccount = integrationAccount;
            this.rechargeRewardRuleService = rechargeRewardRuleService;
            _dalBindCustomerService = dalBindCustomerService;
            this.dalWechatPayInfo = dalWechatPayInfo;
            this.operationLogService = operationLogService;
            this.dockingHospitalCustomerInfoService = dockingHospitalCustomerInfoService;
            this.dalWxMpUser = dalWxMpUser;
            this.httpContextAccessor = httpContextAccessor;
            this.huiShouQianPaymentService = huiShouQianPaymentService;
        }
        /// <summary>
        /// 支付宝订单回调地址
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("aliPayNotifyUrl")]
        public Task<string> aliPayNotifyUrlAsync([FromForm] AliPayNotifyVo input)
        {
            throw new Exception("不支持支付方式");
            //string notifyLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 开始回调，回调id：" + input.notify_id;
            //logger.LogInformation(notifyLog);
            //SortedDictionary<string, string> sPara = GetRequestPost(input);
            //var verifyResult = _aliPayService.Verify(sPara, input.notify_id, input.sign);
            //if (verifyResult.Result != true)
            //{
            //    return "fail";
            //}
            //if (input.body == "RECHARGE")
            //{
            //    //储值
            //    try
            //    {
            //        unitOfWork.BeginTransaction();
            //        var rechargeRecord = await balanceRechargeRecordService.GetRechargeRecordByIdAsync(input.out_trade_no);
            //        //如果订单记录状态为success直接返回success
            //        if (rechargeRecord.Status == (int)RechargeStatus.Success)
            //        {
            //            return "success";
            //        }
            //        UpdateRechargeRecordStatusDto update = new UpdateRechargeRecordStatusDto
            //        {
            //            Id = rechargeRecord.Id,
            //            Status = (int)RechargeStatus.Success,
            //            OrderId = input.trade_no,
            //            CompleteDate = DateTime.Now
            //        };
            //        //更新记录状态
            //        await balanceRechargeRecordService.UpdateRechargeRecordStatusAsync(update);
            //        //更新余额
            //        await balanceAccountService.UpdateAccountBalanceAsync(rechargeRecord.CustomerId);

            //        #region 储值奖励积分

            //        var totalRecharge = await balanceRechargeRecordService.GetAllRechargeAmountAsync(rechargeRecord.CustomerId);

            //        var rechargeRewardRuleList = await rechargeRewardRuleService.GetRewardListAsync();

            //        foreach (var rule in rechargeRewardRuleList)
            //        {
            //            if (totalRecharge >= rule.MinAmount)
            //            {
            //                var integrationRecord = await CreateIntegrationRecordAsync(rechargeRecord.CustomerId, rule.GiveIntegration, 1);
            //                if (integrationRecord != null) await integrationAccount.AddByConsumptionAsync(integrationRecord);
            //            }
            //        }

            //        #endregion

            //        unitOfWork.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        unitOfWork.RollBack();
            //        return "fail";
            //    }


            //}
            //else
            //{
            //    //商城下单
            //    var orderTrade = await orderService.GetOrderTradeByTradeIdAsync(input.out_trade_no);
            //    List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
            //    foreach (var item in orderTrade.OrderInfoList)
            //    {

            //        UpdateOrderDto updateOrder = new UpdateOrderDto();
            //        updateOrder.OrderId = item.Id;
            //        updateOrder.StatusCode = OrderStatusCode.TRADE_BUYER_PAID;
            //        if (item.ActualPayment.HasValue)
            //        {
            //            updateOrder.Actual_payment = item.ActualPayment.Value;
            //            var bind = await _dalBindCustomerService.GetAll().FirstOrDefaultAsync(e => e.BuyerPhone == item.Phone);
            //            if (bind != null)
            //            {
            //                bind.NewConsumptionDate = DateTime.Now;
            //                bind.NewConsumptionContentPlatform = (int)OrderFrom.ThirdPartyOrder;
            //                bind.NewContentPlatForm = ServiceClass.GetAppTypeText(item.AppType);
            //                bind.AllPrice += item.ActualPayment.Value;
            //                bind.AllOrderCount += item.Quantity;
            //                await _dalBindCustomerService.UpdateAsync(bind, true);
            //            }
            //        }
            //        if (item.IntegrationQuantity.HasValue)
            //        {
            //            updateOrder.IntergrationQuantity = item.IntegrationQuantity;
            //        }
            //        Random random = new Random();
            //        updateOrder.AppType = item.AppType;
            //        updateOrder.WriteOffCode = random.Next().ToString().Substring(0, 8);
            //        updateOrderList.Add(updateOrder);
            //    }

            //    //修改订单状态
            //    await orderService.UpdateAsync(updateOrderList);

            //    UpdateOrderTradeDto updateOrderTrade = new UpdateOrderTradeDto();
            //    updateOrderTrade.TradeId = input.out_trade_no;
            //    updateOrderTrade.AddressId = orderTrade.AddressId;
            //    updateOrderTrade.StatusCode = OrderStatusCode.TRADE_BUYER_PAID;
            //    await orderService.UpdateOrderTradeAsync(updateOrderTrade);
            //}
            //return "success";
        }
        /// <summary>
        /// 创建储值奖励记录
        /// </summary>
        /// <param name="awardAmount">储值奖励金额</param>
        /// <param name="customerId">用户id</param>
        /// <param name="accountBalance">账户操作前余额</param>
        /// <returns></returns>
       /* private async Task<CreateBalanceRechargeRecordDto> CreateRecordAsync(decimal awardAmount,string customerId,decimal accountBalance) {
            var awardRecord = await balanceRechargeRecordService.GetRechargeRecordByExchangeTypeAsync(customerId, 3);
            var record = awardRecord.Find(e => e.RechargeAmount == awardAmount);
            if (record == null)
            {
                CreateBalanceRechargeRecordDto createBalanceRechargeRecordDto = new CreateBalanceRechargeRecordDto
                {
                    Id = CreateOrderIdHelper.GetNextNumber(),
                    CustomerId=customerId,
                    ExchangeType=3,
                    RechargeAmount=awardAmount,
                    Balance=accountBalance,
                    RechargeDate=DateTime.Now,
                    Status=1
                };
                return createBalanceRechargeRecordDto;
            }
            else {
                return null;
            }
        }*/
        /// <summary>
        /// 创建积分奖励记录
        /// </summary>
        /// <param name="customerId">用户id</param>
        /// <param name="awardAmount">奖励积分金额</param>
        /// <param name="percent">奖励比率</param>
        /// <returns></returns>
        private async Task<ConsumptionIntegrationDto> CreateIntegrationRecordAsync(string customerId, decimal awardAmount, decimal percent)
        {
            var exist = await integrationAccount.ExistRechargeRewardAsync(customerId, awardAmount, percent);
            if (exist)
            {
                return null;
            }
            ConsumptionIntegrationDto consumptionIntegrationDto = new ConsumptionIntegrationDto
            {
                Quantity = awardAmount,
                Percent = 1,
                AmountOfConsumption = awardAmount,
                Date = DateTime.Now,
                CustomerId = customerId,
                ExpiredDate = DateTime.Now.AddMonths(12),
            };
            return consumptionIntegrationDto;
        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        private SortedDictionary<string, string> GetRequestPost(AliPayNotifyVo input)
        {
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            sArray.Add("notify_id", input.notify_id);
            sArray.Add("notify_time", input.notify_time);
            sArray.Add("notify_type", input.notify_type);
            sArray.Add("sign_type", input.sign_type);
            sArray.Add("sign", input.sign);
            sArray.Add("out_trade_no", input.out_trade_no);
            sArray.Add("subject", input.subject);
            sArray.Add("payment_type", input.payment_type);
            sArray.Add("trade_no", input.trade_no);
            sArray.Add("trade_status", input.trade_status);
            sArray.Add("gmt_create", input.gmt_create);
            sArray.Add("gmt_payment", input.gmt_payment);
            sArray.Add("gmt_close", input.gmt_close);
            sArray.Add("seller_email", input.seller_email);
            sArray.Add("buyer_email", input.buyer_email);
            sArray.Add("seller_id", input.seller_id);
            sArray.Add("buyer_id", input.buyer_id);
            sArray.Add("price", input.price);
            sArray.Add("total_fee", input.total_fee);
            sArray.Add("quantity", input.quantity);
            sArray.Add("body", input.body);
            sArray.Add("discount", input.discount);
            sArray.Add("is_total_fee_adjust", input.is_total_fee_adjust);
            sArray.Add("use_coupon", input.use_coupon);
            sArray.Add("refund_status", input.refund_status);
            sArray.Add("gmt_refund", input.gmt_refund);

            return sArray;
        }
        /// <summary>
        /// 微信充值订单回调
        /// </summary>
        /// <returns></returns>
        [HttpPost("rechargepayresult")]
        public Task<string> PayRechargeNotifyUrl()
        {
            throw new Exception("暂不支持充值");
            //try
            //{
            //    return "<xml><return_code><![CDATA[FAIL]]></return_code><return_msg><![CDATA[ERROR]]></return_msg></xml>";
            //    //获取回调POST过来的xml数据的代码
            //    using Stream stream = HttpContext.Request.Body;
            //    byte[] buffer = new byte[HttpContext.Request.ContentLength.Value];
            //    await stream.ReadAsync(buffer);
            //    string xml = System.Text.Encoding.UTF8.GetString(buffer);
            //    XmlDocument xmlDoc = new XmlDocument();
            //    xmlDoc.LoadXml(xml);
            //    WeiXinPayNotifyVo weiXinPayNotifyVo = GetWeiXinRequestPostData(xmlDoc);
            //    SortedDictionary<string, string> sParam = GetWeiXinRequestPostDic(weiXinPayNotifyVo);
            //    SignHelper signHelper = new SignHelper();
            //    //签名验证
            //    string sign = await signHelper.SignPay(sParam, "");
            //    if (sign != weiXinPayNotifyVo.sign)
            //        return "<xml><return_code><![CDATA[FAIL]]></return_code><return_msg><![CDATA[ERROR]]></return_msg></xml>";
            //    unitOfWork.BeginTransaction();
            //    // 业务逻辑
            //    //成功通知微信
            //    if (weiXinPayNotifyVo.return_code.ToUpper() == "SUCCESS")
            //    {
            //        var record = await balanceRechargeRecordService.GetRechargeRecordByIdAsync(weiXinPayNotifyVo.out_trade_no);

            //        if (record == null) throw new Exception("没有找到该用户的充值信息");
            //        if (record.Status == 1)
            //            return "<xml><return_code><![CDATA[SUCCESS]]></return_code><return_msg><![CDATA[OK]]></return_msg></xml>";
            //        UpdateRechargeRecordStatusDto updateRechargeRecord = new UpdateRechargeRecordStatusDto();
            //        updateRechargeRecord.Id = record.Id;
            //        updateRechargeRecord.OrderId = weiXinPayNotifyVo.transaction_id;
            //        updateRechargeRecord.Status = 1;
            //        updateRechargeRecord.CompleteDate = DateTime.Now;
            //        await balanceRechargeRecordService.UpdateRechargeRecordStatusAsync(updateRechargeRecord);
            //        //更新余额
            //        await balanceAccountService.UpdateAccountBalanceAsync(record.CustomerId);

            //        #region 储值奖励积分

            //        var totalRecharge = await balanceRechargeRecordService.GetAllRechargeAmountAsync(record.CustomerId);

            //        var rechargeRewardRuleList = await rechargeRewardRuleService.GetRewardListAsync();

            //        foreach (var rule in rechargeRewardRuleList)
            //        {
            //            if (totalRecharge >= rule.MinAmount)
            //            {
            //                var integrationRecord = await CreateIntegrationRecordAsync(record.CustomerId, rule.GiveIntegration, 1);
            //                if (integrationRecord != null) await integrationAccount.AddByConsumptionAsync(integrationRecord);
            //            }
            //        }

            //        #endregion

            //    }
            //    unitOfWork.Commit();
            //    return "<xml><return_code><![CDATA[SUCCESS]]></return_code><return_msg><![CDATA[OK]]></return_msg></xml>";
            //}
            //catch (Exception e)
            //{
            //    unitOfWork.RollBack();
            //    return "<xml><return_code><![CDATA[FAIL]]></return_code><return_msg><![CDATA[ERROR]]></return_msg></xml>";
            //}
        }
        /// <summary>
        /// 微信订单付款回调
        /// </summary>
        /// <returns></returns>
        [HttpPost("orderpayresult")]
        public async Task<string> PayOrderNotifyUrl()
        {

            try
            {

                bool isMaterialOrder = false;
                //获取回调POST过来的xml数据的代码
                using Stream stream = HttpContext.Request.Body;
                byte[] buffer = new byte[HttpContext.Request.ContentLength.Value];
                await stream.ReadAsync(buffer, 0, buffer.Length);
                string xml = System.Text.Encoding.UTF8.GetString(buffer);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                WeiXinPayNotifyVo weiXinPayNotifyVo = GetWeiXinRequestPostData(xmlDoc);
                SortedDictionary<string, string> sParam = GetWeiXinRequestPostDic(weiXinPayNotifyVo);
                SignHelper signHelper = new SignHelper();
                var wechatPayinfo = dalWechatPayInfo.GetAll().Where(e => e.AppId == "wx8747b7f34c0047eb").FirstOrDefault();
                //签名验证
                string sign = await signHelper.SignPay(sParam, wechatPayinfo.PartnerKey);
                if (sign != weiXinPayNotifyVo.sign) return "<xml><return_code><![CDATA[FAIL]]></return_code><return_msg><![CDATA[ERROR]]></return_msg></xml>";

                // 业务逻辑
                //成功通知微信
                if (weiXinPayNotifyVo.return_code.ToUpper() == "SUCCESS")
                {
                    var orderTrade = await orderService.GetOrderTradeByTradeIdAsync(weiXinPayNotifyVo.attach);
                    if (orderTrade.StatusCode == OrderStatusCode.WAIT_BUYER_PAY)
                    {
                        List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
                        foreach (var item in orderTrade.OrderInfoList)
                        {
                            UpdateOrderDto updateOrder = new UpdateOrderDto();
                            updateOrder.OrderId = item.Id;
                            if (item.OrderType == (byte)OrderType.MaterialOrder)
                            {
                                updateOrder.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
                                isMaterialOrder = true;
                            }
                            else if (item.OrderType == (byte)OrderType.VirtualOrder)
                            {
                                updateOrder.StatusCode = OrderStatusCode.TRADE_BUYER_PAID;
                                //虚拟商品添加发货信息
                                OperationAddDto operationLog = new OperationAddDto();
                                UploadMiniprogramOrderInfoDto uploadMiniprogramOrderInfo = new UploadMiniprogramOrderInfoDto();
                                try
                                {
                                    operationLog.OperationBy = null;

                                    OrderKey orderKey = new OrderKey();
                                    if (orderTrade.AppId == "wx695942e4818de445")
                                    {
                                        orderKey.mchid = "1634868495";
                                    }
                                    else if (orderTrade.AppId == "wx8747b7f34c0047eb")
                                    {
                                        orderKey.mchid = "1633229187";
                                    }


                                    orderKey.transaction_id = weiXinPayNotifyVo.transaction_id;
                                    uploadMiniprogramOrderInfo.order_key = orderKey;
                                    uploadMiniprogramOrderInfo.logistics_type = 1;

                                    uploadMiniprogramOrderInfo.delivery_mode = 1;
                                    uploadMiniprogramOrderInfo.is_all_delivered = true;
                                    ShippingInfo shippingInfo = new ShippingInfo();
                                    shippingInfo.item_desc = item.GoodsName;
                                    Contact contact = new Contact();
                                    contact.receiver_contact = ServiceClass.GetIncompletePhone(orderTrade.Phone);
                                    shippingInfo.contact = contact;
                                    uploadMiniprogramOrderInfo.shipping_list = new List<ShippingInfo> { shippingInfo };
                                    uploadMiniprogramOrderInfo.upload_time = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK");
                                    uploadMiniprogramOrderInfo.payer = new PayerInfo() { openid = dalWxMpUser.GetAll().Where(e => e.UserId == orderTrade.UserId).FirstOrDefault().OpenId };
                                    await this.UploadMiniprogramOrderInfoAsync(uploadMiniprogramOrderInfo, orderTrade.AppId);
                                }
                                catch (Exception ex)
                                {
                                    operationLog.Message = ex.Message;
                                    operationLog.Code = -1;

                                }
                                finally
                                {
                                    operationLog.Parameters = JsonConvert.SerializeObject(uploadMiniprogramOrderInfo);
                                    operationLog.RequestType = (int)RequestType.Update;
                                    operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                                    await operationLogService.AddOperationLogAsync(operationLog);
                                }
                            }
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
                        updateOrderTrade.TradeId = weiXinPayNotifyVo.out_trade_no;
                        updateOrderTrade.AddressId = orderTrade.AddressId;
                        if (isMaterialOrder)
                        {
                            updateOrderTrade.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
                        }
                        else
                        {
                            updateOrderTrade.StatusCode = OrderStatusCode.TRADE_BUYER_PAID;

                        }
                        await orderService.UpdateOrderTradeAsync(updateOrderTrade);
                    }
                    await orderService.TradeAddChanelOrderNoAsync(orderTrade.TradeId, weiXinPayNotifyVo.transaction_id);
                }

                return "<xml><return_code><![CDATA[SUCCESS]]></return_code><return_msg><![CDATA[OK]]></return_msg></xml>";
            }
            catch (Exception e)
            {
                return "<xml><return_code><![CDATA[FAIL]]></return_code><return_msg><![CDATA[ERROR]]></return_msg></xml>"; //回调失败返回给微信
                throw new Exception(e.Message.ToString());
            }
        }
        /// <summary>
        /// 获取微信回调参数
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        private WeiXinPayNotifyVo GetWeiXinRequestPostData(XmlDocument xmlDoc)
        {
            WeiXinPayNotifyVo weiXinPayNotifyVo = new WeiXinPayNotifyVo();
            weiXinPayNotifyVo.return_code = xmlDoc.DocumentElement.GetElementsByTagName("return_code")[0].InnerText;
            weiXinPayNotifyVo.out_trade_no = xmlDoc.DocumentElement.GetElementsByTagName("out_trade_no")[0].InnerText;
            weiXinPayNotifyVo.transaction_id = xmlDoc.DocumentElement.GetElementsByTagName("transaction_id")[0].InnerText;
            weiXinPayNotifyVo.total_fee = xmlDoc.DocumentElement.GetElementsByTagName("total_fee")[0].InnerText;
            weiXinPayNotifyVo.appid = xmlDoc.DocumentElement.GetElementsByTagName("appid")[0].InnerText;
            weiXinPayNotifyVo.bank_type = xmlDoc.DocumentElement.GetElementsByTagName("bank_type")[0].InnerText;
            weiXinPayNotifyVo.cash_fee = xmlDoc.DocumentElement.GetElementsByTagName("cash_fee")[0].InnerText;
            weiXinPayNotifyVo.fee_type = xmlDoc.DocumentElement.GetElementsByTagName("fee_type")[0].InnerText;
            weiXinPayNotifyVo.is_subscribe = xmlDoc.DocumentElement.GetElementsByTagName("is_subscribe")[0].InnerText;
            weiXinPayNotifyVo.mch_id = xmlDoc.DocumentElement.GetElementsByTagName("mch_id")[0].InnerText;
            weiXinPayNotifyVo.nonce_str = xmlDoc.DocumentElement.GetElementsByTagName("nonce_str")[0].InnerText;
            weiXinPayNotifyVo.openid = xmlDoc.DocumentElement.GetElementsByTagName("openid")[0].InnerText;
            weiXinPayNotifyVo.result_code = xmlDoc.DocumentElement.GetElementsByTagName("result_code")[0].InnerText;
            weiXinPayNotifyVo.time_end = xmlDoc.DocumentElement.GetElementsByTagName("time_end")[0].InnerText;
            weiXinPayNotifyVo.trade_type = xmlDoc.DocumentElement.GetElementsByTagName("trade_type")[0].InnerText;
            weiXinPayNotifyVo.sign = xmlDoc.DocumentElement.GetElementsByTagName("sign")[0].InnerText;
            weiXinPayNotifyVo.attach = xmlDoc.DocumentElement.GetElementsByTagName("attach")[0].InnerText;
            return weiXinPayNotifyVo;
        }
        /// <summary>
        /// 微信回调参数转换为有序字典
        /// </summary>
        /// <param name="weiXinPayNotifyVo"></param>
        /// <returns></returns>
        private SortedDictionary<string, string> GetWeiXinRequestPostDic(WeiXinPayNotifyVo weiXinPayNotifyVo)
        {
            SortedDictionary<string, string> sDic = new SortedDictionary<string, string>();
            sDic.Add("appid", weiXinPayNotifyVo.appid);
            sDic.Add("mch_id", weiXinPayNotifyVo.mch_id);
            sDic.Add("nonce_str", weiXinPayNotifyVo.nonce_str);
            sDic.Add("result_code", weiXinPayNotifyVo.result_code);
            sDic.Add("openid", weiXinPayNotifyVo.openid);
            sDic.Add("trade_type", weiXinPayNotifyVo.trade_type);
            sDic.Add("bank_type", weiXinPayNotifyVo.bank_type);
            sDic.Add("total_fee", weiXinPayNotifyVo.total_fee);
            sDic.Add("cash_fee", weiXinPayNotifyVo.cash_fee);
            sDic.Add("transaction_id", weiXinPayNotifyVo.transaction_id);
            sDic.Add("out_trade_no", weiXinPayNotifyVo.out_trade_no);
            sDic.Add("time_end", weiXinPayNotifyVo.time_end);
            sDic.Add("fee_type", weiXinPayNotifyVo.fee_type);
            sDic.Add("is_subscribe", weiXinPayNotifyVo.is_subscribe);
            sDic.Add("return_code", weiXinPayNotifyVo.return_code);
            sDic.Add("attach", weiXinPayNotifyVo.attach);
            return sDic;
        }
        /// <summary>
        /// 慧收钱支付回调
        /// </summary>
        /// <returns></returns>
        [HttpPost("hsqPayResult")]
        public async Task<string> HSQPayOrderNotifyUrl()
        {
            OperationAddDto operationLog2 = new OperationAddDto();
            HuiShouQianNotifyParam notifyParam = new HuiShouQianNotifyParam();
            try
            {
                operationLog2.OperationBy = null;
                operationLog2.Code = 0;
                HuiShouQianPackageInfo huiShouQianPackageInfo = new HuiShouQianPackageInfo();
                var payInfo = dalWechatPayInfo.GetAll().Where(e => e.Id == "202306281235").FirstOrDefault();
                huiShouQianPackageInfo.Key = payInfo.PartnerKey;
                huiShouQianPackageInfo.PrivateKey = payInfo.PrivateKey;
                huiShouQianPackageInfo.PublicKey = payInfo.PublickKey;
                using Stream stream = HttpContext.Request.Body;
                byte[] buffer = new byte[HttpContext.Request.ContentLength.Value];
                await stream.ReadAsync(buffer);
                string notify = System.Text.Encoding.UTF8.GetString(buffer);
                notify = HttpUtility.UrlDecode(notify);
                var list = notify.Split("&");
                string signContent = "";
                string sign = "";
                foreach (var item in list)
                {
                    var arr = item.Split("=");
                    if (arr[0] == "signContent")
                    {
                        signContent = arr[1];
                    }
                    if (arr[0] == "sign")
                    {
                        sign = arr[1];
                    }
                }
                notifyParam = JsonConvert.DeserializeObject<HuiShouQianNotifyParam>(signContent);
                var signContent1 = BuildPayParamString("CALLBACK", "1.0.0", "JSON", payInfo.AppId, "RSA2", signContent, huiShouQianPackageInfo.Key);
                RSAHelper rsa = new RSAHelper(RSAType.RSA2, Encoding.UTF8, huiShouQianPackageInfo.PrivateKey, huiShouQianPackageInfo.PublicKey);
                var verify = rsa.Verify(signContent1, sign);
                if (verify)
                {
                    if (notifyParam.extend == "RECHARGE" && notifyParam.orderStatus.ToUpper() == "SUCCESS")
                    {
                        //储值
                        try
                        {
                            unitOfWork.BeginTransaction();
                            var rechargeRecord = await balanceRechargeRecordService.GetRechargeRecordByIdAsync(notifyParam.transNo);
                            //如果订单记录状态为success直接返回success
                            if (rechargeRecord.Status == (int)RechargeStatus.Success)
                            {
                                return "SUCCESS";
                            }
                            UpdateRechargeRecordStatusDto update = new UpdateRechargeRecordStatusDto
                            {
                                Id = rechargeRecord.Id,
                                Status = (int)RechargeStatus.Success,
                                OrderId = notifyParam.tradeNo,
                                CompleteDate = DateTime.Now
                            };
                            //更新记录状态
                            await balanceRechargeRecordService.UpdateRechargeRecordStatusAsync(update);
                            //更新余额
                            await balanceAccountService.UpdateAccountBalanceAsync(rechargeRecord.CustomerId);

                            #region 储值奖励积分

                            var totalRecharge = await balanceRechargeRecordService.GetAllRechargeAmountAsync(rechargeRecord.CustomerId);

                            var rechargeRewardRuleList = await rechargeRewardRuleService.GetRewardListAsync();

                            foreach (var rule in rechargeRewardRuleList)
                            {
                                if (totalRecharge >= rule.MinAmount)
                                {
                                    var integrationRecord = await CreateIntegrationRecordAsync(rechargeRecord.CustomerId, rule.GiveIntegration, 1);
                                    if (integrationRecord != null) await integrationAccount.AddByConsumptionAsync(integrationRecord);
                                }
                            }

                            #endregion

                            unitOfWork.Commit();
                        }
                        catch (Exception ex)
                        {
                            unitOfWork.RollBack();
                            return "fail";
                        }
                    }
                    else
                    {
                        if (notifyParam.orderStatus.ToUpper() == "SUCCESS")
                        {
                            bool isMaterialOrder = false;
                            var orderTrade = await orderService.GetOrderTradeByTradeIdAsync(notifyParam.extend);
                            if (orderTrade.StatusCode == OrderStatusCode.WAIT_BUYER_PAY)
                            {
                                List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
                                foreach (var item in orderTrade.OrderInfoList)
                                {
                                    UpdateOrderDto updateOrder = new UpdateOrderDto();
                                    updateOrder.OrderId = item.Id;
                                    if (item.OrderType == (byte)OrderType.MaterialOrder)
                                    {
                                        updateOrder.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
                                        isMaterialOrder = true;
                                    }
                                    else if (item.OrderType == (byte)OrderType.VirtualOrder)
                                    {
                                        updateOrder.StatusCode = OrderStatusCode.TRADE_BUYER_PAID;
                                        OperationAddDto operationLog = new OperationAddDto();
                                        UploadMiniprogramOrderInfoDto uploadMiniprogramOrderInfo = new UploadMiniprogramOrderInfoDto();
                                        try
                                        {
                                            operationLog.OperationBy = null;

                                            OrderKey orderKey = new OrderKey();
                                            if (orderTrade.AppId == "wx695942e4818de445")
                                            {
                                                orderKey.mchid = "1634868495";
                                            }
                                            else if (orderTrade.AppId == "wx8747b7f34c0047eb")
                                            {
                                                orderKey.mchid = "1633229187";
                                            }

                                            orderKey.transaction_id = notifyParam.payOrderNo;
                                            uploadMiniprogramOrderInfo.order_key = orderKey;
                                            uploadMiniprogramOrderInfo.logistics_type = 3;
                                            uploadMiniprogramOrderInfo.delivery_mode = 1;
                                            uploadMiniprogramOrderInfo.is_all_delivered = true;
                                            ShippingInfo shippingInfo = new ShippingInfo();
                                            shippingInfo.item_desc = item.GoodsName;
                                            Contact contact = new Contact();
                                            contact.receiver_contact = ServiceClass.GetIncompletePhone(orderTrade.Phone);
                                            shippingInfo.contact = contact;
                                            uploadMiniprogramOrderInfo.shipping_list = new List<ShippingInfo> { shippingInfo };
                                            uploadMiniprogramOrderInfo.upload_time = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK");
                                            uploadMiniprogramOrderInfo.payer = new PayerInfo() { openid = dalWxMpUser.GetAll().Where(e => e.UserId == orderTrade.UserId).FirstOrDefault().OpenId };
                                            await this.UploadMiniprogramOrderInfoAsync(uploadMiniprogramOrderInfo, orderTrade.AppId);
                                        }
                                        catch (Exception ex)
                                        {
                                            operationLog.Message = ex.Message;
                                            operationLog.Code = -1;

                                        }
                                        finally
                                        {
                                            operationLog.Parameters = JsonConvert.SerializeObject(uploadMiniprogramOrderInfo);
                                            operationLog.RequestType = (int)RequestType.Pay;
                                            operationLog.Source = (int)RequestSource.AmiyaBackground;
                                            operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                                            await operationLogService.AddOperationLogAsync(operationLog);
                                        }
                                    }
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
                                updateOrderTrade.TradeId = notifyParam.extend;
                                updateOrderTrade.AddressId = orderTrade.AddressId;
                                if (isMaterialOrder)
                                {
                                    updateOrderTrade.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
                                }
                                else
                                {
                                    updateOrderTrade.StatusCode = OrderStatusCode.TRADE_BUYER_PAID;
                                }

                                await orderService.UpdateOrderTradeAsync(updateOrderTrade);
                                await orderService.TradeAddChanelOrderNoAsync(orderTrade.TradeId, notifyParam.payOrderNo);
                            }
                            //UploadMiniprogramOrderInfoDto uploadMiniprogramOrderInfo = new UploadMiniprogramOrderInfoDto();
                            //OrderKey orderKey = new OrderKey();
                            //orderKey.mchid = "1634868495";
                            //orderKey.out_trade_no = orderTrade.TransNo;
                            //uploadMiniprogramOrderInfo.order_key = orderKey;
                            //uploadMiniprogramOrderInfo.logistics_type = 3;
                            //if (orderTrade.OrderInfoList.Count() == 1)
                            //{
                            //    uploadMiniprogramOrderInfo.delivery_mode = 1;
                            //    uploadMiniprogramOrderInfo.is_all_delivered = true;
                            //}
                            //else if (orderTrade.OrderInfoList.Count() > 1)
                            //{
                            //    uploadMiniprogramOrderInfo.delivery_mode = 2;
                            //    if (!orderTrade.OrderInfoList.Select(e => e.StatusCode).Contains(OrderStatusCode.WAIT_SELLER_SEND_GOODS) && !orderTrade.OrderInfoList.Select(e => e.StatusCode).Contains(OrderStatusCode.TRADE_BUYER_PAID) && orderTrade.StatusCode == OrderStatusCode.WAIT_SELLER_SEND_GOODS)
                            //    {
                            //        uploadMiniprogramOrderInfo.is_all_delivered = true;
                            //    }
                            //    else
                            //    {
                            //        uploadMiniprogramOrderInfo.is_all_delivered = false;
                            //    }
                            //}
                            //ShippingInfo shippingInfo = new ShippingInfo();                            
                            //shippingInfo.item_desc = order.GoodsName;
                            //Contact contact = new Contact();
                            //contact.receiver_contact = ServiceClass.GetIncompletePhone(orderTrade.Address.Phone);
                            //shippingInfo.contact = contact;
                            //uploadMiniprogramOrderInfo.shipping_list = new List<ShippingInfo> { shippingInfo };
                            //uploadMiniprogramOrderInfo.upload_time = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK");
                            //uploadMiniprogramOrderInfo.payer = new PayerInfo() { openid = dalWxMpUser.GetAll().Where(e => e.UserId == orderTrade.CustomerInfo.UserId).FirstOrDefault().OpenId };
                        }
                    }

                    return "SUCCESS";
                }
                else
                {
                    return "Fail";
                }

            }
            catch (Exception ex)
            {
                operationLog2.Message = ex.Message;
                operationLog2.Code = -1;
                return "Fail";
            }
            finally
            {
                operationLog2.Source = (int)RequestSource.AmiyaBackground;
                operationLog2.Parameters = JsonConvert.SerializeObject(notifyParam);
                operationLog2.RequestType = (int)RequestType.Pay;
                operationLog2.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                await operationLogService.AddOperationLogAsync(operationLog2);
            }
        }

        private async Task UploadMiniprogramOrderInfoAsync(UploadMiniprogramOrderInfoDto uploadInfo, string appId)
        {
            var appInfo = new DockingHospitalCustomerInfoDto();
            if (appId == "wx695942e4818de445")
            {
                appInfo = await dockingHospitalCustomerInfoService.GetMiniProgramAccessTokenInfo(192);
            }
            else if (appId == "wx8747b7f34c0047eb")
            {
                appInfo = await dockingHospitalCustomerInfoService.GetMiniProgramAccessTokenInfo(84);
            }
            var requestUrl = $"https://api.weixin.qq.com/wxa/sec/order/upload_shipping_info?access_token={appInfo.AccessToken}";
            var result = HttpUtil.HTTPJsonPost(requestUrl, JsonConvert.SerializeObject(uploadInfo));
        }
        /// <summary>
        /// 获取小程序对应的物流公司信息
        /// </summary>
        /// <returns></returns>
        private async Task<List<BaseKeyValueDto<string>>> GetDeliveryList()
        {
            var appInfo = await dockingHospitalCustomerInfoService.GetMiniProgramAccessTokenInfo(192);
            var requestUrl = $"https://api.weixin.qq.com/cgi-bin/express/delivery/open_msg/get_delivery_list?access_token={appInfo.AccessToken}";
            var result = HttpUtil.HTTPJsonPost(requestUrl, "{}");
            Console.WriteLine();
            return JsonConvert.DeserializeObject<DeliveryInfoDto>(result).delivery_list.Select(e => new BaseKeyValueDto<string>
            {
                Key = e.delivery_id,
                Value = e.delivery_name
            }).ToList();
        }

        /// <summary>
        /// 拼接回调请求参数
        /// </summary>
        /// <param name="method"></param>
        /// <param name="version"></param>
        /// <param name="format"></param>
        /// <param name="merchantNo"></param>
        /// <param name="signType"></param>
        /// <param name="signContent"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string BuildPayParamString(string method, string version, string format, string merchantNo, string signType, string signContent, string key)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("method=");
            builder.Append(method);
            builder.Append("&version=");
            builder.Append(version);
            builder.Append("&format=");
            builder.Append(format);
            builder.Append("&merchantNo=");
            builder.Append(merchantNo);
            builder.Append("&signType=");
            builder.Append(signType);
            builder.Append("&signContent=");
            builder.Append(signContent);
            builder.Append("&key=");
            builder.Append(key);
            return builder.ToString();
        }
        /// <summary>
        /// 杉德支付回调
        /// </summary>
        /// <returns></returns>
        [HttpGet("shanDePayResultNotify")]
        public async Task<string> SDPayResult()
        {
            OperationAddDto operationAddDto = new OperationAddDto();
            operationAddDto.Code = 0;
            try
            {
                bool isMaterialOrder = false;
                var query = HttpContext.Request.Query;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                string sign = "";
                foreach (var item in query)
                {
                    if (item.Key == "sign")
                    {
                        sign = HttpUtility.UrlDecode(item.Value);
                        continue;
                    }
                    dic.Add(item.Key, HttpUtility.UrlDecode(item.Value));
                }
                SignHelper signHelper = new SignHelper();
                var signContent = await signHelper.BuildQueryAsync(dic, false);
                var payInfo = dalWechatPayInfo.GetAll().Where(e => e.Id == "202307072015").FirstOrDefault();
                if (payInfo == null) throw new Exception("没有该支付方式配置信息！");
                var result = RSAFromPkcs8Helper.Verify(signContent, sign, payInfo.PublickKey, "UTF-8");
                if (result == true)
                {
                    var tradeStatus = "";
                    dic.TryGetValue("trade_status", out tradeStatus);

                    if (tradeStatus == "SUCCESS")
                    {
                        var tradeId = "";
                        dic.TryGetValue("req_reserved", out tradeId);
                        var orderTrade = await orderService.GetOrderTradeByTradeIdAsync(tradeId);
                        if (orderTrade.StatusCode == OrderStatusCode.WAIT_BUYER_PAY)
                        {
                            List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
                            foreach (var item in orderTrade.OrderInfoList)
                            {
                                UpdateOrderDto updateOrder = new UpdateOrderDto();
                                updateOrder.OrderId = item.Id;
                                if (item.OrderType == (byte)OrderType.MaterialOrder)
                                {
                                    updateOrder.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
                                    isMaterialOrder = true;
                                }
                                else if (item.OrderType == (byte)OrderType.VirtualOrder)
                                {
                                    updateOrder.StatusCode = OrderStatusCode.TRADE_BUYER_PAID;

                                    //虚拟商品添加发货信息
                                    OperationAddDto operationLog = new OperationAddDto();
                                    UploadMiniprogramOrderInfoDto uploadMiniprogramOrderInfo = new UploadMiniprogramOrderInfoDto();
                                    try
                                    {
                                        operationLog.OperationBy = null;

                                        OrderKey orderKey = new OrderKey();
                                        if (orderTrade.AppId == "wx695942e4818de445")
                                        {
                                            orderKey.mchid = "1634868495";
                                        }
                                        else if (orderTrade.AppId == "wx8747b7f34c0047eb")
                                        {
                                            orderKey.mchid = "1633229187";
                                        }

                                        orderKey.out_trade_no = orderTrade.ChanelOrderNo;
                                        uploadMiniprogramOrderInfo.order_key = orderKey;
                                        uploadMiniprogramOrderInfo.logistics_type = 1;
                                        uploadMiniprogramOrderInfo.delivery_mode = 1;
                                        uploadMiniprogramOrderInfo.is_all_delivered = true;
                                        ShippingInfo shippingInfo = new ShippingInfo();
                                        shippingInfo.item_desc = item.GoodsName;
                                        Contact contact = new Contact();
                                        contact.receiver_contact = ServiceClass.GetIncompletePhone(orderTrade.Phone);
                                        shippingInfo.contact = contact;
                                        uploadMiniprogramOrderInfo.shipping_list = new List<ShippingInfo> { shippingInfo };
                                        uploadMiniprogramOrderInfo.upload_time = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK");
                                        uploadMiniprogramOrderInfo.payer = new PayerInfo() { openid = dalWxMpUser.GetAll().Where(e => e.UserId == orderTrade.UserId).FirstOrDefault().OpenId };
                                        await this.UploadMiniprogramOrderInfoAsync(uploadMiniprogramOrderInfo, orderTrade.AppId);
                                    }
                                    catch (Exception ex)
                                    {
                                        operationLog.Message = ex.Message;
                                        operationLog.Code = -1;

                                    }
                                    finally
                                    {
                                        operationLog.Parameters = JsonConvert.SerializeObject(uploadMiniprogramOrderInfo);
                                        operationLog.RequestType = (int)RequestType.Update;
                                        operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
                                        await operationLogService.AddOperationLogAsync(operationLog);
                                    }
                                }
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
                            if (isMaterialOrder)
                            {
                                updateOrderTrade.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
                            }
                            else
                            {
                                updateOrderTrade.StatusCode = OrderStatusCode.TRADE_BUYER_PAID;

                            }
                            await orderService.UpdateOrderTradeAsync(updateOrderTrade);
                        }
                        else
                        {
                            operationAddDto.Parameters = query.ToString();
                            operationAddDto.Code = -1;
                            operationAddDto.RouteAddress = "杉德支付回调请求";
                            operationAddDto.RequestType = (int)RequestType.Pay;
                            operationAddDto.Message = $"支付成功订单:{tradeId}状态已改变当前订单状态为{orderTrade.StatusCode}";
                            operationAddDto.OperationBy = null;
                            operationAddDto.Source = (int)RequestSource.AmiyaBackground;
                            await operationLogService.AddOperationLogAsync(operationAddDto);
                        }
                    }
                    else
                    {
                        operationAddDto.Parameters = query.ToString();
                        operationAddDto.Code = -1;
                        operationAddDto.RouteAddress = "杉德支付回调请求";
                        operationAddDto.RequestType = (int)RequestType.Pay;
                        operationAddDto.Message = "支付失败";
                        operationAddDto.OperationBy = null;
                        operationAddDto.Source = (int)RequestSource.AmiyaBackground;
                        await operationLogService.AddOperationLogAsync(operationAddDto);
                    }
                }
                else
                {
                    operationAddDto.Parameters = query.ToString();
                    operationAddDto.Code = -1;
                    operationAddDto.RouteAddress = "杉德支付回调请求";
                    operationAddDto.RequestType = (int)RequestType.Pay;
                    operationAddDto.Message = "签名验证失败";
                    operationAddDto.OperationBy = null;
                    operationAddDto.Source = (int)RequestSource.AmiyaBackground;

                }
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                operationAddDto.Message = ex.Message;
                operationAddDto.Code = -1;
                throw;
            }
            finally
            {
                operationAddDto.OperationBy = null;
                await operationLogService.AddOperationLogAsync(operationAddDto);
            }
        }
        [HttpGet("checkOrderStatus")]
        public async Task CheckOrderStatusAsync(string transNo)
        {
            await huiShouQianPaymentService.CheckOrderStatus(transNo);
        }
        //[HttpPost("testPayInfo/{tradeId}")]
        //public async Task TestPayInfo(string tradeId)
        //{
        //    try
        //    {
                
        //        bool isMaterialOrder = false;
        //        var orderTrade = await orderService.GetOrderTradeByTradeIdAsync(tradeId);
        //        if (true)
        //        {
        //            List<UpdateOrderDto> updateOrderList = new List<UpdateOrderDto>();
        //            foreach (var item in orderTrade.OrderInfoList)
        //            {
        //                UpdateOrderDto updateOrder = new UpdateOrderDto();
        //                updateOrder.OrderId = item.Id;
        //                if (item.OrderType == (byte)OrderType.MaterialOrder)
        //                {
        //                    updateOrder.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
        //                    isMaterialOrder = true;
        //                }
        //                else if (item.OrderType == (byte)OrderType.VirtualOrder)
        //                {
        //                    updateOrder.StatusCode = OrderStatusCode.TRADE_BUYER_PAID;
        //                    OperationAddDto operationLog = new OperationAddDto();
        //                    UploadMiniprogramOrderInfoDto uploadMiniprogramOrderInfo = new UploadMiniprogramOrderInfoDto();
        //                    try
        //                    {
        //                        operationLog.OperationBy = null;

        //                        OrderKey orderKey = new OrderKey();
        //                        if (orderTrade.AppId == "wx695942e4818de445")
        //                        {
        //                            orderKey.mchid = "1634868495";
        //                        }
        //                        else if (orderTrade.AppId == "wx8747b7f34c0047eb")
        //                        {
        //                            orderKey.mchid = "1633229187";
        //                        }

        //                        orderKey.transaction_id = "4200002083202312043752280919";
        //                        uploadMiniprogramOrderInfo.order_key = orderKey;
        //                        uploadMiniprogramOrderInfo.logistics_type = 3;
        //                        uploadMiniprogramOrderInfo.delivery_mode = 1;
        //                        uploadMiniprogramOrderInfo.is_all_delivered = true;
        //                        ShippingInfo shippingInfo = new ShippingInfo();
        //                        shippingInfo.item_desc = item.GoodsName;
        //                        Contact contact = new Contact();
        //                        contact.receiver_contact = ServiceClass.GetIncompletePhone(orderTrade.Phone);
        //                        shippingInfo.contact = contact;
        //                        uploadMiniprogramOrderInfo.shipping_list = new List<ShippingInfo> { shippingInfo };
        //                        uploadMiniprogramOrderInfo.upload_time = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK");
        //                        uploadMiniprogramOrderInfo.payer = new PayerInfo() { openid = dalWxMpUser.GetAll().Where(e => e.UserId == orderTrade.UserId).FirstOrDefault().OpenId };
        //                        await this.UploadMiniprogramOrderInfoAsync(uploadMiniprogramOrderInfo, orderTrade.AppId);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        operationLog.Message = ex.Message;
        //                        operationLog.Code = -1;

        //                    }
        //                    finally
        //                    {
        //                        operationLog.Parameters = JsonConvert.SerializeObject(uploadMiniprogramOrderInfo);
        //                        operationLog.RequestType = (int)RequestType.Pay;
        //                        operationLog.Source = (int)RequestSource.AmiyaBackground;
        //                        operationLog.RouteAddress = httpContextAccessor.HttpContext.Request.Path;
        //                        await operationLogService.AddOperationLogAsync(operationLog);
        //                    }
        //                }
        //                if (item.ActualPayment.HasValue)
        //                {
        //                    updateOrder.Actual_payment = item.ActualPayment.Value;

        //                    var bind = await _dalBindCustomerService.GetAll().FirstOrDefaultAsync(e => e.BuyerPhone == item.Phone);
        //                    if (bind != null)
        //                    {
        //                        bind.NewConsumptionDate = DateTime.Now;
        //                        bind.NewConsumptionContentPlatform = (int)OrderFrom.ThirdPartyOrder;
        //                        bind.NewContentPlatForm = ServiceClass.GetAppTypeText(item.AppType);
        //                        bind.AllPrice += item.ActualPayment.Value;
        //                        bind.AllOrderCount += item.Quantity;
        //                        await _dalBindCustomerService.UpdateAsync(bind, true);
        //                    }
        //                }
        //                if (item.IntegrationQuantity.HasValue)
        //                {
        //                    updateOrder.IntergrationQuantity = item.IntegrationQuantity;
        //                }
        //                Random random = new Random();
        //                updateOrder.AppType = item.AppType;
        //                updateOrder.WriteOffCode = random.Next().ToString().Substring(0, 8);
        //                updateOrderList.Add(updateOrder);
        //            }
        //            //修改订单状态
        //            await orderService.UpdateAsync(updateOrderList);
        //            UpdateOrderTradeDto updateOrderTrade = new UpdateOrderTradeDto();
        //            updateOrderTrade.TradeId = tradeId;
        //            updateOrderTrade.AddressId = orderTrade.AddressId;
        //            if (isMaterialOrder)
        //            {
        //                updateOrderTrade.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
        //            }
        //            else
        //            {
        //                updateOrderTrade.StatusCode = OrderStatusCode.TRADE_BUYER_PAID;
        //            }

        //            await orderService.UpdateOrderTradeAsync(updateOrderTrade);
        //            await orderService.TradeAddChanelOrderNoAsync(orderTrade.TradeId, "4200002083202312043752280919");
                    
        //        }
        //    }
        //    catch (Exception ex)
        //    {
                
        //        throw ex;
        //    }

        //}
    }
}
