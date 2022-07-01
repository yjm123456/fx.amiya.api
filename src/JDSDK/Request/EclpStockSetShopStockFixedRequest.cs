using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpStockSetShopStockFixedRequest : JdRequestBase<EclpStockSetShopStockFixedResponse>
    {
                                                                                                                                              public  		string
              requestId
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              shopNo
 {get; set;}
                                                          
                                                          public  		string
              warehouseNo
 {get; set;}
                                                          
                                                          public  		string
              stockNum
 {get; set;}
                                                          
                                                          public  		string
              goodsNo
 {get; set;}
                                                          
                                                          public  		string
              shopType
 {get; set;}
                                                          
                                                          public  		string
              opUser
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.stock.setShopStockFixed";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("requestId", this.            requestId
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("shopNo", this.            shopNo
);
                                                                                                        parameters.Add("warehouseNo", this.            warehouseNo
);
                                                                                                        parameters.Add("stockNum", this.            stockNum
);
                                                                                                        parameters.Add("goodsNo", this.            goodsNo
);
                                                                                                        parameters.Add("shopType", this.            shopType
);
                                                                                                        parameters.Add("opUser", this.            opUser
);
                                                                                                                            }
    }
}





        
 

