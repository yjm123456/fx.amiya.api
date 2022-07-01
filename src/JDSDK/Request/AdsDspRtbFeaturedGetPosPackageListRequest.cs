using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbFeaturedGetPosPackageListRequest : JdRequestBase<AdsDspRtbFeaturedGetPosPackageListResponse>
    {
                                                                                                                                              public  		Nullable<int>
              campaignType
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              device
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.featured.getPosPackageList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("campaignType", this.            campaignType
);
                                                                                                                                                        parameters.Add("device", this.            device
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

