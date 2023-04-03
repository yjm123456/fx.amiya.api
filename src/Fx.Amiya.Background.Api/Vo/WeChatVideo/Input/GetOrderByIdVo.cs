using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WeChatVideo.Input
{
    public class GetOrderByIdVo
    {
        /// <summary>
        /// 订单id(必填)
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 归属主播id(必填)
        /// </summary>
        public int BelongLiveAnchorId { get; set; }
    }
}
