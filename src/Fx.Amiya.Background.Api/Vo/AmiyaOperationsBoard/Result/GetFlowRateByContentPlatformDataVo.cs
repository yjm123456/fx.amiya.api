using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    /// <summary>
    /// 运营看板-平台数据分析
    /// </summary>
    public class GetFlowRateByContentPlatformDataVo
    {
        /// <summary>
        /// 抖音流量分析
        /// </summary>
        public List<BaseIdNameAndRateVo> DouYinFolwRateAnalize { get; set; }
        /// <summary>
        /// 视频号流量分析
        /// </summary>
        public List<BaseIdNameAndRateVo> VideoNumberFolwRateAnalize { get; set; }
        /// <summary>
        /// 小红书流量分析
        /// </summary>
        public List<BaseIdNameAndRateVo> XiaoHongShuFolwRateAnalize { get; set; }
        /// <summary>
        /// 私域流量分析
        /// </summary>
        public List<BaseIdNameAndRateVo> PrivateDataFolwRateAnalize { get; set; }
    }
    /// <summary>
    /// 流量分析详情
    /// </summary>
    public class GetFlowRateDetailsByContentPlatformDataVo
    {
        /// <summary>
        /// 小风车流量分析
        /// </summary>
        public List<BaseIdNameAndRateVo> XiaoFengCheFolwRateAnalize { get; set; }
        /// <summary>
        /// 私信流量分析
        /// </summary>
        public List<BaseIdNameAndRateVo> PersonalChatFolwRateAnalize { get; set; }
        /// <summary>
        /// 直播间流量分析
        /// </summary>
        public List<BaseIdNameAndRateVo> LivingRoomFolwRateAnalize { get; set; }
        /// <summary>
        /// 短视频流量分析
        /// </summary>
        public List<BaseIdNameAndRateVo> ShortVideoFolwRateAnalize { get; set; }
    }
}
