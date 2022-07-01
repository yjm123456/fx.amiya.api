using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class StockReadFindSkuSiteStockRequest : JdRequestBase<StockReadFindSkuSiteStockResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                               public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              siteId
 {get; set;}
                                                          
                                                          public  		string
              venderSource
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              stockNum
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderBookingNum
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              appBookingNum
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              canUsedNum
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.stock.read.findSkuSiteStock";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("siteId", this.            siteId
);
                                                                                                        parameters.Add("venderSource", this.            venderSource
);
                                                                                                        parameters.Add("stockNum", this.            stockNum
);
                                                                                                        parameters.Add("orderBookingNum", this.            orderBookingNum
);
                                                                                                        parameters.Add("appBookingNum", this.            appBookingNum
);
                                                                                                        parameters.Add("canUsedNum", this.            canUsedNum
);
                                                                            }
    }
}





        
 

