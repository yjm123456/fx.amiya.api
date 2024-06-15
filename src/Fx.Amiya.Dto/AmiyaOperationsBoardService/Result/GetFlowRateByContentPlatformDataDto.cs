using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class GetFlowRateByContentPlatformDataDto
    {
        /// <summary>
        /// 抖音流量分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> DouYinFolwRateAnalize { get; set; }
        /// <summary>
        /// 视频号流量分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> VideoNumberFolwRateAnalize { get; set; }
        /// <summary>
        /// 小红书流量分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> XiaoHongShuFolwRateAnalize { get; set; }
        /// <summary>
        /// 私域流量分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> PrivateDataFolwRateAnalize { get; set; }
    }
    /// <summary>
    /// 流量分析详情
    /// </summary>
    public class GetFlowRateDetailsByContentPlatformDataDto
    {
        /// <summary>
        /// 流量详情
        /// </summary>
        public List<BaseKeyValueAndPercentDto> FolwRateDetailsAnalize { get; set; }
    }
}
