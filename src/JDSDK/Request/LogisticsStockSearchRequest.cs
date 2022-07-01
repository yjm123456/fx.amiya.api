using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LogisticsStockSearchRequest : JdRequestBase<LogisticsStockSearchResponse>
    {
                                                                                  public  		string
                                                                                      warehouseNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      goodsNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      currentPage
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.logistics.stock.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("warehouse_no", this.                                                                                    warehouseNo
);
                                                                                                        parameters.Add("goods_no", this.                                                                                    goodsNo
);
                                                                                                        parameters.Add("current_page", this.                                                                                    currentPage
);
                                                                                                    }
    }
}





        
 

