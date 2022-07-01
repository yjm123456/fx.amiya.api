using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ImgzoneIcImageDeleteByQueryRequest : JdRequestBase<ImgzoneIcImageDeleteByQueryResponse>
    {
                                                                                                                                                                                                                                                                                                                                              public  		string
              imgId
 {get; set;}
                                                          
                                                          public  		string
              imgJfsKey
 {get; set;}
                                                          
                                                                                           public  		string
              operate
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.imgzone.ic.image.deleteByQuery";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                        parameters.Add("imgId", this.            imgId
);
                                                                                                        parameters.Add("imgJfsKey", this.            imgJfsKey
);
                                                                                                                                                        parameters.Add("operate", this.            operate
);
                                                                            }
    }
}





        
 

