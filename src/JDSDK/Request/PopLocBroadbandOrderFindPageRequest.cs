using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopLocBroadbandOrderFindPageRequest : JdRequestBase<PopLocBroadbandOrderFindPageResponse>
    {
                                                                                                                                                                               public  		string
                                                                                                                      orderCreatedBegin
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                                                      orderCreatedEnd
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
                                                                                      orderStatus
 {get; set;}
                                                                                                                                  
                                                                                           public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.pop.loc.broadband.order.findPage";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("order_created_begin", this.                                                                                                                    orderCreatedBegin
);
                                                                                                        parameters.Add("order_created_end", this.                                                                                                                    orderCreatedEnd
);
                                                                                                        parameters.Add("order_status", this.                                                                                    orderStatus
);
                                                                                                                                parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                    }
    }
}





        
 

