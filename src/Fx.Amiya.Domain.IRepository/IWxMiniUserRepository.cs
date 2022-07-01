using Fx.Amiya.Domain.UserDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Domain.IRepository
{
   public interface IWxMiniUserRepository: IAsyncRepository<WxMiniUser, string>
    {
        Task<WxMiniUser> GetByOpenIdAsync(string openId);

        Task<WxMiniUser> GetByUserIdAsync(string userId);
    }
}
