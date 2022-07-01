using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerPromotionV2GetPromoLimitRequest : JdRequestBase<SellerPromotionV2GetPromoLimitResponse>
    {
                                                                                                                                                                                                                public  		string
              ip
 {get; set;}
                                                          
                                                          public  		string
              port
 {get; set;}
                                                          
                                                                                                                                                                                                                         public  		Nullable<long>
                                                                                      categoryId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                      startTime
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                      endTime
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.seller.promotion.v2.getPromoLimit";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("ip", this.            ip
);
                                                                                                        parameters.Add("port", this.            port
);
                                                                                                                                                                                                                                                                        parameters.Add("category_id", this.                                                                                    categoryId
);
                                                                                                        parameters.Add("start_time", this.                                                                                    startTime
);
                                                                                                        parameters.Add("end_time", this.                                                                                    endTime
);
                                                                            }
    }
}





        
 

