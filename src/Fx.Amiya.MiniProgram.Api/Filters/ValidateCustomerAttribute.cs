using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Filters
{
    public class ValidateCustomerAttribute: ActionFilterAttribute
    {
        private IMiniSessionStorage _sessionStorage;

        public ValidateCustomerAttribute(IMiniSessionStorage sessionStorage
            )
        {
            _sessionStorage = sessionStorage;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var token = TokenReader.GetToken(request);
            var session = _sessionStorage.GetSession(token);

            if (session == null)
            {
                context.Result = new JsonResult(ResultData<string>.Fail(4010, "token无效"));
            }
            else
            {
                if (session.FxCustomerId == null)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
        }
    }
}
