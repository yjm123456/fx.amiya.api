using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OrderTrackGetTrackShowResultRequest : JdRequestBase<OrderTrackGetTrackShowResultResponse>
    {
                                                                                                                                              public  		string
              userPin
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                                                                                                                                                                                                         public  		string
              userIP
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.order.track.getTrackShowResult";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("userPin", this.            userPin
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                                                                                                                                                                                                                parameters.Add("userIP", this.            userIP
);
                                                                                                    }
    }
}





        
 

