using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopJmCenterUserGetOpenIdRequest : JdRequestBase<PopJmCenterUserGetOpenIdResponse>
    {
                                                                                                                                                                               public  		string
              source
 {get; set;}
                                                          
                                                          public  		string
              token
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.pop.jm.center.user.getOpenId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("source", this.            source
);
                                                                                                        parameters.Add("token", this.            token
);
                                                                                                                            }
    }
}





        
 

