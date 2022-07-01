using Fx.Amiya.Domain.UserDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Domain.IRepository
{
    public interface IWxMpUserRepository : IAsyncRepository<WxMpUser, string>
    {
        Task<WxMpUser> GetByOpenIdAsync(string openId);
    }
}
