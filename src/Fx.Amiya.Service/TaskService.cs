using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.GrowthPoints;
using Fx.Amiya.IService;
using Fx.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class TaskService : ITaskService
    {
        private IGrowthPointsAccountService growthPointsAccountService;
        private IGrowthPointsRecordService growthPointsRecordService;
        private IUnitOfWork unitOfWork;

        public TaskService(IGrowthPointsAccountService growthPointsAccountService, IGrowthPointsRecordService growthPointsRecordService, IUnitOfWork unitOfWork)
        {
            this.growthPointsAccountService = growthPointsAccountService;
            this.growthPointsRecordService = growthPointsRecordService;
            this.unitOfWork = unitOfWork;
        }

        public async Task CompleteSignTask(string customerid)
        {
            var orderid = DateTime.Now.ToString("yyyyMMdd");
            var res = await growthPointsRecordService.GetGrowthPointsRecordByOrderId(orderid);
            if (res != null)
            {
                throw new Exception("今日已签到,请勿重复签到");
            }
            else {
                AddGrowthPointsRecordDto record = new AddGrowthPointsRecordDto();
                var account =await growthPointsAccountService.GetGrowthPointAccountByCustomerId(customerid);
                try
                {
                    unitOfWork.BeginTransaction();
                    record.CreateDate = DateTime.Now;
                    record.CustomerId = customerid;
                    record.IsExpire = false;
                    record.ExpireDate = DateTime.Now.AddMonths(12);
                    record.Type = 0;
                    record.Quantity = 1;
                    record.OrderId = orderid;
                    record.AccountBalance = account.Balance;
                    await growthPointsRecordService.AddAsync(record);
                    var list =await growthPointsRecordService.GetGrowthPointsRecordListByCustomerId(customerid);
                    UpdateGrowthPointsAccountDto updateGrowthPointsAccountDto = new UpdateGrowthPointsAccountDto {
                        CustomerId = customerid,
                        IncreaseCount = list.Sum(s=>s.Quantity)
                    };
                    await growthPointsAccountService.UpdateAsync(updateGrowthPointsAccountDto);
                    unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    unitOfWork.RollBack();
                    throw;
                }
                
            }

        }
    }
}
