using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ScIsJdStudentRequest : JdRequestBase<ScIsJdStudentResponse>
    {
                                                                                                                   public  		string
              mobile
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.sc.isJdStudent";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("mobile", this.            mobile
);
                                                    }
    }
}





        
 

