using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api
{
    public class TokenReader
    {
        private IHttpContextAccessor httpContextAccessor;
        public TokenReader(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetToken()
        {
            HttpRequest request = httpContextAccessor.HttpContext.Request;
            return GetToken(request);
        }

        public static string GetToken(HttpRequest request)
        {
            string tokenHeader = request.Headers["Authorization"];
            string token = null;
            if (!string.IsNullOrWhiteSpace(tokenHeader))
            {

                if (tokenHeader.StartsWith("Bearer") || tokenHeader.StartsWith("bearer"))
                {
                    token = tokenHeader.Substring("bearer".Length).Trim();
                }
                else
                {
                    token = tokenHeader.Trim();
                }
            }
            return token;
        }
    }
}
