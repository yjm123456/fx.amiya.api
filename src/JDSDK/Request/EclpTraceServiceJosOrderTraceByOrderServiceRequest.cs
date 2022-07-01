using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpTraceServiceJosOrderTraceByOrderServiceRequest : JdRequestBase<EclpTraceServiceJosOrderTraceByOrderServiceResponse>
    {
                                                                                                                                              public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              role
 {get; set;}
                                                          
                                                          public  		string
              userId
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.eclp.trace.service.jos.OrderTraceByOrderService";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("role", this.            role
);
                                                                                                        parameters.Add("userId", this.            userId
);
                                                                                                                                                                            }
    }
}





        
 

