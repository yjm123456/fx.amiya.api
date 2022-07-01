using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspKcAdAddskuadRequest : JdRequestBase<DspKcAdAddskuadResponse>
    {
                                                                                                                                              public  		string
              name
 {get; set;}
                                                          
                                                                                           public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                          public  		string
              skuId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dsp.kc.ad.addskuad";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                                                                        parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                                            }
    }
}





        
 

