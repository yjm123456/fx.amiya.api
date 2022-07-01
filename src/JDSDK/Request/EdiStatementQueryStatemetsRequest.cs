using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiStatementQueryStatemetsRequest : JdRequestBase<EdiStatementQueryStatemetsResponse>
    {
                                                                                                                                              public  		Nullable<DateTime>
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
                                                                                           public  		string
              vendorCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.edi.statement.queryStatemets";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                            }
    }
}





        
 

