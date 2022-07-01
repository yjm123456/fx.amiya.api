using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Partner.Api.Authorization
{
    public static class FxAuthorizationRegisterServicesExtension
    {
        /// <summary>
        /// 注册授权需要的服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddFxAuthorization(this IServiceCollection services)
        {
            services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("authorizationRequestHeaderValidate", policy =>
                {
                    policy.Requirements.Add(new FxAuthorizationRequestHeaderValidateRequirement());

                });

            });
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer();

            services.AddHttpContextAccessor();


            services.AddScoped<IAuthorizationHandler, FxAuthorizationRequestHeaderValidateAuthorizationHandler>();

            return services;
        }
    }
}
