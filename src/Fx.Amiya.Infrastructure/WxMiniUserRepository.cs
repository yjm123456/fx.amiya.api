using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Domain;
using Fx.Amiya.Domain.IRepository;
using Fx.Amiya.Domain.UserDomain;
using Fx.Amiya.IDal;
using Fx.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Infrastructure
{
    public class WxMiniUserRepository : IWxMiniUserRepository
    {
        private IDalUserInfo dalUserInfo;
        private IDalWxMiniUserInfo dalWxMiniUserInfo;
        private IUnitOfWork unitOfWork;
        private IDalUserInfoUpdateRecord dalUserInfoUpdateRecord;
        public WxMiniUserRepository(IDalUserInfo dalUserInfo, 
            IDalWxMiniUserInfo dalWxMiniUserInfo,
            IUnitOfWork unitOfWork,
            IDalUserInfoUpdateRecord dalUserInfoUpdateRecord)
        {
            this.dalUserInfo = dalUserInfo;
            this.dalWxMiniUserInfo = dalWxMiniUserInfo;
            this.unitOfWork = unitOfWork;
            this.dalUserInfoUpdateRecord = dalUserInfoUpdateRecord;
        }
        public async Task<WxMiniUser> AddAsync(WxMiniUser entity)
        {

            var userInfo = await dalUserInfo.GetAll().SingleOrDefaultAsync(t => t.UnionId == entity.UnionId);
            if (userInfo == null)
            {
                var userInfoModel = new UserInfo()
                {
                    Avatar = entity.Avatar,
                    City = entity.City,
                    Country = entity.Country,
                    CreateDate = entity.FxUser.CreateDate,
                    CreateFromType = (byte)entity.FxUser.CreateFromType,
                    Frozen = entity.FxUser.Frozen,
                    Gender = entity.Gender,
                    Id = entity.FxUser.Id,
                    Language = entity.Language,
                    NickName = entity.NickName,
                    Province = entity.Province,
                    UnionId = entity.UnionId,
                    Valid = entity.FxUser.Valid
                };
                await dalUserInfo.AddAsync(userInfoModel, false);
            }
            var wxMiniUser = await dalWxMiniUserInfo.GetAll().SingleOrDefaultAsync(t => t.OpenId == entity.OpenId);

            if (wxMiniUser == null)
            {
                WxMiniUserInfo wxMiniUserInfo = new WxMiniUserInfo()
                {
                    AppId = entity.AppId,
                    AppPath = entity.AppPath,
                    Id = entity.Id,
                    OpenId = entity.OpenId,
                    Scene = entity.Scene,
                    UserId = entity.FxUser.Id,
                    CreateDate = entity.CreateDate
                };
                await dalWxMiniUserInfo.AddAsync(wxMiniUserInfo, false);


            }

            await unitOfWork.SaveChangesAsync();
            return entity;
        }

        public Task DeleteAsync(WxMiniUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<WxMiniUser> GetByIdAsync(string id)
        {
            var entity = await dalWxMiniUserInfo.GetAll()
                .Include(t => t.UserInfo).ThenInclude(t => t.CustomerInfo)
                .SingleOrDefaultAsync(t => t.Id == id);

            if (entity != null)
            {
                WxMiniUser miniUser = new WxMiniUser
                    (
                        id: entity.Id,
                        openid: entity.OpenId,
                        unionid: entity.UserInfo.UnionId,
                        appid: entity.AppId,
                        appPath: entity.AppPath,
                        scene: entity.Scene,
                        nickName: entity.UserInfo.NickName,
                        gender: entity.UserInfo.Gender,
                        createDate: entity.CreateDate,
                        country: entity.UserInfo.Country,
                        province: entity.UserInfo.Province,
                        city: entity.UserInfo.City,
                        avatar: entity.UserInfo.Avatar,
                        language: entity.UserInfo.Language,
                        fxUser: new FxUser(
                                id: entity.UserInfo.Id,
                                createDate: entity.UserInfo.CreateDate,
                                createFromType: (FxUserType)entity.UserInfo.CreateFromType,
                                 customerId: entity.UserInfo.CustomerInfo?.Id,
                                frozen: entity.UserInfo.Frozen,
                                valid: entity.UserInfo.Valid)
                    );
                return miniUser;
            }
            else
            {
                return null;
            }
        }

        public async Task<WxMiniUser> GetByOpenIdAsync(string openId)
        {
            var entity = await dalWxMiniUserInfo.GetAll()
                .Include(t => t.UserInfo).ThenInclude(t => t.CustomerInfo)
                .SingleOrDefaultAsync(t => t.OpenId == openId);

            if (entity != null)
            {
                WxMiniUser miniUser = new WxMiniUser
                    (
                        id: entity.Id,
                        openid: entity.OpenId,
                        unionid: entity.UserInfo.UnionId,
                        appid: entity.AppId,
                        appPath: entity.AppPath,
                        scene: entity.Scene,
                        nickName: entity.UserInfo.NickName,
                        gender: entity.UserInfo.Gender,
                        createDate: entity.CreateDate,
                        country: entity.UserInfo.Country,
                        province: entity.UserInfo.Province,
                        city: entity.UserInfo.City,
                        avatar: entity.UserInfo.Avatar,
                        language: entity.UserInfo.Language,
                        fxUser: new FxUser(
                                id: entity.UserInfo.Id,
                                createDate: entity.UserInfo.CreateDate,
                                createFromType: (FxUserType)entity.UserInfo.CreateFromType,
                                customerId: entity.UserInfo.CustomerInfo?.Id,
                                frozen: entity.UserInfo.Frozen,
                                valid: entity.UserInfo.Valid)
                    );
                return miniUser;
            }
            else
            {
                return null;
            }

        }

        public async Task<WxMiniUser> GetByUserIdAsync(string userId)
        {
            var entity = await dalWxMiniUserInfo.GetAll()
                .Include(t => t.UserInfo).ThenInclude(t => t.CustomerInfo)
                .SingleOrDefaultAsync(t => t.UserId == userId);

            if (entity != null)
            {
                WxMiniUser miniUser = new WxMiniUser
                    (
                        id: entity.Id,
                        openid: entity.OpenId,
                        unionid: entity.UserInfo.UnionId,
                        appid: entity.AppId,
                        appPath: entity.AppPath,
                        scene: entity.Scene,
                        nickName: entity.UserInfo.NickName,
                        gender: entity.UserInfo.Gender,
                        createDate: entity.CreateDate,
                        country: entity.UserInfo.Country,
                        province: entity.UserInfo.Province,
                        city: entity.UserInfo.City,
                        avatar: entity.UserInfo.Avatar,
                        language: entity.UserInfo.Language,
                        fxUser: new FxUser(
                                id: entity.UserInfo.Id,
                                createDate: entity.UserInfo.CreateDate,
                                createFromType: (FxUserType)entity.UserInfo.CreateFromType,
                                customerId: entity.UserInfo.CustomerInfo?.Id,
                                frozen: entity.UserInfo.Frozen,
                                valid: entity.UserInfo.Valid)
                    );
                return miniUser;
            }
            else
            {
                return null;
            }

        }

        public async Task UpdateAsync(WxMiniUser entity)
        {
            try
            {
                var userInfo = await dalUserInfo.GetAll().SingleOrDefaultAsync(t => t.Id == entity.FxUser.Id);
                userInfo.Avatar = entity.Avatar;
                userInfo.City = entity.City;
                userInfo.Country = entity.Country;
                userInfo.Frozen = entity.FxUser.Frozen;
                userInfo.Gender = entity.Gender;
                userInfo.NickName = entity.NickName;
                userInfo.Language = entity.Language;
                userInfo.Province = entity.Province;
                userInfo.Valid = entity.FxUser.Valid;
                //var updatedUserInfo = new UserInfo()
                //{
                //    Avatar = entity.Avatar,
                //    City = entity.City,
                //    Country = entity.Country,
                //    CreateDate = entity.CreateDate,
                //    CreateFromType = (byte)entity.FxUser.CreateFromType,
                //    Frozen = entity.FxUser.Frozen,
                //    Gender = entity.Gender,
                //    Id = entity.FxUser.Id,
                //    Language = entity.Language,
                //    NickName = entity.NickName,
                //    Province = entity.Province,
                //    UnionId = entity.UnionId,
                //    Valid = entity.FxUser.Valid

                //};
                var userUpdateRecord = await dalUserInfoUpdateRecord.GetAll().SingleOrDefaultAsync(e => e.UserId == userInfo.Id);
                if (userUpdateRecord == null)
                {
                    UserInfoUpdateRecord userInfoUpdateRecord = new UserInfoUpdateRecord();
                    userInfoUpdateRecord.UserId = userInfo.Id;
                    userInfoUpdateRecord.LatestUpdateDate = DateTime.Now;
                    await dalUserInfoUpdateRecord.AddAsync(userInfoUpdateRecord, true);
                }
                else
                {
                    userUpdateRecord.LatestUpdateDate = DateTime.Now;
                    await dalUserInfoUpdateRecord.UpdateAsync(userUpdateRecord, true);
                }

                await dalUserInfo.UpdateAsync(userInfo, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
