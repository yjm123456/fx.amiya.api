using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Domain;
using Fx.Amiya.Domain.IRepository;
using Fx.Amiya.Domain.UserDomain;
using Fx.Amiya.IDal;
using Fx.Infrastructure.DataAccess;
using Fx.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fx.Common.Extensions;
namespace Fx.Amiya.Infrastructure
{
   public class WxMpUserRepository: IWxMpUserRepository
    {
        private IDalUserInfo _dalUserInfo;
        private IDalWxMpUserInfo _dalWxMpUserInfo;
        private IUnitOfWork _unitOfWork;
        private IDalMpUserSubscribeDetail _dalMpUserSubscribeDetail;

        public WxMpUserRepository(IDalUserInfo dalUserInfo,
            IDalWxMpUserInfo dalWxMpUserInfo,
            IUnitOfWork unitOfWork,
            IDalMpUserSubscribeDetail dalMpUserSubscribeDetail)
        {
            _dalUserInfo = dalUserInfo;
            _dalWxMpUserInfo = dalWxMpUserInfo;
            _unitOfWork = unitOfWork;
            _dalMpUserSubscribeDetail = dalMpUserSubscribeDetail;
        }


        public async Task<WxMpUser> AddAsync(WxMpUser entity)
        {
            var userInfo = await _dalUserInfo.GetAll().SingleOrDefaultAsync(t => t.UnionId == entity.UnionId);
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
                await _dalUserInfo.AddAsync(userInfoModel, false);
            }

            var wxMpUser = await _dalWxMpUserInfo.GetAll().SingleOrDefaultAsync(t => t.OpenId == entity.OpenId);
            if (wxMpUser == null)
            {
                WxMpUserInfo wxMpUserInfo = new WxMpUserInfo()
                {
                    AppId = entity.AppId,
                    CreateDate = entity.CreateDate,
                    GroupId = entity.GroupId,
                    Id = entity.Id,
                    IsSubscribed = entity.IsSubscribed,
                    OpenId = entity.OpenId,
                    QrScene = entity.QrScene,
                    QrSceneStr = entity.QrSceneStr,
                    Remark = entity.Remark,
                    SubscribeCount = entity.SubscribeCount,
                    SubscribeDateTime = DateTimeExtension.TimeStampToDateTime(entity.SubscribeTime),
                    SubscribeScene = entity.SubscribeScene,
                    SubscribeTime = entity.SubscribeTime,
                    TagIdList = JsonConvert.SerializeObject(entity.TagidList),
                    UserId = entity.FxUser.Id,

                };
                await _dalWxMpUserInfo.AddAsync(wxMpUserInfo, false);
            }

            if (entity.SubscribeDetail != null)
            {
                MpUserSubscribeDetail subscribeDetail = new MpUserSubscribeDetail()
                {
                    AppId = entity.SubscribeDetail.AppId,
                    MpUserId = entity.SubscribeDetail.MpUserId,
                    Date = entity.SubscribeDetail.Date,
                    Subscribe = entity.SubscribeDetail.Subscribe,

                };
                await _dalMpUserSubscribeDetail.AddAsync(subscribeDetail, false);
            }

            await _unitOfWork.SaveChangesAsync();
            return entity;

        }

