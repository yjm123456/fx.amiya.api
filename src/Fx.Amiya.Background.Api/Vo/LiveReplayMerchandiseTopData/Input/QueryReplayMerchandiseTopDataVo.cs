﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveReplayMerchandiseTopData.Input
{
    public class QueryReplayMerchandiseTopDataDataVo : BaseQueryVo
    {
        public bool Valid { get; set; }
        public string LiveReplayId { get; set; }
    }
}
