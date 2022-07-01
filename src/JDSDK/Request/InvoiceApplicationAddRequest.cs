using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class InvoiceApplicationAddRequest : JdRequestBase<InvoiceApplicationAddResponse>
    {
                                                                                  public  		string
              invoiceApplication
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.invoice.application.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("invoiceApplication", this.            invoiceApplication
);
                                                    }
    }
}





        
 

