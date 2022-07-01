using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpBatchUpdatePosPackageCoefRequest : JdRequestBase<AdsDspRtbTpBatchUpdatePosPackageCoefResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  ids {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              coef
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.batchUpdatePosPackageCoef";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("ids", this.            ids
);
                                                                                                                                parameters.Add("coef", this.            coef
);
                                                                                                        parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

