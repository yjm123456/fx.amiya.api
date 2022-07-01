
using Fx.Amiya.Domain.UserDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Domain.IRepository
{
    public interface IUserRepository: IAsyncRepository<FxUser, string>
    {
        Task<bool> ExsitOpenIdAsync(string openid, byte userType);

      
        Task<FxUser> GetFxUserByUnionIdAsync(string unionId);
    }
}
