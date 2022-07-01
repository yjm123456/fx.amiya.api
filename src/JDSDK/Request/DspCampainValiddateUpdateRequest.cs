using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspCampainValiddateUpdateRequest : JdRequestBase<DspCampainValiddateUpdateResponse>
    {
                                                                                                                                              public  		Nullable<long>
              id
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
                get{return "jingdong.dsp.campain.validdate.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("id", this.            id
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





        
 

