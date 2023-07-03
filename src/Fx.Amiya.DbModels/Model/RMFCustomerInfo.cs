using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class RMFCustomerInfo:BaseDbModel
    {
        
        /// <summary>
        /// 客服id
        /// </summary>
        public int? CustomerServiceId  { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 最近一次成交时间
        /// </summary>
        public DateTime? LastDealDate { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int? HospitalId { get; set; }
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
        /// 最近一次消费距离当前时间的天数
        /// </summary>
        public int RecencyDate { get; set; }
        /// <summary>
        /// R
        /// </summary>
        public int Recency { get; set; }
        /// <summary>
        /// F
        /// </summary>
        public int Frequency { get; set; }
        /// <summary>
        /// M
        /// </summary>
        public int Monetary { get; set; }
        /// <summary>
        /// RFM
        /// </summary>
        public int RFMTag { get; set; }
        /// <summary>
        /// 主播微信号
        /// </summary>
        public string LiveAnchorWechatNo { get; set; }
    }
}
