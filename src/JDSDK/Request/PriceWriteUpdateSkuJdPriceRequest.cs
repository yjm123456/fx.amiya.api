using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PriceWriteUpdateSkuJdPriceRequest : JdRequestBase<PriceWriteUpdateSkuJdPriceResponse>
    {
                                                                                                                                                                                                                                                                                                                                              public  		string
              jdPrice
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.price.write.updateSkuJdPrice";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                        parameters.Add("jdPrice", this.            jdPrice
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                                            }
    }
}





        
 

