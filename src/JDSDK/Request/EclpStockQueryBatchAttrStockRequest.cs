using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpStockQueryBatchAttrStockRequest : JdRequestBase<EclpStockQueryBatchAttrStockResponse>
    {
                                                                                                                                              public  		string
              cursor
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              stockType
 {get; set;}
                                                          
                                                          public  		string
              goodsLevel
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		string
              endTime
 {get; set;}
                                                          
                                                          public  		string
              sku
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              warehouseNo
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.stock.queryBatchAttrStock";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("cursor", this.            cursor
);
                                                                                                        parameters.Add("stockType", this.            stockType
);
                                                                                                        parameters.Add("goodsLevel", this.            goodsLevel
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("sku", this.            sku
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("warehouseNo", this.            warehouseNo
);
                                                                                                                            }
    }
}





        
 

