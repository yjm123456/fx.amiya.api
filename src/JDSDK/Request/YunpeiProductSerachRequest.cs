using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class YunpeiProductSerachRequest : JdRequestBase<YunpeiProductSerachResponse>
    {
                                                                                                                   public  		Nullable<int>
                                                                                      productId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      oeId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      popProductSn
 {get; set;}
                                                                                                                                                          
            public override string ApiName
            {
                get{return "jingdong.yunpei.product.serach";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("product_id", this.                                                                                    productId
);
                                                                                                        parameters.Add("oe_id", this.                                                                                    oeId
);
                                                                                                        parameters.Add("page_no", this.                                                                                    pageNo
);
                                                                                                        parameters.Add("pop_product_sn", this.                                                                                                                    popProductSn
);
                                                    }
    }
}





        
 

