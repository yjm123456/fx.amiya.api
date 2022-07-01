using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api
{
    /// <summary>
    /// 微信小程序的自定义登录状态
    /// 保存在服务端
    /// </summary>
    public class FxWxMiniUserSession
    {
        public string OpenId { get; set; }
        public string SessionKey { get; set; }
        public string UnionId { get; set; }
        public string FxUserId { get; set; }
        public string FxCustomerId { get; set; }

        public DateTime ExpireTime { get; set; }

        public string AppId { get; set; }
    }
}
