using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bOrderLogisticsGetRequest : JdRequestBase<B2bOrderLogisticsGetResponse>
    {
                                                                                  public  		Nullable<long>
              jdOrderId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.b2b.order.logistics.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("jdOrderId", this.            jdOrderId
);
                                                                                                                                                    }
    }
}





        
 

