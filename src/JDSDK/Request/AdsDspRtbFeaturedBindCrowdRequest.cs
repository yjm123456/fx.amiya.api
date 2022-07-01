using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbFeaturedBindCrowdRequest : JdRequestBase<AdsDspRtbFeaturedBindCrowdResponse>
    {
                                                                                                                                              public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  crowdId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  adGroupPrice {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  isUsed {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                    public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.featured.bindCrowd";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                                                                                                        parameters.Add("crowdId", this.            crowdId
);
                                                                                                        parameters.Add("adGroupPrice", this.            adGroupPrice
);
                                                                                                        parameters.Add("isUsed", this.            isUsed
);
                                                                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

