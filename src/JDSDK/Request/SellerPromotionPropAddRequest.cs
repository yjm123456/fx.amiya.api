using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerPromotionPropAddRequest : JdRequestBase<SellerPromotionPropAddResponse>
    {
                                                                                                                                                                                                                      		public  		Nullable<long>
  promoId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  type {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  num {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  usedWay {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.seller.promotion.prop.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                    parameters.Add("promo_id", this.                                                                                    promoId
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("num", this.            num
);
                                                                                                        parameters.Add("used_way", this.                                                                                    usedWay
);
                                                                                                                                                    }
    }
}





        
 

