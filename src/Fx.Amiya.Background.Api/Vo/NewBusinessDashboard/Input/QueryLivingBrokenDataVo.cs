using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.NewBusinessDashboard
{
    public class QueryLivingBrokenDataVo
    {
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }
        
        /// <summary>
        /// 基础主播id(不传为查总体)
        /// </summary>
        public string BaseLiveAnchorId { get; set; }
        /// <summary>
        /// 是否查询抖音数据
        /// </summary>
        public bool ShowTikTokData { get; set; }
        /// <summary>
        /// 是否查询视频号数据
        /// </summary>
        public bool ShowWechatVideoData { get; set; }
        
    }
}
