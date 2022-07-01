using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopSelfPickupSmsSendRequest : JdRequestBase<LdopSelfPickupSmsSendResponse>
    {
                                                                                                                                              public  		string
              waybillCode
 {get; set;}
                                                          
                                                          public  		string
              customerCode
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ldop.self.pickup.sms.send";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("waybillCode", this.            waybillCode
);
                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                                                                            }
    }
}





        
 

