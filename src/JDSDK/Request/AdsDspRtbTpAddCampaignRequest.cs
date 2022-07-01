using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpAddCampaignRequest : JdRequestBase<AdsDspRtbTpAddCampaignResponse>
    {
                                                                                                                                              public  		Nullable<int>
              putType
 {get; set;}
                                                          
                                                                                                                            public  		string
              billingType
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              dayBudget
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              campaignType
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.addCampaign";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("putType", this.            putType
);
                                                                                                                                                                                                        parameters.Add("billingType", this.            billingType
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("dayBudget", this.            dayBudget
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("campaignType", this.            campaignType
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

