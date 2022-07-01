using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VirtualCrabCouponDeliverycouponRequest : JdRequestBase<VirtualCrabCouponDeliverycouponResponse>
    {
                                                                                                                                              public  		string
              couponNumber
 {get; set;}
                                                          
                                                          public  		string
              merchantName
 {get; set;}
                                                          
                                                          public  		string
              merchantId
 {get; set;}
                                                          
                                                          public  		string
              trackingName
 {get; set;}
                                                          
                                                          public  		string
              trackingNumber
 {get; set;}
                                                          
                                                          public  		string
              trackingCode
 {get; set;}
                                                          
                                                          public  		string
              deliveryAddress
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              deliveryTime
 {get; set;}
                                                          
                                                          public  		string
              receiverName
 {get; set;}
                                                          
                                                          public  		string
              receiverMobile
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              deliveryStatus
 {get; set;}
                                                          
                                                          public  		string
              deliverySerialNumber
 {get; set;}
                                                          
                                                                                                                                                public override string ApiName
            {
                get{return "jingdong.virtual.crabCoupon.deliverycoupon";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("couponNumber", this.            couponNumber
);
                                                                                                        parameters.Add("merchantName", this.            merchantName
);
                                                                                                        parameters.Add("merchantId", this.            merchantId
);
                                                                                                        parameters.Add("trackingName", this.            trackingName
);
                                                                                                        parameters.Add("trackingNumber", this.            trackingNumber
);
                                                                                                        parameters.Add("trackingCode", this.            trackingCode
);
                                                                                                        parameters.Add("deliveryAddress", this.            deliveryAddress
);
                                                                                                        parameters.Add("deliveryTime", this.            deliveryTime
);
                                                                                                        parameters.Add("receiverName", this.            receiverName
);
                                                                                                        parameters.Add("receiverMobile", this.            receiverMobile
);
                                                                                                        parameters.Add("deliveryStatus", this.            deliveryStatus
);
                                                                                                        parameters.Add("deliverySerialNumber", this.            deliverySerialNumber
);
                                                                                                                                                                                                                            }
    }
}





        
 

