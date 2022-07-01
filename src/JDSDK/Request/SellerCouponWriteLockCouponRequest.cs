using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerCouponWriteLockCouponRequest : JdRequestBase<SellerCouponWriteLockCouponResponse>
    {
                                                                                                                                                                                                                                                                                  public  		string
              port
 {get; set;}
                                                          
                                                          public  		string
              requestId
 {get; set;}
                                                          
                                                          public  		string
              time
 {get; set;}
                                                          
                                                                                                                                                       public  		string
              purpose
 {get; set;}
                                                          
                                                          public  		string
              operateTime
 {get; set;}
                                                          
                                                                                           public  		Nullable<long>
              couponId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.seller.coupon.write.lockCoupon";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                        parameters.Add("port", this.            port
);
                                                                                                        parameters.Add("requestId", this.            requestId
);
                                                                                                        parameters.Add("time", this.            time
);
                                                                                                                                                                        parameters.Add("purpose", this.            purpose
);
                                                                                                        parameters.Add("operateTime", this.            operateTime
);
                                                                                                                                                        parameters.Add("couponId", this.            couponId
);
                                                                            }
    }
}





        
 

