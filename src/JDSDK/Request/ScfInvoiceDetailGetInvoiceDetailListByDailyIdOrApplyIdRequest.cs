using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ScfInvoiceDetailGetInvoiceDetailListByDailyIdOrApplyIdRequest : JdRequestBase<ScfInvoiceDetailGetInvoiceDetailListByDailyIdOrApplyIdResponse>
    {
                                                                                                                                              public  		Nullable<long>
              applyId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              dailyId
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              pageNum
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.scf.invoice.detail.getInvoiceDetailListByDailyIdOrApplyId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("applyId", this.            applyId
);
                                                                                                        parameters.Add("dailyId", this.            dailyId
);
                                                                                                                                                        parameters.Add("pageNum", this.            pageNum
);
                                                                            }
    }
}





        
 

