using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class GetFactoryAbutmentOrderInfoRequest : JdRequestBase<GetFactoryAbutmentOrderInfoResponse>
    {
                                                                                  public  		string
              authorizedSequence
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.getFactoryAbutmentOrderInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("authorizedSequence", this.            authorizedSequence
);
                                                    }
    }
}





        
 

