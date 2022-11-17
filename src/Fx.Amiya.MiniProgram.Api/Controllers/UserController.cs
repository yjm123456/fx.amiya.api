using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Common;
using Fx.Amiya.Dto.UserInfo;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.Login;
using Fx.Amiya.MiniProgram.Api.Vo.UserInfo;
using Fx.Open.Infrastructure.Web;
using Fx.Weixin.MP.AdvanceApi.MiniApi;
using Fx.Weixin.MP.Dto.Mini;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Fx.Amiya.MiniProgram.Api.Controllers
{
    [Route("amiya/wxmini/[controller]")]
    [ApiController]
    [FxAmiyaApiUserTypeAuthorization]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private IMiniSessionStorage sessionStorage;
        private readonly static int SessionLiveDays = 3;
        private TokenReader tokenReader;
        private IConfiguration configuration;
        private FxAppGlobal _fxAppGlobal;
        private ILogger<UserController> logger;
        public UserController(IUserService userService,
            IMiniSessionStorage sessionStorage,
            TokenReader tokenReader,
            IConfiguration configuration,
            FxAppGlobal fxAppGlobal,
            ILogger<UserController> logger)
        {
            this.userService = userService;
            this.sessionStorage = sessionStorage;
            this.tokenReader = tokenReader;
            this.configuration = configuration;
            _fxAppGlobal = fxAppGlobal;
            this.logger = logger;
        }

        [HttpGet("appIds")]
        [AllowAnonymous]
        public async Task<ResultData<List<string>>> GetAppListAsync()
        {
            List<string> appIds = new List<string>();
            foreach (var item in _fxAppGlobal.WxAppInfoList)
            {
                appIds.Add(item.WxAppId);
            }
            return ResultData<List<string>>.Success().AddData("appIds", appIds);
        }


        [HttpGet("appByAppId/{appId}")]
        [AllowAnonymous]
        public async Task<ResultData<string>> GetAppListAsync(string appId)
        {
            var appInfo = _fxAppGlobal.WxAppInfoList.SingleOrDefault(t => t.WxAppId == appId);
            return ResultData<string>.Success().AddData("appIds", appInfo?.WxAppId);
        }





        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginVo"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ResultData<string>> Login([FromBody] LoginVo loginVo)
        {
            try
            {
                var appInfo = _fxAppGlobal.WxAppInfoList.SingleOrDefault(t => t.WxAppId == loginVo.AppId);
                if (appInfo == null)
                    return ResultData<string>.Fail("无效APPID！");

                var sessionInfo = await WxMiniBaseApi.GetCode2SessionAsync(loginVo.Code, appInfo.WxAppId, appInfo.WxAppSecret);

                if (sessionInfo.ErrCode == 0)
                {
                    //if (string.IsNullOrEmpty(sessionInfo.UnionId))
                    //{
                    //    return ResultData<string>.Fail(-2, "unionid获取不到！");
                    //}

                    //添加用户，如果已经存在，则不会添加
                    var wxMiniUserInfo = await userService.AddUnauthorizedWxMiniUserAsync(new UnauthorizedWxMiniUserAddDto()
                    {
                        AppId = appInfo.WxAppId,
                        AppPath = loginVo.AppPath,
                        OpenId = sessionInfo.OpenId,
                        Scene = loginVo.Scene,
                        UnionId = sessionInfo.UnionId
                    });
                    string token = Guid.NewGuid().ToString().Replace("-", "");

                    sessionStorage.SetSession(token, new FxWxMiniUserSession()
                    {
                        FxUserId = wxMiniUserInfo.UserId,
                        OpenId = sessionInfo.OpenId,
                        SessionKey = sessionInfo.SessionKey,
                        UnionId = sessionInfo.UnionId,
                        FxCustomerId = wxMiniUserInfo.CustomerId,
                        AppId = loginVo.AppId,
                        ExpireTime = DateTime.Now.AddDays(SessionLiveDays)
                    });

                    return ResultData<string>.Success().AddData("token", token);
                }
                else
                {
                    return ResultData<string>.Fail(sessionInfo.ErrMsg);
                }
            }
            catch (Exception ex)
            {

                return ResultData<string>.Fail(ex.Message);
            }
        }


        ///// <summary>
        ///// 登录
        ///// </summary>
        ///// <param name="loginVo"></param>
        ///// <returns></returns>
        //[HttpPost("loginwithuserinfo")]
        //[AllowAnonymous]
        //public async Task<ResultData<string>> LoginWithDecryptUserInfo([FromBody]LoginWithUserInfoVo loginVo)
        //{
        //    try
        //    {
        //        //string appId = configuration.GetValue<string>("FxOpen:WxMini:AppId");
        //        //string appSecret = configuration.GetValue<string>("FxOpen:WxMini:AppSecret");
        //        var appInfo = _fxAppGlobal.WxAppInfoList.SingleOrDefault(t => t.WxAppId == loginVo.AppId);
        //        if (appInfo == null)
        //            return ResultData<string>.Fail("无效APPID！");

        //        var sessionInfo = await WxMiniBaseApi.GetCode2SessionAsync(loginVo.Code, appInfo.WxAppId, appInfo.WxAppSecret);

        //        if (sessionInfo.ErrCode == 0)
        //        {

        //            var decodeUserInfoString = WxMiniBaseApi.DecodeUserInfo(loginVo.EncryptedData, loginVo.Iv, sessionInfo.SessionKey);
        //            var authMiniUserObj = JsonConvert.DeserializeObject<dynamic>(decodeUserInfoString);

        //            AuthorizedWxMiniUserAddDto authMiniUserAddDto = new AuthorizedWxMiniUserAddDto()
        //            {
        //                AppId = appInfo.WxAppId,
        //                AppPath = loginVo.AppPath,
        //                Scene = loginVo.Scene,
        //                AvatarUrl = authMiniUserObj.avatarUrl,
        //                City = authMiniUserObj.city,
        //                Country = authMiniUserObj.country,
        //                Gender = (byte)authMiniUserObj.gender,
        //                Language = authMiniUserObj.language,
        //                NickName = authMiniUserObj.nickName,
        //                OpenId = authMiniUserObj.openId,
        //                Province = authMiniUserObj.province,
        //                UnionId = authMiniUserObj.unionId
        //            };

        //            //添加用户，如果已经存在，则不会添加
        //            var wxMiniUserInfo = await userService.AddAuthorizedWxMiniUserAsync(authMiniUserAddDto);


        //            string token = Guid.NewGuid().ToString().Replace("-", "");
        //            sessionStorage.SetSession(token, new FxWxMiniUserSession()
        //            {
        //                FxUserId = wxMiniUserInfo.UserId,
        //                OpenId = sessionInfo.OpenId,
        //                SessionKey = sessionInfo.SessionKey,
        //                UnionId = authMiniUserAddDto.UnionId,
        //                FxCustomerId = wxMiniUserInfo.CustomerId,
        //                ExpireTime = DateTime.Now.AddDays(SessionLiveDays),
        //                AppId = loginVo.AppId
        //            });
        //            return ResultData<string>.Success().AddData("token", token);
        //        }
        //        else
        //        {
        //            return ResultData<string>.Fail(sessionInfo.ErrMsg);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ResultData<string>.Fail(ex.Message);
        //    }
        //}


        /// <summary>
        /// 通过小程序用户信息来更新方旋用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPut("updateUserInfo")]

        public async Task<ResultData> UpdateUserInfo([FromBody] UserInfoEditVo userInfo)
        {

            var sessionInfo = sessionStorage.GetSession(tokenReader.GetToken());
            if (sessionInfo != null)
            {
                await userService.UpdateUserInfoByWxMiniUserAsync(new WxMiniUserEditDto()
                {
                    AvatarUrl = userInfo.AvatarUrl,
                    City = userInfo.City,
                    Country = userInfo.Country,
                    Gender = userInfo.Gender,
                    Language = userInfo.Language,
                    NickName = userInfo.NickName,
                    Province = userInfo.Province,
                    OpenId = sessionInfo.OpenId,
                    UnionId = sessionInfo.UnionId
                });
                return ResultData.Success();
            }
            else
            {
                return ResultData.Fail();
            }
        }

        [HttpPut("userEditInfo")]
        public async Task<ResultData> UseEditInfo(UserEditInfoVo editInfoVo) {
            var sessionInfo = sessionStorage.GetSession(tokenReader.GetToken());
            if (sessionInfo != null) {
                await userService.UpdateUserInfo(
                    new UserInfoEditDto {
                        Id = sessionInfo.FxUserId,
                        Gender = editInfoVo.Gender,
                        City = editInfoVo.City,
                        Province = editInfoVo.Province,
                        NickName = editInfoVo.NickName
                    }
                    );
                return ResultData.Success();
            } else {
                return ResultData.Fail();
            }
        }


        /// <summary>
        /// 访问
        /// </summary>
        /// <param name="visitVo"></param>
        /// <returns></returns>
        [HttpPost("visit")]
        public async Task<ResultData> Visit([FromBody] VisitVo visitVo)
        {
            var sessionInfo = sessionStorage.GetSession(tokenReader.GetToken());
            var appid = sessionInfo.AppId;

            return ResultData.Success();
        }


        /// <summary>
        /// 判断用户是否是客户
        /// </summary>
        /// <returns></returns>
        [HttpGet("iscustomer")]
        public async Task<ResultData<bool>> FxUserIsCustomer()
        {
            try
            {
                var sessionInfo = sessionStorage.GetSession(tokenReader.GetToken());
                if (sessionInfo.FxCustomerId == null)
                {
                    var customerId = await userService.GetCustomerIdAsync(sessionInfo.FxUserId);
                    sessionInfo.FxCustomerId = customerId;
                }
                return ResultData<bool>.Success().AddData("isCustomer", sessionInfo.FxCustomerId != null);


            }
            catch (Exception ex)
            {
                return ResultData<bool>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 解密手机号
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet("decryptPhoneNumber")]
        public async Task<ResultData<string>> DecryptWxPhoneNumber([FromQuery] DecryptWxPhoneNumberVo param)
        {
            try
            {
                var sessionInfo = sessionStorage.GetSession(tokenReader.GetToken());

                DecryptWxPhoneNumberDto decryptWxPhoneNumberDto = new DecryptWxPhoneNumberDto();
                decryptWxPhoneNumberDto.EncryptedData = param.EncryptedData;
                decryptWxPhoneNumberDto.Iv = param.Iv;
                decryptWxPhoneNumberDto.SessionKey = sessionInfo.SessionKey;


                var phoneNumber = WxMiniBaseApi.DecryptWxPhoneNumber(decryptWxPhoneNumberDto);

                await userService.UpdateUserWxBindPhoneAsync(sessionInfo.FxUserId, phoneNumber);

                return ResultData<string>.Success().AddData("phoneNumber", phoneNumber);
            }
            catch (Exception ex)
            {
                return ResultData<string>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("info")]
        public async Task<ResultData<UserInfoVo>> GetUserInfoAsync()
        {
            string token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);

            var userInfo = await userService.GetUserInfoByUserIdAsync(sessionInfo.FxUserId);
            UserInfoVo user = new UserInfoVo();
            user.Id = userInfo.Id;
            user.CreateDate = userInfo.CreateDate;
            user.NickName = userInfo.NickName;
            user.Phone = userInfo.Phone;
            user.City = userInfo.City;
            user.AvatarUrl = userInfo.Avatar;
            user.Province = userInfo.Province;
            user.Language = userInfo.Language;
            user.Country = userInfo.Country;
            user.Gender = userInfo.Gender;
            user.Sex = userInfo.Sex;
            user.IsAuthorizationUserInfo = userInfo.IsAuthorizationUserInfo;
            return ResultData<UserInfoVo>.Success().AddData("userInfo", user);
        }
        [HttpGet("getBusinessCardCode")]
        public async Task<ResultData<string>> GetBusinessCardCode() {
            string token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            var userInfo = await userService.GetUserInfoByUserIdAsync(sessionInfo.FxUserId);
            var userId = userInfo.Id;
            var baseString = await userService.GetUserQrCode(userId);
            return ResultData<string>.Success().AddData("qrCode", baseString);
        }

    }
}