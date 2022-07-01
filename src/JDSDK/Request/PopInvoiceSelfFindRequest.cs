using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopInvoiceSelfFindRequest : JdRequestBase<PopInvoiceSelfFindResponse>
    {
                                                                                                                                                                               public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              invoiceCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              invoiceNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.invoice.self.find";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("invoiceCode", this.            invoiceCode
);
                                                                                                        parameters.Add("invoiceNo", this.            invoiceNo
);
                                                                            }
    }
}





        
 

