using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class KuaicheZnPlanSearchKeywordUpdateRequest : JdRequestBase<KuaicheZnPlanSearchKeywordUpdateResponse>
    {
                                                                                                                                                    public  		Nullable<long>
                                                                                      planId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      keywordPrice
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.kuaiche.zn.plan.search.keyword.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                parameters.Add("plan_id", this.                                                                                    planId
);
                                                                                                        parameters.Add("keyword_price", this.                                                                                    keywordPrice
);
                                                    }
    }
}





        
 

