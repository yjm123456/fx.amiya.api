using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.Recharge;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class RechargeAmountService:IRechargeAmountService
    {
        private readonly IDalRechargeAmount dalRechargeAmount;

        public RechargeAmountService(IDalRechargeAmount dalRechargeAmount)
        {
            this.dalRechargeAmount = dalRechargeAmount;
        }
        /// <summary>
        /// 添加充值金额选项
        /// </summary>
        /// <param name="addRechargeAmountDto"></param>
        /// <returns></returns>
        public async Task AddRechargeAmount(AddRechargeAmountDto addRechargeAmountDto)
        {
            RechargeAmount rechargeAmount = new RechargeAmount { 
                Id=addRechargeAmountDto.Id,
                Amount=addRechargeAmountDto.Amount
            };
            await dalRechargeAmount.AddAsync(rechargeAmount, true);
        }

        public async Task<RechargeAmountDto> GetRechargeAmountAsync(string id)
        {
            return dalRechargeAmount.GetAll().Where(a=>a.Id==id).Select(a=>new RechargeAmountDto { 
                Id=a.Id,
                Amount=a.Amount
            }).SingleOrDefault();
        }

        /// <summary>
        /// 获取所有的充值金额
        /// </summary>
        /// <returns></returns>
        public async Task<List<RechargeAmountDto>> GetRechargeAmountListAsync()
        {
            return dalRechargeAmount.GetAll().Select(a => new RechargeAmountDto
            {
                Id = a.Id,
                Amount = a.Amount
            }).ToList();
        }
    }
}
