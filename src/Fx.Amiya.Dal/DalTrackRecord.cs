using System;
using System.Collections.Generic;
using System.Text;
using Fx.Amiya.DbModels;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Infrastructure.DataAccess.EFCore;

namespace Fx.Amiya.Dal
{
    public class DalTrackRecord : DalEFCore<TrackRecord>, IDalTrackRecord
    {
        public DalTrackRecord(AmiyaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
