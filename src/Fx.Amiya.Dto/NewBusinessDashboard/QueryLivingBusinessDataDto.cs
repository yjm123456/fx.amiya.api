using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.NewBusinessDashboard
{
    public class QueryLivingBusinessDataDto
    {
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// 主播id(不传查所有)
        /// </summary>
        public string BaseLiveAnchorId { get; set; }
        /// <summary>
        /// 是否查询抖音数据
        /// </summary>
        public bool ShowTikokData { get; set; }
        /// <summary>
        /// 是否查询视频号数据
        /// </summary>
        public bool ShowWechatVideoData { get; set; }
        /// <summary>
        /// 是否查询小红书数据
        /// </summary>
        public bool ShowXiaoHongShuData { get; set; }
        /// <summary>
        /// 是否查询小程序数据
        /// </summary>
        public bool ShowMiniProgram { get; set; }
    }
}
