using Fx.Domain.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fx.Amiya.Modules.Integration.Domin
{
    public class IntegrationAccount : IEntity
    {
        public string CustomerId { get; set; }
        public int Version { get; set; }

        private decimal balance;





        private IEnumerable<IntegrationGenerateRecord> generateRecordList;

        public IEnumerable<IntegrationGenerateRecord> GenerateRecordList
        {
            get { return generateRecordList; }
            set
            {
                if (value.Where(t => t.StockQuantity < 0m).Count() > 0)
                {
                    throw new ArgumentException();
                }
                //generateRecordList = value.Where(t=>t.Balance >0m);  //过滤余额为0的产生记录
                generateRecordList = value;
                this.Balance = generateRecordList.Sum(t => t.StockQuantity);
            }
        }



        /// <summary>
        /// 积分余额
        /// </summary>
        public decimal Balance
        {
            get { return balance; }
            private set
            {
                balance = value;
                if (balance < 0m)
                    throw new ArgumentException("帐户余额有误！");
            }
        }

        public IntegrationUseRecord UseRecord { get; set; }
        public List<IntegrationUseDetailRecord> UseDetails { get; set; }

        public void AddIntegration(Integration integration)
        {
            if (integration == null)
                throw new ArgumentNullException();

            var integrationGenerateRecord = new IntegrationGenerateRecord(integration);
            ((List<IntegrationGenerateRecord>)this.GenerateRecordList).Add(integrationGenerateRecord);
            integrationGenerateRecord.AccountBalance = this.GenerateRecordList.Sum(e => e.StockQuantity);
            Balance = this.GenerateRecordList.Sum(e => e.StockQuantity);
        }


        public void ReduceIntegration(UseIntegration useIntegration)
        {
            if (useIntegration == null)
                throw new ArgumentNullException();
            if (useIntegration.Quantity < 0)
                throw new Exception("减扣积分不能小于0");
            generateRecordList = GenerateRecordList.OrderBy(e => e.Date);
            decimal needUseQuantity = useIntegration.Quantity;
            UseDetails = new List<IntegrationUseDetailRecord>();
            foreach (var item in generateRecordList)
            {
                if (needUseQuantity > 0)
                {
                    UseDetails.Add(item.Use(ref needUseQuantity, useIntegration.Date));
                }

            }

            if (needUseQuantity > 0m)
            {
                UseDetails.Add(new IntegrationUseDetailRecord()
                {
                    Date = useIntegration.Date,
                    GenerateRecordId = null,
                    UseQuantity = needUseQuantity,

                });
            }

            this.UseRecord = new IntegrationUseRecord(useIntegration.Quantity, useIntegration.Date, useIntegration.UseType, useIntegration.OrderId);
            this.Balance = generateRecordList.Sum(e => e.StockQuantity);
            this.UseRecord.AccountBalance = this.Balance;
        }
    }
}
