using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpBatchDeleteCampaignRequest : JdRequestBase<AdsDspRtbTpBatchDeleteCampaignResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  campaignIds {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                    public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.batchDeleteCampaign";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("campaignIds", this.            campaignIds
);
                                                                                                                                                                                                                                                                                                                                                                    }
    }
}





        
 

