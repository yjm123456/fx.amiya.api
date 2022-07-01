using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerPromotionV2SkuListRequest : JdRequestBase<SellerPromotionV2SkuListResponse>
    {
                                                                                                                                                                                                                public  		string
              ip
 {get; set;}
                                                          
                                                          public  		string
              port
 {get; set;}
                                                          
                                                                                                                                                                                        public  		Nullable<long>
                                                                                      promoId
 {get; set;}
                                                                                                                                  
                                                                                           public  		Nullable<long>
                                                                                      wareId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      skuId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      bindType
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      promoType
 {get; set;}
                                                                                                                                  
                                                          public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
                                                                                      pageSSize
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.seller.promotion.v2.sku.list";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("ip", this.            ip
);
                                                                                                        parameters.Add("port", this.            port
);
                                                                                                                                                                                                                        parameters.Add("promo_id", this.                                                                                    promoId
);
                                                                                                                                                        parameters.Add("ware_id", this.                                                                                    wareId
);
                                                                                                        parameters.Add("sku_id", this.                                                                                    skuId
);
                                                                                                        parameters.Add("bind_type", this.                                                                                    bindType
);
                                                                                                        parameters.Add("promo_type", this.                                                                                    promoType
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageS_size", this.                                                                                    pageSSize
);
                                                                            }
    }
}





        
 

