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
    public class DalWaitTrackCustomer : DalEFCore<WaitTrackCustomer>, IDalWaitTrackCustomer
    {
        public DalWaitTrackCustomer(AmiyaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
