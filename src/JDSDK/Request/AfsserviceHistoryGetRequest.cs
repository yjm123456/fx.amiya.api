using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AfsserviceHistoryGetRequest : JdRequestBase<AfsserviceHistoryGetResponse>
    {
                                                                                  public  		Nullable<long>
              orderId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.afsservice.history.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("orderId", this.            orderId
);
                                                    }
    }
}





        
 

