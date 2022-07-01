using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspKcUsertagGetRequest : JdRequestBase<DspKcUsertagGetResponse>
    {
                            public override string ApiName
            {
                get{return "jingdong.dsp.kc.usertag.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                }
    }
}





        
 

