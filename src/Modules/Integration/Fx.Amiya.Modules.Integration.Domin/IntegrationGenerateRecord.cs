using Fx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.Domin
{
   public class IntegrationGenerateRecord
    {
        public long? Id { get; set; }

        public DateTime Date { get; set; }

        /// <summary>
        /// 这条充值记录还剩下的余额
        /// </summary>
        public decimal StockQuantity { get; set; }

        /// <summary>
        /// 该客户的积分账户实时余额（产生这条记录的时候的余额）
        /// </summary>
        public decimal AccountBalance { get; set; }

        public Integration IntegrationRecord { get; set; }

        public IntegrationGenerateRecord(Integration integration)
        {
            Id = null;
            IntegrationRecord = integration;
            StockQuantity = integration.Quantity;
            Date = integration.Date;
        }
        public IntegrationGenerateRecord()
        {
            Id = null;
        }


        public IntegrationUseDetailRecord Use(ref decimal useQuantity, DateTime useDate)
        {
            decimal quantity = 0m;
            if (useQuantity >= StockQuantity)
            {
                useQuantity -= StockQuantity;
                quantity = StockQuantity;
                StockQuantity = 0m;
            }
            else
            {
                StockQuantity -= useQuantity;
                quantity = useQuantity;
                useQuantity = 0m;
            }
            return new IntegrationUseDetailRecord()
            {
                GenerateRecordId=Id,
                Date=useDate,
                UseQuantity=quantity,

            };
        }
    }
}
