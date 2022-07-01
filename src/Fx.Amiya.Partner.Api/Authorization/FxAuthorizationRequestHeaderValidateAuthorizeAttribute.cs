using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Partner.Api.Authorization
{
    public class FxAuthorizationRequestHeaderValidateAuthorizeAttribute: AuthorizeAttribute
    {
        public FxAuthorizationRequestHeaderValidateAuthorizeAttribute(FxHeaderType fxHeaderType = FxHeaderType.Authorization)
        {
            this.Policy = "authorizationRequestHeaderValidate";
            this.FxHeaderType = fxHeaderType;
        }
        public FxHeaderType FxHeaderType { get; set; }
    }
    public enum FxHeaderType
    {
        Authorization = 0x00000001,
        InternalVistor = 0x00000010
    }
}
