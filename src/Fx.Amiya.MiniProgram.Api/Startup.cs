using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Open.Infrastructure.Web.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Fx.Open.Infrastructure.Web.Filters;
using Fx.Amiya.MiniProgram.Api.Filters;
using Fx.Amiya.Common;
using Fx.Open.Infrastructure.Web.Middleware;
using Fx.Sms.Aliyun;
using Fx.Amiya.Core.Services;

namespace Fx.Amiya.MiniProgram.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFxValidateModelFilter();
            services.AddSingleton<IMiniSessionStorage, FxMiniSessionStorage>();

            services.AddFxSwagger(xmlDocName: "Fx.Amiya.MiniProgram.Api.xml", title: "啊美雅微信小程序API");

            services.AddAuthorization(options => {
                options.AddPolicy("wx_mini_api_validate_usertype", policy =>
                {
                    policy.Requirements.Add(new FxAmiyaApiUserTypeAuthorizationRequirement());
                });
            });
            services.AddHttpContextAccessor();

            services.AddScoped<IAuthorizationHandler, FxAmiyaApiUserTypeAuthorizationHandler>();

            services.AddScoped<TokenReader>();
            services.AddFxAmiyaCommonServices();

            services.AddTimedJob();
            FxAmiyaModulesRegister.RegisteModules(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(b=>b.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            app.UseRouting();
           
            app.UseAuthorization();

            var enableApiDoc = Configuration.GetValue<bool?>("FxOpen:Params:EnableApiDoc");
            if (enableApiDoc == true)
            {
                app.UseFxSwagger();
            }

            app.UseTimedJob();

            app.UseFxExceptionHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
        }
    }
}
