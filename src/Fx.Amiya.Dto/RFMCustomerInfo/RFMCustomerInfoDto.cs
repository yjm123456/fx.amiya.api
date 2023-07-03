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
        /// 加密手机号
        /// </summary>
        public string EncryptPhone { get; set; }
        /// <summary>
        /// 客服id
        /// </summary>
        public int? CustomerServiceId { get; set; }
        /// <summary>
        /// 客服名称
        /// </summary>
        public string CustomerServiceName { get; set; }
        /// <summary>
        /// 最近一次成交时间
        /// </summary>
        public DateTime? LastDealDate { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public  int? HospitalId { get; set; }
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
        public int RecencyDate { get; set; }
        public int RecencyLeave { get; set; }
        /// <summary>
        /// R
        /// </summary>
        public string Recency { get; set; }
        public int FrequencyLeave { get; set; }
        /// <summary>
        /// F
        /// </summary>
        public string Frequency { get; set; }
        public int MonetaryLeave { get; set; }
        /// <summary>
        /// M
        /// </summary>
        public string Monetary { get; set; }

        public int RFMTagLeave { get; set; }
        /// <summary>
        /// RFM
        /// </summary>
        public string RFMTag { get; set; }
        /// <summary>
        /// RFM等级名称
        /// </summary>
        public string RFMTagText { get; set; }
        public string LiveAnchorWechatNoId { get; set; }
        /// <summary>
        /// 主播微信号
        /// </summary>
        public string LiveAnchorWechatNo { get; set; }
    }
}
