using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOrderFbpGetRequest : JdRequestBase<PopOrderFbpGetResponse>
    {
                                                                                                                                                                               public  		string
              orderState
 {get; set;}
                                                          
                                                          public  		string
              colType
 {get; set;}
                                                          
                                                          public  		string
              optionalFields
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.order.fbp.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("orderState", this.            orderState
);
                                                                                                        parameters.Add("colType", this.            colType
);
                                                                                                        parameters.Add("optionalFields", this.            optionalFields
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                            }
    }
}





        
 

