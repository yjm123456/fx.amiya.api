using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class KuaicheZnPlanListSearchRequest : JdRequestBase<KuaicheZnPlanListSearchResponse>
    {
                                                                                                                                                                               public  		string
                                                                                      planName
 {get; set;}
                                                                                                                                  
                                                          public  		string
              mode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                          public  		string
                                                                                                                                                      isQueryByStatus
 {get; set;}
                                                                                                                                                                                  
                                                          public  		Nullable<int>
              begin
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              end
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageIndex
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.kuaiche.zn.plan.list.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("plan_name", this.                                                                                    planName
);
                                                                                                        parameters.Add("mode", this.            mode
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("is_query_by_status", this.                                                                                                                                                    isQueryByStatus
);
                                                                                                        parameters.Add("begin", this.            begin
);
                                                                                                        parameters.Add("end", this.            end
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                                                        parameters.Add("page_index", this.                                                                                    pageIndex
);
                                                                            }
    }
}





        
 

