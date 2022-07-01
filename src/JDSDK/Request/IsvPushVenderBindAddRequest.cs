using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class IsvPushVenderBindAddRequest : JdRequestBase<IsvPushVenderBindAddResponse>
    {
                                                                                                                   public  		string
              dbId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.isv.push.vender.bind.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("dbId", this.            dbId
);
                                                                                                                                                    }
    }
}





        
 

