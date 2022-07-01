using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Background.Api.Vo.UserInfo;
using Fx.Amiya.IService;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fx.Amiya.Background.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private IUserService userService;

        public UserInfoController(IUserService userService)
        {
            this.userService = userService;
        }


        /// <summary>
        /// 根据用户编号集合获取昵称头像列表
        /// </summary>
        /// <param name="userIds">用户编号数组</param>
        /// <returns></returns>
        [HttpPost("getNickNameList")]
        public async Task<ResultData<List<UserNickNameVo>>> GetNickNameList([FromBody]List<string> userIds)
        {
            try
            {
                var user = from d in await userService.GetNickNameList(userIds)
                           select new UserNickNameVo
                           {
                               UserId = d.UserId,
                               NickName = d.NickName,
                               Avatar = d.Avatar,
                               Phone=d.Phone,
                               EncryptPhone=d.EncryptPhone
                           };

                return ResultData<List<UserNickNameVo>>.Success().AddData("userList", user.ToList());

            }
            catch (Exception ex)
            {
                return ResultData<List<UserNickNameVo>>.Fail(ex.Message);
            }
        }
    }
}