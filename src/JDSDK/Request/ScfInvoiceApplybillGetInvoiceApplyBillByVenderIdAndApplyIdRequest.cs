using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ScfInvoiceApplybillGetInvoiceApplyBillByVenderIdAndApplyIdRequest : JdRequestBase<ScfInvoiceApplybillGetInvoiceApplyBillByVenderIdAndApplyIdResponse>
    {
                                                                                                                   public  		Nullable<long>
              applyId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.scf.invoice.applybill.getInvoiceApplyBillByVenderIdAndApplyId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("applyId", this.            applyId
);
                                                    }
    }
}





        
 

