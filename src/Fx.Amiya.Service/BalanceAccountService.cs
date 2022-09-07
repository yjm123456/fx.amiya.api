using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.Balance;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class BalanceAccountService : IBalanceAccountService
    {
        private readonly IDalBalanceAccount dalBalanceAccount;
        private readonly IBalanceUseRecordService balanceUseRecordService;
        private readonly IBalanceRechargeService balanceRechargeService;

        public BalanceAccountService(IDalBalanceAccount dalBalanceAccount, IBalanceRechargeService balanceRechargeService, IBalanceUseRecordService balanceUseRecordService)
        {
            this.dalBalanceAccount = dalBalanceAccount; 
            this.balanceRechargeService = balanceRechargeService;
            this.balanceUseRecordService = balanceUseRecordService;
        }
        /// <summary>
        /// 创建并返回新的账号
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<BalanceAccountDto> CreateBalanceAccountAsync(string customerId)
        {
            BalanceAccount balanceAccount = new BalanceAccount { 
                CustomerId=customerId,
                Balance=0
            };
            await dalBalanceAccount.AddAsync(balanceAccount,true);
            var account = dalBalanceAccount.GetAll().Where(e => e.CustomerId == customerId).SingleOrDefault();
            return new BalanceAccountDto { 
                CustomerId=account.CustomerId,
                Balance=account.Balance
            };
        }
        public async Task<BalanceAccountDto> GetAccountInfoAsync(string customerId)
        {
            var account= dalBalanceAccount.GetAll().Where(b => b.CustomerId == customerId).Select(b => new BalanceAccountDto
            {
                CustomerId = b.CustomerId,
                Balance = b.Balance
            }).SingleOrDefault();
            if (account==null) {
                account =await CreateBalanceAccountAsync(customerId);
            }
            if (account.Balance < 0) throw new Exception("账户余额异常");
            return account;
        }

        public async Task UpdateAccountBalanceAsync(string customerid)
        {
            var account = dalBalanceAccount.GetAll().Where(e=>e.CustomerId==customerid).SingleOrDefault();
            if (account.Balance < 0) throw new Exception("账号异常");
            //充值总金额
            decimal totalRechargeAmount=await balanceRechargeService.GetAllAmountAsync(customerid);
            //消费总金额
            decimal totalUseAmount =await balanceUseRecordService.GetTotalUseAmountAsync(customerid);
            decimal balance = totalRechargeAmount - totalUseAmount;
            if (balance < 0) throw new Exception("账号异常");
            account.Balance = balance;
            await dalBalanceAccount.UpdateAsync(account,true);
        }
        
    }
}