        public Task DeleteAsync(WxMpUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<WxMpUser> GetByIdAsync(string id)
        {
            var entity = await _dalWxMpUserInfo.GetAll()
                .Include(t => t.UserInfo)
                .SingleOrDefaultAsync(t => t.Id == id);
            if (entity != null)
            {
                WxMpUser wxMpUser = new WxMpUser
                    (
                        id: entity.Id,
                        openid: entity.OpenId,
                        unionid: entity.UserInfo.UnionId,
                        appid: entity.AppId,
                        nickName: entity.UserInfo.NickName,
                        gender: entity.UserInfo.Gender,
                        country: entity.UserInfo.Country,
                        province: entity.UserInfo.Province,
                        city: entity.UserInfo.City,
                        avatar: entity.UserInfo.Avatar,
                        language: entity.UserInfo.Language,
                        createDate: entity.CreateDate,
                        subscribeTime: entity.SubscribeTime,
                        subscribeScene: entity.SubscribeScene,
                        subscribeCount: entity.SubscribeCount,
                        isSubscribed: entity.IsSubscribed,
                        groupid: entity.GroupId,
                        tagidList: JsonConvert.DeserializeObject<int[]>(entity.TagIdList),
                        qrScene: entity.QrScene,
                        qrSceneStr: entity.QrSceneStr,
                        remark: entity.Remark,
                        fxUser: new FxUser(
                            id: entity.UserInfo.Id,
                                createDate: entity.UserInfo.CreateDate,
                                createFromType: (FxUserType)entity.UserInfo.CreateFromType,
                                frozen: entity.UserInfo.Frozen,
                                valid: entity.UserInfo.Valid
                            )
                    );
                return wxMpUser;
            }
            else
            {
                return null;
            }
        }

        public async Task<WxMpUser> GetByOpenIdAsync(string openId)
        {
            var entity = await _dalWxMpUserInfo.GetAll()
                .Include(t => t.UserInfo)
                .SingleOrDefaultAsync(t => t.OpenId == openId);
            if (entity != null)
            {
                WxMpUser wxMpUser = new WxMpUser
                    (
                        id: entity.Id,
                        openid: entity.OpenId,
                        unionid: entity.UserInfo.UnionId,
                        appid: entity.AppId,
                        nickName: entity.UserInfo.NickName,
                        gender: entity.UserInfo.Gender,
                        country: entity.UserInfo.Country,
                        province: entity.UserInfo.Province,
                        city: entity.UserInfo.City,
                        avatar: entity.UserInfo.Avatar,
                        language: entity.UserInfo.Language,
                        createDate: entity.CreateDate,
                        subscribeTime: entity.SubscribeTime,
                        subscribeScene: entity.SubscribeScene,
                        subscribeCount: entity.SubscribeCount,
                        isSubscribed: entity.IsSubscribed,
                        groupid: entity.GroupId,
                        tagidList: JsonConvert.DeserializeObject<int[]>(entity.TagIdList),
                        qrScene: entity.QrScene,
                        qrSceneStr: entity.QrSceneStr,
                        remark: entity.Remark,
                        fxUser: new FxUser(
                            id: entity.UserInfo.Id,
                                createDate: entity.UserInfo.CreateDate,
                                createFromType: (FxUserType)entity.UserInfo.CreateFromType,
                                frozen: entity.UserInfo.Frozen,
                                valid: entity.UserInfo.Valid
                            )
                    );
                return wxMpUser;
            }
            else
            {
                return null;
            }
        }

        public async Task UpdateAsync(WxMpUser entity)
        {
            if (entity.SubscribeDetail != null)
            {
                MpUserSubscribeDetail subscribeDetail = new MpUserSubscribeDetail()
                {
                    AppId = entity.SubscribeDetail.AppId,
                    MpUserId = entity.SubscribeDetail.MpUserId,
                    Date = entity.SubscribeDetail.Date,
                    Subscribe = entity.SubscribeDetail.Subscribe,

                };
                await _dalMpUserSubscribeDetail.AddAsync(subscribeDetail, false);
            }

            var userInfo = await _dalUserInfo.GetAll().SingleOrDefaultAsync(t => t.Id == entity.FxUser.Id);
            userInfo.Avatar = entity.Avatar;
            userInfo.City = entity.City;
            userInfo.Country = entity.Country;
            userInfo.Frozen = entity.FxUser.Frozen;
            userInfo.Gender = entity.Gender;
            userInfo.NickName = entity.NickName;
            userInfo.Language = entity.Language;
            userInfo.Province = entity.Province;
            userInfo.Valid = entity.FxUser.Valid;
            await _dalUserInfo.UpdateAsync(userInfo, false);

            var mpUser = await _dalWxMpUserInfo.GetAll().SingleOrDefaultAsync(t => t.OpenId == entity.OpenId);
            mpUser.IsSubscribed = entity.IsSubscribed;
            mpUser.SubscribeCount = entity.SubscribeCount;
            mpUser.SubscribeTime = entity.SubscribeTime;
            mpUser.SubscribeDateTime = DateTimeExtension.TimeStampToDateTime(entity.SubscribeTime);
            mpUser.Remark = entity.Remark;
            mpUser.GroupId = entity.GroupId;
            mpUser.TagIdList = JsonConvert.SerializeObject(entity.TagidList);
            mpUser.SubscribeScene = entity.SubscribeScene;
            mpUser.QrScene = entity.QrScene;
            mpUser.QrSceneStr = entity.QrSceneStr;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
