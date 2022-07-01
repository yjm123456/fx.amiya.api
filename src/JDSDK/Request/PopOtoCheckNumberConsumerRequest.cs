using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOtoCheckNumberConsumerRequest : JdRequestBase<PopOtoCheckNumberConsumerResponse>
    {
                                                                                                                   public  		Nullable<long>
                                                                                      orderId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      cardNumber
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      pwdUmber
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      shopId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      shopName
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      codeType
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.pop.oto.CheckNumber.consumer";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("order_id", this.                                                                                    orderId
);
                                                                                                        parameters.Add("card_number", this.                                                                                    cardNumber
);
                                                                                                        parameters.Add("pwd_umber", this.                                                                                    pwdUmber
);
                                                                                                        parameters.Add("shop_id", this.                                                                                    shopId
);
                                                                                                        parameters.Add("shop_name", this.                                                                                    shopName
);
                                                                                                        parameters.Add("code_type", this.                                                                                    codeType
);
                                                    }
    }
}





        
 

