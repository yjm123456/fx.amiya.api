using FreeSql;
using Fx.Amiya.Modules.Integration.DbModel;
using Fx.Amiya.Modules.Integration.Domin;
using Fx.Amiya.Modules.Integration.Domin.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.Infrastructure.Repositories
{
    public class IntegrationAccountRepository : IIntegrationAccountRepository
    {
        private IFreeSql<IntegrationFlag> freeSql;
        public IntegrationAccountRepository(IFreeSql<IntegrationFlag> freeSql)
        {
            this.freeSql = freeSql;
        }

        public async Task<IntegrationAccount> GetIntegrationAccountAsync(string customerId)
        {
            var integrationAccount = await freeSql.Select<IntegrationAccountDbModel>().Where(e => e.CustomerId == customerId).FirstAsync();
            if (integrationAccount == null)
                return null;

            return new IntegrationAccount()
            {
                CustomerId = integrationAccount.CustomerId,
                GenerateRecordList = (from d in await freeSql.Select<IntegrationGenerateRecordDbModel>().Where(e => e.CustomerId == customerId).ToListAsync()
                                      select new IntegrationGenerateRecord
                                      {
                                          Date = d.Date,
                                          Id = d.Id,
                                          StockQuantity = d.StockQuantity,
                                          AccountBalance = d.AccountBalance,
                                          IntegrationRecord = new Domin.Integration
                                          {
                                              Date = d.Date,
                                              CustomerId = d.CustomerId,
                                              ExpiredDate = d.ExpiredDate,
                                              Quantity = d.Quantity
                                          }
                                      }).ToList()
            };

        }

        public async Task<List<string>> GetAllIntegrationAccountAsync()
        {
            var integrationAccount = await freeSql.Select<IntegrationAccountDbModel>().Where(x => x.Balance > 0).ToListAsync();
            List<string> result = new List<string>();
            foreach (var x in integrationAccount)
            {
                result.Add(x.CustomerId);
            }
            return result;
        }

        public async Task SaveIntegrationAccountAsync(IntegrationAccount entity)
        {
            using (var uowManager = new UnitOfWorkManager(freeSql))
            {
                using (var uow = uowManager.Begin())
                {
                    try
                    {
                        var integrationAccount = await freeSql.Select<IntegrationAccountDbModel>().Where(e => e.CustomerId == entity.CustomerId).FirstAsync();
                        if (integrationAccount == null)
                        {
                            IntegrationAccountDbModel integrationAccountDbModel = new IntegrationAccountDbModel()
                            {
                                CustomerId = entity.CustomerId,
                                Balance = entity.Balance,
                                Version = entity.Version
                            };
                            await freeSql.Insert<IntegrationAccountDbModel>().WithTransaction(uow.GetOrBeginTransaction()).AppendData(integrationAccountDbModel).ExecuteAffrowsAsync();
                        }


                        await freeSql.Update<IntegrationAccountDbModel>()
                            .WithTransaction(uow.GetOrBeginTransaction())
                            .Set(e => e.Balance, entity.Balance)
                            .Where(e => e.CustomerId == entity.CustomerId)
                            .ExecuteAffrowsAsync();

                        long generateRecordId = 0;
                        foreach (var record in entity.GenerateRecordList)
                        {
                            if (record.Id == null)
                            {

                                if (record.IntegrationRecord is ConsumptionIntegration consumptionIntegration)
                                {
                                    IntegrationGenerateRecordDbModel model = new IntegrationGenerateRecordDbModel();
                                    model.StockQuantity = record.StockQuantity;
                                    model.CustomerId = entity.CustomerId;
                                    model.Date = record.Date;
                                    model.Quantity = record.IntegrationRecord.Quantity;
                                    model.ExpiredDate = record.IntegrationRecord.ExpiredDate;
                                    model.AccountBalance = record.AccountBalance;
                                    model.Type = (byte)consumptionIntegration.GenerateType;
                                    model.Percents = consumptionIntegration.Percent;
                                    model.AmountOfConsumption = consumptionIntegration.AmountOfConsumption;
                                    model.OrderId = consumptionIntegration.OrderId;
                                    model.ProviderId = consumptionIntegration.ProviderId;
                                    model.HandleBy = consumptionIntegration.HandleBy;
                                    generateRecordId = await freeSql.Insert<IntegrationGenerateRecordDbModel>().WithTransaction(uow.GetOrBeginTransaction()).AppendData(model).ExecuteIdentityAsync();
                                }

                                else if (record.IntegrationRecord is ReturnGiftIntegration returnGiftIntegration)
                                {
                                    IntegrationGenerateRecordDbModel model = new IntegrationGenerateRecordDbModel();
                                    model.StockQuantity = record.StockQuantity;
                                    model.CustomerId = entity.CustomerId;
                                    model.Date = record.Date;
                                    model.Quantity = record.IntegrationRecord.Quantity;
                                    model.ExpiredDate = record.IntegrationRecord.ExpiredDate;
                                    model.AccountBalance = record.AccountBalance;
                                    model.Type = (byte)returnGiftIntegration.GenerateType;
                                    model.HandleBy = returnGiftIntegration.HandleBy;
                                    model.OrderId = returnGiftIntegration.OrderId;
                                    generateRecordId = await freeSql.Insert<IntegrationGenerateRecordDbModel>().WithTransaction(uow.GetOrBeginTransaction()).AppendData(model).ExecuteIdentityAsync();
                                }

                                else if (record.IntegrationRecord is HandselIntegration handselIntegration)
                                {
                                    IntegrationGenerateRecordDbModel model = new IntegrationGenerateRecordDbModel();
                                    model.StockQuantity = record.StockQuantity;
                                    model.CustomerId = entity.CustomerId;
                                    model.Date = record.Date;
                                    model.Quantity = record.IntegrationRecord.Quantity;
                                    model.ExpiredDate = record.IntegrationRecord.ExpiredDate;
                                    model.AccountBalance = record.AccountBalance;
                                    model.Type = (byte)handselIntegration.GenerateType;
                                    model.HandleBy = handselIntegration.HandleBy;
                                    generateRecordId = await freeSql.Insert<IntegrationGenerateRecordDbModel>().WithTransaction(uow.GetOrBeginTransaction()).AppendData(model).ExecuteIdentityAsync();
                                }

                                else if (record.IntegrationRecord is ReturnMoneyReturnIntegration returnMoneyReturnIntegration)
                                {
                                    IntegrationGenerateRecordDbModel model = new IntegrationGenerateRecordDbModel();
                                    model.StockQuantity = record.StockQuantity;
                                    model.CustomerId = entity.CustomerId;
                                    model.Date = record.Date;
                                    model.Quantity = record.IntegrationRecord.Quantity;
                                    model.ExpiredDate = record.IntegrationRecord.ExpiredDate;
                                    model.AccountBalance = record.AccountBalance;
                                    model.Type = (byte)returnMoneyReturnIntegration.GenerateType;
                                    model.OrderId = returnMoneyReturnIntegration.OrderId;
                                    generateRecordId = await freeSql.Insert<IntegrationGenerateRecordDbModel>().WithTransaction(uow.GetOrBeginTransaction()).AppendData(model).ExecuteIdentityAsync();
                                }


                            }
                            else
                            {
                                await freeSql.Update<IntegrationGenerateRecordDbModel>()
                                    .WithTransaction(uow.GetOrBeginTransaction())
                                    .Set(e => e.StockQuantity, record.StockQuantity)
                                    .Where(e => e.Id == record.Id)
                                    .ExecuteAffrowsAsync();
                            }
                        }
                        if (entity.UseRecord != null)
                        {
                            IntegrationUseRecordDbModel integrationUseRecord = new IntegrationUseRecordDbModel();
                            integrationUseRecord.CustomerId = entity.CustomerId;
                            integrationUseRecord.Date = entity.UseRecord.Date;
                            integrationUseRecord.UseQuantity = entity.UseRecord.UseQuantity;
                            integrationUseRecord.UseType = entity.UseRecord.UseType;
                            integrationUseRecord.AccountBalance = entity.UseRecord.AccountBalance;
                            integrationUseRecord.OrderId = entity.UseRecord.OrderId;
                            integrationUseRecord.Id = await freeSql.Insert<IntegrationUseRecordDbModel>().WithTransaction(uow.GetOrBeginTransaction()).AppendData(integrationUseRecord).ExecuteIdentityAsync();

                            foreach (var item in entity.UseDetails)
                            {
                                IntegrationUseDetailRecordDbModel integrationUseDetailRecord = new IntegrationUseDetailRecordDbModel();
                                integrationUseDetailRecord.UseRecordId = integrationUseRecord.Id;
                                integrationUseDetailRecord.UseQuantity = item.UseQuantity;
                                if (item.GenerateRecordId != null)
                                {
                                    integrationUseDetailRecord.GenerateRecordId = item.GenerateRecordId;
                                }
                                else
                                {
                                    integrationUseDetailRecord.GenerateRecordId = generateRecordId;
                                }
                                await freeSql.Insert<IntegrationUseDetailRecordDbModel>().WithTransaction(uow.GetOrBeginTransaction()).AppendData(integrationUseDetailRecord).ExecuteIdentityAsync();
                            }

                        }
                        uow.Commit();
                    }
                    catch (Exception ex)
                    {
                        uow.Rollback();
                        throw ex;

                    }
                }

            }
        }
    }
}
