using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class MedicineDsOrderGetOrderRequest : JdRequestBase<MedicineDsOrderGetOrderResponse>
    {
                                                                                                                                              public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              clientIp
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.medicine.ds.order.getOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("clientIp", this.            clientIp
);
                                                                                                                            }
    }
}





        
 

