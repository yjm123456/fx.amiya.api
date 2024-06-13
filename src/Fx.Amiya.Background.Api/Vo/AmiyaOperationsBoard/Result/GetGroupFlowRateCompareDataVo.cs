using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    /// <summary>
    /// 流量分析占比展示
    /// </summary>
    public class GetGroupFlowRateCompareDataVo
    {
        /// <summary>
        /// 整体流量分析
        /// </summary>
        public OperationBoardContentPlatFormDataVo TotalFlowRate { get; set; }
        /// <summary>
        /// 刀刀组流量分析
        /// </summary>
        public OperationBoardContentPlatFormDataVo GroupDaoDaoFlowRate { get; set; }
        /// <summary>
        /// 吉娜组流量分析
        /// </summary>
        public OperationBoardContentPlatFormDataVo GroupJiNaFlowRate { get; set; }
    }
    public class OperationBoardContentPlatFormDataVo
    {
        /// <summary>
        /// 抖音（占比）
        /// </summary>
        public decimal? DouYinRate { get; set; }
        /// <summary>
        /// 视频号（占比）
        /// </summary>
        public decimal? VideoNumberRate { get; set; }

        /// <summary>
        /// 小红书（占比）
        /// </summary>
        public decimal? XiaoHongShuRate { get; set; }

        /// <summary>
        /// 私域（占比）
        /// </summary>
        public decimal? PrivateDataRate { get; set; }
        /// <summary>
        /// 抖音（数值）
        /// </summary>
        public decimal? DouYinNumber { get; set; }
        /// <summary>
        /// 视频号（数值）
        /// </summary>
        public decimal? VideoNumberNumber { get; set; }

        /// <summary>
        /// 小红书（数值）
        /// </summary>
        public decimal? XiaoHongShuNumber { get; set; }

        /// <summary>
        /// 私域（数值）
        /// </summary>
        public decimal? PrivateDataNumber { get; set; }
    }
}

