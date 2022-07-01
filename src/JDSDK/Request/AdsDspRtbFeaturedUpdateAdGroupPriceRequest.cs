using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbFeaturedUpdateAdGroupPriceRequest : JdRequestBase<AdsDspRtbFeaturedUpdateAdGroupPriceResponse>
    {
                                                                                                                                              public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  		string
              fee
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.featured.updateAdGroupPrice";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("fee", this.            fee
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

