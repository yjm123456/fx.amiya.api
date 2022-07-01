using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VirtualCrabCouponInvalidRequest : JdRequestBase<VirtualCrabCouponInvalidResponse>
    {
                                                                                                                                              public  		string
              merchantId
 {get; set;}
                                                          
                                                          public  		string
              merchantName
 {get; set;}
                                                          
                                                          public  		string
              couponNumber
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              invalidTime
 {get; set;}
                                                          
                                                          public  		string
              invalidSerialNumber
 {get; set;}
                                                          
                                                                                                                                                public override string ApiName
            {
                get{return "jingdong.virtual.crabCoupon.invalid";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("merchantId", this.            merchantId
);
                                                                                                        parameters.Add("merchantName", this.            merchantName
);
                                                                                                        parameters.Add("couponNumber", this.            couponNumber
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                        parameters.Add("invalidTime", this.            invalidTime
);
                                                                                                        parameters.Add("invalidSerialNumber", this.            invalidSerialNumber
);
                                                                                                                                                                                                                            }
    }
}





        
 

