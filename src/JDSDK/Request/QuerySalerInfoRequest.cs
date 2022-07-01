using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class QuerySalerInfoRequest : JdRequestBase<QuerySalerInfoResponse>
    {
                                                                                                                   public  		string
              bizToken
 {get; set;}
                                                          
                                                          public  		string
              source
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              shopId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.querySalerInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("bizToken", this.            bizToken
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                        parameters.Add("shopId", this.            shopId
);
                                                    }
    }
}





        
 

