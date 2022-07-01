using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Filters
{
    /// <summary>
    /// 用户类型授权
    /// </summary>
    public class FxAmiyaApiUserTypeAuthorizationAttribute: AuthorizeAttribute
    {
        public UserType UserType { get; set; }

        public FxAmiyaApiUserTypeAuthorizationAttribute(UserType userType = UserType.User)
        {
            Policy = "wx_mini_api_validate_usertype";
            UserType = userType;
        }
    }
}
