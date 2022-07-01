using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class KuaicheZnPlanSearchCreateRequest : JdRequestBase<KuaicheZnPlanSearchCreateResponse>
    {
                                                                                                                                                    public  		string
                                                                                      planInfo
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.kuaiche.zn.plan.search.create";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                parameters.Add("plan_info", this.                                                                                    planInfo
);
                                                    }
    }
}





        
 

