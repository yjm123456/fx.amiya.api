using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ImgzoneImageQueryAllRequest : JdRequestBase<ImgzoneImageQueryAllResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
                                                                                      categoryId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      imageName
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      scrollId
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.imgzone.image.queryAll";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("category_id", this.                                                                                    categoryId
);
                                                                                                        parameters.Add("image_name", this.                                                                                    imageName
);
                                                                                                        parameters.Add("scroll_id", this.                                                                                    scrollId
);
                                                                            }
    }
}





        
 

