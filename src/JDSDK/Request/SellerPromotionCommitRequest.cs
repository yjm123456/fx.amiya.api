using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerPromotionCommitRequest : JdRequestBase<SellerPromotionCommitResponse>
    {
                                                                                                                                              public  		Nullable<long>
                                                                                      promoId
 {get; set;}
                                                                                                                                  
                                                                              public override string ApiName
            {
                get{return "jingdong.seller.promotion.commit";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("promo_id", this.                                                                                    promoId
);
                                                                                                                            }
    }
}





        
 

