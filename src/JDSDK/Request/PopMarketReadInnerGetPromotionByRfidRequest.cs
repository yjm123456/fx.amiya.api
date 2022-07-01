using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopMarketReadInnerGetPromotionByRfidRequest : JdRequestBase<PopMarketReadInnerGetPromotionByRfidResponse>
    {
                                                                                                                                                                               public  		string
              ip
 {get; set;}
                                                          
                                                                                           public  		string
              requestId
 {get; set;}
                                                          
                                                          public  		string
              port
 {get; set;}
                                                          
                                                                                                                                                                                              public  		Nullable<long>
              rfId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.pop.market.read.inner.getPromotionByRfid";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("ip", this.            ip
);
                                                                                                                                                        parameters.Add("requestId", this.            requestId
);
                                                                                                        parameters.Add("port", this.            port
);
                                                                                                                                                                                                                                                                                parameters.Add("rfId", this.            rfId
);
                                                    }
    }
}





        
 

