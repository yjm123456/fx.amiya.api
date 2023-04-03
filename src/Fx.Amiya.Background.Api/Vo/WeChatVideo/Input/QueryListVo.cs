using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WeChatVideo.Input
{
    public class QueryListVo:BaseQueryVo
    {
        /// <summary>
        /// 归属主播id
        /// </summary>
        public int? BelongLiveAnchorId { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public int? OrderType { get; set; }
    }
}
