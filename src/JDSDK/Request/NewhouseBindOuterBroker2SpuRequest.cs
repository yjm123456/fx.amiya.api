using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NewhouseBindOuterBroker2SpuRequest : JdRequestBase<NewhouseBindOuterBroker2SpuResponse>
    {
                                                                                  public  		string
              paramInfo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.newhouse.bindOuterBroker2Spu";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("paramInfo", this.            paramInfo
);
                                                                                                    }
    }
}





        
 

