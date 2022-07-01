using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Filters
{
    public class RouteUtil
    {
        public static Tuple<string, string> GetRouteData(object contextResource)
        {

            if (contextResource is RouteEndpoint resource)
            {
                var route = resource.RoutePattern.RawText;
                var httpMethodMetadata = resource.Metadata.GetMetadata<HttpMethodMetadata>();
                return new Tuple<string, string>(route, httpMethodMetadata.HttpMethods[0]);


            }
            else if (contextResource is HttpContext httpContext)
            {
                var route = httpContext.Request.Path;
                var httpMethod = httpContext.Request.Method;
                return new Tuple<string, string>(route, httpMethod);
            }
            else
            {
                return new Tuple<string, string>(string.Empty, string.Empty);
            }
        }
    }
}
