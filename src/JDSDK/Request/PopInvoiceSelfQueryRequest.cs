using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopInvoiceSelfQueryRequest : JdRequestBase<PopInvoiceSelfQueryResponse>
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
                                                          
                                                          public  		Nullable<int>
              invoiceType
 {get; set;}
                                                          
                                                          public  		string
              invoiceTimeStart
 {get; set;}
                                                          
                                                          public  		string
              invoiceTimeEnd
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              pageCurrent
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.invoice.self.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("invoiceCode", this.            invoiceCode
);
                                                                                                        parameters.Add("invoiceNo", this.            invoiceNo
);
                                                                                                        parameters.Add("invoiceType", this.            invoiceType
);
                                                                                                        parameters.Add("invoiceTimeStart", this.            invoiceTimeStart
);
                                                                                                        parameters.Add("invoiceTimeEnd", this.            invoiceTimeEnd
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("pageCurrent", this.            pageCurrent
);
                                                                            }
    }
}





        
 

