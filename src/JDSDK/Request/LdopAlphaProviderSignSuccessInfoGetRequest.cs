using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAlphaProviderSignSuccessInfoGetRequest : JdRequestBase<LdopAlphaProviderSignSuccessInfoGetResponse>
    {
                                                                                                                                              public  		string
              venderCode
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.ldop.alpha.provider.sign.success.info.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                                                                                            }
    }
}





        
 

