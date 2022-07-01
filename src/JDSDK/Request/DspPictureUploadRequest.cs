using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspPictureUploadRequest : JdRequestBase<DspPictureUploadResponse>
    {
                                                                                  public  		string
              picFile
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.dsp.picture.upload";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("picFile", this.            picFile
);
                                                    }
    }
}





        
 

