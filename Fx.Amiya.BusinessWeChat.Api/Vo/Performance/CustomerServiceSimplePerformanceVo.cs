using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.Performance
{
    /// <summary>
    /// 客服基础业绩
    /// </summary>
    public class CustomerServiceSimplePerformanceVo
    {

        /// <summary>
        /// 客服名称
        /// </summary>
        public string CustomerServiceName { get; set; }
        /// <summary>
        /// 排名
        /// </summary>
        public string Rank { get; set; }
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotaPrice { get; set; }

        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPrice { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPrice { get; set; }
        /// <summary>
        /// 新老客业绩占比
        /// </summary>
        public string NewOrOldCustomerRate { get; set; }
        /// <summary>
        /// 当月派单+历史派单当月上门率
        /// </summary>
        public decimal? VisitRate { get; set; }
        /// <summary>
        /// 当月派单当月上门率
        /// </summary>
        public decimal? ThisMonthSendThisMonthVisitNumRatio { get; set; }

        /// <summary>
        /// 新诊人数
        /// </summary>
        public int NewCustomerNum { get; set; }

        /// <summary>
        /// 复诊人数
        /// </summary>
        public int SequentCustomerNum { get; set; }

        /// <summary>
        /// 成交人数
        /// </summary>
        public int DealNum { get; set; }

        /// <summary>
        /// 老客人数
        /// </summary>
        public int OldCustomerNum { get; set; }

        /// <summary>
        /// 排名集合
        /// </summary>
        public List<CustomerServiceRankVo> CustomerServiceRankDtoList { get; set; }
    }

    /// <summary>
    /// 客服排名类
    /// </summary>

    public class CustomerServiceRankVo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int RankId { get; set; }
        /// <summary>
        /// 客服名称
        /// </summary>
        public string CustomerServiceName { get; set; }
        /// <summary>
        /// 业绩
        /// </summary>

        public decimal TotalAchievement { get; set; }
    }
}
