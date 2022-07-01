using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOrderCoupondetailRequest : JdRequestBase<PopOrderCoupondetailResponse>
    {
                                                                                  public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.order.coupondetail";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("orderId", this.            orderId
);
                                                                                                    }
    }
}





        
 

