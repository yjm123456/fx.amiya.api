using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AssistantHomePage.Input
{
    public class QueryAssistantHomePageTrackDataDto: QueryAssistantHomePageDataDto
    {
        /// <summary>
        /// 1:未回访,2:已回访
        /// </summary>
        public int Type { get; set; }
    }
}
