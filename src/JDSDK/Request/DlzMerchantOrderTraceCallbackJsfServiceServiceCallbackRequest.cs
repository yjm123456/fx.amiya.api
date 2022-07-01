using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DlzMerchantOrderTraceCallbackJsfServiceServiceCallbackRequest : JdRequestBase<DlzMerchantOrderTraceCallbackJsfServiceServiceCallbackResponse>
    {
                                                                                                                                              public  		string
              customsId
 {get; set;}
                                                          
                                                          public  		string
              serviceId
 {get; set;}
                                                          
                                                                                                                                                                                        public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              platformId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              methodType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              operateType
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              operateTime
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.DlzMerchantOrderTraceCallbackJsfService.serviceCallback";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("customsId", this.            customsId
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("platformId", this.            platformId
);
                                                                                                        parameters.Add("methodType", this.            methodType
);
                                                                                                        parameters.Add("operateType", this.            operateType
);
                                                                                                        parameters.Add("operateTime", this.            operateTime
);
                                                                            }
    }
}





        
 

