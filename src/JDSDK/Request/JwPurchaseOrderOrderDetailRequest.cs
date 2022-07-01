using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JwPurchaseOrderOrderDetailRequest : JdRequestBase<JwPurchaseOrderOrderDetailResponse>
    {
                                                                                                                                              public  		string
              orderCode
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.jw.purchase.order.orderDetail";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderCode", this.            orderCode
);
                                                                                                                                                                            }
    }
}





        
 

