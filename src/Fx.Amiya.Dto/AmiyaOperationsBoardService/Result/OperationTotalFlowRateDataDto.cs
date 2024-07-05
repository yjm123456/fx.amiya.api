using Fx.Amiya.Dto.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class OperationTotalFlowRateDataDto
    {

        /// <summary>
        /// 总分诊
        /// </summary>
        public decimal TotalDistributeConsulation { get; set; }
        /// <summary>
        /// 当日分诊
        /// </summary>
        public decimal? TodayDistributeConsulation { get; set; }


        /// <summary>
        /// 分诊目标完成率
        /// </summary>
        public decimal? DistributeConsulationCompleteRate { get; set; }

        /// <summary>
        /// 分诊同比
        /// </summary>
        public decimal? DistributeConsulationYearOnYear { get; set; }

        /// <summary>
        /// 分诊环比
        /// </summary>
        public decimal? DistributeConsulationChainRatio { get; set; }

        /// <summary>
        /// 总加v
        /// </summary>
        public decimal TotalAddWechat { get; set; }
        /// <summary>
        /// 当日加v
        /// </summary>
        public decimal? TodayAddWechat { get; set; }


        /// <summary>
        /// 加v目标完成率
        /// </summary>
        public decimal? AddWechatCompleteRate { get; set; }

        /// <summary>
        /// 加v同比
        /// </summary>
        public decimal? AddWechatYearOnYear { get; set; }

        /// <summary>
        /// 加v环比
        /// </summary>
        public decimal? AddWechatChainRatio { get; set; }

        /// <summary>
        /// 总派单
        /// </summary>
        public decimal TotalSendOrder { get; set; }
        /// <summary>
        /// 当日总派单
        /// </summary>
        public decimal? TodayTotalSendOrder { get; set; }

        /// <summary>
        /// 总派单目标完成率
        /// </summary>
        public decimal? TotalSendOrderCompleteRate { get; set; }

        /// <summary>
        /// 总派单同比
        /// </summary>
        public decimal? TotalSendOrderYearOnYear { get; set; }

        /// <summary>
        /// 总派单环比
        /// </summary>
        public decimal? TotalSendOrderChainRatio { get; set; }

        /// <summary>
        /// 总上门
        /// </summary>
        public decimal TotalVisit { get; set; }
        /// <summary>
        /// 当日上门
        /// </summary>
        public decimal? TodayVisit { get; set; }


        /// <summary>
        /// 上门目标完成率
        /// </summary>
        public decimal? VisitCompleteRate { get; set; }

        /// <summary>
        /// 上门同比
        /// </summary>
        public decimal? VisitYearOnYear { get; set; }

        /// <summary>
        /// 上门环比
        /// </summary>
        public decimal? VisitChainRatio { get; set; }
        /// <summary>
        /// 分诊折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> DistributeConsulationBrokenLineList { get; set; }
        /// <summary>
        /// 加v折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> AddWeChatBrokenLineList { get; set; }
        /// <summary>
        /// 派单折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> SendOrderBrokenLineList { get; set; }
    }
}
