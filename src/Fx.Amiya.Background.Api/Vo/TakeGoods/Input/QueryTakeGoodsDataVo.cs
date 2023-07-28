using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TakeGoods.Input
{
    /// <summary>
    /// gmv看板数据查询
    /// </summary>
    public class QueryGmvDataVo
    {
        /// <summary>
        /// 平台id
        /// </summary>
        public string ContentPlatformId { get; set; }
        /// <summary>
        /// 主播id
        /// </summary>
        public string LiveAnchorId { get; set; }
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; set; }
    }
}
