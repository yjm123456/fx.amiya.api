using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspKcCampainValiddateUpdateRequest : JdRequestBase<DspKcCampainValiddateUpdateResponse>
    {
                                                                                                                                              public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
                                                                                           public  		string
              timeRange
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.dsp.kc.campain.validdate.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                                                                        parameters.Add("timeRange", this.            timeRange
);
                                                                                                                                                                            }
    }
}





        
 

