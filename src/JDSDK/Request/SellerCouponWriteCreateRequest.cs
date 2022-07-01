using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerCouponWriteCreateRequest : JdRequestBase<SellerCouponWriteCreateResponse>
    {
                                                                                                                                                                                                                public  		string
              ip
 {get; set;}
                                                          
                                                          public  		string
              port
 {get; set;}
                                                          
                                                                                                                                                                                        public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              type
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              bindType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              grantType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              num
 {get; set;}
                                                          
                                                          public  		string
              discount
 {get; set;}
                                                          
                                                          public  		string
              quota
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              validityType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              days
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              beginTime
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              endTime
 {get; set;}
                                                          
                                                          public  		string
              password
 {get; set;}
                                                          
                                                          public  		string
              batchKey
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              member
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              takeBeginTime
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              takeEndTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              takeRule
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              takeNum
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              display
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              platformType
 {get; set;}
                                                          
                                                          public  		string
              platform
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              shareType
 {get; set;}
                                                          
                                                          public  		string
              activityLink
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              userClass
 {get; set;}
                                                          
                                                          public  		string
              paidMembers
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                            		public  		string
  skuId {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.seller.coupon.write.create";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("ip", this.            ip
);
                                                                                                        parameters.Add("port", this.            port
);
                                                                                                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("bindType", this.            bindType
);
                                                                                                        parameters.Add("grantType", this.            grantType
);
                                                                                                        parameters.Add("num", this.            num
);
                                                                                                        parameters.Add("discount", this.            discount
);
                                                                                                        parameters.Add("quota", this.            quota
);
                                                                                                        parameters.Add("validityType", this.            validityType
);
                                                                                                        parameters.Add("days", this.            days
);
                                                                                                        parameters.Add("beginTime", this.            beginTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("password", this.            password
);
                                                                                                        parameters.Add("batchKey", this.            batchKey
);
                                                                                                        parameters.Add("member", this.            member
);
                                                                                                        parameters.Add("takeBeginTime", this.            takeBeginTime
);
                                                                                                        parameters.Add("takeEndTime", this.            takeEndTime
);
                                                                                                        parameters.Add("takeRule", this.            takeRule
);
                                                                                                        parameters.Add("takeNum", this.            takeNum
);
                                                                                                        parameters.Add("display", this.            display
);
                                                                                                        parameters.Add("platformType", this.            platformType
);
                                                                                                        parameters.Add("platform", this.            platform
);
                                                                                                        parameters.Add("shareType", this.            shareType
);
                                                                                                        parameters.Add("activityLink", this.            activityLink
);
                                                                                                        parameters.Add("userClass", this.            userClass
);
                                                                                                        parameters.Add("paidMembers", this.            paidMembers
);
                                                                                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                            }
    }
}





        
 

