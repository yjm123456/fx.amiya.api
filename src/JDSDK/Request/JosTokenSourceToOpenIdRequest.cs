using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JosTokenSourceToOpenIdRequest : JdRequestBase<JosTokenSourceToOpenIdResponse>
    {
                                                                                                                                              public  		string
              token
 {get; set;}
                                                          
                                                          public  		string
              source
 {get; set;}
                                                          
                                                          public  		string
              appKey
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.jos.token.source.to.openId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("token", this.            token
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                        parameters.Add("appKey", this.            appKey
);
                                                                            }
    }
}





        
 

