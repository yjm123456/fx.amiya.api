using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspKcCampainDaybudgetUpdateRequest : JdRequestBase<DspKcCampainDaybudgetUpdateResponse>
    {
                                                                                                                                              public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              dayBudget
 {get; set;}
                                                          
                                                                                                                                                public override string ApiName
            {
                get{return "jingdong.dsp.kc.campain.daybudget.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("dayBudget", this.            dayBudget
);
                                                                                                                                                                                                                            }
    }
}





        
 

