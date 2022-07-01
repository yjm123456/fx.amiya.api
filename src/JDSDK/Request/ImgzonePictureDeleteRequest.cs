using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ImgzonePictureDeleteRequest : JdRequestBase<ImgzonePictureDeleteResponse>
    {
                                                                                                                   public  		string
                                                                                      pictureIds
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.imgzone.picture.delete";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("picture_ids", this.                                                                                    pictureIds
);
                                                    }
    }
}





        
 

