using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TaobaoAppInfo
{
    public class TaobaoAppSimpleInfoVo
    {
        public string AppKey { get; set; }

        /// <summary>
        /// 回调url，需加上baseUrl
        /// </summary>
        public string PortionRedirectUri { get; set; }
    }
}
