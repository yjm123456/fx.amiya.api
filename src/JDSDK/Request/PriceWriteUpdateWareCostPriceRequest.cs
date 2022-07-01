using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PriceWriteUpdateWareCostPriceRequest : JdRequestBase<PriceWriteUpdateWareCostPriceResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                          public  		string
              costPrice
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.price.write.updateWareCostPrice";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                        parameters.Add("costPrice", this.            costPrice
);
                                                    }
    }
}





        
 

