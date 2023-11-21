using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlatFormOrderSend
{
    public class QuerySendOrderInfoListDto:BaseQueryDto
    {
        /// <summary>
        /// 内容平台订单id
        /// </summary>
        public string ContentPlatformId { get; set; }
    }
}
