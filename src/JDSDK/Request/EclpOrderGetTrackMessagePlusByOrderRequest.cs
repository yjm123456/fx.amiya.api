using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpOrderGetTrackMessagePlusByOrderRequest : JdRequestBase<EclpOrderGetTrackMessagePlusByOrderResponse>
    {
                                                                                  public  		string
              customerCode
 {get; set;}
                                                          
                                                          public  		string
              bizCode
 {get; set;}
                                                          
                                                          public  		string
              type
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.eclp.order.getTrackMessagePlusByOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("customerCode", this.            customerCode
);
                                                                                                        parameters.Add("bizCode", this.            bizCode
);
                                                                                                        parameters.Add("type", this.            type
);
                                                    }
    }
}





        
 

