using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class BuildPayRequestRequest : JdRequestBase<BuildPayRequestResponse>
    {
                                                                                                                   public  		Nullable<long>
              shopId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		string
              source
 {get; set;}
                                                          
                                                          public  		string
              bizToken
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.buildPayRequest";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("shopId", this.            shopId
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                        parameters.Add("bizToken", this.            bizToken
);
                                                    }
    }
}





        
 

