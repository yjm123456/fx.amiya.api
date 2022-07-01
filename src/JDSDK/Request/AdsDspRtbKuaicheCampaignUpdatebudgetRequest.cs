using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKuaicheCampaignUpdatebudgetRequest : JdRequestBase<AdsDspRtbKuaicheCampaignUpdatebudgetResponse>
    {
                                                                                                                                              public  		string
              dateRange
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              dayBudget
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.kuaiche.campaign.updatebudget";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("dateRange", this.            dateRange
);
                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("dayBudget", this.            dayBudget
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

