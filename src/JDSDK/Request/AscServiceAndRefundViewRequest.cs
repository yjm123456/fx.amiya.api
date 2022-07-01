using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscServiceAndRefundViewRequest : JdRequestBase<AscServiceAndRefundViewResponse>
    {
                                                                                                                                                                                                                                                 public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              applyTimeBegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              applyTimeEnd
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              approveTimeBegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              approveTimeEnd
 {get; set;}
                                                          
                                                                                                                      public  		string
              pageNumber
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                                                           public  		string
              extJsonStr
 {get; set;}
                                                          
                                                          public  		string
              buId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.serviceAndRefund.view";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("applyTimeBegin", this.            applyTimeBegin
);
                                                                                                        parameters.Add("applyTimeEnd", this.            applyTimeEnd
);
                                                                                                        parameters.Add("approveTimeBegin", this.            approveTimeBegin
);
                                                                                                        parameters.Add("approveTimeEnd", this.            approveTimeEnd
);
                                                                                                                                                parameters.Add("pageNumber", this.            pageNumber
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                                                        parameters.Add("buId", this.            buId
);
                                                                            }
    }
}





        
 

