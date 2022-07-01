using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpBatchUpdatePosPackageStatusRequest : JdRequestBase<AdsDspRtbTpBatchUpdatePosPackageStatusResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  ids {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              enable
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.batchUpdatePosPackageStatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("ids", this.            ids
);
                                                                                                                                parameters.Add("enable", this.            enable
);
                                                                                                        parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

