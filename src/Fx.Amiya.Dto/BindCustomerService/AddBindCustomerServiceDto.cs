using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.BindCustomerService
{
   public class AddBindCustomerServiceDto
    {
        public int CustomerServiceId { get; set; }
        public List<string> OrderIdList { get; set; }
    }

    public class AddBindCustomerServiceFirstlyDto
    {

        public string BuyerPhone { get; set; }
        public DateTime CreateDate { get; set; }
        public int CustomerServiceId { get; set; }
        public int CreateBy { get; set; }
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
        /// 最近消费所属主播
        /// </summary>
        public string NewLiveAnchor { get; set; }
        /// <summary>
        /// 最近消费所属微信号
        /// </summary>
        public string NewWechatNo { get; set; }
    }
}
