using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class BeforeLiveDepartmentContentPlatformClueRateVo
    {
        /// <summary>
        /// 部门平台线索占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformClueRateDataItemVo> DepartmentContentPlatformClueRate { get; set; }
        /// <summary>
        /// 抖音部门平台线索占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformClueRateDataItemVo> TikTokClueRate { get; set; }
        /// <summary>
        /// 视频号部门平台线索占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformClueRateDataItemVo> WechatVideoClueRate { get; set; }
        /// <summary>
        /// 小红书部门平台线索占比
        /// </summary>
        public List<BeforeLiveDepartmentContentPlatformClueRateDataItemVo> XiaohongshuClueRate { get; set; }



    }
    public class BeforeLiveDepartmentContentPlatformClueRateDataItemVo
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
