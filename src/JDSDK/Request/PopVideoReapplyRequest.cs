using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopVideoReapplyRequest : JdRequestBase<PopVideoReapplyResponse>
    {
                                                                                                                   public  		Nullable<long>
                                                                                      videoId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      applyReason
 {get; set;}
                                                                                                                                  
                                                                                                                                                                                                                                             public override string ApiName
            {
                get{return "jingdong.pop.video.reapply";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("video_id", this.                                                                                    videoId
);
                                                                                                        parameters.Add("apply_reason", this.                                                                                    applyReason
);
                                                                                                                                                                                                                                                                                                                    }
    }
}





        
 

