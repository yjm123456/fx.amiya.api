using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderQueryChangeBookDateOrderRequest : JdRequestBase<UeOrderQueryChangeBookDateOrderResponse>
    {
                                                                                                                                              public  		string
              appId
 {get; set;}
                                                          
                                                          public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.queryChangeBookDateOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("appId", this.            appId
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                            }
    }
}





        
 

