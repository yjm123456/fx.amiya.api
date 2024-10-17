using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class BeforeLiveDepartmentContentPlatformPerformanceRateDto
    {
        /// <summary>
        /// 部门平台业绩占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformPerformanceRateDataItemDto> DepartmentContentPlatformPerformanceRate { get; set; }
        /// <summary>
        /// 抖音部门平台业绩占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformPerformanceRateDataItemDto> TikTokPerformanceRate { get; set; }
        /// <summary>
        /// 视频号部门平台业绩占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformPerformanceRateDataItemDto> WechatVideoPerformanceRate { get; set; }
        /// <summary>
        /// 小红书部门平台业绩占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformPerformanceRateDataItemDto> XiaohongshuPerformanceRate { get; set; }
    }
    public class BeforeLiveDepartmentContentPlatformPerformanceRateDataItemDto
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
