using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class FindBusinessByVenderIdRequest : JdRequestBase<FindBusinessByVenderIdResponse>
    {
                                                                     public override string ApiName
            {
                get{return "jingdong.findBusinessByVenderId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                            }
    }
}





        
 

