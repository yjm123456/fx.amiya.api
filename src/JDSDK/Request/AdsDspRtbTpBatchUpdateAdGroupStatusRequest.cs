using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpBatchUpdateAdGroupStatusRequest : JdRequestBase<AdsDspRtbTpBatchUpdateAdGroupStatusResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  idList {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.batchUpdateAdGroupStatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("idList", this.            idList
);
                                                                                                                                parameters.Add("status", this.            status
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

