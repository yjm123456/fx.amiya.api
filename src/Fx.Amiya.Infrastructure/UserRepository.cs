using Fx.Amiya.Domain;
using Fx.Amiya.Domain.IRepository;
using Fx.Amiya.Domain.UserDomain;
using Fx.Amiya.IDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Infrastructure
{
   public class UserRepository: IUserRepository
    {
        private IDalUserInfo dalUserInfo;
        private IDalWxMiniUserInfo dalWxMiniUserInfo;
        public UserRepository(IDalUserInfo dalUserInfo, IDalWxMiniUserInfo dalWxMiniUserInfo)
        {
            this.dalUserInfo = dalUserInfo;
            this.dalWxMiniUserInfo = dalWxMiniUserInfo;
        }

        public Task<FxUser> AddAsync(FxUser entity)
        {
            return null;
        }

        public Task DeleteAsync(FxUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExsitOpenIdAsync(string openid, byte userType)
        {
            if ((byte)FxUserType.Mini == userType)
            {
                var user = await dalWxMiniUserInfo.GetAll().SingleOrDefaultAsync(t => t.OpenId == openid);
                return user != null;
            }
            else if ((byte)FxUserType.Mp == userType)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public async Task<FxUser> GetByIdAsync(string id)
        {
            var user = await dalUserInfo.GetAll().Include(t => t.CustomerInfo).SingleOrDefaultAsync(t => t.Id == id);
            FxUser fxUser = new FxUser
                (
                   user.Id,
                   user.CreateDate,
                   (FxUserType)user.CreateFromType,
                   user.CustomerInfo?.Id,
                   user.Frozen,
                   user.Valid
                );
            return fxUser;
        }

        public async Task<FxUser> GetFxUserByUnionIdAsync(string unionId)
        {
            var userInfo = await dalUserInfo.GetAll().Include(t => t.CustomerInfo).SingleOrDefaultAsync(t => t.UnionId == unionId);
            if (userInfo == null)
                return null;
            FxUser fxUser = new FxUser(
                    id: userInfo.Id,
                    createDate: userInfo.CreateDate,
                    createFromType: (FxUserType)userInfo.CreateFromType,
                    customerId: userInfo.CustomerInfo?.Id,
                    frozen: userInfo.Frozen,
                    valid: userInfo.Valid
                );

            return fxUser;
        }

        public Task UpdateAsync(FxUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
