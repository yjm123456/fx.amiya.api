using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpStockQueryStockRequest : JdRequestBase<EclpStockQueryStockResponse>
    {
                                                                                                                                              public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              warehouseNo
 {get; set;}
                                                          
                                                          public  		string
              stockStatus
 {get; set;}
                                                          
                                                          public  		string
              stockType
 {get; set;}
                                                          
                                                          public  		string
              goodsNo
 {get; set;}
                                                          
                                                          public  		string
              currentPage
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              returnZeroStock
 {get; set;}
                                                          
                                                          public  		string
              returnIsvLotattrs
 {get; set;}
                                                          
                                                          public  		string
              goodsLevel
 {get; set;}
                                                          
                                                          public  		string
              isvSku
 {get; set;}
                                                          
                                                          public  		string
              sellerGoodsSign
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.stock.queryStock";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("warehouseNo", this.            warehouseNo
);
                                                                                                        parameters.Add("stockStatus", this.            stockStatus
);
                                                                                                        parameters.Add("stockType", this.            stockType
);
                                                                                                        parameters.Add("goodsNo", this.            goodsNo
);
                                                                                                        parameters.Add("currentPage", this.            currentPage
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("returnZeroStock", this.            returnZeroStock
);
                                                                                                        parameters.Add("returnIsvLotattrs", this.            returnIsvLotattrs
);
                                                                                                        parameters.Add("goodsLevel", this.            goodsLevel
);
                                                                                                        parameters.Add("isvSku", this.            isvSku
);
                                                                                                        parameters.Add("sellerGoodsSign", this.            sellerGoodsSign
);
                                                                                                                            }
    }
}





        
 

