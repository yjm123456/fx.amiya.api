using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbFeaturedBindMaterialRequest : JdRequestBase<AdsDspRtbFeaturedBindMaterialResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  materialIds {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  adGroupIds {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                     public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.featured.bindMaterial";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("materialIds", this.            materialIds
);
                                                                                                                                                                        parameters.Add("adGroupIds", this.            adGroupIds
);
                                                                                                                                                                                                                                                                                                                                                                                                                    }
    }
}





        
 

