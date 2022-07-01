using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspKcCampainGetRequest : JdRequestBase<DspKcCampainGetResponse>
    {
                                                                                                                                              public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                                                                                                                public override string ApiName
            {
                get{return "jingdong.dsp.kc.campain.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                                                                                                                                            }
    }
}





        
 

