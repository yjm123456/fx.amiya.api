using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerPromotionSkuAddRequest : JdRequestBase<SellerPromotionSkuAddResponse>
    {
                                                                                                                                                                                                                      		public  		Nullable<long>
  promoId {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  skuIds {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  jdPrices {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  promoPrices {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  seq {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  num {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  bindType {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.seller.promotion.sku.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                    parameters.Add("promo_id", this.                                                                                    promoId
);
                                                                                                        parameters.Add("sku_ids", this.                                                                                    skuIds
);
                                                                                                        parameters.Add("jd_prices", this.                                                                                    jdPrices
);
                                                                                                        parameters.Add("promo_prices", this.                                                                                    promoPrices
);
                                                                                                        parameters.Add("seq", this.            seq
);
                                                                                                        parameters.Add("num", this.            num
);
                                                                                                        parameters.Add("bind_type", this.                                                                                    bindType
);
                                                                                                                                                    }
    }
}





        
 

