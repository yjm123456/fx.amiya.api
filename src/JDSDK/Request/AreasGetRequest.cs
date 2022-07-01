using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AreasGetRequest : JdRequestBase<AreasGetResponse>
    {
                            public override string ApiName
            {
                get{return "jingdong.areas.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                }
    }
}





        
 

