using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Amiya.Call.Api.Vo.CallRecord;
using Fx.Amiya.Common;
using Fx.Authentication;
using Fx.Authorization;
using Fx.Identity.Core;
using Fx.Infrastructure.DataAccess.Mongodb.Standard;
using Fx.Open.Infrastructure.Web.Filters;
using Fx.Open.Infrastructure.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fx.Amiya.Call.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFxValidateModelFilter();
            
            services.AddFxAmiyaCommonServices();
            services.AddScoped<IMongoRepository<CallRecordVo>, FxCallRecordMongoRepository>();

            services.AddFxJwtTokenAuthenticationServices();
            services.AddScoped<IFxIdentityRepository, FxIdentityRepository>();
            services.AddFxAuthroizationServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(b => b.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseFxExceptionHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
