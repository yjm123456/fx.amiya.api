using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class MfaInnerUserUnifiedAuthenticationRequest : JdRequestBase<MfaInnerUserUnifiedAuthenticationResponse>
    {
                                                                                                                                              public  		string
              deviceOSType
 {get; set;}
                                                          
                                                          public  		string
              appId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              businessType
 {get; set;}
                                                          
                                                          public  		string
              eid
 {get; set;}
                                                          
                                                          public  		string
              openUDID
 {get; set;}
                                                          
                                                          public  		string
              source
 {get; set;}
                                                          
                                                          public  		string
              deviceName
 {get; set;}
                                                          
                                                          public  		string
              email
 {get; set;}
                                                          
                                                          public  		string
              deviceOSVersion
 {get; set;}
                                                          
                                                          public  		string
              pin
 {get; set;}
                                                          
                                                          public  		string
              appVersion
 {get; set;}
                                                          
                                                          public  		string
              loginChannel
 {get; set;}
                                                          
                                                          public  		string
              authType
 {get; set;}
                                                          
                                                          public  		string
              clientIp
 {get; set;}
                                                          
                                                          public  		string
              uuid
 {get; set;}
                                                          
                                                          public  		string
              mobile
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.mfa.inner.userUnifiedAuthentication";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deviceOSType", this.            deviceOSType
);
                                                                                                        parameters.Add("appId", this.            appId
);
                                                                                                        parameters.Add("businessType", this.            businessType
);
                                                                                                        parameters.Add("eid", this.            eid
);
                                                                                                        parameters.Add("openUDID", this.            openUDID
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                        parameters.Add("deviceName", this.            deviceName
);
                                                                                                        parameters.Add("email", this.            email
);
                                                                                                        parameters.Add("deviceOSVersion", this.            deviceOSVersion
);
                                                                                                        parameters.Add("pin", this.            pin
);
                                                                                                        parameters.Add("appVersion", this.            appVersion
);
                                                                                                        parameters.Add("loginChannel", this.            loginChannel
);
                                                                                                        parameters.Add("authType", this.            authType
);
                                                                                                        parameters.Add("clientIp", this.            clientIp
);
                                                                                                        parameters.Add("uuid", this.            uuid
);
                                                                                                        parameters.Add("mobile", this.            mobile
);
                                                                            }
    }
}





        
 

