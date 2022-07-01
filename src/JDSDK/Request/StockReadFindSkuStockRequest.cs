using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class StockReadFindSkuStockRequest : JdRequestBase<StockReadFindSkuStockResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              skuId
 {get; set;}
                                                          
                                                                                      public  		string
              field
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.stock.read.findSkuStock";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("field", this.            field
);
                                                    }
    }
}





        
 

