using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class BeforeLiveDepartmentContentPlatformPerformanceRateVo
    {
        /// <summary>
        /// 部门平台业绩占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformPerformanceRateDataItemVo> DepartmentContentPlatformPerformanceRate { get; set; }
        /// <summary>
        /// 抖音部门平台业绩占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformPerformanceRateDataItemVo> TikTokPerformanceRate { get; set; }
        /// <summary>
        /// 视频号部门平台业绩占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformPerformanceRateDataItemVo> WechatVideoPerformanceRate { get; set; }
        /// <summary>
        /// 小红书部门平台业绩占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformPerformanceRateDataItemVo> XiaohongshuPerformanceRate { get; set; }
    }
    public class BeforeLiveDepartmentContentPlatformPerformanceRateDataItemVo
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
