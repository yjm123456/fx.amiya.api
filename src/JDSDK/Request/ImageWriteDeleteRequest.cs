using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ImageWriteDeleteRequest : JdRequestBase<ImageWriteDeleteResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                                                      public  		string
              colorIds
 {get; set;}
                                                          
                                                                                      public  		string
              imgIndexes
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.image.write.delete";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                        parameters.Add("colorIds", this.            colorIds
);
                                                                                                        parameters.Add("imgIndexes", this.            imgIndexes
);
                                                    }
    }
}





        
 

