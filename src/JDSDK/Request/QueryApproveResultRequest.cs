using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class QueryApproveResultRequest : JdRequestBase<QueryApproveResultResponse>
    {
                                                                                  public  		string
              approveParam
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.queryApproveResult";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("approveParam", this.            approveParam
);
                                                    }
    }
}





        
 

