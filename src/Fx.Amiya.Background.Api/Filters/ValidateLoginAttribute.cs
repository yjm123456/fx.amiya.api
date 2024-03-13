using Fx.Open.Infrastructure.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Filters
{
    public class ValidateLoginAttribute : ActionFilterAttribute
    {
        private IOffcialWebUserSessionStorage _sessionStorage;

        public ValidateLoginAttribute(IOffcialWebUserSessionStorage sessionStorage
            )
        {
            _sessionStorage = sessionStorage;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            string tokenHeader = request.Headers["Token"];
            string token = null;
            if (!string.IsNullOrWhiteSpace(tokenHeader))
            {
                    token = tokenHeader.Trim();                
            }
            var session = _sessionStorage.GetSession(token);

            if (session == null)
            {
                context.Result = new JsonResult(ResultData<string>.Fail(403, "token无效"));
            }
            else
            {
                if (string.IsNullOrEmpty(session.Phone) == null)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
        }
    }
}
