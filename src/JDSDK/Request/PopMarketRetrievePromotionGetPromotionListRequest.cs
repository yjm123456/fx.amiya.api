using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopMarketRetrievePromotionGetPromotionListRequest : JdRequestBase<PopMarketRetrievePromotionGetPromotionListResponse>
    {
                                                                                                                                                                                                                public  		string
              ip
 {get; set;}
                                                          
                                                          public  		string
                                                                                      requestId
 {get; set;}
                                                                                                                                  
                                                          public  		string
              port
 {get; set;}
                                                          
                                                                                                                                                                                                                                                          public  		Nullable<int>
              promoStatus
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                          public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.market.retrieve.promotion.getPromotionList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("ip", this.            ip
);
                                                                                                        parameters.Add("request_id", this.                                                                                    requestId
);
                                                                                                        parameters.Add("port", this.            port
);
                                                                                                                                                                                                                                                                                                                        parameters.Add("promoStatus", this.            promoStatus
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                            }
    }
}





        
 

