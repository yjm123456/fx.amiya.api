using Fx.Amiya.IService;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Filters
{
    public class FxAmiyaApiUserTypeAuthorizationHandler : AuthorizationHandler<FxAmiyaApiUserTypeAuthorizationRequirement>
    {
        private IMiniSessionStorage _miniSessionStorage;
        private IHttpContextAccessor _httpContextAccessor;
        private IUserService _userService;
        public FxAmiyaApiUserTypeAuthorizationHandler(IHttpContextAccessor httpContextAccessor,
            IMiniSessionStorage miniSessionStorage,
            IUserService userService)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _miniSessionStorage = miniSessionStorage;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, FxAmiyaApiUserTypeAuthorizationRequirement requirement)
        {

            HttpRequest request = _httpContextAccessor.HttpContext.Request;
            HttpResponse response = _httpContextAccessor.HttpContext.Response;
            var session = _miniSessionStorage.GetSession(TokenReader.GetToken(request));
            if (!await ValidateSessionAsync(session))
            {
                //这里直接return，因为验证token如果出问题，那边会直接在response里处理返回结果，所以这里不需要再context.fail()
                return;
            }

            var routeData = RouteUtil.GetRouteData(context.Resource);
            if (string.IsNullOrEmpty(routeData.Item1))
            {
                context.Fail();
                return;
            }
            //var attr = resource.Metadata.GetMetadata<FxAmiyaApiUserTypeAuthorizationAttribute>();
            var attr = _httpContextAccessor.HttpContext.GetEndpoint().Metadata.GetMetadata<FxAmiyaApiUserTypeAuthorizationAttribute>();
            if (attr.UserType == UserType.Customer)
            {
                if (session.FxCustomerId != null)
                {
                    var customerId = await _userService.GetCustomerIdAsync(session.FxUserId);
                    if (customerId == null)
                    {
                        context.Fail();
                    }
                    else
                    {
                        session.FxCustomerId = customerId;
                        context.Succeed(requirement);
                    }

                }
                else
                {
                    context.Fail();
                }

            }
            else
            {
                context.Succeed(requirement);
            }

        }

        private async Task<bool> ValidateSessionAsync(FxWxMiniUserSession session)
        {

            HttpResponse response = _httpContextAccessor.HttpContext.Response;

            if (session == null)
            {
                response.ContentType = "application/json; charset=UTF-8";
                response.StatusCode = 200;
                await response.WriteAsync(JsonConvert.SerializeObject(ResultData<string>.Fail(4010, "token无效！")));
                await response.Body.FlushAsync();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
