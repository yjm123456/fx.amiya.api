using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOtoChecknumberinfoGetRequest : JdRequestBase<PopOtoChecknumberinfoGetResponse>
    {
                                                                                                                   public  		Nullable<long>
                                                                                      orderId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      cardNumber
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      pwdNumber
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.pop.oto.checknumberinfo.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("order_id", this.                                                                                    orderId
);
                                                                                                        parameters.Add("card_number", this.                                                                                    cardNumber
);
                                                                                                        parameters.Add("pwd_number", this.                                                                                    pwdNumber
);
                                                    }
    }
}





        
 

