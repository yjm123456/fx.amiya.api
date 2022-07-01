using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpAddAdRequest : JdRequestBase<AdsDspRtbTpAddAdResponse>
    {
                                                                                                                                              public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                          public  		string
              skuId
 {get; set;}
                                                          
                                                          public  		string
              customTitle
 {get; set;}
                                                          
                                                          public  		string
              imgUrl
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.addAd";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("customTitle", this.            customTitle
);
                                                                                                        parameters.Add("imgUrl", this.            imgUrl
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

