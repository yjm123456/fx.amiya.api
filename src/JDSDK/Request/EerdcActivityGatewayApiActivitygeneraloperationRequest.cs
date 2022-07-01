using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EerdcActivityGatewayApiActivitygeneraloperationRequest : JdRequestBase<EerdcActivityGatewayApiActivitygeneraloperationResponse>
    {
                                                                                                                                                    public  		string
              operType
 {get; set;}
                                                          
                                                          public  		string
              jsonData
 {get; set;}
                                                          
                                                          public  		string
              k
 {get; set;}
                                                          
                                                          public  		string
              t
 {get; set;}
                                                          
                                                          public  		string
              sign
 {get; set;}
                                                          
                                                          public  		string
              extStr
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.eerdc.activity.gateway.api.activitygeneraloperation";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                parameters.Add("operType", this.            operType
);
                                                                                                        parameters.Add("jsonData", this.            jsonData
);
                                                                                                        parameters.Add("k", this.            k
);
                                                                                                        parameters.Add("t", this.            t
);
                                                                                                        parameters.Add("sign", this.            sign
);
                                                                                                        parameters.Add("extStr", this.            extStr
);
                                                    }
    }
}





        
 

