using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UserRelatedRpcI18nServiceGetOpenIdRequest : JdRequestBase<UserRelatedRpcI18nServiceGetOpenIdResponse>
    {
                                                                                                                   public  		string
              pin
 {get; set;}
                                                          
                                                                                                                                          public override string ApiName
            {
                get{return "jingdong.UserRelatedRpcI18nService.getOpenId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("pin", this.            pin
);
                                                                                                                                                                    }
    }
}





        
 

