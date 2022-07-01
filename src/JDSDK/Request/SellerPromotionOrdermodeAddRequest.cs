using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerPromotionOrdermodeAddRequest : JdRequestBase<SellerPromotionOrdermodeAddResponse>
    {
                                                                                                                                                                                                                      		public  		Nullable<long>
  promoId {get; set; }
                                                                                                                                                           		public  		Nullable<int>
  favorMode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  quota {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  rate {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  plus {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  minus {get; set; }
                                                                                                                                                           		public  		string
  link {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  freePostage {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.seller.promotion.ordermode.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                    parameters.Add("promo_id", this.                                                                                    promoId
);
                                                                                                                            parameters.Add("favor_mode", this.                                                                                    favorMode
);
                                                                                                        parameters.Add("quota", this.            quota
);
                                                                                                        parameters.Add("rate", this.            rate
);
                                                                                                        parameters.Add("plus", this.            plus
);
                                                                                                        parameters.Add("minus", this.            minus
);
                                                                                                                            parameters.Add("link", this.            link
);
                                                                                                        parameters.Add("free_postage", this.                                                                                    freePostage
);
                                                                                                                                                    }
    }
}





        
 

