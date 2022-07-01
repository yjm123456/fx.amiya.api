using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PriceWriteUpdateWareMarketPriceRequest : JdRequestBase<PriceWriteUpdateWareMarketPriceResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                          public  		string
              marketPrice
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.price.write.updateWareMarketPrice";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                        parameters.Add("marketPrice", this.            marketPrice
);
                                                    }
    }
}





        
 

