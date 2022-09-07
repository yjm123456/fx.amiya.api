using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.Balance;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class BalanceUseRecordService:IBalanceUseRecordService
    {
        private readonly IDalBalanceUseRecord dalBalanceUseRecord;
        private readonly IDalOrderInfo dalOrderInfo;

        public BalanceUseRecordService(IDalBalanceUseRecord dalBalanceUseRecord, IDalOrderInfo dalOrderInfo)
        {
            this.dalBalanceUseRecord = dalBalanceUseRecord;
            this.dalOrderInfo = dalOrderInfo;
        }

        public async Task AddBalanceUseRecordAsync(AddBalanceUseRecordDto addBalanceUse)
        {
            BalanceUseRecord balanceUseRecord = new BalanceUseRecord {
                Id=addBalanceUse.Id,
                CustomerId=addBalanceUse.CustomerId,
                Amount=addBalanceUse.Amount,
                CreateDate=addBalanceUse.CreateDate,
                OrderId=addBalanceUse.OrderId,
                Balance=addBalanceUse.Balance,
                UseType=addBalanceUse.UseType
            };
            await dalBalanceUseRecord.AddAsync(balanceUseRecord,true);
        }

        public async Task<FxPageInfo<BalanceUseRecordInfoDto>> GetBalanceUseRecordListAsync(int pageNum, int pageSize, string customerid)
        {
            FxPageInfo<BalanceUseRecordInfoDto> fxPageInfo = new FxPageInfo<BalanceUseRecordInfoDto>();
            var list = dalBalanceUseRecord.GetAll().Where(e => e.CustomerId == customerid).OrderByDescending(e=>e.CreateDate);
            fxPageInfo.TotalCount = list.Count();
            fxPageInfo.List = list.Skip((pageNum - 1) * pageSize).Take(pageSize).Select(e => new BalanceUseRecordInfoDto
            {
                Id = e.Id,
                CustomerId = e.CustomerId,
                Amount = e.Amount,
                CreateDate = e.CreateDate,
                OrderId = e.OrderId,
                GoodsName = dalOrderInfo.GetAll().Where(s => s.Id == e.OrderId).Select(s=>s.GoodsName).FirstOrDefault()
            }).ToList();
            return fxPageInfo;
        }

        public async Task<decimal> GetTotalUseAmountAsync(string customerid)
        {
            return dalBalanceUseRecord.GetAll().Where(e => e.CustomerId == customerid).Sum(e=>e.Amount);
        }
    }
}
