using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JwPurchaseStockQueryStockRequest : JdRequestBase<JwPurchaseStockQueryStockResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                		public  		string
  sku {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  num {get; set; }
                                                                                                                                                                                                                                                            public  		string
              addressLevel1Id
 {get; set;}
                                                          
                                                          public  		string
              addressLevel2Id
 {get; set;}
                                                          
                                                          public  		string
              addressLevel3Id
 {get; set;}
                                                          
                                                          public  		string
              addressLevel4Id
 {get; set;}
                                                          
                                                                                                                                                public override string ApiName
            {
                get{return "jingdong.jw.purchase.stock.queryStock";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                        parameters.Add("sku", this.            sku
);
                                                                                                        parameters.Add("num", this.            num
);
                                                                                                                                                                                                parameters.Add("addressLevel1Id", this.            addressLevel1Id
);
                                                                                                        parameters.Add("addressLevel2Id", this.            addressLevel2Id
);
                                                                                                        parameters.Add("addressLevel3Id", this.            addressLevel3Id
);
                                                                                                        parameters.Add("addressLevel4Id", this.            addressLevel4Id
);
                                                                                                                                                                                                    }
    }
}





        
 

