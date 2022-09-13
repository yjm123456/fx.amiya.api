using Fx.Amiya.Dto.ConsumptionVoucher;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.ConsumptionVoucher;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    [FxAmiyaApiUserTypeAuthorization(UserType.Customer)]
    public class CustomerConsumptionVoucherController : ControllerBase
    {
        private readonly ICustomerConsumptionVoucherService customerConsumptionVoucherService;
        private TokenReader _tokenReader;
        private IMiniSessionStorage _sessionStorage;
        public CustomerConsumptionVoucherController(ICustomerConsumptionVoucherService customerConsumptionVoucherService, TokenReader tokenReader, IMiniSessionStorage sessionStorage)
        {
            this.customerConsumptionVoucherService = customerConsumptionVoucherService;
            _tokenReader = tokenReader;
            _sessionStorage = sessionStorage;
        }
        /// <summary>
        /// 分页获取用户抵用券
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="type">类型0全部,1未使用,2已使用,3已过期</param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<CustomerConsumptionVoucherInfoVo>>> GetCustomerConsumptionVoucherList(int pageNum,int pageSize,int? type) {
            FxPageInfo<CustomerConsumptionVoucherInfoVo> pageInfo = new FxPageInfo<CustomerConsumptionVoucherInfoVo>();
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var list=await customerConsumptionVoucherService.GetCustomerConsumptionVoucherListAsync(pageNum,pageSize,customerId,type);
            pageInfo.TotalCount = list.TotalCount;
            pageInfo.List = list.List.Select(s => new CustomerConsumptionVoucherInfoVo { 
                Id=s.Id,
                CustomerId=customerId,
                ConsumptionVoucherName=s.ConsumptionVoucherName,
                DeductMoney=s.DeductMoney,
                IsShare=s.IsShare,
                IsSpecifyProduct=s.IsSpecifyProduct,
                ConsumptionVoucherId=s.ConsumptionVoucherId,
                IsUsed=s.IsUsed,
                ExpireDate=s.ExpireDate,
                IsExpire=s.IsExpire,
                CreateDate=s.CreateDate,
                UseDate=s.UseDate,
                Source=s.Source,
                Type=s.Type,
                WirteOfCode=s.WriteOfCode
            }).ToList();
            return ResultData<FxPageInfo<CustomerConsumptionVoucherInfoVo>>.Success().AddData("customerConsumptionVoucherList",pageInfo);
        }

        /// <summary>
        /// 获取当前商品可用的抵用券
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isUsed"></param>
        /// <param name="goodsId">商品id</param>
        /// <returns></returns>
        [HttpGet("allList")]
        public async Task<ResultData<List<CustomerConsumptionVoucherInfoVo>>> GetCustomerConsumptionVoucherList( bool? isUsed,string goodsId)
        {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var list = await customerConsumptionVoucherService.GetAllCustomerConsumptionVoucherListAsync( customerId, isUsed, goodsId);
            var voucherList= list.Select(s => new CustomerConsumptionVoucherInfoVo
            {
                Id = s.Id,
                CustomerId = customerId,
                ConsumptionVoucherName = s.ConsumptionVoucherName,
                DeductMoney = s.DeductMoney,
                IsShare = s.IsShare,
                IsSpecifyProduct = s.IsSpecifyProduct,
                ConsumptionVoucherId = s.ConsumptionVoucherId,
                IsUsed = s.IsUsed,
                ExpireDate = s.ExpireDate,
                IsExpire = s.IsExpire,
                CreateDate = s.CreateDate,
                UseDate = s.UseDate,
                Source = s.Source,
                Type = s.Type,
                WirteOfCode = s.WriteOfCode
            }).ToList();
            return ResultData<List<CustomerConsumptionVoucherInfoVo>>.Success().AddData("customerConsumptionVoucherList", voucherList);
        }

        /// <summary>
        /// 领取分享的抵用券
        /// </summary>
        /// <returns></returns>
        [HttpPost("reciveShareVoucher")]
        public async Task<ResultData<String>> ReceiveShareVoucher(ShareConsumptionVoucherVo shareConsumption) {
            try
            {
                string token = _tokenReader.GetToken();
                var sessionInfo = _sessionStorage.GetSession(token);
                string customerId = sessionInfo.FxCustomerId;
                ShareCustomerConsumptionVoucherDto shareCustomerConsumption = new ShareCustomerConsumptionVoucherDto
                {
                    CustomerId = customerId,
                    ShareCustomerId = shareConsumption.ShareBy,
                    CustomerConsumptionVocherId = shareConsumption.ConsumerConsumptionVoucherId
                };
                await customerConsumptionVoucherService.ShareCustomerConsumptionVoucherAsync(shareCustomerConsumption);
                return ResultData<string>.Success();
            }
            catch (Exception ex)
            {
               return ResultData<string>.Fail(ex.Message);
            }
        }
        /// <summary>
        /// 当前月是否已领取抵用券
        /// </summary>
        /// <returns></returns>
        [HttpGet("isReciveConsumptionVoucher")]
        public async Task<ResultData<bool>> IsReciveConsumptionVoucher() {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var isRecieve =await customerConsumptionVoucherService.IsReciveVoucherThisMonthAsync(customerId);
            return ResultData<bool>.Success().AddData("recieve",isRecieve);
        }
        /// <summary>
        /// 每月领取抵用券
        /// </summary>
        /// <returns></returns>
        [HttpGet("reciveConsumptionVoucher")]
        public async Task<ResultData> ReciveConsumptionVoucher() {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            await customerConsumptionVoucherService.MemberRecieveCardAsync(customerId);
            return ResultData.Success();
        }
    }
}
