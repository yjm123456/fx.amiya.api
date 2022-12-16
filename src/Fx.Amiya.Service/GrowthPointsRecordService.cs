using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.GrowthPoints;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using jos_sdk_net.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class GrowthPointsRecordService : IGrowthPointsRecordService
    {
        private readonly IDalGrowthPointsRecord _dalGrowthPointsRecord;

        public GrowthPointsRecordService(IDalGrowthPointsRecord dalGrowthPointsRecord)
        {
            _dalGrowthPointsRecord = dalGrowthPointsRecord;
        }

        public async Task AddAsync(AddGrowthPointsRecordDto record)
        {
            var res =await GetGrowthPointsRecordByOrderId(record.CustomerId,record.OrderId);
            if (res==null) {
                GrowthPointsRecord growthPointsRecord = new GrowthPointsRecord {
                    Id = CreateOrderIdHelper.GetNextNumber(),
                    Quantity=record.Quantity,
                    Type=record.Type,
                    CustomerId=record.CustomerId,
                    OrderId=record.OrderId,
                    AccountBalance=record.AccountBalance,
                    IsExpire=record.IsExpire,
                    ExpireDate=record.ExpireDate,
                    CreateDate=record.CreateDate
                };
                await _dalGrowthPointsRecord.AddAsync(growthPointsRecord,true);

            }
         
        }

        public async Task<GrowthPointsRecordListInfoDto> GetGrowthPointsRecordByOrderId(string customerId,string orderid)
        {
            return await _dalGrowthPointsRecord.GetAll().Where(g => g.OrderId == orderid&&g.CustomerId== customerId).Select(g => new GrowthPointsRecordListInfoDto
            {
                Quantity = g.Quantity,
                IsExpire = g.IsExpire,
                CreateDate = g.CreateDate,
                ExpireDate = g.ExpireDate
            }).SingleOrDefaultAsync();
        }

        public async Task<List<GrowthPointsRecordListInfoDto>> GetGrowthPointsRecordListByCustomerId(string customerid)
        {
            return await _dalGrowthPointsRecord.GetAll().Where(g => g.CustomerId == customerid&&g.IsExpire==false).Select(g => new GrowthPointsRecordListInfoDto
            {
                Quantity = g.Quantity,
                IsExpire = g.IsExpire,
                CreateDate = g.CreateDate,
                Type = g.Type

            }).ToListAsync();

       
       
        }

        public async Task<FxPageInfo<GrowthPointsRecordListInfoDto>> GetGrowthPointsRecordListPageByCustomerId(string customerid,int pageNum,int pageSize)
        {
            var result =  _dalGrowthPointsRecord.GetAll().Where(g => g.CustomerId == customerid).Select(g => new GrowthPointsRecordListInfoDto
            {
                Quantity = g.Quantity,
                IsExpire = g.IsExpire,
                CreateDate = g.CreateDate,
                ExpireDate = g.ExpireDate,
                Type = g.Type

            });

            FxPageInfo<GrowthPointsRecordListInfoDto> pageInfo = new FxPageInfo<GrowthPointsRecordListInfoDto> {
                TotalCount = result.Count(),
                List=await result.OrderByDescending(e => e.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync()
            };
            return pageInfo;
        }
    }
}
