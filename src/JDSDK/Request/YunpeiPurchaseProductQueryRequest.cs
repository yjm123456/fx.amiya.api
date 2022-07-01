using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class YunpeiPurchaseProductQueryRequest : JdRequestBase<YunpeiPurchaseProductQueryResponse>
    {
                                                                                                                   public  		string
                                                                                                                      level2CategoryId
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      cityName
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      pageNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.yunpei.purchase.product.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("level2_category_id", this.                                                                                                                    level2CategoryId
);
                                                                                                        parameters.Add("city_name", this.                                                                                    cityName
);
                                                                                                        parameters.Add("page_no", this.                                                                                    pageNo
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                    }
    }
}





        
 

