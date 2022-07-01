using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ScfInvoiceDailybillQueryDailyBillListRequest : JdRequestBase<ScfInvoiceDailybillQueryDailyBillListResponse>
    {
                                                                                                                                              public  		Nullable<long>
              applyId
 {get; set;}
                                                          
                                                          public  		string
              rfBillType
 {get; set;}
                                                          
                                                                                           public  		Nullable<DateTime>
              endDate
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              beginDate
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNum
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.scf.invoice.dailybill.queryDailyBillList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("applyId", this.            applyId
);
                                                                                                        parameters.Add("rfBillType", this.            rfBillType
);
                                                                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("beginDate", this.            beginDate
);
                                                                                                        parameters.Add("pageNum", this.            pageNum
);
                                                                            }
    }
}





        
 

