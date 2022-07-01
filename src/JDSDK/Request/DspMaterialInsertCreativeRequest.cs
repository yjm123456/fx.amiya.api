using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspMaterialInsertCreativeRequest : JdRequestBase<DspMaterialInsertCreativeResponse>
    {
                                                                                  public  		string
              imgUrl
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.material.insertCreative";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("imgUrl", this.            imgUrl
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                    }
    }
}





        
 

