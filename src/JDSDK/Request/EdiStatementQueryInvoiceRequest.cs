using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiStatementQueryInvoiceRequest : JdRequestBase<EdiStatementQueryInvoiceResponse>
    {
                                                                                                                                                                               public  		string
              invoiceNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.edi.statement.queryInvoice";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("invoiceNo", this.            invoiceNo
);
                                                                            }
    }
}





        
 

