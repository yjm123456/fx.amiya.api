using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKuaicheCampaignUpdateTimeRangePriceCoefRequest : JdRequestBase<AdsDspRtbKuaicheCampaignUpdateTimeRangePriceCoefResponse>
    {
                                                                                                                                              public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  		string
              timeRangePriceCoef
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.kuaiche.campaign.updateTimeRangePriceCoef";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("timeRangePriceCoef", this.            timeRangePriceCoef
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

