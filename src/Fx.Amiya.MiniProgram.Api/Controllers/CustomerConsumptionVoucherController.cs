using Fx.Amiya.Dto.ConsumptionVoucher;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.ConsumptionVoucher;
using Fx.Common;
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
    public class CustomerConsumptionVoucherController : ControllerBase
    {
        private readonly ICustomerConsumptionVoucherService customerConsumptionVoucherService;
        private TokenReader _tokenReader;
        private static readonly AsyncLock _mutex = new AsyncLock();
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
        public async Task<ResultData<FxPageInfo<CustomerConsumptionVoucherInfoVo>>> GetCustomerConsumptionVoucherList(int pageNum, int pageSize, int? type)
        {
            FxPageInfo<CustomerConsumptionVoucherInfoVo> pageInfo = new FxPageInfo<CustomerConsumptionVoucherInfoVo>();
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;

            //会员赠送优惠券
            //await customerConsumptionVoucherService.IsReciveVoucherThisMonthThisWeekAsync(customerId);


            var list = await customerConsumptionVoucherService.GetCustomerConsumptionVoucherListAsync(pageNum, pageSize, customerId, type);
            pageInfo.TotalCount = list.TotalCount;
            pageInfo.List = list.List.Select(s => new CustomerConsumptionVoucherInfoVo
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
                WirteOfCode = s.WriteOfCode,
                Remark=s.Remark
            }).ToList();
            return ResultData<FxPageInfo<CustomerConsumptionVoucherInfoVo>>.Success().AddData("customerConsumptionVoucherList", pageInfo);
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
        public async Task<ResultData<List<CustomerConsumptionVoucherInfoVo>>> GetCustomerConsumptionVoucherList(bool? isUsed, string goodsId)
        {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;

            //会员赠送优惠券
            //await customerConsumptionVoucherService.IsReciveVoucherThisMonthThisWeekAsync(customerId);

            var list = await customerConsumptionVoucherService.GetAllCustomerConsumptionVoucherListAsync(customerId, isUsed, goodsId);
            var voucherList = list.Select(s => new CustomerConsumptionVoucherInfoVo
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
        /// 获取当前用户拥有的可供全局商品使用的抵用券
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isUsed"></param>
        /// <param name="goodsId">商品id</param>
        /// <returns></returns>
        [HttpGet("overAllList")]
        public async Task<ResultData<List<CustomerConsumptionVoucherInfoVo>>> GetCustomerOverAllConsumptionVoucherList(bool? isUsed, string goodsId)
        {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var voucher = await customerConsumptionVoucherService.GetOverAllCustomerConsumptionVoucherListAsync(customerId, false, goodsId);
            if (voucher.Count()==0)
            {
                return ResultData<List<CustomerConsumptionVoucherInfoVo>>.Success().AddData("customerOverAllConsumptionVoucher", null);
            }
            else
            {              
                var result = voucher.Select(e => new CustomerConsumptionVoucherInfoVo {
                    Id=e.Id,
                    ConsumptionVoucherName=e.ConsumptionVoucherName,
                    DeductMoney=e.DeductMoney,
                    Source=e.Source,
                    Type=e.Type
                }).ToList();
                return ResultData<List<CustomerConsumptionVoucherInfoVo>>.Success().AddData("customerOverAllConsumptionVoucher", result);
            }

            /*var voucherList = list.Select(s => new CustomerConsumptionVoucherInfoVo
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
            }).ToList();*/

        }

        /// <summary>
        /// 获取当前所有可用的叫车抵用券
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isUsed"></param>
        /// <param name="goodsId">商品id</param>
        /// <returns></returns>
        [HttpGet("allCarList")]
        public async Task<ResultData<List<CustomerConsumptionVoucherInfoVo>>> GetCustomerCarConsumptionVoucherList()
        {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;

            //会员赠送优惠券
            //await customerConsumptionVoucherService.IsReciveVoucherThisMonthThisWeekAsync(customerId);

            var list = await customerConsumptionVoucherService.GetAllCustomerConsumptionCarVoucherListAsync(customerId);
            var voucherList = list.Select(s => new CustomerConsumptionVoucherInfoVo
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
        public async Task<ResultData<String>> ReceiveShareVoucher(ShareConsumptionVoucherVo shareConsumption)
        {
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
        public async Task<ResultData<bool>> IsReciveConsumptionVoucher()
        {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var isRecieve = await customerConsumptionVoucherService.IsReciveVoucherThisMonthAsync(customerId);
            return ResultData<bool>.Success().AddData("recieve", isRecieve);
        }

        /// <summary>
        /// 每月领取抵用券
        /// </summary>
        /// <returns></returns>
        [HttpGet("reciveConsumptionVoucher")]
        public async Task<ResultData> ReciveConsumptionVoucher()
        {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            await customerConsumptionVoucherService.MemberRecieveCardAsync(customerId);
            return ResultData.Success();
        }
        /// <summary>
        /// 判断最近七天有没有领取抵用券
        /// </summary>
        /// <returns></returns>
        [HttpGet("isReciveConsumptionVoucherThisWeek")]
        public async Task<ResultData<List<MemberReciveVoucherVo>>> IsReciveConsumptionVoucherThisWeek()
        {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var recieve = await customerConsumptionVoucherService.IsReciveVoucherThisMonthThisWeekAsync(customerId);
            List<MemberReciveVoucherVo> resultList = null;
            if (recieve == null)
            {
                resultList = new List<MemberReciveVoucherVo>();
            }
            else
            {
                resultList = recieve.Select(e => new MemberReciveVoucherVo
                {
                    VoucherName = e.VoucherName,
                    DeductMoney = e.DeductMoney,
                    VoucherType = e.VoucherType,
                    VoucherCode = e.VoucherCode,
                    Remark=e.Remark
                }).ToList();
            }
            /*MemberReciveVoucherVo memberReciveVoucherVo = new MemberReciveVoucherVo();
            if (recieve == null) {
                
                memberReciveVoucherVo.CanReceive = false;
                memberReciveVoucherVo.DeductMoney = 0;
                memberReciveVoucherVo.VoucherName = "";
            } else {                
                memberReciveVoucherVo.CanReceive = true;
                memberReciveVoucherVo.DeductMoney = recieve.DeductMoney;
                memberReciveVoucherVo.VoucherName = recieve.VoucherName;
            }*/
            return ResultData<List<MemberReciveVoucherVo>>.Success().AddData("voucher", resultList);

        }
        /// <summary>
        /// 每周领取抵用券
        /// </summary>
        /// <returns></returns>
        [HttpPost("reciveConsumptionVoucherWeek/{code}")]
        public async Task<ResultData> ReciveConsumptionVoucherWeek(string code)
        {
            using (await _mutex.LockAsync())
            {
                string token = _tokenReader.GetToken();
                var sessionInfo = _sessionStorage.GetSession(token);
                string customerId = sessionInfo.FxCustomerId;
                await customerConsumptionVoucherService.MemberRecieveCardWeekAsync(customerId, code);
                return ResultData.Success();
            }

        }
        /// <summary>
        /// 获取用户所有可用的抵用券
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAllValidVoucher")]
        public async Task<ResultData<List<SimpleVoucherInfoVo>>> GetAllValidVoucherList() {
            string token = _tokenReader.GetToken();
            var sessionInfo = _sessionStorage.GetSession(token);
            string customerId = sessionInfo.FxCustomerId;
            var list= (await customerConsumptionVoucherService.GetCustomerAllVoucher(customerId)).Select(e=>new SimpleVoucherInfoVo { 
                CustomerVoucherId=e.CustomerVoucherId,
                VoucherName=e.VoucherName,
                IsSpecifyProduct=e.IsSpecifyProduct,
                Type=e.Type,
                IsNeedMinFee=e.IsNeedMinFee,
                MinPrice=e.MinPrice,
                VioucherId=e.VoucherId,
                Remark=e.Remark,
                DeductMoney=e.DeductMoney
            });
            return ResultData<List<SimpleVoucherInfoVo>>.Success().AddData("voucherList", list.ToList());
        }
    }
}
