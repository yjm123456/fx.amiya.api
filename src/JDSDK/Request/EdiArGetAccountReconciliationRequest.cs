using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiArGetAccountReconciliationRequest : JdRequestBase<EdiArGetAccountReconciliationResponse>
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
                get{return "jingdong.edi.ar.getAccountReconciliation";}
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





        
 

