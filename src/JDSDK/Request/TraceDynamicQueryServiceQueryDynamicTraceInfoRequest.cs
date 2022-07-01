using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class TraceDynamicQueryServiceQueryDynamicTraceInfoRequest : JdRequestBase<TraceDynamicQueryServiceQueryDynamicTraceInfoResponse>
    {
                                                                                  public  		string
              customerCode
 {get; set;}
                                                          
                                                          public  		string
              waybillCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.trace.dynamicQueryService.queryDynamicTraceInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("customerCode", this.            customerCode
);
                                                                                                        parameters.Add("waybillCode", this.            waybillCode
);
                                                                                                    }
    }
}





        
 

