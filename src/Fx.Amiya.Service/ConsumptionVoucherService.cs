using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ConsumptionVoucher;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
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
            ConsumptionVoucher consumptionVoucher = new ConsumptionVoucher
            {
                Id = CreateOrderIdHelper.GetNextNumber(),
                Name=addConsumptionVoucher.Name,
                DeductMoney=addConsumptionVoucher.DeductMoney,
                IsSpecifyProduct=addConsumptionVoucher.IsSpecifyProduct,
                IsAccumulate=addConsumptionVoucher.IsAccumulate,
                IsShare=addConsumptionVoucher.IsShare,
                EffectiveTime=addConsumptionVoucher.EffectiveTime,
                Type=addConsumptionVoucher.Type,
                ExpireDate=addConsumptionVoucher.ExpireDate,
                IsValid=addConsumptionVoucher.IsValid,
                CreateDate=addConsumptionVoucher.CreateDate,
                
            };
            await dalConsumptionVoucher.AddAsync(consumptionVoucher,true);
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
                    UpdateTime = e.UpdateTime,
                    ConsumptionVoucherCode = e.ConsumptionVoucherCode,
                    Type=e.Type
                }).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("请输入正确的抵用券编号");
            }
        }
        
    }
}
