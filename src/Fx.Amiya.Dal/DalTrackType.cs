using Fx.Amiya.DbModels;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Infrastructure.DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dal
{
    public class DalTrackType : DalEFCore<TrackType>, IDalTrackType
    {
        public DalTrackType(AmiyaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
