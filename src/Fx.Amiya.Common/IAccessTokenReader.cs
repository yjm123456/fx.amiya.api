using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Common
{
    public interface IAccessTokenReader
    {
        Task<string> GetAccessTokenAsync(string appId);
    }
}
