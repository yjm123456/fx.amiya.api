using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKuaicheCampaignAddRequest : JdRequestBase<AdsDspRtbKuaicheCampaignAddResponse>
    {
                                                                                                                                              public  		Nullable<int>
              putType
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              dayBudget
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              campaignType
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                               public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.kuaiche.campaign.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("putType", this.            putType
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("dayBudget", this.            dayBudget
);
                                                                                                        parameters.Add("campaignType", this.            campaignType
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

