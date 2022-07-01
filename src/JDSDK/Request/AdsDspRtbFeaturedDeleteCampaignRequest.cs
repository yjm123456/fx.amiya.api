using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbFeaturedDeleteCampaignRequest : JdRequestBase<AdsDspRtbFeaturedDeleteCampaignResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  ids {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                    public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.featured.deleteCampaign";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("ids", this.            ids
);
                                                                                                                                                                                                                                                                                                                                                                    }
    }
}





        
 

