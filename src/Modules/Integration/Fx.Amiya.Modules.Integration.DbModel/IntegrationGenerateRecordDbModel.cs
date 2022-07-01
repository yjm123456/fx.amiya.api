using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;

namespace Fx.Amiya.Modules.Integration.DbModel
{
   public class IntegrationGenerateRecordDbModel
    {
        [Column(IsIdentity =true)]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string CustomerId { get; set; }
        public byte Type { get; set; }
        public decimal Quantity { get; set; }
        public string OrderId { get; set; }

        /// <summary>
        ///  订单总额
        /// </summary>
        public decimal AmountOfConsumption { get; set; }


        /// <summary>
        /// 产生比例
        /// </summary>
        public decimal Percents { get; set; }

        /// <summary>
        /// 客户介绍的人消费了产生的（预留）
        /// </summary>
        public string ProviderId { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? ExpiredDate { get; set; }

        /// <summary>
        /// 这条充值记录还剩下的余额
        /// </summary>
        public decimal StockQuantity { get; set; }

        /// <summary>
        /// 该客户的积分账户实时余额（产生这条记录的时候的余额）
        /// </summary>
        public decimal AccountBalance { get; set; }

        public int? HandleBy { get; set; }

        public List<IntegrationUseDetailRecordDbModel> IntegrationUseDetailRecordList { get; set; }
    }
}
