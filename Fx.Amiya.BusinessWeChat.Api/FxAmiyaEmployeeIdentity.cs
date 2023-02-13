using Fx.Identity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWechat.Api
{
    public class FxAmiyaEmployeeIdentity : FxInternalEmployeeIdentity
    {
        public bool IsCustomerService { get; set; }
    }
}
