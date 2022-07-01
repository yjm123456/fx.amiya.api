using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ImgzonePictureUploadRequest : JdRequestBase<ImgzonePictureUploadResponse>
    {
                                                                                                                   public  		string
                                                                                      imageData
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                                                      pictureCateId
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      pictureName
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.imgzone.picture.upload";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("image_data", this.                                                                                    imageData
);
                                                                                                        parameters.Add("picture_cate_id", this.                                                                                                                    pictureCateId
);
                                                                                                        parameters.Add("picture_name", this.                                                                                    pictureName
);
                                                    }
    }
}





        
 

