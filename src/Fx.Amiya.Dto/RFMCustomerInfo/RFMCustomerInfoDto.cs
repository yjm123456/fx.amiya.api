using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.RFMCustomerInfo
{
    public class RFMCustomerInfoDto
    {
        public string Id { get; set; }
        public string Phone { get; set; }
        /// <summary>
        /// 客服名称
        /// </summary>
        public string CustomerServiceName { get; set; }
        /// <summary>
        /// 最近一次成交时间
        /// </summary>
        public DateTime? LastDealDate { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 最近一次成交金额
        /// </summary>
        public decimal DealPrice { get; set; }
        /// <summary>
        /// 总成交金额
        /// </summary>
        public decimal TotalDealPrice { get; set; }
        /// <summary>
        /// 消费次数
        /// </summary>
        public int ConsumptionFrequency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal RecentDealPrice { get; set; }
        /// <summary>
        /// R
        /// </summary>
        public string Recency { get; set; }
        /// <summary>
        /// F
        /// </summary>
        public string Frequency { get; set; }
        /// <summary>
        /// M
        /// </summary>
        public string Monetary { get; set; }
        /// <summary>
        /// RFM
        /// </summary>
        public string RFMTag { get; set; }
        /// <summary>
        /// RFM等级名称
        /// </summary>
        public string RFMTagText { get; set; }
        /// <summary>
        /// 主播微信号
        /// </summary>
        public string LiveAnchorWechatNo { get; set; }
    }
}
