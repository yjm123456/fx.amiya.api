using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bProductStockGetRequest : JdRequestBase<B2bProductStockGetResponse>
    {
                                                                                  public  		string
              skuNums
 {get; set;}
                                                          
                                                          public  		string
              area
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.b2b.product.stock.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("skuNums", this.            skuNums
);
                                                                                                        parameters.Add("area", this.            area
);
                                                                                                    }
    }
}





        
 

