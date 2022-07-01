using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LogisticsOtherOutstoreQueryRequest : JdRequestBase<LogisticsOtherOutstoreQueryResponse>
    {
                                                                                  public  		string
                                                                                                                      joslOutboundNo
 {get; set;}
                                                                                                                                                          
                                             public override string ApiName
            {
                get{return "jingdong.logistics.otherOutstore.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("josl_outbound_no", this.                                                                                                                    joslOutboundNo
);
                                                                                                    }
    }
}





        
 

