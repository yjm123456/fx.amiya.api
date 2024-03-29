﻿using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Dto.CustomerIntergration;
using Fx.Amiya.Dto.MiniProgramSendMessage;
using Fx.Amiya.IService;
using Fx.Amiya.Modules.Integration.DbModel;
using Fx.Amiya.Modules.Integration.Domin;
using Fx.Amiya.Modules.Integration.Domin.IRepository;
using Fx.Amiya.Modules.Integration.Infrastructure.Repositories;
using Fx.Amiya.Service;
using Fx.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.AppService
{
    public class IntegrationAccountAppService : IIntegrationAccount
    {
        private IFreeSql<IntegrationFlag> freeSql;
        private IUnitOfWork unitOfWork;
        private IMemberCard memberCardService;
        private ICustomerService customerService;
        private IMemberRankInfo memberRankInfoService;
        private IIntegrationAccountRepository _integrationAccountRepository;
        private IMiniProgramTemplateMessageSendService miniProgramTemplateMessageSendService;
        public IntegrationAccountAppService(IIntegrationAccountRepository integrationAccountRepository,
            IMemberCard memberCardService,
            ICustomerService customerService,
             IMemberRankInfo memberRankInfoService,
            IUnitOfWork unitOfWork,
            IFreeSql<IntegrationFlag> freeSql, IMiniProgramTemplateMessageSendService miniProgramTemplateMessageSendService)
        {
            _integrationAccountRepository = integrationAccountRepository;
            this.freeSql = freeSql;
            this.unitOfWork = unitOfWork;
            this.memberRankInfoService = memberRankInfoService;
            this.memberCardService = memberCardService;
            this.customerService = customerService;
            this.miniProgramTemplateMessageSendService = miniProgramTemplateMessageSendService;
        }

        public Task AddIntegrationGenerateRecordAsync(IntegrationGenerateRecordAddDto item)
        {
            throw new NotImplementedException();
        }

        public Task AddIntegrationUseRecordAsync(IntegrationUseRecordAddDto item)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 添加消费奖励积分
        /// </summary>
        /// <returns></returns>
        public async Task AddByConsumptionAsync(ConsumptionIntegrationDto consumptionIntegration)
        {
            var integrationAccount = await _integrationAccountRepository.GetIntegrationAccountAsync(consumptionIntegration.CustomerId);
            if (integrationAccount == null)
            {
                integrationAccount = new IntegrationAccount()
                {
                    CustomerId = consumptionIntegration.CustomerId,
                    Version = 0,
                    GenerateRecordList = new List<IntegrationGenerateRecord>()
                };
            }

            integrationAccount.AddIntegration(new ConsumptionIntegration()
            {
                AmountOfConsumption = consumptionIntegration.AmountOfConsumption,
                CustomerId = consumptionIntegration.CustomerId,
                Date = consumptionIntegration.Date,
                ExpiredDate = consumptionIntegration.ExpiredDate,
                OrderId = consumptionIntegration.OrderId,
                Percent = consumptionIntegration.Percent,
                ProviderId = consumptionIntegration.ProviderId,
                Quantity = consumptionIntegration.Quantity, 
                GenerateType= (GenerateType)consumptionIntegration.Type,
                HandleBy= consumptionIntegration.HandleBy
            });

            await _integrationAccountRepository.SaveIntegrationAccountAsync(integrationAccount);
        }

        /// <summary>
        /// 积分商品退款返还积分
        /// </summary>
        /// <returns></returns>
        public async Task ReturnByConsumptionAsync(ConsumptionIntegrationDto consumptionIntegration)
        {
            var integrationAccount = await _integrationAccountRepository.GetIntegrationAccountAsync(consumptionIntegration.CustomerId);
            if (integrationAccount == null)
            {
                integrationAccount = new IntegrationAccount()
                {
                    CustomerId = consumptionIntegration.CustomerId,
                    Version = 0,
                    GenerateRecordList = new List<IntegrationGenerateRecord>()
                };
            }

            integrationAccount.AddIntegration(new ReturnGiftIntegration()
            {
                CustomerId = consumptionIntegration.CustomerId,
                Date = consumptionIntegration.Date,
                ExpiredDate = consumptionIntegration.ExpiredDate,
                Quantity = consumptionIntegration.Quantity,
                HandleBy = consumptionIntegration.HandleBy,
                OrderId = consumptionIntegration.OrderId
            });

            await _integrationAccountRepository.SaveIntegrationAccountAsync(integrationAccount);
        }


        public async Task<decimal> GetIntegrationBalanceByCustomerIDAsync(string customerId)
        {
            var integrationAccount = await _integrationAccountRepository.GetIntegrationAccountAsync(customerId);
            if (integrationAccount == null)
                return 0m;
            return integrationAccount.Balance;
        }
        public async Task<List<string>> GetAllCustomerHasIntergration()
        {
            var customerIds = await _integrationAccountRepository.GetAllIntegrationAccountAsync();
            return customerIds;
        }

        public async Task<bool> GetIsIntegrationGenerateRecordByOrderIdAsync(string orderId)
        {
            var integrationGenerateRecord = await freeSql.Select<IntegrationGenerateRecordDbModel>().Where(e => e.OrderId == orderId).FirstAsync();
            if (integrationGenerateRecord == null)
                return false;
            return true;
        }

        public async Task<List<IntegrationGenerateRecordsDto>> GetIntegrationGenerateRecordsByCustomerIDAsync(string customerID)
        {
            var integrationGenerateRecord = await freeSql.Select<IntegrationGenerateRecordDbModel>().Where(e => e.CustomerId == customerID).ToListAsync();
            List<IntegrationGenerateRecordsDto> integrationGenerateRecordResult = new List<IntegrationGenerateRecordsDto>();
            foreach (var x in integrationGenerateRecord)
            {
                IntegrationGenerateRecordsDto integrationGenerate = new IntegrationGenerateRecordsDto();
                integrationGenerate.CustomerID = x.CustomerId;
                integrationGenerate.Type = x.Type;
                integrationGenerate.TypeText = ServiceClass.GetIntegrationTypeText(x.Type);
                integrationGenerate.Quantity = x.Quantity;
                integrationGenerate.StockQuantity = x.StockQuantity;
                integrationGenerate.AccountBalance = x.AccountBalance;
                integrationGenerate.ExpiredDate = x.ExpiredDate;
                integrationGenerate.CreateDate = x.Date;
                integrationGenerate.OrderId = x.OrderId;
                integrationGenerateRecordResult.Add(integrationGenerate);
            }
            return integrationGenerateRecordResult;
        }

        public Task<List<IntegrationGenerateRecordsDto>> GetIntegrationGenerateRecordsByDateAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IntegrationUseRecordDto>> GetIntegrationUseRecordsByCustomerIDAsync(string customerID)
        {
            var integrationGenerateRecord = await freeSql.Select<IntegrationUseRecordDbModel>().Where(e => e.CustomerId == customerID).ToListAsync();
            List<IntegrationUseRecordDto> integrationUsedRecordResult = new List<IntegrationUseRecordDto>();
            foreach (var x in integrationGenerateRecord)
            {
                IntegrationUseRecordDto integrationUsed = new IntegrationUseRecordDto();
                integrationUsed.CustomerID = x.CustomerId;
                integrationUsed.Type = x.UseType;
                integrationUsed.TypeText = ServiceClass.GetUseIntegrationTypeText(x.UseType);
                integrationUsed.UseQuantity = x.UseQuantity;
                integrationUsed.AccountBalance = x.AccountBalance;
                integrationUsed.CreateDate = x.Date;
                integrationUsed.OrderId = x.OrderId;
                integrationUsedRecordResult.Add(integrationUsed);
            }
            return integrationUsedRecordResult;
        }

        public Task<List<IntegrationUseRecordDto>> GetIntegrationUseRecordsByDateAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 根据客户编号数组获取积分账户列表
        /// </summary>
        /// <param name="customerIds"></param>
        /// <returns></returns>
        public async Task<List<IntegrationAccountDto>> GetIntegrationAccountListByCustomerIdsAsync(List<string> customerIds)
        {

            var integrationAccountList = await freeSql.Select<IntegrationAccountDbModel>()
                .Where(e => customerIds.Contains(e.CustomerId)).ToListAsync();


            var integrationAccounts = from d in integrationAccountList
                                      select new IntegrationAccountDto
                                      {
                                          CustomerId = d.CustomerId,
                                          Balance = d.Balance

                                      };

            return integrationAccounts.ToList();
        }

        /// <summary>
        /// 客户消费奖励积分
        /// </summary>
        /// <param name="addCustomerIntergration"></param>
        /// <returns></returns>
        public async Task AddInterGrationAsync(AddCustomerIntergrationDto addCustomerIntergration)
        {
            //var customerId = await customerService.GetCustomerIdByPhoneAsync(addCustomerIntergration.Phone);
            if (string.IsNullOrWhiteSpace(addCustomerIntergration.CustomerId))
            {
                throw new Exception("该客户未注册小程序，无法赠送积分！");
            }
            decimal integrationPercent = 0m;
            var memberCard = await memberCardService.GetMemberCardHandelByCustomerIdAsync(addCustomerIntergration.CustomerId);
            if (memberCard != null)
            {
                integrationPercent = memberCard.GenerateIntegrationPercent;
            }
            else
            {
                var memberRank = await memberRankInfoService.GetMinGeneratePercentMemberRankInfoAsync();
                integrationPercent = memberRank.GenerateIntegrationPercent;
            }
            if (!string.IsNullOrWhiteSpace(addCustomerIntergration.OrderId))
            {
                var exist = await this.GetIsIntegrationGenerateRecordByOrderIdAndCustomerIdAsync(addCustomerIntergration.OrderId, addCustomerIntergration.CustomerId);
                if (exist) throw new Exception("该订单已赠送过积分");
            }
            ConsumptionIntegrationDto consumptionIntegrationDto = new ConsumptionIntegrationDto
            {
                Quantity = Math.Floor(integrationPercent * (decimal)addCustomerIntergration.ActualPayment),
                Percent = integrationPercent,
                AmountOfConsumption = addCustomerIntergration.ActualPayment.Value,
                Date = DateTime.Now,
                CustomerId = addCustomerIntergration.CustomerId,
                OrderId = addCustomerIntergration.OrderId,
                Type=(int)GenerateType.Handsel,
                HandleBy=addCustomerIntergration.HandleBy
            };
            await this.AddByConsumptionAsync(consumptionIntegrationDto);
            var account=await _integrationAccountRepository.GetIntegrationAccountAsync(addCustomerIntergration.CustomerId);
            SendPointMessageDto sendPointMessageDto = new SendPointMessageDto();
            sendPointMessageDto.CustomerId = addCustomerIntergration.CustomerId;
            sendPointMessageDto.MerchantName = "啊美雅";
            sendPointMessageDto.Title = "消费领积分";
            sendPointMessageDto.ChangeCount = $"+{consumptionIntegrationDto.Quantity}";
            sendPointMessageDto.ExpireDate=$"{DateTime.Now.Year}-12-31";
            sendPointMessageDto.PointBalance = account.Balance;
            await miniProgramTemplateMessageSendService.SendPointChangeMessgaeAsync(sendPointMessageDto);
        }

        /// <summary>
        /// 积分过期
        /// </summary>
        /// <param name="useIntegration"></param>
        /// <returns></returns>
        public async Task ExpiredGoodsConsumption()
        {
            try
            {

                unitOfWork.BeginTransaction();
                var customerIds = await this.GetAllCustomerHasIntergration();
                foreach (var x in customerIds)
                {  //积分余额
                    decimal integrationBalance = await this.GetIntegrationBalanceByCustomerIDAsync(x);
                    if (integrationBalance > 0)
                    {
                        UseIntegrationDto useIntegrationDto = new UseIntegrationDto();
                        useIntegrationDto.CustomerId = x;
                        useIntegrationDto.OrderId = "";
                        useIntegrationDto.Date = DateTime.Now;
                        useIntegrationDto.UseQuantity = integrationBalance;
                        await UseAsync(useIntegrationDto, IntegrationUseType.Expired);
                    }
                }
                unitOfWork.Commit();
            }
            catch (Exception err)
            {
                unitOfWork.RollBack();
                throw new Exception("操作失败！" + err.Message.ToString());

            }
        }
        /// <summary>
        /// 商品消费使用积分
        /// </summary>
        /// <param name="useIntegration"></param>
        /// <returns></returns>
        public async Task UseByGoodsConsumption(UseIntegrationDto useIntegration)
        {
            if (useIntegration.Type == 1)
            {
                await UseAsync(useIntegration, IntegrationUseType.CustomerServiceEdit);
            }
            else {
                await UseAsync(useIntegration, IntegrationUseType.Consumption);
            }
            

        }

        private async Task UseAsync(UseIntegrationDto useIntegration, IntegrationUseType integrationUseType)
        {
            var integrationAccount = await _integrationAccountRepository.GetIntegrationAccountAsync(useIntegration.CustomerId);
            integrationAccount.ReduceIntegration(new UseIntegration((byte)integrationUseType)
            {
                Date = useIntegration.Date,
                OrderId = useIntegration.OrderId,
                Quantity = useIntegration.UseQuantity,
            });
            await _integrationAccountRepository.SaveIntegrationAccountAsync(integrationAccount);
        }
        /// <summary>
        /// 是否存在指定的储值奖励积分记录
        /// </summary>
        /// <param name="customerId">用户id</param>
        /// <param name="amount">奖励金额</param>
        /// <param name="percent">奖励比例</param>
        /// <returns></returns>
        public async Task<bool> ExistRechargeRewardAsync(string customerId, decimal amount, decimal percent)
        {
            var record = await freeSql.Select<IntegrationGenerateRecordDbModel>().Where(e => e.CustomerId == customerId && e.Quantity == amount && e.Percents == percent).FirstAsync();
            return record == null ? false : true;
        }

        public async Task<bool> GetIsIntegrationGenerateRecordByOrderIdAndCustomerIdAsync(string orderId, string customerId)
        {
            var integrationGenerateRecord = await freeSql.Select<IntegrationGenerateRecordDbModel>().Where(e => e.OrderId == orderId && e.CustomerId == customerId).FirstAsync();
            if (integrationGenerateRecord == null)
                return false;
            return true;
        }

        public async Task<bool> ExistNewCustomerRewardAsync(string customerId, decimal amount, int type, string orderId)
        {
            var record = await freeSql.Select<IntegrationGenerateRecordDbModel>().Where(e => e.CustomerId == customerId && e.Quantity == amount && e.Type == type).Where(e=>string.IsNullOrEmpty(orderId)||e.OrderId==orderId).FirstAsync();
            return record == null ? false : true;
        }
    }
}
