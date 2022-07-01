using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspCampainAddRequest : JdRequestBase<DspCampainAddResponse>
    {
                                                                                                                                              public  		string
              name
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
                                                          
                                                          public  		Nullable<long>
              dayBudget
 {get; set;}
                                                          
                                                                                                                                                             public  		Nullable<int>
              uniformSpeed
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.campain.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("timeRange", this.            timeRange
);
                                                                                                        parameters.Add("dayBudget", this.            dayBudget
);
                                                                                                                                                                                                                                                        parameters.Add("uniformSpeed", this.            uniformSpeed
);
                                                                            }
    }
}





        
 

