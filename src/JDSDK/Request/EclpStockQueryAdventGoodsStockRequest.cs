using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpStockQueryAdventGoodsStockRequest : JdRequestBase<EclpStockQueryAdventGoodsStockResponse>
    {
                                                                                                                                              public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              warehouseNos
 {get; set;}
                                                          
                                                          public  		string
              goodsNos
 {get; set;}
                                                          
                                                          public  		string
              currentPage
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.stock.queryAdventGoodsStock";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("warehouseNos", this.            warehouseNos
);
                                                                                                        parameters.Add("goodsNos", this.            goodsNos
);
                                                                                                        parameters.Add("currentPage", this.            currentPage
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                            }
    }
}





        
 

