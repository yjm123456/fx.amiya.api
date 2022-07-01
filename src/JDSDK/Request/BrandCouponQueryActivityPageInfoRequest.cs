using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class BrandCouponQueryActivityPageInfoRequest : JdRequestBase<BrandCouponQueryActivityPageInfoResponse>
    {
                                                                                                                                                                               public  		Nullable<DateTime>
              endDate
 {get; set;}
                                                          
                                                          public  		string
              activityName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              currentPage
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startDate
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.brand.coupon.queryActivityPageInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("activityName", this.            activityName
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("currentPage", this.            currentPage
);
                                                                                                        parameters.Add("startDate", this.            startDate
);
                                                                            }
    }
}





        
 

