using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerCouponWritePushCouponRequest : JdRequestBase<SellerCouponWritePushCouponResponse>
    {
                                                                                                                                                                                                                                                                                                                                                    public  		string
              port
 {get; set;}
                                                          
                                                          public  		string
              requestId
 {get; set;}
                                                          
                                                                                                                                                       public  		string
              pin
 {get; set;}
                                                          
                                                                                           public  		string
              distrTime
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              couponId
 {get; set;}
                                                          
                                                          public  		string
              uuid
 {get; set;}
                                                          
                                                          public  		string
                                                                                                                      openIdBuyer
 {get; set;}
                                                                                                                                                          
                                             public override string ApiName
            {
                get{return "jingdong.seller.coupon.write.pushCoupon";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                                                                                        parameters.Add("port", this.            port
);
                                                                                                        parameters.Add("requestId", this.            requestId
);
                                                                                                                                                                        parameters.Add("pin", this.            pin
);
                                                                                                                                                        parameters.Add("distrTime", this.            distrTime
);
                                                                                                        parameters.Add("couponId", this.            couponId
);
                                                                                                        parameters.Add("uuid", this.            uuid
);
                                                                                                        parameters.Add("open_id_buyer", this.                                                                                                                    openIdBuyer
);
                                                                            }
    }
}





        
 

