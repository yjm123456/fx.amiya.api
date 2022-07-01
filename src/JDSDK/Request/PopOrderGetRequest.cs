using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOrderGetRequest : JdRequestBase<PopOrderGetResponse>
    {
                                                                                                                                                                               public  		string
                                                                                      orderState
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      optionalFields
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      orderId
 {get; set;}
                                                                                                                                  
                                                                              public override string ApiName
            {
                get{return "jingdong.pop.order.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("order_state", this.                                                                                    orderState
);
                                                                                                        parameters.Add("optional_fields", this.                                                                                    optionalFields
);
                                                                                                        parameters.Add("order_id", this.                                                                                    orderId
);
                                                                                                                            }
    }
}





        
 

