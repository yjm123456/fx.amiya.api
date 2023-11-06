using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.BindCustomerService
{
   public class BindCustomerServiceDto
    {
        public int Id { get; set; }
        public int CustomerServiceId { get; set; }
        public string CustomerServiceName { get; set; }
        public string BuyerPhone { get; set; }
        public string EncryptPhone { get; set; }
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

        /// <summary>
        /// 距今消费间隔天数
        /// </summary>
        public int ConsumptionDate { get; set; }

        /// <summary>
        /// RFM类型
        /// </summary>
        public int RfmType { get; set; }

        /// <summary>
        /// RFM类型文本
        /// </summary>
        public string RfmTypeText { get; set; }
        /// <summary>
        /// 累计发放礼品次数
        /// </summary>
        public int? SystemSendGiftTime { get; set; }

        /// <summary>
        /// 最近发放礼品时间
        /// </summary>
        public DateTime? NewSystemSendGiftDate { get; set; }

    }
}
