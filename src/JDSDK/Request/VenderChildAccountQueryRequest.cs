using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VenderChildAccountQueryRequest : JdRequestBase<VenderChildAccountQueryResponse>
    {
                                                                                                                   public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              size
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.vender.childAccount.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("size", this.            size
);
                                                                                                    }
    }
}





        
 

