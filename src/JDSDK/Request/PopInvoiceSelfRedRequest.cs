using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopInvoiceSelfRedRequest : JdRequestBase<PopInvoiceSelfRedResponse>
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
                                                          
                                                          public  		string
              invoiceTime
 {get; set;}
                                                          
                                                          public  		string
              blueInvoiceCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              blueInvoiceNo
 {get; set;}
                                                          
                                                          public  		string
              pdfInfo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.invoice.self.red";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("invoiceCode", this.            invoiceCode
);
                                                                                                        parameters.Add("invoiceNo", this.            invoiceNo
);
                                                                                                        parameters.Add("invoiceTime", this.            invoiceTime
);
                                                                                                        parameters.Add("blueInvoiceCode", this.            blueInvoiceCode
);
                                                                                                        parameters.Add("blueInvoiceNo", this.            blueInvoiceNo
);
                                                                                                        parameters.Add("pdfInfo", this.            pdfInfo
);
                                                                            }
    }
}





        
 

