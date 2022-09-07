using Fx.Amiya.Dto.Balance;
using Fx.Amiya.IService;
using Fx.Infrastructure.DataAccess;
using jos_sdk_net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class BalanceService:IBalanceService
    {
        private IBalanceAccountService balanceAccountService;
        private IBalanceUseRecordService useRecordService;
        private IUnitOfWork unitOfWork;
        private readonly IBalanceRechargeService balanceRechargeService;

        public BalanceService(IBalanceAccountService balanceAccountService, IBalanceUseRecordService useRecordService, IUnitOfWork unitOfWork, IBalanceRechargeService balanceRechargeService)
        {
            this.balanceAccountService = balanceAccountService;
            this.useRecordService = useRecordService;
            this.unitOfWork = unitOfWork;
            this.balanceRechargeService = balanceRechargeService;
        }
        /// <summary>
        /// 余额消费
        /// </summary>
        /// <param name="customerid">用户id</param>
        /// <param name="orderid">订单id</param>
        /// <param name="amount">消费金额</param>
        /// <returns></returns>
        public async Task BalancePayAsync(string customerid, string orderid, decimal amount)
        {
            try
            {
                unitOfWork.BeginTransaction();
                if (amount < 0) throw new Exception("支付金额异常");
                var balance = await balanceAccountService.GetAccountInfoAsync(customerid);
                if (balance == null || balance.Balance < amount) throw new Exception("余额不足");
                if (balance.Balance < 0) throw new Exception("余额异常,支付失败");
                AddBalanceUseRecordDto addBalanceUseRecordDto = new AddBalanceUseRecordDto
                {
                    Id = CreateOrderIdHelper.GetNextNumber(),
                    CustomerId = customerid,
                    Amount = amount,
                    CreateDate = DateTime.Now,
                    OrderId = orderid,
                    Balance = balance.Balance,
                    UseType = 0
                };
                await useRecordService.AddBalanceUseRecordAsync(addBalanceUseRecordDto);
                await balanceAccountService.UpdateAccountBalanceAsync(customerid);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception("余额支付失败");
            }
        }

    }
}
