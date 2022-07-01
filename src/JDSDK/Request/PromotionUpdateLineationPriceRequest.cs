using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PromotionUpdateLineationPriceRequest : JdRequestBase<PromotionUpdateLineationPriceResponse>
    {
                                                                                  public  		string
              skuId
 {get; set;}
                                                          
                                                          public  		string
              lineationPrice
 {get; set;}
                                                          
                                                                                           public  		string
              applicant
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.promotion.updateLineationPrice";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("lineationPrice", this.            lineationPrice
);
                                                                                                                                                        parameters.Add("applicant", this.            applicant
);
                                                    }
    }
}





        
 

