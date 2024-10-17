using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class BeforeLiveDepartmentContentPlatformClueRateDto
    {
        /// <summary>
        /// 部门平台线索占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformClueRateDataItemDto> DepartmentContentPlatformClueRate { get; set; }
        /// <summary>
        /// 抖音部门平台线索占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformClueRateDataItemDto> TikTokClueRate { get; set; }
        /// <summary>
        /// 视频号部门平台线索占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformClueRateDataItemDto> WechatVideoClueRate { get; set; }
        /// <summary>
        /// 小红书部门平台线索占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformClueRateDataItemDto> XiaohongshuClueRate { get; set; }

      

    }
    public class BeforeLiveDepartmentContentPlatformClueRateDataItemDto
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
