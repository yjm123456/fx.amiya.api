using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class KuaicheZnPlanDetailGetRequest : JdRequestBase<KuaicheZnPlanDetailGetResponse>
    {
                                                                                                                   public  		Nullable<long>
                                                                                      planId
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.kuaiche.zn.plan.detail.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("plan_id", this.                                                                                    planId
);
                                                    }
    }
}





        
 

