using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveReplayInteractionlData.Input
{
    public class QueryLiveReplayInteractionlDataDto : BaseQueryDto
    {
        public bool Valid { get; set; }
        public string LiveReplayId { get; set; }
    }
}
