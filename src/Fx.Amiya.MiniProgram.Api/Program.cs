using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Fx.Amiya.MiniProgram.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FxHostBuilder.CreateHostBuilderWithConfiguration<Startup>(args)
                .UseDefaultServiceProvider(options=>options.ValidateScopes=false)
                .Build().Run();

        }

     
    }
}
