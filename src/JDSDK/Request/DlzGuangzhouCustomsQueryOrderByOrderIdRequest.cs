using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DlzGuangzhouCustomsQueryOrderByOrderIdRequest : JdRequestBase<DlzGuangzhouCustomsQueryOrderByOrderIdResponse>
    {
                                                                                                                                                                               public  		string
              platformId
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dlz.guangzhou.customs.queryOrderByOrderId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("platformId", this.            platformId
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                            }
    }
}





        
 

