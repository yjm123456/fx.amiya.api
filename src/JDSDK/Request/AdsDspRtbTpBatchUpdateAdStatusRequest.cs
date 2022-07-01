using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpBatchUpdateAdStatusRequest : JdRequestBase<AdsDspRtbTpBatchUpdateAdStatusResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  adIds {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.batchUpdateAdStatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("adIds", this.            adIds
);
                                                                                                                                parameters.Add("status", this.            status
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

