using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkcunitTcpaStatusUpdateRequest : JdRequestBase<DspAdkcunitTcpaStatusUpdateResponse>
    {
                                                                                                                   public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                          public  		string
              tcpaBidStr
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              automatedBiddingType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.adkcunit.tcpa.status.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                        parameters.Add("tcpaBidStr", this.            tcpaBidStr
);
                                                                                                        parameters.Add("automatedBiddingType", this.            automatedBiddingType
);
                                                                                                    }
    }
}





        
 

