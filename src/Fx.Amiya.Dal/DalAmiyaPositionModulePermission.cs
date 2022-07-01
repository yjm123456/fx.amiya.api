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
    public class DalAmiyaPositionModulePermission : DalEFCore<AmiyaPositionModulePermission>, IDalAmiyaPositionModulePermission
    {
        public DalAmiyaPositionModulePermission(AmiyaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
