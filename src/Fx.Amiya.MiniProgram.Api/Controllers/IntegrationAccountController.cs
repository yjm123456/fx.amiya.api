using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Dto.CustomerIntegralOrderRefunds;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo;
using Fx.Amiya.MiniProgram.Api.Vo.Order;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
    public class IntegrationAccountController : ControllerBase
    {
        private IIntegrationAccount integrationAccountService;
        private ICustomerIntegralOrderRefundService _customerIntegralOrderRefundService;
        private TokenReader _tokenReader;
        private IOrderService orderService;
        private IMiniSessionStorage _sessionStorage;
        public IntegrationAccountController(IIntegrationAccount integrationAccountService,
              TokenReader tokenReader,
              IOrderService orderService,
              ICustomerIntegralOrderRefundService customerIntegralOrderRefundService,
            IMiniSessionStorage sessionStorage)
        {
            this.integrationAccountService = integrationAccountService;
            _tokenReader = tokenReader;
            this.orderService = orderService;
            _sessionStorage = sessionStorage;
            _customerIntegralOrderRefundService = customerIntegralOrderRefundService;
        }


        /// <summary>
        /// 获取客户的积分余额
        /// </summary>
        /// <returns></returns>
        [HttpGet("balance")]
        public async Task<ResultData<decimal>> GetIntegrationBalanceByCustomerIDAsync()
        {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            decimal balance = await integrationAccountService.GetIntegrationBalanceByCustomerIDAsync(customerId);
            return ResultData<decimal>.Success().AddData("balance", balance);
        }
        /// <summary>
        /// 客户积分明细
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<CustomerInterGrationAccountDetails>>> GetCustomerInitergrationRecord([Required] int pageNum, [Required] int pageSize)
        {
            try
            {
                string token = _tokenReader.GetToken();
                var sessionInfo = _sessionStorage.GetSession(token);
                string customerId = sessionInfo.FxCustomerId;
                List<CustomerInterGrationAccountDetails> customerInterGrationAccountResultList = new List<CustomerInterGrationAccountDetails>();
                //积分获取集合
                var generateRecord = await integrationAccountService.GetIntegrationGenerateRecordsByCustomerIDAsync(customerId);
                foreach (var x in generateRecord)
                {
                    CustomerInterGrationAccountDetails generateRecordDetails = new CustomerInterGrationAccountDetails();
                    generateRecordDetails.GenerateOrUsed = x.TypeText + "，订单号：" + x.OrderId;
                    generateRecordDetails.InterGrationAmount = "+" + x.Quantity.ToString();
                    generateRecordDetails.CreateDate = x.CreateDate;
                    customerInterGrationAccountResultList.Add(generateRecordDetails);
                }
                //积分使用集合
                var userRecord = await integrationAccountService.GetIntegrationUseRecordsByCustomerIDAsync(customerId);
                foreach (var z in userRecord)
                {
                    CustomerInterGrationAccountDetails generateRecordDetails = new CustomerInterGrationAccountDetails();
                    if(!string.IsNullOrEmpty(z.OrderId))
                    {
                        generateRecordDetails.GenerateOrUsed = z.TypeText + "，订单号：" + z.OrderId;
                    }
                    else
                    {
                        generateRecordDetails.GenerateOrUsed = z.TypeText;
                    }
                    generateRecordDetails.InterGrationAmount = "-" + z.UseQuantity.ToString();
                    generateRecordDetails.CreateDate = z.CreateDate;
                    customerInterGrationAccountResultList.Add(generateRecordDetails);
                }
                FxPageInfo<CustomerInterGrationAccountDetails> customerIntergrationAccount = new FxPageInfo<CustomerInterGrationAccountDetails>();
                customerIntergrationAccount.TotalCount = customerInterGrationAccountResultList.Count;
                customerIntergrationAccount.List = customerInterGrationAccountResultList.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
                return ResultData<FxPageInfo<CustomerInterGrationAccountDetails>>.Success().AddData("hospitalInfo", customerIntergrationAccount);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<CustomerInterGrationAccountDetails>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 客户积分退款申请
        /// </summary>
        /// <param name="addVo">订单号</param>
        /// <returns></returns>
        [HttpPost("Refund")]
        public async Task<ResultData> IntegrationPayAsync(AddCustomerIntegralOrderRefundsVo addVo)
        {

            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            AddCustomerIntegralOrderRefundsDto addDto = new AddCustomerIntegralOrderRefundsDto();
            addDto.OrderId = addVo.OrderId;
            addDto.CustomerId = customerId;
            addDto.RefundReasong = addVo.RefundReason;
            await _customerIntegralOrderRefundService.AddAsync(addDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 客户积分退款申请
        /// </summary>
        /// <param name="addVo">订单号</param>
        /// <returns></returns>
        [HttpPost("RefundTrade")]
        public async Task<ResultData> IntegrationRefundAsync(AddCustomerIntegralOrderRefundsVo addVo)
        {

            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            AddCustomerIntegralOrderRefundsDto addDto = new AddCustomerIntegralOrderRefundsDto();
            addDto.OrderId = addVo.OrderId;
            addDto.TradeId = addVo.TradeId;
            addDto.CustomerId = customerId;
            addDto.RefundReasong = addVo.RefundReason;
            await _customerIntegralOrderRefundService.AddByTradeAsync(addDto);
            return ResultData.Success();
        }
    }
}
