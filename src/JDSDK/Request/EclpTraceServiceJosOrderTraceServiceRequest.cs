using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpTraceServiceJosOrderTraceServiceRequest : JdRequestBase<EclpTraceServiceJosOrderTraceServiceResponse>
    {
                                                                                                                                              public  		string
              waybillId
 {get; set;}
                                                          
                                                          public  		string
              carrierCode
 {get; set;}
                                                          
                                                          public  		string
              role
 {get; set;}
                                                          
                                                          public  		string
              userId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.trace.service.josOrderTraceService";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("waybillId", this.            waybillId
);
                                                                                                        parameters.Add("carrierCode", this.            carrierCode
);
                                                                                                        parameters.Add("role", this.            role
);
                                                                                                        parameters.Add("userId", this.            userId
);
                                                                            }
    }
}





        
 

