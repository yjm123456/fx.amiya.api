using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JosVoucherInfoGetRequest : JdRequestBase<JosVoucherInfoGetResponse>
    {
                                                                                                                                              public  		string
                                                                                      accessToken
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                                                      customerUserId
 {get; set;}
                                                                                                                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.jos.voucher.info.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("access_token", this.                                                                                    accessToken
);
                                                                                                        parameters.Add("customer_user_id", this.                                                                                                                    customerUserId
);
                                                                                                                            }
    }
}





        
 

