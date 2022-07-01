using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerPromotionListRequest : JdRequestBase<SellerPromotionListResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              type
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                          public  		string
                                                                                      beginTime
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      endTime
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      skuId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      favorMode
 {get; set;}
                                                                                                                                  
                                                                                           public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              size
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.seller.promotion.list";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("begin_time", this.                                                                                    beginTime
);
                                                                                                        parameters.Add("end_time", this.                                                                                    endTime
);
                                                                                                        parameters.Add("sku_id", this.                                                                                    skuId
);
                                                                                                        parameters.Add("favor_mode", this.                                                                                    favorMode
);
                                                                                                                                parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("size", this.            size
);
                                                    }
    }
}





        
 

