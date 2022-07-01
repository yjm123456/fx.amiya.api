using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpStockQueryVmiShopStockRequest : JdRequestBase<EclpStockQueryVmiShopStockResponse>
    {
                                                                                                                                              public  		string
              goodsNos
 {get; set;}
                                                          
                                                          public  		string
              shopNos
 {get; set;}
                                                          
                                                          public  		string
              currentPage
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              warehouseNo
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.stock.queryVmiShopStock";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("goodsNos", this.            goodsNos
);
                                                                                                        parameters.Add("shopNos", this.            shopNos
);
                                                                                                        parameters.Add("currentPage", this.            currentPage
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("warehouseNo", this.            warehouseNo
);
                                                                                                                            }
    }
}





        
 

