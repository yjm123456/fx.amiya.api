﻿using Fx.Amiya.DbModels;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Infrastructure.DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dal
{
    public class DalHospitalTagDetail : DalEFCore<HospitalTagDetail>, IDalHospitalTagDetail
    {
        public DalHospitalTagDetail(AmiyaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
