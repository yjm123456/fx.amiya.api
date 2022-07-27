using Fx.Amiya.Domain;
using Fx.Amiya.Domain.IRepository;
using Fx.Amiya.Domain.UserDomain;
using Fx.Amiya.Dto.UserInfo;
using Fx.Amiya.Dto.WxAppConfig;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common.Utils;
using Fx.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class UserService : IUserService
    {
        private IDalUserInfo dalUserInfo;
        private IWxMiniUserRepository wxMiniUserRepository;
        private IUserRepository userRepository;
        private IDalWxMpUserInfo dalWxMpUserInfo;
        private IWxMpUserRepository _wxMpUserRepository;
        private IDalConfig dalConfig;
        private IDalCustomerInfo dalCustomerInfo;
        private IDalUserInfoUpdateRecord dalUserInfoUpdateRecord;
        public UserService(IDalUserInfo dalUserInfo,
            IWxMiniUserRepository wxMiniUserRepository,
            IUserRepository userRepository,
            IDalWxMpUserInfo dalWxMpUserInfo,
            IWxMpUserRepository wxMpUserRepository,
            IDalConfig dalConfig,
            IDalCustomerInfo dalCustomerInfo,
            IDalUserInfoUpdateRecord dalUserInfoUpdateRecord)
        {
            this.dalUserInfo = dalUserInfo;
            this.wxMiniUserRepository = wxMiniUserRepository;
            this.userRepository = userRepository;
            this.dalWxMpUserInfo = dalWxMpUserInfo;
            _wxMpUserRepository = wxMpUserRepository;
            this.dalConfig = dalConfig;
            this.dalCustomerInfo = dalCustomerInfo;
            this.dalUserInfoUpdateRecord = dalUserInfoUpdateRecord;
        }
        public async Task<WxMiniUserDto> AddUnauthorizedWxMiniUserAsync(UnauthorizedWxMiniUserAddDto miniUserAddDto)
        {
            try
            {
                var fxUser = await userRepository.GetFxUserByUnionIdAsync(miniUserAddDto.UnionId);
                var wxMiniUser = await wxMiniUserRepository.GetByOpenIdAsync(miniUserAddDto.OpenId);
                if (wxMiniUser == null)
                {
                    wxMiniUser = new WxMiniUser
                    (
                         id: GuidUtil.NewGuidShortString(),
                         openid: miniUserAddDto.OpenId,
                         unionid: miniUserAddDto.UnionId,
                         appid: miniUserAddDto.AppId,
                         appPath: miniUserAddDto.AppPath,
                         scene: miniUserAddDto.Scene,
                         nickName: null,
                         gender: 0,
                         createDate: DateTime.Now,
                         country: null,
                         province: null,
                         city: null,
                         avatar: null,
                         language: null,
                         fxUser: fxUser
                    );
                    await wxMiniUserRepository.AddAsync(wxMiniUser);
                }


                return new WxMiniUserDto()
                {
                    Id = wxMiniUser.Id,
                    UserId = wxMiniUser.FxUser.Id,
                    CustomerId = wxMiniUser.FxUser.CustomerId,
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public async Task<string> GetCustomerIdAsync(string fxUserId)
        {
            FxUser fxUser = await userRepository.GetByIdAsync(fxUserId);
            return fxUser.CustomerId;
        }

        public async Task<bool> UpdateUserInfoByWxMiniUserAsync(WxMiniUserEditDto miniUserEditDto)
        {
            try
            {
                var wxMiniUser = await wxMiniUserRepository.GetByOpenIdAsync(miniUserEditDto.OpenId);
                wxMiniUser.ChangeAvatar(miniUserEditDto.AvatarUrl);
                wxMiniUser.ChangeCity(miniUserEditDto.City);
                wxMiniUser.ChangeCountry(miniUserEditDto.Country);
                wxMiniUser.ChangeGender(miniUserEditDto.Gender);
                wxMiniUser.ChangeLanguage(miniUserEditDto.Language);
                wxMiniUser.ChangeNickName(miniUserEditDto.NickName);
                wxMiniUser.ChangeProvince(miniUserEditDto.Province);

                await wxMiniUserRepository.UpdateAsync(wxMiniUser);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public async Task<bool> UpdateUserInfo(UserInfoEditDto userInfoEditDto)
        {
            try {
                var userInfo = dalUserInfo.GetAll().SingleOrDefault(e => e.Id == userInfoEditDto.Id);
                if (userInfo != null)
                {
                    userInfo.Province = userInfoEditDto.Province;
                    userInfo.City = userInfoEditDto.City;
                    userInfo.Gender = userInfoEditDto.Gender;
                    userInfo.NickName = userInfoEditDto.NickName;
                    await dalUserInfo.UpdateAsync(userInfo, true);
                    return true;
                }
                return false;
            }
            catch (Exception ex) {
                throw ex;
            }
        }



        public async Task<bool> UpdateUserWxBindPhoneAsync(string userId, string phone)
        {
            try
            {
                var user = await dalUserInfo.GetAll().SingleOrDefaultAsync(e => e.Id == userId);
                if (user != null)
                {
                    if (user.WxBindPhone == null || user.WxBindPhone != phone)
                    {
                        user.WxBindPhone = phone;
                        await dalUserInfo.UpdateAsync(user, true);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<WxMiniUserDto> AddAuthorizedWxMiniUserAsync(AuthorizedWxMiniUserAddDto miniUserAddDto)
        {
            try
            {

                var fxUser = await userRepository.GetFxUserByUnionIdAsync(miniUserAddDto.UnionId);
                var wxMiniUser = await wxMiniUserRepository.GetByOpenIdAsync(miniUserAddDto.OpenId);
                if (wxMiniUser == null)
                {
                    wxMiniUser = new WxMiniUser
                    (
                         id: GuidUtil.NewGuidShortString(),
                         openid: miniUserAddDto.OpenId,
                         unionid: miniUserAddDto.UnionId,
                         appid: miniUserAddDto.AppId,
                         appPath: miniUserAddDto.AppPath,
                         scene: miniUserAddDto.Scene,
                         nickName: miniUserAddDto.NickName,
                         gender: miniUserAddDto.Gender,
                         createDate: DateTime.Now,
                         country: miniUserAddDto.Country,
                         province: miniUserAddDto.Province,
                         city: miniUserAddDto.City,
                         avatar: miniUserAddDto.AvatarUrl,
                         language: miniUserAddDto.Language,
                         fxUser: fxUser
                    );
                    await wxMiniUserRepository.AddAsync(wxMiniUser);
                }


                return new WxMiniUserDto()
                {
                    Id = wxMiniUser.Id,
                    UserId = wxMiniUser.FxUser.Id,
                    CustomerId = wxMiniUser.FxUser.CustomerId,
                };

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
   
        private async Task<CallCenterConfigDto> GetCallCenterConfig()
        {
            var config = await dalConfig.GetAll().SingleOrDefaultAsync();
            return JsonConvert.DeserializeObject<WxAppConfigDto>(config.ConfigJson).CallCenterConfig;
        }
        public async Task<List<UserNickNameDto>> GetNickNameList(List<string> userIds)
        {
            try
            {
                List<UserNickNameDto> userNickNameDtos = new List<UserNickNameDto>();
                var config = await GetCallCenterConfig();
                foreach (var userid in userIds)
                {
                    var userInfo = await dalUserInfo.GetAll().SingleOrDefaultAsync(e => e.Id == userid);
                    if (userInfo == null)
                        continue;
                    var customer = await dalCustomerInfo.GetAll().SingleOrDefaultAsync(e => e.UserId == userid);
                    UserNickNameDto userNickNameDto = new UserNickNameDto();
                    if (customer != null)
                    {
                        userNickNameDto.EncryptPhone = ServiceClass.Encrypt(customer.Phone, config.PhoneEncryptKey);
                        userNickNameDto.Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(customer.Phone) : customer.Phone;
                    }
                    else
                    {
                        userNickNameDto.EncryptPhone = ServiceClass.Encrypt(userInfo?.WxBindPhone, config.PhoneEncryptKey);
                        userNickNameDto.Phone = config.EnablePhoneEncrypt == true ? ServiceClass.GetIncompletePhone(userInfo?.WxBindPhone) : userInfo?.WxBindPhone;

                    }

                    userNickNameDto.UserId = userInfo.Id;
                    userNickNameDto.NickName = userInfo.NickName;
                    userNickNameDto.Avatar = userInfo.Avatar;

                    userNickNameDtos.Add(userNickNameDto);

                }
                return userNickNameDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetFxUserIdByMpUserOpenIdAsync(string openid)
        {
            return (await dalWxMpUserInfo.GetAll().SingleOrDefaultAsync(t => t.OpenId == openid))?.UserId;

        }

        public async Task<WxMpUserInfoDto> WxMpUserSubscribeAsync(WxMpUserInfoDto wxMpUserDto)
        {
            var fxUser = await userRepository.GetFxUserByUnionIdAsync(wxMpUserDto.Unionid);
            WxMpUser wxMpUser = await _wxMpUserRepository.GetByOpenIdAsync(wxMpUserDto.Openid);
            if (wxMpUser == null)
            {
                wxMpUser = new WxMpUser
                    (
                        id: GuidUtil.NewGuidShortString(),
                        openid: wxMpUserDto.Openid,
                        unionid: wxMpUserDto.Unionid,
                        appid: wxMpUserDto.AppId,
                        nickName: wxMpUserDto.Nickname,
                        gender: wxMpUserDto.Sex,
                        country: wxMpUserDto.Country,
                        province: wxMpUserDto.Province,
                        city: wxMpUserDto.City,
                        avatar: wxMpUserDto.Avatar,
                        language: wxMpUserDto.Language,
                        createDate: DateTime.Now,
                        subscribeTime: wxMpUserDto.SubscribeTime,
                        subscribeScene: wxMpUserDto.SubscribeScene,
                        subscribeCount: 0,
                        isSubscribed: wxMpUserDto.Subscribe == 1,
                        groupid: wxMpUserDto.GroupId,
                        tagidList: wxMpUserDto.TagidList,
                        qrScene: wxMpUserDto.QrScene,
                        qrSceneStr: wxMpUserDto.QrSceneStr,
                        remark: wxMpUserDto.Remark,
                        fxUser: fxUser

                    );
                wxMpUser.Subscribe();
                await _wxMpUserRepository.AddAsync(wxMpUser);

            }
            else
            {
                wxMpUser.Subscribe();
                await _wxMpUserRepository.UpdateAsync(wxMpUser);

            }
            return new WxMpUserInfoDto() { Openid = wxMpUser.OpenId, SubscribeCount = wxMpUser.SubscribeCount };

        }


        public async Task WxMpUserUnsubscribeAsync(string openid)
        {
            WxMpUser wxMpUser = await _wxMpUserRepository.GetByOpenIdAsync(openid);
            if (wxMpUser != null)
            {
                wxMpUser.Unsubscribe();
                await _wxMpUserRepository.UpdateAsync(wxMpUser);
            }
        }


        /// <summary>
        /// 根据userId获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserInfoDto> GetUserInfoByUserIdAsync(string userId)
        {
            var userInfo = await dalUserInfo.GetAll().SingleOrDefaultAsync(e => e.Id == userId);
            UserInfoDto user = new UserInfoDto();
            user.Id = userInfo.Id;
            user.CreateDate = userInfo.CreateDate;
            user.NickName = userInfo.NickName;
            user.Phone = userInfo.WxBindPhone;
            user.City = userInfo.City;
            user.Avatar = userInfo.Avatar;
            user.Province = userInfo.Province;
            user.Language = userInfo.Language;
            user.Country = userInfo.Country;
            user.UnionId = userInfo.UnionId;
            user.Gender = userInfo.Gender;
            user.Sex = sexDict[userInfo.Gender];

            var userInfoUpdateRecord = await dalUserInfoUpdateRecord.GetAll().SingleOrDefaultAsync(e => e.UserId == userId);
            if (userInfoUpdateRecord == null)
            {
                user.IsAuthorizationUserInfo = true;
            }
            else
            {
                if ((DateTime.Now - userInfoUpdateRecord.LatestUpdateDate).Days > 100)
                {
                    user.IsAuthorizationUserInfo = true;
                }
                else
                {
                    user.IsAuthorizationUserInfo = false;
                }
            }

            return user;
        }

        

        Dictionary<byte, string> sexDict = new Dictionary<byte, string>()
        {
            { 0,"未知"},
            { 1,"男"},
            { 2,"女"}
        };
    }
}
