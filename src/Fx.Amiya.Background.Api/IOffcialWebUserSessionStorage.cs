using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api
{
    public interface IOffcialWebUserSessionStorage
    {
        OffcialWebUserSession GetSession(string key);
        void SetSession(string key, OffcialWebUserSession session);
    }
}
