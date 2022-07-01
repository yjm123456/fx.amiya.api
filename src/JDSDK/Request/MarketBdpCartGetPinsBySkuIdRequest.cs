using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class MarketBdpCartGetPinsBySkuIdRequest : JdRequestBase<MarketBdpCartGetPinsBySkuIdResponse>
    {
                                                                                                                   public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                          public  		string
              days
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.market.bdp.cart.getPinsBySkuId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("days", this.            days
);
                                                    }
    }
}





        
 

