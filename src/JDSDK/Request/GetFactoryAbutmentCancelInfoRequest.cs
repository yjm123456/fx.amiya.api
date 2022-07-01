using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class GetFactoryAbutmentCancelInfoRequest : JdRequestBase<GetFactoryAbutmentCancelInfoResponse>
    {
                                                                                  public  		string
              authorizedSequence
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.getFactoryAbutmentCancelInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("authorizedSequence", this.            authorizedSequence
);
                                                    }
    }
}





        
 

