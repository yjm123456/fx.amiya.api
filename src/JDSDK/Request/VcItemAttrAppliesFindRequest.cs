using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcItemAttrAppliesFindRequest : JdRequestBase<VcItemAttrAppliesFindResponse>
    {
                                                                                                                                                                               public  		string
                                                                                                                      wareGroupId
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
              category
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
                                                                                                                      beginApplyTime
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<DateTime>
                                                                                                                      endApplyTime
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
              state
 {get; set;}
                                                          
                                                          public  		string
                                                                                      publicName
 {get; set;}
                                                                                                                                  
                                                          public  		string
              offset
 {get; set;}
                                                          
                                                          public  		string
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.vc.item.attr.applies.find";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("ware_group_id", this.                                                                                                                    wareGroupId
);
                                                                                                        parameters.Add("category", this.            category
);
                                                                                                        parameters.Add("begin_apply_time", this.                                                                                                                    beginApplyTime
);
                                                                                                        parameters.Add("end_apply_time", this.                                                                                                                    endApplyTime
);
                                                                                                        parameters.Add("state", this.            state
);
                                                                                                        parameters.Add("public_name", this.                                                                                    publicName
);
                                                                                                        parameters.Add("offset", this.            offset
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                            }
    }
}





        
 

