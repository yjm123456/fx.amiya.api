using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcGetcomponentlistRequest : JdRequestBase<VcGetcomponentlistResponse>
    {
                                                                                  public  		string
              type
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.vc.getcomponentlist";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("type", this.            type
);
                                                    }
    }
}





        
 

