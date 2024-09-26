﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlatFormOrderSend
{
    public class QuerySendOrderInfoListVo:BaseQueryVo
    {
        /// <summary>
        /// 内容平台订单id
        /// </summary>
        public string ContentPlatformId { get; set; }
        /// <summary>
        /// 是否为主派医院
        /// </summary>
        public bool? IsMainHospital { get; set; }
    }
}
