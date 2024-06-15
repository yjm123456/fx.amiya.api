using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class OperationBoardContentPlatFormDataDto
    {
        /// <summary>
        /// 整体流量分析
        /// </summary>
        public OperationBoardContentPlatFormDataDetailsDto TotalFlowRate { get; set; }
        /// <summary>
        /// 刀刀组流量分析
        /// </summary>
        public OperationBoardContentPlatFormDataDetailsDto GroupDaoDaoFlowRate { get; set; }
        /// <summary>
        /// 吉娜组流量分析
        /// </summary>
        public OperationBoardContentPlatFormDataDetailsDto GroupJiNaFlowRate { get; set; }
    }
    public class OperationBoardContentPlatFormDataDetailsDto
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
