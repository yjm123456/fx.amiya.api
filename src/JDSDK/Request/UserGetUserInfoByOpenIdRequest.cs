using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UserGetUserInfoByOpenIdRequest : JdRequestBase<UserGetUserInfoByOpenIdResponse>
    {
                                                                                                                   public  		string
              openId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.user.getUserInfoByOpenId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("openId", this.            openId
);
                                                                                                    }
    }
}





        
 

