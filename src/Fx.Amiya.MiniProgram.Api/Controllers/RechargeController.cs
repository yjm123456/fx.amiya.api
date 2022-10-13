using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.Balance;
using Fx.Amiya.Dto.OrderAppInfo;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.Balance;
using Fx.Amiya.MiniProgram.Api.Vo.Order;
using Fx.Amiya.MiniProgram.Api.Vo.Recharge;
using Fx.Amiya.Service;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
    public class RechargeController : ControllerBase
    {
        private readonly IBalanceAccountService balanceAccountService;
        private readonly IBalanceRechargeService balanceRechargeRecordService;
        private readonly IBalanceUseRecordService balanceUseRecordService;
        private TokenReader tokenReader;
        private IMiniSessionStorage sessionStorage;
        private IAliPayService _aliPayService;
        private readonly IRechargeAmountService rechargeAmountService;
        private Domain.IRepository.IWxMiniUserRepository _wxMiniUserRepository;
        private readonly ICustomerService customerService;
        private readonly IOrderService orderService;
        private readonly IRechargeRewardRuleService rechargeRewardRuleService;
        private IIntegrationAccount integrationAccount;
        private IUnitOfWork unitOfWork;
        public RechargeController(IBalanceAccountService balanceAccountService, IBalanceRechargeService balanceRechargeRecordService, TokenReader tokenReader, IMiniSessionStorage sessionStorage, IAliPayService aliPayService, IBalanceUseRecordService balanceUseRecordService, IRechargeAmountService rechargeAmountService, Domain.IRepository.IWxMiniUserRepository wxMiniUserRepository, ICustomerService customerService, IOrderService orderService, IRechargeRewardRuleService rechargeRewardRuleService, IIntegrationAccount integrationAccount, IUnitOfWork unitOfWork)
        {
            this.balanceAccountService = balanceAccountService;
            this.balanceRechargeRecordService = balanceRechargeRecordService;
            this.tokenReader = tokenReader;
            this.sessionStorage = sessionStorage;
            _aliPayService = aliPayService;
            this.balanceUseRecordService = balanceUseRecordService;
            this.rechargeAmountService = rechargeAmountService;
            _wxMiniUserRepository = wxMiniUserRepository;
            this.customerService = customerService;
            this.orderService = orderService;
            this.rechargeRewardRuleService = rechargeRewardRuleService;
            this.integrationAccount = integrationAccount;
            this.unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 获取用户余额
        /// </summary>
        /// <returns></returns>
        [HttpGet("balance")]
        public async Task<ResultData<decimal>> GetCustomerBalance()
        {
            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            var balance = await balanceAccountService.GetAccountInfoAsync(customerId);
            if (balance == null)
            {
                balance = await balanceAccountService.CreateBalanceAccountAsync(customerId);
            }
            return ResultData<decimal>.Success().AddData("balance", balance.Balance);
        }

        /// <summary>
        /// 分页获取充值记录
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="type">1:三方支付记录,2:余额退款记录</param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<BalanceRechargeRecordVo>>> GetRechargeRecordList(int pageNum, int pageSize, int? type)
        {
            FxPageInfo<BalanceRechargeRecordVo> fxPageInfo = new FxPageInfo<BalanceRechargeRecordVo>();
            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            var list = await balanceRechargeRecordService.GetBalanceRechargeRecordListAsync(pageNum, pageSize, customerId, type);
            fxPageInfo.TotalCount = list.TotalCount;
            fxPageInfo.List = list.List.Select(b => new BalanceRechargeRecordVo
            {
                Id = b.Id,
                ExchangeTypeText = b.ExchageTypeText,
                RechargeAmount = b.RechargeAmount,
                OrderId = b.OrderId,
                RechargeDate = b.RechargeDate,
                Status = b.Status,
                StatusText = b.StatusText,
                ExchangeType = b.ExchageType
            }).ToList();
            return ResultData<FxPageInfo<BalanceRechargeRecordVo>>.Success().AddData("recordList", fxPageInfo);
        }
        /// <summary>
        /// 获取余额消费记录
        /// </summary>
        /// <returns></returns>
        [HttpGet("useList")]
        public async Task<ResultData<FxPageInfo<BalanceUseRecordVo>>> GetBalanceUseRecord(int pageNum, int pageSize)
        {
            FxPageInfo<BalanceUseRecordVo> fxPageInfo = new FxPageInfo<BalanceUseRecordVo>();
            var token = tokenReader.GetToken();
            var sesssionInfo = sessionStorage.GetSession(token);
            string customerId = sesssionInfo.FxCustomerId;
            var list = await balanceUseRecordService.GetBalanceUseRecordListAsync(pageNum, pageSize, customerId);
            fxPageInfo.TotalCount = list.TotalCount;
            fxPageInfo.List = list.List.Select(b => new BalanceUseRecordVo
            {
                Amount = b.Amount,
                UseDate = b.CreateDate,
                GoodsName = b.GoodsName
            }).ToList();

            return ResultData<FxPageInfo<BalanceUseRecordVo>>.Success().AddData("useRecordList", fxPageInfo);
        }
        /// <summary>
        /// 生成订单
        /// </summary>
        /// <returns>交易编号</returns>
        [HttpPost]
        public async Task<ResultData<RechargeResultVo>> AddRechargeRecord(RechargeVo orderAdd)
        {

            RechargeResultVo rechargeResultVo = new RechargeResultVo();

            var token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var customerInfo = await customerService.GetByIdAsync(customerId);
            var miniUserInfo = await _wxMiniUserRepository.GetByUserIdAsync(customerInfo.UserId);
            string OpenId = miniUserInfo.OpenId;

            CreateBalanceRechargeRecordDto recordDto = new CreateBalanceRechargeRecordDto();
            var record = await balanceRechargeRecordService.GetRechargeRecordingAsync(customerId);
            if (record != null) throw new Exception("已存在一个未支付的充值订单,请先取消未支付订单");
            int type = ServiceClass.GetRechargeTypeByExchangeCode(orderAdd.ExchangeCode);
            if (type == -1) throw new Exception("不支持的支付方式");
            var amount = await rechargeAmountService.GetRechargeAmountAsync(orderAdd.AmountId);
            if (amount == null) throw new Exception("不支持的充值金额");
            recordDto.ExchangeType = type;
            recordDto.Id = CreateOrderIdHelper.GetNextNumber();
            recordDto.CustomerId = customerId;
            recordDto.RechargeAmount = amount.Amount;
            var balanceAccount = await balanceAccountService.GetAccountInfoAsync(customerId);
            recordDto.Balance = balanceAccount.Balance;
            recordDto.RechargeDate = DateTime.Now;
            recordDto.Status = (int)RechargeStatus.PendingPayment;
            string tradeId = await balanceRechargeRecordService.AddRechargeRecordAsync(recordDto);
            if (orderAdd.ExchangeCode == "WECHAT")
            {
                //throw new Exception("暂不支持微信支付");
                #region 微信支付
                WxPackageInfo packageInfo = new WxPackageInfo();
                packageInfo.Body = tradeId;
                //回调地址需重新设置(todo;)
                packageInfo.NotifyUrl = string.Format("http://{0}/amiya/wxmini/Notify/orderpayresult", Request.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString() + ":" + Request.HttpContext.Connection.LocalPort);
                //packageInfo.NotifyUrl = string.Format("http://{0}/amiya/wxmini/Notify/rechargepayresult", "wswjym.gnway.cc");
                packageInfo.OutTradeNo = tradeId;
                packageInfo.TotalFee = amount.Amount * 100m;
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
                    rechargeResultVo.PayRequestInfo = payRequestInfo;
                }

                #endregion
            }

            if (orderAdd.ExchangeCode == "ALIPAY")
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
                sParaTemp.Add("subject", tradeId);
                sParaTemp.Add("total_fee", amount.Amount.ToString("0.00"));
                sParaTemp.Add("body", "RECHARGE");
                var res = _aliPayService.BuildRequest(sParaTemp);
                rechargeResultVo.TradeId = tradeId;
                rechargeResultVo.AlipayUrl = res.Result;
                #endregion
            }

            return ResultData<RechargeResultVo>.Success().AddData("rechargeResult", rechargeResultVo);
        }
        /// <summary>
        /// 取消充值订单
        /// </summary>
        /// <returns></returns>
        [HttpPost("cancel")]
        public async Task<ResultData<string>> CancelRecharge(CancelRechargeVo cancelRecharge)
        {
            var token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var record = await balanceRechargeRecordService.GetRechargeRecordByRecordIdAndCustomerIdAsync(customerId, cancelRecharge.RecordId);
            if (record == null) throw new Exception("没有对应订单!");
            if (record.Status != 0)
            {
                throw new Exception("订单状态已改变,取消失败!");
            }
            UpdateRechargeRecordStatusDto updateRechargeRecordStatusDto = new UpdateRechargeRecordStatusDto
            {
                Id = cancelRecharge.RecordId,
                Status = (int)RechargeStatus.Cacncel,
                OrderId = null,
                CompleteDate = DateTime.Now
            };
            await balanceRechargeRecordService.UpdateRechargeRecordStatusAsync(updateRechargeRecordStatusDto);
            return ResultData<string>.Success();
        }
        /// <summary>
        /// 支付订单重新支付
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        [HttpPost("pay/{recordId}")]
        public async Task<ResultData<RechargeResultVo>> PayAsync(string recordId)
        {
            RechargeResultVo rechargeResultVo = new RechargeResultVo();
            var token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var customerInfo = await customerService.GetByIdAsync(customerId);
            var miniUserInfo = await _wxMiniUserRepository.GetByUserIdAsync(customerInfo.UserId);
            string OpenId = miniUserInfo.OpenId;
            var record = await balanceRechargeRecordService.GetRechargeRecordByRecordIdAndCustomerIdAsync(customerId, recordId);
            if (record == null) throw new Exception("没有对应订单!");
            if (record.Status != 0)
            {
                throw new Exception("订单状态已改变,重新支付失败!");
            }
            if (record.ExchageType == 0)
            {
                //支付宝支付
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
                sParaTemp.Add("out_trade_no", record.Id);
                sParaTemp.Add("subject", record.Id);
                sParaTemp.Add("total_fee", record.RechargeAmount.ToString("0.00"));
                sParaTemp.Add("body", "RECHARGE");
                var res = _aliPayService.BuildRequest(sParaTemp);
                rechargeResultVo.TradeId = record.Id;
                rechargeResultVo.AlipayUrl = res.Result;
                #endregion
            }
            else if (record.ExchageType == 1)
            {
                //微信支付
                WxPackageInfo packageInfo = new WxPackageInfo();
                packageInfo.Body = recordId;
                //回调地址需重新设置(todo;)
                packageInfo.NotifyUrl = string.Format("http://{0}/amiya/wxmini/Notify/rechargepayresult", Request.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString() + ":" + Request.HttpContext.Connection.LocalPort);
                packageInfo.OutTradeNo = recordId;
                packageInfo.TotalFee = (int)(record.RechargeAmount * 100m);
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
                    rechargeResultVo.PayRequestInfo = payRequestInfo;
                }
            }
            return ResultData<RechargeResultVo>.Success().AddData("rechargeResult", rechargeResultVo);
        }
        [HttpGet("amountList")]
        public async Task<ResultData<List<RechargeAmountVo>>> GetRechargeAmountList()
        {
            var list = await rechargeAmountService.GetRechargeAmountListAsync();
            var rechargeAmountList = list.Select(r => new RechargeAmountVo
            {
                Id = r.Id,
                Amount = r.Amount
            }).ToList();
            return ResultData<List<RechargeAmountVo>>.Success().AddData("rechargeAmountList", rechargeAmountList);
        }
        

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
    }
}
