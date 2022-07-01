using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Infrastructure.DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Fx.Amiya.Dal
{
    public class DalTrackTool : DalEFCore<TrackTool>, IDalTrackTool
    {
        public DalTrackTool(AmiyaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
