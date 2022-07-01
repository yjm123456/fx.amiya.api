using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopAfsRefundapplyQuerylistRequest : JdRequestBase<PopAfsRefundapplyQuerylistResponse>
    {
                                                                                                                                                                               public  		string
              status
 {get; set;}
                                                          
                                                          public  		string
              id
 {get; set;}
                                                          
                                                          public  		string
                                                                                      orderId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      buyerId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      buyerName
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      applyTimeStart
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                                                      applyTimeEnd
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                                                      checkTimeStart
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                                                      checkTimeEnd
 {get; set;}
                                                                                                                                                          
                                                                                           public  		Nullable<int>
                                                                                      pageIndex
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.pop.afs.refundapply.querylist";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("order_id", this.                                                                                    orderId
);
                                                                                                        parameters.Add("buyer_id", this.                                                                                    buyerId
);
                                                                                                        parameters.Add("buyer_name", this.                                                                                    buyerName
);
                                                                                                        parameters.Add("apply_time_start", this.                                                                                                                    applyTimeStart
);
                                                                                                        parameters.Add("apply_time_end", this.                                                                                                                    applyTimeEnd
);
                                                                                                        parameters.Add("check_time_start", this.                                                                                                                    checkTimeStart
);
                                                                                                        parameters.Add("check_time_end", this.                                                                                                                    checkTimeEnd
);
                                                                                                                                parameters.Add("page_index", this.                                                                                    pageIndex
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                    }
    }
}





        
 

