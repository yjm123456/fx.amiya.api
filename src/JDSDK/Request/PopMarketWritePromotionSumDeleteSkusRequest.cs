using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopMarketWritePromotionSumDeleteSkusRequest : JdRequestBase<PopMarketWritePromotionSumDeleteSkusResponse>
    {
                                                                                                                                                                               public  		string
              ip
 {get; set;}
                                                          
                                                                                                                            public  		string
              port
 {get; set;}
                                                          
                                                          public  		string
                                                                                      requestId
 {get; set;}
                                                                                                                                  
                                                                                                                                                                                                                         public  		Nullable<long>
              rfId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              promoId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  skuId {get; set; }
                                                                                                                                                                                                public  		string
              operator1
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.market.write.promotion.sum.deleteSkus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("ip", this.            ip
);
                                                                                                                                                                                                        parameters.Add("port", this.            port
);
                                                                                                        parameters.Add("request_id", this.                                                                                    requestId
);
                                                                                                                                                                                                                                                                        parameters.Add("rfId", this.            rfId
);
                                                                                                        parameters.Add("promoId", this.            promoId
);
                                                                                                                                                parameters.Add("skuId", this.            skuId
);
                                                                                                                                parameters.Add("operator1", this.            operator1
);
                                                                            }
    }
}





        
 

