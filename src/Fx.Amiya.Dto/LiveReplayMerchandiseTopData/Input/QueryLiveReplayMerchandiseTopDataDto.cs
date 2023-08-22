using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveReplayMerchandiseTopData.Input
{
    public class QueryLiveReplayMerchandiseTopDataDto : BaseQueryDto
    {
        public bool Valid { get; set; }
        public string LiveReplayId { get; set; }
    }
}
