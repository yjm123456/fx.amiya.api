using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKuaicheCampaignUpdatestatusRequest : JdRequestBase<AdsDspRtbKuaicheCampaignUpdatestatusResponse>
    {
                                                                                                                                              public  		Nullable<int>
              operateType
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  ids {get; set; }
                                                                                                                                                                                                                                                                                                                              public  		string
              businessFrom
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.kuaiche.campaign.updatestatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("operateType", this.            operateType
);
                                                                                                                                                parameters.Add("ids", this.            ids
);
                                                                                                                                                                                                                                                parameters.Add("businessFrom", this.            businessFrom
);
                                                                                                                                                                            }
    }
}





        
 

