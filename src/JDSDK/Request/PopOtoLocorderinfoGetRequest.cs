using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOtoLocorderinfoGetRequest : JdRequestBase<PopOtoLocorderinfoGetResponse>
    {
                                                                                                                   public  		Nullable<long>
                                                                                      orderId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      codeType
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.pop.oto.locorderinfo.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("order_id", this.                                                                                    orderId
);
                                                                                                        parameters.Add("code_type", this.                                                                                    codeType
);
                                                    }
    }
}





        
 

