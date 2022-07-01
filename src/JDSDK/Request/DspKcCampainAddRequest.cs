using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspKcCampainAddRequest : JdRequestBase<DspKcCampainAddResponse>
    {
                                                                                                                                              public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              dayBudget
 {get; set;}
                                                          
                                                                                                                                                public override string ApiName
            {
                get{return "jingdong.dsp.kc.campain.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("dayBudget", this.            dayBudget
);
                                                                                                                                                                                                                            }
    }
}





        
 

