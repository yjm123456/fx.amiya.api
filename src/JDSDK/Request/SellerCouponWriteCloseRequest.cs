using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerCouponWriteCloseRequest : JdRequestBase<SellerCouponWriteCloseResponse>
    {
                                                                                                                                                                                                                public  		string
              ip
 {get; set;}
                                                          
                                                          public  		string
              port
 {get; set;}
                                                          
                                                                                                                            public  		Nullable<long>
              couponId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.seller.coupon.write.close";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("ip", this.            ip
);
                                                                                                        parameters.Add("port", this.            port
);
                                                                                                                                                                                parameters.Add("couponId", this.            couponId
);
                                                    }
    }
}





        
 

