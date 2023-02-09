using Fx.Amiya.Core.Dto.Goods;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto;
using Fx.Amiya.Dto.ConsumptionVoucher;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using jos_sdk_net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    /// <summary>
    /// 抵用券
    /// </summary>
    public class ConsumptionVoucherService : IConsumptionVoucherService
    {
        private readonly IDalConsumptionVoucher dalConsumptionVoucher;

        public ConsumptionVoucherService(IDalConsumptionVoucher dalConsumptionVoucher)
        {
            this.dalConsumptionVoucher = dalConsumptionVoucher;
        }
        /// <summary>
        /// 添加抵用券
        /// </summary>
        /// <param name="addConsumptionVoucher"></param>
        /// <returns></returns>
        public async Task AddAsync(AddConsumptionVoucherDto addConsumptionVoucher)
        {
            var consumerVoucher = dalConsumptionVoucher.GetAll().Where(e => e.ConsumptionVoucherCode == addConsumptionVoucher.ConsumptionVoucherCode).SingleOrDefault();
            if (consumerVoucher != null) throw new Exception("抵用券编码重复,请重新设置抵用券编码");
            if (addConsumptionVoucher.Type == 1 && addConsumptionVoucher.DeductMoney > 0) throw new Exception("虚拟商品抵用券无法设置抵扣量!");
            if (addConsumptionVoucher.Type != 1 && addConsumptionVoucher.DeductMoney <= 0) throw new Exception("现金/积分抵用券抵扣量不能小于0!");
            if (addConsumptionVoucher.Type != 1 && addConsumptionVoucher.IsNeedMinPrice)
            {
                if (!addConsumptionVoucher.MinPrice.HasValue || addConsumptionVoucher.MinPrice.Value <= 0)
                {
                    throw new Exception("最小限制金额不能为空或小于0");
                }
            }
            ConsumptionVoucher consumptionVoucher = new ConsumptionVoucher
            {
                Id = CreateOrderIdHelper.GetNextNumber(),
                Name = addConsumptionVoucher.Name,
                DeductMoney = addConsumptionVoucher.DeductMoney,
                IsSpecifyProduct = addConsumptionVoucher.IsSpecifyProduct,
                IsAccumulate = addConsumptionVoucher.IsAccumulate,
                IsShare = addConsumptionVoucher.IsShare,
                EffectiveTime = addConsumptionVoucher.EffectiveTime,
                Type = addConsumptionVoucher.Type,
                ExpireDate = addConsumptionVoucher.ExpireDate,
                IsValid = addConsumptionVoucher.IsValid,
                CreateDate = addConsumptionVoucher.CreateDate,
                ConsumptionVoucherCode = addConsumptionVoucher.ConsumptionVoucherCode,
                Remark = addConsumptionVoucher.Remark,
                IsNeedMinFee = addConsumptionVoucher.IsNeedMinPrice,
                MinPrice = addConsumptionVoucher.MinPrice,
                MemberRankCode = addConsumptionVoucher.MemberRankCode,
                IsMemberVoucher = addConsumptionVoucher.IsMemberVoucher
            };
            await dalConsumptionVoucher.AddAsync(consumptionVoucher, true);
        }
        /// <summary>
        /// 根据抵用券编号获取抵用券信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<ConsumptionVoucherDto> GetConsumptionVoucherByCodeAsync(string code)
        {
            try
            {
                return dalConsumptionVoucher.GetAll().Where(e => e.ConsumptionVoucherCode == code).Select(e => new ConsumptionVoucherDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    DeductMoney = e.DeductMoney,
                    IsSpecifyProduct = e.IsSpecifyProduct,
                    IsAccumulate = e.IsAccumulate,
                    IsShare = e.IsShare,
                    CreateDate = e.CreateDate,
                    UpdateDate = e.UpdateDate,
                    ConsumptionVoucherCode = e.ConsumptionVoucherCode,
                    Type = e.Type,
                    EffectiveTime = e.EffectiveTime,
                    Remark = e.Remark
                }).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("请输入正确的抵用券编号");
            }
        }
        /// <summary>
        /// 获取抵用券名称列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<ConsumptionVoucherDto>> GetConsumptionVoucherkNameListAsync()
        {
            return dalConsumptionVoucher.GetAll().Where(e => e.IsValid == true).Select(v => new ConsumptionVoucherDto
            {
                Id = v.Id,
                Name = v.Name
            }).ToList();
        }
        /// <summary>
        /// 获取抵用券类型列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<BaseKeyValueDto>> GetConsumptionVoucherTypeListAsync()
        {
            var consumptionVoucherTypes = Enum.GetValues(typeof(ConsumptionVoucherType));

            List<BaseKeyValueDto> consumptionVoucherTypeList = new List<BaseKeyValueDto>();
            foreach (var item in consumptionVoucherTypes)
            {
                BaseKeyValueDto baseKeyValueDto = new BaseKeyValueDto();
                baseKeyValueDto.Key = Convert.ToInt32(item).ToString();
                baseKeyValueDto.Value = ServiceClass.GetConsumptionVoucherType(Convert.ToInt32(item));
                consumptionVoucherTypeList.Add(baseKeyValueDto);
            }
            return consumptionVoucherTypeList;
        }
        /// <summary>
        /// 获取抵用券信息列表
        /// </summary>
        /// <returns></returns>
        public async Task<FxPageInfo<ConsumptionVoucherDto>> GetConsumptionListAsync(int pageNum, int pageSize, string keyword, bool valid)
        {
            FxPageInfo<ConsumptionVoucherDto> fxPageInfo = new FxPageInfo<ConsumptionVoucherDto>();
            var consumptionVoucherList = from c in dalConsumptionVoucher.GetAll()
                                         where(keyword == null || c.Name.Contains(keyword)) && (c.IsValid == valid)
                                         select new ConsumptionVoucherDto
                                         {
                                             Id = c.Id,
                                             Name = c.Name,
                                             DeductMoney = c.DeductMoney,
                                             IsSpecifyProduct = c.IsSpecifyProduct,
                                             IsAccumulate = c.IsAccumulate,
                                             IsShare = c.IsShare,
                                             Type = c.Type,
                                             IsValid = c.IsValid,
                                             ConsumptionVoucherCode = c.ConsumptionVoucherCode,
                                             TypeText = ServiceClass.GetConsumptionVoucherType(c.Type),
                                             Remark = c.Remark,
                                             IsNeedMinPrice = c.IsNeedMinFee,
                                             MinPrice = c.MinPrice,
                                             EffectiveTime = c.EffectiveTime,
                                             IsMemberVoucher = c.IsMemberVoucher,
                                             MemberRankCode = c.MemberRankCode
                                         };
            /*.Select(c => new ConsumptionVoucherDto
{
Id = c.Id,
Name = c.Name,
DeductMoney = c.DeductMoney,
IsSpecifyProduct = c.IsSpecifyProduct,
IsAccumulate = c.IsAccumulate,
IsShare = c.IsShare,
Type = c.Type,
IsValid = c.IsValid,
ConsumptionVoucherCode = c.ConsumptionVoucherCode,
TypeText = ServiceClass.GetConsumptionVoucherType(c.Type),
Remark = c.Remark,
IsNeedMinPrice = c.IsNeedMinFee,
MinPrice = c.MinPrice,
EffectiveTime = c.EffectiveTime,
IsMemberVoucher = c.IsMemberVoucher,
MemberRankCode = c.MemberRankCode
});*/
            fxPageInfo.TotalCount = consumptionVoucherList.Count();
            fxPageInfo.List = consumptionVoucherList.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            return fxPageInfo;
        }
        /// <summary>
        /// 根据抵用券id获取抵用券信息
        /// </summary>
        /// <returns></returns>
        public async Task<ConsumptionVoucherDto> GetConsumptionVoucherInfoByIdAsync(string voucherId)
        {
            var voucher = dalConsumptionVoucher.GetAll().Where(e => e.Id == voucherId).Select(e => new ConsumptionVoucherDto
            {
                Id = e.Id,
                Name = e.Name,
                DeductMoney = e.DeductMoney,
                IsSpecifyProduct = e.IsSpecifyProduct,
                IsAccumulate = e.IsAccumulate,
                IsShare = e.IsShare,
                Type = e.Type,
                IsValid = e.IsValid,
                ConsumptionVoucherCode = e.ConsumptionVoucherCode,
                Remark = e.Remark,
                IsNeedMinPrice = e.IsNeedMinFee,
                MinPrice = e.MinPrice,
                EffectiveTime = e.EffectiveTime,
                IsMemberVoucher = e.IsMemberVoucher,
                MemberRankCode = e.MemberRankCode
            }).SingleOrDefault();
            return voucher;
        }
        /// <summary>
        /// 修改抵用券信息
        /// </summary>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        public async Task UpdateConsumptionVoucherAsync(UpdateConsumptionVoucherDto updateDto)
        {
            try
            {
                var voucher = dalConsumptionVoucher.GetAll().Where(e => e.Id == updateDto.Id).SingleOrDefault();
                if (voucher == null) throw new Exception("抵用券不存在");
                voucher.Name = updateDto.Name;
                voucher.DeductMoney = updateDto.DeductMoney;
                voucher.IsSpecifyProduct = updateDto.IsSpecifyProduct;
                voucher.IsAccumulate = updateDto.IsAccumulate;
                voucher.IsShare = updateDto.IsShare;
                voucher.Type = updateDto.Type;
                voucher.IsValid = updateDto.IsValid;
                voucher.ConsumptionVoucherCode = updateDto.ConsumptionVoucherCode;
                voucher.UpdateDate = updateDto.UpdateTime;
                voucher.EffectiveTime = (int)updateDto.EffectiveTime.Value;
                voucher.IsNeedMinFee = updateDto.IsNeedMinPrice;
                voucher.MinPrice = updateDto.MinPrice;
                voucher.IsMemberVoucher = updateDto.IsMemberVoucher;
                voucher.MemberRankCode = updateDto.MemberRankCode;
                voucher.Remark = updateDto.Remark;
                if (voucher.Type == 1 && voucher.DeductMoney > 0) throw new Exception("虚拟商品抵用券无法设置抵用量!");
                if (voucher.Type != 1 && voucher.DeductMoney <= 0) throw new Exception("现金/积分抵用券抵扣量不能小于0!");
                var existVoucher = dalConsumptionVoucher.GetAll().Where(e => e.Id != updateDto.Id && e.ConsumptionVoucherCode == updateDto.ConsumptionVoucherCode).SingleOrDefault();
                if (existVoucher != null) throw new Exception("抵用券编码重复,请重新填写抵用券编码!");
                dalConsumptionVoucher.Update(voucher, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取抵用券编码列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<ConsumptionVoucherCodeNameList>> GetConsumptionVoucherkCodeNameListAsync()
        {
            return dalConsumptionVoucher.GetAll().Where(e => e.IsValid == true).Select(v => new ConsumptionVoucherCodeNameList
            {
                VoucherCode = v.ConsumptionVoucherCode,
                Name = v.Name
            }).ToList();
        }
    }
}
