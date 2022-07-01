using Fx.Weixin.MP.Message.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Wx.Message.Api
{
    public interface IFxMessageCenter
    {
        Task AddAsync(RequestMessageBase requestMessageBase);
        void Add(RequestMessageBase requestMessageBase);
    }
}
