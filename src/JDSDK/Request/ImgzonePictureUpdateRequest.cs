using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ImgzonePictureUpdateRequest : JdRequestBase<ImgzonePictureUpdateResponse>
    {
                                                                                                                   public  		string
                                                                                      pictureId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      pictureName
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                                                      pictureCateId
 {get; set;}
                                                                                                                                                          
            public override string ApiName
            {
                get{return "jingdong.imgzone.picture.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("picture_id", this.                                                                                    pictureId
);
                                                                                                        parameters.Add("picture_name", this.                                                                                    pictureName
);
                                                                                                        parameters.Add("picture_cate_id", this.                                                                                                                    pictureCateId
);
                                                    }
    }
}





        
 

