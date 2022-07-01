using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpBatchUpdateCampaignStatusRequest : JdRequestBase<AdsDspRtbTpBatchUpdateCampaignStatusResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  campaignIds {get; set; }
                                                                                                                                                                                                public  		string
              status
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.batchUpdateCampaignStatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("campaignIds", this.            campaignIds
);
                                                                                                                                parameters.Add("status", this.            status
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

