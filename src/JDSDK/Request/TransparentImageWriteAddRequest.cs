using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class TransparentImageWriteAddRequest : JdRequestBase<TransparentImageWriteAddResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  colorId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  imageUrl {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.transparentImage.write.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                                                                                                        parameters.Add("colorId", this.            colorId
);
                                                                                                        parameters.Add("imageUrl", this.            imageUrl
);
                                                                                                    }
    }
}





        
 

