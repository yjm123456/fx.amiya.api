using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SvcBookingVerificationInfoRequest : JdRequestBase<SvcBookingVerificationInfoResponse>
    {
                                                                                                                                              public  		string
              verificationCode
 {get; set;}
                                                          
                                                          public  		string
              lcnNo
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              appId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.svc.booking.verification.info";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("verificationCode", this.            verificationCode
);
                                                                                                        parameters.Add("lcnNo", this.            lcnNo
);
                                                                                                                                                        parameters.Add("appId", this.            appId
);
                                                                            }
    }
}





        
 

