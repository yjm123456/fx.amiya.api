using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpGetAdGroupRequest : JdRequestBase<AdsDspRtbTpGetAdGroupResponse>
    {
                                                                                                                                              public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.getAdGroup";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("id", this.            id
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

