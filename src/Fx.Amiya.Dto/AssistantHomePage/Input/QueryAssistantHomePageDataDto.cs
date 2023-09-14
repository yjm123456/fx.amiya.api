using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AssistantHomePage.Input
{
    public class QueryAssistantHomePageDataDto:BaseQueryDto
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// 基础主播id
        /// </summary>
        public string BaseLiveAnchorId { get; set; }
        /// <summary>
        /// 平台id
        /// </summary>
        public string ContentPlatformId { get; set; }
        /// <summary>
        /// 主播id
        /// </summary>
        public int? LiveAnchorId { get; set; }
        /// <summary>
        /// 微信号id
        /// </summary>
        public string WechatNoId { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public int? Source { get; set; }
        /// <summary>
        /// 助理id
        /// </summary>
        public int? AssistantId { get; set; }
    }
}
