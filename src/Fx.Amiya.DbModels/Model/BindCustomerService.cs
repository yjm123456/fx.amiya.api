using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class BindCustomerService
    {
        public int Id { get; set; }
        public int CustomerServiceId { get; set; }
        public string BuyerPhone { get; set; }
        public string UserId { get; set; } 
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 首次项目需求
        /// </summary>
        public string FirstProjectDemand { get; set; }
        /// <summary>
        /// 首次消费时间
        /// </summary>
        public DateTime? FirstConsumptionDate { get; set; }
        /// <summary>
        /// 最新消费时间
        /// </summary>

        public DateTime? NewConsumptionDate { get; set; }
        /// <summary>
        /// 最新消费平台
        /// </summary>
        public int? NewConsumptionContentPlatform { get; set; }

        /// <summary>
        /// 最新消费渠道
        /// </summary>
        public string NewContentPlatForm { get; set; }

        /// <summary>
        /// 累计消费
        /// </summary>
        public decimal? AllPrice { get; set; }

        /// <summary>
        /// 总单数
        /// </summary>
        public int? AllOrderCount { get; set; }


        public AmiyaEmployee CustomerServiceAmiyaEmployee { get; set; }
        public AmiyaEmployee CreateByAmiyaEmployee { get; set; }
    }
}
