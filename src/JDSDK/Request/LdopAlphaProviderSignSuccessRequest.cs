using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAlphaProviderSignSuccessRequest : JdRequestBase<LdopAlphaProviderSignSuccessResponse>
    {
                                                                                  public  		string
              vendorCode
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.ldop.alpha.provider.sign.success";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("vendorCode", this.            vendorCode
);
                                                    }
    }
}





        
 

