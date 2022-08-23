using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.GrowthPoints;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class GrowthPointsAccountService : IGrowthPointsAccountService
    {
        private readonly IDalGrowthPointsAccount _dalGrowthPointsAccount;
        private readonly IDalGrowthPointsRecord dalGrowthPointsRecord;

        public GrowthPointsAccountService(IDalGrowthPointsAccount dalGrowthPointsAccount, IDalGrowthPointsRecord dalGrowthPointsRecord)
        {
            _dalGrowthPointsAccount = dalGrowthPointsAccount;
            this.dalGrowthPointsRecord = dalGrowthPointsRecord;
        }

        public async Task AddAsync(CreateGrowthPointsAccountDto create)
        {
            try
            {
                GrowthPointsAccount account = new GrowthPointsAccount();
                account.CustomerId = create.CustomerId;
                account.Balance = 0m;
                await _dalGrowthPointsAccount.AddAsync(account, true);
            }
            catch (Exception ex)
            {

                throw new Exception("创建成长值账号失败");
            }
        }

        public async Task<GrowthPointsAccountDto> GetGrowthPointAccountByCustomerId(string customerId)
        {
            return _dalGrowthPointsAccount.GetAll().Where(c => c.CustomerId == customerId).Select(c => new GrowthPointsAccountDto { CustomerId = c.CustomerId, Balance = c.Balance }).SingleOrDefault();
        }

        public async Task UpdateAsync(UpdateGrowthPointsAccountDto update)
        {
            var res = _dalGrowthPointsAccount.GetAll().Where(e => e.CustomerId == update.CustomerId).SingleOrDefault();
            res.Balance = update.IncreaseCount;
            await _dalGrowthPointsAccount.UpdateAsync(res,true);
        }
    }
}
