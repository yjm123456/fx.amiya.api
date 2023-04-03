using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TikTokUserInfo
{
    public class TikTokCiperUserInfoDto
    {
        /// <summary>
        /// 抖店用户id
        /// </summary>
        public string TiktokUserId { get; set; }
        /// <summary>
        /// 抖店订单id
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 归属主播
        /// </summary>
        public int BelongLiveAnchorId { get; set; }
    }
}
