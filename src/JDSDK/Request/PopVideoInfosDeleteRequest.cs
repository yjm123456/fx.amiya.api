using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopVideoInfosDeleteRequest : JdRequestBase<PopVideoInfosDeleteResponse>
    {
                                                                                                                                               public  		string
                                                                                      videoIds
 {get; set;}
                                                                                                                                  
                                                                                                                                                                                                                                             public override string ApiName
            {
                get{return "jingdong.pop.video.infos.delete";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("video_ids", this.                                                                                    videoIds
);
                                                                                                                                                                                                                                                                                                                    }
    }
}





        
 

