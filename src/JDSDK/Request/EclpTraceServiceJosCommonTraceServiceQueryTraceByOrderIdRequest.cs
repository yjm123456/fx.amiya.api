using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpTraceServiceJosCommonTraceServiceQueryTraceByOrderIdRequest : JdRequestBase<EclpTraceServiceJosCommonTraceServiceQueryTraceByOrderIdResponse>
    {
                                                                                                                                                                                                                public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              source
 {get; set;}
                                                          
                                                          public  		string
              sign
 {get; set;}
                                                          
                                                          public  		string
              t
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.trace.service.jos.CommonTraceService.queryTraceByOrderId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                        parameters.Add("sign", this.            sign
);
                                                                                                        parameters.Add("t", this.            t
);
                                                                            }
    }
}





        
 

