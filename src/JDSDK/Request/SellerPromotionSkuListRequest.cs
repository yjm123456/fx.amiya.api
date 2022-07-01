using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerPromotionSkuListRequest : JdRequestBase<SellerPromotionSkuListResponse>
    {
                                                                                                                                              public  		Nullable<long>
                                                                                      wareId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      skuId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      promoId
 {get; set;}
                                                                                                                                  
                                                                                           public  		Nullable<int>
                                                                                      bindType
 {get; set;}
                                                                                                                                  
                                                                                           public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              size
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.seller.promotion.sku.list";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("ware_id", this.                                                                                    wareId
);
                                                                                                        parameters.Add("sku_id", this.                                                                                    skuId
);
                                                                                                        parameters.Add("promo_id", this.                                                                                    promoId
);
                                                                                                                                                        parameters.Add("bind_type", this.                                                                                    bindType
);
                                                                                                                                parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("size", this.            size
);
                                                    }
    }
}





        
 

