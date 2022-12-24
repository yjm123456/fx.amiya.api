using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Common;
using Fx.Amiya.Core.Dto.Integration;
using Fx.Amiya.Core.Interfaces.Integration;
using Fx.Amiya.Dto.CustomerBaseInfo;
using Fx.Amiya.Dto.UserInfo;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.MiniProgram.Api.Vo.Login;
using Fx.Amiya.MiniProgram.Api.Vo.UserInfo;
using Fx.Amiya.Modules.Integration.Domin;
using Fx.Common;
using Fx.Infrastructure.DataAccess;
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
        private IIntegrationAccount integrationAccount;
        private ICustomerBaseInfoService customerBaseInfoService;
        private IDalCustomerInfo dalCustomerInfo;
        private IUnitOfWork unitOfWork;
        public UserController(IUserService userService,
            IMiniSessionStorage sessionStorage,
            TokenReader tokenReader,
            IConfiguration configuration,
            FxAppGlobal fxAppGlobal,
            ILogger<UserController> logger, IIntegrationAccount integrationAccount, ICustomerBaseInfoService customerBaseInfoService, IDalCustomerInfo dalCustomerInfo, IUnitOfWork unitOfWork)
        {
            this.userService = userService;
            this.sessionStorage = sessionStorage;
            this.tokenReader = tokenReader;
            this.configuration = configuration;
            _fxAppGlobal = fxAppGlobal;
            this.logger = logger;
            this.integrationAccount = integrationAccount;
            this.customerBaseInfoService = customerBaseInfoService;
            this.dalCustomerInfo = dalCustomerInfo;
            this.unitOfWork = unitOfWork;
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
        public async Task<ResultData> UseEditInfo(UserEditInfoVo editInfoVo)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var sessionInfo = sessionStorage.GetSession(tokenReader.GetToken());
                string customerId = sessionInfo.FxCustomerId;
                var userInfo = await userService.GetUserInfoByUserIdAsync(sessionInfo.FxUserId);
                if (sessionInfo != null)
                {
                    await userService.UpdateUserInfo(
                        new UserInfoEditDto
                        {
                            Id = sessionInfo.FxUserId,
                            Gender = (byte)(editInfoVo.Gender - 1),
                            City = editInfoVo.City,
                            Province = editInfoVo.Province,
                            NickName = editInfoVo.NickName,
                            Avatar = editInfoVo.UserAvatar,
                            Area = editInfoVo.Area,
                            BirthDay = editInfoVo.Date,
                            Name = editInfoVo.Name,
                            PersonalSignature = editInfoVo.PersonalSignature,
                            DetailAdress = editInfoVo.DetailAddress,
                            Phone = editInfoVo.Phone
                        }
                        );
                    //新用户领取200积分
                    var integrationRecord = await CreateIntegrationRecordAsync(customerId, 200);
                    if (integrationRecord != null) await integrationAccount.AddByConsumptionAsync(integrationRecord);
                    var customer = dalCustomerInfo.GetAll().Where(e => e.Id == customerId).FirstOrDefault();
                    var baseInfo = await customerBaseInfoService.GetByPhoneAsync(userInfo.Phone);
                    if (baseInfo != null)
                    {
                        UpdateCustomerBaseInfoDto updateCustomerBaseInfoDto = new UpdateCustomerBaseInfoDto();
                        updateCustomerBaseInfoDto.Id = baseInfo.Id;
                        updateCustomerBaseInfoDto.PersonalWechat = baseInfo.PersonalWechat;
                        updateCustomerBaseInfoDto.Phone = editInfoVo.Phone;
                        updateCustomerBaseInfoDto.BusinessWeChat = baseInfo.BusinessWeChat;
                        updateCustomerBaseInfoDto.WechatMiniProgram = baseInfo.WechatMiniProgram;
                        updateCustomerBaseInfoDto.OfficialAccounts = baseInfo.OfficialAccounts;
                        updateCustomerBaseInfoDto.RealName = editInfoVo.Name;
                        updateCustomerBaseInfoDto.WechatNumber = baseInfo.WechatNumber;
                        updateCustomerBaseInfoDto.Sex = (byte)(editInfoVo.Gender - 1) == 1 ? "男" : "女";
                        updateCustomerBaseInfoDto.Birthday = editInfoVo.Date;
                        updateCustomerBaseInfoDto.Occupation = baseInfo.Occupation;
                        updateCustomerBaseInfoDto.OtherPhone = baseInfo.OtherPhone;
                        updateCustomerBaseInfoDto.DetailAddress = editInfoVo.DetailAddress;
                        updateCustomerBaseInfoDto.IsSendNote = baseInfo.IsSendNote;
                        updateCustomerBaseInfoDto.IsCall = baseInfo.IsCall;
                        updateCustomerBaseInfoDto.IsSendWeChat = baseInfo.IsSendWeChat;
                        updateCustomerBaseInfoDto.UnTrackReason = baseInfo.UnTrackReason;
                        updateCustomerBaseInfoDto.Remark = baseInfo.Remark;
                        updateCustomerBaseInfoDto.City = editInfoVo.City;
                        await customerBaseInfoService.UpdateAsync(updateCustomerBaseInfoDto);
                    }
                    unitOfWork.Commit();
                    return ResultData.Success();
                }
                else
                {
                    return ResultData.Fail();
                }
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        [HttpGet("birthDayCard")]
        public async Task<ResultData<BirthDayCardVo>> GetBirthDayCardInfo()
        {
            var sessionInfo = sessionStorage.GetSession(tokenReader.GetToken());
            string customerId = sessionInfo.FxCustomerId;
            var userInfo = await userService.GetUserInfoByUserIdAsync(sessionInfo.FxUserId);
            var customer = dalCustomerInfo.GetAll().Where(e => e.Id == customerId).FirstOrDefault();

            var baseInfo = await customerBaseInfoService.GetByPhoneAsync(userInfo.Phone);
            if (baseInfo != null)
            {
                BirthDayCardVo updateCustomerBaseInfoDto = new BirthDayCardVo();
                updateCustomerBaseInfoDto.Id = userInfo.Id;
                updateCustomerBaseInfoDto.Phone = userInfo.Phone;
                updateCustomerBaseInfoDto.Name = userInfo.Name;
                updateCustomerBaseInfoDto.BirthDay = userInfo.BirthDay;
                updateCustomerBaseInfoDto.DetailAddress = userInfo.DetailAddress;
                updateCustomerBaseInfoDto.City = userInfo.City;
                updateCustomerBaseInfoDto.Area = userInfo.Area;
                updateCustomerBaseInfoDto.Province = userInfo.Province;
                return ResultData<BirthDayCardVo>.Success().AddData("birthDay", updateCustomerBaseInfoDto);
            }
            else
            {
                return ResultData<BirthDayCardVo>.Success().AddData("birthDay", new BirthDayCardVo());
            }

        }
        [HttpPost("updateBirthDayCard")]
        public async Task<ResultData> UpdateBirthDayCardInfo(UpdateBirthDayCardVo update)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var sessionInfo = sessionStorage.GetSession(tokenReader.GetToken());
                string customerId = sessionInfo.FxCustomerId;
                var userInfo = await userService.GetUserInfoByUserIdAsync(sessionInfo.FxUserId);
                UpdateBirthDayCardDto updateBirthDayCardDto = new UpdateBirthDayCardDto();
                updateBirthDayCardDto.Id = sessionInfo.FxUserId;
                updateBirthDayCardDto.BirthDay = update.BirthDay;
                updateBirthDayCardDto.Name = update.Name;
                updateBirthDayCardDto.Phone = update.Phone;
                updateBirthDayCardDto.Province = update.Province;
                updateBirthDayCardDto.City = update.City;
                updateBirthDayCardDto.Area = update.Area;
                updateBirthDayCardDto.DetailAddress = update.DetailAddress;
                await userService.UpdateBirthDayCardInfo(updateBirthDayCardDto);
                var customer = dalCustomerInfo.GetAll().Where(e => e.Id == customerId).FirstOrDefault();
                var baseInfo = await customerBaseInfoService.GetByPhoneAsync(userInfo.Phone);
                if (baseInfo != null)
                {
                    UpdateCustomerBaseInfoDto updateCustomerBaseInfoDto = new UpdateCustomerBaseInfoDto();
                    updateCustomerBaseInfoDto.Id = baseInfo.Id;
                    updateCustomerBaseInfoDto.PersonalWechat = baseInfo.PersonalWechat;
                    updateCustomerBaseInfoDto.Phone = baseInfo.Phone;
                    updateCustomerBaseInfoDto.BusinessWeChat = baseInfo.BusinessWeChat;
                    updateCustomerBaseInfoDto.WechatMiniProgram = baseInfo.WechatMiniProgram;
                    updateCustomerBaseInfoDto.OfficialAccounts = baseInfo.OfficialAccounts;
                    updateCustomerBaseInfoDto.RealName = update.Name;
                    updateCustomerBaseInfoDto.WechatNumber = baseInfo.WechatNumber;
                    updateCustomerBaseInfoDto.Sex = baseInfo.Sex;
                    updateCustomerBaseInfoDto.Birthday = update.BirthDay;
                    updateCustomerBaseInfoDto.Occupation = baseInfo.Occupation;
                    updateCustomerBaseInfoDto.OtherPhone = baseInfo.OtherPhone;
                    updateCustomerBaseInfoDto.DetailAddress = update.DetailAddress;
                    updateCustomerBaseInfoDto.IsSendNote = baseInfo.IsSendNote;
                    updateCustomerBaseInfoDto.IsCall = baseInfo.IsCall;
                    updateCustomerBaseInfoDto.IsSendWeChat = baseInfo.IsSendWeChat;
                    updateCustomerBaseInfoDto.UnTrackReason = baseInfo.UnTrackReason;
                    updateCustomerBaseInfoDto.Remark = baseInfo.Remark;
                    updateCustomerBaseInfoDto.City = update.City;
                    await customerBaseInfoService.UpdateAsync(updateCustomerBaseInfoDto);
                }
                unitOfWork.Commit();
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw ex;
            }
        }
        /// <summary>
        /// 个人信息是否完善
        /// </summary>
        /// <returns></returns>
        [HttpGet("isComplete")]
        public async Task<ResultData<bool>> IsCompleteUserInfo() {
            var sessionInfo = sessionStorage.GetSession(tokenReader.GetToken());
            string customerId = sessionInfo.FxCustomerId;
            var result= await userService.IsCompleteUserInfo(sessionInfo.FxUserId);
            return ResultData<bool>.Success().AddData("isComplete",result);
        }

        /// <summary>
        /// 创建积分奖励记录
        /// </summary>
        /// <param name="customerId">用户id</param>
        /// <param name="awardAmount">奖励积分金额</param>
        /// <param name="percent">奖励比率</param>
        /// <returns></returns>
        private async Task<ConsumptionIntegrationDto> CreateIntegrationRecordAsync(string customerId, decimal awardAmount)
        {
            var exist = await integrationAccount.ExistNewCustomerRewardAsync(customerId, awardAmount, (int)GenerateType.NewCustomer);
            if (exist)
            {
                return null;
            }
            ConsumptionIntegrationDto consumptionIntegrationDto = new ConsumptionIntegrationDto
            {
                Quantity = awardAmount,
                Percent = 1,
                AmountOfConsumption = awardAmount,
                Date = DateTime.Now,
                CustomerId = customerId,
                ExpiredDate = DateTime.Now.AddMonths(12),
                Type = (int)GenerateType.NewCustomer
            };
            return consumptionIntegrationDto;
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
            user.Name = userInfo.Name;
            user.PersonalSignature = userInfo.PersonalSignature;
            user.Area = userInfo.Area;
            user.BirthDay = userInfo.BirthDay;
            user.DetailAddress = userInfo.DetailAddress;
            user.IsAuthorizationUserInfo = userInfo.IsAuthorizationUserInfo;
            return ResultData<UserInfoVo>.Success().AddData("userInfo", user);
        }
        /// <summary>
        /// 获取小程序码
        /// </summary>
        /// <returns></returns>
        [HttpGet("getBusinessCardCode")]
        public async Task<ResultData<string>> GetBusinessCardCode()
        {
            string token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            var userInfo = await userService.GetUserInfoByUserIdAsync(sessionInfo.FxUserId);
            var userId = userInfo.Id;
            var avatarUrl = userInfo.Avatar;
            var baseString = await userService.GetUserQrCode(userId, avatarUrl);
            return ResultData<string>.Success().AddData("qrCode", baseString);
        }
        /// <summary>
        /// 添加上级
        /// </summary>
        /// <param name="superiorId"></param>
        /// <returns></returns>
        [HttpPut("setSuperior/{superiorId}")]
        public async Task<ResultData<string>> SetSuperior(string superiorId)
        {
            string token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            var result = await userService.AddSuperiorAsync(sessionInfo.FxUserId, superiorId);
            return ResultData<string>.Success();
        }
        /// <summary>
        /// 获取下级用户
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("subordinateList")]
        public async Task<ResultData<FxPageInfo<SubordinateUserVo>>> GetSubordinateList(int pageNum, int pageSize)
        {
            FxPageInfo<SubordinateUserVo> fxPageInfo = new FxPageInfo<SubordinateUserVo>();
            string token = tokenReader.GetToken();
            var sessionInfo = sessionStorage.GetSession(token);
            var list = await userService.GetSubordinateUserListAsync(sessionInfo.FxUserId, pageNum, pageSize);
            fxPageInfo.TotalCount = list.TotalCount;
            fxPageInfo.List = list.List.Select(e => new SubordinateUserVo
            {
                NickName = e.NickName,
                AvatarUrl = e.AvatarUrl,
                CreateDate = e.CreateDate,
                CustomerId = e.CustomerId
            });
            return ResultData<FxPageInfo<SubordinateUserVo>>.Success().AddData("subordinate", fxPageInfo);
        }
    }
}