using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AfsserviceFreightmessageGetRequest : JdRequestBase<AfsserviceFreightmessageGetResponse>
    {
                                                                                                                   public  		Nullable<int>
              afsServiceId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.afsservice.freightmessage.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("afsServiceId", this.            afsServiceId
);
                                                    }
    }
}





        
 

