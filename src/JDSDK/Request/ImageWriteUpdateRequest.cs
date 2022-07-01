using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ImageWriteUpdateRequest : JdRequestBase<ImageWriteUpdateResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  colorId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  imgId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  imgIndex {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  imgUrl {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  imgZoneId {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.image.write.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                                                                                                        parameters.Add("colorId", this.            colorId
);
                                                                                                        parameters.Add("imgId", this.            imgId
);
                                                                                                        parameters.Add("imgIndex", this.            imgIndex
);
                                                                                                        parameters.Add("imgUrl", this.            imgUrl
);
                                                                                                        parameters.Add("imgZoneId", this.            imgZoneId
);
                                                                                                    }
    }
}





        
 

