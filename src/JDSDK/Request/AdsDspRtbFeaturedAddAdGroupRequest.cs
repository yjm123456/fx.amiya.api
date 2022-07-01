using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbFeaturedAddAdGroupRequest : JdRequestBase<AdsDspRtbFeaturedAddAdGroupResponse>
    {
                                                                                                                                              public  		string
              fee
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  positions {get; set; }
                                                                                                                                                                                                public  		string
              name
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.featured.addAdGroup";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("fee", this.            fee
);
                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                                                                parameters.Add("positions", this.            positions
);
                                                                                                                                parameters.Add("name", this.            name
);
                                                                                                                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

