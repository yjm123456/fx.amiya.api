﻿using Fx.Identity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api
{
    public class FxAmiyaHospitalEmployeeIdentity:FxTenantIdentity
    {
        public int HospitalId { get; set; }

    } 
}
