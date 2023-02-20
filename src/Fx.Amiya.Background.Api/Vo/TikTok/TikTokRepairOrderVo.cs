using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TikTok
{
    public class TikTokRepairOrderVo
    {
        /// <summary>
        /// 订单id
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 归属主播账号
        /// </summary>
        public int belongLiveAnchorId { get; set; }
    }
}
