using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class KuaicheZnPlanSearchKeywordDeleteRequest : JdRequestBase<KuaicheZnPlanSearchKeywordDeleteResponse>
    {
                                                                                                                                                    public  		Nullable<long>
                                                                                      planId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      keywordIds
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.kuaiche.zn.plan.search.keyword.delete";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                parameters.Add("plan_id", this.                                                                                    planId
);
                                                                                                        parameters.Add("keyword_ids", this.                                                                                    keywordIds
);
                                                    }
    }
}





        
 

