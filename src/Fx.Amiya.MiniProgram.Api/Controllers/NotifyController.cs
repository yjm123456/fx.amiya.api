using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Dto.Balance;
using Fx.Amiya.Dto.TmallOrder;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Vo.Notify;
using Fx.Amiya.Modules.Integration.Domin;
using Fx.Amiya.Service;
using Fx.Infrastructure.DataAccess;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Threading.Tasks;

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
        public NotifyController(IOrderService orderService,
            IAliPayService aliPayService,
            ILogger<AliPayService> logger, IBalanceRechargeService balanceRechargeRecordService, IBalanceAccountService balanceAccountService, IUnitOfWork unitOfWork, IIntegrationAccount integrationAccount, IRechargeRewardRuleService rechargeRewardRuleService)
        {
            this.orderService = orderService;
            _aliPayService = aliPayService;
            this.logger = logger;
            this.balanceRechargeRecordService = balanceRechargeRecordService;
            this.balanceAccountService = balanceAccountService;
            this.unitOfWork = unitOfWork;
            this.integrationAccount = integrationAccount;
            this.rechargeRewardRuleService = rechargeRewardRuleService;
        }
        /// <summary>
        /// 支付宝订单回调地址
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("aliPayNotifyUrl")]
        public async Task<string> aliPayNotifyUrlAsync([FromForm]AliPayNotifyVo input)
        {
            string notifyLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 开始回调，回调id：" + input.notify_id;
            logger.LogInformation(notifyLog);
            /*SortedDictionary<string, string> sPara = GetRequestPost(input);
            var verifyResult = _aliPayService.Verify(sPara, input.notify_id, input.sign);
            if (verifyResult.Result != true)
            {
                return "fail";
            }*/
            if (input.body== "RECHARGE") {
                //储值
                try
                {
                    unitOfWork.BeginTransaction();
                    var rechargeRecord = await balanceRechargeRecordService.GetRechargeRecordByIdAsync(input.out_trade_no);
                    //如果订单记录状态为success直接返回success
                    if (rechargeRecord.Status == (int)RechargeStatus.Success) {
                        return "success";
                    }
                    UpdateRechargeRecordStatusDto update = new UpdateRechargeRecordStatusDto
                    {
                        Id = rechargeRecord.Id,
                        Status = (int)RechargeStatus.Success,
                        OrderId = input.trade_no,
                        CompleteDate = DateTime.Now
                    };
                    //更新记录状态
                    await balanceRechargeRecordService.UpdateRechargeRecordStatusAsync(update);
                    //更新余额
                    await balanceAccountService.UpdateAccountBalanceAsync(rechargeRecord.CustomerId);

                    var balance =await balanceAccountService.GetAccountInfoAsync(rechargeRecord.CustomerId);

                    #region 储值奖励积分

                    var totalRecharge = await balanceRechargeRecordService.GetAllRechargeAmountAsync(rechargeRecord.CustomerId);

                    var rechargeRewardRuleList = await rechargeRewardRuleService.GetRewardListAsync();

                    foreach (var rule in rechargeRewardRuleList)
                    {
                        if (totalRecharge>=rule.MinAmount) {
                            var integrationRecord = await CreateIntegrationRecordAsync(rechargeRecord.CustomerId, rule.GiveIntegration, 1);
                            if(integrationRecord!=null) await integrationAccount.AddByConsumptionAsync(integrationRecord);
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
                
                
            } else {
                //商城下单
                var orderTrade = await orderService.GetOrderTradeByTradeIdAsync(input.out_trade_no);
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
                updateOrderTrade.TradeId = input.out_trade_no;
                updateOrderTrade.AddressId = orderTrade.AddressId;
                updateOrderTrade.StatusCode = OrderStatusCode.WAIT_SELLER_SEND_GOODS;
                await orderService.UpdateOrderTradeAsync(updateOrderTrade);
            }
            return "success";
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
        private async Task<ConsumptionIntegrationDto> CreateIntegrationRecordAsync(string customerId,decimal awardAmount,decimal percent) {
            var exist= await integrationAccount.ExistRechargeRewardAsync(customerId,awardAmount,percent);
            if (exist) {
                return null;
            }
            ConsumptionIntegrationDto consumptionIntegrationDto = new ConsumptionIntegrationDto { 
                Quantity=awardAmount,
                Percent=1,
                AmountOfConsumption=awardAmount,
                Date=DateTime.Now,
                CustomerId=customerId,
                ExpiredDate=DateTime.Now.AddMonths(12),
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
    }
}
