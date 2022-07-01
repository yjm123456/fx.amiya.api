using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AreasProvinceGetRequest : JdRequestBase<AreasProvinceGetResponse>
    {
                            public override string ApiName
            {
                get{return "jingdong.areas.province.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                }
    }
}





        
 

