using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ImgzonePictureQueryRequest : JdRequestBase<ImgzonePictureQueryResponse>
    {
                                                                                                                                                                               public  		string
                                                                                      pictureId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                                                      pictureCateId
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      pictureName
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                      startDate
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                      endDate
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageNum
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.imgzone.picture.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("picture_id", this.                                                                                    pictureId
);
                                                                                                        parameters.Add("picture_cate_id", this.                                                                                                                    pictureCateId
);
                                                                                                        parameters.Add("picture_name", this.                                                                                    pictureName
);
                                                                                                        parameters.Add("start_date", this.                                                                                    startDate
);
                                                                                                        parameters.Add("end_Date", this.                                                                                    endDate
);
                                                                                                        parameters.Add("page_num", this.                                                                                    pageNum
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                            }
    }
}





        
 

