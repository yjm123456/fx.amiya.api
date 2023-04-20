using Fx.Amiya.DbModels;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Infrastructure.DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dal
{
    public class DalMiniprogram : DalEFCore<Miniprogram>, IDalMiniprogram
    {
        public DalMiniprogram(AmiyaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
