using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AssistantHomePage.Input
{
    public class QueryAssistantHomePageTrackDataVo: QueryAssistantHomePageDataVo
    {
        /// <summary>
        /// 1:未回访,2:已回访
        /// </summary>
        public int Type { get; set; }
    }
}
