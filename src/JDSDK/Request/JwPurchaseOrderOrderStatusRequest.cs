using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JwPurchaseOrderOrderStatusRequest : JdRequestBase<JwPurchaseOrderOrderStatusResponse>
    {
                                                                                                                                                                          public  		string
              orderCodes
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.jw.purchase.order.orderStatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderCodes", this.            orderCodes
);
                                                                                                                                                                            }
    }
}





        
 

