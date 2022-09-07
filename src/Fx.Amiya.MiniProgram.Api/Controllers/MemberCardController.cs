using Fx.Amiya.Core.Dto.MemberCard;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.MemberCard;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
     [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
    public class MemberCardController : ControllerBase
    {
        private IMemberCard memberCardService;
        private TokenReader _tokenReader;
        private IMiniSessionStorage _sessionStorage;
        private ICustomerService _customerService;
        private IOrderService _orderService;
        private IMemberCardHandleService memberCardHandleService;
        private readonly IMemberCardService _memberCardService;
        public MemberCardController(IMemberCard memberCardService,
            TokenReader tokenReader,
            IMiniSessionStorage sessionStorage,
            ICustomerService customerService,
            IOrderService orderService, IMemberCardService memberCardService1, IMemberCardHandleService memberCardHandleService,IMemberCardService memberCardService2)
        {
            this.memberCardService = memberCardService;
            _tokenReader = tokenReader;
            _sessionStorage = sessionStorage;
            _customerService = customerService;
            _orderService = orderService;
            this.memberCardHandleService = memberCardHandleService;
            _memberCardService = memberCardService2;
        }
        private static readonly AsyncLock _mutex = new AsyncLock();

        /// <summary>
        /// 领取会员卡
        /// </summary>
        /// <returns></returns>
        [HttpGet("receive")]
        public async Task<ResultData> CustomerApplyForMemberCardAsync()
        {
            using (await _mutex.LockAsync())
            {
                string token = _tokenReader.GetToken();
                var sessionInfo = _sessionStorage.GetSession(token);
                string customerId = sessionInfo.FxCustomerId;

              string phone=await  _customerService.GetPhoneByCustomerIdAsync(customerId);
                var orderAmount =await _orderService.GetTradeFinishAmountByPhoneAsync(phone);
                if (orderAmount < 10000)
                    throw new Exception("未达到会员卡的核销金额");
                if (orderAmount >= 10000&& orderAmount<100000)
                {
                    await memberCardService.CustomerApplyForMemberCardAsync(customerId,MemberRankCode.OrdinaryMember);
                }
                if (orderAmount >= 100000)
                {
                    await memberCardService.CustomerApplyForMemberCardAsync(customerId, MemberRankCode.BlackCardMember);
                }

               
                return ResultData.Success();
            }
        }
        /// <summary>
        /// 获取新的会员卡信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("cardInfo")]
        public async Task<ResultData<MemberCardHandleVo>> GetMemberCardByCustomerIdAsync()
        {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var card =await memberCardHandleService.GetMemberCardByCustomeridAsync(customerId);
            
            if (card == null)
                 await _memberCardService.SendMemberCardAsync(customerId);

            card = await memberCardHandleService.GetMemberCardByCustomeridAsync(customerId);
            MemberCardHandleVo memberCardHandle = new MemberCardHandleVo()
            {
                Date = card.Date,
                CustomerId = card.CustomerId,
                MemberCardNum = card.MemberCardNum,
                MemberRankId = card.MemberRankId,
                MemberRankName = card.MemberRankName,
                HandleBy = card.HandleBy,
                Valid = card.Valid,
                Description = card.Description,
                ImageUrl = card.ImageUrl
            };
            return ResultData<MemberCardHandleVo>.Success().AddData("memberCard", memberCardHandle);
        }


        /// <summary>
        /// 获取会员卡信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("info")]
        public async Task<ResultData<MemberCardHandleVo>> GetMemberCardInfoByCustomerIdAsync()
        {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var memberCard = await memberCardService.GetMemberCardHandelByCustomerIdAsync(customerId);

            if (memberCard == null)
                return ResultData<MemberCardHandleVo>.Success().AddData("memberCard", null);

            MemberCardHandleVo memberCardHandle = new MemberCardHandleVo()
            {
                Date = memberCard.Date,
                CustomerId = memberCard.CustomerId,
                MemberCardNum = memberCard.MemberCardNum,
                MemberRankId = memberCard.MemberRankId,
                MemberRankName = memberCard.MemberRankName,
                HandleBy = memberCard.HandleBy,
                Valid = memberCard.Valid,
                Description = memberCard.Description,
                ImageUrl = memberCard.ImageUrl
            };
            return ResultData<MemberCardHandleVo>.Success().AddData("memberCard", memberCardHandle);
        }

    }
}
