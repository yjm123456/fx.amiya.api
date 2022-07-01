using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKcAdUpdateStatusRequest : JdRequestBase<AdsDspRtbKcAdUpdateStatusResponse>
    {
                                                                                                                                              public  		Nullable<int>
              operateType
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  adIds {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                    public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.kc.ad.updateStatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("operateType", this.            operateType
);
                                                                                                                                                parameters.Add("adIds", this.            adIds
);
                                                                                                                                                                                                                                                                                                                                                                    }
    }
}





        
 

