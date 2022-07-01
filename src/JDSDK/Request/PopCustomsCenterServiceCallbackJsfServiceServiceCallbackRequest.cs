using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopCustomsCenterServiceCallbackJsfServiceServiceCallbackRequest : JdRequestBase<PopCustomsCenterServiceCallbackJsfServiceServiceCallbackResponse>
    {
                                                                                                                                              public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		string
              serviceId
 {get; set;}
                                                          
                                                          public  		string
              customsId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderStatus
 {get; set;}
                                                          
                                                          public  		string
              orderDesc
 {get; set;}
                                                          
                                                                                           public  		string
              goodsCheck
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.customs.center.ServiceCallbackJsfService.serviceCallback";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("customsId", this.            customsId
);
                                                                                                        parameters.Add("orderStatus", this.            orderStatus
);
                                                                                                        parameters.Add("orderDesc", this.            orderDesc
);
                                                                                                                                                        parameters.Add("goodsCheck", this.            goodsCheck
);
                                                                            }
    }
}





        
 

