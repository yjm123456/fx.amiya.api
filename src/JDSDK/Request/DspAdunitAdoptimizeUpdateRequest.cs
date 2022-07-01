using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdunitAdoptimizeUpdateRequest : JdRequestBase<DspAdunitAdoptimizeUpdateResponse>
    {
                                                                                                                                              public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              adOptimize
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.dsp.adunit.adoptimize.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("adOptimize", this.            adOptimize
);
                                                                                                                                                                            }
    }
}





        
 

