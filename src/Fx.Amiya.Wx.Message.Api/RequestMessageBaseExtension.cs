using Fx.Weixin.MP.Message.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Wx.Message.Api
{
    public static class RequestMessageBaseExtension
    {
        public static void SendTo(this RequestMessageBase requestMessageBase, IFxMessageCenter messageCenter)
        {
            messageCenter?.Add(requestMessageBase);
        }
        public static async Task SendToAsync(this RequestMessageBase requestMessageBase, IFxMessageCenter messageCenter)
        {
            await messageCenter?.AddAsync(requestMessageBase);
        }
    }
}
