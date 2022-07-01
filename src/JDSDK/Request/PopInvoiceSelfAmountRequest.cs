using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopInvoiceSelfAmountRequest : JdRequestBase<PopInvoiceSelfAmountResponse>
    {
                                                                                                                   public  		string
              orderId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.pop.invoice.self.amount";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("orderId", this.            orderId
);
                                                    }
    }
}





        
 

