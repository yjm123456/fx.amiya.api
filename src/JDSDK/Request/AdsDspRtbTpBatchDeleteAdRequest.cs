using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpBatchDeleteAdRequest : JdRequestBase<AdsDspRtbTpBatchDeleteAdResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  adIds {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                    public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.batchDeleteAd";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("adIds", this.            adIds
);
                                                                                                                                                                                                                                                                                                                                                                    }
    }
}





        
 

