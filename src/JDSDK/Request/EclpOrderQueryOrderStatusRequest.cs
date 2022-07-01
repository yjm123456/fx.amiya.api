using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpOrderQueryOrderStatusRequest : JdRequestBase<EclpOrderQueryOrderStatusResponse>
    {
                                                                                  public  		string
              eclpSoNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.order.queryOrderStatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("eclpSoNo", this.            eclpSoNo
);
                                                                                                    }
    }
}





        
 

