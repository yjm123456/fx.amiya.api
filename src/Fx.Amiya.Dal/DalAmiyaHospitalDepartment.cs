﻿using Fx.Amiya.DbModels;
using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IDal;
using Fx.Infrastructure.DataAccess.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dal
{
    public class DalAmiyaHospitalDepartment : DalEFCore<AmiyaHospitalDepartment>, IDalAmiyaHospitalDepartment
    {
        public DalAmiyaHospitalDepartment(AmiyaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
