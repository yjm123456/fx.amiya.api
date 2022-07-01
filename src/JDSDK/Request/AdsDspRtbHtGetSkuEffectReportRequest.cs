using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbHtGetSkuEffectReportRequest : JdRequestBase<AdsDspRtbHtGetSkuEffectReportResponse>
    {
                                                                                                                                              public  		Nullable<long>
              activityId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clickOrOrderDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              clickStartDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              clickEndDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              orderStartDay
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              orderEndDay
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderStatus
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              platform
 {get; set;}
                                                          
                                                          public  		string
              province
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              giftFlag
 {get; set;}
                                                          
                                                          public  		string
              mySelf
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.ht.getSkuEffectReport";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("activityId", this.            activityId
);
                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("clickOrOrderDay", this.            clickOrOrderDay
);
                                                                                                        parameters.Add("clickStartDay", this.            clickStartDay
);
                                                                                                        parameters.Add("clickEndDay", this.            clickEndDay
);
                                                                                                        parameters.Add("orderStartDay", this.            orderStartDay
);
                                                                                                        parameters.Add("orderEndDay", this.            orderEndDay
);
                                                                                                        parameters.Add("orderStatus", this.            orderStatus
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("platform", this.            platform
);
                                                                                                        parameters.Add("province", this.            province
);
                                                                                                        parameters.Add("giftFlag", this.            giftFlag
);
                                                                                                        parameters.Add("mySelf", this.            mySelf
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

