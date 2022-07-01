using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OrderStockoutRequest : JdRequestBase<OrderStockoutResponse>
    {
                                                                                                                                              public  		Nullable<int>
              venderId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              completeDate
 {get; set;}
                                                          
                                                          public  		string
              operName
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.orderStockout";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("venderId", this.            venderId
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("completeDate", this.            completeDate
);
                                                                                                        parameters.Add("operName", this.            operName
);
                                                                            }
    }
}





        
 

