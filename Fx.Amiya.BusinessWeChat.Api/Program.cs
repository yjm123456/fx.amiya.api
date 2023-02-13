using Fx.Amiya.BusinessWechat.Api;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FxHostBuilder.CreateHostBuilderWithConfiguration<Startup>(args)
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .Build().Run();


        }
    }
}
