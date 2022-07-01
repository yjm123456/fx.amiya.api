using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OrderOrderDeleteApplyRequest : JdRequestBase<OrderOrderDeleteApplyResponse>
    {
                                                                                                                                                                                                                public  		string
                                                                                      orderId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      delApplyType
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                                                      delApplyReason
 {get; set;}
                                                                                                                                                          
                                             public override string ApiName
            {
                get{return "jingdong.order.orderDelete.apply";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("order_id", this.                                                                                    orderId
);
                                                                                                        parameters.Add("del_apply_type", this.                                                                                                                    delApplyType
);
                                                                                                        parameters.Add("del_apply_reason", this.                                                                                                                    delApplyReason
);
                                                                            }
    }
}





        
 

