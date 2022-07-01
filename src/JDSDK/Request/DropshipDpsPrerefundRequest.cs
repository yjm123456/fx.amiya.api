using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DropshipDpsPrerefundRequest : JdRequestBase<DropshipDpsPrerefundResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              customOrderId
 {get; set;}
                                                          
                                                          public  		string
              approvalSuggestion
 {get; set;}
                                                          
                                                          public  		string
              approvalState
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  		string
              operatorState
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dropship.dps.prerefund";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("customOrderId", this.            customOrderId
);
                                                                                                        parameters.Add("approvalSuggestion", this.            approvalSuggestion
);
                                                                                                        parameters.Add("approvalState", this.            approvalState
);
                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("operatorState", this.            operatorState
);
                                                                            }
    }
}





        
 

