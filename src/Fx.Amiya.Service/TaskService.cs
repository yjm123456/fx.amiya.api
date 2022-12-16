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
        private IMemberCardService memberCardService;
        private readonly IGrowthPointsRuleService growthPointsRuleService;

        public TaskService(IGrowthPointsAccountService growthPointsAccountService, IGrowthPointsRecordService growthPointsRecordService, IUnitOfWork unitOfWork, IMemberCardService memberCardService, IGrowthPointsRuleService growthPointsRuleService)
        {
            this.growthPointsAccountService = growthPointsAccountService;
            this.growthPointsRecordService = growthPointsRecordService;
            this.unitOfWork = unitOfWork;
            this.memberCardService = memberCardService;
            this.growthPointsRuleService = growthPointsRuleService;
        }
        /// <summary>
        /// 完成商城下单任务
        /// </summary>
        /// <param name="customerid">用户id</param>
        /// <param name="actualpay">支付金额</param>
        /// <param name="orderid">订单id</param>
        /// <returns></returns>
        public async Task CompleteShopOrderTaskAsync(string customerid, decimal actualpay,string orderid)
        {
            if (actualpay < 1) return;
            var res = await growthPointsRecordService.GetGrowthPointsRecordByOrderId(customerid, orderid);
            if (res != null)
            {
                return;
            }
            else {
                try
                {
                    unitOfWork.BeginTransaction();
                    var growthRule = await growthPointsRuleService.GetTaskRuleByTaskCodeAsync(GrowthPointsRuleCode.CONSUMPTION);
                    AddGrowthPointsRecordDto record = new AddGrowthPointsRecordDto();
                    var account = await growthPointsAccountService.GetGrowthPointAccountByCustomerId(customerid);
                    if (account == null)
                    {
                        CreateGrowthPointsAccountDto pointsAccountDto = new CreateGrowthPointsAccountDto
                        {
                            CustomerId = customerid,
                            Balance = 0
                        };
                        account = await growthPointsAccountService.AddAsync(pointsAccountDto);
                    }
                    decimal quantity = Math.Round(actualpay*growthRule.RewardQuantityPercent,2);
                    record.CreateDate = DateTime.Now;
                    record.CustomerId = customerid;
                    record.IsExpire = false;
                    record.ExpireDate = DateTime.Now.AddMonths(12);
                    record.Type = 2;
                    record.Quantity = quantity;
                    record.OrderId = orderid;
                    record.AccountBalance = account.Balance;
                    await growthPointsRecordService.AddAsync(record);
                    var list = await growthPointsRecordService.GetGrowthPointsRecordListByCustomerId(customerid);
                    UpdateGrowthPointsAccountDto updateGrowthPointsAccountDto = new UpdateGrowthPointsAccountDto
                    {
                        CustomerId = customerid,
                        IncreaseCount = list.Sum(s => s.Quantity)
                    };
                    await growthPointsAccountService.UpdateAsync(updateGrowthPointsAccountDto);
                    await memberCardService.SendMemberCardAsync(customerid);
                    unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    unitOfWork.RollBack();
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 完成签到任务
        /// </summary>
        /// <returns></returns>
        public async Task CompleteSignTaskAsync(string customerid)
        {
            var orderid = DateTime.Now.ToString("yyyyMMdd");
            var res = await growthPointsRecordService.GetGrowthPointsRecordByOrderId(customerid, orderid);
            if (res != null)
            {
                throw new Exception("今日已签到,请勿重复签到");
            }
            else {
                try
                {
                    unitOfWork.BeginTransaction();
                    AddGrowthPointsRecordDto record = new AddGrowthPointsRecordDto();
                    var growthRule = await growthPointsRuleService.GetTaskRuleByTaskCodeAsync(GrowthPointsRuleCode.Singin);
                    var account = await growthPointsAccountService.GetGrowthPointAccountByCustomerId(customerid);
                    if (account == null)
                    {
                        CreateGrowthPointsAccountDto pointsAccountDto = new CreateGrowthPointsAccountDto
                        {
                            CustomerId = customerid,
                            Balance = 0
                        };
                        account = await growthPointsAccountService.AddAsync(pointsAccountDto);
                    }
                    record.CreateDate = DateTime.Now;
                    record.CustomerId = customerid;
                    record.IsExpire = false;
                    record.ExpireDate = DateTime.Now.AddMonths(12);
                    record.Type = 0;
                    record.Quantity = growthRule.RewardQuantity;
                    record.OrderId = orderid;
                    record.AccountBalance = account.Balance;
                    await growthPointsRecordService.AddAsync(record);
                    var list =await growthPointsRecordService.GetGrowthPointsRecordListByCustomerId(customerid);
                    UpdateGrowthPointsAccountDto updateGrowthPointsAccountDto = new UpdateGrowthPointsAccountDto {
                        CustomerId = customerid,
                        IncreaseCount = list.Sum(s=>s.Quantity)
                    };
                    await growthPointsAccountService.UpdateAsync(updateGrowthPointsAccountDto);
                    await memberCardService.SendMemberCardAsync(customerid);
                    unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    unitOfWork.RollBack();
                    throw new Exception("签到失败");
                }
                
            }

        }

    }
}
