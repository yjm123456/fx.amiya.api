using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ImgzonePictureIsreferencedRequest : JdRequestBase<ImgzonePictureIsreferencedResponse>
    {
                                                                                                                   public  		string
                                                                                      pictureId
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.imgzone.picture.isreferenced";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("picture_id", this.                                                                                    pictureId
);
                                                    }
    }
}





        
 

