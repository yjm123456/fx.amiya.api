using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOrderNotPayOrderByIdRequest : JdRequestBase<PopOrderNotPayOrderByIdResponse>
    {
                                                                                                                   public  		string
              orderId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.pop.order.notPayOrderById";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("orderId", this.            orderId
);
                                                    }
    }
}





        
 

