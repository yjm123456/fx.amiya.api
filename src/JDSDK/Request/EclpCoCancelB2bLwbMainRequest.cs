using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpCoCancelB2bLwbMainRequest : JdRequestBase<EclpCoCancelB2bLwbMainResponse>
    {
                                                                                  public  		string
              deptNo
 {get; set;}
                                                          
                                                                                           public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              wbNo
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.eclp.co.cancelB2bLwbMain";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("deptNo", this.            deptNo
);
                                                                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("wbNo", this.            wbNo
);
                                                    }
    }
}





        
 

