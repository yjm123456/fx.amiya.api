using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopMarketWritePromotionGiftApproveRequest : JdRequestBase<PopMarketWritePromotionGiftApproveResponse>
    {
                                                                                                                                                                                                                public  		string
              ip
 {get; set;}
                                                          
                                                          public  		string
              port
 {get; set;}
                                                          
                                                          public  		string
                                                                                      requestId
 {get; set;}
                                                                                                                                  
                                                                                                                                                             public  		Nullable<long>
              promoId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.market.write.promotion.gift.approve";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("ip", this.            ip
);
                                                                                                        parameters.Add("port", this.            port
);
                                                                                                        parameters.Add("request_id", this.                                                                                    requestId
);
                                                                                                                                                                                                                                parameters.Add("promoId", this.            promoId
);
                                                                                                    }
    }
}





        
 

