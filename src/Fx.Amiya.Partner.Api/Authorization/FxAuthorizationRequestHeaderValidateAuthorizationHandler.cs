using Fx.Amiya.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Fx.Infrastructure.Extensions;

namespace Fx.Amiya.Partner.Api.Authorization
{
    public class FxAuthorizationRequestHeaderValidateAuthorizationHandler
        : AuthorizationHandler<FxAuthorizationRequestHeaderValidateRequirement>
    {
        IHttpContextAccessor httpContextAccessor;
        private FxAppGlobal _fxAppGlobal;


        public FxAuthorizationRequestHeaderValidateAuthorizationHandler(IHttpContextAccessor httpContextAccessor,
            FxAppGlobal fxAppGlobal)
        {
            this.httpContextAccessor = httpContextAccessor;
            _fxAppGlobal = fxAppGlobal;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, FxAuthorizationRequestHeaderValidateRequirement requirement)
        {
            HttpRequest request = httpContextAccessor.HttpContext.Request;
            if (context.Resource is Endpoint resource)
            {
                var attr = resource.Metadata.GetMetadata<FxAuthorizationRequestHeaderValidateAuthorizeAttribute>();
                if (attr != null)
                {
                    if ((attr.FxHeaderType & FxHeaderType.InternalVistor) == FxHeaderType.InternalVistor)
                    {
                        if (ValidateInternalVistor(request))
                        {
                            context.Succeed(requirement);

                        }
                        else
                        {
                            if ((attr.FxHeaderType & FxHeaderType.Authorization) == FxHeaderType.Authorization)
                            {
                                if (ValidateAuthorizationHeader(request))
                                {
                                    context.Succeed(requirement);
                                }
                                else
                                {
                                    context.Fail();
                                }
                            }
                            else
                            {
                                context.Fail();
                            }

                        }
                    }
                    else
                    {
                        if (ValidateAuthorizationHeader(request))
                        {
                            context.Succeed(requirement);
                        }
                        else
                        {
                            context.Fail();
                        }
                    }
                }
                else
                {
                    context.Fail();
                }
            }
            else
            {
                context.Fail();
            }
        }

        private bool ValidateInternalVistor(HttpRequest request)
        {
            string vistor = request.Headers["vistor"];
            return !string.IsNullOrWhiteSpace(vistor) && vistor == "internal";

        }

        private bool ValidateAuthorizationHeader(HttpRequest request)
        {
            string authorization = request.Headers["Authorization"];
            if (string.IsNullOrWhiteSpace(authorization))
            {
                return false;
            }

            string token = string.Empty;
            if (authorization.StartsWith("Bearer") || authorization.StartsWith("bearer"))
            {
                token = authorization.Substring("bearer".Length).Trim();
            }
            else
            {
                token = authorization.Trim();
            }
            if (string.IsNullOrWhiteSpace(token))
            {
                return false;
            }

            try
            {

                return Validate(token, opt => true);

            }
            catch
            {
                return false;
            }
        }



        /// <summary>
        /// 验证身份 验证签名的有效性,
        /// </summary>
        /// <param name="encodeJwt"></param
        /// <param name="validatePayLoad">自定义各类验证； 是否包含那种申明，或者申明的值， </param>
        /// 例如：payLoad["aud"]?.ToString() == "roberAuddience";
        /// 例如：验证是否过期 等
        /// <returns></returns>
        private bool Validate(string token, Func<Dictionary<string, object>, bool> validatePayLoad)
        {
            var success = true;
            var jwtArr = token.Split('.');
            //var header = JsonConvert.DeserializeObject<Dictionary<string, object>>(Base64UrlEncoder.Decode(jwtArr[0]));
            var payLoad = JsonConvert.DeserializeObject<Dictionary<string, object>>(Base64UrlEncoder.Decode(jwtArr[1]));

            var hs256 = new HMACSHA256(Encoding.UTF8.GetBytes(_fxAppGlobal.AppConfig.FxJwtConfig.Key));
            //首先验证签名是否正确（必须的）
            success = success && string.Equals(jwtArr[2], Base64UrlEncoder.Encode(hs256.ComputeHash(Encoding.UTF8.GetBytes(string.Concat(jwtArr[0], ".", jwtArr[1])))));
            if (!success)
            {
                return false;//签名不正确直接返回
            }
            //其次验证是否在有效期内（也应该必须）
            var now = DateTime.UtcNow.GetTimestampSeconds();
            success = success && (now >= long.Parse(payLoad["nbf"].ToString()) && now < long.Parse(payLoad["exp"].ToString()));

            //再其次 进行自定义的验证

            success = success && validatePayLoad(payLoad);

            return success;
        }



    }
}
