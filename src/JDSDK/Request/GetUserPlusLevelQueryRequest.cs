using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class GetUserPlusLevelQueryRequest : JdRequestBase<GetUserPlusLevelQueryResponse>
    {
                                                                                                                                                    public  string              fields
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.getUserPlusLevel.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                parameters.Add("fields", this.            fields
);
                                                    }
    }
}





        
 

