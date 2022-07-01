using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Common;
using Fx.Amiya.Core.Services;
using Fx.Amiya.SyncOrder.JD;
using Fx.Open.Infrastructure.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fx.Amiya.JD.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTimedJob();
            services.AddHostedService<FxAmiyaJDInitializer>();
            services.AddFxAmiyaSyncJDOrderServices();
            services.AddFxAmiyaCommonServices();
            FxAmiyaModulesRegister.RegisteModules(services);
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(b => b.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            app.UseRouting();
            app.UseTimedJob();
            app.UseFxExceptionHandler();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
