using Fx.Weixin.MP.Message.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Wx.Message.Api
{
    public class FxWxMessageWrapper
    {
        public string UserId { get; set; }
        public RequestMessageBase WxRequestMessage { get; set; }

        /// <summary>
        /// 0=公众号  1=小程序  2=APP
        /// </summary>
        public byte AppType { get; set; }
    }
}
