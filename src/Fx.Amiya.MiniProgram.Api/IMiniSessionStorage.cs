using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api
{
    public interface IMiniSessionStorage
    {
        FxWxMiniUserSession GetSession(string key);
        void SetSession(string key, FxWxMiniUserSession session);
    }
}
