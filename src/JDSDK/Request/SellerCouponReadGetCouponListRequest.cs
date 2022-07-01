using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerCouponReadGetCouponListRequest : JdRequestBase<SellerCouponReadGetCouponListResponse>
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
                                                          
                                                          public  		Nullable<int>
              type
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              grantType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              bindType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              grantWay
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                                          public  		string
              createMonth
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              creatorType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              closed
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.seller.coupon.read.getCouponList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("ip", this.            ip
);
                                                                                                        parameters.Add("port", this.            port
);
                                                                                                                                                                                                                        parameters.Add("couponId", this.            couponId
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("grantType", this.            grantType
);
                                                                                                        parameters.Add("bindType", this.            bindType
);
                                                                                                        parameters.Add("grantWay", this.            grantWay
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("createMonth", this.            createMonth
);
                                                                                                        parameters.Add("creatorType", this.            creatorType
);
                                                                                                        parameters.Add("closed", this.            closed
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                            }
    }
}





        
 

