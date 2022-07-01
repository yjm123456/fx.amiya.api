using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopLocBroadbandOrderFindDetailRequest : JdRequestBase<PopLocBroadbandOrderFindDetailResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
                                                                                      orderId
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.pop.loc.broadband.order.findDetail";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("order_id", this.                                                                                    orderId
);
                                                                            }
    }
}





        
 

