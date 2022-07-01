using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LogisticsOtherInstoreQueryRequest : JdRequestBase<LogisticsOtherInstoreQueryResponse>
    {
                                                                                  public  		string
                                                                                                                      inBoundNo
 {get; set;}
                                                                                                                                                          
                                             public override string ApiName
            {
                get{return "jingdong.logistics.otherInstore.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("in_bound_no", this.                                                                                                                    inBoundNo
);
                                                                                                    }
    }
}





        
 

