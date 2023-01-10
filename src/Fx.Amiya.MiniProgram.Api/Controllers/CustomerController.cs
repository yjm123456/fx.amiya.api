using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Dto.GrowthPoints;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private TokenReader tokenReader;
        private IMiniSessionStorage sessionStorage;
        private ICustomerService customerService;
        private IBindCustomerServiceService bindCustomerServiceService;
        private IMemberCard memberCardService;
        private IMemberRankInfo memberRankInfoService;
        private IOrderService orderService;
        private IIntegrationAccount integrationAccountService;
        private IGrowthPointsAccountService growthPointsAccountService;
        private ILogger<CustomerController> logger;
        private IMemberCardService cardService;
        private ICustomerConsumptionVoucherService customerConsumptionVoucherService;
        public CustomerController(
            TokenReader tokenReader,
            IMiniSessionStorage sessionStorage,
            ICustomerService customerService,
            IBindCustomerServiceService bindCustomerServiceService,
              IMemberCard memberCardService,
             IMemberRankInfo memberRankInfoService,
             IOrderService orderService,
            IIntegrationAccount integrationAccountService,
             ILogger<CustomerController> logger, IGrowthPointsAccountService growthPointsAccountService, IMemberCardService cardService, ICustomerConsumptionVoucherService customerConsumptionVoucherService)
        {
            this.tokenReader = tokenReader;
            this.sessionStorage = sessionStorage;
            this.customerService = customerService;
            this.bindCustomerServiceService = bindCustomerServiceService;
            this.memberCardService = memberCardService;
            this.memberRankInfoService = memberRankInfoService;
            this.orderService = orderService;
            this.integrationAccountService = integrationAccountService;
            this.logger = logger;
            this.growthPointsAccountService = growthPointsAccountService;
            this.cardService = cardService;
            this.customerConsumptionVoucherService = customerConsumptionVoucherService;
        }
        /// <summary>
        /// 绑定客户
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        [HttpPost("bind")]
        [FxAmiyaApiUserTypeAuthorization]
        public async Task<ResultData<bool>> Bind([FromBody] string phoneNumber)
        {
            try
            {
                var token = tokenReader.GetToken();
                var sessionInfo = sessionStorage.GetSession(token);
                string fxCustomerId = await customerService.BindCustomerAsync(sessionInfo.FxUserId, phoneNumber);
                if (!string.IsNullOrEmpty(fxCustomerId))
                {
                    sessionInfo.FxCustomerId = fxCustomerId;
                    sessionStorage.SetSession(token, sessionInfo);
                }

                await bindCustomerServiceService.UpdateBindUserIdAsync(fxCustomerId);


                //计算积分
                var orders = await orderService.GetTradeFinishOrderListByCustomerIdAsync(fxCustomerId);
                foreach (var order in orders.ToList())
                {
                    var memberRank = await memberRankInfoService.GetMinGeneratePercentMemberRankInfoAsync();
                    ConsumptionIntegrationDto consumptionIntegration = new ConsumptionIntegrationDto();
                    consumptionIntegration.CustomerId = order.CustomerId;
                    consumptionIntegration.OrderId = order.Id;
                    consumptionIntegration.AmountOfConsumption = order.ActualPayment;
                    consumptionIntegration.Date = DateTime.Now;
                    consumptionIntegration.Quantity = Math.Floor(memberRank.GenerateIntegrationPercent * order.ActualPayment);
                    consumptionIntegration.Percent = memberRank.GenerateIntegrationPercent;

                    if (consumptionIntegration.Quantity > 0)
                        await integrationAccountService.AddByConsumptionAsync(consumptionIntegration);
                }

                //初始化成长值账号
                await growthPointsAccountService.AddAsync(new CreateGrowthPointsAccountDto {CustomerId= fxCustomerId,Balance=0});

                //新用户赠送抵用券
                await customerConsumptionVoucherService.NewCustomerSendVoucherAsync(fxCustomerId);
                //发放会员卡
                await cardService.SendMemberCardAsync(fxCustomerId);

                return ResultData<bool>.Success().AddData("isNewCustomer", false);
            }
            catch (Exception ex)
            {
                return ResultData<bool>.Fail("绑定账户失败");
            }
        }



        /// <summary>
        /// 获取客户手机号
        /// </summary>
        /// <returns></returns>
        [HttpGet("phone")]
        [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
        public async Task<ResultData<string>> GetPhoneByCustomerIdAsync()
        {
            try
            {
                var token = tokenReader.GetToken();
                var sessionInfo = sessionStorage.GetSession(token);

                var phone = await customerService.GetPhoneByCustomerIdAsync(sessionInfo.FxCustomerId);
                return ResultData<string>.Success().AddData("phone", phone);
            }
            catch (Exception ex)
            {
                return ResultData<string>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改客户手机号
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpPut("phone/{phone}")]
        [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
        public async Task<ResultData> UpdatePhoneByIdAsync([FromRoute] string phone)
        {
            var token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);

            await customerService.UpdatePhoneByIdAsync(sessionInfo.FxCustomerId, phone);
            return ResultData.Success();
        }


        /// <summary>
        /// 解密手机号
        /// </summary>
        /// <param name="encryptPhone"></param>
        /// <returns></returns>
        [HttpGet("decryptoPhone")]
        public async Task<ResultData<string>> DecryptoPhone(string encryptPhone)
        {
            var q = await customerService.DecryptoPhone(encryptPhone);
            return ResultData<string>.Success().AddData("phone", q);
        }
    }
}