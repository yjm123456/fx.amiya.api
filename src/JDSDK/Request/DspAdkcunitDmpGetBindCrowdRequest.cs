using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkcunitDmpGetBindCrowdRequest : JdRequestBase<DspAdkcunitDmpGetBindCrowdResponse>
    {
                                                                                                                   public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              displayType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.adkcunit.dmp.getBindCrowd";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                        parameters.Add("displayType", this.            displayType
);
                                                                                                    }
    }
}





        
 

