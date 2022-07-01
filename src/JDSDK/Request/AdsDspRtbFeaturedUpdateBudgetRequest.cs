using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbFeaturedUpdateBudgetRequest : JdRequestBase<AdsDspRtbFeaturedUpdateBudgetResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              dayBudget
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.featured.updateBudget";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("dayBudget", this.            dayBudget
);
                                                                                                        parameters.Add("id", this.            id
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

