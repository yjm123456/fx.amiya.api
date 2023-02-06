using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ConsumptionVoucher;
using Fx.Amiya.Dto.ConsumptionVoucher;
using Fx.Amiya.Dto.MiniProgramSendMessage;
using Fx.Amiya.IService;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 抵用券
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionVoucherController : ControllerBase
    {
        private readonly IConsumptionVoucherService consumptionVoucherService;
        private readonly ICustomerService customerService;
        private readonly ICustomerConsumptionVoucherService customerConsumptionVoucherService;
        private readonly IMiniProgramTemplateMessageSendService miniProgramTemplateMessageSendService;
        public ConsumptionVoucherController(IConsumptionVoucherService consumptionVoucherService, ICustomerService customerService, ICustomerConsumptionVoucherService customerConsumptionVoucherService, IMiniProgramTemplateMessageSendService miniProgramTemplateMessageSendService)
        {
            this.consumptionVoucherService = consumptionVoucherService;
            this.customerService = customerService;
            this.customerConsumptionVoucherService = customerConsumptionVoucherService;
            this.miniProgramTemplateMessageSendService = miniProgramTemplateMessageSendService;
        }

        /// <summary>
        /// 获取抵用券名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("nameList")]
        public async Task<ResultData<List<ConsumptionVoucherVo>>> GetMemberRankNameListAsync()
        {
            var consumptionVoucherInfos = from d in await consumptionVoucherService.GetConsumptionVoucherkNameListAsync()
                                          select new ConsumptionVoucherVo
                                          {
                                              ConsumptionVoiucherId = d.Id,
                                              ConsumptionVoucherName = d.Name,
                                          };
            return ResultData<List<ConsumptionVoucherVo>>.Success().AddData("consumptionVoucherNames", consumptionVoucherInfos.ToList());
        }
        /// <summary>
        /// 获取抵用券编码名称列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("codeList")]
        public async Task<ResultData<List<ConsumptionVoucherCodeVo>>> GetMemberRankCodeNameListAsync()
        {
            var consumptionVoucherInfos = from d in await consumptionVoucherService.GetConsumptionVoucherkCodeNameListAsync()
                                          select new ConsumptionVoucherCodeVo
                                          {
                                              VoucherCode = d.VoucherCode,
                                              Name = d.Name,
                                          };
            return ResultData<List<ConsumptionVoucherCodeVo>>.Success().AddData("consumptionVoucherCodeNames", consumptionVoucherInfos.ToList());
        }
        /// <summary>
        /// 添加抵用券
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddConsumptionVoucherVo add)
        {
            AddConsumptionVoucherDto addConsumptionVoucherDto = new AddConsumptionVoucherDto
            {
                Name = add.Name,
                DeductMoney = add.DeductMoney,
                IsSpecifyProduct = add.IsSpecifyProduct,
                IsAccumulate = add.IsAccumulate,
                IsShare = add.IsShare,
                EffectiveTime = add.EffectiveTime,
                Type = add.Type,
                IsValid = true,
                CreateDate = DateTime.Now,
                ConsumptionVoucherCode = add.ConsumptionVoucherCode,
                Remark = add.Remark,
                IsNeedMinPrice = add.IsNeedMinPrice,
                MinPrice = add.MinPrice,
                IsMemberVoucher = add.IsMemberVoucher,
                MemberRankCode = add.MemberRankCode
            };
            await consumptionVoucherService.AddAsync(addConsumptionVoucherDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 获取抵用券类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("consumptionVoucherTypeList")]
        public async Task<ResultData<List<BaseIdAndNameVo>>> GetConsumptionVoucherTypeListAsync()
        {
            var list = (await consumptionVoucherService.GetConsumptionVoucherTypeListAsync()).Select(c => new BaseIdAndNameVo
            {
                Id = c.Key,
                Name = c.Value
            }).ToList();
            return ResultData<List<BaseIdAndNameVo>>.Success().AddData("consumptionVoucherTypeList", list);
        }
        /// <summary>
        /// 获取抵用券列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ResultData<FxPageInfo<ConsumptionVoucherInfoListVo>>> GetConsumptionVoucherInfoList(int pageNum, int pageSize)
        {
            FxPageInfo<ConsumptionVoucherInfoListVo> fxPageInfo = new FxPageInfo<ConsumptionVoucherInfoListVo>();
            var voucherList = (await consumptionVoucherService.GetConsumptionListAsync(pageNum, pageSize));
            fxPageInfo.TotalCount = voucherList.TotalCount;
            fxPageInfo.List = voucherList.List.Select(c => new ConsumptionVoucherInfoListVo
            {
                Id = c.Id,
                Name = c.Name,
                DeductMoney = c.DeductMoney,
                IsSpecifyProduct = c.IsSpecifyProduct,
                IsAccumulate = c.IsAccumulate,
                IsShare = c.IsShare,
                TypeText = c.TypeText,
                IsValid = c.IsValid,
                ConsumptionVoucherCode = c.ConsumptionVoucherCode,
                Remark = c.Remark,
                IsNeedMinPrice = c.IsNeedMinPrice,
                MinPrice = c.MinPrice,
                EffectiveTime = c.EffectiveTime,
                IsMemberVoucher = c.IsMemberVoucher,
                MemberRankCode = c.MemberRankCode
            });
            return ResultData<FxPageInfo<ConsumptionVoucherInfoListVo>>.Success().AddData("consumptionVoucherInfoList", fxPageInfo);
        }
        /// <summary>
        /// 根据抵用券id获取抵用券信息
        /// </summary>
        /// <param name="voucherId">抵用券id</param>
        /// <returns></returns>
        [HttpGet("byId/{voucherId}")]
        public async Task<ResultData<ConsumptionVoucherInfoVo>> GetConsumptionVoucherInfoByIdAsync(string voucherId)
        {
            ConsumptionVoucherInfoVo consumptionVoucherInfoVo = new ConsumptionVoucherInfoVo();
            var voucher = await consumptionVoucherService.GetConsumptionVoucherInfoByIdAsync(voucherId);
            consumptionVoucherInfoVo.Id = voucher.Id;
            consumptionVoucherInfoVo.Name = voucher.Name;
            consumptionVoucherInfoVo.DeductMoney = voucher.DeductMoney;
            consumptionVoucherInfoVo.IsSpecifyProduct = voucher.IsSpecifyProduct;
            consumptionVoucherInfoVo.IsAccumulate = voucher.IsAccumulate;
            consumptionVoucherInfoVo.IsShare = voucher.IsShare;
            consumptionVoucherInfoVo.Type = voucher.Type;
            consumptionVoucherInfoVo.IsValid = voucher.IsValid;
            consumptionVoucherInfoVo.ConsumptionVoucherCode = voucher.ConsumptionVoucherCode;
            consumptionVoucherInfoVo.Remark = voucher.Remark;
            consumptionVoucherInfoVo.IsNeedMinPrice = voucher.IsNeedMinPrice;
            consumptionVoucherInfoVo.MinPrice = voucher.MinPrice;
            consumptionVoucherInfoVo.EffectiveTime = voucher.EffectiveTime;
            consumptionVoucherInfoVo.IsMemberVoucher = voucher.IsMemberVoucher;
            consumptionVoucherInfoVo.MemberRankCode = voucher.MemberRankCode;
            return ResultData<ConsumptionVoucherInfoVo>.Success().AddData("consumptionVoucherInfo", consumptionVoucherInfoVo);
        }
        /// <summary>
        /// 修改抵用券信息
        /// </summary>
        /// <param name="updateConsumption"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateConsumptionVoucherInfoAsync(UpdateConsumptionVoucherInfoVo updateConsumption)
        {
            UpdateConsumptionVoucherDto updateConsumptionVoucherDto = new UpdateConsumptionVoucherDto
            {
                Id = updateConsumption.Id,
                Name = updateConsumption.Name,
                DeductMoney = updateConsumption.DeductMoney,
                IsSpecifyProduct = updateConsumption.IsSpecifyProduct,
                IsAccumulate = updateConsumption.IsAccumulate,
                IsShare = updateConsumption.IsShare,
                Type = updateConsumption.Type,
                IsValid = updateConsumption.IsValid,
                UpdateTime = DateTime.Now,
                ConsumptionVoucherCode = updateConsumption.ConsumptionVoucherCode,
                Remark = updateConsumption.Remark,
                IsNeedMinPrice = updateConsumption.IsNeedMinPrice,
                MinPrice = updateConsumption.MinPrice,
                EffectiveTime = updateConsumption.EffectiveTime,
                IsMemberVoucher = updateConsumption.IsMemberVoucher,
                MemberRankCode = updateConsumption.MemberRankCode
            };
            await consumptionVoucherService.UpdateConsumptionVoucherAsync(updateConsumptionVoucherDto);
            return ResultData.Success();
        }
        /// <summary>
        /// 手动发放优惠券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost("sendVoucher")]
        public async Task<ResultData> SendVoucher(SendVoucherVo send)
        {
            var voucher = await consumptionVoucherService.GetConsumptionVoucherByCodeAsync(send.VoucherCode);
            if (voucher == null) throw new Exception("抵用券编码错误");
            var effictime = voucher.EffectiveTime;
            AddConsumptionVoucherDto addConsumptionVoucherDto = new AddConsumptionVoucherDto();
            AddCustomerConsumptionVoucherDto addDto = new AddCustomerConsumptionVoucherDto();
            addDto.CustomerId = send.CustomerId;
            addDto.ConsumptionVoucherCode = send.VoucherCode;
            addDto.Source = 4;
            addDto.ExpireDate = DateTime.Now.AddDays(effictime.Value);
            await customerConsumptionVoucherService.AddAsyn(addDto);
            SendVoucherMessageDto sendVoucherMessageDto = new SendVoucherMessageDto();
            sendVoucherMessageDto.CustomerId = send.CustomerId;
            sendVoucherMessageDto.VoucherName = voucher.Name;
            switch (voucher.Type)
            {
                case 0:
                    sendVoucherMessageDto.DeductMoney = $"{voucher.DeductMoney}元抵用券";
                    break;
                case 4:
                    sendVoucherMessageDto.DeductMoney = $"{voucher.DeductMoney}折抵用券";
                    break;
                default:
                    sendVoucherMessageDto.DeductMoney = voucher.Name;
                    break;
            };
            sendVoucherMessageDto.UseageRange = voucher.Remark;
            sendVoucherMessageDto.ExpireDate = DateTime.Now.AddDays(voucher.EffectiveTime.Value).ToString("yyyy-MM-dd");
            sendVoucherMessageDto.Remark = "抵用券已到账";
            //手动发送抵用券成功后给客户发送消息
            await miniProgramTemplateMessageSendService.SendVoucherMessageAsync(sendVoucherMessageDto);
            return ResultData.Success();
        }
    }
}
