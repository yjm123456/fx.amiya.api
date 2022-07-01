
using Fx.Amiya.Core;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Modules.MemberCard.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace Fx.Amiya.Modules.MemberCard.AppService
{
   public class MemberCardModuleRegister: DefaultFxModuleRegister
    {
        public MemberCardModuleRegister()
        {
            Name = "MemberCardModule";
        }

        public override void AddModuleServices(IServiceCollection services)
        {
            base.AddModuleServices(services);
            services.AddMemberCardRepositoryServices(DbConnectionString, ReadDbConnectionStrings, DBType);
            services.AddScoped<IMemberRankInfo, MemberRankInfoAppService>();
            services.AddScoped<IMemberCard, MemberCardHandleAppService>();
        }
    }
}
