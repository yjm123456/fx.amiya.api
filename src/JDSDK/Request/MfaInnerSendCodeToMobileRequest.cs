using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class MfaInnerSendCodeToMobileRequest : JdRequestBase<MfaInnerSendCodeToMobileResponse>
    {
                                                                                  public  		string
              rKey
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              validateType
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.mfa.inner.sendCodeToMobile";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("rKey", this.            rKey
);
                                                                                                        parameters.Add("validateType", this.            validateType
);
                                                    }
    }
}





        
 

