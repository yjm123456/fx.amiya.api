using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAlphaProviderSignApproveRequest : JdRequestBase<LdopAlphaProviderSignApproveResponse>
    {
                                                                                                                                              public  		string
              requestId
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              approveResult
 {get; set;}
                                                          
                                                          public  		string
              approveMessage
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ldop.alpha.provider.sign.approve";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("requestId", this.            requestId
);
                                                                                                        parameters.Add("approveResult", this.            approveResult
);
                                                                                                        parameters.Add("approveMessage", this.            approveMessage
);
                                                                                                                            }
    }
}





        
 

