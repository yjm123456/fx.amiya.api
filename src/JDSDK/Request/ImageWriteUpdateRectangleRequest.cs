using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ImageWriteUpdateRectangleRequest : JdRequestBase<ImageWriteUpdateRectangleResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                          public  		string
              colorId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  imgId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  imgRectangleUrl {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  imgIndex {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.image.write.updateRectangle";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                        parameters.Add("colorId", this.            colorId
);
                                                                                                                                                                                        parameters.Add("imgId", this.            imgId
);
                                                                                                        parameters.Add("imgRectangleUrl", this.            imgRectangleUrl
);
                                                                                                        parameters.Add("imgIndex", this.            imgIndex
);
                                                                                                    }
    }
}





        
 

