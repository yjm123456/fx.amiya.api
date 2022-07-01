using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EerdcActivityGatewayApiActivityexternaloperationRequest : JdRequestBase<EerdcActivityGatewayApiActivityexternaloperationResponse>
    {
                                                                                                                                                    public  		Nullable<int>
              operType
 {get; set;}
                                                          
                                                          public  		string
              jsonData
 {get; set;}
                                                          
                                                          public  		string
              extStr
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.eerdc.activity.gateway.api.activityexternaloperation";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                parameters.Add("operType", this.            operType
);
                                                                                                        parameters.Add("jsonData", this.            jsonData
);
                                                                                                        parameters.Add("extStr", this.            extStr
);
                                                    }
    }
}





        
 

