using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerPromotionActivitymodeAddRequest : JdRequestBase<SellerPromotionActivitymodeAddResponse>
    {
                                                                                                                                              public  		Nullable<long>
                                                                                      promoId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      numBound
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      freqBound
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                                                      perMaxNum
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
                                                                                                                      perMinNum
 {get; set;}
                                                                                                                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.seller.promotion.activitymode.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("promo_id", this.                                                                                    promoId
);
                                                                                                        parameters.Add("num_bound", this.                                                                                    numBound
);
                                                                                                        parameters.Add("freq_bound", this.                                                                                    freqBound
);
                                                                                                        parameters.Add("per_max_num", this.                                                                                                                    perMaxNum
);
                                                                                                        parameters.Add("per_min_num", this.                                                                                                                    perMinNum
);
                                                                                                                            }
    }
}





        
 

