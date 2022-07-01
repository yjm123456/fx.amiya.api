using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopPickupCancelRequest : JdRequestBase<LdopPickupCancelResponse>
    {
                                                                                                                                              public  		string
              endReasonName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              endReason
 {get; set;}
                                                          
                                                          public  		string
              pickupCode
 {get; set;}
                                                          
                                                          public  		string
              source
 {get; set;}
                                                          
                                                          public  		string
              customerCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ldop.pickup.cancel";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("endReasonName", this.            endReasonName
);
                                                                                                        parameters.Add("endReason", this.            endReason
);
                                                                                                        parameters.Add("pickupCode", this.            pickupCode
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                            }
    }
}





        
 

