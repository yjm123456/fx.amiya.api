using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspKcAdQuerySkuInfoRequest : JdRequestBase<DspKcAdQuerySkuInfoResponse>
    {
                                                                                                                                              public  		string
              skuId
 {get; set;}
                                                          
                                                          public  		string
              adGroupId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dsp.kc.ad.querySkuInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                                            }
    }
}





        
 

