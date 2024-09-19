using Fx.Amiya.BusinessWechat.Api.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlatFormOrderSend
{
    public class QuerySendOrderInfoListVo : BaseQueryVo
    {
        /// <summary>
        /// 内容平台订单id
        /// </summary>
        public string ContentPlatformId { get; set; }
    }
}
