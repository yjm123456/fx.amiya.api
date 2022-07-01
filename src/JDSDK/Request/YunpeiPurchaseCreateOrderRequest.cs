using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class YunpeiPurchaseCreateOrderRequest : JdRequestBase<YunpeiPurchaseCreateOrderResponse>
    {
                                                                                                                   public  		string
                                                                                      addressDetail
 {get; set;}
                                                                                                                                  
                                                          public  		string
              mobile
 {get; set;}
                                                          
                                                          public  		string
                                                                                      cityName
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      sellerRequestList
 {get; set;}
                                                                                                                                                          
            public override string ApiName
            {
                get{return "jingdong.yunpei.purchase.createOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("address_detail", this.                                                                                    addressDetail
);
                                                                                                        parameters.Add("mobile", this.            mobile
);
                                                                                                        parameters.Add("city_name", this.                                                                                    cityName
);
                                                                                                        parameters.Add("seller_request_list", this.                                                                                                                    sellerRequestList
);
                                                    }
    }
}





        
 

