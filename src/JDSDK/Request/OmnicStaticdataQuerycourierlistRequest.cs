using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnicStaticdataQuerycourierlistRequest : JdRequestBase<OmnicStaticdataQuerycourierlistResponse>
    {
                                                                                                                                              public  		string
              authKey
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.omnic.staticdata.querycourierlist";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("authKey", this.            authKey
);
                                                                                                                                                                            }
    }
}





        
 

