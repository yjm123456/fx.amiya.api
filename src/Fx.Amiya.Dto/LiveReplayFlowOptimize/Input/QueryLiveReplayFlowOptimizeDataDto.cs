using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveReplayFlowOptimize.Input
{
    public class QueryLiveReplayFlowOptimizeDataDto:BaseQueryDto
    {
        public bool Valid { get; set; }
        public string LiveReplayId { get; set; }
    }
}
