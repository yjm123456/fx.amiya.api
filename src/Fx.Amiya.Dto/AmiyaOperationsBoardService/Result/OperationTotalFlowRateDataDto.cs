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
        /// 总线索
        /// </summary>
        public decimal TotalFlowRate { get; set; }
        /// <summary>
        /// 当日总线索
        /// </summary>
        public decimal? TodayTotalFlowRate { get; set; }

        /// <summary>
        /// 总线索目标完成率
        /// </summary>
        public decimal? TotalFlowRateCompleteRate { get; set; }

        /// <summary>
        /// 总线索同比
        /// </summary>
        public decimal? TotalFlowRateYearOnYear { get; set; }

        /// <summary>
        /// 总线索环比
        /// </summary>
        public decimal? TotalFlowRateChainRatio { get; set; }

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
        /// 总退卡
        /// </summary>
        public decimal TotalRefundCard { get; set; }
        /// <summary>
        /// 当日退卡
        /// </summary>
        public decimal? TodayRefundCard { get; set; }


        /// <summary>
        /// 退卡目标完成率
        /// </summary>
        public decimal? RefundCardCompleteRate { get; set; }

        /// <summary>
        /// 退卡同比
        /// </summary>
        public decimal? RefundCardYearOnYear { get; set; }

        /// <summary>
        /// 退卡环比
        /// </summary>
        public decimal? RefundCardChainRatio { get; set; }
        /// <summary>
        /// 线索折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> FlowRateBrokenLineList { get; set; }
        /// <summary>
        /// 分诊折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> DistributeConsulationBrokenLineList { get; set; }
        /// <summary>
        /// 加v折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> AddWeChatBrokenLineList { get; set; }
    }
}
