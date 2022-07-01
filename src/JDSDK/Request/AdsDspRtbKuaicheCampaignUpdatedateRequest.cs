using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKuaicheCampaignUpdatedateRequest : JdRequestBase<AdsDspRtbKuaicheCampaignUpdatedateResponse>
    {
                                                                                                                                              public  		Nullable<DateTime>
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.kuaiche.campaign.updatedate";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

