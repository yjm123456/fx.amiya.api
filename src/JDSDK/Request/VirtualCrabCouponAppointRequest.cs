using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VirtualCrabCouponAppointRequest : JdRequestBase<VirtualCrabCouponAppointResponse>
    {
                                                                                                                                              public  		string
              couponNumber
 {get; set;}
                                                          
                                                          public  		string
              merchantId
 {get; set;}
                                                          
                                                          public  		string
              merchantName
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              appointTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              deliveryType
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
                                                          
                                                          public  		string
              appointSerialNumber
 {get; set;}
                                                          
                                                                                                                                                public override string ApiName
            {
                get{return "jingdong.virtual.crabCoupon.appoint";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("couponNumber", this.            couponNumber
);
                                                                                                        parameters.Add("merchantId", this.            merchantId
);
                                                                                                        parameters.Add("merchantName", this.            merchantName
);
                                                                                                        parameters.Add("appointTime", this.            appointTime
);
                                                                                                        parameters.Add("deliveryType", this.            deliveryType
);
                                                                                                        parameters.Add("deliveryAddress", this.            deliveryAddress
);
                                                                                                        parameters.Add("deliveryTime", this.            deliveryTime
);
                                                                                                        parameters.Add("receiverName", this.            receiverName
);
                                                                                                        parameters.Add("receiverMobile", this.            receiverMobile
);
                                                                                                        parameters.Add("appointSerialNumber", this.            appointSerialNumber
);
                                                                                                                                                                                                                            }
    }
}





        
 

