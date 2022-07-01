using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangUploadImgRequest : JdRequestBase<ErsFangUploadImgResponse>
    {
                                                                                  public  		string
              urls
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ers.fang.uploadImg";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("urls", this.            urls
);
                                                                                                    }
    }
}





        
 

