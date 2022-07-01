using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpTraceServiceJosSubscribeTraceByWaybillServiceRequest : JdRequestBase<EclpTraceServiceJosSubscribeTraceByWaybillServiceResponse>
    {
                                                                                                                                                                                                                public  		string
              source
 {get; set;}
                                                          
                                                          public  		string
              waybillId
 {get; set;}
                                                          
                                                          public  		string
              carrierCode
 {get; set;}
                                                          
                                                          public  		string
              sign
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              t
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.trace.service.jos.SubscribeTraceByWaybillService";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("source", this.            source
);
                                                                                                        parameters.Add("waybillId", this.            waybillId
);
                                                                                                        parameters.Add("carrierCode", this.            carrierCode
);
                                                                                                        parameters.Add("sign", this.            sign
);
                                                                                                        parameters.Add("t", this.            t
);
                                                                            }
    }
}





        
 

