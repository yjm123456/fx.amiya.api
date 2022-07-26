using Fx.Amiya.DbModels;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Infrastructure.DataAccess;
using Fx.Infrastructure.DataAccess.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dal
{
    public class DalTikTokUserInfo : DalEFCore<TikTokUserInfo>, IDalTikTokUserInfo
    {
        public DalTikTokUserInfo(AmiyaDbContext amiyaDbContext) : base(amiyaDbContext) { }
    }
}
