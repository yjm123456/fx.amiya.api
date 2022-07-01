using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOrderShipmentRequest : JdRequestBase<PopOrderShipmentResponse>
    {
                                                                                                                                                                               public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              logiCoprId
 {get; set;}
                                                          
                                                          public  		string
              logiNo
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              installId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.order.shipment";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("logiCoprId", this.            logiCoprId
);
                                                                                                        parameters.Add("logiNo", this.            logiNo
);
                                                                                                        parameters.Add("installId", this.            installId
);
                                                                            }
    }
}





        
 

