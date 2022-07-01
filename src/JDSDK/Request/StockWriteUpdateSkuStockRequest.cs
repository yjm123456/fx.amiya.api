using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class StockWriteUpdateSkuStockRequest : JdRequestBase<StockWriteUpdateSkuStockResponse>
    {
                                                                                                                                                                                                                                                                                                                                              public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              stockNum
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.stock.write.updateSkuStock";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("stockNum", this.            stockNum
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                                            }
    }
}





        
 

