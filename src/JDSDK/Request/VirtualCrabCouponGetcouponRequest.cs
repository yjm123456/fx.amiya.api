using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VirtualCrabCouponGetcouponRequest : JdRequestBase<VirtualCrabCouponGetcouponResponse>
    {
                                                                                                                                              public  		string
              merchantId
 {get; set;}
                                                          
                                                          public  		string
              merchantName
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              channelType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              couponType
 {get; set;}
                                                          
                                                          public  		string
              couponNumber
 {get; set;}
                                                          
                                                          public  		string
              trackingName
 {get; set;}
                                                          
                                                          public  		string
              trackingNumber
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              sendTime
 {get; set;}
                                                          
                                                          public  		string
              receiverName
 {get; set;}
                                                          
                                                          public  		string
              receiverMobile
 {get; set;}
                                                          
                                                          public  		string
              sendSerialNumber
 {get; set;}
                                                          
                                                                                                                                                public override string ApiName
            {
                get{return "jingdong.virtual.crabCoupon.getcoupon";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("merchantId", this.            merchantId
);
                                                                                                        parameters.Add("merchantName", this.            merchantName
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("channelType", this.            channelType
);
                                                                                                        parameters.Add("couponType", this.            couponType
);
                                                                                                        parameters.Add("couponNumber", this.            couponNumber
);
                                                                                                        parameters.Add("trackingName", this.            trackingName
);
                                                                                                        parameters.Add("trackingNumber", this.            trackingNumber
);
                                                                                                        parameters.Add("sendTime", this.            sendTime
);
                                                                                                        parameters.Add("receiverName", this.            receiverName
);
                                                                                                        parameters.Add("receiverMobile", this.            receiverMobile
);
                                                                                                        parameters.Add("sendSerialNumber", this.            sendSerialNumber
);
                                                                                                                                                                                                                            }
    }
}





        
 

