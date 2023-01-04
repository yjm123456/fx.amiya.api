using Fx.Amiya.Dto.UserInfo;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IUserService
    {
        /// <summary>
        /// 添加一个未用户授权小程序用户
        /// 前提是能取到unionid
        /// </summary>
        /// <param name="miniUserAddDto"></param>
        /// <returns>返回添加成功后的user</returns>
        Task<WxMiniUserDto> AddUnauthorizedWxMiniUserAsync(UnauthorizedWxMiniUserAddDto miniUserAddDto);

        Task<WxMiniUserDto> AddAuthorizedWxMiniUserAsync(AuthorizedWxMiniUserAddDto miniUserAddDto);

        /// <summary>
        /// 通过小程序用户信息来更新方旋用户信息
        /// </summary>
        /// <param name="miniUserEditDto"></param>
        /// <returns></returns>
        Task<bool> UpdateUserInfoByWxMiniUserAsync(WxMiniUserEditDto miniUserEditDto);
        /// <summary>
        /// 用户编辑个人信息
        /// </summary>
        /// <param name="userInfoEditDto"></param>
        /// <returns></returns>

        Task<bool> UpdateUserInfo(UserInfoEditDto userInfoEditDto);


        Task<string> GetCustomerIdAsync(string fxUserId);

        Task<bool> UpdateUserWxBindPhoneAsync(string userId, string phone);


        /// <summary>
        /// 根据用户编号集合获取昵称头像
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        Task<List<UserNickNameDto>> GetNickNameList(List<string> userIds);

        /// <summary>
        /// 通过公众号openid取用户ID
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        Task<string> GetFxUserIdByMpUserOpenIdAsync(string openid);

        /// <summary>
        /// 用户关注公众号
        /// </summary>
        /// <param name="wxMpUser"></param>
        /// <returns></returns>
        Task<WxMpUserInfoDto> WxMpUserSubscribeAsync(WxMpUserInfoDto wxMpUser);


        /// <summary>
        /// 用户取关公众号
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        Task WxMpUserUnsubscribeAsync(string openid);

        /// <summary>
        /// 根据userId获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
         Task<UserInfoDto> GetUserInfoByUserIdAsync(string userId);
        /// <summary>
        /// 根据userid获取分享二维码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<string> GetUserQrCode(string userId, string avatar);
        /// <summary>
        /// 添加用户上级
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="superiorId">上级id</param>
        /// <returns></returns>
        Task<bool> AddSuperiorAsync(string userId,string superiorId,string customerId);
        /// <summary>
        /// 判断一个用户是否是下级用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> IsSubordinate(string userId,string subordinateUserId);
        /// <summary>
        /// 分页获取下级用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<SubordinateUserDto>> GetSubordinateUserListAsync(string userId,int pageNum,int pageSize);
        /// <summary>
        /// 修改生日卡片信息
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        Task UpdateBirthDayCardInfo(UpdateBirthDayCardDto update);
        /// <summary>
        /// 是否完成个人信息完善
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> IsCompleteUserInfo(string userId);
    }
}
