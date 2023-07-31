using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WeChatVideo.Input
{
    public class AutoCompleteDataParam
    {
        /// <summary>
        /// 带货时间
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// 主播id
        /// </summary>
        public int liveAnchorId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 带货类型
        /// </summary>
        public int TakeGoodsType { get; set; }
    }
}
