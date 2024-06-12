using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Input
{
    public class QueryTransformDataVo
    {
      
        /// <summary>
        /// 抖音
        /// </summary>
        public bool ShowTikTok { get; set; }
        /// <summary>
        /// 小红书
        /// </summary>
        public bool ShowXiaoHongShu { get; set; }
        /// <summary>
        /// 视频号
        /// </summary>
        public bool ShowWechatVideo { get; set; }
        /// <summary>
        /// 私域
        /// </summary>
        public bool ShowPrivateDomain { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
